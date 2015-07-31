/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
*
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/
namespace ATMLCommonLibrary.controls.common
{
    partial class NamedValueControl
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
            this.lblName = new ATMLCommonLibrary.controls.HelpLabel(this.components);
            this.edtName = new ATMLCommonLibrary.controls.awb.AWBTextBox(this.components);
            this.requiredFieldValidator = new ATMLCommonLibrary.controls.validators.RequiredFieldValidator();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // helpLabel1
            // 
            this.helpLabel1.Location = new System.Drawing.Point(338, 7);
            // 
            // cmbValueType
            // 
            this.cmbValueType.Location = new System.Drawing.Point(405, 5);
            // 
            // collectionControl
            // 
            this.collectionControl.Size = new System.Drawing.Size(596, 550);
            this.collectionControl.Load += new System.EventHandler(this.collectionControl_Load);
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(13, 32);
            this.panel1.Size = new System.Drawing.Size(600, 554);
            // 
            // datumTypeControl
            // 
            this.datumTypeControl.Size = new System.Drawing.Size(596, 550);
            // 
            // indexArrayControl
            // 
            this.indexArrayControl.Size = new System.Drawing.Size(596, 550);
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.HelpMessageKey = "NamedValue.Name";
            this.lblName.Location = new System.Drawing.Point(10, 7);
            this.lblName.Name = "lblName";
            this.lblName.RequiredField = false;
            this.lblName.RequiredFieldMarkerFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.Size = new System.Drawing.Size(35, 13);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "Name";
            // 
            // edtName
            // 
            this.edtName.AttributeName = null;
            this.edtName.DataLookupKey = null;
            this.edtName.Location = new System.Drawing.Point(50, 5);
            this.edtName.Name = "edtName";
            this.edtName.Size = new System.Drawing.Size(260, 20);
            this.edtName.TabIndex = 1;
            this.edtName.Value = null;
            this.edtName.ValueType = ATMLCommonLibrary.controls.awb.AWBTextBox.eValueType.xsString;
            // 
            // requiredFieldValidator
            // 
            this.requiredFieldValidator.ControlToValidate = this.edtName;
            this.requiredFieldValidator.ErrorMessage = "The Name is required.";
            this.requiredFieldValidator.ErrorProvider = this.errorProvider;
            this.requiredFieldValidator.Icon = null;
            this.requiredFieldValidator.InitialValue = null;
            this.requiredFieldValidator.IsEnabled = true;
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // NamedValueControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.edtName);
            this.Controls.Add(this.lblName);
            this.Name = "NamedValueControl";
            this.Size = new System.Drawing.Size(625, 600);
            this.Controls.SetChildIndex(this.lblName, 0);
            this.Controls.SetChildIndex(this.edtName, 0);
            this.Controls.SetChildIndex(this.helpLabel1, 0);
            this.Controls.SetChildIndex(this.cmbValueType, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private HelpLabel lblName;
        private ATMLCommonLibrary.controls.awb.AWBTextBox edtName;
        private validators.RequiredFieldValidator requiredFieldValidator;
        private System.Windows.Forms.ErrorProvider errorProvider;
    }
}
