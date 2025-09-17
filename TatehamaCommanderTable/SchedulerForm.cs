using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using TatehamaCommanderTable.Communications;
using TatehamaCommanderTable.Models;

namespace TatehamaCommanderTable
{
    public partial class SchedulerForm : Form
    {
        private readonly ServerCommunication _serverCommunication;
        private List<SchedulerInfo> _schedulers;
        private readonly Dictionary<string, CheckBox> _schedulerCheckBoxes;

        public SchedulerForm(ServerCommunication serverCommunication)
        {
            InitializeComponent();
            _serverCommunication = serverCommunication;
            _schedulers = new();
            _schedulerCheckBoxes = new();

            Load += SchedulerForm_Load;
        }

        private async void SchedulerForm_Load(object sender, EventArgs e)
        {
            await LoadSchedulers();
            CreateSchedulerControls();
        }

        private async Task LoadSchedulers()
        {
            try
            {
                _schedulers = await _serverCommunication.GetSchedulers();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"スケジューラー情報の取得に失敗しました: {ex.Message}", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CreateSchedulerControls()
        {
            int yPosition = 60;
            int xPosition = 20;
            int spacing = 50;
            int maxWidth = 200;

            foreach (var scheduler in _schedulers)
            {
                var checkBox = new CheckBox
                {
                    Name = $"checkBox_{scheduler.Name}",
                    Text = $"{scheduler.Name} ({scheduler.Type})",
                    Checked = scheduler.IsEnabled,
                    Location = new Point(xPosition, yPosition),
                    Font = new Font("Yu Gothic UI", 10F, FontStyle.Regular),
                    ForeColor = Color.Black,
                    AutoSize = true
                };

                checkBox.CheckedChanged += async (sender, e) =>
                {
                    await ToggleScheduler(scheduler.Name, checkBox.Checked);
                };

                _schedulerCheckBoxes[scheduler.Name] = checkBox;
                this.Controls.Add(checkBox);

                // テキストの実際の幅を測定
                using (Graphics g = this.CreateGraphics())
                {
                    SizeF textSize = g.MeasureString(checkBox.Text, checkBox.Font);
                    int textWidth = (int)Math.Ceiling(textSize.Width) + 30; // チェックボックス分を追加
                    maxWidth = Math.Max(maxWidth, textWidth);
                }

                yPosition += spacing;
            }

            this.Height = Math.Max(200, yPosition + 60);
            this.Width = Math.Max(600, maxWidth + 60); // 十分な余白を確保
        }

        private async Task ToggleScheduler(string schedulerName, bool isEnabled)
        {
            try
            {
                bool success = await _serverCommunication.ToggleScheduler(schedulerName, isEnabled);
                if (!success)
                {
                    MessageBox.Show($"スケジューラー '{schedulerName}' の切り替えに失敗しました", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    if (_schedulerCheckBoxes.ContainsKey(schedulerName))
                    {
                        _schedulerCheckBoxes[schedulerName].Checked = !isEnabled;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"スケジューラー '{schedulerName}' の切り替え中にエラーが発生しました: {ex.Message}", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);

                if (_schedulerCheckBoxes.ContainsKey(schedulerName))
                {
                    _schedulerCheckBoxes[schedulerName].Checked = !isEnabled;
                }
            }
        }

        private async void RefreshButton_Click(object sender, EventArgs e)
        {
            Controls.Clear();
            InitializeComponent();
            _schedulerCheckBoxes.Clear();
            await LoadSchedulers();
            CreateSchedulerControls();
        }
    }
}