/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
* 
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

namespace ATMLCommonLibrary.controls.hardware
{
    partial class VersionIdentifierForm
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
            this.versionIdentifierControl = new ATMLCommonLibrary.controls.hardware.VersionIdentifierControl();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.versionIdentifierControl);
            this.panel1.Size = new System.Drawing.Size(433, 76);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(371, 94);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(290, 94);
            // 
            // lblDenoteRequiredField
            // 
            this.lblDenoteRequiredField.Location = new System.Drawing.Point(1, 105);
            // 
            // versionIdentifierControl
            // 
            this.versionIdentifierControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.versionIdentifierControl.Location = new System.Drawing.Point(0, 0);
            this.versionIdentifierControl.Name = "versionIdentifierControl";
            this.versionIdentifierControl.SchemaTypeName = null;
            this.versionIdentifierControl.Size = new System.Drawing.Size(433, 76);
            this.versionIdentifierControl.TabIndex = 0;
            this.versionIdentifierControl.TargetNamespace = null;
            // 
            // VersionIdentifierForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(458, 121);
            this.MinimumSize = new System.Drawing.Size(474, 159);
            this.Name = "VersionIdentifierForm";
            this.Text = "Verion Identifier";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private VersionIdentifierControl versionIdentifierControl;
    }
}
