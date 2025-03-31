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
            TrackCircuit_BindingSource = new System.Windows.Forms.BindingSource(components);
            TrackCircuit_Button_SendServer = new System.Windows.Forms.Button();
            TrackCircuit_TextBox_TrainNumber = new System.Windows.Forms.TextBox();
            TrackCircuit_RadioButton_ShortCircuit_ON = new System.Windows.Forms.RadioButton();
            TrackCircuit_RadioButton_ShortCircuit_OFF = new System.Windows.Forms.RadioButton();
            TrackCircuit_Label_Title_TrackCircuit = new System.Windows.Forms.Label();
            TrackCircuit_Label_Title_TrainNumber = new System.Windows.Forms.Label();
            TrackCircuit_GroupBox_TrackCircuitSetting = new System.Windows.Forms.GroupBox();
            TrackCircuit_TextBox_TrackCircuit = new System.Windows.Forms.TextBox();
            TrackCircuit_GroupBox_Title_Loking = new System.Windows.Forms.GroupBox();
            TrackCircuit_RadioButton_Locking_OFF = new System.Windows.Forms.RadioButton();
            TrackCircuit_RadioButton_Locking_ON = new System.Windows.Forms.RadioButton();
            TrackCircuit_GroupBox_Title_ShortCircuit = new System.Windows.Forms.GroupBox();
            TrackCircuit_CheckBox_TopMost = new System.Windows.Forms.CheckBox();
            TrackCircuit_Button_DeleteTrainNumber = new System.Windows.Forms.Button();
            TrackCircuit_TextBox_DeleteTrainNumber = new System.Windows.Forms.TextBox();
            TrackCircuit_Label_Title_DeleteTrainNumber = new System.Windows.Forms.Label();
            TrackCircuit_GroupBox_DeleteNumberSetting = new System.Windows.Forms.GroupBox();
            TrackCircuit_GroupBox_Filter = new System.Windows.Forms.GroupBox();
            TrackCircuit_GroupBox_Title_FilterLoking = new System.Windows.Forms.GroupBox();
            TrackCircuit_RadioButton_FilterLocking_All = new System.Windows.Forms.RadioButton();
            TrackCircuit_RadioButton_FilterLocking_Other = new System.Windows.Forms.RadioButton();
            TrackCircuit_RadioButton_FilterLocking_Only = new System.Windows.Forms.RadioButton();
            TrackCircuit_GroupBox_Title_FilterShortCircuit = new System.Windows.Forms.GroupBox();
            TrackCircuit_RadioButton_FilterShortCircuit_All = new System.Windows.Forms.RadioButton();
            TrackCircuit_RadioButton_FilterShortCircuit_Other = new System.Windows.Forms.RadioButton();
            TrackCircuit_RadioButton_FilterShortCircuit_Only = new System.Windows.Forms.RadioButton();
            TrackCircuit_TextBox_FilterTrainNumber = new System.Windows.Forms.TextBox();
            TrackCircuit_Label_Title_FilterTrainNumber = new System.Windows.Forms.Label();
            TrackCircuit_Label_Title_FilterTrackCircuit = new System.Windows.Forms.Label();
            TrackCircuit_TextBox_FilterTrackCircuit = new System.Windows.Forms.TextBox();
            trackCircuit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            trainNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            shortCircuitStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            lockingStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)TrackCircuit_DataGridView_TrackCircuitData).BeginInit();
            ((System.ComponentModel.ISupportInitialize)TrackCircuit_BindingSource).BeginInit();
            TrackCircuit_GroupBox_TrackCircuitSetting.SuspendLayout();
            TrackCircuit_GroupBox_Title_Loking.SuspendLayout();
            TrackCircuit_GroupBox_Title_ShortCircuit.SuspendLayout();
            TrackCircuit_GroupBox_DeleteNumberSetting.SuspendLayout();
            TrackCircuit_GroupBox_Filter.SuspendLayout();
            TrackCircuit_GroupBox_Title_FilterLoking.SuspendLayout();
            TrackCircuit_GroupBox_Title_FilterShortCircuit.SuspendLayout();
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
            // 
            // TrackCircuit_Button_SendServer
            // 
            TrackCircuit_Button_SendServer.BackColor = System.Drawing.Color.Lime;
            TrackCircuit_Button_SendServer.FlatAppearance.BorderSize = 0;
            TrackCircuit_Button_SendServer.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            TrackCircuit_Button_SendServer.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            TrackCircuit_Button_SendServer.Font = new System.Drawing.Font("BIZ UDゴシック", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 128);
            TrackCircuit_Button_SendServer.ForeColor = System.Drawing.SystemColors.ControlText;
            TrackCircuit_Button_SendServer.Location = new System.Drawing.Point(82, 207);
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
            TrackCircuit_TextBox_TrainNumber.Location = new System.Drawing.Point(91, 49);
            TrackCircuit_TextBox_TrainNumber.MaxLength = 7;
            TrackCircuit_TextBox_TrainNumber.Name = "TrackCircuit_TextBox_TrainNumber";
            TrackCircuit_TextBox_TrainNumber.Size = new System.Drawing.Size(220, 28);
            TrackCircuit_TextBox_TrainNumber.TabIndex = 4;
            TrackCircuit_TextBox_TrainNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // TrackCircuit_RadioButton_ShortCircuit_ON
            // 
            TrackCircuit_RadioButton_ShortCircuit_ON.AutoSize = true;
            TrackCircuit_RadioButton_ShortCircuit_ON.Font = new System.Drawing.Font("BIZ UDゴシック", 12F);
            TrackCircuit_RadioButton_ShortCircuit_ON.ForeColor = System.Drawing.Color.White;
            TrackCircuit_RadioButton_ShortCircuit_ON.Location = new System.Drawing.Point(95, 22);
            TrackCircuit_RadioButton_ShortCircuit_ON.Name = "TrackCircuit_RadioButton_ShortCircuit_ON";
            TrackCircuit_RadioButton_ShortCircuit_ON.Size = new System.Drawing.Size(57, 20);
            TrackCircuit_RadioButton_ShortCircuit_ON.TabIndex = 5;
            TrackCircuit_RadioButton_ShortCircuit_ON.TabStop = true;
            TrackCircuit_RadioButton_ShortCircuit_ON.Text = "短絡";
            TrackCircuit_RadioButton_ShortCircuit_ON.UseVisualStyleBackColor = true;
            // 
            // TrackCircuit_RadioButton_ShortCircuit_OFF
            // 
            TrackCircuit_RadioButton_ShortCircuit_OFF.AutoSize = true;
            TrackCircuit_RadioButton_ShortCircuit_OFF.Font = new System.Drawing.Font("BIZ UDゴシック", 12F);
            TrackCircuit_RadioButton_ShortCircuit_OFF.ForeColor = System.Drawing.Color.White;
            TrackCircuit_RadioButton_ShortCircuit_OFF.Location = new System.Drawing.Point(171, 22);
            TrackCircuit_RadioButton_ShortCircuit_OFF.Name = "TrackCircuit_RadioButton_ShortCircuit_OFF";
            TrackCircuit_RadioButton_ShortCircuit_OFF.Size = new System.Drawing.Size(57, 20);
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
            TrackCircuit_Label_Title_TrainNumber.Location = new System.Drawing.Point(6, 49);
            TrackCircuit_Label_Title_TrainNumber.Name = "TrackCircuit_Label_Title_TrainNumber";
            TrackCircuit_Label_Title_TrainNumber.Size = new System.Drawing.Size(85, 28);
            TrackCircuit_Label_Title_TrainNumber.TabIndex = 12;
            TrackCircuit_Label_Title_TrainNumber.Text = "列車番号";
            TrackCircuit_Label_Title_TrainNumber.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TrackCircuit_GroupBox_TrackCircuitSetting
            // 
            TrackCircuit_GroupBox_TrackCircuitSetting.Controls.Add(TrackCircuit_Button_SendServer);
            TrackCircuit_GroupBox_TrackCircuitSetting.Controls.Add(TrackCircuit_TextBox_TrackCircuit);
            TrackCircuit_GroupBox_TrackCircuitSetting.Controls.Add(TrackCircuit_GroupBox_Title_Loking);
            TrackCircuit_GroupBox_TrackCircuitSetting.Controls.Add(TrackCircuit_GroupBox_Title_ShortCircuit);
            TrackCircuit_GroupBox_TrackCircuitSetting.Controls.Add(TrackCircuit_Label_Title_TrackCircuit);
            TrackCircuit_GroupBox_TrackCircuitSetting.Controls.Add(TrackCircuit_Label_Title_TrainNumber);
            TrackCircuit_GroupBox_TrackCircuitSetting.Controls.Add(TrackCircuit_TextBox_TrainNumber);
            TrackCircuit_GroupBox_TrackCircuitSetting.Font = new System.Drawing.Font("BIZ UDゴシック", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 128);
            TrackCircuit_GroupBox_TrackCircuitSetting.ForeColor = System.Drawing.Color.White;
            TrackCircuit_GroupBox_TrackCircuitSetting.Location = new System.Drawing.Point(543, 459);
            TrackCircuit_GroupBox_TrackCircuitSetting.Name = "TrackCircuit_GroupBox_TrackCircuitSetting";
            TrackCircuit_GroupBox_TrackCircuitSetting.Size = new System.Drawing.Size(324, 258);
            TrackCircuit_GroupBox_TrackCircuitSetting.TabIndex = 15;
            TrackCircuit_GroupBox_TrackCircuitSetting.TabStop = false;
            TrackCircuit_GroupBox_TrackCircuitSetting.Text = "軌道回路設定";
            // 
            // TrackCircuit_TextBox_TrackCircuit
            // 
            TrackCircuit_TextBox_TrackCircuit.Font = new System.Drawing.Font("BIZ UDゴシック", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 128);
            TrackCircuit_TextBox_TrackCircuit.Location = new System.Drawing.Point(91, 15);
            TrackCircuit_TextBox_TrackCircuit.MaxLength = 10;
            TrackCircuit_TextBox_TrackCircuit.Name = "TrackCircuit_TextBox_TrackCircuit";
            TrackCircuit_TextBox_TrackCircuit.Size = new System.Drawing.Size(220, 28);
            TrackCircuit_TextBox_TrackCircuit.TabIndex = 19;
            TrackCircuit_TextBox_TrackCircuit.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // TrackCircuit_GroupBox_Title_Loking
            // 
            TrackCircuit_GroupBox_Title_Loking.Controls.Add(TrackCircuit_RadioButton_Locking_OFF);
            TrackCircuit_GroupBox_Title_Loking.Controls.Add(TrackCircuit_RadioButton_Locking_ON);
            TrackCircuit_GroupBox_Title_Loking.Font = new System.Drawing.Font("BIZ UDゴシック", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 128);
            TrackCircuit_GroupBox_Title_Loking.ForeColor = System.Drawing.Color.White;
            TrackCircuit_GroupBox_Title_Loking.Location = new System.Drawing.Point(6, 145);
            TrackCircuit_GroupBox_Title_Loking.Name = "TrackCircuit_GroupBox_Title_Loking";
            TrackCircuit_GroupBox_Title_Loking.Size = new System.Drawing.Size(311, 56);
            TrackCircuit_GroupBox_Title_Loking.TabIndex = 18;
            TrackCircuit_GroupBox_Title_Loking.TabStop = false;
            TrackCircuit_GroupBox_Title_Loking.Text = "鎖錠状態";
            // 
            // TrackCircuit_RadioButton_Locking_OFF
            // 
            TrackCircuit_RadioButton_Locking_OFF.AutoSize = true;
            TrackCircuit_RadioButton_Locking_OFF.Font = new System.Drawing.Font("BIZ UDゴシック", 12F);
            TrackCircuit_RadioButton_Locking_OFF.ForeColor = System.Drawing.Color.White;
            TrackCircuit_RadioButton_Locking_OFF.Location = new System.Drawing.Point(171, 22);
            TrackCircuit_RadioButton_Locking_OFF.Name = "TrackCircuit_RadioButton_Locking_OFF";
            TrackCircuit_RadioButton_Locking_OFF.Size = new System.Drawing.Size(57, 20);
            TrackCircuit_RadioButton_Locking_OFF.TabIndex = 6;
            TrackCircuit_RadioButton_Locking_OFF.TabStop = true;
            TrackCircuit_RadioButton_Locking_OFF.Text = "なし";
            TrackCircuit_RadioButton_Locking_OFF.UseVisualStyleBackColor = true;
            // 
            // TrackCircuit_RadioButton_Locking_ON
            // 
            TrackCircuit_RadioButton_Locking_ON.AutoSize = true;
            TrackCircuit_RadioButton_Locking_ON.Font = new System.Drawing.Font("BIZ UDゴシック", 12F);
            TrackCircuit_RadioButton_Locking_ON.ForeColor = System.Drawing.Color.White;
            TrackCircuit_RadioButton_Locking_ON.Location = new System.Drawing.Point(94, 22);
            TrackCircuit_RadioButton_Locking_ON.Name = "TrackCircuit_RadioButton_Locking_ON";
            TrackCircuit_RadioButton_Locking_ON.Size = new System.Drawing.Size(57, 20);
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
            TrackCircuit_GroupBox_Title_ShortCircuit.Location = new System.Drawing.Point(7, 83);
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
            // TrackCircuit_Button_DeleteTrainNumber
            // 
            TrackCircuit_Button_DeleteTrainNumber.BackColor = System.Drawing.Color.OrangeRed;
            TrackCircuit_Button_DeleteTrainNumber.FlatAppearance.BorderSize = 0;
            TrackCircuit_Button_DeleteTrainNumber.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            TrackCircuit_Button_DeleteTrainNumber.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            TrackCircuit_Button_DeleteTrainNumber.Font = new System.Drawing.Font("BIZ UDゴシック", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 128);
            TrackCircuit_Button_DeleteTrainNumber.ForeColor = System.Drawing.Color.White;
            TrackCircuit_Button_DeleteTrainNumber.Location = new System.Drawing.Point(82, 49);
            TrackCircuit_Button_DeleteTrainNumber.Name = "TrackCircuit_Button_DeleteTrainNumber";
            TrackCircuit_Button_DeleteTrainNumber.Size = new System.Drawing.Size(160, 40);
            TrackCircuit_Button_DeleteTrainNumber.TabIndex = 18;
            TrackCircuit_Button_DeleteTrainNumber.Text = "在線削除";
            TrackCircuit_Button_DeleteTrainNumber.UseVisualStyleBackColor = false;
            TrackCircuit_Button_DeleteTrainNumber.Click += TrackCircuit_Button_Click;
            // 
            // TrackCircuit_TextBox_DeleteTrainNumber
            // 
            TrackCircuit_TextBox_DeleteTrainNumber.Font = new System.Drawing.Font("BIZ UDゴシック", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 128);
            TrackCircuit_TextBox_DeleteTrainNumber.Location = new System.Drawing.Point(91, 15);
            TrackCircuit_TextBox_DeleteTrainNumber.MaxLength = 7;
            TrackCircuit_TextBox_DeleteTrainNumber.Name = "TrackCircuit_TextBox_DeleteTrainNumber";
            TrackCircuit_TextBox_DeleteTrainNumber.Size = new System.Drawing.Size(220, 28);
            TrackCircuit_TextBox_DeleteTrainNumber.TabIndex = 4;
            TrackCircuit_TextBox_DeleteTrainNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
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
            // TrackCircuit_GroupBox_DeleteNumberSetting
            // 
            TrackCircuit_GroupBox_DeleteNumberSetting.Controls.Add(TrackCircuit_Label_Title_DeleteTrainNumber);
            TrackCircuit_GroupBox_DeleteNumberSetting.Controls.Add(TrackCircuit_Button_DeleteTrainNumber);
            TrackCircuit_GroupBox_DeleteNumberSetting.Controls.Add(TrackCircuit_TextBox_DeleteTrainNumber);
            TrackCircuit_GroupBox_DeleteNumberSetting.Font = new System.Drawing.Font("BIZ UDゴシック", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 128);
            TrackCircuit_GroupBox_DeleteNumberSetting.ForeColor = System.Drawing.Color.White;
            TrackCircuit_GroupBox_DeleteNumberSetting.Location = new System.Drawing.Point(543, 335);
            TrackCircuit_GroupBox_DeleteNumberSetting.Name = "TrackCircuit_GroupBox_DeleteNumberSetting";
            TrackCircuit_GroupBox_DeleteNumberSetting.Size = new System.Drawing.Size(324, 101);
            TrackCircuit_GroupBox_DeleteNumberSetting.TabIndex = 17;
            TrackCircuit_GroupBox_DeleteNumberSetting.TabStop = false;
            TrackCircuit_GroupBox_DeleteNumberSetting.Text = "在線削除設定";
            // 
            // TrackCircuit_GroupBox_Filter
            // 
            TrackCircuit_GroupBox_Filter.Controls.Add(TrackCircuit_GroupBox_Title_FilterLoking);
            TrackCircuit_GroupBox_Filter.Controls.Add(TrackCircuit_GroupBox_Title_FilterShortCircuit);
            TrackCircuit_GroupBox_Filter.Controls.Add(TrackCircuit_TextBox_FilterTrainNumber);
            TrackCircuit_GroupBox_Filter.Controls.Add(TrackCircuit_Label_Title_FilterTrainNumber);
            TrackCircuit_GroupBox_Filter.Controls.Add(TrackCircuit_Label_Title_FilterTrackCircuit);
            TrackCircuit_GroupBox_Filter.Controls.Add(TrackCircuit_TextBox_FilterTrackCircuit);
            TrackCircuit_GroupBox_Filter.Font = new System.Drawing.Font("BIZ UDゴシック", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 128);
            TrackCircuit_GroupBox_Filter.ForeColor = System.Drawing.Color.White;
            TrackCircuit_GroupBox_Filter.Location = new System.Drawing.Point(543, 50);
            TrackCircuit_GroupBox_Filter.Name = "TrackCircuit_GroupBox_Filter";
            TrackCircuit_GroupBox_Filter.Size = new System.Drawing.Size(324, 209);
            TrackCircuit_GroupBox_Filter.TabIndex = 19;
            TrackCircuit_GroupBox_Filter.TabStop = false;
            TrackCircuit_GroupBox_Filter.Text = "項目絞り込み設定";
            // 
            // TrackCircuit_GroupBox_Title_FilterLoking
            // 
            TrackCircuit_GroupBox_Title_FilterLoking.Controls.Add(TrackCircuit_RadioButton_FilterLocking_All);
            TrackCircuit_GroupBox_Title_FilterLoking.Controls.Add(TrackCircuit_RadioButton_FilterLocking_Other);
            TrackCircuit_GroupBox_Title_FilterLoking.Controls.Add(TrackCircuit_RadioButton_FilterLocking_Only);
            TrackCircuit_GroupBox_Title_FilterLoking.Font = new System.Drawing.Font("BIZ UDゴシック", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 128);
            TrackCircuit_GroupBox_Title_FilterLoking.ForeColor = System.Drawing.Color.White;
            TrackCircuit_GroupBox_Title_FilterLoking.Location = new System.Drawing.Point(7, 145);
            TrackCircuit_GroupBox_Title_FilterLoking.Name = "TrackCircuit_GroupBox_Title_FilterLoking";
            TrackCircuit_GroupBox_Title_FilterLoking.Size = new System.Drawing.Size(311, 56);
            TrackCircuit_GroupBox_Title_FilterLoking.TabIndex = 22;
            TrackCircuit_GroupBox_Title_FilterLoking.TabStop = false;
            TrackCircuit_GroupBox_Title_FilterLoking.Text = "鎖錠状態";
            // 
            // TrackCircuit_RadioButton_FilterLocking_All
            // 
            TrackCircuit_RadioButton_FilterLocking_All.AutoSize = true;
            TrackCircuit_RadioButton_FilterLocking_All.Checked = true;
            TrackCircuit_RadioButton_FilterLocking_All.Font = new System.Drawing.Font("BIZ UDゴシック", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 128);
            TrackCircuit_RadioButton_FilterLocking_All.ForeColor = System.Drawing.Color.White;
            TrackCircuit_RadioButton_FilterLocking_All.Location = new System.Drawing.Point(43, 22);
            TrackCircuit_RadioButton_FilterLocking_All.Name = "TrackCircuit_RadioButton_FilterLocking_All";
            TrackCircuit_RadioButton_FilterLocking_All.Size = new System.Drawing.Size(57, 20);
            TrackCircuit_RadioButton_FilterLocking_All.TabIndex = 8;
            TrackCircuit_RadioButton_FilterLocking_All.TabStop = true;
            TrackCircuit_RadioButton_FilterLocking_All.Text = "全て";
            TrackCircuit_RadioButton_FilterLocking_All.UseVisualStyleBackColor = true;
            // 
            // TrackCircuit_RadioButton_FilterLocking_Other
            // 
            TrackCircuit_RadioButton_FilterLocking_Other.AutoSize = true;
            TrackCircuit_RadioButton_FilterLocking_Other.Font = new System.Drawing.Font("BIZ UDゴシック", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 128);
            TrackCircuit_RadioButton_FilterLocking_Other.ForeColor = System.Drawing.Color.White;
            TrackCircuit_RadioButton_FilterLocking_Other.Location = new System.Drawing.Point(201, 22);
            TrackCircuit_RadioButton_FilterLocking_Other.Name = "TrackCircuit_RadioButton_FilterLocking_Other";
            TrackCircuit_RadioButton_FilterLocking_Other.Size = new System.Drawing.Size(89, 20);
            TrackCircuit_RadioButton_FilterLocking_Other.TabIndex = 6;
            TrackCircuit_RadioButton_FilterLocking_Other.Text = "鎖錠以外";
            TrackCircuit_RadioButton_FilterLocking_Other.UseVisualStyleBackColor = true;
            // 
            // TrackCircuit_RadioButton_FilterLocking_Only
            // 
            TrackCircuit_RadioButton_FilterLocking_Only.AutoSize = true;
            TrackCircuit_RadioButton_FilterLocking_Only.Font = new System.Drawing.Font("BIZ UDゴシック", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 128);
            TrackCircuit_RadioButton_FilterLocking_Only.ForeColor = System.Drawing.Color.White;
            TrackCircuit_RadioButton_FilterLocking_Only.Location = new System.Drawing.Point(106, 22);
            TrackCircuit_RadioButton_FilterLocking_Only.Name = "TrackCircuit_RadioButton_FilterLocking_Only";
            TrackCircuit_RadioButton_FilterLocking_Only.Size = new System.Drawing.Size(89, 20);
            TrackCircuit_RadioButton_FilterLocking_Only.TabIndex = 5;
            TrackCircuit_RadioButton_FilterLocking_Only.Text = "鎖錠のみ";
            TrackCircuit_RadioButton_FilterLocking_Only.UseVisualStyleBackColor = true;
            // 
            // TrackCircuit_GroupBox_Title_FilterShortCircuit
            // 
            TrackCircuit_GroupBox_Title_FilterShortCircuit.Controls.Add(TrackCircuit_RadioButton_FilterShortCircuit_All);
            TrackCircuit_GroupBox_Title_FilterShortCircuit.Controls.Add(TrackCircuit_RadioButton_FilterShortCircuit_Other);
            TrackCircuit_GroupBox_Title_FilterShortCircuit.Controls.Add(TrackCircuit_RadioButton_FilterShortCircuit_Only);
            TrackCircuit_GroupBox_Title_FilterShortCircuit.Font = new System.Drawing.Font("BIZ UDゴシック", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 128);
            TrackCircuit_GroupBox_Title_FilterShortCircuit.ForeColor = System.Drawing.Color.White;
            TrackCircuit_GroupBox_Title_FilterShortCircuit.Location = new System.Drawing.Point(7, 83);
            TrackCircuit_GroupBox_Title_FilterShortCircuit.Name = "TrackCircuit_GroupBox_Title_FilterShortCircuit";
            TrackCircuit_GroupBox_Title_FilterShortCircuit.Size = new System.Drawing.Size(311, 56);
            TrackCircuit_GroupBox_Title_FilterShortCircuit.TabIndex = 21;
            TrackCircuit_GroupBox_Title_FilterShortCircuit.TabStop = false;
            TrackCircuit_GroupBox_Title_FilterShortCircuit.Text = "短絡状態";
            // 
            // TrackCircuit_RadioButton_FilterShortCircuit_All
            // 
            TrackCircuit_RadioButton_FilterShortCircuit_All.AutoSize = true;
            TrackCircuit_RadioButton_FilterShortCircuit_All.Checked = true;
            TrackCircuit_RadioButton_FilterShortCircuit_All.Font = new System.Drawing.Font("BIZ UDゴシック", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 128);
            TrackCircuit_RadioButton_FilterShortCircuit_All.ForeColor = System.Drawing.Color.White;
            TrackCircuit_RadioButton_FilterShortCircuit_All.Location = new System.Drawing.Point(43, 22);
            TrackCircuit_RadioButton_FilterShortCircuit_All.Name = "TrackCircuit_RadioButton_FilterShortCircuit_All";
            TrackCircuit_RadioButton_FilterShortCircuit_All.Size = new System.Drawing.Size(57, 20);
            TrackCircuit_RadioButton_FilterShortCircuit_All.TabIndex = 7;
            TrackCircuit_RadioButton_FilterShortCircuit_All.TabStop = true;
            TrackCircuit_RadioButton_FilterShortCircuit_All.Text = "全て";
            TrackCircuit_RadioButton_FilterShortCircuit_All.UseVisualStyleBackColor = true;
            // 
            // TrackCircuit_RadioButton_FilterShortCircuit_Other
            // 
            TrackCircuit_RadioButton_FilterShortCircuit_Other.AutoSize = true;
            TrackCircuit_RadioButton_FilterShortCircuit_Other.Font = new System.Drawing.Font("BIZ UDゴシック", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 128);
            TrackCircuit_RadioButton_FilterShortCircuit_Other.ForeColor = System.Drawing.Color.White;
            TrackCircuit_RadioButton_FilterShortCircuit_Other.Location = new System.Drawing.Point(201, 22);
            TrackCircuit_RadioButton_FilterShortCircuit_Other.Name = "TrackCircuit_RadioButton_FilterShortCircuit_Other";
            TrackCircuit_RadioButton_FilterShortCircuit_Other.Size = new System.Drawing.Size(89, 20);
            TrackCircuit_RadioButton_FilterShortCircuit_Other.TabIndex = 6;
            TrackCircuit_RadioButton_FilterShortCircuit_Other.Text = "短絡以外";
            TrackCircuit_RadioButton_FilterShortCircuit_Other.UseVisualStyleBackColor = true;
            // 
            // TrackCircuit_RadioButton_FilterShortCircuit_Only
            // 
            TrackCircuit_RadioButton_FilterShortCircuit_Only.AutoSize = true;
            TrackCircuit_RadioButton_FilterShortCircuit_Only.Font = new System.Drawing.Font("BIZ UDゴシック", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 128);
            TrackCircuit_RadioButton_FilterShortCircuit_Only.ForeColor = System.Drawing.Color.White;
            TrackCircuit_RadioButton_FilterShortCircuit_Only.Location = new System.Drawing.Point(106, 22);
            TrackCircuit_RadioButton_FilterShortCircuit_Only.Name = "TrackCircuit_RadioButton_FilterShortCircuit_Only";
            TrackCircuit_RadioButton_FilterShortCircuit_Only.Size = new System.Drawing.Size(89, 20);
            TrackCircuit_RadioButton_FilterShortCircuit_Only.TabIndex = 5;
            TrackCircuit_RadioButton_FilterShortCircuit_Only.Text = "短絡のみ";
            TrackCircuit_RadioButton_FilterShortCircuit_Only.UseVisualStyleBackColor = true;
            // 
            // TrackCircuit_TextBox_FilterTrainNumber
            // 
            TrackCircuit_TextBox_FilterTrainNumber.Font = new System.Drawing.Font("BIZ UDゴシック", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 128);
            TrackCircuit_TextBox_FilterTrainNumber.Location = new System.Drawing.Point(91, 49);
            TrackCircuit_TextBox_FilterTrainNumber.MaxLength = 7;
            TrackCircuit_TextBox_FilterTrainNumber.Name = "TrackCircuit_TextBox_FilterTrainNumber";
            TrackCircuit_TextBox_FilterTrainNumber.Size = new System.Drawing.Size(220, 28);
            TrackCircuit_TextBox_FilterTrainNumber.TabIndex = 14;
            TrackCircuit_TextBox_FilterTrainNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // TrackCircuit_Label_Title_FilterTrainNumber
            // 
            TrackCircuit_Label_Title_FilterTrainNumber.BackColor = System.Drawing.Color.FromArgb(76, 102, 102);
            TrackCircuit_Label_Title_FilterTrainNumber.Font = new System.Drawing.Font("BIZ UDゴシック", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 128);
            TrackCircuit_Label_Title_FilterTrainNumber.ForeColor = System.Drawing.Color.White;
            TrackCircuit_Label_Title_FilterTrainNumber.Location = new System.Drawing.Point(6, 49);
            TrackCircuit_Label_Title_FilterTrainNumber.Name = "TrackCircuit_Label_Title_FilterTrainNumber";
            TrackCircuit_Label_Title_FilterTrainNumber.Size = new System.Drawing.Size(85, 28);
            TrackCircuit_Label_Title_FilterTrainNumber.TabIndex = 13;
            TrackCircuit_Label_Title_FilterTrainNumber.Text = "列車番号";
            TrackCircuit_Label_Title_FilterTrainNumber.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TrackCircuit_Label_Title_FilterTrackCircuit
            // 
            TrackCircuit_Label_Title_FilterTrackCircuit.BackColor = System.Drawing.Color.FromArgb(76, 102, 102);
            TrackCircuit_Label_Title_FilterTrackCircuit.Font = new System.Drawing.Font("BIZ UDゴシック", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 128);
            TrackCircuit_Label_Title_FilterTrackCircuit.ForeColor = System.Drawing.Color.White;
            TrackCircuit_Label_Title_FilterTrackCircuit.Location = new System.Drawing.Point(6, 15);
            TrackCircuit_Label_Title_FilterTrackCircuit.Name = "TrackCircuit_Label_Title_FilterTrackCircuit";
            TrackCircuit_Label_Title_FilterTrackCircuit.Size = new System.Drawing.Size(85, 28);
            TrackCircuit_Label_Title_FilterTrackCircuit.TabIndex = 12;
            TrackCircuit_Label_Title_FilterTrackCircuit.Text = "軌道回路";
            TrackCircuit_Label_Title_FilterTrackCircuit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TrackCircuit_TextBox_FilterTrackCircuit
            // 
            TrackCircuit_TextBox_FilterTrackCircuit.Font = new System.Drawing.Font("BIZ UDゴシック", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 128);
            TrackCircuit_TextBox_FilterTrackCircuit.Location = new System.Drawing.Point(91, 15);
            TrackCircuit_TextBox_FilterTrackCircuit.MaxLength = 10;
            TrackCircuit_TextBox_FilterTrackCircuit.Name = "TrackCircuit_TextBox_FilterTrackCircuit";
            TrackCircuit_TextBox_FilterTrackCircuit.Size = new System.Drawing.Size(220, 28);
            TrackCircuit_TextBox_FilterTrackCircuit.TabIndex = 4;
            TrackCircuit_TextBox_FilterTrackCircuit.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
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
            trainNumber.MaxInputLength = 7;
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
            // TrackCircuitForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.FromArgb(76, 102, 102);
            ClientSize = new System.Drawing.Size(884, 729);
            Controls.Add(TrackCircuit_GroupBox_Filter);
            Controls.Add(TrackCircuit_GroupBox_DeleteNumberSetting);
            Controls.Add(TrackCircuit_CheckBox_TopMost);
            Controls.Add(TrackCircuit_GroupBox_TrackCircuitSetting);
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
            TrackCircuit_GroupBox_Filter.ResumeLayout(false);
            TrackCircuit_GroupBox_Filter.PerformLayout();
            TrackCircuit_GroupBox_Title_FilterLoking.ResumeLayout(false);
            TrackCircuit_GroupBox_Title_FilterLoking.PerformLayout();
            TrackCircuit_GroupBox_Title_FilterShortCircuit.ResumeLayout(false);
            TrackCircuit_GroupBox_Title_FilterShortCircuit.PerformLayout();
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
        private System.Windows.Forms.Button TrackCircuit_Button_DeleteTrainNumber;
        private System.Windows.Forms.TextBox TrackCircuit_TextBox_TrackCircuit;
        private System.Windows.Forms.TextBox TrackCircuit_TextBox_DeleteTrainNumber;
        private System.Windows.Forms.Label TrackCircuit_Label_Title_DeleteTrainNumber;
        private System.Windows.Forms.GroupBox TrackCircuit_GroupBox_DeleteNumberSetting;
        private System.Windows.Forms.GroupBox TrackCircuit_GroupBox_Filter;
        private System.Windows.Forms.Label TrackCircuit_Label_Title_FilterTrackCircuit;
        private System.Windows.Forms.TextBox TrackCircuit_TextBox_FilterTrackCircuit;
        private System.Windows.Forms.TextBox TrackCircuit_TextBox_FilterTrainNumber;
        private System.Windows.Forms.Label TrackCircuit_Label_Title_FilterTrainNumber;
        private System.Windows.Forms.GroupBox TrackCircuit_GroupBox_Title_FilterShortCircuit;
        private System.Windows.Forms.RadioButton TrackCircuit_RadioButton_FilterShortCircuit_Other;
        private System.Windows.Forms.RadioButton TrackCircuit_RadioButton_FilterShortCircuit_Only;
        private System.Windows.Forms.GroupBox TrackCircuit_GroupBox_Title_FilterLoking;
        private System.Windows.Forms.RadioButton TrackCircuit_RadioButton_FilterLocking_Other;
        private System.Windows.Forms.RadioButton TrackCircuit_RadioButton_FilterLocking_Only;
        private System.Windows.Forms.RadioButton TrackCircuit_RadioButton_FilterLocking_All;
        private System.Windows.Forms.RadioButton TrackCircuit_RadioButton_FilterShortCircuit_All;
        private System.Windows.Forms.DataGridViewTextBoxColumn trackCircuit;
        private System.Windows.Forms.DataGridViewTextBoxColumn trainNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn shortCircuitStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn lockingStatus;
    }
}