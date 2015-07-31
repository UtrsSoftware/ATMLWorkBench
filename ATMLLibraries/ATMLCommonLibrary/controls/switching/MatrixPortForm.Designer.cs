/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
*
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/
namespace ATMLCommonLibrary.controls.switching
{
    partial class MatrixPortForm
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
            this.matrixPortControl = new ATMLCommonLibrary.controls.switching.MatrixPortControl();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.matrixPortControl);
            this.panel1.Size = new System.Drawing.Size(510, 177);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(448, 195);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(367, 195);
            // 
            // lblDenoteRequiredField
            // 
            this.lblDenoteRequiredField.Location = new System.Drawing.Point(1, 206);
            // 
            // matrixPortControl
            // 
            this.matrixPortControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.matrixPortControl.Location = new System.Drawing.Point(0, 0);
            this.matrixPortControl.MinimumSize = new System.Drawing.Size(507, 167);
            this.matrixPortControl.Name = "matrixPortControl";
            this.matrixPortControl.Size = new System.Drawing.Size(510, 177);
            this.matrixPortControl.TabIndex = 0;
            // 
            // MatrixPortForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(535, 222);
            this.MinimumSize = new System.Drawing.Size(551, 260);
            this.Name = "MatrixPortForm";
            this.Text = "Matrix Port";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MatrixPortControl matrixPortControl;
    }
}
