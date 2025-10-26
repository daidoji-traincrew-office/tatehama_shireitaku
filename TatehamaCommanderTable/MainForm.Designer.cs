namespace TatehamaCommanderTable
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            Label_ServerConectionState = new System.Windows.Forms.Label();
            Button_Select_Kokuchi = new System.Windows.Forms.Button();
            Button_Select_Accident = new System.Windows.Forms.Button();
            Button_Select_TrackCircuit = new System.Windows.Forms.Button();
            Main_CheckBox_TopMost = new System.Windows.Forms.CheckBox();
            Button_Select_Message = new System.Windows.Forms.Button();
            Button_Select_Dia = new System.Windows.Forms.Button();
            Button_Select_ProtectionRadio = new System.Windows.Forms.Button();
            Button_Select_TrainState = new System.Windows.Forms.Button();
            GroupBox_Schedule = new System.Windows.Forms.GroupBox();
            RadioButton_ON_Private = new System.Windows.Forms.RadioButton();
            RadioButton_ON_Public = new System.Windows.Forms.RadioButton();
            RadioButton_OFF = new System.Windows.Forms.RadioButton();
            Label_ServerType = new System.Windows.Forms.Label();
            GroupBox_Volume = new System.Windows.Forms.GroupBox();
            Label_Volume = new System.Windows.Forms.Label();
            TrackBar_Volume = new System.Windows.Forms.TrackBar();
            Label_ProtectionRadioReceivingState = new System.Windows.Forms.Label();
            Button_Select_TimeOffset = new System.Windows.Forms.Button();
            GroupBox_Schedule.SuspendLayout();
            GroupBox_Volume.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)TrackBar_Volume).BeginInit();
            SuspendLayout();
            // 
            // Label_ServerConectionState
            // 
            Label_ServerConectionState.BackColor = System.Drawing.Color.FromArgb(85, 85, 85);
            Label_ServerConectionState.Font = new System.Drawing.Font("Yu Gothic UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 128);
            Label_ServerConectionState.ForeColor = System.Drawing.Color.FromArgb(136, 136, 136);
            Label_ServerConectionState.Location = new System.Drawing.Point(642, 9);
            Label_ServerConectionState.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            Label_ServerConectionState.Name = "Label_ServerConectionState";
            Label_ServerConectionState.Size = new System.Drawing.Size(130, 30);
            Label_ServerConectionState.TabIndex = 0;
            Label_ServerConectionState.Text = "オフライン";
            Label_ServerConectionState.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Button_Select_Kokuchi
            // 
            Button_Select_Kokuchi.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            Button_Select_Kokuchi.BackColor = System.Drawing.Color.LightBlue;
            Button_Select_Kokuchi.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            Button_Select_Kokuchi.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkKhaki;
            Button_Select_Kokuchi.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Khaki;
            Button_Select_Kokuchi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            Button_Select_Kokuchi.Font = new System.Drawing.Font("BIZ UDゴシック", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 128);
            Button_Select_Kokuchi.Location = new System.Drawing.Point(66, 120);
            Button_Select_Kokuchi.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            Button_Select_Kokuchi.Name = "Button_Select_Kokuchi";
            Button_Select_Kokuchi.Size = new System.Drawing.Size(200, 100);
            Button_Select_Kokuchi.TabIndex = 1;
            Button_Select_Kokuchi.Text = "運転告知器";
            Button_Select_Kokuchi.UseVisualStyleBackColor = false;
            Button_Select_Kokuchi.Click += ButtonClickEvent;
            // 
            // Button_Select_Accident
            // 
            Button_Select_Accident.BackColor = System.Drawing.Color.LightBlue;
            Button_Select_Accident.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            Button_Select_Accident.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkKhaki;
            Button_Select_Accident.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Khaki;
            Button_Select_Accident.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            Button_Select_Accident.Font = new System.Drawing.Font("BIZ UDゴシック", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 128);
            Button_Select_Accident.Location = new System.Drawing.Point(292, 120);
            Button_Select_Accident.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            Button_Select_Accident.Name = "Button_Select_Accident";
            Button_Select_Accident.Size = new System.Drawing.Size(200, 100);
            Button_Select_Accident.TabIndex = 2;
            Button_Select_Accident.Text = "運転支障\r\n";
            Button_Select_Accident.UseVisualStyleBackColor = false;
            Button_Select_Accident.Click += ButtonClickEvent;
            // 
            // Button_Select_TrackCircuit
            // 
            Button_Select_TrackCircuit.BackColor = System.Drawing.Color.LightBlue;
            Button_Select_TrackCircuit.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            Button_Select_TrackCircuit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkKhaki;
            Button_Select_TrackCircuit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Khaki;
            Button_Select_TrackCircuit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            Button_Select_TrackCircuit.Font = new System.Drawing.Font("BIZ UDゴシック", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 128);
            Button_Select_TrackCircuit.Location = new System.Drawing.Point(517, 120);
            Button_Select_TrackCircuit.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            Button_Select_TrackCircuit.Name = "Button_Select_TrackCircuit";
            Button_Select_TrackCircuit.Size = new System.Drawing.Size(200, 100);
            Button_Select_TrackCircuit.TabIndex = 3;
            Button_Select_TrackCircuit.Text = "軌道回路";
            Button_Select_TrackCircuit.UseVisualStyleBackColor = false;
            Button_Select_TrackCircuit.Click += ButtonClickEvent;
            // 
            // Main_CheckBox_TopMost
            // 
            Main_CheckBox_TopMost.AutoSize = true;
            Main_CheckBox_TopMost.Font = new System.Drawing.Font("BIZ UDゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 128);
            Main_CheckBox_TopMost.ForeColor = System.Drawing.Color.White;
            Main_CheckBox_TopMost.Location = new System.Drawing.Point(671, 53);
            Main_CheckBox_TopMost.Name = "Main_CheckBox_TopMost";
            Main_CheckBox_TopMost.Size = new System.Drawing.Size(101, 19);
            Main_CheckBox_TopMost.TabIndex = 17;
            Main_CheckBox_TopMost.Text = "最前面表示";
            Main_CheckBox_TopMost.UseVisualStyleBackColor = true;
            Main_CheckBox_TopMost.CheckedChanged += Main_CheckBox_TopMost_CheckedChanged;
            // 
            // Button_Select_Message
            // 
            Button_Select_Message.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            Button_Select_Message.BackColor = System.Drawing.Color.LightBlue;
            Button_Select_Message.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            Button_Select_Message.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkKhaki;
            Button_Select_Message.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Khaki;
            Button_Select_Message.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            Button_Select_Message.Font = new System.Drawing.Font("BIZ UDゴシック", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 128);
            Button_Select_Message.Location = new System.Drawing.Point(66, 250);
            Button_Select_Message.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            Button_Select_Message.Name = "Button_Select_Message";
            Button_Select_Message.Size = new System.Drawing.Size(200, 100);
            Button_Select_Message.TabIndex = 18;
            Button_Select_Message.Text = "運行メッセージ";
            Button_Select_Message.UseVisualStyleBackColor = false;
            Button_Select_Message.Click += ButtonClickEvent;
            // 
            // Button_Select_Dia
            // 
            Button_Select_Dia.BackColor = System.Drawing.Color.LightBlue;
            Button_Select_Dia.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            Button_Select_Dia.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkKhaki;
            Button_Select_Dia.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Khaki;
            Button_Select_Dia.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            Button_Select_Dia.Font = new System.Drawing.Font("BIZ UDゴシック", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 128);
            Button_Select_Dia.Location = new System.Drawing.Point(292, 250);
            Button_Select_Dia.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            Button_Select_Dia.Name = "Button_Select_Dia";
            Button_Select_Dia.Size = new System.Drawing.Size(200, 100);
            Button_Select_Dia.TabIndex = 19;
            Button_Select_Dia.Text = "日時ダイヤ行先";
            Button_Select_Dia.UseVisualStyleBackColor = false;
            Button_Select_Dia.Click += ButtonClickEvent;
            // 
            // Button_Select_ProtectionRadio
            // 
            Button_Select_ProtectionRadio.BackColor = System.Drawing.Color.LightBlue;
            Button_Select_ProtectionRadio.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            Button_Select_ProtectionRadio.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkKhaki;
            Button_Select_ProtectionRadio.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Khaki;
            Button_Select_ProtectionRadio.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            Button_Select_ProtectionRadio.Font = new System.Drawing.Font("BIZ UDゴシック", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 128);
            Button_Select_ProtectionRadio.Location = new System.Drawing.Point(517, 250);
            Button_Select_ProtectionRadio.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            Button_Select_ProtectionRadio.Name = "Button_Select_ProtectionRadio";
            Button_Select_ProtectionRadio.Size = new System.Drawing.Size(200, 100);
            Button_Select_ProtectionRadio.TabIndex = 20;
            Button_Select_ProtectionRadio.Text = "防護無線";
            Button_Select_ProtectionRadio.UseVisualStyleBackColor = false;
            Button_Select_ProtectionRadio.Click += ButtonClickEvent;
            // 
            // Button_Select_TrainState
            // 
            Button_Select_TrainState.BackColor = System.Drawing.Color.LightBlue;
            Button_Select_TrainState.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            Button_Select_TrainState.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkKhaki;
            Button_Select_TrainState.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Khaki;
            Button_Select_TrainState.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            Button_Select_TrainState.Font = new System.Drawing.Font("BIZ UDゴシック", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 128);
            Button_Select_TrainState.Location = new System.Drawing.Point(66, 380);
            Button_Select_TrainState.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            Button_Select_TrainState.Name = "Button_Select_TrainState";
            Button_Select_TrainState.Size = new System.Drawing.Size(200, 100);
            Button_Select_TrainState.TabIndex = 21;
            Button_Select_TrainState.Text = "列車情報";
            Button_Select_TrainState.UseVisualStyleBackColor = false;
            Button_Select_TrainState.Click += ButtonClickEvent;
            // 
            // GroupBox_Schedule
            // 
            GroupBox_Schedule.Controls.Add(RadioButton_ON_Private);
            GroupBox_Schedule.Controls.Add(RadioButton_ON_Public);
            GroupBox_Schedule.Controls.Add(RadioButton_OFF);
            GroupBox_Schedule.ForeColor = System.Drawing.Color.White;
            GroupBox_Schedule.Location = new System.Drawing.Point(12, 9);
            GroupBox_Schedule.Name = "GroupBox_Schedule";
            GroupBox_Schedule.Size = new System.Drawing.Size(335, 59);
            GroupBox_Schedule.TabIndex = 22;
            GroupBox_Schedule.TabStop = false;
            GroupBox_Schedule.Text = "定時処理";
            // 
            // RadioButton_ON_Private
            // 
            RadioButton_ON_Private.Appearance = System.Windows.Forms.Appearance.Button;
            RadioButton_ON_Private.BackColor = System.Drawing.Color.White;
            RadioButton_ON_Private.FlatAppearance.BorderSize = 0;
            RadioButton_ON_Private.FlatAppearance.CheckedBackColor = System.Drawing.Color.Gold;
            RadioButton_ON_Private.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gold;
            RadioButton_ON_Private.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gold;
            RadioButton_ON_Private.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            RadioButton_ON_Private.Font = new System.Drawing.Font("Yu Gothic UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 128);
            RadioButton_ON_Private.ForeColor = System.Drawing.Color.Black;
            RadioButton_ON_Private.Location = new System.Drawing.Point(117, 18);
            RadioButton_ON_Private.Margin = new System.Windows.Forms.Padding(5);
            RadioButton_ON_Private.Name = "RadioButton_ON_Private";
            RadioButton_ON_Private.Size = new System.Drawing.Size(100, 30);
            RadioButton_ON_Private.TabIndex = 24;
            RadioButton_ON_Private.Text = "ON (Private)";
            RadioButton_ON_Private.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            RadioButton_ON_Private.UseVisualStyleBackColor = false;
            RadioButton_ON_Private.CheckedChanged += RadioButton_CheckedChanged;
            // 
            // RadioButton_ON_Public
            // 
            RadioButton_ON_Public.Appearance = System.Windows.Forms.Appearance.Button;
            RadioButton_ON_Public.BackColor = System.Drawing.Color.White;
            RadioButton_ON_Public.Checked = true;
            RadioButton_ON_Public.FlatAppearance.BorderSize = 0;
            RadioButton_ON_Public.FlatAppearance.CheckedBackColor = System.Drawing.Color.Gold;
            RadioButton_ON_Public.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gold;
            RadioButton_ON_Public.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gold;
            RadioButton_ON_Public.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            RadioButton_ON_Public.Font = new System.Drawing.Font("Yu Gothic UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 128);
            RadioButton_ON_Public.ForeColor = System.Drawing.Color.Black;
            RadioButton_ON_Public.Location = new System.Drawing.Point(227, 18);
            RadioButton_ON_Public.Margin = new System.Windows.Forms.Padding(5);
            RadioButton_ON_Public.Name = "RadioButton_ON_Public";
            RadioButton_ON_Public.Size = new System.Drawing.Size(100, 30);
            RadioButton_ON_Public.TabIndex = 23;
            RadioButton_ON_Public.TabStop = true;
            RadioButton_ON_Public.Text = "ON (Public)";
            RadioButton_ON_Public.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            RadioButton_ON_Public.UseVisualStyleBackColor = false;
            RadioButton_ON_Public.CheckedChanged += RadioButton_CheckedChanged;
            // 
            // RadioButton_OFF
            // 
            RadioButton_OFF.Appearance = System.Windows.Forms.Appearance.Button;
            RadioButton_OFF.BackColor = System.Drawing.Color.White;
            RadioButton_OFF.FlatAppearance.BorderSize = 0;
            RadioButton_OFF.FlatAppearance.CheckedBackColor = System.Drawing.Color.Gold;
            RadioButton_OFF.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gold;
            RadioButton_OFF.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gold;
            RadioButton_OFF.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            RadioButton_OFF.Font = new System.Drawing.Font("Yu Gothic UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 128);
            RadioButton_OFF.ForeColor = System.Drawing.Color.Black;
            RadioButton_OFF.Location = new System.Drawing.Point(7, 18);
            RadioButton_OFF.Margin = new System.Windows.Forms.Padding(5);
            RadioButton_OFF.Name = "RadioButton_OFF";
            RadioButton_OFF.Size = new System.Drawing.Size(100, 30);
            RadioButton_OFF.TabIndex = 22;
            RadioButton_OFF.Text = "OFF";
            RadioButton_OFF.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            RadioButton_OFF.UseVisualStyleBackColor = false;
            RadioButton_OFF.CheckedChanged += RadioButton_CheckedChanged;
            // 
            // Label_ServerType
            // 
            Label_ServerType.BackColor = System.Drawing.Color.FromArgb(85, 85, 85);
            Label_ServerType.Font = new System.Drawing.Font("Yu Gothic UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 128);
            Label_ServerType.ForeColor = System.Drawing.Color.FromArgb(136, 136, 136);
            Label_ServerType.Location = new System.Drawing.Point(564, 9);
            Label_ServerType.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            Label_ServerType.Name = "Label_ServerType";
            Label_ServerType.Size = new System.Drawing.Size(70, 30);
            Label_ServerType.TabIndex = 23;
            Label_ServerType.Text = "Prod";
            Label_ServerType.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // GroupBox_Volume
            // 
            GroupBox_Volume.Controls.Add(Label_Volume);
            GroupBox_Volume.Controls.Add(TrackBar_Volume);
            GroupBox_Volume.ForeColor = System.Drawing.Color.White;
            GroupBox_Volume.Location = new System.Drawing.Point(353, 9);
            GroupBox_Volume.Name = "GroupBox_Volume";
            GroupBox_Volume.Size = new System.Drawing.Size(89, 59);
            GroupBox_Volume.TabIndex = 25;
            GroupBox_Volume.TabStop = false;
            GroupBox_Volume.Text = "音量";
            // 
            // Label_Volume
            // 
            Label_Volume.ForeColor = System.Drawing.Color.White;
            Label_Volume.Location = new System.Drawing.Point(33, -2);
            Label_Volume.Name = "Label_Volume";
            Label_Volume.Size = new System.Drawing.Size(36, 18);
            Label_Volume.TabIndex = 26;
            Label_Volume.Text = "100%";
            Label_Volume.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TrackBar_Volume
            // 
            TrackBar_Volume.AutoSize = false;
            TrackBar_Volume.LargeChange = 1;
            TrackBar_Volume.Location = new System.Drawing.Point(6, 18);
            TrackBar_Volume.Name = "TrackBar_Volume";
            TrackBar_Volume.Size = new System.Drawing.Size(77, 30);
            TrackBar_Volume.TabIndex = 26;
            TrackBar_Volume.TickFrequency = 5;
            TrackBar_Volume.Value = 10;
            // 
            // Label_ProtectionRadioReceivingState
            // 
            Label_ProtectionRadioReceivingState.BackColor = System.Drawing.Color.FromArgb(85, 85, 85);
            Label_ProtectionRadioReceivingState.Font = new System.Drawing.Font("Yu Gothic UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 128);
            Label_ProtectionRadioReceivingState.ForeColor = System.Drawing.Color.FromArgb(136, 136, 136);
            Label_ProtectionRadioReceivingState.Location = new System.Drawing.Point(486, 9);
            Label_ProtectionRadioReceivingState.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            Label_ProtectionRadioReceivingState.Name = "Label_ProtectionRadioReceivingState";
            Label_ProtectionRadioReceivingState.Size = new System.Drawing.Size(70, 30);
            Label_ProtectionRadioReceivingState.TabIndex = 26;
            Label_ProtectionRadioReceivingState.Text = "防護";
            Label_ProtectionRadioReceivingState.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Button_Select_TimeOffset
            // 
            Button_Select_TimeOffset.BackColor = System.Drawing.Color.LightBlue;
            Button_Select_TimeOffset.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            Button_Select_TimeOffset.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkKhaki;
            Button_Select_TimeOffset.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Khaki;
            Button_Select_TimeOffset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            Button_Select_TimeOffset.Font = new System.Drawing.Font("BIZ UDゴシック", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 128);
            Button_Select_TimeOffset.Location = new System.Drawing.Point(292, 380);
            Button_Select_TimeOffset.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            Button_Select_TimeOffset.Name = "Button_Select_TimeOffset";
            Button_Select_TimeOffset.Size = new System.Drawing.Size(200, 100);
            Button_Select_TimeOffset.TabIndex = 27;
            Button_Select_TimeOffset.Text = "時差設定";
            Button_Select_TimeOffset.UseVisualStyleBackColor = false;
            Button_Select_TimeOffset.Click += ButtonClickEvent;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.FromArgb(76, 102, 102);
            ClientSize = new System.Drawing.Size(784, 561);
            Controls.Add(Button_Select_TimeOffset);
            Controls.Add(Label_ProtectionRadioReceivingState);
            Controls.Add(GroupBox_Volume);
            Controls.Add(Label_ServerType);
            Controls.Add(GroupBox_Schedule);
            Controls.Add(Button_Select_TrainState);
            Controls.Add(Button_Select_ProtectionRadio);
            Controls.Add(Button_Select_Dia);
            Controls.Add(Button_Select_Message);
            Controls.Add(Main_CheckBox_TopMost);
            Controls.Add(Button_Select_TrackCircuit);
            Controls.Add(Button_Select_Accident);
            Controls.Add(Button_Select_Kokuchi);
            Controls.Add(Label_ServerConectionState);
            Font = new System.Drawing.Font("Yu Gothic UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 128);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            MaximizeBox = false;
            Name = "MainForm";
            Text = "項目選択 | 司令卓 - ダイヤ運転会";
            GroupBox_Schedule.ResumeLayout(false);
            GroupBox_Volume.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)TrackBar_Volume).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label Label_ServerConectionState;
        private System.Windows.Forms.Button Button_Select_Kokuchi;
        private System.Windows.Forms.Button Button_Select_Accident;
        private System.Windows.Forms.Button Button_Select_TrackCircuit;
        private System.Windows.Forms.CheckBox Main_CheckBox_TopMost;
        private System.Windows.Forms.Button Button_Select_Message;
        private System.Windows.Forms.Button Button_Select_Dia;
        private System.Windows.Forms.Button Button_Select_ProtectionRadio;
        private System.Windows.Forms.Button Button_Select_TrainState;
        private System.Windows.Forms.GroupBox GroupBox_Schedule;
        private System.Windows.Forms.RadioButton RadioButton_ON_Private;
        private System.Windows.Forms.RadioButton RadioButton_ON_Public;
        private System.Windows.Forms.RadioButton RadioButton_OFF;
        private System.Windows.Forms.Label Label_ServerType;
        private System.Windows.Forms.GroupBox GroupBox_Volume;
        private System.Windows.Forms.TrackBar TrackBar_Volume;
        private System.Windows.Forms.Label Label_Volume;
        private System.Windows.Forms.Label Label_ProtectionRadioReceivingState;
        private System.Windows.Forms.Button Button_Select_TimeOffset;
    }
}
