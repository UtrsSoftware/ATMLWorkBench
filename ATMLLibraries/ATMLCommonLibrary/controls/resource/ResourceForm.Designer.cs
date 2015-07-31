/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
*
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/
namespace ATMLCommonLibrary.forms
{
    partial class ResourceForm
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
            this.resourceControl = new ATMLCommonLibrary.controls.ResourceControl();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.resourceControl);
            this.panel1.Size = new System.Drawing.Size(665, 408);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(603, 427);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(522, 427);
            // 
            // lblDenoteRequiredField
            // 
            this.lblDenoteRequiredField.Location = new System.Drawing.Point(1, 437);
            // 
            // resourceControl
            // 
            this.resourceControl.BackColor = System.Drawing.Color.AliceBlue;
            this.resourceControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.resourceControl.HasErrors = false;
            this.resourceControl.HelpKeyWord = null;
            this.resourceControl.LastError = null;
            this.resourceControl.Location = new System.Drawing.Point(0, 0);
            this.resourceControl.MinimumSize = new System.Drawing.Size(603, 413);
            this.resourceControl.Name = "resourceControl";
            this.resourceControl.SchemaTypeName = null;
            this.resourceControl.Size = new System.Drawing.Size(665, 413);
            this.resourceControl.TabIndex = 0;
            this.resourceControl.TargetNamespace = null;
            // 
            // ResourceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(690, 454);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "ResourceForm";
            this.Text = "Resource";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private controls.ResourceControl resourceControl;
    }
}