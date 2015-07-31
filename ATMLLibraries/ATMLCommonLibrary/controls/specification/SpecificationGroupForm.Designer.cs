/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
*
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/
namespace ATMLCommonLibrary.forms
{
    partial class SpecificationGroupForm
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
            this.specificationGroupControl = new ATMLCommonLibrary.controls.SpecificationGroupControl();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.specificationGroupControl);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Size = new System.Drawing.Size(544, 361);
            this.panel1.TabIndex = 4;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(481, 380);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(400, 380);
            // 
            // lblDenoteRequiredField
            // 
            this.lblDenoteRequiredField.Location = new System.Drawing.Point(2, 390);
            // 
            // specificationGroupControl
            // 
            this.specificationGroupControl.BackColor = System.Drawing.Color.Transparent;
            this.specificationGroupControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.specificationGroupControl.Location = new System.Drawing.Point(0, 0);
            this.specificationGroupControl.Name = "specificationGroupControl";
            this.specificationGroupControl.Size = new System.Drawing.Size(544, 361);
            this.specificationGroupControl.TabIndex = 0;
            // 
            // SpecificationGroupForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(568, 410);
            this.Name = "SpecificationGroupForm";
            this.Text = "Specification Group";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private controls.SpecificationGroupControl specificationGroupControl;

    }
}