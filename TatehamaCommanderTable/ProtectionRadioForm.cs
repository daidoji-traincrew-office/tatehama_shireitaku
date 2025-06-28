using System;
using System.Windows.Forms;
using TatehamaCommanderTable.Communications;
using TatehamaCommanderTable.Manager;
using TatehamaCommanderTable.Models;
using TatehamaCommanderTable.Services;

namespace TatehamaCommanderTable
{
    public partial class ProtectionRadioForm : Form
    {
        private readonly DataManager _dataManager;
        private readonly ServerCommunication _serverCommunication;
        private bool _isScrolling = false;

        public ProtectionRadioForm(ServerCommunication serverCommunication)
        {
            InitializeComponent();

            // インスタンス取得
            _dataManager = DataManager.Instance;
            _serverCommunication = serverCommunication;

            // イベント設定
            Load += ProtectionRadioForm_Load;
            FormClosing += ProtectionRadioForm_FormClosing;
        }

        /// <summary>
        /// ProtectionRadioForm_Loadイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ProtectionRadioForm_Load(object sender, EventArgs e)
        {
            // イベントハンドラ設定
            _serverCommunication.ProtectionRadioDataGridViewUpdated += (newDataSource) => UpdateDataSource(newDataSource);
            ProtectionRadio_DataGridView_ProtectionRadioData.CellClick += DataGridView_ProtectionRadioData_CellClick;
            ProtectionRadio_DataGridView_ProtectionRadioData.Scroll += DataGridView_ProtectionRadio_Scroll;

            // DataGridViewのデータバインド
            ProtectionRadio_BindingSource.DataSource = _dataManager.ProtectionRadioDataGridViewSettingList;

            // DataGridViewの設定
            SetupDataGridView();

            // NumericUpDownの初期値設定
            ProtectionRadio_NumericUpDown_ID.Value = 0;
            ProtectionRadio_NumericUpDown_ProtectionZone.Value = 0;

            // TextBoxの初期値設定
            ProtectionRadio_TextBox_TrainNumber.Text = string.Empty;
        }

        /// <summary>
        /// ProtectionRadioForm_FormClosingイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ProtectionRadioForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Hide();
            e.Cancel = true;
        }

        /// <summary>
        /// 最前面表示切替イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ProtectionRadio_CheckBox_TopMost_CheckedChanged(object sender, EventArgs e)
        {
            this.TopMost = ProtectionRadio_CheckBox_TopMost.Checked;
        }

        /// <summary>
        /// ボタンクリックイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void ProtectionRadio_Button_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;

            switch (button.Name)
            {
                // 削除ボタン
                case "ProtectionRadio_Button_Delete":
                    {
                        _serverCommunication.DeleteProtectionRadioEventDataRequestToServerAsync((long)ProtectionRadio_NumericUpDown_ID.Value);

                        //CustomMessage.Show($"ID: {(long)ProtectionRadio_NumericUpDown_ID.Value}", "設定完了");
                    }
                    break;
                // 追加ボタン
                case "ProtectionRadio_Button_Add":
                    {
                        var sendData = new ProtectionRadioData
                        {
                            Id = (ulong)ProtectionRadio_NumericUpDown_ID.Value,
                            ProtectionZone = (int)ProtectionRadio_NumericUpDown_ProtectionZone.Value,
                            TrainNumber = ProtectionRadio_TextBox_TrainNumber.Text
                        };
                        var result = await _serverCommunication.AddProtectionRadioEventDataRequestToServerAsync(sendData);

                        //CustomMessage.Show($"ID: {(ulong)ProtectionRadio_NumericUpDown_ID.Value}\nProtectionZone: {(int)ProtectionRadio_NumericUpDown_ProtectionZone.Value}\nTrainNumber: {ProtectionRadio_TextBox_TrainNumber.Text}", "設定完了");
                    }
                    break;
                // 更新ボタン
                case "ProtectionRadio_Button_Update":
                    {
                        var sendData = new ProtectionRadioData
                        {
                            Id = (ulong)ProtectionRadio_NumericUpDown_ID.Value,
                            ProtectionZone = (int)ProtectionRadio_NumericUpDown_ProtectionZone.Value,
                            TrainNumber = ProtectionRadio_TextBox_TrainNumber.Text
                        };
                        var result = await _serverCommunication.UpdateProtectionRadioEventDataRequestToServerAsync(sendData);

                        //CustomMessage.Show($"ID: {(ulong)ProtectionRadio_NumericUpDown_ID.Value}\nProtectionZone: {(int)ProtectionRadio_NumericUpDown_ProtectionZone.Value}\nTrainNumber: {ProtectionRadio_TextBox_TrainNumber.Text}", "設定完了");
                    }
                    break;
            }
        }

        /// <summary>
        /// DataGridViewの選択したデータを表示
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DataGridView_ProtectionRadioData_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var selectedRow = ProtectionRadio_DataGridView_ProtectionRadioData.Rows[e.RowIndex];
                string id = selectedRow.Cells["ID"].Value.ToString();
                string protectionZone = selectedRow.Cells["ProtectionZone"].Value.ToString();
                string trainNumber = selectedRow.Cells["TrainNumber"].Value.ToString();

                // 各コントロールに設定
                ProtectionRadio_NumericUpDown_ID.Value = long.TryParse(id, out long parsedId) ? parsedId : 0;
                ProtectionRadio_NumericUpDown_ProtectionZone.Value = long.TryParse(protectionZone, out long parsedZone) ? parsedZone : 0;
                ProtectionRadio_TextBox_TrainNumber.Text = trainNumber;
            }
        }

        /// <summary>
        /// DataGridViewスクロールイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DataGridView_ProtectionRadio_Scroll(object sender, ScrollEventArgs e)
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
        public void UpdateDataSource(SortableBindingList<ProtectionRadioDataGridViewSetting> newDataSource)
        {
            try
            {
                if (!this.IsDisposed)
                {
                    if (this.IsHandleCreated && !this.IsDisposed)
                    {
                        SuspendLayout();

                        // スクロール位置を保持
                        int firstDisplayedScrollingRowIndex = ProtectionRadio_DataGridView_ProtectionRadioData.FirstDisplayedScrollingRowIndex;
                        int selectedRowIndex = ProtectionRadio_DataGridView_ProtectionRadioData.CurrentCell?.RowIndex ?? 0;
                        int selectedColumnIndex = !_isScrolling ? (ProtectionRadio_DataGridView_ProtectionRadioData.CurrentCell?.ColumnIndex ?? 0) : 0;
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
                                    ProtectionRadio_BindingSource.DataSource = newDataSource;
                                    if (ProtectionRadio_DataGridView_ProtectionRadioData.Rows.Count > 0)
                                    {
                                        ProtectionRadio_DataGridView_ProtectionRadioData.FirstDisplayedScrollingRowIndex = Math.Min(firstDisplayedScrollingRowIndex, ProtectionRadio_DataGridView_ProtectionRadioData.Rows.Count - 1);
                                        ProtectionRadio_DataGridView_ProtectionRadioData.CurrentCell = ProtectionRadio_DataGridView_ProtectionRadioData.Rows[Math.Min(selectedRowIndex, ProtectionRadio_DataGridView_ProtectionRadioData.Rows.Count - 1)].Cells[Math.Min(selectedColumnIndex, ProtectionRadio_DataGridView_ProtectionRadioData.Columns.Count - 1)];
                                    }
                                }
                            }));
                        }
                        else
                        {
                            if (!this.IsDisposed)
                            {
                                ProtectionRadio_BindingSource.DataSource = newDataSource;
                                if (ProtectionRadio_DataGridView_ProtectionRadioData.Rows.Count > 0)
                                {
                                    ProtectionRadio_DataGridView_ProtectionRadioData.FirstDisplayedScrollingRowIndex = Math.Min(firstDisplayedScrollingRowIndex, ProtectionRadio_DataGridView_ProtectionRadioData.Rows.Count - 1);
                                    ProtectionRadio_DataGridView_ProtectionRadioData.CurrentCell = ProtectionRadio_DataGridView_ProtectionRadioData.Rows[Math.Min(selectedRowIndex, ProtectionRadio_DataGridView_ProtectionRadioData.Rows.Count - 1)].Cells[Math.Min(selectedColumnIndex, ProtectionRadio_DataGridView_ProtectionRadioData.Columns.Count - 1)];
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
            ProtectionRadio_DataGridView_ProtectionRadioData.MultiSelect = false;
            ProtectionRadio_DataGridView_ProtectionRadioData.AutoGenerateColumns = false;

            // 中央揃え
            ProtectionRadio_DataGridView_ProtectionRadioData.Columns["ID"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ProtectionRadio_DataGridView_ProtectionRadioData.Columns["ProtectionZone"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ProtectionRadio_DataGridView_ProtectionRadioData.Columns["TrainNumber"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }
    }
}
