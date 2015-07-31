/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
* 
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

namespace ATMLCommonLibrary.controls.controller
{
    partial class ControllerDriveForm
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
            this.controllerDriveControl1 = new ControllerDriveControl();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.controllerDriveControl1);
            this.panel1.Size = new System.Drawing.Size(376, 127);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(314, 145);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(233, 145);
            // 
            // lblDenoteRequiredField
            // 
            this.lblDenoteRequiredField.Location = new System.Drawing.Point(1, 156);
            // 
            // controllerDriveControl1
            // 
            this.controllerDriveControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.controllerDriveControl1.Location = new System.Drawing.Point(0, 0);
            this.controllerDriveControl1.Name = "controllerDriveControl1";
            this.controllerDriveControl1.SchemaTypeName = null;
            this.controllerDriveControl1.Size = new System.Drawing.Size(376, 127);
            this.controllerDriveControl1.TabIndex = 0;
            this.controllerDriveControl1.TargetNamespace = null;
            // 
            // ControllerDriveForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(401, 172);
            this.Name = "ControllerDriveForm";
            this.Text = "ControllerDriveForm";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ControllerDriveControl controllerDriveControl1;
    }
}