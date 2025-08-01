using System;
using TatehamaCommanderTable.Models;

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
            components = new System.ComponentModel.Container();
            Dia_CheckBox_TopMost = new System.Windows.Forms.CheckBox();
            Dia_BindingSource = new System.Windows.Forms.BindingSource(components);
            Dia_DataGridView_DiaData = new System.Windows.Forms.DataGridView();
            TrainNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            TypeId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            TrainType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            FromStationId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ToStationId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            DiaId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)Dia_BindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Dia_DataGridView_DiaData).BeginInit();
            SuspendLayout();
            // 
            // Dia_CheckBox_TopMost
            // 
            Dia_CheckBox_TopMost.AutoSize = true;
            Dia_CheckBox_TopMost.Font = new System.Drawing.Font("BIZ UDゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 128);
            Dia_CheckBox_TopMost.ForeColor = System.Drawing.Color.White;
            Dia_CheckBox_TopMost.Location = new System.Drawing.Point(771, 12);
            Dia_CheckBox_TopMost.Name = "Dia_CheckBox_TopMost";
            Dia_CheckBox_TopMost.Size = new System.Drawing.Size(101, 19);
            Dia_CheckBox_TopMost.TabIndex = 11;
            Dia_CheckBox_TopMost.Text = "最前面表示";
            Dia_CheckBox_TopMost.UseVisualStyleBackColor = true;
            Dia_CheckBox_TopMost.CheckedChanged += Dia_CheckBox_TopMost_CheckedChanged;
            // 
            // Dia_DataGridView_DiaData
            // 
            Dia_DataGridView_DiaData.AllowUserToAddRows = false;
            Dia_DataGridView_DiaData.AllowUserToDeleteRows = false;
            Dia_DataGridView_DiaData.AllowUserToResizeColumns = false;
            Dia_DataGridView_DiaData.AllowUserToResizeRows = false;
            Dia_DataGridView_DiaData.AutoGenerateColumns = false;
            Dia_DataGridView_DiaData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            Dia_DataGridView_DiaData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { TrainNumber, TypeId, TrainType, FromStationId, ToStationId, DiaId });
            Dia_DataGridView_DiaData.DataSource = Dia_BindingSource;
            Dia_DataGridView_DiaData.Location = new System.Drawing.Point(12, 37);
            Dia_DataGridView_DiaData.Name = "Dia_DataGridView_DiaData";
            Dia_DataGridView_DiaData.ReadOnly = true;
            Dia_DataGridView_DiaData.RowHeadersVisible = false;
            Dia_DataGridView_DiaData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            Dia_DataGridView_DiaData.Size = new System.Drawing.Size(860, 260);
            Dia_DataGridView_DiaData.TabIndex = 19;
            // 
            // TrainNumber
            // 
            TrainNumber.DataPropertyName = "TrainNumber";
            TrainNumber.HeaderText = "列車番号";
            TrainNumber.MaxInputLength = 10;
            TrainNumber.Name = "TrainNumber";
            TrainNumber.ReadOnly = true;
            // 
            // TypeId
            // 
            TypeId.DataPropertyName = "TypeId";
            TypeId.HeaderText = "種別ID";
            TypeId.MaxInputLength = 10;
            TypeId.Name = "TypeId";
            TypeId.ReadOnly = true;
            // 
            // TrainType
            // 
            TrainType.DataPropertyName = "TrainType";
            TrainType.HeaderText = "種別";
            TrainType.MaxInputLength = 20;
            TrainType.Name = "TrainType";
            TrainType.ReadOnly = true;
            // 
            // FromStationId
            // 
            FromStationId.DataPropertyName = "FromStationId";
            FromStationId.HeaderText = "始発駅ID";
            FromStationId.MaxInputLength = 10;
            FromStationId.Name = "FromStationId";
            FromStationId.ReadOnly = true;
            // 
            // ToStationId
            // 
            ToStationId.DataPropertyName = "ToStationId";
            ToStationId.HeaderText = "行先駅ID";
            ToStationId.MaxInputLength = 10;
            ToStationId.Name = "ToStationId";
            ToStationId.ReadOnly = true;
            // 
            // DiaId
            // 
            DiaId.DataPropertyName = "DiaId";
            DiaId.HeaderText = "ダイヤID";
            DiaId.MaxInputLength = 10;
            DiaId.Name = "DiaId";
            DiaId.ReadOnly = true;
            // 
            // DiaForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.FromArgb(76, 102, 102);
            ClientSize = new System.Drawing.Size(884, 561);
            Controls.Add(Dia_DataGridView_DiaData);
            Controls.Add(Dia_CheckBox_TopMost);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            MinimizeBox = false;
            Name = "DiaForm";
            Text = "日時ダイヤ行先設定 | 司令卓 - ダイヤ運転会";
            ((System.ComponentModel.ISupportInitialize)Dia_BindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)Dia_DataGridView_DiaData).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.CheckBox Dia_CheckBox_TopMost;
        private System.Windows.Forms.BindingSource Dia_BindingSource;
        private System.Windows.Forms.DataGridView Dia_DataGridView_DiaData;
        private System.Windows.Forms.DataGridViewTextBoxColumn TrainNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn TypeId;
        private System.Windows.Forms.DataGridViewTextBoxColumn TrainType;
        private System.Windows.Forms.DataGridViewTextBoxColumn FromStationId;
        private System.Windows.Forms.DataGridViewTextBoxColumn ToStationId;
        private System.Windows.Forms.DataGridViewTextBoxColumn DiaId;
    }
}