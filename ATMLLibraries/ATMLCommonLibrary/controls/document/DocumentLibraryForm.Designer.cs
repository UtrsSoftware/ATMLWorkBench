/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
*
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/
namespace ATMLCommonLibrary.forms
{
    partial class DocumentLibraryForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DocumentLibraryForm));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.cmbDocumentType = new System.Windows.Forms.ToolStripComboBox();
            this.documentLibraryListControl = new ATMLCommonLibrary.controls.document.DocumentLibraryListControl();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.SteelBlue;
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.cmbDocumentType});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Margin = new System.Windows.Forms.Padding(1);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Padding = new System.Windows.Forms.Padding(4);
            this.toolStrip1.Size = new System.Drawing.Size(906, 31);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.ForeColor = System.Drawing.Color.AliceBlue;
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(95, 20);
            this.toolStripLabel1.Text = "Document Type:";
            // 
            // cmbDocumentType
            // 
            this.cmbDocumentType.DropDownWidth = 250;
            this.cmbDocumentType.Name = "cmbDocumentType";
            this.cmbDocumentType.Size = new System.Drawing.Size(250, 23);
            this.cmbDocumentType.Sorted = true;
            this.cmbDocumentType.SelectedIndexChanged += new System.EventHandler(this.cmbDocumentType_SelectedIndexChanged);
            // 
            // documentLibraryListControl
            // 
            this.documentLibraryListControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.documentLibraryListControl.ListName = null;
            this.documentLibraryListControl.Location = new System.Drawing.Point(0, 31);
            this.documentLibraryListControl.Margin = new System.Windows.Forms.Padding(0);
            this.documentLibraryListControl.Name = "documentLibraryListControl";
            this.documentLibraryListControl.SchemaTypeName = null;
            this.documentLibraryListControl.ShowFind = false;
            this.documentLibraryListControl.Size = new System.Drawing.Size(906, 490);
            this.documentLibraryListControl.TabIndex = 1;
            this.documentLibraryListControl.TargetNamespace = null;
            this.documentLibraryListControl.Load += new System.EventHandler(this.documentLibraryListControl_Load);
            // 
            // DocumentLibraryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(906, 521);
            this.Controls.Add(this.documentLibraryListControl);
            this.Controls.Add(this.toolStrip1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HideOnClose = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DocumentLibraryForm";
            this.Text = "Document Library";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripComboBox cmbDocumentType;
        private controls.document.DocumentLibraryListControl documentLibraryListControl;
    }
}