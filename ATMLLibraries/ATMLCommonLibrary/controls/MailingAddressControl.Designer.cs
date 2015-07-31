/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
*
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/
namespace ATMLCommonLibrary.controls
{
    partial class MailingAddressControl
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.cbMailingState = new System.Windows.Forms.ComboBox();
            this.cbMailingCountry = new System.Windows.Forms.ComboBox();
            this.edtMailingPostalCode = new ATMLCommonLibrary.controls.awb.AWBTextBox(this.components);
            this.label6 = new ATMLCommonLibrary.controls.HelpLabel(this.components);
            this.label7 = new ATMLCommonLibrary.controls.HelpLabel(this.components);
            this.label8 = new ATMLCommonLibrary.controls.HelpLabel(this.components);
            this.edtMailingCity = new ATMLCommonLibrary.controls.awb.AWBTextBox(this.components);
            this.label9 = new ATMLCommonLibrary.controls.HelpLabel(this.components);
            this.edtMailingAddress2 = new ATMLCommonLibrary.controls.awb.AWBTextBox(this.components);
            this.edtMailingAddress1 = new ATMLCommonLibrary.controls.awb.AWBTextBox(this.components);
            this.label10 = new ATMLCommonLibrary.controls.HelpLabel(this.components);
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.requiredAddress1Validator = new ATMLCommonLibrary.controls.validators.RequiredFieldValidator();
            this.requiredCityValidator = new ATMLCommonLibrary.controls.validators.RequiredFieldValidator();
            this.requiredPostalCodeValidator = new ATMLCommonLibrary.controls.validators.RequiredFieldValidator();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.Controls.Add(this.cbMailingState);
            this.panel2.Controls.Add(this.cbMailingCountry);
            this.panel2.Controls.Add(this.edtMailingPostalCode);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.edtMailingCity);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.edtMailingAddress2);
            this.panel2.Controls.Add(this.edtMailingAddress1);
            this.panel2.Controls.Add(this.label10);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(185, 156);
            this.panel2.TabIndex = 9;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // cbMailingState
            // 
            this.cbMailingState.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbMailingState.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMailingState.FormattingEnabled = true;
            this.cbMailingState.Location = new System.Drawing.Point(89, 101);
            this.cbMailingState.Name = "cbMailingState";
            this.cbMailingState.Size = new System.Drawing.Size(77, 21);
            this.cbMailingState.TabIndex = 8;
            this.cbMailingState.BindingContextChanged += new System.EventHandler(this.cbMailingState_BindingContextChanged);
            // 
            // cbMailingCountry
            // 
            this.cbMailingCountry.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbMailingCountry.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMailingCountry.FormattingEnabled = true;
            this.cbMailingCountry.Location = new System.Drawing.Point(89, 77);
            this.cbMailingCountry.Name = "cbMailingCountry";
            this.cbMailingCountry.Size = new System.Drawing.Size(77, 21);
            this.cbMailingCountry.TabIndex = 6;
            this.cbMailingCountry.SelectedIndexChanged += new System.EventHandler(this.cbMailingCountry_SelectedIndexChanged);
            this.cbMailingCountry.ValueMemberChanged += new System.EventHandler(this.cbMailingCountry_ValueMemberChanged);
            this.cbMailingCountry.SelectedValueChanged += new System.EventHandler(this.cbMailingCountry_SelectedValueChanged);
            this.cbMailingCountry.BindingContextChanged += new System.EventHandler(this.cbMailingCountry_BindingContextChanged);
            this.cbMailingCountry.TextChanged += new System.EventHandler(this.cbMailingCountry_TextChanged);
            // 
            // edtMailingPostalCode
            // 
            this.edtMailingPostalCode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtMailingPostalCode.AttributeName = null;
            this.edtMailingPostalCode.Location = new System.Drawing.Point(89, 125);
            this.edtMailingPostalCode.Name = "edtMailingPostalCode";
            this.edtMailingPostalCode.Size = new System.Drawing.Size(77, 20);
            this.edtMailingPostalCode.TabIndex = 10;
            this.edtMailingPostalCode.Value = null;
            this.edtMailingPostalCode.ValueType = ATMLCommonLibrary.controls.awb.AWBTextBox.eValueType.xsString;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.HelpMessageKey = "ManufacturerData.postalCode";
            this.label6.Location = new System.Drawing.Point(11, 128);
            this.label6.Name = "label6";
            this.label6.RequiredField = true;
            this.label6.RequiredFieldMarkerFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Size = new System.Drawing.Size(67, 13);
            this.label6.TabIndex = 9;
            this.label6.Text = "Postal Code:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.HelpMessageKey = "te";
            this.label7.Location = new System.Drawing.Point(43, 104);
            this.label7.Name = "label7";
            this.label7.RequiredField = false;
            this.label7.RequiredFieldMarkerFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Size = new System.Drawing.Size(35, 13);
            this.label7.TabIndex = 7;
            this.label7.Text = "State:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.HelpMessageKey = "ManufacturerData.country";
            this.label8.Location = new System.Drawing.Point(32, 80);
            this.label8.Name = "label8";
            this.label8.RequiredField = true;
            this.label8.RequiredFieldMarkerFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Size = new System.Drawing.Size(46, 13);
            this.label8.TabIndex = 5;
            this.label8.Text = "Country:";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // edtMailingCity
            // 
            this.edtMailingCity.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtMailingCity.AttributeName = null;
            this.edtMailingCity.Location = new System.Drawing.Point(89, 53);
            this.edtMailingCity.Name = "edtMailingCity";
            this.edtMailingCity.Size = new System.Drawing.Size(77, 20);
            this.edtMailingCity.TabIndex = 4;
            this.edtMailingCity.Value = null;
            this.edtMailingCity.ValueType = ATMLCommonLibrary.controls.awb.AWBTextBox.eValueType.xsString;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.HelpMessageKey = "ManufacturerData.city";
            this.label9.Location = new System.Drawing.Point(51, 56);
            this.label9.Name = "label9";
            this.label9.RequiredField = true;
            this.label9.RequiredFieldMarkerFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Size = new System.Drawing.Size(27, 13);
            this.label9.TabIndex = 3;
            this.label9.Text = "City:";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // edtMailingAddress2
            // 
            this.edtMailingAddress2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtMailingAddress2.AttributeName = null;
            this.edtMailingAddress2.Location = new System.Drawing.Point(89, 30);
            this.edtMailingAddress2.Name = "edtMailingAddress2";
            this.edtMailingAddress2.Size = new System.Drawing.Size(77, 20);
            this.edtMailingAddress2.TabIndex = 2;
            this.edtMailingAddress2.Value = null;
            this.edtMailingAddress2.ValueType = ATMLCommonLibrary.controls.awb.AWBTextBox.eValueType.xsString;
            // 
            // edtMailingAddress1
            // 
            this.edtMailingAddress1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtMailingAddress1.AttributeName = null;
            this.edtMailingAddress1.Location = new System.Drawing.Point(89, 7);
            this.edtMailingAddress1.Name = "edtMailingAddress1";
            this.edtMailingAddress1.Size = new System.Drawing.Size(77, 20);
            this.edtMailingAddress1.TabIndex = 1;
            this.edtMailingAddress1.Value = null;
            this.edtMailingAddress1.ValueType = ATMLCommonLibrary.controls.awb.AWBTextBox.eValueType.xsString;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.HelpMessageKey = "ManufacturerData.address";
            this.label10.Location = new System.Drawing.Point(30, 9);
            this.label10.Name = "label10";
            this.label10.RequiredField = true;
            this.label10.RequiredFieldMarkerFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Size = new System.Drawing.Size(48, 13);
            this.label10.TabIndex = 0;
            this.label10.Text = "Address:";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // requiredAddress1Validator
            // 
            this.requiredAddress1Validator.ControlToValidate = this.edtMailingAddress1;
            this.requiredAddress1Validator.ErrorMessage = "The street address is required";
            this.requiredAddress1Validator.ErrorProvider = this.errorProvider;
            this.requiredAddress1Validator.Icon = null;
            this.requiredAddress1Validator.InitialValue = null;
            this.requiredAddress1Validator.IsEnabled = true;
            // 
            // requiredCityValidator
            // 
            this.requiredCityValidator.ControlToValidate = this.edtMailingCity;
            this.requiredCityValidator.ErrorMessage = "The city name is required";
            this.requiredCityValidator.ErrorProvider = this.errorProvider;
            this.requiredCityValidator.Icon = null;
            this.requiredCityValidator.InitialValue = null;
            this.requiredCityValidator.IsEnabled = true;
            // 
            // requiredPostalCodeValidator
            // 
            this.requiredPostalCodeValidator.ControlToValidate = this.edtMailingPostalCode;
            this.requiredPostalCodeValidator.ErrorMessage = "The postal code is required";
            this.requiredPostalCodeValidator.ErrorProvider = this.errorProvider;
            this.requiredPostalCodeValidator.Icon = null;
            this.requiredPostalCodeValidator.InitialValue = null;
            this.requiredPostalCodeValidator.IsEnabled = true;
            // 
            // MailingAddressControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel2);
            this.MinimumSize = new System.Drawing.Size(185, 156);
            this.Name = "MailingAddressControl";
            this.Size = new System.Drawing.Size(185, 156);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ComboBox cbMailingState;
        private System.Windows.Forms.ComboBox cbMailingCountry;
        private ATMLCommonLibrary.controls.awb.AWBTextBox edtMailingPostalCode;
        private HelpLabel label6;
        private HelpLabel label7;
        private HelpLabel label8;
        private ATMLCommonLibrary.controls.awb.AWBTextBox edtMailingCity;
        private HelpLabel label9;
        private ATMLCommonLibrary.controls.awb.AWBTextBox edtMailingAddress2;
        private ATMLCommonLibrary.controls.awb.AWBTextBox edtMailingAddress1;
        private HelpLabel label10;
        private validators.RequiredFieldValidator requiredAddress1Validator;
        private validators.RequiredFieldValidator requiredCityValidator;
        private validators.RequiredFieldValidator requiredPostalCodeValidator;
        protected System.Windows.Forms.ErrorProvider errorProvider;
    }
}
