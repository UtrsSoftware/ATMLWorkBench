/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
*
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/
namespace ATMLCommonLibrary.controls.manufacturer
{
    partial class ManufacturerControl
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
            this.mailingAddressControl = new ATMLCommonLibrary.controls.MailingAddressControl();
            this.chkHasAddress = new System.Windows.Forms.CheckBox();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.requiredNameValidator = new ATMLCommonLibrary.controls.validators.RequiredFieldValidator();
            this.edtManufacturerName = new ATMLCommonLibrary.controls.awb.AWBTextBox(this.components);
            this.edtManufacturerFaxNumber = new ATMLCommonLibrary.controls.awb.AWBTextBox(this.components);
            this.label4 = new ATMLCommonLibrary.controls.HelpLabel(this.components);
            this.edtManufacturerURL = new ATMLCommonLibrary.controls.awb.AWBTextBox(this.components);
            this.label3 = new ATMLCommonLibrary.controls.HelpLabel(this.components);
            this.edtManufacturerCageCode = new ATMLCommonLibrary.controls.awb.AWBTextBox(this.components);
            this.label2 = new ATMLCommonLibrary.controls.HelpLabel(this.components);
            this.label1 = new ATMLCommonLibrary.controls.HelpLabel(this.components);
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabAddress = new System.Windows.Forms.TabPage();
            this.label5 = new ATMLCommonLibrary.controls.HelpLabel(this.components);
            this.tabContacts = new System.Windows.Forms.TabPage();
            this.manufacturerContactListControl = new ATMLCommonLibrary.controls.lists.ManufacturerContactListControl();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabAddress.SuspendLayout();
            this.tabContacts.SuspendLayout();
            this.SuspendLayout();
            // 
            // mailingAddressControl
            // 
            this.mailingAddressControl.BackColor = System.Drawing.Color.AliceBlue;
            this.mailingAddressControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mailingAddressControl.HasErrors = false;
            this.mailingAddressControl.HelpKeyWord = null;
            this.mailingAddressControl.LastError = null;
            this.mailingAddressControl.Location = new System.Drawing.Point(3, 3);
            this.mailingAddressControl.MinimumSize = new System.Drawing.Size(185, 156);
            this.mailingAddressControl.Name = "mailingAddressControl";
            this.mailingAddressControl.Padding = new System.Windows.Forms.Padding(0, 15, 0, 0);
            this.mailingAddressControl.SchemaTypeName = null;
            this.mailingAddressControl.Size = new System.Drawing.Size(217, 166);
            this.mailingAddressControl.TabIndex = 28;
            this.mailingAddressControl.TargetNamespace = null;
            this.mailingAddressControl.ValidationEndabled = true;
            // 
            // chkHasAddress
            // 
            this.chkHasAddress.Location = new System.Drawing.Point(89, 6);
            this.chkHasAddress.Name = "chkHasAddress";
            this.chkHasAddress.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkHasAddress.Size = new System.Drawing.Size(18, 16);
            this.chkHasAddress.TabIndex = 27;
            this.chkHasAddress.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.chkHasAddress.UseVisualStyleBackColor = true;
            this.chkHasAddress.CheckedChanged += new System.EventHandler(this.chkHasAddress_CheckedChanged_1);
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // requiredNameValidator
            // 
            this.requiredNameValidator.ControlToValidate = this.edtManufacturerName;
            this.requiredNameValidator.ErrorMessage = "The manufacturer name is required.";
            this.requiredNameValidator.ErrorProvider = this.errorProvider;
            this.requiredNameValidator.Icon = null;
            this.requiredNameValidator.InitialValue = null;
            this.requiredNameValidator.IsEnabled = true;
            // 
            // edtManufacturerName
            // 
            this.edtManufacturerName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtManufacturerName.AttributeName = null;
            this.edtManufacturerName.DataLookupKey = "Manufacturer";
            this.edtManufacturerName.Location = new System.Drawing.Point(89, 8);
            this.edtManufacturerName.Name = "edtManufacturerName";
            this.edtManufacturerName.Size = new System.Drawing.Size(130, 20);
            this.edtManufacturerName.TabIndex = 18;
            this.edtManufacturerName.Value = null;
            this.edtManufacturerName.ValueType = ATMLCommonLibrary.controls.awb.AWBTextBox.eValueType.xsString;
            // 
            // edtManufacturerFaxNumber
            // 
            this.edtManufacturerFaxNumber.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtManufacturerFaxNumber.AttributeName = null;
            this.edtManufacturerFaxNumber.DataLookupKey = "Fax";
            this.edtManufacturerFaxNumber.Location = new System.Drawing.Point(89, 79);
            this.edtManufacturerFaxNumber.Name = "edtManufacturerFaxNumber";
            this.edtManufacturerFaxNumber.Size = new System.Drawing.Size(130, 20);
            this.edtManufacturerFaxNumber.TabIndex = 24;
            this.edtManufacturerFaxNumber.Value = null;
            this.edtManufacturerFaxNumber.ValueType = ATMLCommonLibrary.controls.awb.AWBTextBox.eValueType.xsString;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.HelpMessageKey = "ManufacturerData.faxNumber";
            this.label4.Location = new System.Drawing.Point(12, 82);
            this.label4.Name = "label4";
            this.label4.RequiredField = false;
            this.label4.RequiredFieldMarkerFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Size = new System.Drawing.Size(67, 13);
            this.label4.TabIndex = 23;
            this.label4.Text = "Fax Number:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // edtManufacturerURL
            // 
            this.edtManufacturerURL.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtManufacturerURL.AttributeName = null;
            this.edtManufacturerURL.DataLookupKey = "URL";
            this.edtManufacturerURL.Location = new System.Drawing.Point(89, 55);
            this.edtManufacturerURL.Name = "edtManufacturerURL";
            this.edtManufacturerURL.Size = new System.Drawing.Size(130, 20);
            this.edtManufacturerURL.TabIndex = 22;
            this.edtManufacturerURL.Value = null;
            this.edtManufacturerURL.ValueType = ATMLCommonLibrary.controls.awb.AWBTextBox.eValueType.xsString;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.HelpMessageKey = "ManufacturerData.URL";
            this.label3.Location = new System.Drawing.Point(47, 57);
            this.label3.Name = "label3";
            this.label3.RequiredField = false;
            this.label3.RequiredFieldMarkerFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Size = new System.Drawing.Size(32, 13);
            this.label3.TabIndex = 21;
            this.label3.Text = "URL:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // edtManufacturerCageCode
            // 
            this.edtManufacturerCageCode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtManufacturerCageCode.AttributeName = null;
            this.edtManufacturerCageCode.DataLookupKey = "Cage";
            this.edtManufacturerCageCode.Location = new System.Drawing.Point(89, 31);
            this.edtManufacturerCageCode.Name = "edtManufacturerCageCode";
            this.edtManufacturerCageCode.Size = new System.Drawing.Size(130, 20);
            this.edtManufacturerCageCode.TabIndex = 20;
            this.edtManufacturerCageCode.Value = null;
            this.edtManufacturerCageCode.ValueType = ATMLCommonLibrary.controls.awb.AWBTextBox.eValueType.xsString;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.HelpMessageKey = "ManufacturerData.cageCode";
            this.label2.Location = new System.Drawing.Point(16, 33);
            this.label2.Name = "label2";
            this.label2.RequiredField = false;
            this.label2.RequiredFieldMarkerFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 19;
            this.label2.Text = "Cage Code:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.HelpMessageKey = "ManufacturerData.name";
            this.label1.Location = new System.Drawing.Point(36, 12);
            this.label1.Name = "label1";
            this.label1.RequiredField = true;
            this.label1.RequiredFieldMarkerFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 17;
            this.label1.Text = "Name:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabAddress);
            this.tabControl1.Controls.Add(this.tabContacts);
            this.tabControl1.Location = new System.Drawing.Point(5, 105);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.Padding = new System.Drawing.Point(0, 0);
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(231, 198);
            this.tabControl1.TabIndex = 29;
            // 
            // tabAddress
            // 
            this.tabAddress.Controls.Add(this.label5);
            this.tabAddress.Controls.Add(this.chkHasAddress);
            this.tabAddress.Controls.Add(this.mailingAddressControl);
            this.tabAddress.Location = new System.Drawing.Point(4, 22);
            this.tabAddress.Name = "tabAddress";
            this.tabAddress.Padding = new System.Windows.Forms.Padding(3);
            this.tabAddress.Size = new System.Drawing.Size(223, 172);
            this.tabAddress.TabIndex = 0;
            this.tabAddress.Text = "Address";
            this.tabAddress.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.HelpMessageKey = "ManufacturerData.HasAddress";
            this.label5.Location = new System.Drawing.Point(11, 5);
            this.label5.Name = "label5";
            this.label5.RequiredField = false;
            this.label5.RequiredFieldMarkerFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Size = new System.Drawing.Size(70, 13);
            this.label5.TabIndex = 29;
            this.label5.Text = "Has Address:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tabContacts
            // 
            this.tabContacts.Controls.Add(this.manufacturerContactListControl);
            this.tabContacts.Location = new System.Drawing.Point(4, 22);
            this.tabContacts.Name = "tabContacts";
            this.tabContacts.Padding = new System.Windows.Forms.Padding(3);
            this.tabContacts.Size = new System.Drawing.Size(223, 172);
            this.tabContacts.TabIndex = 1;
            this.tabContacts.Text = "Contacts";
            this.tabContacts.UseVisualStyleBackColor = true;
            // 
            // manufacturerContactListControl
            // 
            this.manufacturerContactListControl.AllowRowResequencing = false;
            this.manufacturerContactListControl.BackColor = System.Drawing.Color.AliceBlue;
            this.manufacturerContactListControl.Contacts = null;
            this.manufacturerContactListControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.manufacturerContactListControl.FormTitle = null;
            this.manufacturerContactListControl.HasErrors = false;
            this.manufacturerContactListControl.HelpKeyWord = null;
            this.manufacturerContactListControl.LastError = null;
            this.manufacturerContactListControl.ListName = null;
            this.manufacturerContactListControl.Location = new System.Drawing.Point(3, 3);
            this.manufacturerContactListControl.Margin = new System.Windows.Forms.Padding(0);
            this.manufacturerContactListControl.Name = "manufacturerContactListControl";
            this.manufacturerContactListControl.SchemaTypeName = null;
            this.manufacturerContactListControl.ShowFind = false;
            this.manufacturerContactListControl.Size = new System.Drawing.Size(217, 166);
            this.manufacturerContactListControl.TabIndex = 28;
            this.manufacturerContactListControl.TargetNamespace = null;
            this.manufacturerContactListControl.TooltipTextAddButton = "Press to add a new ";
            this.manufacturerContactListControl.TooltipTextDeleteButton = "Press to delete the selected ";
            this.manufacturerContactListControl.TooltipTextEditButton = "Press to edit the selected ";
            // 
            // ManufacturerControl
            // 
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.edtManufacturerFaxNumber);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.edtManufacturerURL);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.edtManufacturerCageCode);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.edtManufacturerName);
            this.Controls.Add(this.label1);
            this.Name = "ManufacturerControl";
            this.Size = new System.Drawing.Size(240, 307);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabAddress.ResumeLayout(false);
            this.tabAddress.PerformLayout();
            this.tabContacts.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MailingAddressControl mailingAddressControl;
        private System.Windows.Forms.CheckBox chkHasAddress;
        private awb.AWBTextBox edtManufacturerFaxNumber;
        private HelpLabel label4;
        private awb.AWBTextBox edtManufacturerURL;
        private HelpLabel label3;
        private awb.AWBTextBox edtManufacturerCageCode;
        private HelpLabel label2;
        private awb.AWBTextBox edtManufacturerName;
        private HelpLabel label1;
        private validators.RequiredFieldValidator requiredNameValidator;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabAddress;
        private System.Windows.Forms.TabPage tabContacts;
        private lists.ManufacturerContactListControl manufacturerContactListControl;
        private ATMLCommonLibrary.controls.HelpLabel label5;
        protected System.Windows.Forms.ErrorProvider errorProvider;
    }
}
