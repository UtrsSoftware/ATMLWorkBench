/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
*
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/
namespace ATMLCommonLibrary.controls.awb
{
    partial class AWBTextCollectionList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AWBTextCollectionList));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tsSupplimental = new System.Windows.Forms.ToolStrip();
            this.btnRowAdd = new System.Windows.Forms.ToolStripButton();
            this.btnEdit = new System.Windows.Forms.ToolStripButton();
            this.btnDelete = new System.Windows.Forms.ToolStripButton();
            this.dgTextData = new System.Windows.Forms.DataGridView();
            this.tsSupplimental.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgTextData)).BeginInit();
            this.SuspendLayout();
            // 
            // tsSupplimental
            // 
            this.tsSupplimental.BackColor = System.Drawing.Color.LightSteelBlue;
            this.tsSupplimental.Dock = System.Windows.Forms.DockStyle.Right;
            this.tsSupplimental.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tsSupplimental.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.tsSupplimental.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnRowAdd,
            this.btnEdit,
            this.btnDelete});
            this.tsSupplimental.Location = new System.Drawing.Point(369, 0);
            this.tsSupplimental.Margin = new System.Windows.Forms.Padding(2);
            this.tsSupplimental.Name = "tsSupplimental";
            this.tsSupplimental.Padding = new System.Windows.Forms.Padding(0);
            this.tsSupplimental.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.tsSupplimental.Size = new System.Drawing.Size(28, 150);
            this.tsSupplimental.TabIndex = 35;
            this.tsSupplimental.Text = "toolStrip4";
            // 
            // btnRowAdd
            // 
            this.btnRowAdd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnRowAdd.Image = ((System.Drawing.Image)(resources.GetObject("btnRowAdd.Image")));
            this.btnRowAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRowAdd.Name = "btnRowAdd";
            this.btnRowAdd.Size = new System.Drawing.Size(27, 28);
            this.btnRowAdd.Text = "Add";
            this.btnRowAdd.ToolTipText = "Press to add a new text row";
            this.btnRowAdd.Click += new System.EventHandler(this.btnRowAdd_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnEdit.Image = ((System.Drawing.Image)(resources.GetObject("btnEdit.Image")));
            this.btnEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(27, 28);
            this.btnEdit.Text = "Edit";
            this.btnEdit.ToolTipText = "Press to edit the selected text row";
            this.btnEdit.Visible = false;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnDelete.Image = ((System.Drawing.Image)(resources.GetObject("btnDelete.Image")));
            this.btnDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(27, 28);
            this.btnDelete.Text = "Delete";
            this.btnDelete.ToolTipText = "Press to delete the selected text row";
            this.btnDelete.Visible = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // dgTextData
            // 
            this.dgTextData.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgTextData.BackgroundColor = System.Drawing.Color.SteelBlue;
            this.dgTextData.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgTextData.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgTextData.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgTextData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgTextData.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgTextData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgTextData.Location = new System.Drawing.Point(0, 0);
            this.dgTextData.Margin = new System.Windows.Forms.Padding(0);
            this.dgTextData.Name = "dgTextData";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgTextData.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgTextData.RowHeadersVisible = false;
            this.dgTextData.Size = new System.Drawing.Size(369, 150);
            this.dgTextData.TabIndex = 37;
            // 
            // AWBTextCollectionList
            // 
            this.Controls.Add(this.dgTextData);
            this.Controls.Add(this.tsSupplimental);
            this.Name = "AWBTextCollectionList";
            this.Size = new System.Drawing.Size(397, 150);
            this.tsSupplimental.ResumeLayout(false);
            this.tsSupplimental.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgTextData)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tsSupplimental;
        private System.Windows.Forms.ToolStripButton btnRowAdd;
        private System.Windows.Forms.ToolStripButton btnEdit;
        private System.Windows.Forms.ToolStripButton btnDelete;
        private System.Windows.Forms.DataGridView dgTextData;
    }
}
