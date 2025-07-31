namespace TatehamaCommanderTable
{
    partial class TrainInfoForm
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
            ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            TrainNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            DiaNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            FromStationID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ToStationID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            Delay = new System.Windows.Forms.DataGridViewTextBoxColumn();
            DriverID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            TrainInfo_DataGridView_TrainInfoData = new System.Windows.Forms.DataGridView();
            TrainInfo_BindingSource = new System.Windows.Forms.BindingSource(components);
            TrainInfo_CheckBox_TopMost = new System.Windows.Forms.CheckBox();
            TrainInfo_Button_Delete = new System.Windows.Forms.Button();
            TrainInfo_Button_Update = new System.Windows.Forms.Button();
            TrainInfo_Button_Add = new System.Windows.Forms.Button();
            TrainInfo_Label_ID = new System.Windows.Forms.Label();
            TrainInfo_NumericUpDown_ID = new System.Windows.Forms.NumericUpDown();
            TrainInfo_TextBox_TrainNumber = new System.Windows.Forms.TextBox();
            TrainInfo_Label_DiaNumber = new System.Windows.Forms.Label();
            TrainInfo_NumericUpDown_DiaNumber = new System.Windows.Forms.NumericUpDown();
            TrainInfo_TextBox_FromStationID = new System.Windows.Forms.TextBox();
            TrainInfo_Label_Title_TrainNumber = new System.Windows.Forms.Label();
            TrainInfo_Label_FromStationID = new System.Windows.Forms.Label();
            TrainInfo_TextBox_ToStationID = new System.Windows.Forms.TextBox();
            TrainInfo_Label_ToStationID = new System.Windows.Forms.Label();
            TrainInfo_Label_Delay = new System.Windows.Forms.Label();
            TrainInfo_NumericUpDown_Delay = new System.Windows.Forms.NumericUpDown();
            TrainInfo_Label_DriverID = new System.Windows.Forms.Label();
            TrainInfo_TextBox_DriverID = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)TrainInfo_DataGridView_TrainInfoData).BeginInit();
            ((System.ComponentModel.ISupportInitialize)TrainInfo_BindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)TrainInfo_NumericUpDown_ID).BeginInit();
            ((System.ComponentModel.ISupportInitialize)TrainInfo_NumericUpDown_DiaNumber).BeginInit();
            ((System.ComponentModel.ISupportInitialize)TrainInfo_NumericUpDown_Delay).BeginInit();
            SuspendLayout();
            // 
            // ID
            // 
            ID.DataPropertyName = "ID";
            ID.HeaderText = "ID";
            ID.MaxInputLength = 10;
            ID.Name = "ID";
            ID.ReadOnly = true;
            // 
            // TrainNumber
            // 
            TrainNumber.DataPropertyName = "TrainNumber";
            TrainNumber.HeaderText = "列車番号";
            TrainNumber.MaxInputLength = 10;
            TrainNumber.Name = "TrainNumber";
            TrainNumber.ReadOnly = true;
            // 
            // DiaNumber
            // 
            DiaNumber.DataPropertyName = "DiaNumber";
            DiaNumber.HeaderText = "ダイヤ番号";
            DiaNumber.MaxInputLength = 10;
            DiaNumber.Name = "DiaNumber";
            DiaNumber.ReadOnly = true;
            // 
            // FromStationID
            // 
            FromStationID.DataPropertyName = "FromStationID";
            FromStationID.HeaderText = "始発駅ID";
            FromStationID.MaxInputLength = 10;
            FromStationID.Name = "FromStationID";
            FromStationID.ReadOnly = true;
            // 
            // ToStationID
            // 
            ToStationID.DataPropertyName = "ToStationID";
            ToStationID.HeaderText = "行先駅ID";
            ToStationID.MaxInputLength = 10;
            ToStationID.Name = "ToStationID";
            ToStationID.ReadOnly = true;
            // 
            // Delay
            // 
            Delay.DataPropertyName = "Delay";
            Delay.HeaderText = "遅延";
            Delay.MaxInputLength = 10;
            Delay.Name = "Delay";
            Delay.ReadOnly = true;
            // 
            // DriverID
            // 
            DriverID.DataPropertyName = "DriverID";
            DriverID.HeaderText = "運転士ID";
            DriverID.MaxInputLength = 50;
            DriverID.Name = "DriverID";
            DriverID.ReadOnly = true;
            DriverID.Width = 240;
            // 
            // TrainInfo_DataGridView_TrainInfoData
            // 
            TrainInfo_DataGridView_TrainInfoData.AllowUserToAddRows = false;
            TrainInfo_DataGridView_TrainInfoData.AllowUserToDeleteRows = false;
            TrainInfo_DataGridView_TrainInfoData.AllowUserToResizeColumns = false;
            TrainInfo_DataGridView_TrainInfoData.AllowUserToResizeRows = false;
            TrainInfo_DataGridView_TrainInfoData.AutoGenerateColumns = false;
            TrainInfo_DataGridView_TrainInfoData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            TrainInfo_DataGridView_TrainInfoData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { ID, TrainNumber, DiaNumber, FromStationID, ToStationID, Delay, DriverID });
            TrainInfo_DataGridView_TrainInfoData.DataSource = TrainInfo_BindingSource;
            TrainInfo_DataGridView_TrainInfoData.Location = new System.Drawing.Point(12, 37);
            TrainInfo_DataGridView_TrainInfoData.Name = "TrainInfo_DataGridView_TrainInfoData";
            TrainInfo_DataGridView_TrainInfoData.RowHeadersVisible = false;
            TrainInfo_DataGridView_TrainInfoData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            TrainInfo_DataGridView_TrainInfoData.Size = new System.Drawing.Size(860, 360);
            TrainInfo_DataGridView_TrainInfoData.TabIndex = 19;
            // 
            // TrainInfo_CheckBox_TopMost
            // 
            TrainInfo_CheckBox_TopMost.AutoSize = true;
            TrainInfo_CheckBox_TopMost.Font = new System.Drawing.Font("BIZ UDゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 128);
            TrainInfo_CheckBox_TopMost.ForeColor = System.Drawing.Color.White;
            TrainInfo_CheckBox_TopMost.Location = new System.Drawing.Point(771, 12);
            TrainInfo_CheckBox_TopMost.Name = "TrainInfo_CheckBox_TopMost";
            TrainInfo_CheckBox_TopMost.Size = new System.Drawing.Size(101, 19);
            TrainInfo_CheckBox_TopMost.TabIndex = 20;
            TrainInfo_CheckBox_TopMost.Text = "最前面表示";
            TrainInfo_CheckBox_TopMost.UseVisualStyleBackColor = true;
            TrainInfo_CheckBox_TopMost.CheckedChanged += TrainInfo_CheckBox_TopMost_CheckedChanged;
            // 
            // TrainInfo_Button_Delete
            // 
            TrainInfo_Button_Delete.BackColor = System.Drawing.Color.OrangeRed;
            TrainInfo_Button_Delete.FlatAppearance.BorderSize = 0;
            TrainInfo_Button_Delete.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            TrainInfo_Button_Delete.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            TrainInfo_Button_Delete.Font = new System.Drawing.Font("BIZ UDゴシック", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 128);
            TrainInfo_Button_Delete.ForeColor = System.Drawing.Color.White;
            TrainInfo_Button_Delete.Location = new System.Drawing.Point(296, 498);
            TrainInfo_Button_Delete.Margin = new System.Windows.Forms.Padding(5);
            TrainInfo_Button_Delete.Name = "TrainInfo_Button_Delete";
            TrainInfo_Button_Delete.Size = new System.Drawing.Size(75, 40);
            TrainInfo_Button_Delete.TabIndex = 29;
            TrainInfo_Button_Delete.Text = "削除";
            TrainInfo_Button_Delete.UseVisualStyleBackColor = false;
            // 
            // TrainInfo_Button_Update
            // 
            TrainInfo_Button_Update.BackColor = System.Drawing.Color.Aqua;
            TrainInfo_Button_Update.FlatAppearance.BorderSize = 0;
            TrainInfo_Button_Update.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            TrainInfo_Button_Update.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            TrainInfo_Button_Update.Font = new System.Drawing.Font("BIZ UDゴシック", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 128);
            TrainInfo_Button_Update.ForeColor = System.Drawing.Color.Black;
            TrainInfo_Button_Update.Location = new System.Drawing.Point(516, 498);
            TrainInfo_Button_Update.Margin = new System.Windows.Forms.Padding(5);
            TrainInfo_Button_Update.Name = "TrainInfo_Button_Update";
            TrainInfo_Button_Update.Size = new System.Drawing.Size(75, 40);
            TrainInfo_Button_Update.TabIndex = 34;
            TrainInfo_Button_Update.Text = "更新";
            TrainInfo_Button_Update.UseVisualStyleBackColor = false;
            // 
            // TrainInfo_Button_Add
            // 
            TrainInfo_Button_Add.BackColor = System.Drawing.Color.Lime;
            TrainInfo_Button_Add.FlatAppearance.BorderSize = 0;
            TrainInfo_Button_Add.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            TrainInfo_Button_Add.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            TrainInfo_Button_Add.Font = new System.Drawing.Font("BIZ UDゴシック", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 128);
            TrainInfo_Button_Add.ForeColor = System.Drawing.Color.Black;
            TrainInfo_Button_Add.Location = new System.Drawing.Point(406, 498);
            TrainInfo_Button_Add.Margin = new System.Windows.Forms.Padding(5);
            TrainInfo_Button_Add.Name = "TrainInfo_Button_Add";
            TrainInfo_Button_Add.Size = new System.Drawing.Size(75, 40);
            TrainInfo_Button_Add.TabIndex = 33;
            TrainInfo_Button_Add.Text = "追加";
            TrainInfo_Button_Add.UseVisualStyleBackColor = false;
            // 
            // TrainInfo_Label_ID
            // 
            TrainInfo_Label_ID.BackColor = System.Drawing.Color.FromArgb(76, 102, 102);
            TrainInfo_Label_ID.Font = new System.Drawing.Font("BIZ UDゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 128);
            TrainInfo_Label_ID.ForeColor = System.Drawing.Color.White;
            TrainInfo_Label_ID.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            TrainInfo_Label_ID.Location = new System.Drawing.Point(12, 412);
            TrainInfo_Label_ID.Name = "TrainInfo_Label_ID";
            TrainInfo_Label_ID.Padding = new System.Windows.Forms.Padding(0, 5, 0, 5);
            TrainInfo_Label_ID.Size = new System.Drawing.Size(85, 31);
            TrainInfo_Label_ID.TabIndex = 36;
            TrainInfo_Label_ID.Text = "ID";
            TrainInfo_Label_ID.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TrainInfo_NumericUpDown_ID
            // 
            TrainInfo_NumericUpDown_ID.Font = new System.Drawing.Font("BIZ UDゴシック", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 128);
            TrainInfo_NumericUpDown_ID.Location = new System.Drawing.Point(12, 446);
            TrainInfo_NumericUpDown_ID.Name = "TrainInfo_NumericUpDown_ID";
            TrainInfo_NumericUpDown_ID.Size = new System.Drawing.Size(85, 34);
            TrainInfo_NumericUpDown_ID.TabIndex = 35;
            TrainInfo_NumericUpDown_ID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // TrainInfo_TextBox_TrainNumber
            // 
            TrainInfo_TextBox_TrainNumber.Font = new System.Drawing.Font("BIZ UDゴシック", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 128);
            TrainInfo_TextBox_TrainNumber.Location = new System.Drawing.Point(103, 446);
            TrainInfo_TextBox_TrainNumber.MaxLength = 7;
            TrainInfo_TextBox_TrainNumber.Name = "TrainInfo_TextBox_TrainNumber";
            TrainInfo_TextBox_TrainNumber.Size = new System.Drawing.Size(180, 34);
            TrainInfo_TextBox_TrainNumber.TabIndex = 37;
            TrainInfo_TextBox_TrainNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // TrainInfo_Label_DiaNumber
            // 
            TrainInfo_Label_DiaNumber.BackColor = System.Drawing.Color.FromArgb(76, 102, 102);
            TrainInfo_Label_DiaNumber.Font = new System.Drawing.Font("BIZ UDゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 128);
            TrainInfo_Label_DiaNumber.ForeColor = System.Drawing.Color.White;
            TrainInfo_Label_DiaNumber.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            TrainInfo_Label_DiaNumber.Location = new System.Drawing.Point(289, 412);
            TrainInfo_Label_DiaNumber.Name = "TrainInfo_Label_DiaNumber";
            TrainInfo_Label_DiaNumber.Padding = new System.Windows.Forms.Padding(0, 5, 0, 5);
            TrainInfo_Label_DiaNumber.Size = new System.Drawing.Size(85, 31);
            TrainInfo_Label_DiaNumber.TabIndex = 40;
            TrainInfo_Label_DiaNumber.Text = "ダイヤ番号";
            TrainInfo_Label_DiaNumber.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TrainInfo_NumericUpDown_DiaNumber
            // 
            TrainInfo_NumericUpDown_DiaNumber.Font = new System.Drawing.Font("BIZ UDゴシック", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 128);
            TrainInfo_NumericUpDown_DiaNumber.Location = new System.Drawing.Point(289, 446);
            TrainInfo_NumericUpDown_DiaNumber.Name = "TrainInfo_NumericUpDown_DiaNumber";
            TrainInfo_NumericUpDown_DiaNumber.Size = new System.Drawing.Size(85, 34);
            TrainInfo_NumericUpDown_DiaNumber.TabIndex = 39;
            TrainInfo_NumericUpDown_DiaNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // TrainInfo_TextBox_FromStationID
            // 
            TrainInfo_TextBox_FromStationID.Font = new System.Drawing.Font("BIZ UDゴシック", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 128);
            TrainInfo_TextBox_FromStationID.Location = new System.Drawing.Point(380, 446);
            TrainInfo_TextBox_FromStationID.MaxLength = 7;
            TrainInfo_TextBox_FromStationID.Name = "TrainInfo_TextBox_FromStationID";
            TrainInfo_TextBox_FromStationID.Size = new System.Drawing.Size(100, 34);
            TrainInfo_TextBox_FromStationID.TabIndex = 41;
            TrainInfo_TextBox_FromStationID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // TrainInfo_Label_Title_TrainNumber
            // 
            TrainInfo_Label_Title_TrainNumber.BackColor = System.Drawing.Color.FromArgb(76, 102, 102);
            TrainInfo_Label_Title_TrainNumber.Font = new System.Drawing.Font("BIZ UDゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 128);
            TrainInfo_Label_Title_TrainNumber.ForeColor = System.Drawing.Color.White;
            TrainInfo_Label_Title_TrainNumber.Location = new System.Drawing.Point(103, 412);
            TrainInfo_Label_Title_TrainNumber.Name = "TrainInfo_Label_Title_TrainNumber";
            TrainInfo_Label_Title_TrainNumber.Size = new System.Drawing.Size(180, 31);
            TrainInfo_Label_Title_TrainNumber.TabIndex = 38;
            TrainInfo_Label_Title_TrainNumber.Text = "列車番号";
            TrainInfo_Label_Title_TrainNumber.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TrainInfo_Label_FromStationID
            // 
            TrainInfo_Label_FromStationID.BackColor = System.Drawing.Color.FromArgb(76, 102, 102);
            TrainInfo_Label_FromStationID.Font = new System.Drawing.Font("BIZ UDゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 128);
            TrainInfo_Label_FromStationID.ForeColor = System.Drawing.Color.White;
            TrainInfo_Label_FromStationID.Location = new System.Drawing.Point(380, 412);
            TrainInfo_Label_FromStationID.Name = "TrainInfo_Label_FromStationID";
            TrainInfo_Label_FromStationID.Size = new System.Drawing.Size(100, 31);
            TrainInfo_Label_FromStationID.TabIndex = 42;
            TrainInfo_Label_FromStationID.Text = "始発駅ID";
            TrainInfo_Label_FromStationID.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TrainInfo_TextBox_ToStationID
            // 
            TrainInfo_TextBox_ToStationID.Font = new System.Drawing.Font("BIZ UDゴシック", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 128);
            TrainInfo_TextBox_ToStationID.Location = new System.Drawing.Point(486, 446);
            TrainInfo_TextBox_ToStationID.MaxLength = 7;
            TrainInfo_TextBox_ToStationID.Name = "TrainInfo_TextBox_ToStationID";
            TrainInfo_TextBox_ToStationID.Size = new System.Drawing.Size(100, 34);
            TrainInfo_TextBox_ToStationID.TabIndex = 43;
            TrainInfo_TextBox_ToStationID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // TrainInfo_Label_ToStationID
            // 
            TrainInfo_Label_ToStationID.BackColor = System.Drawing.Color.FromArgb(76, 102, 102);
            TrainInfo_Label_ToStationID.Font = new System.Drawing.Font("BIZ UDゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 128);
            TrainInfo_Label_ToStationID.ForeColor = System.Drawing.Color.White;
            TrainInfo_Label_ToStationID.Location = new System.Drawing.Point(486, 412);
            TrainInfo_Label_ToStationID.Name = "TrainInfo_Label_ToStationID";
            TrainInfo_Label_ToStationID.Size = new System.Drawing.Size(100, 31);
            TrainInfo_Label_ToStationID.TabIndex = 44;
            TrainInfo_Label_ToStationID.Text = "行先駅ID";
            TrainInfo_Label_ToStationID.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TrainInfo_Label_Delay
            // 
            TrainInfo_Label_Delay.BackColor = System.Drawing.Color.FromArgb(76, 102, 102);
            TrainInfo_Label_Delay.Font = new System.Drawing.Font("BIZ UDゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 128);
            TrainInfo_Label_Delay.ForeColor = System.Drawing.Color.White;
            TrainInfo_Label_Delay.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            TrainInfo_Label_Delay.Location = new System.Drawing.Point(592, 412);
            TrainInfo_Label_Delay.Name = "TrainInfo_Label_Delay";
            TrainInfo_Label_Delay.Padding = new System.Windows.Forms.Padding(0, 5, 0, 5);
            TrainInfo_Label_Delay.Size = new System.Drawing.Size(85, 31);
            TrainInfo_Label_Delay.TabIndex = 46;
            TrainInfo_Label_Delay.Text = "遅延";
            TrainInfo_Label_Delay.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TrainInfo_NumericUpDown_Delay
            // 
            TrainInfo_NumericUpDown_Delay.Font = new System.Drawing.Font("BIZ UDゴシック", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 128);
            TrainInfo_NumericUpDown_Delay.Location = new System.Drawing.Point(592, 446);
            TrainInfo_NumericUpDown_Delay.Name = "TrainInfo_NumericUpDown_Delay";
            TrainInfo_NumericUpDown_Delay.Size = new System.Drawing.Size(85, 34);
            TrainInfo_NumericUpDown_Delay.TabIndex = 45;
            TrainInfo_NumericUpDown_Delay.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // TrainInfo_Label_DriverID
            // 
            TrainInfo_Label_DriverID.BackColor = System.Drawing.Color.FromArgb(76, 102, 102);
            TrainInfo_Label_DriverID.Font = new System.Drawing.Font("BIZ UDゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 128);
            TrainInfo_Label_DriverID.ForeColor = System.Drawing.Color.White;
            TrainInfo_Label_DriverID.Location = new System.Drawing.Point(683, 412);
            TrainInfo_Label_DriverID.Name = "TrainInfo_Label_DriverID";
            TrainInfo_Label_DriverID.Size = new System.Drawing.Size(189, 31);
            TrainInfo_Label_DriverID.TabIndex = 48;
            TrainInfo_Label_DriverID.Text = "運転士ID";
            TrainInfo_Label_DriverID.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TrainInfo_TextBox_DriverID
            // 
            TrainInfo_TextBox_DriverID.Font = new System.Drawing.Font("BIZ UDゴシック", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 128);
            TrainInfo_TextBox_DriverID.Location = new System.Drawing.Point(683, 446);
            TrainInfo_TextBox_DriverID.MaxLength = 7;
            TrainInfo_TextBox_DriverID.Name = "TrainInfo_TextBox_DriverID";
            TrainInfo_TextBox_DriverID.Size = new System.Drawing.Size(189, 34);
            TrainInfo_TextBox_DriverID.TabIndex = 47;
            TrainInfo_TextBox_DriverID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // TrainInfoForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.FromArgb(76, 102, 102);
            ClientSize = new System.Drawing.Size(884, 561);
            Controls.Add(TrainInfo_Label_DriverID);
            Controls.Add(TrainInfo_TextBox_DriverID);
            Controls.Add(TrainInfo_Label_Delay);
            Controls.Add(TrainInfo_NumericUpDown_Delay);
            Controls.Add(TrainInfo_Label_ToStationID);
            Controls.Add(TrainInfo_TextBox_ToStationID);
            Controls.Add(TrainInfo_Label_FromStationID);
            Controls.Add(TrainInfo_TextBox_FromStationID);
            Controls.Add(TrainInfo_Label_DiaNumber);
            Controls.Add(TrainInfo_NumericUpDown_DiaNumber);
            Controls.Add(TrainInfo_Label_Title_TrainNumber);
            Controls.Add(TrainInfo_TextBox_TrainNumber);
            Controls.Add(TrainInfo_Label_ID);
            Controls.Add(TrainInfo_NumericUpDown_ID);
            Controls.Add(TrainInfo_Button_Update);
            Controls.Add(TrainInfo_Button_Add);
            Controls.Add(TrainInfo_Button_Delete);
            Controls.Add(TrainInfo_CheckBox_TopMost);
            Controls.Add(TrainInfo_DataGridView_TrainInfoData);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            Name = "TrainInfoForm";
            Text = "列車情報設定 | 司令卓 - ダイヤ運転会";
            ((System.ComponentModel.ISupportInitialize)TrainInfo_DataGridView_TrainInfoData).EndInit();
            ((System.ComponentModel.ISupportInitialize)TrainInfo_BindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)TrainInfo_NumericUpDown_ID).EndInit();
            ((System.ComponentModel.ISupportInitialize)TrainInfo_NumericUpDown_DiaNumber).EndInit();
            ((System.ComponentModel.ISupportInitialize)TrainInfo_NumericUpDown_Delay).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.DataGridView TrainInfo_DataGridView_TrainInfoData;
        private System.Windows.Forms.CheckBox TrainInfo_CheckBox_TopMost;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn TrainNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn DiaNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn FromStationID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ToStationID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Delay;
        private System.Windows.Forms.DataGridViewTextBoxColumn DriverID;
        private System.Windows.Forms.BindingSource TrainInfo_BindingSource;
        private System.Windows.Forms.Button TrainInfo_Button_Delete;
        private System.Windows.Forms.Button TrainInfo_Button_Update;
        private System.Windows.Forms.Button TrainInfo_Button_Add;
        private System.Windows.Forms.Label TrainInfo_Label_ID;
        private System.Windows.Forms.NumericUpDown TrainInfo_NumericUpDown_ID;
        private System.Windows.Forms.TextBox TrainInfo_TextBox_TrainNumber;
        private System.Windows.Forms.Label TrainInfo_Label_DiaNumber;
        private System.Windows.Forms.NumericUpDown TrainInfo_NumericUpDown_DiaNumber;
        private System.Windows.Forms.TextBox TrainInfo_TextBox_FromStationID;
        private System.Windows.Forms.Label TrainInfo_Label_Title_TrainNumber;
        private System.Windows.Forms.Label TrainInfo_Label_FromStationID;
        private System.Windows.Forms.TextBox TrainInfo_TextBox_ToStationID;
        private System.Windows.Forms.Label TrainInfo_Label_ToStationID;
        private System.Windows.Forms.Label TrainInfo_Label_Delay;
        private System.Windows.Forms.NumericUpDown TrainInfo_NumericUpDown_Delay;
        private System.Windows.Forms.Label TrainInfo_Label_DriverID;
        private System.Windows.Forms.TextBox TrainInfo_TextBox_DriverID;
    }
}