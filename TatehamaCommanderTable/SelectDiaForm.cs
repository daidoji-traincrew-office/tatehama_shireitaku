using System;
using System.Drawing;
using System.Threading.Tasks;
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
        private ulong? _selectedDiagramId;

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
        private async void SelectDiaForm_Load(object sender, EventArgs e)
        {
            // イベントハンドラ設定
            _serverCommunication.ReceiveData += OnReceiveData;
            SelectDia_DataGridView_SelectDiaData.CellClick += DataGridView_SelectDia_CellClick;
            SelectDia_DataGridView_SelectDiaData.Scroll += DataGridView_SelectDia_Scroll;

            // DataGridViewの設定
            SetupDataGridView();

            // ダイヤ一覧を取得
            await LoadDiagramsAsync();
        }

        /// <summary>
        /// SelectDiaForm_FormClosingイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SelectDiaForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            _serverCommunication.ReceiveData -= OnReceiveData;
            Hide();
            e.Cancel = true;
        }

        private void OnReceiveData(DatabaseOperational.DataFromServer _)
        {
            if (this.InvokeRequired)
                this.Invoke(HighlightSelectedRow);
            else
                HighlightSelectedRow();
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
                case "SelectDia_Button_Set":
                    if (_selectedDiagramId.HasValue)
                    {
                        await _serverCommunication.SetSelectedDiagramIdAsync(_selectedDiagramId.Value);
                        if (_dataManager.DataFromServer != null)
                            _dataManager.DataFromServer.SelectedDiagramId = _selectedDiagramId.Value;
                        HighlightSelectedRow();
                    }
                    break;
                case "SelectDia_Button_Cancel":
                    await _serverCommunication.SetSelectedDiagramIdAsync(null);
                    if (_dataManager.DataFromServer != null)
                        _dataManager.DataFromServer.SelectedDiagramId = null;
                    HighlightSelectedRow();
                    break;
                case "SelectDia_Button_Reload":
                    await LoadDiagramsAsync();
                    break;
            }
        }

        /// <summary>
        /// サーバーからダイヤ一覧を取得してDataGridViewを更新
        /// </summary>
        private async Task LoadDiagramsAsync()
        {
            var diagrams = await _serverCommunication.GetDiagramsAsync();
            var list = new SortableBindingList<SelectDiaDataGridViewSetting>();
            foreach (var d in diagrams)
            {
                list.Add(new SelectDiaDataGridViewSetting
                {
                    Id = d.Id.ToString(),
                    DiaName = d.Name,
                    Version = d.Version,
                });
            }
            _dataManager.SelectDiaDataGridViewSettingList = list;
            UpdateDataSource(list);
            HighlightSelectedRow();
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
                var item = (SelectDiaDataGridViewSetting)SelectDia_BindingSource[e.RowIndex];
                SelectDia_TextBox_DiaName.Text = item.DiaName;
                _selectedDiagramId = ulong.TryParse(item.Id, out var id) ? id : null;
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
        /// 選択中ダイヤの行をハイライト
        /// </summary>
        private void HighlightSelectedRow()
        {
            var activeId = _dataManager.DataFromServer?.SelectedDiagramId;
            foreach (DataGridViewRow row in SelectDia_DataGridView_SelectDiaData.Rows)
            {
                var item = row.DataBoundItem as SelectDiaDataGridViewSetting;
                bool isSelected = item != null && ulong.TryParse(item.Id, out var rowId) && rowId == activeId;
                row.Cells["Selected"].Value = isSelected ? "O" : "";
                row.DefaultCellStyle.BackColor = isSelected ? Color.Lime : Color.Empty;
                row.DefaultCellStyle.ForeColor = isSelected ? Color.Black : Color.Empty;
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
            SelectDia_DataGridView_SelectDiaData.Columns["Selected"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            SelectDia_DataGridView_SelectDiaData.Columns["DiaName"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            SelectDia_DataGridView_SelectDiaData.Columns["Version"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }
    }
}
