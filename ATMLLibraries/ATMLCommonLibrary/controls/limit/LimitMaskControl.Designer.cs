/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
*
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/
namespace ATMLCommonLibrary.controls.limit
{
    partial class LimitMaskControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LimitMaskControl));
            this.edtExpectedValue = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.maskName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.maskOperator = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.maskValueType = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.maskValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.maskStdUnit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnDetail = new System.Windows.Forms.DataGridViewButtonColumn();
            this.label2 = new ATMLCommonLibrary.controls.HelpLabel(this.components);
            this.btnExpectedLimit = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // edtExpectedValue
            // 
            this.edtExpectedValue.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(255)))), ((int)(((byte)(220)))));
            this.edtExpectedValue.Location = new System.Drawing.Point(67, 8);
            this.edtExpectedValue.Name = "edtExpectedValue";
            this.edtExpectedValue.ReadOnly = true;
            this.edtExpectedValue.Size = new System.Drawing.Size(287, 20);
            this.edtExpectedValue.TabIndex = 1;
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Arial Narrow", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.maskName,
            this.maskOperator,
            this.maskValueType,
            this.maskValue,
            this.maskStdUnit,
            this.btnDetail});
            this.dataGridView1.Location = new System.Drawing.Point(0, 34);
            this.dataGridView1.Name = "dataGridView1";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Arial Narrow", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridView1.RowHeadersVisible = false;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Arial Narrow", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridView1.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Arial Narrow", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridView1.RowTemplate.Height = 16;
            this.dataGridView1.Size = new System.Drawing.Size(455, 138);
            this.dataGridView1.TabIndex = 2;
            // 
            // maskName
            // 
            this.maskName.HeaderText = "Name";
            this.maskName.Name = "maskName";
            // 
            // maskOperator
            // 
            this.maskOperator.HeaderText = "Operator";
            this.maskOperator.Name = "maskOperator";
            this.maskOperator.Width = 50;
            // 
            // maskValueType
            // 
            this.maskValueType.HeaderText = "Type";
            this.maskValueType.Name = "maskValueType";
            this.maskValueType.Width = 50;
            // 
            // maskValue
            // 
            this.maskValue.HeaderText = "Value";
            this.maskValue.Name = "maskValue";
            // 
            // maskStdUnit
            // 
            this.maskStdUnit.HeaderText = "Unit";
            this.maskStdUnit.Name = "maskStdUnit";
            this.maskStdUnit.Width = 60;
            // 
            // btnDetail
            // 
            this.btnDetail.HeaderText = "";
            this.btnDetail.Name = "btnDetail";
            this.btnDetail.Width = 20;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.HelpMessageKey = "LimitMaskControl.Expected";
            this.label2.Location = new System.Drawing.Point(9, 11);
            this.label2.Name = "label2";
            this.label2.RequiredField = false;
            this.label2.RequiredFieldMarkerFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Expected";
            // 
            // btnExpectedLimit
            // 
            this.btnExpectedLimit.FlatAppearance.BorderSize = 0;
            this.btnExpectedLimit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExpectedLimit.Image = ((System.Drawing.Image)(resources.GetObject("btnExpectedLimit.Image")));
            this.btnExpectedLimit.Location = new System.Drawing.Point(358, 5);
            this.btnExpectedLimit.Name = "btnExpectedLimit";
            this.btnExpectedLimit.Size = new System.Drawing.Size(27, 23);
            this.btnExpectedLimit.TabIndex = 4;
            this.btnExpectedLimit.UseVisualStyleBackColor = true;
            this.btnExpectedLimit.Click += new System.EventHandler(this.btnExpectedLimit_Click);
            // 
            // LimitMaskControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnExpectedLimit);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.edtExpectedValue);
            this.MinimumSize = new System.Drawing.Size(455, 175);
            this.Name = "LimitMaskControl";
            this.Size = new System.Drawing.Size(455, 175);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox edtExpectedValue;
        private System.Windows.Forms.DataGridView dataGridView1;
        private ATMLCommonLibrary.controls.HelpLabel label2;
        private System.Windows.Forms.DataGridViewTextBoxColumn maskName;
        private System.Windows.Forms.DataGridViewComboBoxColumn maskOperator;
        private System.Windows.Forms.DataGridViewComboBoxColumn maskValueType;
        private System.Windows.Forms.DataGridViewTextBoxColumn maskValue;
        private System.Windows.Forms.DataGridViewTextBoxColumn maskStdUnit;
        private System.Windows.Forms.DataGridViewButtonColumn btnDetail;
        private System.Windows.Forms.Button btnExpectedLimit;
    }
}
