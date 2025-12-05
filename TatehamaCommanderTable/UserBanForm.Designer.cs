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
            UserBan_CheckBox_TopMost = new System.Windows.Forms.CheckBox();
            UserBan_GroupBox_BanUser = new System.Windows.Forms.GroupBox();
            UserBan_NumericUpDown_UserId = new System.Windows.Forms.NumericUpDown();
            UserBan_Label_UserId = new System.Windows.Forms.Label();
            UserBan_Button_Ban = new System.Windows.Forms.Button();
            UserBan_Button_Unban = new System.Windows.Forms.Button();
            UserBan_Label_BannedUsers = new System.Windows.Forms.Label();
            UserBan_GroupBox_BanUser.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)UserBan_NumericUpDown_UserId).BeginInit();
            SuspendLayout();
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
            // UserBan_GroupBox_BanUser
            //
            UserBan_GroupBox_BanUser.Controls.Add(UserBan_NumericUpDown_UserId);
            UserBan_GroupBox_BanUser.Controls.Add(UserBan_Label_UserId);
            UserBan_GroupBox_BanUser.Controls.Add(UserBan_Button_Ban);
            UserBan_GroupBox_BanUser.Controls.Add(UserBan_Button_Unban);
            UserBan_GroupBox_BanUser.Font = new System.Drawing.Font("BIZ UDゴシック", 9F);
            UserBan_GroupBox_BanUser.ForeColor = System.Drawing.Color.White;
            UserBan_GroupBox_BanUser.Location = new System.Drawing.Point(12, 100);
            UserBan_GroupBox_BanUser.Name = "UserBan_GroupBox_BanUser";
            UserBan_GroupBox_BanUser.Size = new System.Drawing.Size(360, 85);
            UserBan_GroupBox_BanUser.TabIndex = 22;
            UserBan_GroupBox_BanUser.TabStop = false;
            UserBan_GroupBox_BanUser.Text = "ユーザーID操作";
            //
            // UserBan_NumericUpDown_UserId
            //
            UserBan_NumericUpDown_UserId.Font = new System.Drawing.Font("BIZ UDゴシック", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 128);
            UserBan_NumericUpDown_UserId.Location = new System.Drawing.Point(54, 28);
            UserBan_NumericUpDown_UserId.Maximum = new decimal(new int[] { 1316134911, 2328, 0, 0 });
            UserBan_NumericUpDown_UserId.Name = "UserBan_NumericUpDown_UserId";
            UserBan_NumericUpDown_UserId.Size = new System.Drawing.Size(180, 31);
            UserBan_NumericUpDown_UserId.TabIndex = 31;
            UserBan_NumericUpDown_UserId.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            //
            // UserBan_Label_UserId
            //
            UserBan_Label_UserId.Font = new System.Drawing.Font("BIZ UDゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 128);
            UserBan_Label_UserId.Location = new System.Drawing.Point(240, 28);
            UserBan_Label_UserId.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            UserBan_Label_UserId.Name = "UserBan_Label_UserId";
            UserBan_Label_UserId.Size = new System.Drawing.Size(66, 32);
            UserBan_Label_UserId.TabIndex = 24;
            UserBan_Label_UserId.Text = "(Discord)";
            UserBan_Label_UserId.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // UserBan_Button_Ban
            //
            UserBan_Button_Ban.BackColor = System.Drawing.Color.Red;
            UserBan_Button_Ban.FlatAppearance.BorderSize = 0;
            UserBan_Button_Ban.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            UserBan_Button_Ban.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            UserBan_Button_Ban.Font = new System.Drawing.Font("BIZ UDゴシック", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 128);
            UserBan_Button_Ban.ForeColor = System.Drawing.Color.White;
            UserBan_Button_Ban.Location = new System.Drawing.Point(14, 23);
            UserBan_Button_Ban.Margin = new System.Windows.Forms.Padding(5);
            UserBan_Button_Ban.Name = "UserBan_Button_Ban";
            UserBan_Button_Ban.Size = new System.Drawing.Size(115, 40);
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
            UserBan_Button_Unban.Location = new System.Drawing.Point(139, 23);
            UserBan_Button_Unban.Margin = new System.Windows.Forms.Padding(5);
            UserBan_Button_Unban.Name = "UserBan_Button_Unban";
            UserBan_Button_Unban.Size = new System.Drawing.Size(115, 40);
            UserBan_Button_Unban.TabIndex = 25;
            UserBan_Button_Unban.Text = "解除";
            UserBan_Button_Unban.UseVisualStyleBackColor = false;
            UserBan_Button_Unban.Click += UserBan_Button_Click;
            //
            // UserBan_Label_BannedUsers
            //
            UserBan_Label_BannedUsers.Font = new System.Drawing.Font("BIZ UDゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 128);
            UserBan_Label_BannedUsers.ForeColor = System.Drawing.Color.White;
            UserBan_Label_BannedUsers.Location = new System.Drawing.Point(13, 50);
            UserBan_Label_BannedUsers.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            UserBan_Label_BannedUsers.Name = "UserBan_Label_BannedUsers";
            UserBan_Label_BannedUsers.Size = new System.Drawing.Size(359, 35);
            UserBan_Label_BannedUsers.TabIndex = 25;
            UserBan_Label_BannedUsers.Text = "BANユーザー: なし";
            UserBan_Label_BannedUsers.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // UserBanForm
            //
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.FromArgb(76, 102, 102);
            ClientSize = new System.Drawing.Size(384, 201);
            Controls.Add(UserBan_Label_BannedUsers);
            Controls.Add(UserBan_GroupBox_BanUser);
            Controls.Add(UserBan_CheckBox_TopMost);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            Name = "UserBanForm";
            Text = "ユーザーBAN管理 | 司令卓 - ダイヤ運転会";
            UserBan_GroupBox_BanUser.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)UserBan_NumericUpDown_UserId).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.CheckBox UserBan_CheckBox_TopMost;
        private System.Windows.Forms.GroupBox UserBan_GroupBox_BanUser;
        private System.Windows.Forms.Button UserBan_Button_Ban;
        private System.Windows.Forms.Button UserBan_Button_Unban;
        private System.Windows.Forms.Label UserBan_Label_UserId;
        private System.Windows.Forms.NumericUpDown UserBan_NumericUpDown_UserId;
        private System.Windows.Forms.Label UserBan_Label_BannedUsers;
    }
}
