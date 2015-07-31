/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
*
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/
namespace ATMLCommonLibrary.controls.calibration
{
    partial class CalibrationRequirementsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CalibrationRequirementsForm));
            this._calibrationRequirementsControl = new ATMLCommonLibrary.controls.calibration.CalibrationRequirementsControl();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this._calibrationRequirementsControl);
            this.panel1.Size = new System.Drawing.Size(567, 406);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(505, 424);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(424, 424);
            // 
            // lblDenoteRequiredField
            // 
            this.lblDenoteRequiredField.Location = new System.Drawing.Point(1, 435);
            // 
            // _calibrationRequirementsControl
            // 
            this._calibrationRequirementsControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this._calibrationRequirementsControl.HelpKeyWord = null;
            this._calibrationRequirementsControl.Location = new System.Drawing.Point(0, 0);
            this._calibrationRequirementsControl.Name = "_calibrationRequirementsControl";
            this._calibrationRequirementsControl.SchemaTypeName = null;
            this._calibrationRequirementsControl.Size = new System.Drawing.Size(567, 406);
            this._calibrationRequirementsControl.TabIndex = 0;
            this._calibrationRequirementsControl.TargetNamespace = null;
            // 
            // CalibrationRequirementsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(592, 451);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CalibrationRequirementsForm";
            this.Text = "Calibration Requirements";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CalibrationRequirementsControl _calibrationRequirementsControl;
    }
}