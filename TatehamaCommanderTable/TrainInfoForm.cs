using System;
using System.Windows.Forms;
using TatehamaCommanderTable.Communications;
using TatehamaCommanderTable.Manager;
using TatehamaCommanderTable.Models;
using TatehamaCommanderTable.Services;

namespace TatehamaCommanderTable
{
    public partial class TrainInfoForm : Form
    {
        private readonly DataManager _dataManager;
        private readonly ServerCommunication _serverCommunication;
        private bool _isScrolling = false;

        public TrainInfoForm(ServerCommunication serverCommunication)
        {
            InitializeComponent();

            // インスタンス取得
            _dataManager = DataManager.Instance;
            _serverCommunication = serverCommunication;

            // イベント設定
            Load += TrainInfoForm_Load;
            FormClosing += TrainInfoForm_FormClosing;
        }

        /// <summary>
        /// TrainInfoForm_Loadイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TrainInfoForm_Load(object sender, EventArgs e)
        {
            // イベントハンドラ設定
            _serverCommunication.TrainInfoDataGridViewUpdated += (newDataSource) => UpdateDataSource(newDataSource);
            TrainInfo_DataGridView_TrainInfoData.CellClick += DataGridView_TrainInfoData_CellClick;
            TrainInfo_DataGridView_TrainInfoData.Scroll += DataGridView_TrainInfo_Scroll;

            // DataGridViewのデータバインド
            TrainInfo_BindingSource.DataSource = _dataManager.TrainInfoDataGridViewSettingList;

            // DataGridViewの設定
            SetupDataGridView();

            // NumericUpDownの初期値設定
            TrainInfo_NumericUpDown_ID.Value = 0;
            TrainInfo_NumericUpDown_DiaNumber.Value = 0;
            TrainInfo_NumericUpDown_Delay.Value = 0;

            // TextBoxの初期値設定
            TrainInfo_TextBox_TrainNumber.Text = string.Empty;
            TrainInfo_TextBox_FromStationID.Text = string.Empty;
            TrainInfo_TextBox_ToStationID.Text = string.Empty;
            TrainInfo_TextBox_DriverID.Text = string.Empty;
        }

        /// <summary>
        /// TrainInfoForm_FormClosingイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TrainInfoForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Hide();
            e.Cancel = true;
        }

        /// <summary>
        /// 最前面表示切替イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TrainInfo_CheckBox_TopMost_CheckedChanged(object sender, EventArgs e)
        {
            this.TopMost = TrainInfo_CheckBox_TopMost.Checked;
        }

        /// <summary>
        /// ボタンクリックイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void TrainInfo_Button_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;

            switch (button.Name)
            {
                // 削除ボタン
                case "TrainInfo_Button_Delete":
                    {

                    }
                    break;
                // 追加ボタン
                case "TrainInfo_Button_Add":
                    {

                    }
                    break;
                // 更新ボタン
                case "TrainInfo_Button_Update":
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
        private void DataGridView_TrainInfoData_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var selectedRow = TrainInfo_DataGridView_TrainInfoData.Rows[e.RowIndex];
                string id = selectedRow.Cells["ID"].Value.ToString();
                string trainNumber = selectedRow.Cells["TrainNumber"].Value.ToString();
                string diaNumber = selectedRow.Cells["DiaNumber"].Value.ToString();
                string fromStationID = selectedRow.Cells["FromStationID"].Value.ToString();
                string toStationID = selectedRow.Cells["ToStationID"].Value.ToString();
                string delay = selectedRow.Cells["Delay"].Value.ToString();
                string driverID = selectedRow.Cells["DriverID"].Value.ToString();

                // 各コントロールに設定
                TrainInfo_NumericUpDown_ID.Value = string.IsNullOrEmpty(id) ? 0 : Convert.ToDecimal(id);
                TrainInfo_TextBox_TrainNumber.Text = trainNumber;
                TrainInfo_NumericUpDown_DiaNumber.Value = string.IsNullOrEmpty(diaNumber) ? 0 : Convert.ToDecimal(diaNumber);
                TrainInfo_TextBox_FromStationID.Text = fromStationID;
                TrainInfo_TextBox_ToStationID.Text = toStationID;
                TrainInfo_NumericUpDown_Delay.Value = string.IsNullOrEmpty(delay) ? 0 : Convert.ToDecimal(delay);
                TrainInfo_TextBox_DriverID.Text = driverID;
            }
        }

        /// <summary>
        /// DataGridViewスクロールイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DataGridView_TrainInfo_Scroll(object sender, ScrollEventArgs e)
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
        public void UpdateDataSource(SortableBindingList<TrainInfoDataGridViewSetting> newDataSource)
        {
            try
            {
                if (!this.IsDisposed)
                {
                    if (this.IsHandleCreated && !this.IsDisposed)
                    {
                        SuspendLayout();

                        // スクロール位置を保持
                        int firstDisplayedScrollingRowIndex = TrainInfo_DataGridView_TrainInfoData.FirstDisplayedScrollingRowIndex;
                        int selectedRowIndex = TrainInfo_DataGridView_TrainInfoData.CurrentCell?.RowIndex ?? 0;
                        int selectedColumnIndex = !_isScrolling ? (TrainInfo_DataGridView_TrainInfoData.CurrentCell?.ColumnIndex ?? 0) : 0;
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
                                    TrainInfo_BindingSource.DataSource = newDataSource;
                                    if (TrainInfo_DataGridView_TrainInfoData.Rows.Count > 0)
                                    {
                                        TrainInfo_DataGridView_TrainInfoData.FirstDisplayedScrollingRowIndex = Math.Min(firstDisplayedScrollingRowIndex, TrainInfo_DataGridView_TrainInfoData.Rows.Count - 1);
                                        TrainInfo_DataGridView_TrainInfoData.CurrentCell = TrainInfo_DataGridView_TrainInfoData.Rows[Math.Min(selectedRowIndex, TrainInfo_DataGridView_TrainInfoData.Rows.Count - 1)].Cells[Math.Min(selectedColumnIndex, TrainInfo_DataGridView_TrainInfoData.Columns.Count - 1)];
                                    }
                                }
                            }));
                        }
                        else
                        {
                            if (!this.IsDisposed)
                            {
                                TrainInfo_BindingSource.DataSource = newDataSource;
                                if (TrainInfo_DataGridView_TrainInfoData.Rows.Count > 0)
                                {
                                    TrainInfo_DataGridView_TrainInfoData.FirstDisplayedScrollingRowIndex = Math.Min(firstDisplayedScrollingRowIndex, TrainInfo_DataGridView_TrainInfoData.Rows.Count - 1);
                                    TrainInfo_DataGridView_TrainInfoData.CurrentCell = TrainInfo_DataGridView_TrainInfoData.Rows[Math.Min(selectedRowIndex, TrainInfo_DataGridView_TrainInfoData.Rows.Count - 1)].Cells[Math.Min(selectedColumnIndex, TrainInfo_DataGridView_TrainInfoData.Columns.Count - 1)];
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
            TrainInfo_DataGridView_TrainInfoData.MultiSelect = false;
            TrainInfo_DataGridView_TrainInfoData.AutoGenerateColumns = false;

            // 中央揃え
            TrainInfo_DataGridView_TrainInfoData.Columns["ID"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            TrainInfo_DataGridView_TrainInfoData.Columns["TrainNumber"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            TrainInfo_DataGridView_TrainInfoData.Columns["DiaNumber"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            TrainInfo_DataGridView_TrainInfoData.Columns["FromStationID"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            TrainInfo_DataGridView_TrainInfoData.Columns["ToStationID"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            TrainInfo_DataGridView_TrainInfoData.Columns["Delay"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            TrainInfo_DataGridView_TrainInfoData.Columns["DriverID"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
        }
    }
}
