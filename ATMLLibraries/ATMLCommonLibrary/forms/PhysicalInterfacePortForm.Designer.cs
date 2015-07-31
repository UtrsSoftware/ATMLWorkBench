/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
*
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/
namespace ATMLCommonLibrary.forms
{
    partial class PhysicalInterfacePortForm
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
            this.physicalInterfacePortControl = new ATMLCommonLibrary.controls.common.PhysicalInterfacePortControl();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.physicalInterfacePortControl);
            this.panel1.Location = new System.Drawing.Point(13, 14);
            this.panel1.Size = new System.Drawing.Size(405, 291);
            // 
            // btnCancel
            // 
            this.btnCancel.CausesValidation = false;
            this.btnCancel.Location = new System.Drawing.Point(343, 311);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(262, 311);
            // 
            // lblDenoteRequiredField
            // 
            this.lblDenoteRequiredField.Location = new System.Drawing.Point(2, 327);
            // 
            // physicalInterfacePortControl
            // 
            this.physicalInterfacePortControl.BackColor = System.Drawing.Color.AliceBlue;
            this.physicalInterfacePortControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.physicalInterfacePortControl.Location = new System.Drawing.Point(0, 0);
            this.physicalInterfacePortControl.Name = "physicalInterfacePortControl";
            this.physicalInterfacePortControl.Size = new System.Drawing.Size(405, 291);
            this.physicalInterfacePortControl.TabIndex = 1;
            this.physicalInterfacePortControl.Load += new System.EventHandler(this.physicalInterfacePortControl_Load);
            // 
            // PhysicalInterfacePortForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(430, 342);
            this.Name = "PhysicalInterfacePortForm";
            this.Text = "Physical Interface Port";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private controls.common.PhysicalInterfacePortControl physicalInterfacePortControl;

    }
}