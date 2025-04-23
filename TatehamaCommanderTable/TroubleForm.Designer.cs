namespace TatehamaCommanderTable
{
    partial class TroubleForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TroubleForm));
            Trouble_CheckBox_TopMost = new System.Windows.Forms.CheckBox();
            Trouble_GroupBox_Setting = new System.Windows.Forms.GroupBox();
            Trouble_RadioButton_Tokuhatsu = new System.Windows.Forms.RadioButton();
            Trouble_ComboBox_SelectTokuhatsu = new System.Windows.Forms.ComboBox();
            Trouble_Label_TokuhatsuSelect = new System.Windows.Forms.Label();
            Trouble_Label_SettingList = new System.Windows.Forms.Label();
            Trouble_DataGridView_TroubleData = new System.Windows.Forms.DataGridView();
            Trouble_BindingSource = new System.Windows.Forms.BindingSource(components);
            Trouble_Button_Set = new System.Windows.Forms.Button();
            Trouble_Button_Cansel = new System.Windows.Forms.Button();
            troubleType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            placeType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            placeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            occuredAt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            additionalData = new System.Windows.Forms.DataGridViewTextBoxColumn();
            Trouble_GroupBox_Setting.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)Trouble_DataGridView_TroubleData).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Trouble_BindingSource).BeginInit();
            SuspendLayout();
            // 
            // Trouble_CheckBox_TopMost
            // 
            Trouble_CheckBox_TopMost.AutoSize = true;
            Trouble_CheckBox_TopMost.Font = new System.Drawing.Font("BIZ UDゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 128);
            Trouble_CheckBox_TopMost.ForeColor = System.Drawing.Color.White;
            Trouble_CheckBox_TopMost.Location = new System.Drawing.Point(670, 15);
            Trouble_CheckBox_TopMost.Name = "Trouble_CheckBox_TopMost";
            Trouble_CheckBox_TopMost.Size = new System.Drawing.Size(101, 19);
            Trouble_CheckBox_TopMost.TabIndex = 10;
            Trouble_CheckBox_TopMost.Text = "最前面表示";
            Trouble_CheckBox_TopMost.UseVisualStyleBackColor = true;
            Trouble_CheckBox_TopMost.CheckedChanged += Trouble_CheckBox_TopMost_CheckedChanged;
            // 
            // Trouble_GroupBox_Setting
            // 
            Trouble_GroupBox_Setting.Controls.Add(Trouble_RadioButton_Tokuhatsu);
            Trouble_GroupBox_Setting.Font = new System.Drawing.Font("BIZ UDゴシック", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 128);
            Trouble_GroupBox_Setting.ForeColor = System.Drawing.Color.White;
            Trouble_GroupBox_Setting.Location = new System.Drawing.Point(13, 290);
            Trouble_GroupBox_Setting.Name = "Trouble_GroupBox_Setting";
            Trouble_GroupBox_Setting.Size = new System.Drawing.Size(449, 70);
            Trouble_GroupBox_Setting.TabIndex = 11;
            Trouble_GroupBox_Setting.TabStop = false;
            Trouble_GroupBox_Setting.Text = "支障パターン";
            // 
            // Trouble_RadioButton_Tokuhatsu
            // 
            Trouble_RadioButton_Tokuhatsu.Appearance = System.Windows.Forms.Appearance.Button;
            Trouble_RadioButton_Tokuhatsu.BackColor = System.Drawing.Color.White;
            Trouble_RadioButton_Tokuhatsu.Checked = true;
            Trouble_RadioButton_Tokuhatsu.FlatAppearance.BorderSize = 0;
            Trouble_RadioButton_Tokuhatsu.FlatAppearance.CheckedBackColor = System.Drawing.Color.Gold;
            Trouble_RadioButton_Tokuhatsu.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gold;
            Trouble_RadioButton_Tokuhatsu.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gold;
            Trouble_RadioButton_Tokuhatsu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            Trouble_RadioButton_Tokuhatsu.Font = new System.Drawing.Font("BIZ UDゴシック", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 128);
            Trouble_RadioButton_Tokuhatsu.ForeColor = System.Drawing.Color.Black;
            Trouble_RadioButton_Tokuhatsu.Location = new System.Drawing.Point(8, 20);
            Trouble_RadioButton_Tokuhatsu.Margin = new System.Windows.Forms.Padding(5);
            Trouble_RadioButton_Tokuhatsu.Name = "Trouble_RadioButton_Tokuhatsu";
            Trouble_RadioButton_Tokuhatsu.Size = new System.Drawing.Size(100, 40);
            Trouble_RadioButton_Tokuhatsu.TabIndex = 1;
            Trouble_RadioButton_Tokuhatsu.TabStop = true;
            Trouble_RadioButton_Tokuhatsu.Text = "特発動作";
            Trouble_RadioButton_Tokuhatsu.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            Trouble_RadioButton_Tokuhatsu.UseVisualStyleBackColor = false;
            // 
            // Trouble_ComboBox_SelectTokuhatsu
            // 
            Trouble_ComboBox_SelectTokuhatsu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            Trouble_ComboBox_SelectTokuhatsu.Font = new System.Drawing.Font("BIZ UDゴシック", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 128);
            Trouble_ComboBox_SelectTokuhatsu.FormattingEnabled = true;
            Trouble_ComboBox_SelectTokuhatsu.Location = new System.Drawing.Point(77, 371);
            Trouble_ComboBox_SelectTokuhatsu.Margin = new System.Windows.Forms.Padding(8);
            Trouble_ComboBox_SelectTokuhatsu.Name = "Trouble_ComboBox_SelectTokuhatsu";
            Trouble_ComboBox_SelectTokuhatsu.Size = new System.Drawing.Size(226, 27);
            Trouble_ComboBox_SelectTokuhatsu.TabIndex = 13;
            // 
            // Trouble_Label_TokuhatsuSelect
            // 
            Trouble_Label_TokuhatsuSelect.Font = new System.Drawing.Font("BIZ UDゴシック", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 128);
            Trouble_Label_TokuhatsuSelect.ForeColor = System.Drawing.Color.White;
            Trouble_Label_TokuhatsuSelect.Location = new System.Drawing.Point(13, 371);
            Trouble_Label_TokuhatsuSelect.Name = "Trouble_Label_TokuhatsuSelect";
            Trouble_Label_TokuhatsuSelect.Size = new System.Drawing.Size(53, 27);
            Trouble_Label_TokuhatsuSelect.TabIndex = 14;
            Trouble_Label_TokuhatsuSelect.Text = "特発";
            Trouble_Label_TokuhatsuSelect.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Trouble_Label_SettingList
            // 
            Trouble_Label_SettingList.Font = new System.Drawing.Font("BIZ UDゴシック", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 128);
            Trouble_Label_SettingList.ForeColor = System.Drawing.Color.White;
            Trouble_Label_SettingList.Location = new System.Drawing.Point(13, 9);
            Trouble_Label_SettingList.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            Trouble_Label_SettingList.Name = "Trouble_Label_SettingList";
            Trouble_Label_SettingList.Size = new System.Drawing.Size(175, 28);
            Trouble_Label_SettingList.TabIndex = 15;
            Trouble_Label_SettingList.Text = "設定中の運転支障一覧";
            Trouble_Label_SettingList.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Trouble_DataGridView_TroubleData
            // 
            Trouble_DataGridView_TroubleData.AllowUserToAddRows = false;
            Trouble_DataGridView_TroubleData.AllowUserToDeleteRows = false;
            Trouble_DataGridView_TroubleData.AllowUserToResizeColumns = false;
            Trouble_DataGridView_TroubleData.AllowUserToResizeRows = false;
            Trouble_DataGridView_TroubleData.AutoGenerateColumns = false;
            Trouble_DataGridView_TroubleData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            Trouble_DataGridView_TroubleData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { troubleType, placeType, placeName, occuredAt, additionalData });
            Trouble_DataGridView_TroubleData.DataSource = Trouble_BindingSource;
            Trouble_DataGridView_TroubleData.Location = new System.Drawing.Point(13, 40);
            Trouble_DataGridView_TroubleData.Name = "Trouble_DataGridView_TroubleData";
            Trouble_DataGridView_TroubleData.RowHeadersVisible = false;
            Trouble_DataGridView_TroubleData.Size = new System.Drawing.Size(760, 244);
            Trouble_DataGridView_TroubleData.TabIndex = 16;
            // 
            // Trouble_Button_Set
            // 
            Trouble_Button_Set.BackColor = System.Drawing.Color.Lime;
            Trouble_Button_Set.FlatAppearance.BorderSize = 0;
            Trouble_Button_Set.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            Trouble_Button_Set.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            Trouble_Button_Set.Font = new System.Drawing.Font("BIZ UDゴシック", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 128);
            Trouble_Button_Set.ForeColor = System.Drawing.Color.Black;
            Trouble_Button_Set.Location = new System.Drawing.Point(624, 310);
            Trouble_Button_Set.Margin = new System.Windows.Forms.Padding(5);
            Trouble_Button_Set.Name = "Trouble_Button_Set";
            Trouble_Button_Set.Size = new System.Drawing.Size(75, 40);
            Trouble_Button_Set.TabIndex = 19;
            Trouble_Button_Set.Text = "設定";
            Trouble_Button_Set.UseVisualStyleBackColor = false;
            Trouble_Button_Set.Click += Trouble_Button_Click;
            // 
            // Trouble_Button_Cansel
            // 
            Trouble_Button_Cansel.BackColor = System.Drawing.Color.OrangeRed;
            Trouble_Button_Cansel.FlatAppearance.BorderSize = 0;
            Trouble_Button_Cansel.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            Trouble_Button_Cansel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            Trouble_Button_Cansel.Font = new System.Drawing.Font("BIZ UDゴシック", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 128);
            Trouble_Button_Cansel.ForeColor = System.Drawing.Color.White;
            Trouble_Button_Cansel.Location = new System.Drawing.Point(539, 310);
            Trouble_Button_Cansel.Margin = new System.Windows.Forms.Padding(5);
            Trouble_Button_Cansel.Name = "Trouble_Button_Cansel";
            Trouble_Button_Cansel.Size = new System.Drawing.Size(75, 40);
            Trouble_Button_Cansel.TabIndex = 18;
            Trouble_Button_Cansel.Text = "削除";
            Trouble_Button_Cansel.UseVisualStyleBackColor = false;
            Trouble_Button_Cansel.Click += Trouble_Button_Click;
            // 
            // troubleType
            // 
            troubleType.HeaderText = "支障";
            troubleType.MaxInputLength = 20;
            troubleType.Name = "troubleType";
            troubleType.ReadOnly = true;
            troubleType.Width = 200;
            // 
            // placeType
            // 
            placeType.HeaderText = "分類";
            placeType.MaxInputLength = 20;
            placeType.Name = "placeType";
            placeType.ReadOnly = true;
            // 
            // placeName
            // 
            placeName.HeaderText = "場所名称";
            placeName.MaxInputLength = 20;
            placeName.Name = "placeName";
            placeName.ReadOnly = true;
            placeName.Width = 150;
            // 
            // occuredAt
            // 
            occuredAt.HeaderText = "発生時刻";
            occuredAt.MaxInputLength = 20;
            occuredAt.Name = "occuredAt";
            occuredAt.ReadOnly = true;
            occuredAt.Width = 140;
            // 
            // additionalData
            // 
            additionalData.HeaderText = "補足情報";
            additionalData.MaxInputLength = 20;
            additionalData.Name = "additionalData";
            additionalData.ReadOnly = true;
            additionalData.Width = 150;
            // 
            // TroubleForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.FromArgb(76, 102, 102);
            ClientSize = new System.Drawing.Size(784, 561);
            Controls.Add(Trouble_Button_Set);
            Controls.Add(Trouble_Button_Cansel);
            Controls.Add(Trouble_DataGridView_TroubleData);
            Controls.Add(Trouble_Label_SettingList);
            Controls.Add(Trouble_Label_TokuhatsuSelect);
            Controls.Add(Trouble_ComboBox_SelectTokuhatsu);
            Controls.Add(Trouble_GroupBox_Setting);
            Controls.Add(Trouble_CheckBox_TopMost);
            Font = new System.Drawing.Font("Yu Gothic UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            MaximizeBox = false;
            Name = "TroubleForm";
            Text = "運転支障 | 司令卓 - ダイヤ運転会";
            Trouble_GroupBox_Setting.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)Trouble_DataGridView_TroubleData).EndInit();
            ((System.ComponentModel.ISupportInitialize)Trouble_BindingSource).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.CheckBox Trouble_CheckBox_TopMost;
        private System.Windows.Forms.GroupBox Trouble_GroupBox_Setting;
        private System.Windows.Forms.ComboBox Trouble_ComboBox_SelectTokuhatsu;
        private System.Windows.Forms.Label Trouble_Label_TokuhatsuSelect;
        private System.Windows.Forms.RadioButton Trouble_RadioButton_Tokuhatsu;
        private System.Windows.Forms.Label Trouble_Label_SettingList;
        private System.Windows.Forms.DataGridView Trouble_DataGridView_TroubleData;
        private System.Windows.Forms.BindingSource Trouble_BindingSource;
        private System.Windows.Forms.Button Trouble_Button_Set;
        private System.Windows.Forms.Button Trouble_Button_Cansel;
        private System.Windows.Forms.DataGridViewTextBoxColumn troubleType;
        private System.Windows.Forms.DataGridViewTextBoxColumn placeType;
        private System.Windows.Forms.DataGridViewTextBoxColumn placeName;
        private System.Windows.Forms.DataGridViewTextBoxColumn occuredAt;
        private System.Windows.Forms.DataGridViewTextBoxColumn additionalData;
    }
}