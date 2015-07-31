/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
*
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/
namespace ATMLCommonLibrary.controls.path
{
    partial class PathSParameterDataForm
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
            this.pathSParameterDataControl = new ATMLCommonLibrary.controls.path.PathSParameterDataControl();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.pathSParameterDataControl);
            this.panel1.Size = new System.Drawing.Size(345, 162);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(283, 180);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(202, 180);
            // 
            // lblDenoteRequiredField
            // 
            this.lblDenoteRequiredField.Location = new System.Drawing.Point(1, 191);
            // 
            // pathSParameterDataControl
            // 
            this.pathSParameterDataControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pathSParameterDataControl.Location = new System.Drawing.Point(0, 0);
            this.pathSParameterDataControl.Name = "PathSParameterDataControl";
            this.pathSParameterDataControl.SchemaTypeName = null;
            this.pathSParameterDataControl.Size = new System.Drawing.Size(345, 162);
            this.pathSParameterDataControl.TabIndex = 0;
            this.pathSParameterDataControl.TargetNamespace = null;
            // 
            // pathSParameterSParameterDataForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(370, 207);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "PathSParameterDataForm";
            this.Text = "Path SParameter Data";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private PathSParameterDataControl pathSParameterDataControl;
    }
}