namespace TatehamaCommandConsole
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Label_ServerConectionState = new System.Windows.Forms.Label();
            Button_Select_Kokuchi = new System.Windows.Forms.Button();
            Button_Select_Accident = new System.Windows.Forms.Button();
            Button_Select_TrackCircuit = new System.Windows.Forms.Button();
            Main_CheckBox_TopMost = new System.Windows.Forms.CheckBox();
            SuspendLayout();
            // 
            // Label_ServerConectionState
            // 
            Label_ServerConectionState.BackColor = System.Drawing.Color.FromArgb(85, 85, 85);
            Label_ServerConectionState.Font = new System.Drawing.Font("Yu Gothic UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 128);
            Label_ServerConectionState.ForeColor = System.Drawing.Color.FromArgb(136, 136, 136);
            Label_ServerConectionState.Location = new System.Drawing.Point(642, 9);
            Label_ServerConectionState.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            Label_ServerConectionState.Name = "Label_ServerConectionState";
            Label_ServerConectionState.Size = new System.Drawing.Size(130, 30);
            Label_ServerConectionState.TabIndex = 0;
            Label_ServerConectionState.Text = "オフライン";
            Label_ServerConectionState.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Button_Select_Kokuchi
            // 
            Button_Select_Kokuchi.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            Button_Select_Kokuchi.BackColor = System.Drawing.Color.LightBlue;
            Button_Select_Kokuchi.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            Button_Select_Kokuchi.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkKhaki;
            Button_Select_Kokuchi.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Khaki;
            Button_Select_Kokuchi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            Button_Select_Kokuchi.Font = new System.Drawing.Font("BIZ UDゴシック", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 128);
            Button_Select_Kokuchi.Location = new System.Drawing.Point(66, 180);
            Button_Select_Kokuchi.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            Button_Select_Kokuchi.Name = "Button_Select_Kokuchi";
            Button_Select_Kokuchi.Size = new System.Drawing.Size(200, 200);
            Button_Select_Kokuchi.TabIndex = 1;
            Button_Select_Kokuchi.Text = "運転告知器";
            Button_Select_Kokuchi.UseVisualStyleBackColor = false;
            Button_Select_Kokuchi.Click += ButtonClickEvent;
            // 
            // Button_Select_Accident
            // 
            Button_Select_Accident.BackColor = System.Drawing.Color.LightBlue;
            Button_Select_Accident.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            Button_Select_Accident.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkKhaki;
            Button_Select_Accident.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Khaki;
            Button_Select_Accident.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            Button_Select_Accident.Font = new System.Drawing.Font("BIZ UDゴシック", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 128);
            Button_Select_Accident.Location = new System.Drawing.Point(292, 180);
            Button_Select_Accident.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            Button_Select_Accident.Name = "Button_Select_Accident";
            Button_Select_Accident.Size = new System.Drawing.Size(200, 200);
            Button_Select_Accident.TabIndex = 2;
            Button_Select_Accident.Text = "運転支障\r\n";
            Button_Select_Accident.UseVisualStyleBackColor = false;
            Button_Select_Accident.Click += ButtonClickEvent;
            // 
            // Button_Select_TrackCircuit
            // 
            Button_Select_TrackCircuit.BackColor = System.Drawing.Color.LightBlue;
            Button_Select_TrackCircuit.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            Button_Select_TrackCircuit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkKhaki;
            Button_Select_TrackCircuit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Khaki;
            Button_Select_TrackCircuit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            Button_Select_TrackCircuit.Font = new System.Drawing.Font("BIZ UDゴシック", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 128);
            Button_Select_TrackCircuit.Location = new System.Drawing.Point(517, 180);
            Button_Select_TrackCircuit.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            Button_Select_TrackCircuit.Name = "Button_Select_TrackCircuit";
            Button_Select_TrackCircuit.Size = new System.Drawing.Size(200, 200);
            Button_Select_TrackCircuit.TabIndex = 3;
            Button_Select_TrackCircuit.Text = "軌道回路";
            Button_Select_TrackCircuit.UseVisualStyleBackColor = false;
            Button_Select_TrackCircuit.Click += ButtonClickEvent;
            // 
            // Main_CheckBox_TopMost
            // 
            Main_CheckBox_TopMost.AutoSize = true;
            Main_CheckBox_TopMost.Font = new System.Drawing.Font("BIZ UDゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 128);
            Main_CheckBox_TopMost.ForeColor = System.Drawing.Color.White;
            Main_CheckBox_TopMost.Location = new System.Drawing.Point(671, 53);
            Main_CheckBox_TopMost.Name = "Main_CheckBox_TopMost";
            Main_CheckBox_TopMost.Size = new System.Drawing.Size(101, 19);
            Main_CheckBox_TopMost.TabIndex = 17;
            Main_CheckBox_TopMost.Text = "最前面表示";
            Main_CheckBox_TopMost.UseVisualStyleBackColor = true;
            Main_CheckBox_TopMost.CheckedChanged += Main_CheckBox_TopMost_CheckedChanged;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.FromArgb(76, 102, 102);
            ClientSize = new System.Drawing.Size(784, 561);
            Controls.Add(Main_CheckBox_TopMost);
            Controls.Add(Button_Select_TrackCircuit);
            Controls.Add(Button_Select_Accident);
            Controls.Add(Button_Select_Kokuchi);
            Controls.Add(Label_ServerConectionState);
            Font = new System.Drawing.Font("Yu Gothic UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 128);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            MaximizeBox = false;
            Name = "MainForm";
            Text = "項目選択 | 司令卓 - ダイヤ運転会";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label Label_ServerConectionState;
        private System.Windows.Forms.Button Button_Select_Kokuchi;
        private System.Windows.Forms.Button Button_Select_Accident;
        private System.Windows.Forms.Button Button_Select_TrackCircuit;
        private System.Windows.Forms.CheckBox Main_CheckBox_TopMost;
    }
}
