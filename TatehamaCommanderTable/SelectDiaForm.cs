using System;
using System.Windows.Forms;
using TatehamaCommanderTable.Communications;
using TatehamaCommanderTable.Manager;
using TatehamaCommanderTable.Models;
using TatehamaCommanderTable.Services;

namespace TatehamaCommanderTable
{
    public partial class SelectDiaForm : Form
    {
        private readonly ServerCommunication _serverCommunication;
        private readonly DataManager _dataManager;
        private bool _isScrolling = false;

        public SelectDiaForm(ServerCommunication serverCommunication)
        {
            InitializeComponent();

            // インスタンス取得
            _serverCommunication = serverCommunication;
            _dataManager = DataManager.Instance;

            // イベント設定
            Load += SelectDiaForm_Load;
            FormClosing += SelectDiaForm_FormClosing;
        }

        /// <summary>
        /// SelectDiaForm_Loadイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SelectDiaForm_Load(object sender, EventArgs e)
        {
            // イベントハンドラ設定
            _serverCommunication.SelectDiaDataGridViewUpdated += (newDataSource) => UpdateDataSource(newDataSource);
            SelectDia_DataGridView_SelectDiaData.CellClick += DataGridView_SelectDia_CellClick;
            SelectDia_DataGridView_SelectDiaData.Scroll += DataGridView_SelectDia_Scroll;

            // DataGridViewのデータバインド
            SelectDia_BindingSource.DataSource = _dataManager.SelectDiaDataGridViewSettingList;

            // DataGridViewの設定
            SetupDataGridView();
        }

        /// <summary>
        /// SelectDiaForm_FormClosingイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SelectDiaForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Hide();
            e.Cancel = true;
        }

        /// <summary>
        /// 最前面表示切替イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SelectDiaForm_CheckBox_TopMost_CheckedChanged(object sender, EventArgs e)
        {
            this.TopMost = SelectDia_CheckBox_TopMost.Checked;
        }

        /// <summary>
        /// ボタンクリックイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void SelectDia_Button_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;

            switch (button.Name)
            {

            }
        }

        /// <summary>
        /// DataGridView更新処理
        /// </summary>
        /// <param name="newDataSource"></param>
        public void UpdateDataSource(SortableBindingList<SelectDiaDataGridViewSetting> newDataSource)
        {
            try
            {
                if (!this.IsDisposed)
                {
                    if (this.IsHandleCreated && !this.IsDisposed)
                    {
                        SuspendLayout();

                        // スクロール位置を保持
                        int firstDisplayedScrollingRowIndex = SelectDia_DataGridView_SelectDiaData.FirstDisplayedScrollingRowIndex;
                        int selectedRowIndex = SelectDia_DataGridView_SelectDiaData.CurrentCell?.RowIndex ?? 0;
                        int selectedColumnIndex = !_isScrolling ? (SelectDia_DataGridView_SelectDiaData.CurrentCell?.ColumnIndex ?? 0) : 0;
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
                                    SelectDia_BindingSource.DataSource = newDataSource;
                                    if (SelectDia_DataGridView_SelectDiaData.Rows.Count > 0)
                                    {
                                        SelectDia_DataGridView_SelectDiaData.FirstDisplayedScrollingRowIndex = Math.Min(firstDisplayedScrollingRowIndex, SelectDia_DataGridView_SelectDiaData.Rows.Count - 1);
                                        SelectDia_DataGridView_SelectDiaData.CurrentCell = SelectDia_DataGridView_SelectDiaData.Rows[Math.Min(selectedRowIndex, SelectDia_DataGridView_SelectDiaData.Rows.Count - 1)].Cells[Math.Min(selectedColumnIndex, SelectDia_DataGridView_SelectDiaData.Columns.Count - 1)];
                                    }
                                }
                            }));
                        }
                        else
                        {
                            if (!this.IsDisposed)
                            {
                                SelectDia_BindingSource.DataSource = newDataSource;
                                if (SelectDia_DataGridView_SelectDiaData.Rows.Count > 0)
                                {
                                    SelectDia_DataGridView_SelectDiaData.FirstDisplayedScrollingRowIndex = Math.Min(firstDisplayedScrollingRowIndex, SelectDia_DataGridView_SelectDiaData.Rows.Count - 1);
                                    SelectDia_DataGridView_SelectDiaData.CurrentCell = SelectDia_DataGridView_SelectDiaData.Rows[Math.Min(selectedRowIndex, SelectDia_DataGridView_SelectDiaData.Rows.Count - 1)].Cells[Math.Min(selectedColumnIndex, SelectDia_DataGridView_SelectDiaData.Columns.Count - 1)];
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
        /// DataGridViewの選択したデータを表示
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DataGridView_SelectDia_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var selectedRow = SelectDia_DataGridView_SelectDiaData.Rows[e.RowIndex];
                string diaName = selectedRow.Cells["DiaName"].Value.ToString();
                string version = selectedRow.Cells["Version"].Value.ToString();

                // 各コントロールに設定
                SelectDia_TextBox_DiaName.Text = diaName;
            }
        }

        /// <summary>
        /// DataGridViewスクロールイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DataGridView_SelectDia_Scroll(object sender, ScrollEventArgs e)
        {
            if (e.ScrollOrientation == ScrollOrientation.VerticalScroll)
            {
                _isScrolling = true;
            }
        }

        /// <summary>
        /// DataGridViewの設定
        /// </summary>
        private void SetupDataGridView()
        {
            // 複数選択不可
            SelectDia_DataGridView_SelectDiaData.MultiSelect = false;
            SelectDia_DataGridView_SelectDiaData.AutoGenerateColumns = false;

            // 中央揃え
            SelectDia_DataGridView_SelectDiaData.Columns["DiaName"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            SelectDia_DataGridView_SelectDiaData.Columns["Version"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }
    }
}
