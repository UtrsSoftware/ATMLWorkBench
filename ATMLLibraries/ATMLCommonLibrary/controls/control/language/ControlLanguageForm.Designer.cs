/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
*
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

namespace ATMLCommonLibrary.controls.control.language
{
    partial class ControlLanguageForm
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
            this.controlLanguageControl1 = new ControlLanguageControl();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.controlLanguageControl1);
            this.panel1.Size = new System.Drawing.Size(391, 284);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(329, 302);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(248, 302);
            // 
            // lblDenoteRequiredField
            // 
            this.lblDenoteRequiredField.Location = new System.Drawing.Point(1, 313);
            // 
            // controlLanguageControl1
            // 
            this.controlLanguageControl1.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.controlLanguageControl1.BackColor = System.Drawing.Color.Transparent;
            this.controlLanguageControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.controlLanguageControl1.HelpKeyWord = null;
            this.controlLanguageControl1.Location = new System.Drawing.Point(0, 0);
            this.controlLanguageControl1.Name = "controlLanguageControl1";
            this.controlLanguageControl1.Padding = new System.Windows.Forms.Padding(0, 30, 0, 0);
            this.controlLanguageControl1.SchemaTypeName = null;
            this.controlLanguageControl1.Size = new System.Drawing.Size(391, 284);
            this.controlLanguageControl1.TabIndex = 0;
            this.controlLanguageControl1.TargetNamespace = null;
            this.controlLanguageControl1.ValidationEnabled = true;
            // 
            // ControlLanguageForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(416, 329);
            this.Name = "ControlLanguageForm";
            this.Text = "Control Language";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ControlLanguageControl controlLanguageControl1;
    }
}
