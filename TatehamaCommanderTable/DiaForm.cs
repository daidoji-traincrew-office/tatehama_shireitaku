using System;
using System.Windows.Forms;
using TatehamaCommanderTable.Communications;
using TatehamaCommanderTable.Manager;
using TatehamaCommanderTable.Models;
using TatehamaCommanderTable.Services;

namespace TatehamaCommanderTable
{
    public partial class DiaForm : Form
    {
        private readonly DataManager _dataManager;
        private readonly ServerCommunication _serverCommunication;
        private bool _isScrolling = false;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="serverCommunication"></param>
        public DiaForm(ServerCommunication serverCommunication)
        {
            InitializeComponent();

            // インスタンス取得
            _dataManager = DataManager.Instance;
            _serverCommunication = serverCommunication;

            // イベント設定
            Load += DiaForm_Load;
            FormClosing += DiaForm_FormClosing;
        }

        /// <summary>
        /// DiaForm_Loadイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DiaForm_Load(object sender, EventArgs e)
        {
            // イベントハンドラ設定
            _serverCommunication.DiaDataGridViewUpdated += (newDataSource) => UpdateDataSource(newDataSource);
            Dia_DataGridView_DiaData.CellClick += DataGridView_DiaData_CellClick;
            Dia_DataGridView_DiaData.Scroll += DataGridView_Dia_Scroll;

            // DataGridViewのデータバインド
            Dia_BindingSource.DataSource = _dataManager.DiaDataGridViewSettingList;

            // DataGridViewの設定
            SetupDataGridView();
        }

        /// <summary>
        /// DiaForm_FormClosingイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DiaForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Hide();
            e.Cancel = true;
        }

        /// <summary>
        /// 最前面表示切替イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Dia_CheckBox_TopMost_CheckedChanged(object sender, EventArgs e)
        {
            this.TopMost = Dia_CheckBox_TopMost.Checked;
        }

        /// <summary>
        /// ボタンクリックイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void Dia_Button_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;

            switch (button.Name)
            {
                // 削除ボタン
                case "Message_Button_Cansel":
                    {

                    }
                    break;
                // 追加ボタン
                case "Message_Button_Add":
                    {

                    }
                    break;
                // 更新ボタン
                case "Message_Button_Update":
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
        private void DataGridView_DiaData_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var selectedRow = Dia_DataGridView_DiaData.Rows[e.RowIndex];
                string trainNumber = selectedRow.Cells["TrainNumber"].Value.ToString();
                string typeId = selectedRow.Cells["TypeId"].Value.ToString();
                string type = selectedRow.Cells["TrainType"].Value.ToString();
                string fromStationId = selectedRow.Cells["FromStationId"].Value.ToString();
                string toStationId = selectedRow.Cells["ToStationId"].Value.ToString();
                string diaId = selectedRow.Cells["DiaId"].Value.ToString();

                // 各コントロールに設定

            }
        }

        /// <summary>
        /// DataGridViewスクロールイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DataGridView_Dia_Scroll(object sender, ScrollEventArgs e)
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
        public void UpdateDataSource(SortableBindingList<DiaDataGridViewSetting> newDataSource)
        {
            try
            {
                if (!this.IsDisposed)
                {
                    if (this.IsHandleCreated && !this.IsDisposed)
                    {
                        SuspendLayout();

                        // スクロール位置を保持
                        int firstDisplayedScrollingRowIndex = Dia_DataGridView_DiaData.FirstDisplayedScrollingRowIndex;
                        int selectedRowIndex = Dia_DataGridView_DiaData.CurrentCell?.RowIndex ?? 0;
                        int selectedColumnIndex = !_isScrolling ? (Dia_DataGridView_DiaData.CurrentCell?.ColumnIndex ?? 0) : 0;
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
                                    Dia_BindingSource.DataSource = newDataSource;
                                    if (Dia_DataGridView_DiaData.Rows.Count > 0)
                                    {
                                        Dia_DataGridView_DiaData.FirstDisplayedScrollingRowIndex = Math.Min(firstDisplayedScrollingRowIndex, Dia_DataGridView_DiaData.Rows.Count - 1);
                                        Dia_DataGridView_DiaData.CurrentCell = Dia_DataGridView_DiaData.Rows[Math.Min(selectedRowIndex, Dia_DataGridView_DiaData.Rows.Count - 1)].Cells[Math.Min(selectedColumnIndex, Dia_DataGridView_DiaData.Columns.Count - 1)];
                                    }
                                }
                            }));
                        }
                        else
                        {
                            if (!this.IsDisposed)
                            {
                                Dia_BindingSource.DataSource = newDataSource;
                                if (Dia_DataGridView_DiaData.Rows.Count > 0)
                                {
                                    Dia_DataGridView_DiaData.FirstDisplayedScrollingRowIndex = Math.Min(firstDisplayedScrollingRowIndex, Dia_DataGridView_DiaData.Rows.Count - 1);
                                    Dia_DataGridView_DiaData.CurrentCell = Dia_DataGridView_DiaData.Rows[Math.Min(selectedRowIndex, Dia_DataGridView_DiaData.Rows.Count - 1)].Cells[Math.Min(selectedColumnIndex, Dia_DataGridView_DiaData.Columns.Count - 1)];
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
            Dia_DataGridView_DiaData.MultiSelect = false;
            Dia_DataGridView_DiaData.AutoGenerateColumns = false;

            // 中央揃え
            Dia_DataGridView_DiaData.Columns["TrainNumber"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            Dia_DataGridView_DiaData.Columns["TypeId"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            Dia_DataGridView_DiaData.Columns["TrainType"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            Dia_DataGridView_DiaData.Columns["FromStationId"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            Dia_DataGridView_DiaData.Columns["ToStationId"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            Dia_DataGridView_DiaData.Columns["DiaId"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }
    }
}
