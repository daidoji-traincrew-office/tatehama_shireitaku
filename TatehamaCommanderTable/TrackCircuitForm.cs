using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using TatehamaCommanderTable.Communications;
using TatehamaCommanderTable.Manager;
using TatehamaCommanderTable.Models;
using TatehamaCommanderTable.Services;

namespace TatehamaCommanderTable
{
    public partial class TrackCircuitForm : Form
    {
        private readonly DataManager _dataManager;
        private readonly ServerCommunication _serverCommunication;
        public event Action UpdateTrackCircuitData;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="serverCommunication"></param>
        public TrackCircuitForm(ServerCommunication serverCommunication)
        {
            InitializeComponent();

            // インスタンス取得
            _dataManager = DataManager.Instance;
            _serverCommunication = serverCommunication;

            // イベント設定
            Load += TrackCircuitForm_Load;
            FormClosing += TrackCircuitForm_FormClosing;
        }

        /// <summary>
        /// TrackCircuitForm_Loadイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TrackCircuitForm_Load(object sender, EventArgs e)
        {
            // イベントハンドラ設定
            _serverCommunication.DataGridViewUpdated += (newDataSource) => UpdateDataSource(newDataSource);
            TrackCircuit_DataGridView_TrackCircuitData.CellClick += DataGridView_TrackCircuitData_CellClick;

            // DataGridViewのデータバインド
            TrackCircuit_BindingSource.DataSource = _dataManager.DataGridViewSettingList;

            // DataGridViewの設定
            SetupDataGridView();
        }

        /// <summary>
        /// TrackCircuitForm_FormClosingイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TrackCircuitForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Hide();
            e.Cancel = true;
        }

        /// <summary>
        /// 最前面表示切替イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TrackCircuit_CheckBox_TopMost_CheckedChanged(object sender, EventArgs e)
        {
            this.TopMost = TrackCircuit_CheckBox_TopMost.Checked;
        }

        /// <summary>
        /// ボタンクリックイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TrackCircuit_Button_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;

            // 正規表現パターンの定義
            var pattern = @"^([回試臨]?)([0-9]{0,4})(A|B|C|K|X|AX|BX|CX|KX)?$";

            switch (button.Name)
            {
                // 在線削除ボタン
                case "TrackCircuit_Button_DeleteTrainNumber":
                    {
                        _serverCommunication.SendDeleteTrainRequestToServerAsync(TrackCircuit_TextBox_DeleteTrainNumber.Text);
                    }
                    break;
                // サーバー送信ボタン
                case "TrackCircuit_Button_SendServer":
                    {
                        var retsuban = TrackCircuit_TextBox_DeleteTrainNumber.Text;
                        var match = Regex.IsMatch(retsuban, pattern);
                        var retsubanCheck = TrackCircuit_RadioButton_ShortCircuit_ON.Checked;

                        // 列車番号の形式チェック
                        if (retsubanCheck && !match && !retsuban.Contains("溝月"))
                        {
                            CustomMessage.Show("列車番号の形式が正しくありません", "エラー", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);
                            break;
                        }

                        // サーバーにデータ送信
                        var result = new TrackCircuitData
                        {
                            On = TrackCircuit_RadioButton_ShortCircuit_ON.Checked,
                            Lock = TrackCircuit_RadioButton_Locking_ON.Checked,
                            Last = TrackCircuit_RadioButton_ShortCircuit_OFF.Checked ? TrackCircuit_TextBox_TrainNumber.Text : "",
                            Name = TrackCircuit_TextBox_TrackCircuit.Text
                        };
                        _serverCommunication.SendTrackCircuitEventDataRequestToServerAsync(result);
                    }
                    break;
            }
        }

        /// <summary>
        /// DataGridView更新処理
        /// </summary>
        /// <param name="newDataSource"></param>
        public void UpdateDataSource(SortableBindingList<DataGridViewSetting> newDataSource)
        {
            try
            {
                if (!this.IsDisposed)
                {
                    if (this.IsHandleCreated && !this.IsDisposed)
                    {
                        // フィルター設定
                        var filteredData = newDataSource
                            .Where(data => data.trackCircuit.Contains(TrackCircuit_TextBox_FilterTrackCircuit.Text))
                            .Where(data => data.trainNumber.Contains(TrackCircuit_TextBox_FilterTrainNumber.Text))
                            .ToList();
                        if (!TrackCircuit_RadioButton_FilterShortCircuit_All.Checked)
                        {
                            filteredData = filteredData
                                .Where(data => data.shortCircuitStatus == (TrackCircuit_RadioButton_FilterShortCircuit_Only.Checked ? "〇" : ""))
                                .ToList();
                        }
                        if (!TrackCircuit_RadioButton_FilterLocking_All.Checked)
                        {
                            filteredData = filteredData
                                .Where(data => data.lockingStatus == (TrackCircuit_RadioButton_FilterLocking_Only.Checked ? "〇" : ""))
                                .ToList();
                        }

                        // スクロール位置を保持
                        int firstDisplayedScrollingRowIndex = TrackCircuit_DataGridView_TrackCircuitData.FirstDisplayedScrollingRowIndex;
                        int selectedRowIndex = TrackCircuit_DataGridView_TrackCircuitData.CurrentCell?.RowIndex ?? 0;
                        if (firstDisplayedScrollingRowIndex < 0)
                        {
                            firstDisplayedScrollingRowIndex = 0;
                        }

                        // データバインド
                        if (this.InvokeRequired)
                        {
                            this.Invoke(new Action(() =>
                            {
                                if (!this.IsDisposed)
                                {
                                    TrackCircuit_BindingSource.DataSource = filteredData;
                                    if (TrackCircuit_DataGridView_TrackCircuitData.Rows.Count > 0)
                                    {
                                        TrackCircuit_DataGridView_TrackCircuitData.FirstDisplayedScrollingRowIndex = Math.Min(firstDisplayedScrollingRowIndex, TrackCircuit_DataGridView_TrackCircuitData.Rows.Count - 1);
                                        TrackCircuit_DataGridView_TrackCircuitData.CurrentCell = TrackCircuit_DataGridView_TrackCircuitData.Rows[Math.Min(selectedRowIndex, TrackCircuit_DataGridView_TrackCircuitData.Rows.Count - 1)].Cells[0];
                                    }
                                }
                            }));
                        }
                        else
                        {
                            if (!this.IsDisposed)
                            {
                                TrackCircuit_BindingSource.DataSource = filteredData;
                                if (TrackCircuit_DataGridView_TrackCircuitData.Rows.Count > 0)
                                {
                                    TrackCircuit_DataGridView_TrackCircuitData.FirstDisplayedScrollingRowIndex = Math.Min(firstDisplayedScrollingRowIndex, TrackCircuit_DataGridView_TrackCircuitData.Rows.Count - 1);
                                    TrackCircuit_DataGridView_TrackCircuitData.CurrentCell = TrackCircuit_DataGridView_TrackCircuitData.Rows[Math.Min(selectedRowIndex, TrackCircuit_DataGridView_TrackCircuitData.Rows.Count - 1)].Cells[0];
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                CustomMessage.Show(ex.ToString(), "エラー", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);
            }
        }

        /// <summary>
        /// DataGridViewの設定
        /// </summary>
        private void SetupDataGridView()
        {
            // 複数選択不可
            TrackCircuit_DataGridView_TrackCircuitData.MultiSelect = false;

            // 中央揃え
            TrackCircuit_DataGridView_TrackCircuitData.Columns["trainNumber"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            TrackCircuit_DataGridView_TrackCircuitData.Columns["shortCircuitStatus"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            TrackCircuit_DataGridView_TrackCircuitData.Columns["lockingStatus"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        /// <summary>
        /// 選択したデータを表示
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DataGridView_TrackCircuitData_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var selectedRow = TrackCircuit_DataGridView_TrackCircuitData.Rows[e.RowIndex];
                string trackCircuit = selectedRow.Cells["trackCircuit"].Value.ToString();
                string trainNumber = selectedRow.Cells["trainNumber"].Value.ToString();
                string shortCircuitStatus = selectedRow.Cells["shortCircuitStatus"].Value.ToString();
                string lockingStatus = selectedRow.Cells["lockingStatus"].Value.ToString();

                // 各コントロールに設定
                TrackCircuit_TextBox_TrackCircuit.Text = trackCircuit;
                TrackCircuit_TextBox_TrainNumber.Text = trainNumber;
                TrackCircuit_TextBox_DeleteTrainNumber.Text = trainNumber;
                TrackCircuit_RadioButton_ShortCircuit_ON.Checked = shortCircuitStatus == "〇";
                TrackCircuit_RadioButton_ShortCircuit_OFF.Checked = shortCircuitStatus != "〇";
                TrackCircuit_RadioButton_Locking_ON.Checked = lockingStatus == "〇";
                TrackCircuit_RadioButton_Locking_OFF.Checked = lockingStatus != "〇";
            }
        }
    }
}
