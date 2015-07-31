/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
*
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/
namespace ATMLCommonLibrary.forms
{
    partial class ValueForm
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
            this.valueControl = new ATMLCommonLibrary.controls.common.ValueControl();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.valueControl);
            this.panel1.Size = new System.Drawing.Size(594, 546);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(532, 564);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(451, 564);
            // 
            // lblDenoteRequiredField
            // 
            this.lblDenoteRequiredField.Location = new System.Drawing.Point(1, 575);
            // 
            // valueControl
            // 
            this.valueControl.BackColor = System.Drawing.Color.AliceBlue;
            this.valueControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.valueControl.Location = new System.Drawing.Point(0, 0);
            this.valueControl.LockTypes = false;
            this.valueControl.MinimumSize = new System.Drawing.Size(595, 550);
            this.valueControl.Name = "valueControl";
            this.valueControl.Size = new System.Drawing.Size(595, 550);
            this.valueControl.TabIndex = 0;
            // 
            // ValueForm
            // 
            this.ClientSize = new System.Drawing.Size(619, 591);
            this.Location = new System.Drawing.Point(0, 0);
            this.MinimumSize = new System.Drawing.Size(562, 629);
            this.Name = "ValueForm";
            this.Text = "Value";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private controls.common.ValueControl valueControl;
    }
}
