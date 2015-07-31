/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
*
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

using System.Windows.Forms;

namespace ATMLCommonLibrary.controls.common
{
    partial class ItemControl
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
            this.edtDescription = new ATMLCommonLibrary.controls.awb.AWBTextBox(this.components);
            this.edtName = new ATMLCommonLibrary.controls.awb.AWBTextBox(this.components);
            this.lblName = new ATMLCommonLibrary.controls.HelpLabel(this.components);
            this.lblDescription = new ATMLCommonLibrary.controls.HelpLabel(this.components);
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.requiredNameFieldValidator = new ATMLCommonLibrary.controls.validators.RequiredFieldValidator();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // edtDescription
            // 
            this.edtDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtDescription.Location = new System.Drawing.Point(71, 29);
            this.edtDescription.Multiline = true;
            this.edtDescription.Name = "edtDescription";
            this.edtDescription.Size = new System.Drawing.Size(404, 92);
            this.edtDescription.TabIndex = 3;
            this.edtDescription.Tag = "";
            this.edtDescription.Value = null;
            this.edtDescription.ValueType = ATMLCommonLibrary.controls.awb.AWBTextBox.eValueType.xsString;
            // 
            // edtName
            // 
            this.edtName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtName.Location = new System.Drawing.Point(71, 3);
            this.edtName.Name = "edtName";
            this.edtName.Size = new System.Drawing.Size(404, 20);
            this.edtName.TabIndex = 1;
            this.edtName.Tag = "";
            this.edtName.Value = null;
            this.edtName.ValueType = ATMLCommonLibrary.controls.awb.AWBTextBox.eValueType.xsString;
            // 
            // lblName
            // 
            this.lblName.HelpMessageKey = "Item.name";
            this.lblName.Location = new System.Drawing.Point(28, 6);
            this.lblName.Name = "lblName";
            this.lblName.RequiredField = true;
            this.lblName.RequiredFieldMarkerFont = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.Size = new System.Drawing.Size(39, 13);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "Name";
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.HelpMessageKey = "Item.description";
            this.lblDescription.Location = new System.Drawing.Point(3, 32);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.RequiredField = false;
            this.lblDescription.RequiredFieldMarkerFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescription.Size = new System.Drawing.Size(60, 13);
            this.lblDescription.TabIndex = 2;
            this.lblDescription.Text = "Description";
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // requiredNameFieldValidator
            // 
            this.requiredNameFieldValidator.ControlToValidate = this.edtName;
            this.requiredNameFieldValidator.ErrorMessage = "The name is required";
            this.requiredNameFieldValidator.ErrorProvider = this.errorProvider;
            this.requiredNameFieldValidator.Icon = null;
            this.requiredNameFieldValidator.InitialValue = null;
            this.requiredNameFieldValidator.IsEnabled = true;
            // 
            // ItemControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.edtDescription);
            this.Controls.Add(this.edtName);
            this.Name = "ItemControl";
            this.Size = new System.Drawing.Size(500, 126);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected awb.AWBTextBox edtDescription;
        protected awb.AWBTextBox edtName;
        protected HelpLabel lblName;
        protected HelpLabel lblDescription;
        private validators.RequiredFieldValidator requiredNameFieldValidator;
        protected ErrorProvider errorProvider;
    }
}
