/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
*
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/
namespace ATMLCommonLibrary.forms
{
    partial class PortForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PortForm));
            this.portControl = new ATMLCommonLibrary.controls.common.PortControl();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.portControl);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Size = new System.Drawing.Size(239, 114);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(176, 132);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(95, 132);
            // 
            // portControl
            // 
            this.portControl.BackColor = System.Drawing.Color.AliceBlue;
            this.portControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.portControl.Location = new System.Drawing.Point(0, 0);
            this.portControl.Name = "portControl";
            this.portControl.SchemaTypeName = null;
            this.portControl.Size = new System.Drawing.Size(239, 114);
            this.portControl.TabIndex = 0;
            this.portControl.TargetNamespace = null;
            this.portControl.Load += new System.EventHandler(this.portControl_Load);
            // 
            // PortForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SteelBlue;
            this.ClientSize = new System.Drawing.Size(263, 161);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "PortForm";
            this.Text = "Port";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PortForm_FormClosing);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private controls.common.PortControl portControl;
    }
}