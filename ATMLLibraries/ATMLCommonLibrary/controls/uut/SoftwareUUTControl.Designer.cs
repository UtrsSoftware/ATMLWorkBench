/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
*
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/
namespace ATMLCommonLibrary.controls.uut
{
    partial class SoftwareUUTControl
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabWarnings = new System.Windows.Forms.TabPage();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.tabWarningText = new System.Windows.Forms.TabPage();
            this.warningTextList = new ATMLCommonLibrary.controls.awb.AWBTextCollectionList();
            this.tabWarningDocuments = new System.Windows.Forms.TabPage();
            this.documentListControl = new ATMLCommonLibrary.controls.document.DocumentListControl();
            this.tabStatusCodes = new System.Windows.Forms.TabPage();
            this.statusCodeListControl = new ATMLCommonLibrary.controls.lists.ATMLListControl();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabWarnings.SuspendLayout();
            this.tabControl2.SuspendLayout();
            this.tabWarningText.SuspendLayout();
            this.tabWarningDocuments.SuspendLayout();
            this.tabStatusCodes.SuspendLayout();
            this.SuspendLayout();
            // 
            // edtName
            // 
            this.edtName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtName.Size = new System.Drawing.Size(380, 20);
            // 
            // identificationControl
            // 
            this.identificationControl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.identificationControl.Location = new System.Drawing.Point(7, 118);
            this.identificationControl.Size = new System.Drawing.Size(460, 165);
            // 
            // edtDescription
            // 
            this.edtDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtDescription.Size = new System.Drawing.Size(380, 33);
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabWarnings);
            this.tabControl1.Controls.Add(this.tabStatusCodes);
            this.tabControl1.Location = new System.Drawing.Point(7, 291);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(460, 163);
            this.tabControl1.TabIndex = 7;
            // 
            // tabWarnings
            // 
            this.tabWarnings.Controls.Add(this.tabControl2);
            this.tabWarnings.Location = new System.Drawing.Point(4, 22);
            this.tabWarnings.Name = "tabWarnings";
            this.tabWarnings.Padding = new System.Windows.Forms.Padding(3);
            this.tabWarnings.Size = new System.Drawing.Size(452, 137);
            this.tabWarnings.TabIndex = 1;
            this.tabWarnings.Text = "Warnings";
            this.tabWarnings.UseVisualStyleBackColor = true;
            // 
            // RequirementsTabControl
            // 
            this.tabControl2.Controls.Add(this.tabWarningText);
            this.tabControl2.Controls.Add(this.tabWarningDocuments);
            this.tabControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl2.Location = new System.Drawing.Point(3, 3);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(446, 131);
            this.tabControl2.TabIndex = 0;
            // 
            // tabWarningText
            // 
            this.tabWarningText.Controls.Add(this.warningTextList);
            this.tabWarningText.Location = new System.Drawing.Point(4, 22);
            this.tabWarningText.Name = "tabWarningText";
            this.tabWarningText.Padding = new System.Windows.Forms.Padding(3);
            this.tabWarningText.Size = new System.Drawing.Size(438, 105);
            this.tabWarningText.TabIndex = 0;
            this.tabWarningText.Text = "Warning Text";
            this.tabWarningText.UseVisualStyleBackColor = true;
            // 
            // warningTextList
            // 
            this.warningTextList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.warningTextList.HelpKeyWord = null;
            this.warningTextList.Location = new System.Drawing.Point(3, 3);
            this.warningTextList.Name = "warningTextList";
            this.warningTextList.SchemaTypeName = null;
            this.warningTextList.Size = new System.Drawing.Size(432, 99);
            this.warningTextList.TabIndex = 0;
            this.warningTextList.TargetNamespace = null;
            // 
            // tabWarningDocuments
            // 
            this.tabWarningDocuments.Controls.Add(this.documentListControl);
            this.tabWarningDocuments.Location = new System.Drawing.Point(4, 22);
            this.tabWarningDocuments.Name = "tabWarningDocuments";
            this.tabWarningDocuments.Padding = new System.Windows.Forms.Padding(3);
            this.tabWarningDocuments.Size = new System.Drawing.Size(438, 105);
            this.tabWarningDocuments.TabIndex = 1;
            this.tabWarningDocuments.Text = "Warning Documents";
            this.tabWarningDocuments.UseVisualStyleBackColor = true;
            // 
            // documentListControl
            // 
            this.documentListControl.AllowRowResequencing = false;
            this.documentListControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.documentListControl.DocumentType = ATMLDataAccessLibrary.model.dbDocument.DocumentType.NONE;
            this.documentListControl.FormTitle = null;
            this.documentListControl.HelpKeyWord = null;
            this.documentListControl.ListName = null;
            this.documentListControl.Location = new System.Drawing.Point(3, 3);
            this.documentListControl.Margin = new System.Windows.Forms.Padding(0);
            this.documentListControl.Name = "documentListControl";
            this.documentListControl.SchemaTypeName = null;
            this.documentListControl.ShowFind = false;
            this.documentListControl.Size = new System.Drawing.Size(432, 99);
            this.documentListControl.TabIndex = 0;
            this.documentListControl.TargetNamespace = null;
            this.documentListControl.TooltipTextAddButton = "Click to add a new Document";
            this.documentListControl.TooltipTextDeleteButton = "Click to delete the selected Document";
            this.documentListControl.TooltipTextEditButton = "Click to edit the selected Document";
            // 
            // tabStatusCodes
            // 
            this.tabStatusCodes.Controls.Add(this.statusCodeListControl);
            this.tabStatusCodes.Location = new System.Drawing.Point(4, 22);
            this.tabStatusCodes.Name = "tabStatusCodes";
            this.tabStatusCodes.Size = new System.Drawing.Size(452, 137);
            this.tabStatusCodes.TabIndex = 2;
            this.tabStatusCodes.Text = "Status Codes";
            this.tabStatusCodes.UseVisualStyleBackColor = true;
            // 
            // statusCodeListControl
            // 
            this.statusCodeListControl.AllowRowResequencing = false;
            this.statusCodeListControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.statusCodeListControl.FormTitle = null;
            this.statusCodeListControl.HelpKeyWord = null;
            this.statusCodeListControl.ListName = null;
            this.statusCodeListControl.Location = new System.Drawing.Point(0, 0);
            this.statusCodeListControl.Margin = new System.Windows.Forms.Padding(0);
            this.statusCodeListControl.Name = "statusCodeListControl";
            this.statusCodeListControl.SchemaTypeName = null;
            this.statusCodeListControl.ShowFind = false;
            this.statusCodeListControl.Size = new System.Drawing.Size(452, 137);
            this.statusCodeListControl.TabIndex = 1;
            this.statusCodeListControl.TargetNamespace = null;
            this.statusCodeListControl.TooltipTextAddButton = "Press to add a new ";
            this.statusCodeListControl.TooltipTextDeleteButton = "Press to delete the selected ";
            this.statusCodeListControl.TooltipTextEditButton = "Press to edit the selected ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(4, 102);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(81, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Identification";
            // 
            // SoftwareUUTControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tabControl1);
            this.Name = "SoftwareUUTControl";
            this.Size = new System.Drawing.Size(477, 465);
            this.Controls.SetChildIndex(this.tabControl1, 0);
            this.Controls.SetChildIndex(this.identificationControl, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.edtName, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.edtDescription, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.edtVersion, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabWarnings.ResumeLayout(false);
            this.tabControl2.ResumeLayout(false);
            this.tabWarningText.ResumeLayout(false);
            this.tabWarningDocuments.ResumeLayout(false);
            this.tabStatusCodes.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabWarnings;
        private System.Windows.Forms.TabPage tabStatusCodes;
        private lists.ATMLListControl statusCodeListControl;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TabControl tabControl2;
        private System.Windows.Forms.TabPage tabWarningText;
        private awb.AWBTextCollectionList warningTextList;
        private System.Windows.Forms.TabPage tabWarningDocuments;
        private document.DocumentListControl documentListControl;
    }
}
