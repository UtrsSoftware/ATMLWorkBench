/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
* 
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

namespace ATMLCommonLibrary.controls.control.driver
{
    partial class ControlDriverForm
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
            this.controlDriverControl1 = new ATMLCommonLibrary.controls.control.driver.ControlDriverControl();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.controlDriverControl1);
            this.panel1.Size = new System.Drawing.Size(519, 573);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(457, 591);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(376, 591);
            // 
            // lblDenoteRequiredField
            // 
            this.lblDenoteRequiredField.Location = new System.Drawing.Point(1, 602);
            // 
            // controlDriverControl1
            // 
            this.controlDriverControl1.BackColor = System.Drawing.Color.AliceBlue;
            this.controlDriverControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.controlDriverControl1.HasErrors = false;
            this.controlDriverControl1.HelpKeyWord = null;
            this.controlDriverControl1.LastError = null;
            this.controlDriverControl1.Location = new System.Drawing.Point(0, 0);
            this.controlDriverControl1.Name = "controlDriverControl1";
            this.controlDriverControl1.SchemaTypeName = null;
            this.controlDriverControl1.Size = new System.Drawing.Size(519, 573);
            this.controlDriverControl1.TabIndex = 0;
            this.controlDriverControl1.TargetNamespace = null;
            // 
            // ControlDriverForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(544, 618);
            this.Name = "ControlDriverForm";
            this.Text = "Control Driver";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ControlDriverControl controlDriverControl1;
    }
}