/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
* 
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

namespace ATMLCommonLibrary.controls.equipment
{
    partial class TestStationForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TestStationForm));
            this.testStationControl2 = new ATMLCommonLibrary.controls.equipment.TestStationControl();
            this.btnValidate = new System.Windows.Forms.Button();
            this.btnViewATML = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.testStationControl2);
            this.panel1.Size = new System.Drawing.Size(842, 554);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(780, 572);
            this.btnCancel.Text = "Close";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click_1);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(699, 572);
            this.btnOk.Text = "Save";
            // 
            // lblDenoteRequiredField
            // 
            this.lblDenoteRequiredField.Location = new System.Drawing.Point(1, 583);
            // 
            // testStationControl2
            // 
            this.testStationControl2.BackColor = System.Drawing.Color.AliceBlue;
            this.testStationControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.testStationControl2.HasErrors = false;
            this.testStationControl2.HelpKeyWord = null;
            this.testStationControl2.LastError = null;
            this.testStationControl2.Location = new System.Drawing.Point(0, 0);
            this.testStationControl2.Name = "testStationControl2";
            this.testStationControl2.SchemaTypeName = null;
            this.testStationControl2.Size = new System.Drawing.Size(842, 554);
            this.testStationControl2.TabIndex = 0;
            this.testStationControl2.TargetNamespace = null;
            // 
            // btnValidate
            // 
            this.btnValidate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnValidate.Location = new System.Drawing.Point(618, 572);
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
            this.btnViewATML.Location = new System.Drawing.Point(536, 572);
            this.btnViewATML.Name = "btnViewATML";
            this.btnViewATML.Size = new System.Drawing.Size(75, 23);
            this.btnViewATML.TabIndex = 8;
            this.btnViewATML.Text = "View ATML";
            this.btnViewATML.UseVisualStyleBackColor = true;
            this.btnViewATML.Click += new System.EventHandler(this.btnViewATML_Click);
            // 
            // TestStationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(867, 599);
            this.Controls.Add(this.btnViewATML);
            this.Controls.Add(this.btnValidate);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TestStationForm";
            this.Text = "Test Station";
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

        private TestStationControl testStationControl2;
        private System.Windows.Forms.Button btnValidate;
        private System.Windows.Forms.Button btnViewATML;
    }
}