/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
*
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/
namespace ATMLCommonLibrary.controls
{
    partial class SpecificationGroupControl
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
            if( disposing && ( components != null ) )
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SpecificationGroupControl));
            this.tabSpecifications = new System.Windows.Forms.TabControl();
            this.tabSubSpecifications = new System.Windows.Forms.TabPage();
            this.specificationListControl = new ATMLCommonLibrary.controls.lists.SpecificationListControl();
            this.tabConditions = new System.Windows.Forms.TabPage();
            this.dgConditions = new System.Windows.Forms.DataGridView();
            this.condition = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.edtSpecDescription = new ATMLCommonLibrary.controls.awb.AWBTextBox(this.components);
            this.edtSpecName = new ATMLCommonLibrary.controls.awb.AWBTextBox(this.components);
            this.lblDescription = new ATMLCommonLibrary.controls.HelpLabel(this.components);
            this.lblName = new ATMLCommonLibrary.controls.HelpLabel(this.components);
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.tabSpecifications.SuspendLayout();
            this.tabSubSpecifications.SuspendLayout();
            this.tabConditions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgConditions)).BeginInit();
            this.toolStrip2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // tabSpecifications
            // 
            this.tabSpecifications.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabSpecifications.Controls.Add(this.tabSubSpecifications);
            this.tabSpecifications.Controls.Add(this.tabConditions);
            this.tabSpecifications.Location = new System.Drawing.Point(9, 100);
            this.tabSpecifications.Name = "tabSpecifications";
            this.tabSpecifications.SelectedIndex = 0;
            this.tabSpecifications.Size = new System.Drawing.Size(506, 187);
            this.tabSpecifications.TabIndex = 4;
            // 
            // tabSubSpecifications
            // 
            this.tabSubSpecifications.Controls.Add(this.specificationListControl);
            this.tabSubSpecifications.Location = new System.Drawing.Point(4, 22);
            this.tabSubSpecifications.Margin = new System.Windows.Forms.Padding(0);
            this.tabSubSpecifications.Name = "tabSubSpecifications";
            this.tabSubSpecifications.Size = new System.Drawing.Size(498, 161);
            this.tabSubSpecifications.TabIndex = 2;
            this.tabSubSpecifications.Text = "Sub Specifications";
            // 
            // specificationListControl
            // 
            this.specificationListControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.specificationListControl.ListName = null;
            this.specificationListControl.Location = new System.Drawing.Point(0, 0);
            this.specificationListControl.Margin = new System.Windows.Forms.Padding(0);
            this.specificationListControl.Name = "specificationListControl";
            this.specificationListControl.SchemaTypeName = null;
            this.specificationListControl.Size = new System.Drawing.Size(498, 161);
            this.specificationListControl.TabIndex = 0;
            this.specificationListControl.TargetNamespace = null;
            // 
            // tabConditions
            // 
            this.tabConditions.BackColor = System.Drawing.Color.SteelBlue;
            this.tabConditions.Controls.Add(this.dgConditions);
            this.tabConditions.Controls.Add(this.toolStrip2);
            this.tabConditions.Location = new System.Drawing.Point(4, 22);
            this.tabConditions.Name = "tabConditions";
            this.tabConditions.Size = new System.Drawing.Size(498, 161);
            this.tabConditions.TabIndex = 1;
            this.tabConditions.Text = "Conditions";
            // 
            // dgConditions
            // 
            this.dgConditions.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgConditions.BackgroundColor = System.Drawing.Color.SteelBlue;
            this.dgConditions.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgConditions.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgConditions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgConditions.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.condition});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgConditions.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgConditions.Location = new System.Drawing.Point(0, 0);
            this.dgConditions.Name = "dgConditions";
            this.dgConditions.RowHeadersVisible = false;
            this.dgConditions.Size = new System.Drawing.Size(473, 159);
            this.dgConditions.TabIndex = 0;
            // 
            // condition
            // 
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.condition.DefaultCellStyle = dataGridViewCellStyle1;
            this.condition.HeaderText = "Condition Name";
            this.condition.Name = "condition";
            this.condition.Width = 472;
            // 
            // toolStrip2
            // 
            this.toolStrip2.BackColor = System.Drawing.Color.LightSteelBlue;
            this.toolStrip2.Dock = System.Windows.Forms.DockStyle.Right;
            this.toolStrip2.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.toolStripButton2,
            this.toolStripButton3});
            this.toolStrip2.Location = new System.Drawing.Point(474, 0);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip2.Size = new System.Drawing.Size(24, 161);
            this.toolStrip2.TabIndex = 1;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(21, 20);
            this.toolStripButton1.Text = "Add";
            this.toolStripButton1.ToolTipText = "Press to add a new ";
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(21, 20);
            this.toolStripButton2.Text = "Edit";
            this.toolStripButton2.ToolTipText = "Press to edit the selected ";
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton3.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton3.Image")));
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(21, 20);
            this.toolStripButton3.Text = "Delete";
            this.toolStripButton3.ToolTipText = "Press to delete the selected ";
            // 
            // edtSpecDescription
            // 
            this.edtSpecDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtSpecDescription.AttributeName = null;
            this.edtSpecDescription.Location = new System.Drawing.Point(76, 39);
            this.edtSpecDescription.Multiline = true;
            this.edtSpecDescription.Name = "edtSpecDescription";
            this.edtSpecDescription.Size = new System.Drawing.Size(434, 50);
            this.edtSpecDescription.TabIndex = 3;
            this.edtSpecDescription.Tag = "";
            this.edtSpecDescription.Value = null;
            this.edtSpecDescription.ValueType = ATMLCommonLibrary.controls.awb.AWBTextBox.eValueType.xsString;
            // 
            // edtSpecName
            // 
            this.edtSpecName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtSpecName.AttributeName = null;
            this.edtSpecName.Location = new System.Drawing.Point(76, 13);
            this.edtSpecName.Name = "edtSpecName";
            this.edtSpecName.Size = new System.Drawing.Size(434, 20);
            this.edtSpecName.TabIndex = 1;
            this.edtSpecName.Tag = "";
            this.edtSpecName.Value = null;
            this.edtSpecName.ValueType = ATMLCommonLibrary.controls.awb.AWBTextBox.eValueType.xsString;
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.HelpMessageKey = "SpecGroupControl.Description";
            this.lblDescription.Location = new System.Drawing.Point(12, 38);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.RequiredField = false;
            this.lblDescription.RequiredFieldMarkerFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescription.Size = new System.Drawing.Size(60, 13);
            this.lblDescription.TabIndex = 2;
            this.lblDescription.Text = "Description";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.HelpMessageKey = "SpecGroupControl.Name";
            this.lblName.Location = new System.Drawing.Point(37, 14);
            this.lblName.Name = "lblName";
            this.lblName.RequiredField = false;
            this.lblName.RequiredFieldMarkerFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.Size = new System.Drawing.Size(35, 13);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "Name";
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // SpecificationGroupControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabSpecifications);
            this.Controls.Add(this.edtSpecDescription);
            this.Controls.Add(this.edtSpecName);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.lblName);
            this.Name = "SpecificationGroupControl";
            this.Size = new System.Drawing.Size(525, 299);
            this.tabSpecifications.ResumeLayout(false);
            this.tabSubSpecifications.ResumeLayout(false);
            this.tabConditions.ResumeLayout(false);
            this.tabConditions.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgConditions)).EndInit();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabSpecifications;
        private System.Windows.Forms.TabPage tabConditions;
        private System.Windows.Forms.TabPage tabSubSpecifications;
        private awb.AWBTextBox edtSpecDescription;
        private awb.AWBTextBox edtSpecName;
        private ATMLCommonLibrary.controls.HelpLabel lblDescription;
        private ATMLCommonLibrary.controls.HelpLabel lblName;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        private System.Windows.Forms.DataGridView dgConditions;
        private lists.SpecificationListControl specificationListControl;
        private System.Windows.Forms.DataGridViewTextBoxColumn condition;
        protected System.Windows.Forms.ErrorProvider errorProvider;
    }
}
