namespace TatehamaCommanderTable
{
    partial class TimeOffsetForm
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
            TimeOffset_CheckBox_TopMost = new System.Windows.Forms.CheckBox();
            TimeOffset_GroupBox_OffsetHour = new System.Windows.Forms.GroupBox();
            TimeOffset_NumericUpDown_OffsetHour = new System.Windows.Forms.NumericUpDown();
            TimeOffset_Label_OffsetHour = new System.Windows.Forms.Label();
            TimeOffset_Button_OffsetHour = new System.Windows.Forms.Button();
            TimeOffset_GroupBox_SetHour = new System.Windows.Forms.GroupBox();
            TimeOffset_NumericUpDown_SetHour = new System.Windows.Forms.NumericUpDown();
            TimeOffset_Label_SetHour = new System.Windows.Forms.Label();
            TimeOffset_Button_SetHour = new System.Windows.Forms.Button();
            TimeOffset_Label_NowOffsetHour = new System.Windows.Forms.Label();
            TimeOffset_Button_GetOffset = new System.Windows.Forms.Button();
            TimeOffset_GroupBox_OffsetHour.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)TimeOffset_NumericUpDown_OffsetHour).BeginInit();
            TimeOffset_GroupBox_SetHour.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)TimeOffset_NumericUpDown_SetHour).BeginInit();
            SuspendLayout();
            // 
            // TimeOffset_CheckBox_TopMost
            // 
            TimeOffset_CheckBox_TopMost.AutoSize = true;
            TimeOffset_CheckBox_TopMost.Font = new System.Drawing.Font("BIZ UDゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 128);
            TimeOffset_CheckBox_TopMost.ForeColor = System.Drawing.Color.White;
            TimeOffset_CheckBox_TopMost.Location = new System.Drawing.Point(271, 12);
            TimeOffset_CheckBox_TopMost.Name = "TimeOffset_CheckBox_TopMost";
            TimeOffset_CheckBox_TopMost.Size = new System.Drawing.Size(101, 19);
            TimeOffset_CheckBox_TopMost.TabIndex = 21;
            TimeOffset_CheckBox_TopMost.Text = "最前面表示";
            TimeOffset_CheckBox_TopMost.UseVisualStyleBackColor = true;
            TimeOffset_CheckBox_TopMost.CheckedChanged += TimeOffset_CheckBox_TopMost_CheckedChanged;
            // 
            // TimeOffset_GroupBox_OffsetHour
            // 
            TimeOffset_GroupBox_OffsetHour.Controls.Add(TimeOffset_NumericUpDown_OffsetHour);
            TimeOffset_GroupBox_OffsetHour.Controls.Add(TimeOffset_Label_OffsetHour);
            TimeOffset_GroupBox_OffsetHour.Controls.Add(TimeOffset_Button_OffsetHour);
            TimeOffset_GroupBox_OffsetHour.Font = new System.Drawing.Font("BIZ UDゴシック", 9F);
            TimeOffset_GroupBox_OffsetHour.ForeColor = System.Drawing.Color.White;
            TimeOffset_GroupBox_OffsetHour.Location = new System.Drawing.Point(12, 121);
            TimeOffset_GroupBox_OffsetHour.Name = "TimeOffset_GroupBox_OffsetHour";
            TimeOffset_GroupBox_OffsetHour.Size = new System.Drawing.Size(360, 75);
            TimeOffset_GroupBox_OffsetHour.TabIndex = 22;
            TimeOffset_GroupBox_OffsetHour.TabStop = false;
            TimeOffset_GroupBox_OffsetHour.Text = "時差を指定";
            // 
            // TimeOffset_NumericUpDown_OffsetHour
            // 
            TimeOffset_NumericUpDown_OffsetHour.Font = new System.Drawing.Font("BIZ UDゴシック", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 128);
            TimeOffset_NumericUpDown_OffsetHour.Location = new System.Drawing.Point(54, 23);
            TimeOffset_NumericUpDown_OffsetHour.Maximum = new decimal(new int[] { 23, 0, 0, 0 });
            TimeOffset_NumericUpDown_OffsetHour.Minimum = new decimal(new int[] { 23, 0, 0, int.MinValue });
            TimeOffset_NumericUpDown_OffsetHour.Name = "TimeOffset_NumericUpDown_OffsetHour";
            TimeOffset_NumericUpDown_OffsetHour.Size = new System.Drawing.Size(76, 34);
            TimeOffset_NumericUpDown_OffsetHour.TabIndex = 31;
            TimeOffset_NumericUpDown_OffsetHour.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // TimeOffset_Label_OffsetHour
            // 
            TimeOffset_Label_OffsetHour.Font = new System.Drawing.Font("BIZ UDゴシック", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 128);
            TimeOffset_Label_OffsetHour.Location = new System.Drawing.Point(137, 23);
            TimeOffset_Label_OffsetHour.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            TimeOffset_Label_OffsetHour.Name = "TimeOffset_Label_OffsetHour";
            TimeOffset_Label_OffsetHour.Size = new System.Drawing.Size(66, 35);
            TimeOffset_Label_OffsetHour.TabIndex = 24;
            TimeOffset_Label_OffsetHour.Text = "時間";
            TimeOffset_Label_OffsetHour.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // TimeOffset_Button_OffsetHour
            // 
            TimeOffset_Button_OffsetHour.BackColor = System.Drawing.Color.Lime;
            TimeOffset_Button_OffsetHour.FlatAppearance.BorderSize = 0;
            TimeOffset_Button_OffsetHour.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            TimeOffset_Button_OffsetHour.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            TimeOffset_Button_OffsetHour.Font = new System.Drawing.Font("BIZ UDゴシック", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 128);
            TimeOffset_Button_OffsetHour.ForeColor = System.Drawing.Color.Black;
            TimeOffset_Button_OffsetHour.Location = new System.Drawing.Point(242, 19);
            TimeOffset_Button_OffsetHour.Margin = new System.Windows.Forms.Padding(5);
            TimeOffset_Button_OffsetHour.Name = "TimeOffset_Button_OffsetHour";
            TimeOffset_Button_OffsetHour.Size = new System.Drawing.Size(75, 40);
            TimeOffset_Button_OffsetHour.TabIndex = 24;
            TimeOffset_Button_OffsetHour.Text = "設定";
            TimeOffset_Button_OffsetHour.UseVisualStyleBackColor = false;
            TimeOffset_Button_OffsetHour.Click += TimeOffset_Button_Click;
            // 
            // TimeOffset_GroupBox_SetHour
            // 
            TimeOffset_GroupBox_SetHour.Controls.Add(TimeOffset_NumericUpDown_SetHour);
            TimeOffset_GroupBox_SetHour.Controls.Add(TimeOffset_Label_SetHour);
            TimeOffset_GroupBox_SetHour.Controls.Add(TimeOffset_Button_SetHour);
            TimeOffset_GroupBox_SetHour.Font = new System.Drawing.Font("BIZ UDゴシック", 9F);
            TimeOffset_GroupBox_SetHour.ForeColor = System.Drawing.Color.White;
            TimeOffset_GroupBox_SetHour.Location = new System.Drawing.Point(12, 202);
            TimeOffset_GroupBox_SetHour.Name = "TimeOffset_GroupBox_SetHour";
            TimeOffset_GroupBox_SetHour.Size = new System.Drawing.Size(360, 75);
            TimeOffset_GroupBox_SetHour.TabIndex = 23;
            TimeOffset_GroupBox_SetHour.TabStop = false;
            TimeOffset_GroupBox_SetHour.Text = "設定したい時刻を指定";
            // 
            // TimeOffset_NumericUpDown_SetHour
            // 
            TimeOffset_NumericUpDown_SetHour.Font = new System.Drawing.Font("BIZ UDゴシック", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 128);
            TimeOffset_NumericUpDown_SetHour.Location = new System.Drawing.Point(54, 21);
            TimeOffset_NumericUpDown_SetHour.Maximum = new decimal(new int[] { 23, 0, 0, 0 });
            TimeOffset_NumericUpDown_SetHour.Name = "TimeOffset_NumericUpDown_SetHour";
            TimeOffset_NumericUpDown_SetHour.Size = new System.Drawing.Size(76, 34);
            TimeOffset_NumericUpDown_SetHour.TabIndex = 31;
            TimeOffset_NumericUpDown_SetHour.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // TimeOffset_Label_SetHour
            // 
            TimeOffset_Label_SetHour.Font = new System.Drawing.Font("BIZ UDゴシック", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 128);
            TimeOffset_Label_SetHour.Location = new System.Drawing.Point(137, 21);
            TimeOffset_Label_SetHour.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            TimeOffset_Label_SetHour.Name = "TimeOffset_Label_SetHour";
            TimeOffset_Label_SetHour.Size = new System.Drawing.Size(66, 34);
            TimeOffset_Label_SetHour.TabIndex = 25;
            TimeOffset_Label_SetHour.Text = "時台";
            TimeOffset_Label_SetHour.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // TimeOffset_Button_SetHour
            // 
            TimeOffset_Button_SetHour.BackColor = System.Drawing.Color.Lime;
            TimeOffset_Button_SetHour.FlatAppearance.BorderSize = 0;
            TimeOffset_Button_SetHour.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            TimeOffset_Button_SetHour.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            TimeOffset_Button_SetHour.Font = new System.Drawing.Font("BIZ UDゴシック", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 128);
            TimeOffset_Button_SetHour.ForeColor = System.Drawing.Color.Black;
            TimeOffset_Button_SetHour.Location = new System.Drawing.Point(242, 19);
            TimeOffset_Button_SetHour.Margin = new System.Windows.Forms.Padding(5);
            TimeOffset_Button_SetHour.Name = "TimeOffset_Button_SetHour";
            TimeOffset_Button_SetHour.Size = new System.Drawing.Size(75, 40);
            TimeOffset_Button_SetHour.TabIndex = 24;
            TimeOffset_Button_SetHour.Text = "設定";
            TimeOffset_Button_SetHour.UseVisualStyleBackColor = false;
            TimeOffset_Button_SetHour.Click += TimeOffset_Button_Click;
            // 
            // TimeOffset_Label_NowOffsetHour
            // 
            TimeOffset_Label_NowOffsetHour.Font = new System.Drawing.Font("BIZ UDゴシック", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 128);
            TimeOffset_Label_NowOffsetHour.ForeColor = System.Drawing.Color.White;
            TimeOffset_Label_NowOffsetHour.Location = new System.Drawing.Point(13, 60);
            TimeOffset_Label_NowOffsetHour.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            TimeOffset_Label_NowOffsetHour.Name = "TimeOffset_Label_NowOffsetHour";
            TimeOffset_Label_NowOffsetHour.Size = new System.Drawing.Size(233, 35);
            TimeOffset_Label_NowOffsetHour.TabIndex = 25;
            TimeOffset_Label_NowOffsetHour.Text = "現在時差： 0 時間";
            TimeOffset_Label_NowOffsetHour.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TimeOffset_Button_GetOffset
            // 
            TimeOffset_Button_GetOffset.BackColor = System.Drawing.Color.Aqua;
            TimeOffset_Button_GetOffset.FlatAppearance.BorderSize = 0;
            TimeOffset_Button_GetOffset.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            TimeOffset_Button_GetOffset.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            TimeOffset_Button_GetOffset.Font = new System.Drawing.Font("BIZ UDゴシック", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 128);
            TimeOffset_Button_GetOffset.ForeColor = System.Drawing.Color.Black;
            TimeOffset_Button_GetOffset.Location = new System.Drawing.Point(255, 57);
            TimeOffset_Button_GetOffset.Margin = new System.Windows.Forms.Padding(5);
            TimeOffset_Button_GetOffset.Name = "TimeOffset_Button_GetOffset";
            TimeOffset_Button_GetOffset.Size = new System.Drawing.Size(75, 40);
            TimeOffset_Button_GetOffset.TabIndex = 33;
            TimeOffset_Button_GetOffset.Text = "取得";
            TimeOffset_Button_GetOffset.UseVisualStyleBackColor = false;
            TimeOffset_Button_GetOffset.Click += TimeOffset_Button_Click;
            // 
            // TimeOffsetForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.FromArgb(76, 102, 102);
            ClientSize = new System.Drawing.Size(384, 305);
            Controls.Add(TimeOffset_Button_GetOffset);
            Controls.Add(TimeOffset_Label_NowOffsetHour);
            Controls.Add(TimeOffset_GroupBox_SetHour);
            Controls.Add(TimeOffset_GroupBox_OffsetHour);
            Controls.Add(TimeOffset_CheckBox_TopMost);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            Name = "TimeOffsetForm";
            Text = "時差設定 | 司令卓 - ダイヤ運転会";
            TimeOffset_GroupBox_OffsetHour.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)TimeOffset_NumericUpDown_OffsetHour).EndInit();
            TimeOffset_GroupBox_SetHour.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)TimeOffset_NumericUpDown_SetHour).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.CheckBox TimeOffset_CheckBox_TopMost;
        private System.Windows.Forms.GroupBox TimeOffset_GroupBox_OffsetHour;
        private System.Windows.Forms.GroupBox TimeOffset_GroupBox_SetHour;
        private System.Windows.Forms.Button TimeOffset_Button_OffsetHour;
        private System.Windows.Forms.Button TimeOffset_Button_SetHour;
        private System.Windows.Forms.Label TimeOffset_Label_OffsetHour;
        private System.Windows.Forms.Label TimeOffset_Label_SetHour;
        private System.Windows.Forms.NumericUpDown TimeOffset_NumericUpDown_OffsetHour;
        private System.Windows.Forms.NumericUpDown TimeOffset_NumericUpDown_SetHour;
        private System.Windows.Forms.Label TimeOffset_Label_NowOffsetHour;
        private System.Windows.Forms.Button TimeOffset_Button_GetOffset;
    }
}