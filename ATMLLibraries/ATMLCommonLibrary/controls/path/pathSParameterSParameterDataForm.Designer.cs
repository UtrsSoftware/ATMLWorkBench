/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
*
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/
namespace ATMLCommonLibrary.controls.path
{
    partial class pathSParameterSParameterDataForm
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
            this.pathSParameterSParameterDataControl = new ATMLCommonLibrary.controls.path.pathSParameterSParameterDataControl();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.pathSParameterSParameterDataControl);
            this.panel1.Size = new System.Drawing.Size(315, 162);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(253, 180);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(172, 180);
            // 
            // lblDenoteRequiredField
            // 
            this.lblDenoteRequiredField.Location = new System.Drawing.Point(1, 191);
            // 
            // pathSParameterSParameterDataControl
            // 
            this.pathSParameterSParameterDataControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pathSParameterSParameterDataControl.Location = new System.Drawing.Point(0, 0);
            this.pathSParameterSParameterDataControl.Name = "pathSParameterSParameterDataControl";
            this.pathSParameterSParameterDataControl.SchemaTypeName = null;
            this.pathSParameterSParameterDataControl.Size = new System.Drawing.Size(315, 162);
            this.pathSParameterSParameterDataControl.TabIndex = 0;
            this.pathSParameterSParameterDataControl.TargetNamespace = null;
            // 
            // pathSParameterSParameterDataForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(340, 207);
            this.Name = "pathSParameterSParameterDataForm";
            this.Text = "pathSParameterSParameterDataForm";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private pathSParameterSParameterDataControl pathSParameterSParameterDataControl;
    }
}