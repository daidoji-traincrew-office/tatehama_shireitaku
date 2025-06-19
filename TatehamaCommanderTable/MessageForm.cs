using System;
using System.Windows.Forms;
using TatehamaCommanderTable.Communications;
using TatehamaCommanderTable.Manager;
using TatehamaCommanderTable.Models;
using TatehamaCommanderTable.Services;

namespace TatehamaCommanderTable
{
    public partial class MessageForm : Form
    {
        private readonly DataManager _dataManager;
        private readonly ServerCommunication _serverCommunication;
        private bool _isScrolling = false;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="serverCommunication"></param>
        public MessageForm(ServerCommunication serverCommunication)
        {
            InitializeComponent();

            // インスタンス取得
            _dataManager = DataManager.Instance;
            _serverCommunication = serverCommunication;

            // イベント設定
            Load += MessageForm_Load;
            FormClosing += MessageForm_FormClosing;
        }

        /// <summary>
        /// MessageForm_Loadイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MessageForm_Load(object sender, EventArgs e)
        {
            // イベントハンドラ設定
            _serverCommunication.MessageDataGridViewUpdated += (newDataSource) => UpdateDataSource(newDataSource);
            Message_DataGridView_MessageData.CellClick += DataGridView_MessageData_CellClick;
            Message_DataGridView_MessageData.Scroll += DataGridView_Message_Scroll;

            // DataGridViewのデータバインド
            Message_BindingSource.DataSource = _dataManager.MessageDataGridViewSettingList;

            // DataGridViewの設定
            SetupDataGridView();

            // 現在時刻に初期化
            var now = DateTime.Now;
            Message_DateTimePicker_StartDate.Value = new DateTime(now.Year, now.Month, now.Day, now.Hour, now.Minute, 0);
            Message_DateTimePicker_EndDate.Value = new DateTime(now.Year, now.Month, now.Day, now.Hour, now.Minute + 1, 0);

            // ComboBox初期値
            Message_ComboBox_Type.SelectedIndex = 0;
        }

        /// <summary>
        /// MessageForm_FormClosingイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MessageForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Hide();
            e.Cancel = true;
        }

        /// <summary>
        /// 最前面表示切替イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Message_CheckBox_TopMost_CheckedChanged(object sender, EventArgs e)
        {
            this.TopMost = Message_CheckBox_TopMost.Checked;
        }

        /// <summary>
        /// ボタンクリックイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Message_Button_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;

            switch (button.Name)
            {
                // 削除ボタン
                case "Message_Button_Cansel":
                    {
                        _serverCommunication.DeleteOperationInformationEventDataRequestToServerAsync((long)Message_NumericUpDown_ID.Value);
                    }
                    break;
                // 追加ボタン
                case "Message_Button_Add":
                    {
                        var startTime = Message_DateTimePicker_StartDate.Value;
                        var endTime = Message_DateTimePicker_EndDate.Value;

                        // 時刻チェック
                        if (endTime <= startTime)
                        {
                            CustomMessage.Show("配信終了日時は配信開始日時より後の時刻を指定してください。", "入力エラー");
                            return;
                        }

                        var result = new OperationInformationData
                        {
                            Type = (OperationInformationType)Message_ComboBox_Type.SelectedIndex,
                            Content = Message_TextBox_MessageText.Text,
                            StartTime = startTime,
                            EndTime = endTime
                        };
                        _serverCommunication.AddOperationInformationEventDataRequestToServerAsync(result);
                    }
                    break;
                // 更新ボタン
                case "Message_Button_Update":
                    {
                        var startTime = Message_DateTimePicker_StartDate.Value;
                        var endTime = Message_DateTimePicker_EndDate.Value;

                        // 時刻チェック
                        if (endTime <= startTime)
                        {
                            CustomMessage.Show("配信終了日時は配信開始日時より後の時刻を指定してください。", "入力エラー");
                            return;
                        }

                        var result = new OperationInformationData
                        {
                            Id = (long)Message_NumericUpDown_ID.Value,
                            Type = (OperationInformationType)Message_ComboBox_Type.SelectedIndex,
                            Content = Message_TextBox_MessageText.Text,
                            StartTime = startTime,
                            EndTime = endTime
                        };
                        _serverCommunication.UpdateOperationInformationEventDataRequestToServerAsync(result);
                    }
                    break;
            }
        }

        /// <summary>
        /// DataGridViewの選択したデータを表示
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DataGridView_MessageData_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var selectedRow = Message_DataGridView_MessageData.Rows[e.RowIndex];
                string id = selectedRow.Cells["Id"].Value.ToString();
                string type = selectedRow.Cells["Type"].Value.ToString();
                string content = selectedRow.Cells["Content"].Value.ToString();
                string startTime = selectedRow.Cells["StartTime"].Value.ToString();
                string endTime = selectedRow.Cells["EndTime"].Value.ToString();

                // 各コントロールに設定
                Message_NumericUpDown_ID.Value = long.TryParse(id, out long parsedId) ? parsedId : 0;
                Message_ComboBox_Type.SelectedItem = type;
                Message_TextBox_MessageText.Text = content;
                Message_DateTimePicker_StartDate.Value = DateTime.Parse(startTime);
                Message_DateTimePicker_EndDate.Value = DateTime.Parse(endTime);
            }
        }

        /// <summary>
        /// DataGridViewスクロールイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DataGridView_Message_Scroll(object sender, ScrollEventArgs e)
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
        public void UpdateDataSource(SortableBindingList<MessageDataGridViewSetting> newDataSource)
        {
            try
            {
                if (!this.IsDisposed)
                {
                    if (this.IsHandleCreated && !this.IsDisposed)
                    {
                        SuspendLayout();

                        // スクロール位置を保持
                        int firstDisplayedScrollingRowIndex = Message_DataGridView_MessageData.FirstDisplayedScrollingRowIndex;
                        int selectedRowIndex = Message_DataGridView_MessageData.CurrentCell?.RowIndex ?? 0;
                        int selectedColumnIndex = !_isScrolling ? (Message_DataGridView_MessageData.CurrentCell?.ColumnIndex ?? 0) : 0;
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
                                    Message_BindingSource.DataSource = newDataSource;
                                    if (Message_DataGridView_MessageData.Rows.Count > 0)
                                    {
                                        Message_DataGridView_MessageData.FirstDisplayedScrollingRowIndex = Math.Min(firstDisplayedScrollingRowIndex, Message_DataGridView_MessageData.Rows.Count - 1);
                                        Message_DataGridView_MessageData.CurrentCell = Message_DataGridView_MessageData.Rows[Math.Min(selectedRowIndex, Message_DataGridView_MessageData.Rows.Count - 1)].Cells[Math.Min(selectedColumnIndex, Message_DataGridView_MessageData.Columns.Count - 1)];
                                    }
                                }
                            }));
                        }
                        else
                        {
                            if (!this.IsDisposed)
                            {
                                Message_BindingSource.DataSource = newDataSource;
                                if (Message_DataGridView_MessageData.Rows.Count > 0)
                                {
                                    Message_DataGridView_MessageData.FirstDisplayedScrollingRowIndex = Math.Min(firstDisplayedScrollingRowIndex, Message_DataGridView_MessageData.Rows.Count - 1);
                                    Message_DataGridView_MessageData.CurrentCell = Message_DataGridView_MessageData.Rows[Math.Min(selectedRowIndex, Message_DataGridView_MessageData.Rows.Count - 1)].Cells[Math.Min(selectedColumnIndex, Message_DataGridView_MessageData.Columns.Count - 1)];
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
            Message_DataGridView_MessageData.MultiSelect = false;
            Message_DataGridView_MessageData.AutoGenerateColumns = false;
        }
    }
}
