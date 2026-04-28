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
            components = new System.ComponentModel.Container();
            SelectDia_CheckBox_TopMost = new System.Windows.Forms.CheckBox();
            SelectDia_Button_Reload = new System.Windows.Forms.Button();
            SelectDia_DataGridView_SelectDiaData = new System.Windows.Forms.DataGridView();
            Selected = new System.Windows.Forms.DataGridViewTextBoxColumn();
            DiaName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            Version = new System.Windows.Forms.DataGridViewTextBoxColumn();
            SelectDia_Button_Set = new System.Windows.Forms.Button();
            SelectDia_Button_Cancel = new System.Windows.Forms.Button();
            SelectDia_BindingSource = new System.Windows.Forms.BindingSource(components);
            SelectDia_Label_DiaName = new System.Windows.Forms.Label();
            SelectDia_TextBox_DiaName = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)SelectDia_DataGridView_SelectDiaData).BeginInit();
            ((System.ComponentModel.ISupportInitialize)SelectDia_BindingSource).BeginInit();
            SuspendLayout();
            //
            // SelectDia_Button_Reload
            //
            SelectDia_Button_Reload.BackColor = System.Drawing.Color.Aqua;
            SelectDia_Button_Reload.FlatAppearance.BorderSize = 0;
            SelectDia_Button_Reload.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            SelectDia_Button_Reload.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            SelectDia_Button_Reload.Font = new System.Drawing.Font("BIZ UDゴシック", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 128);
            SelectDia_Button_Reload.ForeColor = System.Drawing.Color.Black;
            SelectDia_Button_Reload.Location = new System.Drawing.Point(12, 9);
            SelectDia_Button_Reload.Name = "SelectDia_Button_Reload";
            SelectDia_Button_Reload.Size = new System.Drawing.Size(100, 25);
            SelectDia_Button_Reload.TabIndex = 45;
            SelectDia_Button_Reload.Text = "再読み込み";
            SelectDia_Button_Reload.UseVisualStyleBackColor = false;
            SelectDia_Button_Reload.Click += SelectDia_Button_Click;
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
            // SelectDia_DataGridView_SelectDiaData
            // 
            SelectDia_DataGridView_SelectDiaData.AllowUserToAddRows = false;
            SelectDia_DataGridView_SelectDiaData.AllowUserToDeleteRows = false;
            SelectDia_DataGridView_SelectDiaData.AllowUserToResizeColumns = false;
            SelectDia_DataGridView_SelectDiaData.AllowUserToResizeRows = false;
            SelectDia_DataGridView_SelectDiaData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            SelectDia_DataGridView_SelectDiaData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { Selected, DiaName, Version });
            SelectDia_DataGridView_SelectDiaData.Location = new System.Drawing.Point(12, 37);
            SelectDia_DataGridView_SelectDiaData.Name = "SelectDia_DataGridView_SelectDiaData";
            SelectDia_DataGridView_SelectDiaData.ReadOnly = true;
            SelectDia_DataGridView_SelectDiaData.RowHeadersVisible = false;
            SelectDia_DataGridView_SelectDiaData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            SelectDia_DataGridView_SelectDiaData.DataSource = SelectDia_BindingSource;
            SelectDia_DataGridView_SelectDiaData.Size = new System.Drawing.Size(360, 205);
            SelectDia_DataGridView_SelectDiaData.TabIndex = 22;
            //
            // Selected
            //
            Selected.HeaderText = "選択";
            Selected.Name = "Selected";
            Selected.ReadOnly = true;
            Selected.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            Selected.Width = 40;
            //
            // DiaName
            //
            DiaName.DataPropertyName = "DiaName";
            DiaName.HeaderText = "ダイヤ名";
            DiaName.MaxInputLength = 100;
            DiaName.Name = "DiaName";
            DiaName.ReadOnly = true;
            DiaName.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            DiaName.Width = 180;
            //
            // Version
            //
            Version.DataPropertyName = "Version";
            Version.HeaderText = "バージョン";
            Version.MaxInputLength = 100;
            Version.Name = "Version";
            Version.ReadOnly = true;
            Version.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            Version.Width = 140;
            // 
            // SelectDia_Button_Set
            // 
            SelectDia_Button_Set.BackColor = System.Drawing.Color.Lime;
            SelectDia_Button_Set.FlatAppearance.BorderSize = 0;
            SelectDia_Button_Set.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            SelectDia_Button_Set.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            SelectDia_Button_Set.Font = new System.Drawing.Font("BIZ UDゴシック", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 128);
            SelectDia_Button_Set.ForeColor = System.Drawing.Color.Black;
            SelectDia_Button_Set.Location = new System.Drawing.Point(212, 276);
            SelectDia_Button_Set.Margin = new System.Windows.Forms.Padding(5);
            SelectDia_Button_Set.Name = "SelectDia_Button_Set";
            SelectDia_Button_Set.Size = new System.Drawing.Size(75, 40);
            SelectDia_Button_Set.TabIndex = 41;
            SelectDia_Button_Set.Text = "設定";
            SelectDia_Button_Set.UseVisualStyleBackColor = false;
            SelectDia_Button_Set.Click += SelectDia_Button_Click;
            // 
            // SelectDia_Button_Cancel
            // 
            SelectDia_Button_Cancel.BackColor = System.Drawing.Color.OrangeRed;
            SelectDia_Button_Cancel.FlatAppearance.BorderSize = 0;
            SelectDia_Button_Cancel.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            SelectDia_Button_Cancel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            SelectDia_Button_Cancel.Font = new System.Drawing.Font("BIZ UDゴシック", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 128);
            SelectDia_Button_Cancel.ForeColor = System.Drawing.Color.White;
            SelectDia_Button_Cancel.Location = new System.Drawing.Point(297, 276);
            SelectDia_Button_Cancel.Margin = new System.Windows.Forms.Padding(5);
            SelectDia_Button_Cancel.Name = "SelectDia_Button_Cancel";
            SelectDia_Button_Cancel.Size = new System.Drawing.Size(75, 40);
            SelectDia_Button_Cancel.TabIndex = 42;
            SelectDia_Button_Cancel.Text = "解除";
            SelectDia_Button_Cancel.UseVisualStyleBackColor = false;
            SelectDia_Button_Cancel.Click += SelectDia_Button_Click;
            // 
            // SelectDia_Label_DiaName
            // 
            SelectDia_Label_DiaName.BackColor = System.Drawing.Color.FromArgb(76, 102, 102);
            SelectDia_Label_DiaName.Font = new System.Drawing.Font("BIZ UDゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 128);
            SelectDia_Label_DiaName.ForeColor = System.Drawing.Color.White;
            SelectDia_Label_DiaName.Location = new System.Drawing.Point(12, 245);
            SelectDia_Label_DiaName.Name = "SelectDia_Label_DiaName";
            SelectDia_Label_DiaName.Size = new System.Drawing.Size(192, 31);
            SelectDia_Label_DiaName.TabIndex = 44;
            SelectDia_Label_DiaName.Text = "ダイヤ名";
            SelectDia_Label_DiaName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // SelectDia_TextBox_DiaName
            // 
            SelectDia_TextBox_DiaName.Font = new System.Drawing.Font("BIZ UDゴシック", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 128);
            SelectDia_TextBox_DiaName.Location = new System.Drawing.Point(12, 279);
            SelectDia_TextBox_DiaName.MaxLength = 7;
            SelectDia_TextBox_DiaName.Name = "SelectDia_TextBox_DiaName";
            SelectDia_TextBox_DiaName.Size = new System.Drawing.Size(192, 34);
            SelectDia_TextBox_DiaName.TabIndex = 43;
            SelectDia_TextBox_DiaName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // SelectDiaForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.FromArgb(76, 102, 102);
            ClientSize = new System.Drawing.Size(384, 331);
            Controls.Add(SelectDia_Label_DiaName);
            Controls.Add(SelectDia_TextBox_DiaName);
            Controls.Add(SelectDia_Button_Cancel);
            Controls.Add(SelectDia_Button_Set);
            Controls.Add(SelectDia_DataGridView_SelectDiaData);
            Controls.Add(SelectDia_Button_Reload);
            Controls.Add(SelectDia_CheckBox_TopMost);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            Name = "SelectDiaForm";
            Text = "ダイヤ選択 | 司令卓 - ダイヤ運転会";
            ((System.ComponentModel.ISupportInitialize)SelectDia_DataGridView_SelectDiaData).EndInit();
            ((System.ComponentModel.ISupportInitialize)SelectDia_BindingSource).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.CheckBox SelectDia_CheckBox_TopMost;
        private System.Windows.Forms.Button SelectDia_Button_Reload;
        private System.Windows.Forms.DataGridView SelectDia_DataGridView_SelectDiaData;
        private System.Windows.Forms.DataGridViewTextBoxColumn Selected;
        private System.Windows.Forms.DataGridViewTextBoxColumn DiaName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Version;
        private System.Windows.Forms.Button SelectDia_Button_Set;
        private System.Windows.Forms.Button SelectDia_Button_Cancel;
        private System.Windows.Forms.BindingSource SelectDia_BindingSource;
        private System.Windows.Forms.Label SelectDia_Label_DiaName;
        private System.Windows.Forms.TextBox SelectDia_TextBox_DiaName;
    }
}