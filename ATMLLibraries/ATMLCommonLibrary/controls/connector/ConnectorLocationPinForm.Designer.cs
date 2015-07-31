/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
*
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/
namespace ATMLCommonLibrary.forms
{
    partial class ConnectorLocationPinForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConnectorLocationPinForm));
            this.connectorLocationPinControl = new ATMLCommonLibrary.controls.ConnectorLocationPinControl();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.connectorLocationPinControl);
            this.panel1.Location = new System.Drawing.Point(9, 9);
            this.panel1.Size = new System.Drawing.Size(242, 76);
            this.panel1.TabIndex = 1;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(177, 89);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(96, 89);
            // 
            // lblDenoteRequiredField
            // 
            this.lblDenoteRequiredField.Location = new System.Drawing.Point(1, 287);
            // 
            // connectorLocationPinControl
            // 
            this.connectorLocationPinControl.Connectors = null;
            this.connectorLocationPinControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.connectorLocationPinControl.Location = new System.Drawing.Point(0, 0);
            this.connectorLocationPinControl.Name = "connectorLocationPinControl";
            this.connectorLocationPinControl.Size = new System.Drawing.Size(242, 76);
            this.connectorLocationPinControl.TabIndex = 0;
            this.connectorLocationPinControl.Load += new System.EventHandler(this.connectorLocationPinControl_Load);
            // 
            // ConnectorLocationPinForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(260, 117);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ConnectorLocationPinForm";
            this.Text = "Connector Location Pin";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ConnectorLocationPinForm_FormClosing);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private controls.ConnectorLocationPinControl connectorLocationPinControl;
 
    }
}