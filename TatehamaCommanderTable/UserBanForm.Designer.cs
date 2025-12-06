namespace TatehamaCommanderTable
{
    partial class UserBanForm
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
            UserId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            UserBan_CheckBox_TopMost = new System.Windows.Forms.CheckBox();
            UserBan_DataGridView_BannedUsers = new System.Windows.Forms.DataGridView();
            UserBan_BindingSource = new System.Windows.Forms.BindingSource(components);
            UserBan_Label_UserId = new System.Windows.Forms.Label();
            UserBan_NumericUpDown_UserId = new System.Windows.Forms.NumericUpDown();
            UserBan_Button_Ban = new System.Windows.Forms.Button();
            UserBan_Button_Unban = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)UserBan_DataGridView_BannedUsers).BeginInit();
            ((System.ComponentModel.ISupportInitialize)UserBan_BindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)UserBan_NumericUpDown_UserId).BeginInit();
            SuspendLayout();
            //
            // UserId
            //
            UserId.DataPropertyName = "UserId";
            UserId.HeaderText = "ユーザーID";
            UserId.MaxInputLength = 20;
            UserId.Name = "UserId";
            UserId.ReadOnly = true;
            UserId.Width = 200;
            //
            // UserBan_CheckBox_TopMost
            //
            UserBan_CheckBox_TopMost.AutoSize = true;
            UserBan_CheckBox_TopMost.Font = new System.Drawing.Font("BIZ UDゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 128);
            UserBan_CheckBox_TopMost.ForeColor = System.Drawing.Color.White;
            UserBan_CheckBox_TopMost.Location = new System.Drawing.Point(271, 12);
            UserBan_CheckBox_TopMost.Name = "UserBan_CheckBox_TopMost";
            UserBan_CheckBox_TopMost.Size = new System.Drawing.Size(101, 19);
            UserBan_CheckBox_TopMost.TabIndex = 21;
            UserBan_CheckBox_TopMost.Text = "最前面表示";
            UserBan_CheckBox_TopMost.UseVisualStyleBackColor = true;
            UserBan_CheckBox_TopMost.CheckedChanged += UserBan_CheckBox_TopMost_CheckedChanged;
            //
            // UserBan_DataGridView_BannedUsers
            //
            UserBan_DataGridView_BannedUsers.AllowUserToAddRows = false;
            UserBan_DataGridView_BannedUsers.AllowUserToDeleteRows = false;
            UserBan_DataGridView_BannedUsers.AllowUserToResizeColumns = false;
            UserBan_DataGridView_BannedUsers.AllowUserToResizeRows = false;
            UserBan_DataGridView_BannedUsers.AutoGenerateColumns = false;
            UserBan_DataGridView_BannedUsers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            UserBan_DataGridView_BannedUsers.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { UserId });
            UserBan_DataGridView_BannedUsers.DataSource = UserBan_BindingSource;
            UserBan_DataGridView_BannedUsers.Location = new System.Drawing.Point(12, 37);
            UserBan_DataGridView_BannedUsers.Name = "UserBan_DataGridView_BannedUsers";
            UserBan_DataGridView_BannedUsers.ReadOnly = true;
            UserBan_DataGridView_BannedUsers.RowHeadersVisible = false;
            UserBan_DataGridView_BannedUsers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            UserBan_DataGridView_BannedUsers.Size = new System.Drawing.Size(360, 300);
            UserBan_DataGridView_BannedUsers.TabIndex = 19;
            //
            // UserBan_Label_UserId
            //
            UserBan_Label_UserId.BackColor = System.Drawing.Color.FromArgb(76, 102, 102);
            UserBan_Label_UserId.Font = new System.Drawing.Font("BIZ UDゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 128);
            UserBan_Label_UserId.ForeColor = System.Drawing.Color.White;
            UserBan_Label_UserId.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            UserBan_Label_UserId.Location = new System.Drawing.Point(12, 350);
            UserBan_Label_UserId.Name = "UserBan_Label_UserId";
            UserBan_Label_UserId.Padding = new System.Windows.Forms.Padding(0, 5, 0, 5);
            UserBan_Label_UserId.Size = new System.Drawing.Size(180, 31);
            UserBan_Label_UserId.TabIndex = 33;
            UserBan_Label_UserId.Text = "ユーザーID (Discord)";
            UserBan_Label_UserId.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // UserBan_NumericUpDown_UserId
            //
            UserBan_NumericUpDown_UserId.Font = new System.Drawing.Font("BIZ UDゴシック", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 128);
            UserBan_NumericUpDown_UserId.Location = new System.Drawing.Point(12, 384);
            UserBan_NumericUpDown_UserId.Maximum = new decimal(ulong.MaxValue);
            UserBan_NumericUpDown_UserId.Name = "UserBan_NumericUpDown_UserId";
            UserBan_NumericUpDown_UserId.Size = new System.Drawing.Size(180, 31);
            UserBan_NumericUpDown_UserId.TabIndex = 31;
            UserBan_NumericUpDown_UserId.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            //
            // UserBan_Button_Ban
            //
            UserBan_Button_Ban.BackColor = System.Drawing.Color.Red;
            UserBan_Button_Ban.FlatAppearance.BorderSize = 0;
            UserBan_Button_Ban.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            UserBan_Button_Ban.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            UserBan_Button_Ban.Font = new System.Drawing.Font("BIZ UDゴシック", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 128);
            UserBan_Button_Ban.ForeColor = System.Drawing.Color.White;
            UserBan_Button_Ban.Location = new System.Drawing.Point(212, 350);
            UserBan_Button_Ban.Margin = new System.Windows.Forms.Padding(5);
            UserBan_Button_Ban.Name = "UserBan_Button_Ban";
            UserBan_Button_Ban.Size = new System.Drawing.Size(75, 65);
            UserBan_Button_Ban.TabIndex = 24;
            UserBan_Button_Ban.Text = "BAN";
            UserBan_Button_Ban.UseVisualStyleBackColor = false;
            UserBan_Button_Ban.Click += UserBan_Button_Click;
            //
            // UserBan_Button_Unban
            //
            UserBan_Button_Unban.BackColor = System.Drawing.Color.Lime;
            UserBan_Button_Unban.FlatAppearance.BorderSize = 0;
            UserBan_Button_Unban.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            UserBan_Button_Unban.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            UserBan_Button_Unban.Font = new System.Drawing.Font("BIZ UDゴシック", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 128);
            UserBan_Button_Unban.ForeColor = System.Drawing.Color.Black;
            UserBan_Button_Unban.Location = new System.Drawing.Point(297, 350);
            UserBan_Button_Unban.Margin = new System.Windows.Forms.Padding(5);
            UserBan_Button_Unban.Name = "UserBan_Button_Unban";
            UserBan_Button_Unban.Size = new System.Drawing.Size(75, 65);
            UserBan_Button_Unban.TabIndex = 25;
            UserBan_Button_Unban.Text = "BAN\r\n解除";
            UserBan_Button_Unban.UseVisualStyleBackColor = false;
            UserBan_Button_Unban.Click += UserBan_Button_Click;
            //
            // UserBanForm
            //
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.FromArgb(76, 102, 102);
            ClientSize = new System.Drawing.Size(384, 431);
            Controls.Add(UserBan_Button_Unban);
            Controls.Add(UserBan_Button_Ban);
            Controls.Add(UserBan_Label_UserId);
            Controls.Add(UserBan_NumericUpDown_UserId);
            Controls.Add(UserBan_DataGridView_BannedUsers);
            Controls.Add(UserBan_CheckBox_TopMost);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            Name = "UserBanForm";
            Text = "強制切断 | 司令卓 - ダイヤ運転会";
            ((System.ComponentModel.ISupportInitialize)UserBan_DataGridView_BannedUsers).EndInit();
            ((System.ComponentModel.ISupportInitialize)UserBan_BindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)UserBan_NumericUpDown_UserId).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.CheckBox UserBan_CheckBox_TopMost;
        private System.Windows.Forms.DataGridView UserBan_DataGridView_BannedUsers;
        private System.Windows.Forms.BindingSource UserBan_BindingSource;
        private System.Windows.Forms.Button UserBan_Button_Ban;
        private System.Windows.Forms.Button UserBan_Button_Unban;
        private System.Windows.Forms.Label UserBan_Label_UserId;
        private System.Windows.Forms.NumericUpDown UserBan_NumericUpDown_UserId;
        private System.Windows.Forms.DataGridViewTextBoxColumn UserId;
    }
}
