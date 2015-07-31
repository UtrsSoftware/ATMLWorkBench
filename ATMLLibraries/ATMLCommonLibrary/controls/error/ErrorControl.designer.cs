/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
*
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/
namespace ATMLCommonLibrary.controls.error
{
    partial class ErrorControl
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.helpLabel4 = new ATMLCommonLibrary.controls.HelpLabel(this.components);
            this.helpLabel3 = new ATMLCommonLibrary.controls.HelpLabel(this.components);
            this.helpLabel2 = new ATMLCommonLibrary.controls.HelpLabel(this.components);
            this.edtID = new ATMLCommonLibrary.controls.awb.AWBTextBox(this.components);
            this.edtSource = new ATMLCommonLibrary.controls.awb.AWBTextBox(this.components);
            this.edtType = new ATMLCommonLibrary.controls.awb.AWBTextBox(this.components);
            this.helpLabel1 = new ATMLCommonLibrary.controls.HelpLabel(this.components);
            this.edtDescription = new ATMLCommonLibrary.controls.awb.AWBTextBox(this.components);
            this.edtDescriptionValidate = new ATMLCommonLibrary.controls.validators.RequiredFieldValidator();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.edtIDValidate = new ATMLCommonLibrary.controls.validators.RequiredFieldValidator();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.helpLabel4);
            this.groupBox1.Controls.Add(this.helpLabel3);
            this.groupBox1.Controls.Add(this.helpLabel2);
            this.groupBox1.Controls.Add(this.edtID);
            this.groupBox1.Controls.Add(this.edtSource);
            this.groupBox1.Controls.Add(this.edtType);
            this.groupBox1.Location = new System.Drawing.Point(6, 31);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(250, 99);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Attributes";
            // 
            // helpLabel4
            // 
            this.helpLabel4.AutoSize = true;
            this.helpLabel4.HelpMessageKey = "ErrorControl.ID";
            this.helpLabel4.Location = new System.Drawing.Point(35, 75);
            this.helpLabel4.Name = "helpLabel4";
            this.helpLabel4.RequiredField = false;
            this.helpLabel4.RequiredFieldMarkerFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.helpLabel4.Size = new System.Drawing.Size(18, 13);
            this.helpLabel4.TabIndex = 5;
            this.helpLabel4.Text = "ID";
            // 
            // helpLabel3
            // 
            this.helpLabel3.AutoSize = true;
            this.helpLabel3.HelpMessageKey = "ErrorControl.Source";
            this.helpLabel3.Location = new System.Drawing.Point(12, 48);
            this.helpLabel3.Name = "helpLabel3";
            this.helpLabel3.RequiredField = false;
            this.helpLabel3.RequiredFieldMarkerFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.helpLabel3.Size = new System.Drawing.Size(41, 13);
            this.helpLabel3.TabIndex = 4;
            this.helpLabel3.Text = "Source";
            // 
            // helpLabel2
            // 
            this.helpLabel2.AutoSize = true;
            this.helpLabel2.HelpMessageKey = "ErrorControl.Type";
            this.helpLabel2.Location = new System.Drawing.Point(22, 22);
            this.helpLabel2.Name = "helpLabel2";
            this.helpLabel2.RequiredField = false;
            this.helpLabel2.RequiredFieldMarkerFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.helpLabel2.Size = new System.Drawing.Size(31, 13);
            this.helpLabel2.TabIndex = 3;
            this.helpLabel2.Text = "Type";
            // 
            // edtID
            // 
            this.edtID.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtID.AttributeName = null;
            this.edtID.DataLookupKey = null;
            this.edtID.Location = new System.Drawing.Point(61, 72);
            this.edtID.Name = "edtID";
            this.edtID.Size = new System.Drawing.Size(178, 20);
            this.edtID.TabIndex = 2;
            this.edtID.Value = null;
            this.edtID.ValueType = ATMLCommonLibrary.controls.awb.AWBTextBox.eValueType.xsString;
            // 
            // edtSource
            // 
            this.edtSource.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtSource.AttributeName = null;
            this.edtSource.DataLookupKey = null;
            this.edtSource.Location = new System.Drawing.Point(61, 45);
            this.edtSource.Name = "edtSource";
            this.edtSource.Size = new System.Drawing.Size(178, 20);
            this.edtSource.TabIndex = 1;
            this.edtSource.Value = null;
            this.edtSource.ValueType = ATMLCommonLibrary.controls.awb.AWBTextBox.eValueType.xsString;
            // 
            // edtType
            // 
            this.edtType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtType.AttributeName = null;
            this.edtType.DataLookupKey = null;
            this.edtType.Location = new System.Drawing.Point(61, 19);
            this.edtType.Name = "edtType";
            this.edtType.Size = new System.Drawing.Size(178, 20);
            this.edtType.TabIndex = 0;
            this.edtType.Value = null;
            this.edtType.ValueType = ATMLCommonLibrary.controls.awb.AWBTextBox.eValueType.xsString;
            // 
            // helpLabel1
            // 
            this.helpLabel1.AutoSize = true;
            this.helpLabel1.HelpMessageKey = "ErrorControl.Description";
            this.helpLabel1.Location = new System.Drawing.Point(3, 10);
            this.helpLabel1.Name = "helpLabel1";
            this.helpLabel1.RequiredField = false;
            this.helpLabel1.RequiredFieldMarkerFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.helpLabel1.Size = new System.Drawing.Size(60, 13);
            this.helpLabel1.TabIndex = 1;
            this.helpLabel1.Text = "Description";
            // 
            // edtDescription
            // 
            this.edtDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtDescription.AttributeName = null;
            this.edtDescription.DataLookupKey = null;
            this.edtDescription.Location = new System.Drawing.Point(68, 7);
            this.edtDescription.Name = "edtDescription";
            this.edtDescription.Size = new System.Drawing.Size(178, 20);
            this.edtDescription.TabIndex = 0;
            this.edtDescription.Value = null;
            this.edtDescription.ValueType = ATMLCommonLibrary.controls.awb.AWBTextBox.eValueType.xsString;
            // 
            // edtDescriptionValidate
            // 
            this.edtDescriptionValidate.ControlToValidate = this.edtDescription;
            this.edtDescriptionValidate.ErrorMessage = null;
            this.edtDescriptionValidate.ErrorProvider = this.errorProvider1;
            this.edtDescriptionValidate.Icon = null;
            this.edtDescriptionValidate.InitialValue = null;
            this.edtDescriptionValidate.IsEnabled = true;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // edtIDValidate
            // 
            this.edtIDValidate.ControlToValidate = this.edtID;
            this.edtIDValidate.ErrorMessage = null;
            this.edtIDValidate.ErrorProvider = this.errorProvider1;
            this.edtIDValidate.Icon = null;
            this.edtIDValidate.InitialValue = null;
            this.edtIDValidate.IsEnabled = true;
            // 
            // ErrorControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.helpLabel1);
            this.Controls.Add(this.edtDescription);
            this.Name = "ErrorControl";
            this.Size = new System.Drawing.Size(259, 138);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private awb.AWBTextBox edtDescription;
        private validators.RequiredFieldValidator edtDescriptionValidate;
        private HelpLabel helpLabel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private HelpLabel helpLabel4;
        private HelpLabel helpLabel3;
        private HelpLabel helpLabel2;
        private awb.AWBTextBox edtID;
        private awb.AWBTextBox edtSource;
        private awb.AWBTextBox edtType;
        private validators.RequiredFieldValidator edtIDValidate;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}
