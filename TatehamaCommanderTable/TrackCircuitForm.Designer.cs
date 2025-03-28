namespace TatehamaCommanderTable
{
    partial class TrackCircuitForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            TrackCircuit_DataGridView_TrackCircuitData = new System.Windows.Forms.DataGridView();
            trackCircuit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            trainNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            shortCircuitStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            lockingStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            TrackCircuit_BindingSource = new System.Windows.Forms.BindingSource(components);
            TrackCircuit_Button_SendServer = new System.Windows.Forms.Button();
            TrackCircuit_TextBox_TrainNumber = new System.Windows.Forms.TextBox();
            TrackCircuit_RadioButton_ShortCircuit_ON = new System.Windows.Forms.RadioButton();
            TrackCircuit_RadioButton_ShortCircuit_OFF = new System.Windows.Forms.RadioButton();
            TrackCircuit_Label_Title_TrackCircuit = new System.Windows.Forms.Label();
            TrackCircuit_Label_Title_TrainNumber = new System.Windows.Forms.Label();
            TrackCircuit_GroupBox_TrackCircuitSetting = new System.Windows.Forms.GroupBox();
            TrackCircuit_GroupBox_Title_Loking = new System.Windows.Forms.GroupBox();
            TrackCircuit_RadioButton_Locking_OFF = new System.Windows.Forms.RadioButton();
            TrackCircuit_RadioButton_Locking_ON = new System.Windows.Forms.RadioButton();
            TrackCircuit_GroupBox_Title_ShortCircuit = new System.Windows.Forms.GroupBox();
            TrackCircuit_CheckBox_TopMost = new System.Windows.Forms.CheckBox();
            TrackCircuit_GroupBox_DeleteNumberSetting = new System.Windows.Forms.GroupBox();
            TrackCircuit_Label_Title_DeleteTrainNumber = new System.Windows.Forms.Label();
            TrackCircuit_TextBox_DeleteTrainNumber = new System.Windows.Forms.TextBox();
            TrackCircuit_Button_DeleteTrainNumber = new System.Windows.Forms.Button();
            TrackCircuit_TextBox_TrackCircuit = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)TrackCircuit_DataGridView_TrackCircuitData).BeginInit();
            ((System.ComponentModel.ISupportInitialize)TrackCircuit_BindingSource).BeginInit();
            TrackCircuit_GroupBox_TrackCircuitSetting.SuspendLayout();
            TrackCircuit_GroupBox_Title_Loking.SuspendLayout();
            TrackCircuit_GroupBox_Title_ShortCircuit.SuspendLayout();
            TrackCircuit_GroupBox_DeleteNumberSetting.SuspendLayout();
            SuspendLayout();
            // 
            // TrackCircuit_DataGridView_TrackCircuitData
            // 
            TrackCircuit_DataGridView_TrackCircuitData.AllowUserToAddRows = false;
            TrackCircuit_DataGridView_TrackCircuitData.AllowUserToDeleteRows = false;
            TrackCircuit_DataGridView_TrackCircuitData.AllowUserToResizeColumns = false;
            TrackCircuit_DataGridView_TrackCircuitData.AllowUserToResizeRows = false;
            TrackCircuit_DataGridView_TrackCircuitData.AutoGenerateColumns = false;
            TrackCircuit_DataGridView_TrackCircuitData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            TrackCircuit_DataGridView_TrackCircuitData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { trackCircuit, trainNumber, shortCircuitStatus, lockingStatus });
            TrackCircuit_DataGridView_TrackCircuitData.DataSource = TrackCircuit_BindingSource;
            TrackCircuit_DataGridView_TrackCircuitData.Location = new System.Drawing.Point(12, 12);
            TrackCircuit_DataGridView_TrackCircuitData.Name = "TrackCircuit_DataGridView_TrackCircuitData";
            TrackCircuit_DataGridView_TrackCircuitData.RowHeadersVisible = false;
            TrackCircuit_DataGridView_TrackCircuitData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            TrackCircuit_DataGridView_TrackCircuitData.Size = new System.Drawing.Size(520, 705);
            TrackCircuit_DataGridView_TrackCircuitData.TabIndex = 0;
            TrackCircuit_DataGridView_TrackCircuitData.SelectionChanged += DataGridView_TrackCircuitData_SelectionChanged;
            // 
            // trackCircuit
            // 
            trackCircuit.DataPropertyName = "trackCircuit";
            trackCircuit.HeaderText = "軌道回路";
            trackCircuit.MaxInputLength = 20;
            trackCircuit.Name = "trackCircuit";
            trackCircuit.ReadOnly = true;
            trackCircuit.Width = 200;
            // 
            // trainNumber
            // 
            trainNumber.DataPropertyName = "trainNumber";
            trainNumber.HeaderText = "列車番号";
            trainNumber.MaxInputLength = 6;
            trainNumber.Name = "trainNumber";
            trainNumber.ReadOnly = true;
            // 
            // shortCircuitStatus
            // 
            shortCircuitStatus.DataPropertyName = "shortCircuitStatus";
            shortCircuitStatus.HeaderText = "短絡状態";
            shortCircuitStatus.MaxInputLength = 5;
            shortCircuitStatus.Name = "shortCircuitStatus";
            shortCircuitStatus.ReadOnly = true;
            // 
            // lockingStatus
            // 
            lockingStatus.DataPropertyName = "lockingStatus";
            lockingStatus.HeaderText = "鎖錠状態";
            lockingStatus.MaxInputLength = 5;
            lockingStatus.Name = "lockingStatus";
            lockingStatus.ReadOnly = true;
            // 
            // TrackCircuit_Button_SendServer
            // 
            TrackCircuit_Button_SendServer.BackColor = System.Drawing.Color.Lime;
            TrackCircuit_Button_SendServer.FlatAppearance.BorderSize = 0;
            TrackCircuit_Button_SendServer.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            TrackCircuit_Button_SendServer.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            TrackCircuit_Button_SendServer.Font = new System.Drawing.Font("BIZ UDゴシック", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 128);
            TrackCircuit_Button_SendServer.ForeColor = System.Drawing.SystemColors.ControlText;
            TrackCircuit_Button_SendServer.Location = new System.Drawing.Point(625, 675);
            TrackCircuit_Button_SendServer.Name = "TrackCircuit_Button_SendServer";
            TrackCircuit_Button_SendServer.Size = new System.Drawing.Size(160, 40);
            TrackCircuit_Button_SendServer.TabIndex = 3;
            TrackCircuit_Button_SendServer.Text = "サーバー送信";
            TrackCircuit_Button_SendServer.UseVisualStyleBackColor = false;
            TrackCircuit_Button_SendServer.Click += TrackCircuit_Button_Click;
            // 
            // TrackCircuit_TextBox_TrainNumber
            // 
            TrackCircuit_TextBox_TrainNumber.Font = new System.Drawing.Font("BIZ UDゴシック", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 128);
            TrackCircuit_TextBox_TrainNumber.Location = new System.Drawing.Point(46, 115);
            TrackCircuit_TextBox_TrainNumber.MaxLength = 6;
            TrackCircuit_TextBox_TrainNumber.Name = "TrackCircuit_TextBox_TrainNumber";
            TrackCircuit_TextBox_TrainNumber.Size = new System.Drawing.Size(265, 28);
            TrackCircuit_TextBox_TrainNumber.TabIndex = 4;
            TrackCircuit_TextBox_TrainNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // TrackCircuit_RadioButton_ShortCircuit_ON
            // 
            TrackCircuit_RadioButton_ShortCircuit_ON.AutoSize = true;
            TrackCircuit_RadioButton_ShortCircuit_ON.Font = new System.Drawing.Font("BIZ UDゴシック", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 128);
            TrackCircuit_RadioButton_ShortCircuit_ON.ForeColor = System.Drawing.Color.White;
            TrackCircuit_RadioButton_ShortCircuit_ON.Location = new System.Drawing.Point(95, 22);
            TrackCircuit_RadioButton_ShortCircuit_ON.Name = "TrackCircuit_RadioButton_ShortCircuit_ON";
            TrackCircuit_RadioButton_ShortCircuit_ON.Size = new System.Drawing.Size(70, 25);
            TrackCircuit_RadioButton_ShortCircuit_ON.TabIndex = 5;
            TrackCircuit_RadioButton_ShortCircuit_ON.TabStop = true;
            TrackCircuit_RadioButton_ShortCircuit_ON.Text = "短絡";
            TrackCircuit_RadioButton_ShortCircuit_ON.UseVisualStyleBackColor = true;
            // 
            // TrackCircuit_RadioButton_ShortCircuit_OFF
            // 
            TrackCircuit_RadioButton_ShortCircuit_OFF.AutoSize = true;
            TrackCircuit_RadioButton_ShortCircuit_OFF.Font = new System.Drawing.Font("BIZ UDゴシック", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 128);
            TrackCircuit_RadioButton_ShortCircuit_OFF.ForeColor = System.Drawing.Color.White;
            TrackCircuit_RadioButton_ShortCircuit_OFF.Location = new System.Drawing.Point(171, 22);
            TrackCircuit_RadioButton_ShortCircuit_OFF.Name = "TrackCircuit_RadioButton_ShortCircuit_OFF";
            TrackCircuit_RadioButton_ShortCircuit_OFF.Size = new System.Drawing.Size(70, 25);
            TrackCircuit_RadioButton_ShortCircuit_OFF.TabIndex = 6;
            TrackCircuit_RadioButton_ShortCircuit_OFF.TabStop = true;
            TrackCircuit_RadioButton_ShortCircuit_OFF.Text = "なし";
            TrackCircuit_RadioButton_ShortCircuit_OFF.UseVisualStyleBackColor = true;
            // 
            // TrackCircuit_Label_Title_TrackCircuit
            // 
            TrackCircuit_Label_Title_TrackCircuit.BackColor = System.Drawing.Color.FromArgb(76, 102, 102);
            TrackCircuit_Label_Title_TrackCircuit.Font = new System.Drawing.Font("BIZ UDゴシック", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 128);
            TrackCircuit_Label_Title_TrackCircuit.ForeColor = System.Drawing.Color.White;
            TrackCircuit_Label_Title_TrackCircuit.Location = new System.Drawing.Point(6, 15);
            TrackCircuit_Label_Title_TrackCircuit.Name = "TrackCircuit_Label_Title_TrackCircuit";
            TrackCircuit_Label_Title_TrackCircuit.Size = new System.Drawing.Size(85, 28);
            TrackCircuit_Label_Title_TrackCircuit.TabIndex = 11;
            TrackCircuit_Label_Title_TrackCircuit.Text = "軌道回路";
            TrackCircuit_Label_Title_TrackCircuit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TrackCircuit_Label_Title_TrainNumber
            // 
            TrackCircuit_Label_Title_TrainNumber.BackColor = System.Drawing.Color.FromArgb(76, 102, 102);
            TrackCircuit_Label_Title_TrainNumber.Font = new System.Drawing.Font("BIZ UDゴシック", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 128);
            TrackCircuit_Label_Title_TrainNumber.ForeColor = System.Drawing.Color.White;
            TrackCircuit_Label_Title_TrainNumber.Location = new System.Drawing.Point(6, 85);
            TrackCircuit_Label_Title_TrainNumber.Name = "TrackCircuit_Label_Title_TrainNumber";
            TrackCircuit_Label_Title_TrainNumber.Size = new System.Drawing.Size(85, 28);
            TrackCircuit_Label_Title_TrainNumber.TabIndex = 12;
            TrackCircuit_Label_Title_TrainNumber.Text = "列車番号";
            TrackCircuit_Label_Title_TrainNumber.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TrackCircuit_GroupBox_TrackCircuitSetting
            // 
            TrackCircuit_GroupBox_TrackCircuitSetting.Controls.Add(TrackCircuit_TextBox_TrackCircuit);
            TrackCircuit_GroupBox_TrackCircuitSetting.Controls.Add(TrackCircuit_GroupBox_Title_Loking);
            TrackCircuit_GroupBox_TrackCircuitSetting.Controls.Add(TrackCircuit_GroupBox_Title_ShortCircuit);
            TrackCircuit_GroupBox_TrackCircuitSetting.Controls.Add(TrackCircuit_Label_Title_TrackCircuit);
            TrackCircuit_GroupBox_TrackCircuitSetting.Controls.Add(TrackCircuit_Label_Title_TrainNumber);
            TrackCircuit_GroupBox_TrackCircuitSetting.Controls.Add(TrackCircuit_TextBox_TrainNumber);
            TrackCircuit_GroupBox_TrackCircuitSetting.Font = new System.Drawing.Font("BIZ UDゴシック", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 128);
            TrackCircuit_GroupBox_TrackCircuitSetting.ForeColor = System.Drawing.Color.White;
            TrackCircuit_GroupBox_TrackCircuitSetting.Location = new System.Drawing.Point(543, 392);
            TrackCircuit_GroupBox_TrackCircuitSetting.Name = "TrackCircuit_GroupBox_TrackCircuitSetting";
            TrackCircuit_GroupBox_TrackCircuitSetting.Size = new System.Drawing.Size(324, 277);
            TrackCircuit_GroupBox_TrackCircuitSetting.TabIndex = 15;
            TrackCircuit_GroupBox_TrackCircuitSetting.TabStop = false;
            TrackCircuit_GroupBox_TrackCircuitSetting.Text = "設定項目";
            // 
            // TrackCircuit_GroupBox_Title_Loking
            // 
            TrackCircuit_GroupBox_Title_Loking.Controls.Add(TrackCircuit_RadioButton_Locking_OFF);
            TrackCircuit_GroupBox_Title_Loking.Controls.Add(TrackCircuit_RadioButton_Locking_ON);
            TrackCircuit_GroupBox_Title_Loking.Font = new System.Drawing.Font("BIZ UDゴシック", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 128);
            TrackCircuit_GroupBox_Title_Loking.ForeColor = System.Drawing.Color.White;
            TrackCircuit_GroupBox_Title_Loking.Location = new System.Drawing.Point(6, 215);
            TrackCircuit_GroupBox_Title_Loking.Name = "TrackCircuit_GroupBox_Title_Loking";
            TrackCircuit_GroupBox_Title_Loking.Size = new System.Drawing.Size(311, 56);
            TrackCircuit_GroupBox_Title_Loking.TabIndex = 18;
            TrackCircuit_GroupBox_Title_Loking.TabStop = false;
            TrackCircuit_GroupBox_Title_Loking.Text = "鎖錠状態";
            // 
            // TrackCircuit_RadioButton_Locking_OFF
            // 
            TrackCircuit_RadioButton_Locking_OFF.AutoSize = true;
            TrackCircuit_RadioButton_Locking_OFF.Font = new System.Drawing.Font("BIZ UDゴシック", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 128);
            TrackCircuit_RadioButton_Locking_OFF.ForeColor = System.Drawing.Color.White;
            TrackCircuit_RadioButton_Locking_OFF.Location = new System.Drawing.Point(171, 22);
            TrackCircuit_RadioButton_Locking_OFF.Name = "TrackCircuit_RadioButton_Locking_OFF";
            TrackCircuit_RadioButton_Locking_OFF.Size = new System.Drawing.Size(70, 25);
            TrackCircuit_RadioButton_Locking_OFF.TabIndex = 6;
            TrackCircuit_RadioButton_Locking_OFF.TabStop = true;
            TrackCircuit_RadioButton_Locking_OFF.Text = "なし";
            TrackCircuit_RadioButton_Locking_OFF.UseVisualStyleBackColor = true;
            // 
            // TrackCircuit_RadioButton_Locking_ON
            // 
            TrackCircuit_RadioButton_Locking_ON.AutoSize = true;
            TrackCircuit_RadioButton_Locking_ON.Font = new System.Drawing.Font("BIZ UDゴシック", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 128);
            TrackCircuit_RadioButton_Locking_ON.ForeColor = System.Drawing.Color.White;
            TrackCircuit_RadioButton_Locking_ON.Location = new System.Drawing.Point(94, 22);
            TrackCircuit_RadioButton_Locking_ON.Name = "TrackCircuit_RadioButton_Locking_ON";
            TrackCircuit_RadioButton_Locking_ON.Size = new System.Drawing.Size(70, 25);
            TrackCircuit_RadioButton_Locking_ON.TabIndex = 5;
            TrackCircuit_RadioButton_Locking_ON.TabStop = true;
            TrackCircuit_RadioButton_Locking_ON.Text = "鎖錠";
            TrackCircuit_RadioButton_Locking_ON.UseVisualStyleBackColor = true;
            // 
            // TrackCircuit_GroupBox_Title_ShortCircuit
            // 
            TrackCircuit_GroupBox_Title_ShortCircuit.Controls.Add(TrackCircuit_RadioButton_ShortCircuit_OFF);
            TrackCircuit_GroupBox_Title_ShortCircuit.Controls.Add(TrackCircuit_RadioButton_ShortCircuit_ON);
            TrackCircuit_GroupBox_Title_ShortCircuit.Font = new System.Drawing.Font("BIZ UDゴシック", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 128);
            TrackCircuit_GroupBox_Title_ShortCircuit.ForeColor = System.Drawing.Color.White;
            TrackCircuit_GroupBox_Title_ShortCircuit.Location = new System.Drawing.Point(6, 155);
            TrackCircuit_GroupBox_Title_ShortCircuit.Name = "TrackCircuit_GroupBox_Title_ShortCircuit";
            TrackCircuit_GroupBox_Title_ShortCircuit.Size = new System.Drawing.Size(311, 56);
            TrackCircuit_GroupBox_Title_ShortCircuit.TabIndex = 17;
            TrackCircuit_GroupBox_Title_ShortCircuit.TabStop = false;
            TrackCircuit_GroupBox_Title_ShortCircuit.Text = "短絡状態";
            // 
            // TrackCircuit_CheckBox_TopMost
            // 
            TrackCircuit_CheckBox_TopMost.AutoSize = true;
            TrackCircuit_CheckBox_TopMost.Font = new System.Drawing.Font("BIZ UDゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 128);
            TrackCircuit_CheckBox_TopMost.ForeColor = System.Drawing.Color.White;
            TrackCircuit_CheckBox_TopMost.Location = new System.Drawing.Point(771, 12);
            TrackCircuit_CheckBox_TopMost.Name = "TrackCircuit_CheckBox_TopMost";
            TrackCircuit_CheckBox_TopMost.Size = new System.Drawing.Size(101, 19);
            TrackCircuit_CheckBox_TopMost.TabIndex = 16;
            TrackCircuit_CheckBox_TopMost.Text = "最前面表示";
            TrackCircuit_CheckBox_TopMost.UseVisualStyleBackColor = true;
            TrackCircuit_CheckBox_TopMost.CheckedChanged += TrackCircuit_CheckBox_TopMost_CheckedChanged;
            // 
            // TrackCircuit_GroupBox_DeleteNumberSetting
            // 
            TrackCircuit_GroupBox_DeleteNumberSetting.Controls.Add(TrackCircuit_Label_Title_DeleteTrainNumber);
            TrackCircuit_GroupBox_DeleteNumberSetting.Controls.Add(TrackCircuit_TextBox_DeleteTrainNumber);
            TrackCircuit_GroupBox_DeleteNumberSetting.Font = new System.Drawing.Font("BIZ UDゴシック", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 128);
            TrackCircuit_GroupBox_DeleteNumberSetting.ForeColor = System.Drawing.Color.White;
            TrackCircuit_GroupBox_DeleteNumberSetting.Location = new System.Drawing.Point(543, 223);
            TrackCircuit_GroupBox_DeleteNumberSetting.Name = "TrackCircuit_GroupBox_DeleteNumberSetting";
            TrackCircuit_GroupBox_DeleteNumberSetting.Size = new System.Drawing.Size(324, 88);
            TrackCircuit_GroupBox_DeleteNumberSetting.TabIndex = 17;
            TrackCircuit_GroupBox_DeleteNumberSetting.TabStop = false;
            TrackCircuit_GroupBox_DeleteNumberSetting.Text = "設定項目";
            // 
            // TrackCircuit_Label_Title_DeleteTrainNumber
            // 
            TrackCircuit_Label_Title_DeleteTrainNumber.BackColor = System.Drawing.Color.FromArgb(76, 102, 102);
            TrackCircuit_Label_Title_DeleteTrainNumber.Font = new System.Drawing.Font("BIZ UDゴシック", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 128);
            TrackCircuit_Label_Title_DeleteTrainNumber.ForeColor = System.Drawing.Color.White;
            TrackCircuit_Label_Title_DeleteTrainNumber.Location = new System.Drawing.Point(6, 15);
            TrackCircuit_Label_Title_DeleteTrainNumber.Name = "TrackCircuit_Label_Title_DeleteTrainNumber";
            TrackCircuit_Label_Title_DeleteTrainNumber.Size = new System.Drawing.Size(85, 28);
            TrackCircuit_Label_Title_DeleteTrainNumber.TabIndex = 12;
            TrackCircuit_Label_Title_DeleteTrainNumber.Text = "列車番号";
            TrackCircuit_Label_Title_DeleteTrainNumber.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TrackCircuit_TextBox_DeleteTrainNumber
            // 
            TrackCircuit_TextBox_DeleteTrainNumber.Font = new System.Drawing.Font("BIZ UDゴシック", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 128);
            TrackCircuit_TextBox_DeleteTrainNumber.Location = new System.Drawing.Point(46, 45);
            TrackCircuit_TextBox_DeleteTrainNumber.MaxLength = 6;
            TrackCircuit_TextBox_DeleteTrainNumber.Name = "TrackCircuit_TextBox_DeleteTrainNumber";
            TrackCircuit_TextBox_DeleteTrainNumber.Size = new System.Drawing.Size(265, 28);
            TrackCircuit_TextBox_DeleteTrainNumber.TabIndex = 4;
            TrackCircuit_TextBox_DeleteTrainNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // TrackCircuit_Button_DeleteTrainNumber
            // 
            TrackCircuit_Button_DeleteTrainNumber.BackColor = System.Drawing.Color.OrangeRed;
            TrackCircuit_Button_DeleteTrainNumber.FlatAppearance.BorderSize = 0;
            TrackCircuit_Button_DeleteTrainNumber.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            TrackCircuit_Button_DeleteTrainNumber.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            TrackCircuit_Button_DeleteTrainNumber.Font = new System.Drawing.Font("BIZ UDゴシック", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 128);
            TrackCircuit_Button_DeleteTrainNumber.ForeColor = System.Drawing.Color.White;
            TrackCircuit_Button_DeleteTrainNumber.Location = new System.Drawing.Point(625, 317);
            TrackCircuit_Button_DeleteTrainNumber.Name = "TrackCircuit_Button_DeleteTrainNumber";
            TrackCircuit_Button_DeleteTrainNumber.Size = new System.Drawing.Size(160, 40);
            TrackCircuit_Button_DeleteTrainNumber.TabIndex = 18;
            TrackCircuit_Button_DeleteTrainNumber.Text = "在線削除";
            TrackCircuit_Button_DeleteTrainNumber.UseVisualStyleBackColor = false;
            TrackCircuit_Button_DeleteTrainNumber.Click += TrackCircuit_Button_Click;
            // 
            // TrackCircuit_TextBox_TrackCircuit
            // 
            TrackCircuit_TextBox_TrackCircuit.Font = new System.Drawing.Font("BIZ UDゴシック", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 128);
            TrackCircuit_TextBox_TrackCircuit.Location = new System.Drawing.Point(46, 46);
            TrackCircuit_TextBox_TrackCircuit.MaxLength = 6;
            TrackCircuit_TextBox_TrackCircuit.Name = "TrackCircuit_TextBox_TrackCircuit";
            TrackCircuit_TextBox_TrackCircuit.Size = new System.Drawing.Size(265, 28);
            TrackCircuit_TextBox_TrackCircuit.TabIndex = 19;
            TrackCircuit_TextBox_TrackCircuit.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // TrackCircuitForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.FromArgb(76, 102, 102);
            ClientSize = new System.Drawing.Size(884, 729);
            Controls.Add(TrackCircuit_Button_DeleteTrainNumber);
            Controls.Add(TrackCircuit_GroupBox_DeleteNumberSetting);
            Controls.Add(TrackCircuit_CheckBox_TopMost);
            Controls.Add(TrackCircuit_GroupBox_TrackCircuitSetting);
            Controls.Add(TrackCircuit_Button_SendServer);
            Controls.Add(TrackCircuit_DataGridView_TrackCircuitData);
            Font = new System.Drawing.Font("Yu Gothic UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 128);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            MaximizeBox = false;
            Name = "TrackCircuitForm";
            Text = "任意軌道回路情報設定 | 司令卓 - ダイヤ運転会";
            ((System.ComponentModel.ISupportInitialize)TrackCircuit_DataGridView_TrackCircuitData).EndInit();
            ((System.ComponentModel.ISupportInitialize)TrackCircuit_BindingSource).EndInit();
            TrackCircuit_GroupBox_TrackCircuitSetting.ResumeLayout(false);
            TrackCircuit_GroupBox_TrackCircuitSetting.PerformLayout();
            TrackCircuit_GroupBox_Title_Loking.ResumeLayout(false);
            TrackCircuit_GroupBox_Title_Loking.PerformLayout();
            TrackCircuit_GroupBox_Title_ShortCircuit.ResumeLayout(false);
            TrackCircuit_GroupBox_Title_ShortCircuit.PerformLayout();
            TrackCircuit_GroupBox_DeleteNumberSetting.ResumeLayout(false);
            TrackCircuit_GroupBox_DeleteNumberSetting.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.DataGridView TrackCircuit_DataGridView_TrackCircuitData;
        private System.Windows.Forms.Button TrackCircuit_Button_SendServer;
        private System.Windows.Forms.TextBox TrackCircuit_TextBox_TrainNumber;
        private System.Windows.Forms.RadioButton TrackCircuit_RadioButton_ShortCircuit_ON;
        private System.Windows.Forms.RadioButton TrackCircuit_RadioButton_ShortCircuit_OFF;
        private System.Windows.Forms.Label TrackCircuit_Label_Title_TrackCircuit;
        private System.Windows.Forms.Label TrackCircuit_Label_Title_TrainNumber;
        private System.Windows.Forms.GroupBox TrackCircuit_GroupBox_TrackCircuitSetting;
        private System.Windows.Forms.CheckBox TrackCircuit_CheckBox_TopMost;
        private System.Windows.Forms.GroupBox TrackCircuit_GroupBox_Title_Loking;
        private System.Windows.Forms.RadioButton TrackCircuit_RadioButton_Locking_OFF;
        private System.Windows.Forms.RadioButton TrackCircuit_RadioButton_Locking_ON;
        private System.Windows.Forms.GroupBox TrackCircuit_GroupBox_Title_ShortCircuit;
        private System.Windows.Forms.BindingSource TrackCircuit_BindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn trackCircuit;
        private System.Windows.Forms.DataGridViewTextBoxColumn trainNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn shortCircuitStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn lockingStatus;
        private System.Windows.Forms.GroupBox TrackCircuit_GroupBox_DeleteNumberSetting;
        private System.Windows.Forms.Label TrackCircuit_Label_Title_DeleteTrainNumber;
        private System.Windows.Forms.TextBox TrackCircuit_TextBox_DeleteTrainNumber;
        private System.Windows.Forms.Button TrackCircuit_Button_DeleteTrainNumber;
        private System.Windows.Forms.TextBox TrackCircuit_TextBox_TrackCircuit;
    }
}