/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
* 
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

namespace ATMLCommonLibrary.controls.document
{
    partial class DocumentLibrarySelectionForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DocumentLibrarySelectionForm));
            this.panel2 = new System.Windows.Forms.Panel();
            this.cmbDocumentType = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.documentLibraryListControl = new ATMLCommonLibrary.controls.document.DocumentLibraryListControl();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.documentLibraryListControl);
            this.panel1.Controls.Add(this.panel2);
            // 
            // btnCancel
            // 
            this.btnCancel.Text = "Close";
            // 
            // btnOk
            // 
            this.btnOk.Text = "Select";
            // 
            // lblDenoteRequiredField
            // 
            this.lblDenoteRequiredField.Size = new System.Drawing.Size(0, 13);
            this.lblDenoteRequiredField.Text = "";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.cmbDocumentType);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(433, 31);
            this.panel2.TabIndex = 1;
            // 
            // cmbDocumentType
            // 
            this.cmbDocumentType.FormattingEnabled = true;
            this.cmbDocumentType.Location = new System.Drawing.Point(94, 5);
            this.cmbDocumentType.Name = "cmbDocumentType";
            this.cmbDocumentType.Size = new System.Drawing.Size(328, 21);
            this.cmbDocumentType.TabIndex = 1;
            this.cmbDocumentType.SelectedIndexChanged += new System.EventHandler(this.cmbDocumentType_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Document Type";
            // 
            // documentLibraryListControl
            // 
            this.documentLibraryListControl.AllowRowResequencing = false;
            this.documentLibraryListControl.BackColor = System.Drawing.Color.AliceBlue;
            this.documentLibraryListControl.DefaultDocumentType = ATMLDataAccessLibrary.model.dbDocument.DocumentType.NONE;
            this.documentLibraryListControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.documentLibraryListControl.FormTitle = null;
            this.documentLibraryListControl.HasErrors = false;
            this.documentLibraryListControl.HelpKeyWord = null;
            this.documentLibraryListControl.LastError = null;
            this.documentLibraryListControl.ListName = null;
            this.documentLibraryListControl.Location = new System.Drawing.Point(0, 31);
            this.documentLibraryListControl.Margin = new System.Windows.Forms.Padding(0);
            this.documentLibraryListControl.Name = "documentLibraryListControl";
            this.documentLibraryListControl.SchemaTypeName = null;
            this.documentLibraryListControl.ShowFind = false;
            this.documentLibraryListControl.Size = new System.Drawing.Size(433, 239);
            this.documentLibraryListControl.TabIndex = 2;
            this.documentLibraryListControl.TargetNamespace = null;
            this.documentLibraryListControl.TooltipTextAddButton = "Press to add a new ";
            this.documentLibraryListControl.TooltipTextDeleteButton = "Press to delete the selected ";
            this.documentLibraryListControl.TooltipTextEditButton = "Press to edit the selected ";
            // 
            // DocumentLibrarySelectionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(458, 315);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "DocumentLibrarySelectionForm";
            this.Text = "Document Selection";
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DocumentLibraryListControl documentLibraryListControl;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ComboBox cmbDocumentType;
        private System.Windows.Forms.Label label1;

    }
}
