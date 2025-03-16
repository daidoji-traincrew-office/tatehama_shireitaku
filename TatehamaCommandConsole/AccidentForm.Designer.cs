namespace TatehamaCommandConsole
{
    partial class AccidentForm
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
            Accident_CheckBox_TopMost = new System.Windows.Forms.CheckBox();
            SuspendLayout();
            // 
            // Accident_CheckBox_TopMost
            // 
            Accident_CheckBox_TopMost.AutoSize = true;
            Accident_CheckBox_TopMost.Font = new System.Drawing.Font("BIZ UDゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 128);
            Accident_CheckBox_TopMost.ForeColor = System.Drawing.Color.White;
            Accident_CheckBox_TopMost.Location = new System.Drawing.Point(1151, 12);
            Accident_CheckBox_TopMost.Name = "Accident_CheckBox_TopMost";
            Accident_CheckBox_TopMost.Size = new System.Drawing.Size(101, 19);
            Accident_CheckBox_TopMost.TabIndex = 10;
            Accident_CheckBox_TopMost.Text = "最前面表示";
            Accident_CheckBox_TopMost.UseVisualStyleBackColor = true;
            Accident_CheckBox_TopMost.CheckedChanged += Accident_CheckBox_TopMost_CheckedChanged;
            // 
            // AccidentForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.FromArgb(76, 102, 102);
            ClientSize = new System.Drawing.Size(1264, 681);
            Controls.Add(Accident_CheckBox_TopMost);
            Font = new System.Drawing.Font("Yu Gothic UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            MaximizeBox = false;
            Name = "AccidentForm";
            Text = "運転支障 | 司令卓 - ダイヤ運転会";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.CheckBox Accident_CheckBox_TopMost;
    }
}