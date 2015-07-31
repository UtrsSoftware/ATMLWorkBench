/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
* 
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

namespace ATMLCommonLibrary.controls.physical
{
    partial class PhysicalTypeErrorLimitForm
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
            this.physicalTypeErrorLimitControl = new ATMLCommonLibrary.controls.physical.PhysicalTypeErrorLimitControl();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.physicalTypeErrorLimitControl);
            this.panel1.Size = new System.Drawing.Size(631, 294);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(569, 312);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(488, 312);
            // 
            // lblDenoteRequiredField
            // 
            this.lblDenoteRequiredField.Location = new System.Drawing.Point(1, 323);
            // 
            // physicalTypeErrorLimitControl
            // 
            this.physicalTypeErrorLimitControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.physicalTypeErrorLimitControl.ErrorLimit = null;
            this.physicalTypeErrorLimitControl.Location = new System.Drawing.Point(0, 0);
            this.physicalTypeErrorLimitControl.Name = "physicalTypeErrorLimitControl";
            this.physicalTypeErrorLimitControl.SchemaTypeName = null;
            this.physicalTypeErrorLimitControl.Size = new System.Drawing.Size(631, 294);
            this.physicalTypeErrorLimitControl.TabIndex = 0;
            this.physicalTypeErrorLimitControl.TargetNamespace = null;
            // 
            // PhysicalTypeErrorLimitForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(656, 339);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "PhysicalTypeErrorLimitForm";
            this.Text = "Physical Type Uncertainty Value";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private PhysicalTypeErrorLimitControl physicalTypeErrorLimitControl;
    }
}