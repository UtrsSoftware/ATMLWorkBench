/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
*
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/
namespace ATMLCommonLibrary.controls.driver
{
    partial class DriverForm
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
            this.components = new System.ComponentModel.Container();
            this.iviDriverControl1 = new ATMLCommonLibrary.controls.driver.IVIDriverControl();
            this.cmbDriverType = new System.Windows.Forms.ComboBox();
            this.helpLabel1 = new ATMLCommonLibrary.controls.HelpLabel(this.components);
            this.vppDriverControl = new ATMLCommonLibrary.controls.driver.VPPDriverControl();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cmbDriverType);
            this.panel1.Controls.Add(this.helpLabel1);
            this.panel1.Controls.Add(this.vppDriverControl);
            this.panel1.Controls.Add(this.iviDriverControl1);
            this.panel1.Size = new System.Drawing.Size(679, 469);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(617, 487);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(536, 487);
            // 
            // lblDenoteRequiredField
            // 
            this.lblDenoteRequiredField.Location = new System.Drawing.Point(1, 498);
            // 
            // iviDriverControl1
            // 
            this.iviDriverControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.iviDriverControl1.Driver = null;
            this.iviDriverControl1.Location = new System.Drawing.Point(0, 0);
            this.iviDriverControl1.MinimumSize = new System.Drawing.Size(563, 199);
            this.iviDriverControl1.Name = "iviDriverControl1";
            this.iviDriverControl1.SchemaTypeName = null;
            this.iviDriverControl1.Size = new System.Drawing.Size(679, 469);
            this.iviDriverControl1.TabIndex = 0;
            this.iviDriverControl1.TargetNamespace = null;
            // 
            // cmbDriverType
            // 
            this.cmbDriverType.FormattingEnabled = true;
            this.cmbDriverType.Location = new System.Drawing.Point(74, 8);
            this.cmbDriverType.Name = "cmbDriverType";
            this.cmbDriverType.Size = new System.Drawing.Size(93, 21);
            this.cmbDriverType.TabIndex = 2;
            // 
            // helpLabel1
            // 
            this.helpLabel1.AutoSize = true;
            this.helpLabel1.HelpMessageKey = null;
            this.helpLabel1.Location = new System.Drawing.Point(10, 11);
            this.helpLabel1.Name = "helpLabel1";
            this.helpLabel1.RequiredField = false;
            this.helpLabel1.RequiredFieldMarkerFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.helpLabel1.Size = new System.Drawing.Size(31, 13);
            this.helpLabel1.TabIndex = 1;
            this.helpLabel1.Text = "Type";
            // 
            // vppDriverControl
            // 
            this.vppDriverControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.vppDriverControl.Location = new System.Drawing.Point(0, 0);
            this.vppDriverControl.MinimumSize = new System.Drawing.Size(563, 199);
            this.vppDriverControl.Name = "vppDriverControl";
            this.vppDriverControl.SchemaTypeName = null;
            this.vppDriverControl.Size = new System.Drawing.Size(679, 469);
            this.vppDriverControl.TabIndex = 3;
            this.vppDriverControl.TargetNamespace = null;
            // 
            // DriverForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(704, 514);
            this.Name = "DriverForm";
            this.Text = "Driver";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbDriverType;
        private ATMLCommonLibrary.controls.HelpLabel helpLabel1;
        private ATMLCommonLibrary.controls.driver.VPPDriverControl vppDriverControl;
        private ATMLCommonLibrary.controls.driver.IVIDriverControl iviDriverControl1;
    }
}
