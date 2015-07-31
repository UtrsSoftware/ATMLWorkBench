/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
*
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/
namespace ATMLCommonLibrary.forms
{
    partial class NameValueForm
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
            this.namedValueControl = new ATMLCommonLibrary.controls.common.NamedValueControl();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.namedValueControl);
            this.panel1.Size = new System.Drawing.Size(641, 565);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(579, 583);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(498, 583);
            // 
            // lblDenoteRequiredField
            // 
            this.lblDenoteRequiredField.Location = new System.Drawing.Point(1, 594);
            // 
            // namedValueControl
            // 
            this.namedValueControl.BackColor = System.Drawing.Color.AliceBlue;
            this.namedValueControl.DefaultComparitor = -1;
            this.namedValueControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.namedValueControl.Location = new System.Drawing.Point(0, 0);
            this.namedValueControl.MinimumSize = new System.Drawing.Size(558, 464);
            this.namedValueControl.Name = "namedValueControl";
            this.namedValueControl.Size = new System.Drawing.Size(641, 565);
            this.namedValueControl.TabIndex = 0;
            // 
            // NameValueForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(666, 610);
            this.MinimumSize = new System.Drawing.Size(600, 542);
            this.Name = "NameValueForm";
            this.Text = "Named Value ";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private controls.common.NamedValueControl namedValueControl;
    }
}
