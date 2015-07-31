/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
*
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/
namespace ATMLCommonLibrary.controls.path
{
    partial class PathForm
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
            this.pathControl = new ATMLCommonLibrary.controls.path.PathControl();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.pathControl);
            this.panel1.Size = new System.Drawing.Size(518, 417);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(456, 435);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(375, 435);
            // 
            // lblDenoteRequiredField
            // 
            this.lblDenoteRequiredField.Location = new System.Drawing.Point(1, 446);
            // 
            // pathControl
            // 
            this.pathControl.BackColor = System.Drawing.Color.AliceBlue;
            this.pathControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pathControl.HardwareItemDescription = null;
            this.pathControl.HelpKeyWord = null;
            this.pathControl.Location = new System.Drawing.Point(0, 0);
            this.pathControl.Name = "pathControl";
            this.pathControl.SchemaTypeName = null;
            this.pathControl.Size = new System.Drawing.Size(518, 417);
            this.pathControl.TabIndex = 0;
            this.pathControl.TargetNamespace = null;
            // 
            // PathForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(543, 462);
            this.Name = "PathForm";
            this.Text = "Path";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PathForm_FormClosing);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private PathControl pathControl;
    }
}
