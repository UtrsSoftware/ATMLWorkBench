/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
*
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/
namespace ATMLCommonLibrary.controls.path
{
    partial class PathVSWRValueForm
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
            this.pathVSWRValueControl = new ATMLCommonLibrary.controls.path.PathVSWRValueControl();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.pathVSWRValueControl);
            this.panel1.Size = new System.Drawing.Size(691, 460);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(629, 478);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(548, 478);
            // 
            // lblDenoteRequiredField
            // 
            this.lblDenoteRequiredField.Location = new System.Drawing.Point(1, 489);
            // 
            // pathVSWRValueControl
            // 
            this.pathVSWRValueControl.DefaultComparitor = -1;
            this.pathVSWRValueControl.DefaultLimitType = -1;
            this.pathVSWRValueControl.DefaultStandardUnit = null;
            this.pathVSWRValueControl.DefaultValue = null;
            this.pathVSWRValueControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pathVSWRValueControl.Location = new System.Drawing.Point(0, 0);
            this.pathVSWRValueControl.Name = "pathVSWRValueControl";
            this.pathVSWRValueControl.SchemaTypeName = null;
            this.pathVSWRValueControl.Size = new System.Drawing.Size(691, 460);
            this.pathVSWRValueControl.TabIndex = 0;
            this.pathVSWRValueControl.TargetNamespace = null;
            // 
            // PathVSWRValueForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(716, 505);
            this.Name = "PathVSWRValueForm";
            this.Text = "Path VSWR Value";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private PathVSWRValueControl pathVSWRValueControl;
    }
}
