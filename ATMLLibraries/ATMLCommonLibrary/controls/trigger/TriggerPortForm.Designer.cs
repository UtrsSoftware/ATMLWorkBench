/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
* 
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

namespace ATMLCommonLibrary.controls.trigger
{
    partial class TriggerPortForm
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
            this.triggerPortControl = new TriggerPortControl();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.triggerPortControl);
            this.panel1.Size = new System.Drawing.Size(433, 203);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(371, 221);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(290, 221);
            // 
            // lblDenoteRequiredField
            // 
            this.lblDenoteRequiredField.Location = new System.Drawing.Point(1, 232);
            // 
            // triggerPortControl1
            // 
            this.triggerPortControl.BackColor = System.Drawing.Color.AliceBlue;
            this.triggerPortControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.triggerPortControl.Location = new System.Drawing.Point(0, 0);
            this.triggerPortControl.Name = "triggerPortControl1";
            this.triggerPortControl.Size = new System.Drawing.Size(433, 203);
            this.triggerPortControl.TabIndex = 0;
            // 
            // TriggerPortForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(458, 248);
            this.Name = "TriggerPortForm";
            this.Text = "Trigger Port";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TriggerPortControl triggerPortControl;
    }
}