/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
*
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/
namespace ATMLCommonLibrary.forms
{
    partial class IdentificationNumberForm
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
            this.rbManufacturerId = new System.Windows.Forms.RadioButton();
            this.rbUserId = new System.Windows.Forms.RadioButton();
            this.lblMfrName = new ATMLCommonLibrary.controls.HelpLabel(this.components);
            this.edtManufacturerName = new ATMLCommonLibrary.controls.awb.AWBTextBox();
            this.lblQualifier = new ATMLCommonLibrary.controls.HelpLabel(this.components);
            this.lblType = new ATMLCommonLibrary.controls.HelpLabel(this.components);
            this.lblNumber = new ATMLCommonLibrary.controls.HelpLabel(this.components);
            this.cmbType = new System.Windows.Forms.ComboBox();
            this.edtQualifier = new ATMLCommonLibrary.controls.awb.AWBTextBox();
            this.edtNumber = new ATMLCommonLibrary.controls.awb.AWBTextBox();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.requiredNumberValidator = new ATMLCommonLibrary.controls.validators.RequiredFieldValidator();
            this.requiredQualifierValidator = new ATMLCommonLibrary.controls.validators.RequiredFieldValidator();
            this.requiredMfrNameValidator = new ATMLCommonLibrary.controls.validators.RequiredFieldValidator();
            this.requiredTypeValidator = new ATMLCommonLibrary.controls.validators.RequiredFieldValidator();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.rbManufacturerId);
            this.panel1.Controls.Add(this.rbUserId);
            this.panel1.Controls.Add(this.lblMfrName);
            this.panel1.Controls.Add(this.edtManufacturerName);
            this.panel1.Controls.Add(this.lblQualifier);
            this.panel1.Controls.Add(this.lblType);
            this.panel1.Controls.Add(this.lblNumber);
            this.panel1.Controls.Add(this.cmbType);
            this.panel1.Controls.Add(this.edtQualifier);
            this.panel1.Controls.Add(this.edtNumber);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Size = new System.Drawing.Size(361, 183);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(298, 201);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(217, 201);
            // 
            // lblDenoteRequiredField
            // 
            this.lblDenoteRequiredField.Location = new System.Drawing.Point(-2, 215);
            // 
            // rbManufacturerId
            // 
            this.rbManufacturerId.AutoSize = true;
            this.rbManufacturerId.Location = new System.Drawing.Point(153, 12);
            this.rbManufacturerId.Name = "rbManufacturerId";
            this.rbManufacturerId.Size = new System.Drawing.Size(131, 17);
            this.rbManufacturerId.TabIndex = 9;
            this.rbManufacturerId.TabStop = true;
            this.rbManufacturerId.Text = "Manufacturer Identifier";
            this.rbManufacturerId.UseVisualStyleBackColor = true;
            this.rbManufacturerId.CheckedChanged += new System.EventHandler(this.rbManufacturerId_CheckedChanged);
            // 
            // rbUserId
            // 
            this.rbUserId.AutoSize = true;
            this.rbUserId.Location = new System.Drawing.Point(17, 12);
            this.rbUserId.Name = "rbUserId";
            this.rbUserId.Size = new System.Drawing.Size(130, 17);
            this.rbUserId.TabIndex = 8;
            this.rbUserId.TabStop = true;
            this.rbUserId.Text = "User Defined Identifier";
            this.rbUserId.UseVisualStyleBackColor = true;
            this.rbUserId.CheckedChanged += new System.EventHandler(this.rbUserId_CheckedChanged);
            // 
            // lblMfrName
            // 
            this.lblMfrName.HelpMessageKey = "InformationNumber.manufacturerName";
            this.lblMfrName.Location = new System.Drawing.Point(9, 148);
            this.lblMfrName.Name = "lblMfrName";
            this.lblMfrName.RequiredField = false;
            this.lblMfrName.RequiredFieldMarkerFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMfrName.Size = new System.Drawing.Size(58, 13);
            this.lblMfrName.TabIndex = 6;
            this.lblMfrName.Text = "Mfr Name:";
            this.lblMfrName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // edtManufacturerName
            // 
            this.edtManufacturerName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.edtManufacturerName.Location = new System.Drawing.Point(70, 146);
            this.edtManufacturerName.Name = "edtManufacturerName";
            this.edtManufacturerName.Size = new System.Drawing.Size(270, 20);
            this.edtManufacturerName.TabIndex = 7;
            this.edtManufacturerName.Validating += new System.ComponentModel.CancelEventHandler(this.edtManufacturerName_Validating);
            // 
            // lblQualifier
            // 
            this.lblQualifier.HelpMessageKey = "InformationNumber.qualifier";
            this.lblQualifier.Location = new System.Drawing.Point(17, 113);
            this.lblQualifier.Name = "lblQualifier";
            this.lblQualifier.RequiredField = false;
            this.lblQualifier.RequiredFieldMarkerFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQualifier.Size = new System.Drawing.Size(51, 13);
            this.lblQualifier.TabIndex = 4;
            this.lblQualifier.Text = "Qualifier:";
            this.lblQualifier.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblType
            // 
            this.lblType.HelpMessageKey = "InformationNumber.type";
            this.lblType.Location = new System.Drawing.Point(25, 79);
            this.lblType.Name = "lblType";
            this.lblType.RequiredField = true;
            this.lblType.RequiredFieldMarkerFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblType.Size = new System.Drawing.Size(45, 13);
            this.lblType.TabIndex = 2;
            this.lblType.Text = "Type:";
            this.lblType.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblNumber
            // 
            this.lblNumber.HelpMessageKey = "InformationNumber.number";
            this.lblNumber.Location = new System.Drawing.Point(16, 48);
            this.lblNumber.Name = "lblNumber";
            this.lblNumber.RequiredField = true;
            this.lblNumber.RequiredFieldMarkerFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumber.Size = new System.Drawing.Size(54, 16);
            this.lblNumber.TabIndex = 0;
            this.lblNumber.Text = "Number:";
            this.lblNumber.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cmbType
            // 
            this.cmbType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbType.FormattingEnabled = true;
            this.cmbType.Items.AddRange(new object[] {
            "Part",
            "Model",
            "Other"});
            this.cmbType.Location = new System.Drawing.Point(70, 77);
            this.cmbType.Name = "cmbType";
            this.cmbType.Size = new System.Drawing.Size(270, 21);
            this.cmbType.TabIndex = 3;
            // 
            // edtQualifier
            // 
            this.edtQualifier.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.edtQualifier.Location = new System.Drawing.Point(70, 111);
            this.edtQualifier.Name = "edtQualifier";
            this.edtQualifier.Size = new System.Drawing.Size(270, 20);
            this.edtQualifier.TabIndex = 5;
            this.edtQualifier.Validating += new System.ComponentModel.CancelEventHandler(this.edtQualifier_Validating);
            // 
            // edtNumber
            // 
            this.edtNumber.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.edtNumber.Location = new System.Drawing.Point(70, 44);
            this.edtNumber.Name = "edtNumber";
            this.edtNumber.Size = new System.Drawing.Size(270, 20);
            this.edtNumber.TabIndex = 1;
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // requiredNumberValidator
            // 
            this.requiredNumberValidator.ControlToValidate = this.edtNumber;
            this.requiredNumberValidator.ErrorMessage = "The Identification Number is Required";
            this.requiredNumberValidator.ErrorProvider = this.errorProvider;
            this.requiredNumberValidator.Icon = null;
            this.requiredNumberValidator.InitialValue = null;
            this.requiredNumberValidator.IsEnabled = true;
            // 
            // requiredQualifierValidator
            // 
            this.requiredQualifierValidator.ControlToValidate = this.edtQualifier;
            this.requiredQualifierValidator.ErrorMessage = "The Qualifier is required";
            this.requiredQualifierValidator.ErrorProvider = this.errorProvider;
            this.requiredQualifierValidator.Icon = null;
            this.requiredQualifierValidator.InitialValue = null;
            this.requiredQualifierValidator.IsEnabled = true;
            // 
            // requiredMfrNameValidator
            // 
            this.requiredMfrNameValidator.ControlToValidate = this.edtManufacturerName;
            this.requiredMfrNameValidator.ErrorMessage = "The Manufacturer Name is required";
            this.requiredMfrNameValidator.ErrorProvider = this.errorProvider;
            this.requiredMfrNameValidator.Icon = null;
            this.requiredMfrNameValidator.InitialValue = null;
            this.requiredMfrNameValidator.IsEnabled = true;
            // 
            // requiredTypeValidator
            // 
            this.requiredTypeValidator.ControlToValidate = this.cmbType;
            this.requiredTypeValidator.ErrorMessage = "The Identification Type is required";
            this.requiredTypeValidator.ErrorProvider = this.errorProvider;
            this.requiredTypeValidator.Icon = null;
            this.requiredTypeValidator.InitialValue = null;
            this.requiredTypeValidator.IsEnabled = true;
            // 
            // IdentificationNumberForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.ClientSize = new System.Drawing.Size(385, 229);
            this.MinimumSize = new System.Drawing.Size(393, 196);
            this.Name = "IdentificationNumberForm";
            this.Text = "Identification Number";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.IdentificationNumberForm_FormClosing);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ATMLCommonLibrary.controls.awb.AWBTextBox edtQualifier;
        private ATMLCommonLibrary.controls.HelpLabel lblQualifier;
        private ATMLCommonLibrary.controls.HelpLabel lblType;
        private ATMLCommonLibrary.controls.awb.AWBTextBox edtNumber;
        private ATMLCommonLibrary.controls.HelpLabel lblNumber;
        private System.Windows.Forms.ComboBox cmbType;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.RadioButton rbManufacturerId;
        private System.Windows.Forms.RadioButton rbUserId;
        private controls.HelpLabel lblMfrName;
        private ATMLCommonLibrary.controls.awb.AWBTextBox edtManufacturerName;
        private controls.validators.RequiredFieldValidator requiredNumberValidator;
        private controls.validators.RequiredFieldValidator requiredQualifierValidator;
        private controls.validators.RequiredFieldValidator requiredMfrNameValidator;
        private controls.validators.RequiredFieldValidator requiredTypeValidator;
    }
}