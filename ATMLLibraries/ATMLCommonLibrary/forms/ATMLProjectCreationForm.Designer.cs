/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
* 
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

namespace ATMLCommonLibrary.forms
{
    partial class ATMLProjectCreationForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ATMLProjectCreationForm));
            this.label1 = new System.Windows.Forms.Label();
            this.edtProjectName = new ATMLCommonLibrary.controls.awb.AWBTextBox(this.components);
            this.edtUUT = new ATMLCommonLibrary.controls.awb.AWBTextBox(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.btnSelectUUT = new System.Windows.Forms.Button();
            this.requiredFieldValidatorProjectName = new ATMLCommonLibrary.controls.validators.RequiredFieldValidator();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.requiredFieldValidatorUUT = new ATMLCommonLibrary.controls.validators.RequiredFieldValidator();
            this.edtUUID = new ATMLCommonLibrary.controls.awb.AWBTextBox(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.btnCreateUUID = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnCreateUUID);
            this.panel1.Controls.Add(this.edtUUID);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.btnSelectUUT);
            this.panel1.Controls.Add(this.edtUUT);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.edtProjectName);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Size = new System.Drawing.Size(492, 117);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(430, 135);
            this.btnCancel.TabIndex = 2;
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(349, 135);
            this.btnOk.TabIndex = 1;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click_1);
            // 
            // lblDenoteRequiredField
            // 
            this.lblDenoteRequiredField.Location = new System.Drawing.Point(1, 146);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Project Name";
            // 
            // edtProjectName
            // 
            this.edtProjectName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtProjectName.AttributeName = null;
            this.edtProjectName.DataLookupKey = null;
            this.edtProjectName.Location = new System.Drawing.Point(98, 43);
            this.edtProjectName.Name = "edtProjectName";
            this.edtProjectName.Size = new System.Drawing.Size(345, 20);
            this.edtProjectName.TabIndex = 4;
            this.edtProjectName.Value = null;
            this.edtProjectName.ValueType = ATMLCommonLibrary.controls.awb.AWBTextBox.eValueType.xsString;
            // 
            // edtUUT
            // 
            this.edtUUT.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtUUT.AttributeName = null;
            this.edtUUT.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(255)))), ((int)(((byte)(220)))));
            this.edtUUT.DataLookupKey = null;
            this.edtUUT.Location = new System.Drawing.Point(98, 16);
            this.edtUUT.Name = "edtUUT";
            this.edtUUT.ReadOnly = true;
            this.edtUUT.Size = new System.Drawing.Size(345, 20);
            this.edtUUT.TabIndex = 1;
            this.edtUUT.Value = null;
            this.edtUUT.ValueType = ATMLCommonLibrary.controls.awb.AWBTextBox.eValueType.xsString;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(57, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "UUT";
            // 
            // btnSelectUUT
            // 
            this.btnSelectUUT.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSelectUUT.FlatAppearance.BorderSize = 0;
            this.btnSelectUUT.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSelectUUT.Image = ((System.Drawing.Image)(resources.GetObject("btnSelectUUT.Image")));
            this.btnSelectUUT.Location = new System.Drawing.Point(446, 15);
            this.btnSelectUUT.Name = "btnSelectUUT";
            this.btnSelectUUT.Size = new System.Drawing.Size(22, 23);
            this.btnSelectUUT.TabIndex = 2;
            this.btnSelectUUT.UseVisualStyleBackColor = true;
            this.btnSelectUUT.Click += new System.EventHandler(this.btnSelectUUT_Click);
            // 
            // requiredFieldValidatorProjectName
            // 
            this.requiredFieldValidatorProjectName.ControlToValidate = this.edtProjectName;
            this.requiredFieldValidatorProjectName.ErrorMessage = "A Project Name is Required";
            this.requiredFieldValidatorProjectName.ErrorProvider = this.errorProvider1;
            this.requiredFieldValidatorProjectName.Icon = null;
            this.requiredFieldValidatorProjectName.InitialValue = null;
            this.requiredFieldValidatorProjectName.IsEnabled = true;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            this.errorProvider1.RightToLeft = true;
            // 
            // requiredFieldValidatorUUT
            // 
            this.requiredFieldValidatorUUT.ControlToValidate = this.edtUUT;
            this.requiredFieldValidatorUUT.ErrorMessage = "You must select a UUT";
            this.requiredFieldValidatorUUT.ErrorProvider = this.errorProvider1;
            this.requiredFieldValidatorUUT.Icon = null;
            this.requiredFieldValidatorUUT.InitialValue = null;
            this.requiredFieldValidatorUUT.IsEnabled = true;
            // 
            // edtUUID
            // 
            this.edtUUID.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtUUID.AttributeName = null;
            this.edtUUID.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(255)))), ((int)(((byte)(220)))));
            this.edtUUID.DataLookupKey = null;
            this.edtUUID.Location = new System.Drawing.Point(98, 69);
            this.edtUUID.Name = "edtUUID";
            this.edtUUID.ReadOnly = true;
            this.edtUUID.Size = new System.Drawing.Size(345, 20);
            this.edtUUID.TabIndex = 6;
            this.edtUUID.Value = null;
            this.edtUUID.ValueType = ATMLCommonLibrary.controls.awb.AWBTextBox.eValueType.xsString;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(35, 71);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Project ID";
            // 
            // btnCreateUUID
            // 
            this.btnCreateUUID.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCreateUUID.FlatAppearance.BorderSize = 0;
            this.btnCreateUUID.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCreateUUID.Image = ((System.Drawing.Image)(resources.GetObject("btnCreateUUID.Image")));
            this.btnCreateUUID.Location = new System.Drawing.Point(445, 67);
            this.btnCreateUUID.Name = "btnCreateUUID";
            this.btnCreateUUID.Size = new System.Drawing.Size(22, 23);
            this.btnCreateUUID.TabIndex = 7;
            this.btnCreateUUID.UseVisualStyleBackColor = true;
            this.btnCreateUUID.Visible = false;
            this.btnCreateUUID.Click += new System.EventHandler(this.btnCreateUUID_Click);
            // 
            // ATMLProjectCreationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(517, 162);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "ATMLProjectCreationForm";
            this.Text = "New Project";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private controls.awb.AWBTextBox edtProjectName;
        private System.Windows.Forms.Button btnSelectUUT;
        private controls.awb.AWBTextBox edtUUT;
        private System.Windows.Forms.Label label2;
        private controls.validators.RequiredFieldValidator requiredFieldValidatorProjectName;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private controls.validators.RequiredFieldValidator requiredFieldValidatorUUT;
        private System.Windows.Forms.Button btnCreateUUID;
        private controls.awb.AWBTextBox edtUUID;
        private System.Windows.Forms.Label label3;
    }
}