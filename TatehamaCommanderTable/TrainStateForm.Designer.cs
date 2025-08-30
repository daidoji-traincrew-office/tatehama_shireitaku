namespace TatehamaCommanderTable
{
    partial class TrainStateForm
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
            TrainState_DataGridView_TrainStateData = new System.Windows.Forms.DataGridView();
            TrainState_BindingSource = new System.Windows.Forms.BindingSource(components);
            TrainState_CheckBox_TopMost = new System.Windows.Forms.CheckBox();
            TrainState_Button_Delete = new System.Windows.Forms.Button();
            TrainState_Button_Update = new System.Windows.Forms.Button();
            TrainState_Label_ID = new System.Windows.Forms.Label();
            TrainState_NumericUpDown_ID = new System.Windows.Forms.NumericUpDown();
            TrainState_TextBox_TrainNumber = new System.Windows.Forms.TextBox();
            TrainState_Label_DiaNumber = new System.Windows.Forms.Label();
            TrainState_NumericUpDown_DiaNumber = new System.Windows.Forms.NumericUpDown();
            TrainState_TextBox_FromStationID = new System.Windows.Forms.TextBox();
            TrainState_Label_Title_TrainNumber = new System.Windows.Forms.Label();
            TrainState_Label_FromStationID = new System.Windows.Forms.Label();
            TrainState_TextBox_ToStationID = new System.Windows.Forms.TextBox();
            TrainState_Label_ToStationID = new System.Windows.Forms.Label();
            TrainState_Label_Delay = new System.Windows.Forms.Label();
            TrainState_NumericUpDown_Delay = new System.Windows.Forms.NumericUpDown();
            TrainState_Label_DriverID = new System.Windows.Forms.Label();
            TrainState_TextBox_DriverID = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)TrainState_DataGridView_TrainStateData).BeginInit();
            ((System.ComponentModel.ISupportInitialize)TrainState_BindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)TrainState_NumericUpDown_ID).BeginInit();
            ((System.ComponentModel.ISupportInitialize)TrainState_NumericUpDown_DiaNumber).BeginInit();
            ((System.ComponentModel.ISupportInitialize)TrainState_NumericUpDown_Delay).BeginInit();
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
            // TrainState_DataGridView_TrainStateData
            // 
            TrainState_DataGridView_TrainStateData.AllowUserToAddRows = false;
            TrainState_DataGridView_TrainStateData.AllowUserToDeleteRows = false;
            TrainState_DataGridView_TrainStateData.AllowUserToResizeColumns = false;
            TrainState_DataGridView_TrainStateData.AllowUserToResizeRows = false;
            TrainState_DataGridView_TrainStateData.AutoGenerateColumns = false;
            TrainState_DataGridView_TrainStateData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            TrainState_DataGridView_TrainStateData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { ID, TrainNumber, DiaNumber, FromStationID, ToStationID, Delay, DriverID });
            TrainState_DataGridView_TrainStateData.DataSource = TrainState_BindingSource;
            TrainState_DataGridView_TrainStateData.Location = new System.Drawing.Point(12, 37);
            TrainState_DataGridView_TrainStateData.Name = "TrainState_DataGridView_TrainStateData";
            TrainState_DataGridView_TrainStateData.ReadOnly = true;
            TrainState_DataGridView_TrainStateData.RowHeadersVisible = false;
            TrainState_DataGridView_TrainStateData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            TrainState_DataGridView_TrainStateData.Size = new System.Drawing.Size(860, 350);
            TrainState_DataGridView_TrainStateData.TabIndex = 19;
            // 
            // TrainState_CheckBox_TopMost
            // 
            TrainState_CheckBox_TopMost.AutoSize = true;
            TrainState_CheckBox_TopMost.Font = new System.Drawing.Font("BIZ UDゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 128);
            TrainState_CheckBox_TopMost.ForeColor = System.Drawing.Color.White;
            TrainState_CheckBox_TopMost.Location = new System.Drawing.Point(771, 12);
            TrainState_CheckBox_TopMost.Name = "TrainState_CheckBox_TopMost";
            TrainState_CheckBox_TopMost.Size = new System.Drawing.Size(101, 19);
            TrainState_CheckBox_TopMost.TabIndex = 20;
            TrainState_CheckBox_TopMost.Text = "最前面表示";
            TrainState_CheckBox_TopMost.UseVisualStyleBackColor = true;
            TrainState_CheckBox_TopMost.CheckedChanged += TrainState_CheckBox_TopMost_CheckedChanged;
            // 
            // TrainState_Button_Delete
            // 
            TrainState_Button_Delete.BackColor = System.Drawing.Color.OrangeRed;
            TrainState_Button_Delete.FlatAppearance.BorderSize = 0;
            TrainState_Button_Delete.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            TrainState_Button_Delete.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            TrainState_Button_Delete.Font = new System.Drawing.Font("BIZ UDゴシック", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 128);
            TrainState_Button_Delete.ForeColor = System.Drawing.Color.White;
            TrainState_Button_Delete.Location = new System.Drawing.Point(142, 498);
            TrainState_Button_Delete.Margin = new System.Windows.Forms.Padding(5);
            TrainState_Button_Delete.Name = "TrainState_Button_Delete";
            TrainState_Button_Delete.Size = new System.Drawing.Size(75, 40);
            TrainState_Button_Delete.TabIndex = 29;
            TrainState_Button_Delete.Text = "削除";
            TrainState_Button_Delete.UseVisualStyleBackColor = false;
            TrainState_Button_Delete.Click += TrainState_Button_Click;
            // 
            // TrainState_Button_Update
            // 
            TrainState_Button_Update.BackColor = System.Drawing.Color.Aqua;
            TrainState_Button_Update.FlatAppearance.BorderSize = 0;
            TrainState_Button_Update.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            TrainState_Button_Update.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            TrainState_Button_Update.Font = new System.Drawing.Font("BIZ UDゴシック", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 128);
            TrainState_Button_Update.ForeColor = System.Drawing.Color.Black;
            TrainState_Button_Update.Location = new System.Drawing.Point(664, 498);
            TrainState_Button_Update.Margin = new System.Windows.Forms.Padding(5);
            TrainState_Button_Update.Name = "TrainState_Button_Update";
            TrainState_Button_Update.Size = new System.Drawing.Size(75, 40);
            TrainState_Button_Update.TabIndex = 34;
            TrainState_Button_Update.Text = "更新";
            TrainState_Button_Update.UseVisualStyleBackColor = false;
            TrainState_Button_Update.Click += TrainState_Button_Click;
            // 
            // TrainState_Label_ID
            // 
            TrainState_Label_ID.BackColor = System.Drawing.Color.FromArgb(76, 102, 102);
            TrainState_Label_ID.Font = new System.Drawing.Font("BIZ UDゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 128);
            TrainState_Label_ID.ForeColor = System.Drawing.Color.White;
            TrainState_Label_ID.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            TrainState_Label_ID.Location = new System.Drawing.Point(12, 466);
            TrainState_Label_ID.Name = "TrainState_Label_ID";
            TrainState_Label_ID.Padding = new System.Windows.Forms.Padding(0, 5, 0, 5);
            TrainState_Label_ID.Size = new System.Drawing.Size(120, 31);
            TrainState_Label_ID.TabIndex = 36;
            TrainState_Label_ID.Text = "ID";
            TrainState_Label_ID.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TrainState_NumericUpDown_ID
            // 
            TrainState_NumericUpDown_ID.Font = new System.Drawing.Font("BIZ UDゴシック", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 128);
            TrainState_NumericUpDown_ID.Location = new System.Drawing.Point(12, 500);
            TrainState_NumericUpDown_ID.Maximum = new decimal(new int[] { 9999999, 0, 0, 0 });
            TrainState_NumericUpDown_ID.Name = "TrainState_NumericUpDown_ID";
            TrainState_NumericUpDown_ID.Size = new System.Drawing.Size(120, 34);
            TrainState_NumericUpDown_ID.TabIndex = 35;
            TrainState_NumericUpDown_ID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // TrainState_TextBox_TrainNumber
            // 
            TrainState_TextBox_TrainNumber.Font = new System.Drawing.Font("BIZ UDゴシック", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 128);
            TrainState_TextBox_TrainNumber.Location = new System.Drawing.Point(12, 424);
            TrainState_TextBox_TrainNumber.MaxLength = 7;
            TrainState_TextBox_TrainNumber.Name = "TrainState_TextBox_TrainNumber";
            TrainState_TextBox_TrainNumber.Size = new System.Drawing.Size(120, 34);
            TrainState_TextBox_TrainNumber.TabIndex = 37;
            TrainState_TextBox_TrainNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // TrainState_Label_DiaNumber
            // 
            TrainState_Label_DiaNumber.BackColor = System.Drawing.Color.FromArgb(76, 102, 102);
            TrainState_Label_DiaNumber.Font = new System.Drawing.Font("BIZ UDゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 128);
            TrainState_Label_DiaNumber.ForeColor = System.Drawing.Color.White;
            TrainState_Label_DiaNumber.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            TrainState_Label_DiaNumber.Location = new System.Drawing.Point(138, 390);
            TrainState_Label_DiaNumber.Name = "TrainState_Label_DiaNumber";
            TrainState_Label_DiaNumber.Padding = new System.Windows.Forms.Padding(0, 5, 0, 5);
            TrainState_Label_DiaNumber.Size = new System.Drawing.Size(85, 31);
            TrainState_Label_DiaNumber.TabIndex = 40;
            TrainState_Label_DiaNumber.Text = "ダイヤ番号";
            TrainState_Label_DiaNumber.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TrainState_NumericUpDown_DiaNumber
            // 
            TrainState_NumericUpDown_DiaNumber.Font = new System.Drawing.Font("BIZ UDゴシック", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 128);
            TrainState_NumericUpDown_DiaNumber.Location = new System.Drawing.Point(138, 424);
            TrainState_NumericUpDown_DiaNumber.Maximum = new decimal(new int[] { 9999, 0, 0, 0 });
            TrainState_NumericUpDown_DiaNumber.Name = "TrainState_NumericUpDown_DiaNumber";
            TrainState_NumericUpDown_DiaNumber.Size = new System.Drawing.Size(85, 34);
            TrainState_NumericUpDown_DiaNumber.TabIndex = 39;
            TrainState_NumericUpDown_DiaNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // TrainState_TextBox_FromStationID
            // 
            TrainState_TextBox_FromStationID.Font = new System.Drawing.Font("BIZ UDゴシック", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 128);
            TrainState_TextBox_FromStationID.Location = new System.Drawing.Point(229, 424);
            TrainState_TextBox_FromStationID.MaxLength = 7;
            TrainState_TextBox_FromStationID.Name = "TrainState_TextBox_FromStationID";
            TrainState_TextBox_FromStationID.Size = new System.Drawing.Size(100, 34);
            TrainState_TextBox_FromStationID.TabIndex = 41;
            TrainState_TextBox_FromStationID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // TrainState_Label_Title_TrainNumber
            // 
            TrainState_Label_Title_TrainNumber.BackColor = System.Drawing.Color.FromArgb(76, 102, 102);
            TrainState_Label_Title_TrainNumber.Font = new System.Drawing.Font("BIZ UDゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 128);
            TrainState_Label_Title_TrainNumber.ForeColor = System.Drawing.Color.White;
            TrainState_Label_Title_TrainNumber.Location = new System.Drawing.Point(12, 390);
            TrainState_Label_Title_TrainNumber.Name = "TrainState_Label_Title_TrainNumber";
            TrainState_Label_Title_TrainNumber.Size = new System.Drawing.Size(120, 31);
            TrainState_Label_Title_TrainNumber.TabIndex = 38;
            TrainState_Label_Title_TrainNumber.Text = "列車番号";
            TrainState_Label_Title_TrainNumber.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TrainState_Label_FromStationID
            // 
            TrainState_Label_FromStationID.BackColor = System.Drawing.Color.FromArgb(76, 102, 102);
            TrainState_Label_FromStationID.Font = new System.Drawing.Font("BIZ UDゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 128);
            TrainState_Label_FromStationID.ForeColor = System.Drawing.Color.White;
            TrainState_Label_FromStationID.Location = new System.Drawing.Point(229, 390);
            TrainState_Label_FromStationID.Name = "TrainState_Label_FromStationID";
            TrainState_Label_FromStationID.Size = new System.Drawing.Size(100, 31);
            TrainState_Label_FromStationID.TabIndex = 42;
            TrainState_Label_FromStationID.Text = "始発駅ID";
            TrainState_Label_FromStationID.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TrainState_TextBox_ToStationID
            // 
            TrainState_TextBox_ToStationID.Font = new System.Drawing.Font("BIZ UDゴシック", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 128);
            TrainState_TextBox_ToStationID.Location = new System.Drawing.Point(335, 424);
            TrainState_TextBox_ToStationID.MaxLength = 7;
            TrainState_TextBox_ToStationID.Name = "TrainState_TextBox_ToStationID";
            TrainState_TextBox_ToStationID.Size = new System.Drawing.Size(100, 34);
            TrainState_TextBox_ToStationID.TabIndex = 43;
            TrainState_TextBox_ToStationID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // TrainState_Label_ToStationID
            // 
            TrainState_Label_ToStationID.BackColor = System.Drawing.Color.FromArgb(76, 102, 102);
            TrainState_Label_ToStationID.Font = new System.Drawing.Font("BIZ UDゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 128);
            TrainState_Label_ToStationID.ForeColor = System.Drawing.Color.White;
            TrainState_Label_ToStationID.Location = new System.Drawing.Point(335, 390);
            TrainState_Label_ToStationID.Name = "TrainState_Label_ToStationID";
            TrainState_Label_ToStationID.Size = new System.Drawing.Size(100, 31);
            TrainState_Label_ToStationID.TabIndex = 44;
            TrainState_Label_ToStationID.Text = "行先駅ID";
            TrainState_Label_ToStationID.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TrainState_Label_Delay
            // 
            TrainState_Label_Delay.BackColor = System.Drawing.Color.FromArgb(76, 102, 102);
            TrainState_Label_Delay.Font = new System.Drawing.Font("BIZ UDゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 128);
            TrainState_Label_Delay.ForeColor = System.Drawing.Color.White;
            TrainState_Label_Delay.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            TrainState_Label_Delay.Location = new System.Drawing.Point(441, 390);
            TrainState_Label_Delay.Name = "TrainState_Label_Delay";
            TrainState_Label_Delay.Padding = new System.Windows.Forms.Padding(0, 5, 0, 5);
            TrainState_Label_Delay.Size = new System.Drawing.Size(85, 31);
            TrainState_Label_Delay.TabIndex = 46;
            TrainState_Label_Delay.Text = "遅延";
            TrainState_Label_Delay.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TrainState_NumericUpDown_Delay
            // 
            TrainState_NumericUpDown_Delay.Font = new System.Drawing.Font("BIZ UDゴシック", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 128);
            TrainState_NumericUpDown_Delay.Location = new System.Drawing.Point(441, 424);
            TrainState_NumericUpDown_Delay.Maximum = new decimal(new int[] { 9999, 0, 0, 0 });
            TrainState_NumericUpDown_Delay.Name = "TrainState_NumericUpDown_Delay";
            TrainState_NumericUpDown_Delay.Size = new System.Drawing.Size(85, 34);
            TrainState_NumericUpDown_Delay.TabIndex = 45;
            TrainState_NumericUpDown_Delay.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // TrainState_Label_DriverID
            // 
            TrainState_Label_DriverID.BackColor = System.Drawing.Color.FromArgb(76, 102, 102);
            TrainState_Label_DriverID.Font = new System.Drawing.Font("BIZ UDゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 128);
            TrainState_Label_DriverID.ForeColor = System.Drawing.Color.White;
            TrainState_Label_DriverID.Location = new System.Drawing.Point(532, 390);
            TrainState_Label_DriverID.Name = "TrainState_Label_DriverID";
            TrainState_Label_DriverID.Size = new System.Drawing.Size(340, 31);
            TrainState_Label_DriverID.TabIndex = 48;
            TrainState_Label_DriverID.Text = "運転士ID";
            TrainState_Label_DriverID.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TrainState_TextBox_DriverID
            // 
            TrainState_TextBox_DriverID.Font = new System.Drawing.Font("BIZ UDゴシック", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 128);
            TrainState_TextBox_DriverID.Location = new System.Drawing.Point(532, 424);
            TrainState_TextBox_DriverID.MaxLength = 7;
            TrainState_TextBox_DriverID.Name = "TrainState_TextBox_DriverID";
            TrainState_TextBox_DriverID.Size = new System.Drawing.Size(340, 34);
            TrainState_TextBox_DriverID.TabIndex = 47;
            TrainState_TextBox_DriverID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // TrainStateForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.FromArgb(76, 102, 102);
            ClientSize = new System.Drawing.Size(884, 561);
            Controls.Add(TrainState_Label_DriverID);
            Controls.Add(TrainState_TextBox_DriverID);
            Controls.Add(TrainState_Label_Delay);
            Controls.Add(TrainState_NumericUpDown_Delay);
            Controls.Add(TrainState_Label_ToStationID);
            Controls.Add(TrainState_TextBox_ToStationID);
            Controls.Add(TrainState_Label_FromStationID);
            Controls.Add(TrainState_TextBox_FromStationID);
            Controls.Add(TrainState_Label_DiaNumber);
            Controls.Add(TrainState_NumericUpDown_DiaNumber);
            Controls.Add(TrainState_Label_Title_TrainNumber);
            Controls.Add(TrainState_TextBox_TrainNumber);
            Controls.Add(TrainState_Label_ID);
            Controls.Add(TrainState_NumericUpDown_ID);
            Controls.Add(TrainState_Button_Update);
            Controls.Add(TrainState_Button_Delete);
            Controls.Add(TrainState_CheckBox_TopMost);
            Controls.Add(TrainState_DataGridView_TrainStateData);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            Name = "TrainStateForm";
            Text = "列車情報設定 | 司令卓 - ダイヤ運転会";
            ((System.ComponentModel.ISupportInitialize)TrainState_DataGridView_TrainStateData).EndInit();
            ((System.ComponentModel.ISupportInitialize)TrainState_BindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)TrainState_NumericUpDown_ID).EndInit();
            ((System.ComponentModel.ISupportInitialize)TrainState_NumericUpDown_DiaNumber).EndInit();
            ((System.ComponentModel.ISupportInitialize)TrainState_NumericUpDown_Delay).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.DataGridView TrainState_DataGridView_TrainStateData;
        private System.Windows.Forms.CheckBox TrainState_CheckBox_TopMost;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn TrainNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn DiaNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn FromStationID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ToStationID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Delay;
        private System.Windows.Forms.DataGridViewTextBoxColumn DriverID;
        private System.Windows.Forms.BindingSource TrainState_BindingSource;
        private System.Windows.Forms.Button TrainState_Button_Delete;
        private System.Windows.Forms.Button TrainState_Button_Update;
        private System.Windows.Forms.Label TrainState_Label_ID;
        private System.Windows.Forms.NumericUpDown TrainState_NumericUpDown_ID;
        private System.Windows.Forms.TextBox TrainState_TextBox_TrainNumber;
        private System.Windows.Forms.Label TrainState_Label_DiaNumber;
        private System.Windows.Forms.NumericUpDown TrainState_NumericUpDown_DiaNumber;
        private System.Windows.Forms.TextBox TrainState_TextBox_FromStationID;
        private System.Windows.Forms.Label TrainState_Label_Title_TrainNumber;
        private System.Windows.Forms.Label TrainState_Label_FromStationID;
        private System.Windows.Forms.TextBox TrainState_TextBox_ToStationID;
        private System.Windows.Forms.Label TrainState_Label_ToStationID;
        private System.Windows.Forms.Label TrainState_Label_Delay;
        private System.Windows.Forms.NumericUpDown TrainState_NumericUpDown_Delay;
        private System.Windows.Forms.Label TrainState_Label_DriverID;
        private System.Windows.Forms.TextBox TrainState_TextBox_DriverID;
    }
}