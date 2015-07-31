/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
*
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/
namespace ATMLCommonLibrary.controls.network
{
    partial class NetworkNodeForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NetworkNodeForm));
            this.networkNodeControl = new ATMLCommonLibrary.controls.network.NetworkNodeControl();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.networkNodeControl);
            this.panel1.Size = new System.Drawing.Size(705, 192);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(643, 210);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(562, 210);
            // 
            // lblDenoteRequiredField
            // 
            this.lblDenoteRequiredField.Location = new System.Drawing.Point(1, 221);
            // 
            // networkNodeControl
            // 
            this.networkNodeControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.networkNodeControl.Location = new System.Drawing.Point(0, 0);
            this.networkNodeControl.Name = "networkNodeControl";
            this.networkNodeControl.SchemaTypeName = null;
            this.networkNodeControl.Size = new System.Drawing.Size(705, 192);
            this.networkNodeControl.TabIndex = 0;
            this.networkNodeControl.TargetNamespace = null;
            // 
            // NetworkNodeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(730, 237);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "NetworkNodeForm";
            this.Text = "Network Node";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private NetworkNodeControl networkNodeControl;
    }
}