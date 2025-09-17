namespace TatehamaCommanderTable
{
    partial class SchedulerForm
    {
        private System.ComponentModel.IContainer components = null;

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
            Button_Refresh = new System.Windows.Forms.Button();
            SuspendLayout();
            // 
            // Button_Refresh
            // 
            Button_Refresh.BackColor = System.Drawing.Color.LightBlue;
            Button_Refresh.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            Button_Refresh.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkKhaki;
            Button_Refresh.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Khaki;
            Button_Refresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            Button_Refresh.Font = new System.Drawing.Font("BIZ UDゴシック", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)128));
            Button_Refresh.Location = new System.Drawing.Point(12, 12);
            Button_Refresh.Name = "Button_Refresh";
            Button_Refresh.Size = new System.Drawing.Size(100, 30);
            Button_Refresh.TabIndex = 0;
            Button_Refresh.Text = "更新";
            Button_Refresh.UseVisualStyleBackColor = false;
            Button_Refresh.Click += RefreshButton_Click;
            // 
            // SchedulerForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(144F, 144F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            BackColor = System.Drawing.Color.FromArgb(((int)((byte)240)), ((int)((byte)240)), ((int)((byte)240)));
            ClientSize = new System.Drawing.Size(600, 400);
            Controls.Add(Button_Refresh);
            Font = new System.Drawing.Font("Yu Gothic UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)128));
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            Margin = new System.Windows.Forms.Padding(4);
            MaximizeBox = true;
            MinimizeBox = true;
            MinimumSize = new System.Drawing.Size(400, 200);
            Text = "定時処理設定";
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Button Button_Refresh;
    }
}