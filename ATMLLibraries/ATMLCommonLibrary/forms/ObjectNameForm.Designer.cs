/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
* 
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

namespace ATMLCommonLibrary.forms
{
    sealed partial class ObjectNameForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ObjectNameForm));
            this.label1 = new System.Windows.Forms.Label();
            this.edtName = new System.Windows.Forms.TextBox();
            this.regularExpressionValidator = new ATMLCommonLibrary.controls.validators.RegularExpressionValidator();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.edtName);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Size = new System.Drawing.Size(433, 62);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(371, 80);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(290, 80);
            // 
            // lblDenoteRequiredField
            // 
            this.lblDenoteRequiredField.Location = new System.Drawing.Point(1, 91);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // edtName
            // 
            this.edtName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtName.Location = new System.Drawing.Point(58, 21);
            this.edtName.Name = "edtName";
            this.edtName.Size = new System.Drawing.Size(347, 20);
            this.edtName.TabIndex = 1;
            // 
            // regularExpressionValidator
            // 
            this.regularExpressionValidator.ControlToValidate = this.edtName;
            this.regularExpressionValidator.ErrorMessage = "Invalid Name Format";
            this.regularExpressionValidator.ErrorProvider = this.errorProvider;
            this.regularExpressionValidator.Icon = null;
            this.regularExpressionValidator.InitialValue = null;
            this.regularExpressionValidator.IsEnabled = true;
            this.regularExpressionValidator.RegularExpression = null;
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // ObjectNameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(458, 107);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ObjectNameForm";
            this.Text = "Change Name";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox edtName;
        private controls.validators.RegularExpressionValidator regularExpressionValidator;
        private System.Windows.Forms.ErrorProvider errorProvider;
    }
}
