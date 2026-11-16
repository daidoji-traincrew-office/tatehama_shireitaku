using SharpDX.Multimedia;
using SharpDX.XAudio2;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;

namespace TatehamaCommanderTable.Services
{
    /// <summary>
    /// Soundクラス
    /// </summary>
    public class Sound
    {
        private static readonly Sound _instance = new();
        public static Sound Instance => _instance;

        private XAudio2 xAudio2;
        private MasteringVoice masteringVoice;
        private bool _initialized;
        private int _criticalErrorCode;
        private int _lastErrorCode;
        private string _lastErrorMessage = "音声出力を初期化できませんでした。";
        public Dictionary<string, SourceVoice> SoundSource = new();
        public Dictionary<string, AudioBuffer> SoundBuffer = new();
        public Dictionary<int, string> SoundData = new();
        public List<string> LoopSoundList = new();
        public float fMasterVolume = 1.0f;
        public float fFadeVolume = 1.0f;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        private Sound()
        {
            TryInitialize();
        }

        /// <summary>
        /// 音声デバイスが利用可能かを取得する。
        /// </summary>
        public bool IsAvailable => _initialized && Volatile.Read(ref _criticalErrorCode) == 0
            && xAudio2 != null && masteringVoice != null && LoopSoundList.Count > 0;

        /// <summary>
        /// 音声リソースが残っているかを取得する。
        /// </summary>
        public bool HasResources => xAudio2 != null || masteringVoice != null || SoundSource.Count > 0;

        /// <summary>
        /// 直近の音声エラーコードを取得する。
        /// </summary>
        public int LastErrorCode
        {
            get
            {
                int criticalErrorCode = Volatile.Read(ref _criticalErrorCode);
                return criticalErrorCode != 0 ? criticalErrorCode : _lastErrorCode;
            }
        }

        /// <summary>
        /// 直近の音声エラーの説明を取得する。
        /// </summary>
        public string LastErrorMessage => _lastErrorMessage;

        /// <summary>
        /// XAudio2の重大な障害を受信し、UI側での復旧処理を要求する。
        /// </summary>
        private void OnCriticalError(object sender, SharpDX.XAudio2.ErrorEventArgs e)
        {
            // 音声処理スレッドではリソース解放や画面操作を行わない
            Volatile.Write(ref _criticalErrorCode, e.ErrorCode.Code);
        }

        /// <summary>
        /// 音声出力に関する例外を記録する。
        /// </summary>
        /// <param name="ex">発生した例外</param>
        public void ReportPlaybackFailure(Exception ex)
        {
            _lastErrorCode = ex.HResult;
            _lastErrorMessage = ex.Message;
            _initialized = false;
            System.Diagnostics.Debug.WriteLine($"音声出力異常: {ex}");
        }

        /// <summary>
        /// ループ音声の読み込み・再生状態を検査する。
        /// </summary>
        /// <returns>音声再生を継続できる場合はtrue</returns>
        public bool CheckPlayback()
        {
            if (!IsAvailable) return false;

            try
            {
                foreach (var fileName in LoopSoundList)
                {
                    if (!SoundSource.TryGetValue(fileName, out var voice) ||
                        !SoundBuffer.ContainsKey(fileName) || voice.State.BuffersQueued <= 0)
                    {
                        throw new InvalidOperationException($"防護無線の音声が再生待機状態ではありません: {fileName}");
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                ReportPlaybackFailure(ex);
                return false;
            }
        }

        /// <summary>
        /// 音声デバイスを初期化する。失敗しても再試行できる状態に戻す。
        /// </summary>
        /// <returns>初期化に成功した場合はtrue</returns>
        public bool TryInitialize()
        {
            if (IsAvailable) return true;

            try
            {
                xAudio2 = new XAudio2();
                xAudio2.CriticalError += OnCriticalError;
                masteringVoice = new MasteringVoice(xAudio2);
                LoadSoundFiles();
                CreateLoopSoundList();
                if (LoopSoundList.Count == 0)
                {
                    throw new InvalidOperationException("防護無線用のループ音声ファイルが見つかりません。");
                }
                PlayAllSounds();
                foreach (var fileName in LoopSoundList)
                {
                    if (!SoundSource.TryGetValue(fileName, out var voice) ||
                        voice.State.BuffersQueued <= 0)
                    {
                        throw new InvalidOperationException($"防護無線の音声を再生待機状態にできません: {fileName}");
                    }
                }
                if (Volatile.Read(ref _criticalErrorCode) != 0)
                {
                    throw new InvalidOperationException("音声デバイスの重大な障害を検出しました。");
                }
                _initialized = true;
                _lastErrorCode = 0;
                _lastErrorMessage = string.Empty;
                return true;
            }
            catch (Exception ex)
            {
                ReportPlaybackFailure(ex);
                ReleaseAudioResources();
                return false;
            }
        }

        /// <summary>
        /// 音声関連リソースを安全に解放する。
        /// </summary>
        private void ReleaseAudioResources()
        {
            _initialized = false;
            int criticalErrorCode = Volatile.Read(ref _criticalErrorCode);
            if (criticalErrorCode != 0)
            {
                _lastErrorCode = criticalErrorCode;
                _lastErrorMessage = "XAudio2が重大な音声デバイス障害を検出しました。";
            }

            if (xAudio2 != null)
            {
                xAudio2.CriticalError -= OnCriticalError;
            }
            ClearSoundData();

            try
            {
                masteringVoice?.Dispose();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"音声出力の解放失敗: {ex}");
            }
            finally
            {
                masteringVoice = null;
            }

            try
            {
                xAudio2?.Dispose();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"音声エンジンの解放失敗: {ex}");
            }
            finally
            {
                xAudio2 = null;
                Volatile.Write(ref _criticalErrorCode, 0);
            }
        }

        /// <summary>
        /// 音声ファイル読み込みメソッド
        /// </summary>
        public void LoadSoundFiles()
        {
            try
            {
                // 既存のSourceVoiceとAudioBufferを解放してクリア
                ClearSoundData();

                // Soundフォルダ内の全てのwavファイルを取得
                var soundFiles = Directory.GetFiles($".\\Sound", "*.wav").ToList();

                // サウンド読み込み
                foreach (var filePath in soundFiles)
                {
                    if (!File.Exists(filePath))
                    {
                        continue;
                    }

                    // サウンドファイルを読み込む
                    using (var stream = new SoundStream(File.OpenRead(filePath)))
                    {
                        var waveFormat = stream.Format;
                        var buffer = new AudioBuffer
                        {
                            Stream = stream.ToDataStream(),
                            AudioBytes = (int)stream.Length,
                            LoopCount = 0,
                            LoopBegin = 0,
                            LoopLength = 0,
                            PlayBegin = 0,
                            PlayLength = 0,
                            Flags = BufferFlags.EndOfStream
                        };

                        // SourceVoiceの作成に失敗した場合はバッファも解放する
                        SourceVoice sourceVoice;
                        try
                        {
                            sourceVoice = new SourceVoice(xAudio2, waveFormat, VoiceFlags.None, maxFrequencyRatio: 4.0f);
                        }
                        catch
                        {
                            buffer.Stream?.Dispose();
                            throw;
                        }

                        // ファイル名をキーとしてSourceVoiceとAudioBufferを辞書に追加
                        var fileName = Path.GetFileNameWithoutExtension(filePath);
                        SoundSource[fileName] = sourceVoice;
                        SoundBuffer[fileName] = buffer;
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"音声ファイル読み込み失敗: {ex}");
                throw;
            }
        }

        /// <summary>
        /// 既存の音声データをクリア
        /// </summary>
        public void ClearSoundData()
        {
            // 音声デバイス切断後でも、残りのリソース解放を続行する
            foreach (var voice in SoundSource.Values)
            {
                try
                {
                    voice?.Stop();
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine($"音声停止失敗: {ex}");
                }

                try
                {
                    voice?.DestroyVoice();
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine($"音声ソース解放失敗: {ex}");
                }
            }
            SoundSource.Clear();

            foreach (var buffer in SoundBuffer.Values)
            {
                try
                {
                    buffer.Stream?.Dispose();
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine($"音声バッファ解放失敗: {ex}");
                }
            }
            SoundBuffer.Clear();
            LoopSoundList.Clear();
        }

        /// <summary>
        /// 音声再生メソッド
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="isLoop"></param>
        /// <param name="volume"></param>
        /// <param name="pitch"></param>
        public void SoundPlay(string fileName, bool isLoop, float volume = 1.0f, float pitch = 1.0f)
        {
            if (!SoundSource.TryGetValue(fileName, out SourceVoice sourceVoice) || sourceVoice == null) return;

            // 既に再生中の場合は処理しない
            if (sourceVoice.State.BuffersQueued > 0) return;

            // 音量とピッチを設定
            SetVolume(fileName, volume);
            SetPitch(fileName, pitch);

            // ループ再生の設定
            if (isLoop)
                SoundBuffer[fileName].LoopCount = 255;
            else
                SoundBuffer[fileName].LoopCount = 0;

            // 再生位置の設定
            SoundBuffer[fileName].PlayBegin = 0;
            SoundBuffer[fileName].PlayLength = 0;

            var buffer = SoundBuffer[fileName];

            // バッファをソースに渡して再生開始
            sourceVoice.SubmitSourceBuffer(buffer, null);
            sourceVoice.Start();
        }

        /// <summary>
        /// 全音声停止メソッド
        /// </summary>
        public void SoundAllStop()
        {
            // 全サウンドを停止
            foreach (var sourceVoice in SoundSource.Values)
            {
                if (sourceVoice != null)
                {
                    sourceVoice.Stop();
                    sourceVoice.FlushSourceBuffers();
                }
            }
        }

        /// <summary>
        /// 音声停止メソッド
        /// </summary>
        /// <param name="fileName"></param>
        public void SoundStop(string fileName)
        {
            if (!SoundSource.TryGetValue(fileName, out SourceVoice value) || value == null) return;

            // 既に停止している場合は処理しない
            if (value.State.BuffersQueued == 0) return;

            value.Stop(0);
            value.FlushSourceBuffers();
        }

        /// <summary>
        /// 音量設定メソッド
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="volume"></param>
        public void SetVolume(string fileName, float volume)
        {
            if (!SoundSource.ContainsKey(fileName) || SoundSource[fileName] == null) return;
            if (volume < 0) volume = 0;
            SoundSource[fileName].SetVolume(fMasterVolume * fFadeVolume * volume);
        }

        /// <summary>
        /// ピッチ設定メソッド
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="pitch"></param>
        public void SetPitch(string fileName, float pitch)
        {
            if (!SoundSource.ContainsKey(fileName) || SoundSource[fileName] == null) return;
            SoundSource[fileName].SetFrequencyRatio(pitch);
        }

        /// <summary>
        /// 再生位置初期化メソッド
        /// </summary>
        /// <param name="fileName"></param>
        public void ResetPosition(string fileName)
        {
            if (!SoundSource.ContainsKey(fileName) || SoundSource[fileName] == null) return;
            SoundBuffer[fileName].PlayLength = 0;
            SoundBuffer[fileName].PlayBegin = 0;
        }

        /// <summary>
        /// マスターボリューム設定メソッド
        /// </summary>
        /// <param name="volume"></param>
        public void SetMasterVolume(float volume)
        {
            if (volume < 0) volume = 0;
            fMasterVolume = volume;

            // 全ての音声にマスターボリュームを設定
            foreach (var sourceVoice in SoundSource.Values)
            {
                if (sourceVoice != null)
                {
                    sourceVoice.SetVolume(fMasterVolume * fFadeVolume);
                }
            }
        }

        /// <summary>
        /// リソース解放
        /// </summary>
        public void Dispose()
        {
            ReleaseAudioResources();
        }

        /// <summary>
        /// ループ音声リストを作成
        /// </summary>
        public void CreateLoopSoundList()
        {
            LoopSoundList.Clear();
            foreach (var fileName in SoundSource.Keys)
            {
                if (fileName.Contains("loop"))
                {
                    LoopSoundList.Add(fileName);
                }
            }
        }

        /// <summary>
        /// 指定した音声の再生位置を返す
        /// </summary>
        /// <param name="fileName">音声ファイル名</param>
        /// <returns>再生位置(割合) 0.0～1.0</returns>
        public float GetPosition(string fileName)
        {
            if (!SoundSource.TryGetValue(fileName, out SourceVoice sourceVoice) || sourceVoice == null)
            {
                throw new ArgumentException($"指定された音声ファイルが見つかりません: {fileName}");
            }

            // 全体サンプル数を取得
            var buffer = SoundBuffer[fileName];
            var totalSamples = buffer.AudioBytes;

            // 再生位置を取得
            var state = sourceVoice.State;
            var sampleRate = sourceVoice.VoiceDetails.InputSampleRate;
            var position = (float)state.SamplesPlayed % totalSamples / totalSamples;

            if (position < 0) position = 0;
            else if (position > 1) position = 1;

            return position;
        }

        /// <summary>
        /// 全音声再生メソッド
        /// </summary>
        public void PlayAllSounds()
        {
            foreach (var fileName in LoopSoundList)
            {
                SoundPlay(fileName, true, 0.0f);
            }
        }
    }
}
