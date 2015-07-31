/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
* 
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

namespace ATML1671Translator.forms
{
    partial class ATMLSignalMappingForm
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ATMLSignalMappingForm));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.mappedSignals = new System.Windows.Forms.DataGridView();
            this.signalModelLibrary = new ATMLCommonLibrary.controls.awb.AWBXmlTreeView(this.components);
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.mappedSignalAttributes = new System.Windows.Forms.DataGridView();
            this.cmbSourceType = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mappedSignals)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mappedSignalAttributes)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.cmbSourceType);
            this.panel1.Controls.Add(this.splitContainer2);
            this.panel1.Size = new System.Drawing.Size(762, 484);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(705, 503);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(624, 503);
            // 
            // lblDenoteRequiredField
            // 
            this.lblDenoteRequiredField.Location = new System.Drawing.Point(4, 514);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.mappedSignals);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.signalModelLibrary);
            this.splitContainer1.Size = new System.Drawing.Size(758, 221);
            this.splitContainer1.SplitterDistance = 503;
            this.splitContainer1.TabIndex = 0;
            // 
            // mappedSignals
            // 
            this.mappedSignals.AllowDrop = true;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.mappedSignals.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.mappedSignals.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.mappedSignals.DefaultCellStyle = dataGridViewCellStyle8;
            this.mappedSignals.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mappedSignals.Location = new System.Drawing.Point(0, 0);
            this.mappedSignals.Name = "mappedSignals";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.mappedSignals.RowHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.mappedSignals.RowHeadersVisible = false;
            this.mappedSignals.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.mappedSignals.Size = new System.Drawing.Size(503, 221);
            this.mappedSignals.TabIndex = 0;
            this.mappedSignals.DragDrop += new System.Windows.Forms.DragEventHandler(this.mappedSignals_DragDrop);
            this.mappedSignals.DragEnter += new System.Windows.Forms.DragEventHandler(this.mappedSignals_DragEnter);
            this.mappedSignals.Resize += new System.EventHandler(this.mappedSignals_Resize);
            // 
            // signalModelLibrary
            // 
            this.signalModelLibrary.Dock = System.Windows.Forms.DockStyle.Fill;
            this.signalModelLibrary.HideSelection = false;
            this.signalModelLibrary.ImageIndex = 0;
            this.signalModelLibrary.ImageList = this.imageList1;
            this.signalModelLibrary.IncludeAttributes = false;
            this.signalModelLibrary.Location = new System.Drawing.Point(0, 0);
            this.signalModelLibrary.Name = "signalModelLibrary";
            this.signalModelLibrary.SelectedImageIndex = 0;
            this.signalModelLibrary.Size = new System.Drawing.Size(251, 221);
            this.signalModelLibrary.TabIndex = 0;
            this.signalModelLibrary.TreeModel = null;
            this.signalModelLibrary.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.signalModelLibrary_AfterSelect);
            this.signalModelLibrary.MouseDown += new System.Windows.Forms.MouseEventHandler(this.signalModelLibrary_MouseDown);
            // 
            // splitContainer2
            // 
            this.splitContainer2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer2.Location = new System.Drawing.Point(2, 38);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.splitContainer1);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.mappedSignalAttributes);
            this.splitContainer2.Size = new System.Drawing.Size(758, 444);
            this.splitContainer2.SplitterDistance = 221;
            this.splitContainer2.TabIndex = 1;
            // 
            // mappedSignalAttributes
            // 
            this.mappedSignalAttributes.AllowDrop = true;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.mappedSignalAttributes.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle10;
            this.mappedSignalAttributes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.mappedSignalAttributes.DefaultCellStyle = dataGridViewCellStyle11;
            this.mappedSignalAttributes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mappedSignalAttributes.Location = new System.Drawing.Point(0, 0);
            this.mappedSignalAttributes.Name = "mappedSignalAttributes";
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.mappedSignalAttributes.RowHeadersDefaultCellStyle = dataGridViewCellStyle12;
            this.mappedSignalAttributes.RowHeadersVisible = false;
            this.mappedSignalAttributes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.mappedSignalAttributes.Size = new System.Drawing.Size(758, 219);
            this.mappedSignalAttributes.TabIndex = 1;
            this.mappedSignalAttributes.DragDrop += new System.Windows.Forms.DragEventHandler(this.mappedSignalAttributes_DragDrop);
            this.mappedSignalAttributes.DragEnter += new System.Windows.Forms.DragEventHandler(this.mappedSignalAttributes_DragEnter);
            this.mappedSignalAttributes.Resize += new System.EventHandler(this.mappedSignalAttributes_Resize);
            // 
            // cmbSourceType
            // 
            this.cmbSourceType.FormattingEnabled = true;
            this.cmbSourceType.Items.AddRange(new object[] {
            "ATLAS"});
            this.cmbSourceType.Location = new System.Drawing.Point(87, 9);
            this.cmbSourceType.Name = "cmbSourceType";
            this.cmbSourceType.Size = new System.Drawing.Size(121, 21);
            this.cmbSourceType.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Source Type";
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "blank.gif");
            this.imageList1.Images.SetKeyName(1, "bullet_green.png");
            this.imageList1.Images.SetKeyName(2, "bullet_red.png");
            this.imageList1.Images.SetKeyName(3, "bullet_yellow.png");
            // 
            // ATMLSignalMappingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(787, 533);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "ATMLSignalMappingForm";
            this.Text = "ATML Signal Mapper";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.mappedSignals)).EndInit();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.mappedSignalAttributes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private ATMLCommonLibrary.controls.awb.AWBXmlTreeView signalModelLibrary;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbSourceType;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.DataGridView mappedSignals;
        private System.Windows.Forms.DataGridView mappedSignalAttributes;
        private System.Windows.Forms.ImageList imageList1;
    }
}