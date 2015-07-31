/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
* 
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

namespace ATMLCommonLibrary.controls.driver
{
    partial class DriverSelectionForm
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
            this.driverSelectionControl1 = new ATMLCommonLibrary.controls.driver.DriverSelectionControl();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.driverSelectionControl1);
            this.panel1.Size = new System.Drawing.Size(569, 566);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(507, 584);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(426, 584);
            // 
            // lblDenoteRequiredField
            // 
            this.lblDenoteRequiredField.Location = new System.Drawing.Point(1, 595);
            // 
            // driverSelectionControl1
            // 
            this.driverSelectionControl1.BackColor = System.Drawing.Color.AliceBlue;
            this.driverSelectionControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.driverSelectionControl1.HasErrors = false;
            this.driverSelectionControl1.HelpKeyWord = null;
            this.driverSelectionControl1.LastError = null;
            this.driverSelectionControl1.Location = new System.Drawing.Point(0, 0);
            this.driverSelectionControl1.Margin = new System.Windows.Forms.Padding(0);
            this.driverSelectionControl1.Name = "driverSelectionControl1";
            this.driverSelectionControl1.SchemaTypeName = null;
            this.driverSelectionControl1.Size = new System.Drawing.Size(569, 566);
            this.driverSelectionControl1.TabIndex = 0;
            this.driverSelectionControl1.TargetNamespace = null;
            // 
            // DriverSelectionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(594, 611);
            this.Name = "DriverSelectionForm";
            this.Text = "Control Driver";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DriverSelectionControl driverSelectionControl1;
    }
}
