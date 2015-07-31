/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
*
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

namespace ATMLCommonLibrary.controls.network
{
    partial class NetworkForm
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
            this.networkControl = new ATMLCommonLibrary.controls.network.NetworkControl();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.networkControl);
            this.panel1.Location = new System.Drawing.Point(7, 9);
            this.panel1.Size = new System.Drawing.Size(615, 368);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(549, 383);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(468, 383);
            // 
            // lblDenoteRequiredField
            // 
            this.lblDenoteRequiredField.Location = new System.Drawing.Point(-2, 394);
            // 
            // networkControl
            // 
            this.networkControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.networkControl.Location = new System.Drawing.Point(0, 0);
            this.networkControl.MinimumSize = new System.Drawing.Size(599, 370);
            this.networkControl.Name = "networkControl";
            this.networkControl.SchemaTypeName = null;
            this.networkControl.Size = new System.Drawing.Size(615, 370);
            this.networkControl.TabIndex = 0;
            this.networkControl.TargetNamespace = null;
            // 
            // NetworkForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(629, 410);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MinimumSize = new System.Drawing.Size(645, 448);
            this.Name = "NetworkForm";
            this.Text = "Network";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private NetworkControl networkControl;
    }
}