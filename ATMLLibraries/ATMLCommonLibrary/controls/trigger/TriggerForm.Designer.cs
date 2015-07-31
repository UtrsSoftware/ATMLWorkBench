/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
* 
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

namespace ATMLCommonLibrary.controls.trigger
{
    partial class TriggerForm
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
            this.triggerControl = new ATMLCommonLibrary.controls.TriggerControl();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.triggerControl);
            // 
            // triggerControl1
            // 
            this.triggerControl.BackColor = System.Drawing.Color.Transparent;
            this.triggerControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.triggerControl.Location = new System.Drawing.Point(0, 0);
            this.triggerControl.Name = "triggerControl1";
            this.triggerControl.Size = new System.Drawing.Size(433, 270);
            this.triggerControl.TabIndex = 0;
            this.triggerControl.Load += new System.EventHandler(this.triggerControl1_Load);
            // 
            // TriggerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(458, 315);
            this.Name = "TriggerForm";
            this.Text = "Trigger";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private controls.TriggerControl triggerControl;
    }
}
