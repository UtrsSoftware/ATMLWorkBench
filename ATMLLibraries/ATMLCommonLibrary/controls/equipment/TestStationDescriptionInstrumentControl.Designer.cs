/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
* 
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

namespace ATMLCommonLibrary.controls.instrument
{
    partial class TestStationDescriptionInstrumentControl
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
            this.helpLabel1 = new ATMLCommonLibrary.controls.HelpLabel(this.components);
            this.edtId = new ATMLCommonLibrary.controls.awb.AWBTextBox(this.components);
            this.edtPhysicalLocation = new ATMLCommonLibrary.controls.awb.AWBTextBox(this.components);
            this.helpLabel3 = new ATMLCommonLibrary.controls.HelpLabel(this.components);
            this.edtAddress = new ATMLCommonLibrary.controls.awb.AWBTextBox(this.components);
            this.helpLabel4 = new ATMLCommonLibrary.controls.HelpLabel(this.components);
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.requiredIDValidator = new ATMLCommonLibrary.controls.validators.RequiredFieldValidator();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // rbDefinition
            // 
            this.rbDefinition.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbDefinition.ForeColor = System.Drawing.Color.AliceBlue;
            this.rbDefinition.Location = new System.Drawing.Point(165, 4);
            this.rbDefinition.Size = new System.Drawing.Size(79, 17);
            // 
            // rbDocumentReference
            // 
            this.rbDocumentReference.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbDocumentReference.ForeColor = System.Drawing.Color.AliceBlue;
            this.rbDocumentReference.Size = new System.Drawing.Size(145, 17);
            // 
            // documentReferenceControl
            // 
            this.documentReferenceControl.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.documentReferenceControl.Size = new System.Drawing.Size(542, 315);
            this.documentReferenceControl.Visible = true;
            // 
            // itemDescriptionControl
            // 
            this.itemDescriptionControl.Size = new System.Drawing.Size(542, 315);
            this.itemDescriptionControl.Visible = false;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Location = new System.Drawing.Point(1, 110);
            this.panel1.Size = new System.Drawing.Size(546, 319);
            // 
            // helpLabel1
            // 
            this.helpLabel1.AutoSize = true;
            this.helpLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.helpLabel1.ForeColor = System.Drawing.Color.AliceBlue;
            this.helpLabel1.HelpMessageKey = null;
            this.helpLabel1.Location = new System.Drawing.Point(95, 31);
            this.helpLabel1.Name = "helpLabel1";
            this.helpLabel1.RequiredField = false;
            this.helpLabel1.RequiredFieldMarkerFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.helpLabel1.Size = new System.Drawing.Size(20, 13);
            this.helpLabel1.TabIndex = 9;
            this.helpLabel1.Text = "ID";
            // 
            // edtId
            // 
            this.edtId.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtId.AttributeName = null;
            this.edtId.Location = new System.Drawing.Point(125, 29);
            this.edtId.Name = "edtId";
            this.edtId.Size = new System.Drawing.Size(397, 20);
            this.edtId.TabIndex = 10;
            this.edtId.Value = null;
            this.edtId.ValueType = ATMLCommonLibrary.controls.awb.AWBTextBox.eValueType.xsString;
            // 
            // edtPhysicalLocation
            // 
            this.edtPhysicalLocation.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtPhysicalLocation.AttributeName = null;
            this.edtPhysicalLocation.Location = new System.Drawing.Point(125, 55);
            this.edtPhysicalLocation.Name = "edtPhysicalLocation";
            this.edtPhysicalLocation.Size = new System.Drawing.Size(397, 20);
            this.edtPhysicalLocation.TabIndex = 12;
            this.edtPhysicalLocation.Value = null;
            this.edtPhysicalLocation.ValueType = ATMLCommonLibrary.controls.awb.AWBTextBox.eValueType.xsString;
            // 
            // helpLabel3
            // 
            this.helpLabel3.AutoSize = true;
            this.helpLabel3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.helpLabel3.ForeColor = System.Drawing.Color.AliceBlue;
            this.helpLabel3.HelpMessageKey = null;
            this.helpLabel3.Location = new System.Drawing.Point(8, 57);
            this.helpLabel3.Name = "helpLabel3";
            this.helpLabel3.RequiredField = false;
            this.helpLabel3.RequiredFieldMarkerFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.helpLabel3.Size = new System.Drawing.Size(107, 13);
            this.helpLabel3.TabIndex = 11;
            this.helpLabel3.Text = "Physical Location";
            // 
            // edtAddress
            // 
            this.edtAddress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtAddress.AttributeName = null;
            this.edtAddress.Location = new System.Drawing.Point(125, 81);
            this.edtAddress.Name = "edtAddress";
            this.edtAddress.Size = new System.Drawing.Size(397, 20);
            this.edtAddress.TabIndex = 14;
            this.edtAddress.Value = null;
            this.edtAddress.ValueType = ATMLCommonLibrary.controls.awb.AWBTextBox.eValueType.xsString;
            // 
            // helpLabel4
            // 
            this.helpLabel4.AutoSize = true;
            this.helpLabel4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.helpLabel4.ForeColor = System.Drawing.Color.AliceBlue;
            this.helpLabel4.HelpMessageKey = null;
            this.helpLabel4.Location = new System.Drawing.Point(63, 83);
            this.helpLabel4.Name = "helpLabel4";
            this.helpLabel4.RequiredField = false;
            this.helpLabel4.RequiredFieldMarkerFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.helpLabel4.Size = new System.Drawing.Size(52, 13);
            this.helpLabel4.TabIndex = 13;
            this.helpLabel4.Text = "Address";
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // requiredIDValidator
            // 
            this.requiredIDValidator.ControlToValidate = this.edtId;
            this.requiredIDValidator.ErrorMessage = "The ID is required";
            this.requiredIDValidator.ErrorProvider = this.errorProvider;
            this.requiredIDValidator.Icon = null;
            this.requiredIDValidator.InitialValue = null;
            this.requiredIDValidator.IsEnabled = true;
            // 
            // TestStationDescriptionInstrumentControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.BackColor = System.Drawing.Color.LightSlateGray;
            this.Controls.Add(this.edtAddress);
            this.Controls.Add(this.helpLabel4);
            this.Controls.Add(this.edtPhysicalLocation);
            this.Controls.Add(this.helpLabel3);
            this.Controls.Add(this.edtId);
            this.Controls.Add(this.helpLabel1);
            this.Name = "TestStationDescriptionInstrumentControl";
            this.Size = new System.Drawing.Size(550, 430);
            this.Controls.SetChildIndex(this.rbDocumentReference, 0);
            this.Controls.SetChildIndex(this.rbDefinition, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.helpLabel1, 0);
            this.Controls.SetChildIndex(this.edtId, 0);
            this.Controls.SetChildIndex(this.helpLabel3, 0);
            this.Controls.SetChildIndex(this.edtPhysicalLocation, 0);
            this.Controls.SetChildIndex(this.helpLabel4, 0);
            this.Controls.SetChildIndex(this.edtAddress, 0);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private HelpLabel helpLabel1;
        private awb.AWBTextBox edtId;
        private awb.AWBTextBox edtPhysicalLocation;
        private HelpLabel helpLabel3;
        private awb.AWBTextBox edtAddress;
        private HelpLabel helpLabel4;
        private validators.RequiredFieldValidator requiredIDValidator;
        protected System.Windows.Forms.ErrorProvider errorProvider;
    }
}
