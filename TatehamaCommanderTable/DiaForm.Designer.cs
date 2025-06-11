namespace TatehamaCommanderTable
{
    partial class DiaForm
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
            Dia_CheckBox_TopMost = new System.Windows.Forms.CheckBox();
            SuspendLayout();
            // 
            // Dia_CheckBox_TopMost
            // 
            Dia_CheckBox_TopMost.AutoSize = true;
            Dia_CheckBox_TopMost.Font = new System.Drawing.Font("BIZ UDゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 128);
            Dia_CheckBox_TopMost.ForeColor = System.Drawing.Color.White;
            Dia_CheckBox_TopMost.Location = new System.Drawing.Point(670, 15);
            Dia_CheckBox_TopMost.Name = "Dia_CheckBox_TopMost";
            Dia_CheckBox_TopMost.Size = new System.Drawing.Size(101, 19);
            Dia_CheckBox_TopMost.TabIndex = 11;
            Dia_CheckBox_TopMost.Text = "最前面表示";
            Dia_CheckBox_TopMost.UseVisualStyleBackColor = true;
            Dia_CheckBox_TopMost.CheckedChanged += Dia_CheckBox_TopMost_CheckedChanged;
            // 
            // DiaForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.FromArgb(76, 102, 102);
            ClientSize = new System.Drawing.Size(784, 561);
            Controls.Add(Dia_CheckBox_TopMost);
            Name = "DiaForm";
            Text = "日時ダイヤ行先設定 | 司令卓 - ダイヤ運転会";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.CheckBox Dia_CheckBox_TopMost;
    }
}