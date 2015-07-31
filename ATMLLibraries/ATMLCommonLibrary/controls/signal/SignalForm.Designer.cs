/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
*
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/
namespace ATMLCommonLibrary.forms
{
    partial class SignalForm
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
            this.signalControl = new ATMLCommonLibrary.controls.signal.SignalControl();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.signalControl);
            this.panel1.Size = new System.Drawing.Size(501, 485);
            this.panel1.TabIndex = 3;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(441, 505);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(360, 505);
            // 
            // lblDenoteRequiredField
            // 
            this.lblDenoteRequiredField.Location = new System.Drawing.Point(1, 516);
            // 
            // signalControl
            // 
            this.signalControl.AllowDrop = true;
            this.signalControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.signalControl.BackColor = System.Drawing.Color.AliceBlue;
            this.signalControl.HasErrors = false;
            this.signalControl.HelpKeyWord = null;
            this.signalControl.LastError = null;
            this.signalControl.Location = new System.Drawing.Point(3, 5);
            this.signalControl.Name = "signalControl";
            this.signalControl.SchemaTypeName = null;
            this.signalControl.Size = new System.Drawing.Size(495, 477);
            this.signalControl.TabIndex = 2;
            this.signalControl.TargetNamespace = null;
            this.signalControl.Load += new System.EventHandler(this.signalControl1_Load);
            // 
            // SignalForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SteelBlue;
            this.ClientSize = new System.Drawing.Size(529, 534);
            this.Name = "SignalForm";
            this.Text = "Signal";
            this.Load += new System.EventHandler(this.SignalForm_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private controls.signal.SignalControl signalControl;

    }
}