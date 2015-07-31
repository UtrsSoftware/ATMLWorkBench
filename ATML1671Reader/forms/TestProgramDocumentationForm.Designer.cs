/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
* 
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

namespace ATML1671Reader.forms
{
    partial class TestProgramDocumentationForm
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
            this.testProgramDocumentationControl = new ATML1671Reader.controls.TestProgramDocumentationControl();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.testProgramDocumentationControl);
            this.panel1.Size = new System.Drawing.Size(433, 376);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(371, 394);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(290, 394);
            // 
            // lblDenoteRequiredField
            // 
            this.lblDenoteRequiredField.Location = new System.Drawing.Point(1, 405);
            // 
            // testProgramDocumentationControl
            // 
            this.testProgramDocumentationControl.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.testProgramDocumentationControl.BackColor = System.Drawing.Color.Transparent;
            this.testProgramDocumentationControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.testProgramDocumentationControl.Location = new System.Drawing.Point(0, 0);
            this.testProgramDocumentationControl.Name = "testProgramDocumentationControl";
            this.testProgramDocumentationControl.Size = new System.Drawing.Size(433, 376);
            this.testProgramDocumentationControl.TabIndex = 0;
            this.testProgramDocumentationControl.ValidationEnabled = true;
            // 
            // TestProgramDocumentationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(458, 421);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "TestProgramDocumentationForm";
            this.Text = "Test Program Documentation";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private controls.TestProgramDocumentationControl testProgramDocumentationControl;

    }
}