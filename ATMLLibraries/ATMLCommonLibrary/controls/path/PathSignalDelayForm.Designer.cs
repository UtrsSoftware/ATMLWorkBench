/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
*
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/
namespace ATMLCommonLibrary.controls.path
{
    partial class PathSignalDelayForm
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
            this.pathSignalDelayControl = new ATMLCommonLibrary.controls.path.PathSignalDelayControl();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.pathSignalDelayControl);
            this.panel1.Size = new System.Drawing.Size(432, 293);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(370, 311);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(289, 311);
            // 
            // lblDenoteRequiredField
            // 
            this.lblDenoteRequiredField.Location = new System.Drawing.Point(1, 322);
            // 
            // pathSignalDelayControl1
            // 
            this.pathSignalDelayControl.DefaultComparitor = -1;
            this.pathSignalDelayControl.DefaultLimitType = -1;
            this.pathSignalDelayControl.DefaultStandardUnit = null;
            this.pathSignalDelayControl.DefaultValue = null;
            this.pathSignalDelayControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pathSignalDelayControl.Location = new System.Drawing.Point(0, 0);
            this.pathSignalDelayControl.Name = "pathSignalDelayControl1";
            this.pathSignalDelayControl.SchemaTypeName = null;
            this.pathSignalDelayControl.Size = new System.Drawing.Size(432, 293);
            this.pathSignalDelayControl.TabIndex = 0;
            this.pathSignalDelayControl.TargetNamespace = null;
            // 
            // PathSignalDelayForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(457, 338);
            this.Name = "PathSignalDelayForm";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private PathSignalDelayControl pathSignalDelayControl;
    }
}
