namespace TatehamaCommanderTable
{
    partial class MessageForm
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
            Type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            Content = new System.Windows.Forms.DataGridViewTextBoxColumn();
            StartTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            EndTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            Message_CheckBox_TopMost = new System.Windows.Forms.CheckBox();
            Message_DataGridView_MessageData = new System.Windows.Forms.DataGridView();
            Message_BindingSource = new System.Windows.Forms.BindingSource(components);
            Message_TextBox_MessageText = new System.Windows.Forms.TextBox();
            Message_Label_MessageText = new System.Windows.Forms.Label();
            Message_DateTimePicker_StartDate = new System.Windows.Forms.DateTimePicker();
            Message_DateTimePicker_EndDate = new System.Windows.Forms.DateTimePicker();
            Message_Label_StartDate = new System.Windows.Forms.Label();
            Message_Label_EndDate = new System.Windows.Forms.Label();
            Message_Label_Hyphen = new System.Windows.Forms.Label();
            Message_Button_Add = new System.Windows.Forms.Button();
            Message_Button_Cansel = new System.Windows.Forms.Button();
            Message_ComboBox_Type = new System.Windows.Forms.ComboBox();
            Message_NumericUpDown_ID = new System.Windows.Forms.NumericUpDown();
            Message_Label_ID = new System.Windows.Forms.Label();
            Message_Button_Update = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)Message_DataGridView_MessageData).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Message_BindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Message_NumericUpDown_ID).BeginInit();
            SuspendLayout();
            // 
            // ID
            // 
            ID.DataPropertyName = "ID";
            ID.HeaderText = "ID";
            ID.MaxInputLength = 10;
            ID.Name = "ID";
            ID.ReadOnly = true;
            ID.Width = 50;
            // 
            // Type
            // 
            Type.DataPropertyName = "Type";
            Type.HeaderText = "情報の種類";
            Type.MaxInputLength = 10;
            Type.Name = "Type";
            Type.ReadOnly = true;
            // 
            // Content
            // 
            Content.DataPropertyName = "Content";
            Content.HeaderText = "運行メッセージ";
            Content.MaxInputLength = 10000;
            Content.Name = "Content";
            Content.ReadOnly = true;
            Content.Width = 390;
            // 
            // StartTime
            // 
            StartTime.DataPropertyName = "StartTime";
            StartTime.HeaderText = "配信開始日時";
            StartTime.MaxInputLength = 20;
            StartTime.Name = "StartTime";
            StartTime.ReadOnly = true;
            StartTime.Width = 150;
            // 
            // EndTime
            // 
            EndTime.DataPropertyName = "EndTime";
            EndTime.HeaderText = "配信終了日時";
            EndTime.MaxInputLength = 20;
            EndTime.Name = "EndTime";
            EndTime.ReadOnly = true;
            EndTime.Width = 150;
            // 
            // Message_CheckBox_TopMost
            // 
            Message_CheckBox_TopMost.AutoSize = true;
            Message_CheckBox_TopMost.Font = new System.Drawing.Font("BIZ UDゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 128);
            Message_CheckBox_TopMost.ForeColor = System.Drawing.Color.White;
            Message_CheckBox_TopMost.Location = new System.Drawing.Point(771, 12);
            Message_CheckBox_TopMost.Name = "Message_CheckBox_TopMost";
            Message_CheckBox_TopMost.Size = new System.Drawing.Size(101, 19);
            Message_CheckBox_TopMost.TabIndex = 17;
            Message_CheckBox_TopMost.Text = "最前面表示";
            Message_CheckBox_TopMost.UseVisualStyleBackColor = true;
            Message_CheckBox_TopMost.CheckedChanged += Message_CheckBox_TopMost_CheckedChanged;
            // 
            // Message_DataGridView_MessageData
            // 
            Message_DataGridView_MessageData.AllowUserToAddRows = false;
            Message_DataGridView_MessageData.AllowUserToDeleteRows = false;
            Message_DataGridView_MessageData.AllowUserToResizeColumns = false;
            Message_DataGridView_MessageData.AllowUserToResizeRows = false;
            Message_DataGridView_MessageData.AutoGenerateColumns = false;
            Message_DataGridView_MessageData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            Message_DataGridView_MessageData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { ID, Type, Content, StartTime, EndTime });
            Message_DataGridView_MessageData.DataSource = Message_BindingSource;
            Message_DataGridView_MessageData.Location = new System.Drawing.Point(12, 37);
            Message_DataGridView_MessageData.Name = "Message_DataGridView_MessageData";
            Message_DataGridView_MessageData.ReadOnly = true;
            Message_DataGridView_MessageData.RowHeadersVisible = false;
            Message_DataGridView_MessageData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            Message_DataGridView_MessageData.Size = new System.Drawing.Size(860, 260);
            Message_DataGridView_MessageData.TabIndex = 18;
            // 
            // Message_TextBox_MessageText
            // 
            Message_TextBox_MessageText.Font = new System.Drawing.Font("BIZ UDゴシック", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 128);
            Message_TextBox_MessageText.Location = new System.Drawing.Point(12, 430);
            Message_TextBox_MessageText.Multiline = true;
            Message_TextBox_MessageText.Name = "Message_TextBox_MessageText";
            Message_TextBox_MessageText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            Message_TextBox_MessageText.Size = new System.Drawing.Size(860, 100);
            Message_TextBox_MessageText.TabIndex = 19;
            // 
            // Message_Label_MessageText
            // 
            Message_Label_MessageText.AutoSize = true;
            Message_Label_MessageText.BackColor = System.Drawing.Color.FromArgb(76, 102, 102);
            Message_Label_MessageText.Font = new System.Drawing.Font("BIZ UDゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 128);
            Message_Label_MessageText.ForeColor = System.Drawing.Color.White;
            Message_Label_MessageText.Location = new System.Drawing.Point(163, 399);
            Message_Label_MessageText.Name = "Message_Label_MessageText";
            Message_Label_MessageText.Padding = new System.Windows.Forms.Padding(0, 5, 0, 5);
            Message_Label_MessageText.Size = new System.Drawing.Size(157, 25);
            Message_Label_MessageText.TabIndex = 20;
            Message_Label_MessageText.Text = "運行メッセージ入力欄";
            // 
            // Message_DateTimePicker_StartDate
            // 
            Message_DateTimePicker_StartDate.CalendarFont = new System.Drawing.Font("BIZ UDゴシック", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 128);
            Message_DateTimePicker_StartDate.CustomFormat = "yyyy/MM/dd HH:mm:ss";
            Message_DateTimePicker_StartDate.Font = new System.Drawing.Font("BIZ UDゴシック", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 128);
            Message_DateTimePicker_StartDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            Message_DateTimePicker_StartDate.Location = new System.Drawing.Point(224, 348);
            Message_DateTimePicker_StartDate.MinDate = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            Message_DateTimePicker_StartDate.Name = "Message_DateTimePicker_StartDate";
            Message_DateTimePicker_StartDate.ShowUpDown = true;
            Message_DateTimePicker_StartDate.Size = new System.Drawing.Size(291, 34);
            Message_DateTimePicker_StartDate.TabIndex = 21;
            Message_DateTimePicker_StartDate.Value = new System.DateTime(2025, 6, 12, 8, 0, 0, 0);
            // 
            // Message_DateTimePicker_EndDate
            // 
            Message_DateTimePicker_EndDate.CustomFormat = "yyyy/MM/dd HH:mm:ss";
            Message_DateTimePicker_EndDate.Font = new System.Drawing.Font("BIZ UDゴシック", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 128);
            Message_DateTimePicker_EndDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            Message_DateTimePicker_EndDate.Location = new System.Drawing.Point(566, 348);
            Message_DateTimePicker_EndDate.MinDate = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            Message_DateTimePicker_EndDate.Name = "Message_DateTimePicker_EndDate";
            Message_DateTimePicker_EndDate.ShowUpDown = true;
            Message_DateTimePicker_EndDate.Size = new System.Drawing.Size(291, 34);
            Message_DateTimePicker_EndDate.TabIndex = 22;
            Message_DateTimePicker_EndDate.Value = new System.DateTime(2025, 6, 12, 8, 0, 0, 0);
            // 
            // Message_Label_StartDate
            // 
            Message_Label_StartDate.BackColor = System.Drawing.Color.FromArgb(76, 102, 102);
            Message_Label_StartDate.Font = new System.Drawing.Font("BIZ UDゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 128);
            Message_Label_StartDate.ForeColor = System.Drawing.Color.White;
            Message_Label_StartDate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            Message_Label_StartDate.Location = new System.Drawing.Point(224, 314);
            Message_Label_StartDate.Name = "Message_Label_StartDate";
            Message_Label_StartDate.Padding = new System.Windows.Forms.Padding(0, 5, 0, 5);
            Message_Label_StartDate.Size = new System.Drawing.Size(291, 31);
            Message_Label_StartDate.TabIndex = 23;
            Message_Label_StartDate.Text = "配信開始日時";
            Message_Label_StartDate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Message_Label_EndDate
            // 
            Message_Label_EndDate.BackColor = System.Drawing.Color.FromArgb(76, 102, 102);
            Message_Label_EndDate.Font = new System.Drawing.Font("BIZ UDゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 128);
            Message_Label_EndDate.ForeColor = System.Drawing.Color.White;
            Message_Label_EndDate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            Message_Label_EndDate.Location = new System.Drawing.Point(566, 314);
            Message_Label_EndDate.Name = "Message_Label_EndDate";
            Message_Label_EndDate.Padding = new System.Windows.Forms.Padding(0, 5, 0, 5);
            Message_Label_EndDate.Size = new System.Drawing.Size(291, 31);
            Message_Label_EndDate.TabIndex = 24;
            Message_Label_EndDate.Text = "配信終了日時";
            Message_Label_EndDate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Message_Label_Hyphen
            // 
            Message_Label_Hyphen.BackColor = System.Drawing.Color.FromArgb(76, 102, 102);
            Message_Label_Hyphen.Font = new System.Drawing.Font("BIZ UDゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 128);
            Message_Label_Hyphen.ForeColor = System.Drawing.Color.White;
            Message_Label_Hyphen.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            Message_Label_Hyphen.Location = new System.Drawing.Point(521, 348);
            Message_Label_Hyphen.Name = "Message_Label_Hyphen";
            Message_Label_Hyphen.Padding = new System.Windows.Forms.Padding(0, 5, 0, 5);
            Message_Label_Hyphen.Size = new System.Drawing.Size(39, 34);
            Message_Label_Hyphen.TabIndex = 25;
            Message_Label_Hyphen.Text = "～";
            Message_Label_Hyphen.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Message_Button_Add
            // 
            Message_Button_Add.BackColor = System.Drawing.Color.Lime;
            Message_Button_Add.FlatAppearance.BorderSize = 0;
            Message_Button_Add.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            Message_Button_Add.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            Message_Button_Add.Font = new System.Drawing.Font("BIZ UDゴシック", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 128);
            Message_Button_Add.ForeColor = System.Drawing.Color.Black;
            Message_Button_Add.Location = new System.Drawing.Point(682, 548);
            Message_Button_Add.Margin = new System.Windows.Forms.Padding(5);
            Message_Button_Add.Name = "Message_Button_Add";
            Message_Button_Add.Size = new System.Drawing.Size(75, 40);
            Message_Button_Add.TabIndex = 27;
            Message_Button_Add.Text = "追加";
            Message_Button_Add.UseVisualStyleBackColor = false;
            Message_Button_Add.Click += Message_Button_Click;
            // 
            // Message_Button_Cansel
            // 
            Message_Button_Cansel.BackColor = System.Drawing.Color.OrangeRed;
            Message_Button_Cansel.FlatAppearance.BorderSize = 0;
            Message_Button_Cansel.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            Message_Button_Cansel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            Message_Button_Cansel.Font = new System.Drawing.Font("BIZ UDゴシック", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 128);
            Message_Button_Cansel.ForeColor = System.Drawing.Color.White;
            Message_Button_Cansel.Location = new System.Drawing.Point(127, 342);
            Message_Button_Cansel.Margin = new System.Windows.Forms.Padding(5);
            Message_Button_Cansel.Name = "Message_Button_Cansel";
            Message_Button_Cansel.Size = new System.Drawing.Size(75, 40);
            Message_Button_Cansel.TabIndex = 28;
            Message_Button_Cansel.Text = "削除";
            Message_Button_Cansel.UseVisualStyleBackColor = false;
            Message_Button_Cansel.Click += Message_Button_Click;
            // 
            // Message_ComboBox_Type
            // 
            Message_ComboBox_Type.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            Message_ComboBox_Type.Font = new System.Drawing.Font("BIZ UDゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 128);
            Message_ComboBox_Type.FormattingEnabled = true;
            Message_ComboBox_Type.Items.AddRange(new object[] { "広告", "平常運転", "遅延", "運転見合わせ" });
            Message_ComboBox_Type.Location = new System.Drawing.Point(12, 401);
            Message_ComboBox_Type.Name = "Message_ComboBox_Type";
            Message_ComboBox_Type.Size = new System.Drawing.Size(145, 23);
            Message_ComboBox_Type.TabIndex = 29;
            // 
            // Message_NumericUpDown_ID
            // 
            Message_NumericUpDown_ID.Font = new System.Drawing.Font("BIZ UDゴシック", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 128);
            Message_NumericUpDown_ID.Location = new System.Drawing.Point(29, 348);
            Message_NumericUpDown_ID.Name = "Message_NumericUpDown_ID";
            Message_NumericUpDown_ID.Size = new System.Drawing.Size(76, 34);
            Message_NumericUpDown_ID.TabIndex = 30;
            Message_NumericUpDown_ID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Message_Label_ID
            // 
            Message_Label_ID.BackColor = System.Drawing.Color.FromArgb(76, 102, 102);
            Message_Label_ID.Font = new System.Drawing.Font("BIZ UDゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 128);
            Message_Label_ID.ForeColor = System.Drawing.Color.White;
            Message_Label_ID.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            Message_Label_ID.Location = new System.Drawing.Point(29, 314);
            Message_Label_ID.Name = "Message_Label_ID";
            Message_Label_ID.Padding = new System.Windows.Forms.Padding(0, 5, 0, 5);
            Message_Label_ID.Size = new System.Drawing.Size(76, 31);
            Message_Label_ID.TabIndex = 31;
            Message_Label_ID.Text = "ID";
            Message_Label_ID.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Message_Button_Update
            // 
            Message_Button_Update.BackColor = System.Drawing.Color.Aqua;
            Message_Button_Update.FlatAppearance.BorderSize = 0;
            Message_Button_Update.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            Message_Button_Update.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            Message_Button_Update.Font = new System.Drawing.Font("BIZ UDゴシック", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 128);
            Message_Button_Update.ForeColor = System.Drawing.Color.Black;
            Message_Button_Update.Location = new System.Drawing.Point(782, 548);
            Message_Button_Update.Margin = new System.Windows.Forms.Padding(5);
            Message_Button_Update.Name = "Message_Button_Update";
            Message_Button_Update.Size = new System.Drawing.Size(75, 40);
            Message_Button_Update.TabIndex = 32;
            Message_Button_Update.Text = "更新";
            Message_Button_Update.UseVisualStyleBackColor = false;
            Message_Button_Update.Click += Message_Button_Click;
            // 
            // MessageForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.FromArgb(76, 102, 102);
            ClientSize = new System.Drawing.Size(884, 611);
            Controls.Add(Message_Button_Update);
            Controls.Add(Message_Label_ID);
            Controls.Add(Message_NumericUpDown_ID);
            Controls.Add(Message_ComboBox_Type);
            Controls.Add(Message_Button_Cansel);
            Controls.Add(Message_Button_Add);
            Controls.Add(Message_Label_Hyphen);
            Controls.Add(Message_Label_EndDate);
            Controls.Add(Message_Label_StartDate);
            Controls.Add(Message_DateTimePicker_EndDate);
            Controls.Add(Message_DateTimePicker_StartDate);
            Controls.Add(Message_Label_MessageText);
            Controls.Add(Message_TextBox_MessageText);
            Controls.Add(Message_DataGridView_MessageData);
            Controls.Add(Message_CheckBox_TopMost);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "MessageForm";
            Text = "運行メッセージ設定 | 司令卓 - ダイヤ運転会";
            ((System.ComponentModel.ISupportInitialize)Message_DataGridView_MessageData).EndInit();
            ((System.ComponentModel.ISupportInitialize)Message_BindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)Message_NumericUpDown_ID).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.CheckBox Message_CheckBox_TopMost;
        private System.Windows.Forms.DataGridView Message_DataGridView_MessageData;
        private System.Windows.Forms.TextBox Message_TextBox_MessageText;
        private System.Windows.Forms.Label Message_Label_MessageText;
        private System.Windows.Forms.DateTimePicker Message_DateTimePicker_StartDate;
        private System.Windows.Forms.DateTimePicker Message_DateTimePicker_EndDate;
        private System.Windows.Forms.Label Message_Label_StartDate;
        private System.Windows.Forms.Label Message_Label_EndDate;
        private System.Windows.Forms.Label Message_Label_Hyphen;
        private System.Windows.Forms.Button Message_Button_Add;
        private System.Windows.Forms.Button Message_Button_Cansel;
        private System.Windows.Forms.BindingSource Message_BindingSource;
        private System.Windows.Forms.ComboBox Message_ComboBox_Type;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Type;
        private System.Windows.Forms.DataGridViewTextBoxColumn Content;
        private System.Windows.Forms.DataGridViewTextBoxColumn StartTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn EndTime;
        private System.Windows.Forms.NumericUpDown Message_NumericUpDown_ID;
        private System.Windows.Forms.Label Message_Label_ID;
        private System.Windows.Forms.Button Message_Button_Update;
    }
}