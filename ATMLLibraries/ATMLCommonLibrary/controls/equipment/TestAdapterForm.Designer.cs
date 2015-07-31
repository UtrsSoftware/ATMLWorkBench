/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
* 
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

namespace ATMLCommonLibrary.controls.equipment
{
    partial class TestAdapterForm
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
            this.testAdapterControl1 = new ATMLCommonLibrary.controls.equipment.TestAdapterControl();
            this.btnValidate = new System.Windows.Forms.Button();
            this.btnViewATML = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.testAdapterControl1);
            this.panel1.Size = new System.Drawing.Size(819, 602);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(757, 620);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Close";
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(676, 620);
            this.btnOk.TabIndex = 2;
            this.btnOk.Text = "Save";
            // 
            // lblDenoteRequiredField
            // 
            this.lblDenoteRequiredField.Location = new System.Drawing.Point(1, 631);
            this.lblDenoteRequiredField.TabIndex = 0;
            // 
            // testAdapterControl1
            // 
            this.testAdapterControl1.BackColor = System.Drawing.Color.AliceBlue;
            this.testAdapterControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.testAdapterControl1.HasErrors = false;
            this.testAdapterControl1.HelpKeyWord = null;
            this.testAdapterControl1.LastError = null;
            this.testAdapterControl1.Location = new System.Drawing.Point(0, 0);
            this.testAdapterControl1.Name = "testAdapterControl1";
            this.testAdapterControl1.SchemaTypeName = null;
            this.testAdapterControl1.Size = new System.Drawing.Size(819, 602);
            this.testAdapterControl1.TabIndex = 0;
            this.testAdapterControl1.TargetNamespace = null;
            // 
            // btnValidate
            // 
            this.btnValidate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnValidate.Location = new System.Drawing.Point(595, 620);
            this.btnValidate.Name = "btnValidate";
            this.btnValidate.Size = new System.Drawing.Size(75, 23);
            this.btnValidate.TabIndex = 1;
            this.btnValidate.Text = "Validate";
            this.btnValidate.UseVisualStyleBackColor = true;
            this.btnValidate.Click += new System.EventHandler(this.btnValidate_Click);
            // 
            // btnViewATML
            // 
            this.btnViewATML.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnViewATML.Location = new System.Drawing.Point(513, 620);
            this.btnViewATML.Name = "btnViewATML";
            this.btnViewATML.Size = new System.Drawing.Size(75, 23);
            this.btnViewATML.TabIndex = 5;
            this.btnViewATML.Text = "View ATML";
            this.btnViewATML.UseVisualStyleBackColor = true;
            this.btnViewATML.Click += new System.EventHandler(this.btnViewATML_Click);
            // 
            // TestAdapterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(844, 647);
            this.Controls.Add(this.btnViewATML);
            this.Controls.Add(this.btnValidate);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "TestAdapterForm";
            this.Text = "Test Adapter";
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

        private TestAdapterControl testAdapterControl1;
        private System.Windows.Forms.Button btnValidate;
        private System.Windows.Forms.Button btnViewATML;

    }
}
