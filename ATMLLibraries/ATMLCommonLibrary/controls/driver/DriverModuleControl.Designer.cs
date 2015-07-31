/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
*
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/
namespace ATMLCommonLibrary.controls.driver
{
    partial class DriverModuleControl
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
            this.gbTypeName = new System.Windows.Forms.GroupBox();
            this.edtInstallationDirectory = new ATMLCommonLibrary.controls.awb.AWBTextBox(this.components);
            this.helpLabel3 = new ATMLCommonLibrary.controls.HelpLabel(this.components);
            this.helpLabel1 = new ATMLCommonLibrary.controls.HelpLabel(this.components);
            this.edtFileName = new ATMLCommonLibrary.controls.awb.AWBTextBox(this.components);
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.requiredFileNameValidator = new ATMLCommonLibrary.controls.validators.RequiredFieldValidator();
            this.gbTypeName.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // gbTypeName
            // 
            this.gbTypeName.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbTypeName.Controls.Add(this.edtInstallationDirectory);
            this.gbTypeName.Controls.Add(this.helpLabel3);
            this.gbTypeName.Controls.Add(this.helpLabel1);
            this.gbTypeName.Controls.Add(this.edtFileName);
            this.gbTypeName.Location = new System.Drawing.Point(0, 0);
            this.gbTypeName.Name = "gbTypeName";
            this.gbTypeName.Size = new System.Drawing.Size(245, 80);
            this.gbTypeName.TabIndex = 11;
            this.gbTypeName.TabStop = false;
            this.gbTypeName.Text = "Type Name";
            // 
            // edtInstallationDirectory
            // 
            this.edtInstallationDirectory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtInstallationDirectory.AttributeName = null;
            this.edtInstallationDirectory.Location = new System.Drawing.Point(113, 47);
            this.edtInstallationDirectory.Name = "edtInstallationDirectory";
            this.edtInstallationDirectory.Size = new System.Drawing.Size(105, 20);
            this.edtInstallationDirectory.TabIndex = 10;
            this.edtInstallationDirectory.Tag = "";
            this.edtInstallationDirectory.Value = null;
            this.edtInstallationDirectory.ValueType = ATMLCommonLibrary.controls.awb.AWBTextBox.eValueType.xsString;
            // 
            // helpLabel3
            // 
            this.helpLabel3.HelpMessageKey = "DriverModule.FileName";
            this.helpLabel3.Location = new System.Drawing.Point(5, 23);
            this.helpLabel3.Name = "helpLabel3";
            this.helpLabel3.RequiredField = true;
            this.helpLabel3.RequiredFieldMarkerFont = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.helpLabel3.Size = new System.Drawing.Size(60, 13);
            this.helpLabel3.TabIndex = 7;
            this.helpLabel3.Text = "File Name";
            // 
            // helpLabel1
            // 
            this.helpLabel1.AutoSize = true;
            this.helpLabel1.HelpMessageKey = "DriverModule.InstallationDirectory";
            this.helpLabel1.Location = new System.Drawing.Point(5, 49);
            this.helpLabel1.Name = "helpLabel1";
            this.helpLabel1.RequiredField = false;
            this.helpLabel1.RequiredFieldMarkerFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.helpLabel1.Size = new System.Drawing.Size(102, 13);
            this.helpLabel1.TabIndex = 9;
            this.helpLabel1.Text = "Installation Directory";
            // 
            // edtFileName
            // 
            this.edtFileName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtFileName.AttributeName = null;
            this.edtFileName.Location = new System.Drawing.Point(81, 21);
            this.edtFileName.Name = "edtFileName";
            this.edtFileName.Size = new System.Drawing.Size(137, 20);
            this.edtFileName.TabIndex = 8;
            this.edtFileName.Value = null;
            this.edtFileName.ValueType = ATMLCommonLibrary.controls.awb.AWBTextBox.eValueType.xsString;
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // requiredFileNameValidator
            // 
            this.requiredFileNameValidator.ControlToValidate = this.edtFileName;
            this.requiredFileNameValidator.ErrorMessage = "The File Name is Required";
            this.requiredFileNameValidator.ErrorProvider = this.errorProvider;
            this.requiredFileNameValidator.Icon = null;
            this.requiredFileNameValidator.InitialValue = null;
            this.requiredFileNameValidator.IsEnabled = true;
            // 
            // DriverModuleControl
            // 
            this.Controls.Add(this.gbTypeName);
            this.MinimumSize = new System.Drawing.Size(250, 87);
            this.Name = "DriverModuleControl";
            this.Size = new System.Drawing.Size(250, 87);
            this.gbTypeName.ResumeLayout(false);
            this.gbTypeName.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private HelpLabel helpLabel3;
        private awb.AWBTextBox edtFileName;
        private awb.AWBTextBox edtInstallationDirectory;
        private HelpLabel helpLabel1;
        private System.Windows.Forms.GroupBox gbTypeName;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private validators.RequiredFieldValidator requiredFileNameValidator;
    }
}
