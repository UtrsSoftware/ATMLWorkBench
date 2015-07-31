/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
*
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/
namespace ATMLCommonLibrary.forms
{
    partial class UUTDescriptionForm
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
            if( disposing && ( components != null ) )
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UUTDescriptionForm));
            this.uutDescriptionControl1 = new ATMLCommonLibrary.controls.UUTDescriptionControl();
            this.btnValidate = new System.Windows.Forms.Button();
            this.btnViewATML = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.uutDescriptionControl1);
            this.panel1.Size = new System.Drawing.Size(750, 492);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(693, 511);
            this.btnCancel.Text = "Close";
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(612, 511);
            this.btnOk.Text = "Save";
            // 
            // lblDenoteRequiredField
            // 
            this.lblDenoteRequiredField.Location = new System.Drawing.Point(1, 516);
            // 
            // uutDescriptionControl1
            // 
            this.uutDescriptionControl1.BackColor = System.Drawing.Color.AliceBlue;
            this.uutDescriptionControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uutDescriptionControl1.HasErrors = false;
            this.uutDescriptionControl1.HelpKeyWord = null;
            this.uutDescriptionControl1.LastError = null;
            this.uutDescriptionControl1.Location = new System.Drawing.Point(0, 0);
            this.uutDescriptionControl1.MinimumSize = new System.Drawing.Size(742, 428);
            this.uutDescriptionControl1.Name = "uutDescriptionControl1";
            this.uutDescriptionControl1.SchemaTypeName = null;
            this.uutDescriptionControl1.Size = new System.Drawing.Size(750, 492);
            this.uutDescriptionControl1.TabIndex = 5;
            this.uutDescriptionControl1.TargetNamespace = null;
            this.uutDescriptionControl1.Load += new System.EventHandler(this.uutDescriptionControl1_Load);
            // 
            // btnValidate
            // 
            this.btnValidate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnValidate.Location = new System.Drawing.Point(531, 511);
            this.btnValidate.Name = "btnValidate";
            this.btnValidate.Size = new System.Drawing.Size(75, 23);
            this.btnValidate.TabIndex = 7;
            this.btnValidate.Text = "Validate";
            this.btnValidate.UseVisualStyleBackColor = true;
            this.btnValidate.Click += new System.EventHandler(this.btnValidate_Click);
            // 
            // btnViewATML
            // 
            this.btnViewATML.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnViewATML.Location = new System.Drawing.Point(450, 511);
            this.btnViewATML.Name = "btnViewATML";
            this.btnViewATML.Size = new System.Drawing.Size(75, 23);
            this.btnViewATML.TabIndex = 8;
            this.btnViewATML.Text = "View ATML";
            this.btnViewATML.UseVisualStyleBackColor = true;
            this.btnViewATML.Click += new System.EventHandler(this.btnViewATML_Click);
            // 
            // UUTDescriptionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SteelBlue;
            this.ClientSize = new System.Drawing.Size(775, 540);
            this.Controls.Add(this.btnViewATML);
            this.Controls.Add(this.btnValidate);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(791, 532);
            this.Name = "UUTDescriptionForm";
            this.Text = "UUT Description";
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.btnOk, 0);
            this.Controls.SetChildIndex(this.btnCancel, 0);
            this.Controls.SetChildIndex(this.lblDenoteRequiredField, 0);
            this.Controls.SetChildIndex(this.btnValidate, 0);
            this.Controls.SetChildIndex(this.btnViewATML, 0);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ATMLCommonLibrary.controls.UUTDescriptionControl uutDescriptionControl1;
        private System.Windows.Forms.Button btnValidate;
        private System.Windows.Forms.Button btnViewATML;
    }
}