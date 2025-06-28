namespace TatehamaCommanderTable
{
    partial class ProtectionRadioForm
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
            ProtectionZone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            TrainNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ProtectionRadio_CheckBox_TopMost = new System.Windows.Forms.CheckBox();
            ProtectionRadio_DataGridView_ProtectionRadioData = new System.Windows.Forms.DataGridView();
            ProtectionRadio_BindingSource = new System.Windows.Forms.BindingSource(components);
            ProtectionRadio_Label_ID = new System.Windows.Forms.Label();
            ProtectionRadio_NumericUpDown_ID = new System.Windows.Forms.NumericUpDown();
            ProtectionRadio_Label_ProtectionZone = new System.Windows.Forms.Label();
            ProtectionRadio_NumericUpDown_ProtectionZone = new System.Windows.Forms.NumericUpDown();
            ProtectionRadio_TextBox_TrainNumber = new System.Windows.Forms.TextBox();
            ProtectionRadio_Label_Title_TrainNumber = new System.Windows.Forms.Label();
            ProtectionRadio_Button_Update = new System.Windows.Forms.Button();
            ProtectionRadio_Button_Delete = new System.Windows.Forms.Button();
            ProtectionRadio_Button_Add = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)ProtectionRadio_DataGridView_ProtectionRadioData).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ProtectionRadio_BindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ProtectionRadio_NumericUpDown_ID).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ProtectionRadio_NumericUpDown_ProtectionZone).BeginInit();
            SuspendLayout();
            // 
            // ID
            // 
            ID.DataPropertyName = "ID";
            ID.HeaderText = "ID";
            ID.MaxInputLength = 10;
            ID.Name = "ID";
            ID.ReadOnly = true;
            ID.Width = 150;
            // 
            // ProtectionZone
            // 
            ProtectionZone.DataPropertyName = "ProtectionZone";
            ProtectionZone.HeaderText = "防護ゾーン";
            ProtectionZone.MaxInputLength = 10;
            ProtectionZone.Name = "ProtectionZone";
            ProtectionZone.ReadOnly = true;
            ProtectionZone.Width = 150;
            // 
            // TrainNumber
            // 
            TrainNumber.DataPropertyName = "TrainNumber";
            TrainNumber.HeaderText = "列車番号";
            TrainNumber.MaxInputLength = 10;
            TrainNumber.Name = "TrainNumber";
            TrainNumber.ReadOnly = true;
            TrainNumber.Width = 150;
            // 
            // ProtectionRadio_CheckBox_TopMost
            // 
            ProtectionRadio_CheckBox_TopMost.AutoSize = true;
            ProtectionRadio_CheckBox_TopMost.Font = new System.Drawing.Font("BIZ UDゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 128);
            ProtectionRadio_CheckBox_TopMost.ForeColor = System.Drawing.Color.White;
            ProtectionRadio_CheckBox_TopMost.Location = new System.Drawing.Point(381, 12);
            ProtectionRadio_CheckBox_TopMost.Name = "ProtectionRadio_CheckBox_TopMost";
            ProtectionRadio_CheckBox_TopMost.Size = new System.Drawing.Size(101, 19);
            ProtectionRadio_CheckBox_TopMost.TabIndex = 18;
            ProtectionRadio_CheckBox_TopMost.Text = "最前面表示";
            ProtectionRadio_CheckBox_TopMost.UseVisualStyleBackColor = true;
            ProtectionRadio_CheckBox_TopMost.CheckedChanged += ProtectionRadio_CheckBox_TopMost_CheckedChanged;
            // 
            // ProtectionRadio_DataGridView_ProtectionRadioData
            // 
            ProtectionRadio_DataGridView_ProtectionRadioData.AllowUserToAddRows = false;
            ProtectionRadio_DataGridView_ProtectionRadioData.AllowUserToDeleteRows = false;
            ProtectionRadio_DataGridView_ProtectionRadioData.AllowUserToResizeColumns = false;
            ProtectionRadio_DataGridView_ProtectionRadioData.AllowUserToResizeRows = false;
            ProtectionRadio_DataGridView_ProtectionRadioData.AutoGenerateColumns = false;
            ProtectionRadio_DataGridView_ProtectionRadioData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            ProtectionRadio_DataGridView_ProtectionRadioData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { ID, ProtectionZone, TrainNumber });
            ProtectionRadio_DataGridView_ProtectionRadioData.DataSource = ProtectionRadio_BindingSource;
            ProtectionRadio_DataGridView_ProtectionRadioData.Location = new System.Drawing.Point(12, 37);
            ProtectionRadio_DataGridView_ProtectionRadioData.Name = "ProtectionRadio_DataGridView_ProtectionRadioData";
            ProtectionRadio_DataGridView_ProtectionRadioData.RowHeadersVisible = false;
            ProtectionRadio_DataGridView_ProtectionRadioData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            ProtectionRadio_DataGridView_ProtectionRadioData.Size = new System.Drawing.Size(470, 360);
            ProtectionRadio_DataGridView_ProtectionRadioData.TabIndex = 19;
            // 
            // ProtectionRadio_Label_ID
            // 
            ProtectionRadio_Label_ID.BackColor = System.Drawing.Color.FromArgb(76, 102, 102);
            ProtectionRadio_Label_ID.Font = new System.Drawing.Font("BIZ UDゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 128);
            ProtectionRadio_Label_ID.ForeColor = System.Drawing.Color.White;
            ProtectionRadio_Label_ID.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            ProtectionRadio_Label_ID.Location = new System.Drawing.Point(33, 409);
            ProtectionRadio_Label_ID.Name = "ProtectionRadio_Label_ID";
            ProtectionRadio_Label_ID.Padding = new System.Windows.Forms.Padding(0, 5, 0, 5);
            ProtectionRadio_Label_ID.Size = new System.Drawing.Size(86, 31);
            ProtectionRadio_Label_ID.TabIndex = 33;
            ProtectionRadio_Label_ID.Text = "ID";
            ProtectionRadio_Label_ID.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ProtectionRadio_NumericUpDown_ID
            // 
            ProtectionRadio_NumericUpDown_ID.Font = new System.Drawing.Font("BIZ UDゴシック", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 128);
            ProtectionRadio_NumericUpDown_ID.Location = new System.Drawing.Point(33, 443);
            ProtectionRadio_NumericUpDown_ID.Name = "ProtectionRadio_NumericUpDown_ID";
            ProtectionRadio_NumericUpDown_ID.Size = new System.Drawing.Size(86, 34);
            ProtectionRadio_NumericUpDown_ID.TabIndex = 32;
            ProtectionRadio_NumericUpDown_ID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // ProtectionRadio_Label_ProtectionZone
            // 
            ProtectionRadio_Label_ProtectionZone.BackColor = System.Drawing.Color.FromArgb(76, 102, 102);
            ProtectionRadio_Label_ProtectionZone.Font = new System.Drawing.Font("BIZ UDゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 128);
            ProtectionRadio_Label_ProtectionZone.ForeColor = System.Drawing.Color.White;
            ProtectionRadio_Label_ProtectionZone.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            ProtectionRadio_Label_ProtectionZone.Location = new System.Drawing.Point(135, 409);
            ProtectionRadio_Label_ProtectionZone.Name = "ProtectionRadio_Label_ProtectionZone";
            ProtectionRadio_Label_ProtectionZone.Padding = new System.Windows.Forms.Padding(0, 5, 0, 5);
            ProtectionRadio_Label_ProtectionZone.Size = new System.Drawing.Size(86, 31);
            ProtectionRadio_Label_ProtectionZone.TabIndex = 35;
            ProtectionRadio_Label_ProtectionZone.Text = "防護ゾーン";
            ProtectionRadio_Label_ProtectionZone.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ProtectionRadio_NumericUpDown_ProtectionZone
            // 
            ProtectionRadio_NumericUpDown_ProtectionZone.Font = new System.Drawing.Font("BIZ UDゴシック", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 128);
            ProtectionRadio_NumericUpDown_ProtectionZone.Location = new System.Drawing.Point(135, 443);
            ProtectionRadio_NumericUpDown_ProtectionZone.Name = "ProtectionRadio_NumericUpDown_ProtectionZone";
            ProtectionRadio_NumericUpDown_ProtectionZone.Size = new System.Drawing.Size(86, 34);
            ProtectionRadio_NumericUpDown_ProtectionZone.TabIndex = 34;
            ProtectionRadio_NumericUpDown_ProtectionZone.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // ProtectionRadio_TextBox_TrainNumber
            // 
            ProtectionRadio_TextBox_TrainNumber.Font = new System.Drawing.Font("BIZ UDゴシック", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 128);
            ProtectionRadio_TextBox_TrainNumber.Location = new System.Drawing.Point(237, 442);
            ProtectionRadio_TextBox_TrainNumber.MaxLength = 7;
            ProtectionRadio_TextBox_TrainNumber.Name = "ProtectionRadio_TextBox_TrainNumber";
            ProtectionRadio_TextBox_TrainNumber.Size = new System.Drawing.Size(220, 34);
            ProtectionRadio_TextBox_TrainNumber.TabIndex = 37;
            ProtectionRadio_TextBox_TrainNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // ProtectionRadio_Label_Title_TrainNumber
            // 
            ProtectionRadio_Label_Title_TrainNumber.BackColor = System.Drawing.Color.FromArgb(76, 102, 102);
            ProtectionRadio_Label_Title_TrainNumber.Font = new System.Drawing.Font("BIZ UDゴシック", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 128);
            ProtectionRadio_Label_Title_TrainNumber.ForeColor = System.Drawing.Color.White;
            ProtectionRadio_Label_Title_TrainNumber.Location = new System.Drawing.Point(237, 412);
            ProtectionRadio_Label_Title_TrainNumber.Name = "ProtectionRadio_Label_Title_TrainNumber";
            ProtectionRadio_Label_Title_TrainNumber.Size = new System.Drawing.Size(220, 28);
            ProtectionRadio_Label_Title_TrainNumber.TabIndex = 36;
            ProtectionRadio_Label_Title_TrainNumber.Text = "列車番号";
            ProtectionRadio_Label_Title_TrainNumber.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ProtectionRadio_Button_Update
            // 
            ProtectionRadio_Button_Update.BackColor = System.Drawing.Color.Aqua;
            ProtectionRadio_Button_Update.FlatAppearance.BorderSize = 0;
            ProtectionRadio_Button_Update.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            ProtectionRadio_Button_Update.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            ProtectionRadio_Button_Update.Font = new System.Drawing.Font("BIZ UDゴシック", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 128);
            ProtectionRadio_Button_Update.ForeColor = System.Drawing.Color.Black;
            ProtectionRadio_Button_Update.Location = new System.Drawing.Point(356, 498);
            ProtectionRadio_Button_Update.Margin = new System.Windows.Forms.Padding(5);
            ProtectionRadio_Button_Update.Name = "ProtectionRadio_Button_Update";
            ProtectionRadio_Button_Update.Size = new System.Drawing.Size(75, 40);
            ProtectionRadio_Button_Update.TabIndex = 40;
            ProtectionRadio_Button_Update.Text = "更新";
            ProtectionRadio_Button_Update.UseVisualStyleBackColor = false;
            ProtectionRadio_Button_Update.Click += ProtectionRadio_Button_Click;
            // 
            // ProtectionRadio_Button_Delete
            // 
            ProtectionRadio_Button_Delete.BackColor = System.Drawing.Color.OrangeRed;
            ProtectionRadio_Button_Delete.FlatAppearance.BorderSize = 0;
            ProtectionRadio_Button_Delete.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            ProtectionRadio_Button_Delete.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            ProtectionRadio_Button_Delete.Font = new System.Drawing.Font("BIZ UDゴシック", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 128);
            ProtectionRadio_Button_Delete.ForeColor = System.Drawing.Color.White;
            ProtectionRadio_Button_Delete.Location = new System.Drawing.Point(38, 498);
            ProtectionRadio_Button_Delete.Margin = new System.Windows.Forms.Padding(5);
            ProtectionRadio_Button_Delete.Name = "ProtectionRadio_Button_Delete";
            ProtectionRadio_Button_Delete.Size = new System.Drawing.Size(75, 40);
            ProtectionRadio_Button_Delete.TabIndex = 39;
            ProtectionRadio_Button_Delete.Text = "削除";
            ProtectionRadio_Button_Delete.UseVisualStyleBackColor = false;
            ProtectionRadio_Button_Delete.Click += ProtectionRadio_Button_Click;
            // 
            // ProtectionRadio_Button_Add
            // 
            ProtectionRadio_Button_Add.BackColor = System.Drawing.Color.Lime;
            ProtectionRadio_Button_Add.FlatAppearance.BorderSize = 0;
            ProtectionRadio_Button_Add.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            ProtectionRadio_Button_Add.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            ProtectionRadio_Button_Add.Font = new System.Drawing.Font("BIZ UDゴシック", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 128);
            ProtectionRadio_Button_Add.ForeColor = System.Drawing.Color.Black;
            ProtectionRadio_Button_Add.Location = new System.Drawing.Point(256, 498);
            ProtectionRadio_Button_Add.Margin = new System.Windows.Forms.Padding(5);
            ProtectionRadio_Button_Add.Name = "ProtectionRadio_Button_Add";
            ProtectionRadio_Button_Add.Size = new System.Drawing.Size(75, 40);
            ProtectionRadio_Button_Add.TabIndex = 38;
            ProtectionRadio_Button_Add.Text = "追加";
            ProtectionRadio_Button_Add.UseVisualStyleBackColor = false;
            ProtectionRadio_Button_Add.Click += ProtectionRadio_Button_Click;
            // 
            // ProtectionRadioForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.FromArgb(76, 102, 102);
            ClientSize = new System.Drawing.Size(494, 561);
            Controls.Add(ProtectionRadio_Button_Update);
            Controls.Add(ProtectionRadio_Button_Delete);
            Controls.Add(ProtectionRadio_Button_Add);
            Controls.Add(ProtectionRadio_TextBox_TrainNumber);
            Controls.Add(ProtectionRadio_Label_Title_TrainNumber);
            Controls.Add(ProtectionRadio_Label_ProtectionZone);
            Controls.Add(ProtectionRadio_NumericUpDown_ProtectionZone);
            Controls.Add(ProtectionRadio_Label_ID);
            Controls.Add(ProtectionRadio_NumericUpDown_ID);
            Controls.Add(ProtectionRadio_DataGridView_ProtectionRadioData);
            Controls.Add(ProtectionRadio_CheckBox_TopMost);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            Name = "ProtectionRadioForm";
            Text = "防護無線設定 | 司令卓 - ダイヤ運転会";
            ((System.ComponentModel.ISupportInitialize)ProtectionRadio_DataGridView_ProtectionRadioData).EndInit();
            ((System.ComponentModel.ISupportInitialize)ProtectionRadio_BindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)ProtectionRadio_NumericUpDown_ID).EndInit();
            ((System.ComponentModel.ISupportInitialize)ProtectionRadio_NumericUpDown_ProtectionZone).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.CheckBox ProtectionRadio_CheckBox_TopMost;
        private System.Windows.Forms.DataGridView ProtectionRadio_DataGridView_ProtectionRadioData;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProtectionZone;
        private System.Windows.Forms.DataGridViewTextBoxColumn TrainNumber;
        private System.Windows.Forms.Label ProtectionRadio_Label_ID;
        private System.Windows.Forms.NumericUpDown ProtectionRadio_NumericUpDown_ID;
        private System.Windows.Forms.Label ProtectionRadio_Label_ProtectionZone;
        private System.Windows.Forms.NumericUpDown ProtectionRadio_NumericUpDown_ProtectionZone;
        private System.Windows.Forms.TextBox ProtectionRadio_TextBox_TrainNumber;
        private System.Windows.Forms.Label ProtectionRadio_Label_Title_TrainNumber;
        private System.Windows.Forms.BindingSource ProtectionRadio_BindingSource;
        private System.Windows.Forms.Button ProtectionRadio_Button_Update;
        private System.Windows.Forms.Button ProtectionRadio_Button_Delete;
        private System.Windows.Forms.Button ProtectionRadio_Button_Add;
    }
}