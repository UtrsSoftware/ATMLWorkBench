/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
* 
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

namespace ATMLCommonLibrary.controls.document
{
    partial class DocumentForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DocumentForm));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.lblDocumentType = new System.Windows.Forms.ToolStripLabel();
            this.cmbDocumentType = new System.Windows.Forms.ToolStripComboBox();
            this.btnImportDocument = new System.Windows.Forms.ToolStripButton();
            this.btnExportDocument = new System.Windows.Forms.ToolStripButton();
            this.btnSaveToDatabase = new System.Windows.Forms.ToolStripButton();
            this.documentControl = new DocumentControl();
            this.btnEditDocumentObject = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.documentControl);
            this.panel1.Location = new System.Drawing.Point(8, 46);
            this.panel1.Size = new System.Drawing.Size(632, 509);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(565, 563);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(484, 563);
            // 
            // lblDenoteRequiredField
            // 
            this.lblDenoteRequiredField.Location = new System.Drawing.Point(1, 609);
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.LightSlateGray;
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblDocumentType,
            this.cmbDocumentType,
            this.btnImportDocument,
            this.btnExportDocument,
            this.btnSaveToDatabase});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Margin = new System.Windows.Forms.Padding(2);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Padding = new System.Windows.Forms.Padding(2);
            this.toolStrip1.Size = new System.Drawing.Size(652, 35);
            this.toolStrip1.TabIndex = 4;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // lblDocumentType
            // 
            this.lblDocumentType.ForeColor = System.Drawing.Color.AliceBlue;
            this.lblDocumentType.Name = "lblDocumentType";
            this.lblDocumentType.Size = new System.Drawing.Size(33, 28);
            this.lblDocumentType.Text = "Type";
            // 
            // cmbDocumentType
            // 
            this.cmbDocumentType.DropDownWidth = 250;
            this.cmbDocumentType.Name = "cmbDocumentType";
            this.cmbDocumentType.Size = new System.Drawing.Size(250, 31);
            this.cmbDocumentType.Sorted = true;
            // 
            // btnImportDocument
            // 
            this.btnImportDocument.ForeColor = System.Drawing.Color.AliceBlue;
            this.btnImportDocument.Image = ((System.Drawing.Image)(resources.GetObject("btnImportDocument.Image")));
            this.btnImportDocument.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnImportDocument.Name = "btnImportDocument";
            this.btnImportDocument.Size = new System.Drawing.Size(71, 28);
            this.btnImportDocument.Text = "Import";
            this.btnImportDocument.ToolTipText = "Import TSF";
            this.btnImportDocument.Click += new System.EventHandler(this.btnImportDocument_Click);
            // 
            // btnExportDocument
            // 
            this.btnExportDocument.ForeColor = System.Drawing.Color.AliceBlue;
            this.btnExportDocument.Image = ((System.Drawing.Image)(resources.GetObject("btnExportDocument.Image")));
            this.btnExportDocument.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnExportDocument.Name = "btnExportDocument";
            this.btnExportDocument.Size = new System.Drawing.Size(68, 28);
            this.btnExportDocument.Text = "Export";
            this.btnExportDocument.Click += new System.EventHandler(this.btnExportDocument_Click);
            // 
            // btnSaveToDatabase
            // 
            this.btnSaveToDatabase.ForeColor = System.Drawing.Color.AliceBlue;
            this.btnSaveToDatabase.Image = ((System.Drawing.Image)(resources.GetObject("btnSaveToDatabase.Image")));
            this.btnSaveToDatabase.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSaveToDatabase.Name = "btnSaveToDatabase";
            this.btnSaveToDatabase.Size = new System.Drawing.Size(59, 28);
            this.btnSaveToDatabase.Text = "Save";
            this.btnSaveToDatabase.ToolTipText = "Save to Database";
            this.btnSaveToDatabase.Click += new System.EventHandler(this.btnSaveToDatabase_Click);
            // 
            // documentControl
            // 
            this.documentControl.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.documentControl.BackColor = System.Drawing.Color.AliceBlue;
            this.documentControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.documentControl.Location = new System.Drawing.Point(0, 0);
            this.documentControl.Name = "documentControl";
            this.documentControl.Size = new System.Drawing.Size(632, 509);
            this.documentControl.TabIndex = 0;
            this.documentControl.ValidationEnabled = true;
            // 
            // btnEditDocumentObject
            // 
            this.btnEditDocumentObject.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEditDocumentObject.Location = new System.Drawing.Point(403, 562);
            this.btnEditDocumentObject.Name = "btnEditDocumentObject";
            this.btnEditDocumentObject.Size = new System.Drawing.Size(75, 23);
            this.btnEditDocumentObject.TabIndex = 7;
            this.btnEditDocumentObject.Text = "Edit";
            this.btnEditDocumentObject.UseVisualStyleBackColor = true;
            this.btnEditDocumentObject.Click += new System.EventHandler(this.btnEditDocumentObject_Click);
            // 
            // DocumentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(652, 593);
            this.Controls.Add(this.btnEditDocumentObject);
            this.Controls.Add(this.toolStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(469, 321);
            this.Name = "DocumentForm";
            this.Text = "Document";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DocumentForm_FormClosing);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.btnOk, 0);
            this.Controls.SetChildIndex(this.btnCancel, 0);
            this.Controls.SetChildIndex(this.toolStrip1, 0);
            this.Controls.SetChildIndex(this.lblDenoteRequiredField, 0);
            this.Controls.SetChildIndex(this.btnEditDocumentObject, 0);
            this.panel1.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DocumentControl documentControl;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnImportDocument;
        private System.Windows.Forms.ToolStripButton btnExportDocument;
        private System.Windows.Forms.ToolStripLabel lblDocumentType;
        private System.Windows.Forms.ToolStripComboBox cmbDocumentType;
        private System.Windows.Forms.ToolStripButton btnSaveToDatabase;
        private System.Windows.Forms.Button btnEditDocumentObject;
    }
}