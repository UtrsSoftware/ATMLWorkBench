/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
*
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/
namespace ATMLCommonLibrary.forms
{
    partial class ManufacturerForm
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
            this.manufacturerControl = new ATMLCommonLibrary.controls.manufacturer.ManufacturerControl();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.manufacturerControl);
            this.panel1.Location = new System.Drawing.Point(8, 10);
            this.panel1.Size = new System.Drawing.Size(337, 316);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(270, 331);
            this.btnCancel.TabIndex = 4;
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(187, 331);
            this.btnOk.TabIndex = 3;
            this.btnOk.Text = "Ok";
            // 
            // lblDenoteRequiredField
            // 
            this.lblDenoteRequiredField.Location = new System.Drawing.Point(3, 348);
            // 
            // manufacturerControl
            // 
            this.manufacturerControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.manufacturerControl.Location = new System.Drawing.Point(0, 0);
            this.manufacturerControl.Name = "manufacturerControl";
            this.manufacturerControl.SchemaTypeName = null;
            this.manufacturerControl.Size = new System.Drawing.Size(337, 316);
            this.manufacturerControl.TabIndex = 0;
            this.manufacturerControl.TargetNamespace = null;
            // 
            // ManufacturerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(353, 360);
            this.MinimumSize = new System.Drawing.Size(369, 398);
            this.Name = "ManufacturerForm";
            this.Text = "Manufacturer";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private controls.manufacturer.ManufacturerControl manufacturerControl;

    }
}