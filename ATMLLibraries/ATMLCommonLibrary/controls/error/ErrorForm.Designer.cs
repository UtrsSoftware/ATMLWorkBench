/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
*
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/
namespace ATMLCommonLibrary.controls.error
{
    partial class ErrorForm
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
            this._errorControl = new ATMLCommonLibrary.controls.error.ErrorControl();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this._errorControl);
            this.panel1.Size = new System.Drawing.Size(355, 146);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(293, 164);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(212, 164);
            // 
            // lblDenoteRequiredField
            // 
            this.lblDenoteRequiredField.Location = new System.Drawing.Point(1, 175);
            // 
            // ErrorControl
            // 
            this._errorControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this._errorControl.Location = new System.Drawing.Point(0, 0);
            this._errorControl.Name = "_errorControl";
            this._errorControl.SchemaTypeName = null;
            this._errorControl.Size = new System.Drawing.Size(355, 146);
            this._errorControl.TabIndex = 0;
            this._errorControl.TargetNamespace = null;
            // 
            // ErrorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(380, 191);
            this.Name = "ErrorForm";
            this.Text = "Error";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ErrorControl _errorControl;
    }
}