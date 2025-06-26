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
            ProtectionRadio_CheckBox_TopMost = new System.Windows.Forms.CheckBox();
            SuspendLayout();
            // 
            // ProtectionRadio_CheckBox_TopMost
            // 
            ProtectionRadio_CheckBox_TopMost.AutoSize = true;
            ProtectionRadio_CheckBox_TopMost.Font = new System.Drawing.Font("BIZ UDゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 128);
            ProtectionRadio_CheckBox_TopMost.ForeColor = System.Drawing.Color.White;
            ProtectionRadio_CheckBox_TopMost.Location = new System.Drawing.Point(771, 12);
            ProtectionRadio_CheckBox_TopMost.Name = "ProtectionRadio_CheckBox_TopMost";
            ProtectionRadio_CheckBox_TopMost.Size = new System.Drawing.Size(101, 19);
            ProtectionRadio_CheckBox_TopMost.TabIndex = 18;
            ProtectionRadio_CheckBox_TopMost.Text = "最前面表示";
            ProtectionRadio_CheckBox_TopMost.UseVisualStyleBackColor = true;
            ProtectionRadio_CheckBox_TopMost.CheckedChanged += ProtectionRadio_CheckBox_TopMost_CheckedChanged;
            // 
            // ProtectionRadioForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.FromArgb(76, 102, 102);
            ClientSize = new System.Drawing.Size(884, 611);
            Controls.Add(ProtectionRadio_CheckBox_TopMost);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            Name = "ProtectionRadioForm";
            Text = "防護無線設定 | 司令卓 - ダイヤ運転会";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.CheckBox ProtectionRadio_CheckBox_TopMost;
    }
}