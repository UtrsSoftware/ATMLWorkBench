/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
*
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

namespace ATMLCommonLibrary.controls.network
{
    partial class MappingForm
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
            this.mappingControl = new MappingControl();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.mappingControl);
            this.panel1.Location = new System.Drawing.Point(7, 8);
            this.panel1.Size = new System.Drawing.Size(634, 331);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(567, 343);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(486, 343);
            // 
            // lblDenoteRequiredField
            // 
            this.lblDenoteRequiredField.Location = new System.Drawing.Point(1, 353);
            // 
            // mappingControl
            // 
            this.mappingControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mappingControl.Location = new System.Drawing.Point(0, 0);
            this.mappingControl.MinimumSize = new System.Drawing.Size(587, 247);
            this.mappingControl.Name = "mappingControl";
            this.mappingControl.Size = new System.Drawing.Size(634, 331);
            this.mappingControl.TabIndex = 0;
            // 
            // MappingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(648, 370);
            this.Name = "MappingForm";
            this.Text = "Mapping";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MappingControl mappingControl;
    }
}