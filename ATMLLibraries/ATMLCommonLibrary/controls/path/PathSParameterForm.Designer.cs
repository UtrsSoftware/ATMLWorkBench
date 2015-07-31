/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
*
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/
namespace ATMLCommonLibrary.controls.path
{
    partial class PathSParameterForm
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
            this.pathSParameterControl = new ATMLCommonLibrary.controls.path.PathSParameterControl();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.pathSParameterControl);
            // 
            // pathSParameterControl
            // 
            this.pathSParameterControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pathSParameterControl.Location = new System.Drawing.Point(0, 0);
            this.pathSParameterControl.Name = "pathSParameterControl";
            this.pathSParameterControl.SchemaTypeName = null;
            this.pathSParameterControl.Size = new System.Drawing.Size(433, 270);
            this.pathSParameterControl.TabIndex = 0;
            this.pathSParameterControl.TargetNamespace = null;
            // 
            // PathSParameterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(458, 315);
            this.Name = "PathSParameterForm";
            this.Text = "Path S Parameter";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private PathSParameterControl pathSParameterControl; 
    }
}