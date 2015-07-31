/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
* 
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

namespace ATMLCommonLibrary.controls.document
{
    partial class DocumentReferenceControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DocumentReferenceControl));
            this.edtDocumentID = new ATMLCommonLibrary.controls.awb.AWBTextBox(this.components);
            this.edtUUID = new ATMLCommonLibrary.controls.awb.AWBTextBox(this.components);
            this.helpLabel1 = new ATMLCommonLibrary.controls.HelpLabel(this.components);
            this.helpLabel2 = new ATMLCommonLibrary.controls.HelpLabel(this.components);
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.requiredIDValidator = new ATMLCommonLibrary.controls.validators.RequiredFieldValidator();
            this.requiredUUIDValidator = new ATMLCommonLibrary.controls.validators.RequiredFieldValidator();
            this.btnReferenceLookup = new System.Windows.Forms.Button();
            this.atmlPreviewPanel = new ATMLCommonLibrary.controls.ATMLPreviewPanel();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // edtDocumentID
            // 
            this.edtDocumentID.AttributeName = null;
            this.edtDocumentID.Location = new System.Drawing.Point(111, 10);
            this.edtDocumentID.Name = "edtDocumentID";
            this.edtDocumentID.Size = new System.Drawing.Size(100, 20);
            this.edtDocumentID.TabIndex = 1;
            this.edtDocumentID.Value = null;
            this.edtDocumentID.ValueType = ATMLCommonLibrary.controls.awb.AWBTextBox.eValueType.xsString;
            // 
            // edtUUID
            // 
            this.edtUUID.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtUUID.AttributeName = null;
            this.edtUUID.BackColor = System.Drawing.Color.Honeydew;
            this.edtUUID.Location = new System.Drawing.Point(110, 36);
            this.edtUUID.Name = "edtUUID";
            this.edtUUID.ReadOnly = true;
            this.edtUUID.Size = new System.Drawing.Size(277, 20);
            this.edtUUID.TabIndex = 3;
            this.edtUUID.Value = null;
            this.edtUUID.ValueType = ATMLCommonLibrary.controls.awb.AWBTextBox.eValueType.xsString;
            // 
            // helpLabel1
            // 
            this.helpLabel1.AutoSize = true;
            this.helpLabel1.HelpMessageKey = "DocumentReference.id";
            this.helpLabel1.Location = new System.Drawing.Point(9, 13);
            this.helpLabel1.Name = "helpLabel1";
            this.helpLabel1.RequiredField = false;
            this.helpLabel1.RequiredFieldMarkerFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.helpLabel1.Size = new System.Drawing.Size(70, 13);
            this.helpLabel1.TabIndex = 0;
            this.helpLabel1.Text = "Document ID";
            // 
            // helpLabel2
            // 
            this.helpLabel2.AutoSize = true;
            this.helpLabel2.HelpMessageKey = "DocumentReference.uuid";
            this.helpLabel2.Location = new System.Drawing.Point(9, 39);
            this.helpLabel2.Name = "helpLabel2";
            this.helpLabel2.RequiredField = false;
            this.helpLabel2.RequiredFieldMarkerFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.helpLabel2.Size = new System.Drawing.Size(86, 13);
            this.helpLabel2.TabIndex = 2;
            this.helpLabel2.Text = "Document UUID";
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // requiredIDValidator
            // 
            this.requiredIDValidator.ControlToValidate = this.edtDocumentID;
            this.requiredIDValidator.ErrorMessage = "The Document Id is Required";
            this.requiredIDValidator.ErrorProvider = this.errorProvider;
            this.requiredIDValidator.Icon = null;
            this.requiredIDValidator.InitialValue = null;
            this.requiredIDValidator.IsEnabled = true;
            // 
            // requiredUUIDValidator
            // 
            this.requiredUUIDValidator.ControlToValidate = this.edtUUID;
            this.requiredUUIDValidator.ErrorMessage = "The Document Universal Id is Required";
            this.requiredUUIDValidator.ErrorProvider = this.errorProvider;
            this.requiredUUIDValidator.Icon = null;
            this.requiredUUIDValidator.InitialValue = null;
            this.requiredUUIDValidator.IsEnabled = true;
            // 
            // btnReferenceLookup
            // 
            this.btnReferenceLookup.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReferenceLookup.FlatAppearance.BorderSize = 0;
            this.btnReferenceLookup.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReferenceLookup.Image = ((System.Drawing.Image)(resources.GetObject("btnReferenceLookup.Image")));
            this.btnReferenceLookup.Location = new System.Drawing.Point(390, 33);
            this.btnReferenceLookup.Name = "btnReferenceLookup";
            this.btnReferenceLookup.Size = new System.Drawing.Size(24, 23);
            this.btnReferenceLookup.TabIndex = 4;
            this.btnReferenceLookup.UseVisualStyleBackColor = true;
            this.btnReferenceLookup.Click += new System.EventHandler(this.btnReferenceLookup_Click);
            // 
            // atmlPreviewPanel
            // 
            this.atmlPreviewPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.atmlPreviewPanel.Location = new System.Drawing.Point(12, 67);
            this.atmlPreviewPanel.Name = "atmlPreviewPanel";
            this.atmlPreviewPanel.SchemaTypeName = null;
            this.atmlPreviewPanel.Size = new System.Drawing.Size(403, 146);
            this.atmlPreviewPanel.TabIndex = 6;
            this.atmlPreviewPanel.TargetNamespace = null;
            // 
            // DocumentReferenceControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.BackColor = System.Drawing.Color.Transparent;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.atmlPreviewPanel);
            this.Controls.Add(this.btnReferenceLookup);
            this.Controls.Add(this.helpLabel2);
            this.Controls.Add(this.helpLabel1);
            this.Controls.Add(this.edtUUID);
            this.Controls.Add(this.edtDocumentID);
            this.Name = "DocumentReferenceControl";
            this.Size = new System.Drawing.Size(430, 228);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected ATMLCommonLibrary.controls.awb.AWBTextBox edtDocumentID;
        protected ATMLCommonLibrary.controls.awb.AWBTextBox edtUUID;
        protected HelpLabel helpLabel1;
        protected HelpLabel helpLabel2;
        protected System.Windows.Forms.ErrorProvider errorProvider;
        private validators.RequiredFieldValidator requiredIDValidator;
        private validators.RequiredFieldValidator requiredUUIDValidator;
        protected System.Windows.Forms.Button btnReferenceLookup;
        protected ATMLPreviewPanel atmlPreviewPanel;
    }
}
