/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
* 
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

namespace ATMLCommonLibrary.controls.document
{
    partial class DocumentReferenceForm
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
            this.documentReferenceControl1 = new ATMLCommonLibrary.controls.document.DocumentReferenceControl();
            this.btnEditDocumentObject = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.documentReferenceControl1);
            // 
            // documentReferenceControl1
            // 
            this.documentReferenceControl1.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.documentReferenceControl1.BackColor = System.Drawing.Color.Transparent;
            this.documentReferenceControl1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.documentReferenceControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.documentReferenceControl1.Location = new System.Drawing.Point(0, 0);
            this.documentReferenceControl1.Name = "documentReferenceControl1";
            this.documentReferenceControl1.Size = new System.Drawing.Size(433, 270);
            this.documentReferenceControl1.TabIndex = 0;
            // 
            // btnEditDocumentObject
            // 
            this.btnEditDocumentObject.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEditDocumentObject.Location = new System.Drawing.Point(210, 288);
            this.btnEditDocumentObject.Name = "btnEditDocumentObject";
            this.btnEditDocumentObject.Size = new System.Drawing.Size(75, 23);
            this.btnEditDocumentObject.TabIndex = 7;
            this.btnEditDocumentObject.Text = "Edit";
            this.btnEditDocumentObject.UseVisualStyleBackColor = true;
            this.btnEditDocumentObject.Click += new System.EventHandler(this.btnEditDocumentObject_Click);
            // 
            // DocumentReferenceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(458, 315);
            this.Controls.Add(this.btnEditDocumentObject);
            this.Name = "DocumentReferenceForm";
            this.Text = "Document Reference";
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.btnOk, 0);
            this.Controls.SetChildIndex(this.btnCancel, 0);
            this.Controls.SetChildIndex(this.lblDenoteRequiredField, 0);
            this.Controls.SetChildIndex(this.btnEditDocumentObject, 0);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DocumentReferenceControl documentReferenceControl1;
        private System.Windows.Forms.Button btnEditDocumentObject;
    }
}