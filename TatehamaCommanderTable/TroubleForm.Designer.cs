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
            Trouble_CheckBox_TopMost = new System.Windows.Forms.CheckBox();
            groupBox1 = new System.Windows.Forms.GroupBox();
            radioButton1 = new System.Windows.Forms.RadioButton();
            Trouble_ListBox_SettingList = new System.Windows.Forms.ListBox();
            Kokuchi_ComboBox_KokuchiSelect = new System.Windows.Forms.ComboBox();
            label1 = new System.Windows.Forms.Label();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // Trouble_CheckBox_TopMost
            // 
            Trouble_CheckBox_TopMost.AutoSize = true;
            Trouble_CheckBox_TopMost.Font = new System.Drawing.Font("BIZ UDゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 128);
            Trouble_CheckBox_TopMost.ForeColor = System.Drawing.Color.White;
            Trouble_CheckBox_TopMost.Location = new System.Drawing.Point(670, 260);
            Trouble_CheckBox_TopMost.Name = "Trouble_CheckBox_TopMost";
            Trouble_CheckBox_TopMost.Size = new System.Drawing.Size(101, 19);
            Trouble_CheckBox_TopMost.TabIndex = 10;
            Trouble_CheckBox_TopMost.Text = "最前面表示";
            Trouble_CheckBox_TopMost.UseVisualStyleBackColor = true;
            Trouble_CheckBox_TopMost.CheckedChanged += Trouble_CheckBox_TopMost_CheckedChanged;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(radioButton1);
            groupBox1.Font = new System.Drawing.Font("BIZ UDゴシック", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 128);
            groupBox1.ForeColor = System.Drawing.Color.White;
            groupBox1.Location = new System.Drawing.Point(11, 260);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new System.Drawing.Size(393, 108);
            groupBox1.TabIndex = 11;
            groupBox1.TabStop = false;
            groupBox1.Text = "支障パターン";
            // 
            // radioButton1
            // 
            radioButton1.AutoSize = true;
            radioButton1.Checked = true;
            radioButton1.Location = new System.Drawing.Point(49, 27);
            radioButton1.Margin = new System.Windows.Forms.Padding(8);
            radioButton1.Name = "radioButton1";
            radioButton1.Size = new System.Drawing.Size(89, 20);
            radioButton1.TabIndex = 0;
            radioButton1.TabStop = true;
            radioButton1.Text = "特発動作";
            radioButton1.UseVisualStyleBackColor = true;
            // 
            // Trouble_ListBox_SettingList
            // 
            Trouble_ListBox_SettingList.Font = new System.Drawing.Font("BIZ UDゴシック", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 128);
            Trouble_ListBox_SettingList.FormattingEnabled = true;
            Trouble_ListBox_SettingList.Location = new System.Drawing.Point(11, 11);
            Trouble_ListBox_SettingList.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            Trouble_ListBox_SettingList.Name = "Trouble_ListBox_SettingList";
            Trouble_ListBox_SettingList.Size = new System.Drawing.Size(760, 244);
            Trouble_ListBox_SettingList.TabIndex = 12;
            // 
            // Kokuchi_ComboBox_KokuchiSelect
            // 
            Kokuchi_ComboBox_KokuchiSelect.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            Kokuchi_ComboBox_KokuchiSelect.Font = new System.Drawing.Font("BIZ UDゴシック", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 128);
            Kokuchi_ComboBox_KokuchiSelect.FormattingEnabled = true;
            Kokuchi_ComboBox_KokuchiSelect.Location = new System.Drawing.Point(76, 380);
            Kokuchi_ComboBox_KokuchiSelect.Margin = new System.Windows.Forms.Padding(8);
            Kokuchi_ComboBox_KokuchiSelect.Name = "Kokuchi_ComboBox_KokuchiSelect";
            Kokuchi_ComboBox_KokuchiSelect.Size = new System.Drawing.Size(226, 27);
            Kokuchi_ComboBox_KokuchiSelect.TabIndex = 13;
            // 
            // label1
            // 
            label1.Font = new System.Drawing.Font("BIZ UDゴシック", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 128);
            label1.ForeColor = System.Drawing.Color.White;
            label1.Location = new System.Drawing.Point(12, 380);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(53, 27);
            label1.TabIndex = 14;
            label1.Text = "特発";
            label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TroubleForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.FromArgb(76, 102, 102);
            ClientSize = new System.Drawing.Size(784, 561);
            Controls.Add(label1);
            Controls.Add(Kokuchi_ComboBox_KokuchiSelect);
            Controls.Add(Trouble_ListBox_SettingList);
            Controls.Add(groupBox1);
            Controls.Add(Trouble_CheckBox_TopMost);
            Font = new System.Drawing.Font("Yu Gothic UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            MaximizeBox = false;
            Name = "TroubleForm";
            Text = "運転支障 | 司令卓 - ダイヤ運転会";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.CheckBox Trouble_CheckBox_TopMost;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListBox Trouble_ListBox_SettingList;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.ComboBox Kokuchi_ComboBox_KokuchiSelect;
        private System.Windows.Forms.Label label1;
    }
}