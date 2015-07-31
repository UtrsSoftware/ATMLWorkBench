/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
* 
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

namespace ATMLCommonLibrary.controls.physical
{
    partial class PhysicalTypeRangeForm
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
            this.physicalTypeRangeControl1 = new ATMLCommonLibrary.controls.physical.PhysicalTypeRangeControl();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.physicalTypeRangeControl1);
            this.panel1.Size = new System.Drawing.Size(435, 246);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(373, 264);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(292, 264);
            // 
            // lblDenoteRequiredField
            // 
            this.lblDenoteRequiredField.Location = new System.Drawing.Point(1, 275);
            // 
            // physicalTypeRangeControl1
            // 
            this.physicalTypeRangeControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.physicalTypeRangeControl1.Location = new System.Drawing.Point(0, 0);
            this.physicalTypeRangeControl1.Name = "physicalTypeRangeControl1";
            this.physicalTypeRangeControl1.RangingInformation = null;
            this.physicalTypeRangeControl1.Size = new System.Drawing.Size(435, 246);
            this.physicalTypeRangeControl1.TabIndex = 0;
            // 
            // PhysicalTypeRangeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(460, 291);
            this.Name = "PhysicalTypeRangeForm";
            this.Text = "Physical Type Range";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private PhysicalTypeRangeControl physicalTypeRangeControl1;
    }
}