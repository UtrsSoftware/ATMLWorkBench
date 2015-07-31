/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
*
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/
namespace ATMLCommonLibrary.controls.document
{
    partial class LegalDocumentForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LegalDocumentForm));
            this.legalDocumentsControl = new ATMLCommonLibrary.controls.hardware.LegalDocumentControl();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnImportDocument = new System.Windows.Forms.ToolStripButton();
            this.btnExportDocument = new System.Windows.Forms.ToolStripButton();
            this.btnSaveToDatabase = new System.Windows.Forms.ToolStripButton();
            this.panel1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.legalDocumentsControl);
            this.panel1.Location = new System.Drawing.Point(13, 47);
            this.panel1.Size = new System.Drawing.Size(433, 295);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(371, 347);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(290, 347);
            // 
            // lblDenoteRequiredField
            // 
            this.lblDenoteRequiredField.Location = new System.Drawing.Point(1, 358);
            // 
            // legalDocumentsControl
            // 
            this.legalDocumentsControl.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.legalDocumentsControl.BackColor = System.Drawing.Color.Transparent;
            this.legalDocumentsControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.legalDocumentsControl.Location = new System.Drawing.Point(0, 0);
            this.legalDocumentsControl.Name = "legalDocumentsControl";
            this.legalDocumentsControl.Size = new System.Drawing.Size(433, 295);
            this.legalDocumentsControl.TabIndex = 0;
            this.legalDocumentsControl.ValidationEnabled = true;
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.LightSlateGray;
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnImportDocument,
            this.btnExportDocument,
            this.btnSaveToDatabase});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Margin = new System.Windows.Forms.Padding(2);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Padding = new System.Windows.Forms.Padding(2);
            this.toolStrip1.Size = new System.Drawing.Size(458, 35);
            this.toolStrip1.TabIndex = 7;
            this.toolStrip1.Text = "toolStrip1";
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
            // LegalDocumentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(458, 374);
            this.Controls.Add(this.toolStrip1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "LegalDocumentForm";
            this.Text = "Legal Document";
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.btnOk, 0);
            this.Controls.SetChildIndex(this.btnCancel, 0);
            this.Controls.SetChildIndex(this.lblDenoteRequiredField, 0);
            this.Controls.SetChildIndex(this.toolStrip1, 0);
            this.panel1.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private hardware.LegalDocumentControl legalDocumentsControl;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnImportDocument;
        private System.Windows.Forms.ToolStripButton btnExportDocument;
        private System.Windows.Forms.ToolStripButton btnSaveToDatabase;
    }
}
