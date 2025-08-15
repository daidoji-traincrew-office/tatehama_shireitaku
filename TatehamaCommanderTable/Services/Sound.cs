using SharpDX.Multimedia;
using SharpDX.XAudio2;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

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
        public Dictionary<string, SourceVoice> SoundSource = new();
        public Dictionary<string, AudioBuffer> SoundBuffer = new();
        public Dictionary<int, string> SoundData = new();
        public List<string> LoopSoundList = new();
        public float fMasterVolume = 1.0f;
        public float fFadeVolume = 1.0f;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public Sound()
        {
            try
            {
                // XAudio2とMasteringVoiceを初期化
                xAudio2 = new();
                masteringVoice = new(xAudio2);
                LoadSoundFiles();
                CreateLoopSoundList();
                PlayAllSounds();
            }
            catch
            {

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

                        // SourceVoiceを作成
                        var sourceVoice = new SourceVoice(xAudio2, waveFormat, VoiceFlags.None, maxFrequencyRatio: 4.0f);

                        // ファイル名をキーとしてSourceVoiceとAudioBufferを辞書に追加
                        var fileName = Path.GetFileNameWithoutExtension(filePath);
                        SoundSource[fileName] = sourceVoice;
                        SoundBuffer[fileName] = buffer;
                    }
                }
            }
            catch
            {

            }
        }

        /// <summary>
        /// 既存の音声データをクリア
        /// </summary>
        public void ClearSoundData()
        {
            // すべてのSourceVoiceを停止して解放
            foreach (var voice in SoundSource.Values)
            {
                if (voice != null)
                {
                    voice.Stop();
                    voice.DestroyVoice();
                }
            }
            SoundSource.Clear();
            SoundBuffer.Clear();
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
            // 既存の音声データをクリア
            ClearSoundData();

            // リソースを解放
            masteringVoice.Dispose();
            xAudio2.Dispose();
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
