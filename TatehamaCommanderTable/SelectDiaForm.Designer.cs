namespace TatehamaCommanderTable
{
    partial class SelectDiaForm
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
            SelectDia_CheckBox_TopMost = new System.Windows.Forms.CheckBox();
            SuspendLayout();
            // 
            // SelectDia_CheckBox_TopMost
            // 
            SelectDia_CheckBox_TopMost.AutoSize = true;
            SelectDia_CheckBox_TopMost.Font = new System.Drawing.Font("BIZ UDゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 128);
            SelectDia_CheckBox_TopMost.ForeColor = System.Drawing.Color.White;
            SelectDia_CheckBox_TopMost.Location = new System.Drawing.Point(271, 12);
            SelectDia_CheckBox_TopMost.Name = "SelectDia_CheckBox_TopMost";
            SelectDia_CheckBox_TopMost.Size = new System.Drawing.Size(101, 19);
            SelectDia_CheckBox_TopMost.TabIndex = 21;
            SelectDia_CheckBox_TopMost.Text = "最前面表示";
            SelectDia_CheckBox_TopMost.UseVisualStyleBackColor = true;
            // 
            // SelectDiaForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.FromArgb(76, 102, 102);
            ClientSize = new System.Drawing.Size(384, 301);
            Controls.Add(SelectDia_CheckBox_TopMost);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            Name = "SelectDiaForm";
            Text = "ダイヤ選択 | 司令卓 - ダイヤ運転会";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.CheckBox SelectDia_CheckBox_TopMost;
    }
}