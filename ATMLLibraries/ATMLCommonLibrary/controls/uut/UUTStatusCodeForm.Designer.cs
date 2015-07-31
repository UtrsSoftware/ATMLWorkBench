/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
* 
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

namespace ATMLCommonLibrary.controls.uut
{
    partial class UUTStatusCodeForm
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
            this.edtStatusId = new ATMLCommonLibrary.controls.awb.AWBTextBox(this.components);
            this.helpLabel2 = new ATMLCommonLibrary.controls.HelpLabel(this.components);
            this.edtStatusCode = new ATMLCommonLibrary.controls.awb.AWBTextBox(this.components);
            this.edtStatusMeaning = new ATMLCommonLibrary.controls.awb.AWBTextBox(this.components);
            this.helpLabel3 = new ATMLCommonLibrary.controls.HelpLabel(this.components);
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.requiredIdValidator = new ATMLCommonLibrary.controls.validators.RequiredFieldValidator();
            this.requiredCodeValidator = new ATMLCommonLibrary.controls.validators.RequiredFieldValidator();
            this.requiredMeaningValidator = new ATMLCommonLibrary.controls.validators.RequiredFieldValidator();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.edtStatusMeaning);
            this.panel1.Controls.Add(this.helpLabel3);
            this.panel1.Controls.Add(this.edtStatusCode);
            this.panel1.Controls.Add(this.helpLabel2);
            this.panel1.Controls.Add(this.edtStatusId);
            this.panel1.Controls.Add(this.helpLabel1);
            this.panel1.Size = new System.Drawing.Size(334, 267);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(272, 285);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(191, 285);
            // 
            // lblDenoteRequiredField
            // 
            this.lblDenoteRequiredField.Location = new System.Drawing.Point(1, 296);
            // 
            // helpLabel1
            // 
            this.helpLabel1.AutoSize = true;
            this.helpLabel1.HelpMessageKey = "StatusCode.Id";
            this.helpLabel1.Location = new System.Drawing.Point(47, 18);
            this.helpLabel1.Name = "helpLabel1";
            this.helpLabel1.RequiredField = false;
            this.helpLabel1.RequiredFieldMarkerFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.helpLabel1.Size = new System.Drawing.Size(49, 13);
            this.helpLabel1.TabIndex = 0;
            this.helpLabel1.Text = "Status Id";
            // 
            // edtStatusId
            // 
            this.edtStatusId.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtStatusId.AttributeName = null;
            this.edtStatusId.Location = new System.Drawing.Point(102, 15);
            this.edtStatusId.Name = "edtStatusId";
            this.edtStatusId.Size = new System.Drawing.Size(208, 20);
            this.edtStatusId.TabIndex = 1;
            this.edtStatusId.Value = null;
            this.edtStatusId.ValueType = ATMLCommonLibrary.controls.awb.AWBTextBox.eValueType.xsString;
            // 
            // helpLabel2
            // 
            this.helpLabel2.AutoSize = true;
            this.helpLabel2.HelpMessageKey = "StatusCode.Code";
            this.helpLabel2.Location = new System.Drawing.Point(31, 44);
            this.helpLabel2.Name = "helpLabel2";
            this.helpLabel2.RequiredField = false;
            this.helpLabel2.RequiredFieldMarkerFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.helpLabel2.Size = new System.Drawing.Size(65, 13);
            this.helpLabel2.TabIndex = 0;
            this.helpLabel2.Text = "Status Code";
            // 
            // edtStatusCode
            // 
            this.edtStatusCode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtStatusCode.AttributeName = null;
            this.edtStatusCode.Location = new System.Drawing.Point(102, 41);
            this.edtStatusCode.Name = "edtStatusCode";
            this.edtStatusCode.Size = new System.Drawing.Size(208, 20);
            this.edtStatusCode.TabIndex = 1;
            this.edtStatusCode.Value = null;
            this.edtStatusCode.ValueType = ATMLCommonLibrary.controls.awb.AWBTextBox.eValueType.xsString;
            // 
            // edtStatusMeaning
            // 
            this.edtStatusMeaning.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtStatusMeaning.AttributeName = null;
            this.edtStatusMeaning.Location = new System.Drawing.Point(102, 67);
            this.edtStatusMeaning.Multiline = true;
            this.edtStatusMeaning.Name = "edtStatusMeaning";
            this.edtStatusMeaning.Size = new System.Drawing.Size(208, 182);
            this.edtStatusMeaning.TabIndex = 3;
            this.edtStatusMeaning.Value = null;
            this.edtStatusMeaning.ValueType = ATMLCommonLibrary.controls.awb.AWBTextBox.eValueType.xsString;
            // 
            // helpLabel3
            // 
            this.helpLabel3.AutoSize = true;
            this.helpLabel3.HelpMessageKey = "StatusCode.Meaning";
            this.helpLabel3.Location = new System.Drawing.Point(15, 70);
            this.helpLabel3.Name = "helpLabel3";
            this.helpLabel3.RequiredField = false;
            this.helpLabel3.RequiredFieldMarkerFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.helpLabel3.Size = new System.Drawing.Size(81, 13);
            this.helpLabel3.TabIndex = 2;
            this.helpLabel3.Text = "Status Meaning";
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // requiredIdValidator
            // 
            this.requiredIdValidator.ControlToValidate = this.edtStatusId;
            this.requiredIdValidator.ErrorMessage = "The Status Id is required.";
            this.requiredIdValidator.ErrorProvider = this.errorProvider;
            this.requiredIdValidator.Icon = null;
            this.requiredIdValidator.InitialValue = null;
            this.requiredIdValidator.IsEnabled = true;
            // 
            // requiredCodeValidator
            // 
            this.requiredCodeValidator.ControlToValidate = this.edtStatusCode;
            this.requiredCodeValidator.ErrorMessage = "The Status Code is required.";
            this.requiredCodeValidator.ErrorProvider = this.errorProvider;
            this.requiredCodeValidator.Icon = null;
            this.requiredCodeValidator.InitialValue = null;
            this.requiredCodeValidator.IsEnabled = true;
            // 
            // requiredMeaningValidator
            // 
            this.requiredMeaningValidator.ControlToValidate = this.edtStatusMeaning;
            this.requiredMeaningValidator.ErrorMessage = "The Status Meaning is required.";
            this.requiredMeaningValidator.ErrorProvider = this.errorProvider;
            this.requiredMeaningValidator.Icon = null;
            this.requiredMeaningValidator.InitialValue = null;
            this.requiredMeaningValidator.IsEnabled = true;
            // 
            // UUTStatusCodeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(359, 312);
            this.MinimumSize = new System.Drawing.Size(375, 350);
            this.Name = "UUTStatusCodeForm";
            this.Text = "Status Code";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private HelpLabel helpLabel1;
        private awb.AWBTextBox edtStatusMeaning;
        private HelpLabel helpLabel3;
        private awb.AWBTextBox edtStatusCode;
        private HelpLabel helpLabel2;
        private awb.AWBTextBox edtStatusId;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private validators.RequiredFieldValidator requiredIdValidator;
        private validators.RequiredFieldValidator requiredCodeValidator;
        private validators.RequiredFieldValidator requiredMeaningValidator;
    }
}