using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using TatehamaCommanderTable.Config;

namespace TatehamaCommanderTable;

public partial class EnvironmentSelectForm : Form
{
    private EnvironmentType? _selectedEnvironment;
    public EnvironmentType SelectedEnvironment { get; private set; }
    public string? CustomLocalUrl { get; private set; }

    private TextBox? _localUrlTextBox;
    private Label? _localUrlLabel;

    public EnvironmentSelectForm()
    {
        InitializeComponent();
        SetupEnvironmentRadioButtons();
        SetupLocalUrlInput();
        UpdateLocalUrlVisibility(); // 初期表示状態を更新
    }

    private void SetupEnvironmentRadioButtons()
    {
        // URLが空でない環境のみラジオボタンを生成
        int yPosition = 60;
        var availableEnvironments = EnvironmentDefinition.Available;

        if (!availableEnvironments.Any())
        {
            MessageBox.Show(
                "利用可能な環境が定義されていません。\nServerAddress.csを確認してください。",
                "エラー",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
            );
            Application.Exit();
            return;
        }

        foreach (var env in availableEnvironments)
        {
            // Todo: Localを公開してもよくなったら以下のContinueを消す
            if (env.Type == EnvironmentType.Local)
            {
                continue;
            }
            var radioButton = new RadioButton
            {
                Text = env.DisplayName,  // URLではなく環境名のみ表示
                Tag = env.Type,
                Appearance = Appearance.Button,
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.White,
                ForeColor = Color.Black,
                Font = new Font("BIZ UDゴシック", 12F, FontStyle.Bold, GraphicsUnit.Point, 128),
                TextAlign = ContentAlignment.MiddleCenter,
                Location = new Point(30, yPosition),
                Size = new Size(340, 36),
                Checked = (yPosition == 60)  // 最初の環境をデフォルト選択
            };
            radioButton.FlatAppearance.CheckedBackColor = Color.Gold;
            radioButton.FlatAppearance.MouseOverBackColor = Color.Khaki;
            radioButton.FlatAppearance.MouseDownBackColor = Color.DarkKhaki;
            radioButton.FlatAppearance.BorderColor = Color.Black;
            radioButton.CheckedChanged += RadioButton_CheckedChanged;
            this.Controls.Add(radioButton);
            yPosition += 44;

            if (radioButton.Checked)
            {
                _selectedEnvironment = env.Type;
            }
        }
    }

    private void SetupLocalUrlInput()
    {
        // ローカルURL入力欄を作成
        _localUrlLabel = new Label
        {
            Text = "ローカルURL:",
            Font = new Font("BIZ UDゴシック", 10F, FontStyle.Regular, GraphicsUnit.Point, 128),
            ForeColor = Color.White,
            Location = new Point(30, 165),
            AutoSize = true,
            Visible = false
        };
        this.Controls.Add(_localUrlLabel);

        _localUrlTextBox = new TextBox
        {
            Location = new Point(30, 188),
            Size = new Size(340, 23),
            Font = new Font("BIZ UDゴシック", 10F, FontStyle.Regular, GraphicsUnit.Point, 128),
            Text = ServerAddress.LocalUrl,
            Visible = false
        };
        this.Controls.Add(_localUrlTextBox);
    }

    private void RadioButton_CheckedChanged(object? sender, EventArgs e)
    {
        if (sender is RadioButton rb && rb.Checked)
        {
            _selectedEnvironment = (EnvironmentType)rb.Tag!;
            UpdateLocalUrlVisibility();
        }
    }

    private void UpdateLocalUrlVisibility()
    {
        // Local環境の場合はURL入力欄を表示
        if (_localUrlTextBox != null && _localUrlLabel != null && _selectedEnvironment.HasValue)
        {
            bool isLocal = _selectedEnvironment == EnvironmentType.Local;
            _localUrlTextBox.Visible = isLocal;
            _localUrlLabel.Visible = isLocal;
        }
    }

    private void ConnectButton_Click(object? sender, EventArgs e)
    {
        if (!_selectedEnvironment.HasValue)
        {
            MessageBox.Show("環境を選択してください。", "エラー",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        // Local環境の場合はカスタムURLを保存
        if (_selectedEnvironment == EnvironmentType.Local && _localUrlTextBox != null)
        {
            var customUrl = _localUrlTextBox.Text.Trim();
            if (string.IsNullOrEmpty(customUrl))
            {
                MessageBox.Show("ローカルURLを入力してください。", "エラー",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // URLの妥当性チェック
            if (!Uri.TryCreate(customUrl, UriKind.Absolute, out var uri) ||
                (uri.Scheme != "http" && uri.Scheme != "https"))
            {
                MessageBox.Show("有効なURLを入力してください。\n例: https://localhost:7232", "エラー",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            CustomLocalUrl = customUrl;
        }

        SelectedEnvironment = _selectedEnvironment.Value;
        DialogResult = DialogResult.OK;
        Close();
    }

    private void CancelButton_Click(object? sender, EventArgs e)
    {
        DialogResult = DialogResult.Cancel;
        Close();
    }
}
