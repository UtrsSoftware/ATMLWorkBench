/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
*
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/
namespace ATMLCommonLibrary.controls.switching
{
    partial class SwitchPortForm
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
            this.swtchPortControl = new ATMLCommonLibrary.controls.switching.SwitchPortControl();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.swtchPortControl);
            this.panel1.Size = new System.Drawing.Size(504, 366);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(442, 384);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(361, 384);
            // 
            // lblDenoteRequiredField
            // 
            this.lblDenoteRequiredField.Location = new System.Drawing.Point(1, 395);
            // 
            // swtchPortControl
            // 
            this.swtchPortControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.swtchPortControl.Location = new System.Drawing.Point(0, 0);
            this.swtchPortControl.MinimumSize = new System.Drawing.Size(477, 158);
            this.swtchPortControl.Name = "swtchPortControl";
            this.swtchPortControl.Size = new System.Drawing.Size(504, 366);
            this.swtchPortControl.TabIndex = 0;
            // 
            // SwitchPortForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(529, 411);
            this.MinimumSize = new System.Drawing.Size(545, 449);
            this.Name = "SwitchPortForm";
            this.Text = "Switch Port";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private SwitchPortControl swtchPortControl;
    }
}