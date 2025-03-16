using System;
using System.Diagnostics;
using System.Windows.Forms;
using TatehamaCommandConsole.Manager;

namespace TatehamaCommandConsole
{
    public partial class TrackCircuitForm : Form
    {
        private readonly Timer _trackCircuitTimer;
        private readonly DataManager _dataManager;

        public TrackCircuitForm()
        {
            InitializeComponent();

            // インスタンス取得
            _dataManager = DataManager.Instance;

            // DataGridViewの設定
            SetupDataGridView();

            // タイマーの設定
            _trackCircuitTimer = new Timer();
            _trackCircuitTimer.Interval = 100;
            _trackCircuitTimer.Tick += TrackCircuitTimer_Tick;
            _trackCircuitTimer.Start();
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
        /// タイマーイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <exception cref="NotImplementedException"></exception>
        private void TrackCircuitTimer_Tick(object sender, EventArgs e)
        {
            try
            {
                // DataGridViewの更新
                if (_dataManager.DataGridViewSettingList != null)
                {
                    TrackCircuit_DataGridView_TrackCircuitData.DataSource = _dataManager.DataGridViewSettingList;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// DataGridViewの設定
        /// </summary>
        private void SetupDataGridView()
        {
            // ヘッダーの追加
            TrackCircuit_DataGridView_TrackCircuitData.Columns.Add("trackCircuit", "軌道回路");
            TrackCircuit_DataGridView_TrackCircuitData.Columns.Add("trainNumber", "列車番号");
            TrackCircuit_DataGridView_TrackCircuitData.Columns.Add("shortCircuitStatus", "短絡状態");
            TrackCircuit_DataGridView_TrackCircuitData.Columns.Add("lockingStatus", "鎖錠状態");

            // 複数選択不可
            TrackCircuit_DataGridView_TrackCircuitData.MultiSelect = false;

            // 編集不可
            TrackCircuit_DataGridView_TrackCircuitData.Columns["trackCircuit"].ReadOnly = true;
            TrackCircuit_DataGridView_TrackCircuitData.Columns["trainNumber"].ReadOnly = true;
            TrackCircuit_DataGridView_TrackCircuitData.Columns["shortCircuitStatus"].ReadOnly = true;
            TrackCircuit_DataGridView_TrackCircuitData.Columns["lockingStatus"].ReadOnly = true;

            // 幅の設定
            TrackCircuit_DataGridView_TrackCircuitData.Columns["trackCircuit"].Width = 200;
            TrackCircuit_DataGridView_TrackCircuitData.Columns["trainNumber"].Width = 100;
            TrackCircuit_DataGridView_TrackCircuitData.Columns["shortCircuitStatus"].Width = 100;
            TrackCircuit_DataGridView_TrackCircuitData.Columns["lockingStatus"].Width = 100;

            // 中央揃え
            TrackCircuit_DataGridView_TrackCircuitData.Columns["trainNumber"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            TrackCircuit_DataGridView_TrackCircuitData.Columns["shortCircuitStatus"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            TrackCircuit_DataGridView_TrackCircuitData.Columns["lockingStatus"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            TrackCircuit_DataGridView_TrackCircuitData.Rows.Add("TH76_26イT", "回1234A", "〇", "");
            TrackCircuit_DataGridView_TrackCircuitData.Rows.Add("TH76_26ロT", "回1234A", "", "〇");
            TrackCircuit_DataGridView_TrackCircuitData.Rows.Add("TH76_27T", "回1234A", "〇", "");
            TrackCircuit_DataGridView_TrackCircuitData.Rows.Add("TH76_26イT", "回1234A", "〇", "");
            TrackCircuit_DataGridView_TrackCircuitData.Rows.Add("TH76_26ロT", "回1234A", "〇", "〇");
            TrackCircuit_DataGridView_TrackCircuitData.Rows.Add("TH76_27T", "回1234A", "〇", "");
            TrackCircuit_DataGridView_TrackCircuitData.Rows.Add("TH76_26イT", "回1234A", "〇", "");
            TrackCircuit_DataGridView_TrackCircuitData.Rows.Add("TH76_26ロT", "回1234A", "", "〇");
            TrackCircuit_DataGridView_TrackCircuitData.Rows.Add("TH76_27T", "回1234A", "〇", "");
            TrackCircuit_DataGridView_TrackCircuitData.Rows.Add("TH76_26イT", "回1234A", "〇", "");
            TrackCircuit_DataGridView_TrackCircuitData.Rows.Add("TH76_26ロT", "回1234A", "〇", "〇");
            TrackCircuit_DataGridView_TrackCircuitData.Rows.Add("TH76_27T", "回1234A", "〇", "");
            TrackCircuit_DataGridView_TrackCircuitData.Rows.Add("TH76_26イT", "回1234A", "〇", "");
            TrackCircuit_DataGridView_TrackCircuitData.Rows.Add("TH76_26ロT", "回1234A", "〇", "〇");
            TrackCircuit_DataGridView_TrackCircuitData.Rows.Add("TH76_27T", "回1234A", "〇", "");
            TrackCircuit_DataGridView_TrackCircuitData.Rows.Add("TH76_26イT", "回1234A", "〇", "");
            TrackCircuit_DataGridView_TrackCircuitData.Rows.Add("TH76_26ロT", "回1234A", "〇", "〇");
            TrackCircuit_DataGridView_TrackCircuitData.Rows.Add("TH76_27T", "回1234A", "〇", "");
            TrackCircuit_DataGridView_TrackCircuitData.Rows.Add("TH76_26イT", "回1234A", "〇", "");
            TrackCircuit_DataGridView_TrackCircuitData.Rows.Add("TH76_26ロT", "回1234A", "〇", "〇");
            TrackCircuit_DataGridView_TrackCircuitData.Rows.Add("TH76_27T", "回1234A", "〇", "");
            TrackCircuit_DataGridView_TrackCircuitData.Rows.Add("TH76_26イT", "回1234A", "〇", "");
            TrackCircuit_DataGridView_TrackCircuitData.Rows.Add("TH76_26ロT", "回1234A", "〇", "〇");
            TrackCircuit_DataGridView_TrackCircuitData.Rows.Add("TH76_27T", "回1234A", "〇", "");
            TrackCircuit_DataGridView_TrackCircuitData.Rows.Add("TH76_26イT", "回1234A", "〇", "");
            TrackCircuit_DataGridView_TrackCircuitData.Rows.Add("TH76_26ロT", "回1234A", "〇", "〇");
            TrackCircuit_DataGridView_TrackCircuitData.Rows.Add("TH76_27T", "回1234A", "〇", "");
            TrackCircuit_DataGridView_TrackCircuitData.Rows.Add("TH76_26イT", "回1234A", "〇", "");
            TrackCircuit_DataGridView_TrackCircuitData.Rows.Add("TH76_26ロT", "回1234A", "〇", "〇");
            TrackCircuit_DataGridView_TrackCircuitData.Rows.Add("TH76_27T", "回1234A", "〇", "");
            TrackCircuit_DataGridView_TrackCircuitData.Rows.Add("TH76_26イT", "回1234A", "〇", "");
            TrackCircuit_DataGridView_TrackCircuitData.Rows.Add("TH76_26ロT", "回1234A", "〇", "〇");
            TrackCircuit_DataGridView_TrackCircuitData.Rows.Add("TH76_27T", "回1234A", "〇", "");
            TrackCircuit_DataGridView_TrackCircuitData.Rows.Add("TH76_26イT", "回1234A", "〇", "");
            TrackCircuit_DataGridView_TrackCircuitData.Rows.Add("TH76_26ロT", "回1234A", "〇", "〇");
            TrackCircuit_DataGridView_TrackCircuitData.Rows.Add("TH76_27T", "回1234A", "〇", "");
        }

        /// <summary>
        /// 選択したデータを表示
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DataGridView_TrackCircuitData_SelectionChanged(object sender, EventArgs e)
        {
            if (TrackCircuit_DataGridView_TrackCircuitData.SelectedRows.Count > 0)
            {
                var selectedRow = TrackCircuit_DataGridView_TrackCircuitData.SelectedRows[0];
                string trackCircuit = selectedRow.Cells["trackCircuit"].Value.ToString();
                string trainNumber = selectedRow.Cells["trainNumber"].Value.ToString();
                string shortCircuitStatus = selectedRow.Cells["shortCircuitStatus"].Value.ToString();
                string lockingStatus = selectedRow.Cells["lockingStatus"].Value.ToString();

                // 各コントロールに設定
                TrackCircuit_Label_TrackCircuit.Text = trackCircuit;
                TrackCircuit_TextBox_TrainNumber.Text = trainNumber;
                TrackCircuit_RadioButton_ShortCircuit_ON.Checked = shortCircuitStatus == "〇";
                TrackCircuit_RadioButton_ShortCircuit_OFF.Checked = shortCircuitStatus != "〇";
                TrackCircuit_RadioButton_Locking_ON.Checked = lockingStatus == "〇";
                TrackCircuit_RadioButton_Locking_OFF.Checked = lockingStatus != "〇";
            }
        }
    }
}
