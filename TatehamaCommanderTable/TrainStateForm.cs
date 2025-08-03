using System;
using System.Windows.Forms;
using TatehamaCommanderTable.Communications;
using TatehamaCommanderTable.Manager;
using TatehamaCommanderTable.Models;
using TatehamaCommanderTable.Services;

namespace TatehamaCommanderTable
{
    public partial class TrainStateForm : Form
    {
        private readonly DataManager _dataManager;
        private readonly ServerCommunication _serverCommunication;
        private bool _isScrolling = false;

        public TrainStateForm(ServerCommunication serverCommunication)
        {
            InitializeComponent();

            // インスタンス取得
            _dataManager = DataManager.Instance;
            _serverCommunication = serverCommunication;

            // イベント設定
            Load += TrainStateForm_Load;
            FormClosing += TrainStateForm_FormClosing;
        }

        /// <summary>
        /// TrainStateForm_Loadイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TrainStateForm_Load(object sender, EventArgs e)
        {
            // イベントハンドラ設定
            _serverCommunication.TrainStateDataGridViewUpdated += (newDataSource) => UpdateDataSource(newDataSource);
            TrainState_DataGridView_TrainStateData.CellClick += DataGridView_TrainStateData_CellClick;
            TrainState_DataGridView_TrainStateData.Scroll += DataGridView_TrainState_Scroll;

            // DataGridViewのデータバインド
            TrainState_BindingSource.DataSource = _dataManager.TrainStateDataGridViewSettingList;

            // DataGridViewの設定
            SetupDataGridView();

            // NumericUpDownの初期値設定
            TrainState_NumericUpDown_ID.Value = 0;
            TrainState_NumericUpDown_DiaNumber.Value = 0;
            TrainState_NumericUpDown_Delay.Value = 0;

            // TextBoxの初期値設定
            TrainState_TextBox_TrainNumber.Text = string.Empty;
            TrainState_TextBox_FromStationID.Text = string.Empty;
            TrainState_TextBox_ToStationID.Text = string.Empty;
            TrainState_TextBox_DriverID.Text = string.Empty;
        }

        /// <summary>
        /// TrainStateForm_FormClosingイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TrainStateForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Hide();
            e.Cancel = true;
        }

        /// <summary>
        /// 最前面表示切替イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TrainState_CheckBox_TopMost_CheckedChanged(object sender, EventArgs e)
        {
            this.TopMost = TrainState_CheckBox_TopMost.Checked;
        }

        /// <summary>
        /// ボタンクリックイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void TrainState_Button_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;

            switch (button.Name)
            {
                // 削除ボタン
                case "TrainState_Button_Delete":
                    {

                    }
                    break;
                // 更新ボタン
                case "TrainState_Button_Update":
                    {

                    }
                    break;
            }
        }

        /// <summary>
        /// DataGridViewの選択したデータを表示
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DataGridView_TrainStateData_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var selectedRow = TrainState_DataGridView_TrainStateData.Rows[e.RowIndex];
                string id = selectedRow.Cells["ID"].Value.ToString();
                string trainNumber = selectedRow.Cells["TrainNumber"].Value.ToString();
                string diaNumber = selectedRow.Cells["DiaNumber"].Value.ToString();
                string fromStationID = selectedRow.Cells["FromStationID"].Value.ToString();
                string toStationID = selectedRow.Cells["ToStationID"].Value.ToString();
                string delay = selectedRow.Cells["Delay"].Value.ToString();
                string driverID = selectedRow.Cells["DriverID"].Value.ToString();

                // 各コントロールに設定
                TrainState_NumericUpDown_ID.Value = string.IsNullOrEmpty(id) ? 0 : Convert.ToDecimal(id);
                TrainState_TextBox_TrainNumber.Text = trainNumber;
                TrainState_NumericUpDown_DiaNumber.Value = string.IsNullOrEmpty(diaNumber) ? 0 : Convert.ToDecimal(diaNumber);
                TrainState_TextBox_FromStationID.Text = fromStationID;
                TrainState_TextBox_ToStationID.Text = toStationID;
                TrainState_NumericUpDown_Delay.Value = string.IsNullOrEmpty(delay) ? 0 : Convert.ToDecimal(delay);
                TrainState_TextBox_DriverID.Text = driverID;
            }
        }

        /// <summary>
        /// DataGridViewスクロールイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DataGridView_TrainState_Scroll(object sender, ScrollEventArgs e)
        {
            if (e.ScrollOrientation == ScrollOrientation.VerticalScroll)
            {
                _isScrolling = true;
            }
        }

        /// <summary>
        /// DataGridView更新処理
        /// </summary>
        /// <param name="newDataSource"></param>
        public void UpdateDataSource(SortableBindingList<TrainStateDataGridViewSetting> newDataSource)
        {
            try
            {
                if (!this.IsDisposed)
                {
                    if (this.IsHandleCreated && !this.IsDisposed)
                    {
                        SuspendLayout();

                        // スクロール位置を保持
                        int firstDisplayedScrollingRowIndex = TrainState_DataGridView_TrainStateData.FirstDisplayedScrollingRowIndex;
                        int selectedRowIndex = TrainState_DataGridView_TrainStateData.CurrentCell?.RowIndex ?? 0;
                        int selectedColumnIndex = !_isScrolling ? (TrainState_DataGridView_TrainStateData.CurrentCell?.ColumnIndex ?? 0) : 0;
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
                                    TrainState_BindingSource.DataSource = newDataSource;
                                    if (TrainState_DataGridView_TrainStateData.Rows.Count > 0)
                                    {
                                        TrainState_DataGridView_TrainStateData.FirstDisplayedScrollingRowIndex = Math.Min(firstDisplayedScrollingRowIndex, TrainState_DataGridView_TrainStateData.Rows.Count - 1);
                                        TrainState_DataGridView_TrainStateData.CurrentCell = TrainState_DataGridView_TrainStateData.Rows[Math.Min(selectedRowIndex, TrainState_DataGridView_TrainStateData.Rows.Count - 1)].Cells[Math.Min(selectedColumnIndex, TrainState_DataGridView_TrainStateData.Columns.Count - 1)];
                                    }
                                }
                            }));
                        }
                        else
                        {
                            if (!this.IsDisposed)
                            {
                                TrainState_BindingSource.DataSource = newDataSource;
                                if (TrainState_DataGridView_TrainStateData.Rows.Count > 0)
                                {
                                    TrainState_DataGridView_TrainStateData.FirstDisplayedScrollingRowIndex = Math.Min(firstDisplayedScrollingRowIndex, TrainState_DataGridView_TrainStateData.Rows.Count - 1);
                                    TrainState_DataGridView_TrainStateData.CurrentCell = TrainState_DataGridView_TrainStateData.Rows[Math.Min(selectedRowIndex, TrainState_DataGridView_TrainStateData.Rows.Count - 1)].Cells[Math.Min(selectedColumnIndex, TrainState_DataGridView_TrainStateData.Columns.Count - 1)];
                                }
                            }
                        }
                        ResumeLayout();
                    }
                    _isScrolling = false;
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
            TrainState_DataGridView_TrainStateData.MultiSelect = false;
            TrainState_DataGridView_TrainStateData.AutoGenerateColumns = false;

            // 中央揃え
            TrainState_DataGridView_TrainStateData.Columns["ID"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            TrainState_DataGridView_TrainStateData.Columns["TrainNumber"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            TrainState_DataGridView_TrainStateData.Columns["DiaNumber"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            TrainState_DataGridView_TrainStateData.Columns["FromStationID"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            TrainState_DataGridView_TrainStateData.Columns["ToStationID"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            TrainState_DataGridView_TrainStateData.Columns["Delay"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            TrainState_DataGridView_TrainStateData.Columns["DriverID"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
        }
    }
}
