/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
*
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/
namespace ATMLCommonLibrary.controls.hardware
{
    partial class VersionIdentifierControl
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
            this.cmbVersionIdentifierQualifier = new System.Windows.Forms.ComboBox();
            this.lblVersionQualifier = new ATMLCommonLibrary.controls.HelpLabel(this.components);
            this.edtVersion = new ATMLCommonLibrary.controls.awb.AWBTextBox(this.components);
            this.lblVersion = new ATMLCommonLibrary.controls.HelpLabel(this.components);
            this.edtVersionName = new ATMLCommonLibrary.controls.awb.AWBTextBox(this.components);
            this.lblVersionName = new ATMLCommonLibrary.controls.HelpLabel(this.components);
            this.requiredVersionValidator = new ATMLCommonLibrary.controls.validators.RequiredFieldValidator();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.requiredQualifierValidator = new ATMLCommonLibrary.controls.validators.RequiredFieldValidator();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbVersionIdentifierQualifier
            // 
            this.cmbVersionIdentifierQualifier.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbVersionIdentifierQualifier.FormattingEnabled = true;
            this.cmbVersionIdentifierQualifier.Location = new System.Drawing.Point(219, 38);
            this.cmbVersionIdentifierQualifier.Name = "cmbVersionIdentifierQualifier";
            this.cmbVersionIdentifierQualifier.Size = new System.Drawing.Size(66, 21);
            this.cmbVersionIdentifierQualifier.TabIndex = 5;
            // 
            // lblVersionQualifier
            // 
            this.lblVersionQualifier.HelpMessageKey = "VersionIdentifier.VersionQualifier";
            this.lblVersionQualifier.Location = new System.Drawing.Point(160, 40);
            this.lblVersionQualifier.Name = "lblVersionQualifier";
            this.lblVersionQualifier.RequiredField = true;
            this.lblVersionQualifier.RequiredFieldMarkerFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVersionQualifier.Size = new System.Drawing.Size(51, 13);
            this.lblVersionQualifier.TabIndex = 4;
            this.lblVersionQualifier.Text = "Qualifier";
            this.lblVersionQualifier.Click += new System.EventHandler(this.lblVersionQualifier_Click);
            // 
            // edtVersion
            // 
            this.edtVersion.AttributeName = null;
            this.edtVersion.Location = new System.Drawing.Point(86, 38);
            this.edtVersion.Name = "edtVersion";
            this.edtVersion.Size = new System.Drawing.Size(56, 20);
            this.edtVersion.TabIndex = 3;
            this.edtVersion.Value = null;
            this.edtVersion.ValueType = ATMLCommonLibrary.controls.awb.AWBTextBox.eValueType.xsString;
            // 
            // lblVersion
            // 
            this.lblVersion.HelpMessageKey = "VersionIdentifier.Version";
            this.lblVersion.Location = new System.Drawing.Point(10, 40);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.RequiredField = true;
            this.lblVersion.RequiredFieldMarkerFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVersion.Size = new System.Drawing.Size(48, 13);
            this.lblVersion.TabIndex = 2;
            this.lblVersion.Text = "Version";
            // 
            // edtVersionName
            // 
            this.edtVersionName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtVersionName.AttributeName = null;
            this.edtVersionName.Location = new System.Drawing.Point(86, 12);
            this.edtVersionName.Name = "edtVersionName";
            this.edtVersionName.Size = new System.Drawing.Size(199, 20);
            this.edtVersionName.TabIndex = 1;
            this.edtVersionName.Value = null;
            this.edtVersionName.ValueType = ATMLCommonLibrary.controls.awb.AWBTextBox.eValueType.xsString;
            // 
            // lblVersionName
            // 
            this.lblVersionName.AutoSize = true;
            this.lblVersionName.HelpMessageKey = "VersionIdentifier.VersionName";
            this.lblVersionName.Location = new System.Drawing.Point(10, 13);
            this.lblVersionName.Name = "lblVersionName";
            this.lblVersionName.RequiredField = false;
            this.lblVersionName.RequiredFieldMarkerFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVersionName.Size = new System.Drawing.Size(73, 13);
            this.lblVersionName.TabIndex = 0;
            this.lblVersionName.Text = "Version Name";
            // 
            // requiredVersionValidator
            // 
            this.requiredVersionValidator.ControlToValidate = this.edtVersion;
            this.requiredVersionValidator.ErrorMessage = "The Version is required";
            this.requiredVersionValidator.ErrorProvider = this.errorProvider;
            this.requiredVersionValidator.Icon = null;
            this.requiredVersionValidator.InitialValue = null;
            this.requiredVersionValidator.IsEnabled = true;
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // requiredQualifierValidator
            // 
            this.requiredQualifierValidator.ControlToValidate = this.cmbVersionIdentifierQualifier;
            this.requiredQualifierValidator.ErrorMessage = "The Qualifier is required";
            this.requiredQualifierValidator.ErrorProvider = this.errorProvider;
            this.requiredQualifierValidator.Icon = null;
            this.requiredQualifierValidator.InitialValue = null;
            this.requiredQualifierValidator.IsEnabled = true;
            // 
            // VersionIdentifierControl
            // 
            this.Controls.Add(this.cmbVersionIdentifierQualifier);
            this.Controls.Add(this.lblVersionQualifier);
            this.Controls.Add(this.edtVersion);
            this.Controls.Add(this.lblVersion);
            this.Controls.Add(this.edtVersionName);
            this.Controls.Add(this.lblVersionName);
            this.Name = "VersionIdentifierControl";
            this.Size = new System.Drawing.Size(307, 65);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected HelpLabel lblVersionName;
        protected awb.AWBTextBox edtVersionName;
        protected awb.AWBTextBox edtVersion;
        protected HelpLabel lblVersion;
        protected HelpLabel lblVersionQualifier;
        protected System.Windows.Forms.ComboBox cmbVersionIdentifierQualifier;
        private validators.RequiredFieldValidator requiredVersionValidator;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private validators.RequiredFieldValidator requiredQualifierValidator;
    }
}
