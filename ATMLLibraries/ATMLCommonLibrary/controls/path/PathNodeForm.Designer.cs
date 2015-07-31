/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
*
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/
namespace ATMLCommonLibrary.controls.path
{
    partial class PathNodeForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PathNodeForm));
            this.pathNodeControl = new ATMLCommonLibrary.controls.path.PathNodeControl();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.pathNodeControl);
            this.panel1.Size = new System.Drawing.Size(656, 206);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(594, 224);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(513, 224);
            // 
            // lblDenoteRequiredField
            // 
            this.lblDenoteRequiredField.Location = new System.Drawing.Point(1, 235);
            // 
            // pathNodeControl
            // 
            this.pathNodeControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pathNodeControl.HardwareItemDescription = null;
            this.pathNodeControl.Location = new System.Drawing.Point(0, 0);
            this.pathNodeControl.Name = "pathNodeControl";
            this.pathNodeControl.NetworkNode = ((ATMLModelLibrary.model.equipment.NetworkNode)(resources.GetObject("pathNodeControl.NetworkNode")));
            this.pathNodeControl.SchemaTypeName = null;
            this.pathNodeControl.Size = new System.Drawing.Size(656, 206);
            this.pathNodeControl.TabIndex = 0;
            this.pathNodeControl.TargetNamespace = null;
            // 
            // PathNodeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(681, 251);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "PathNodeForm";
            this.Text = "Path Node";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private PathNodeControl pathNodeControl;
    }
}
