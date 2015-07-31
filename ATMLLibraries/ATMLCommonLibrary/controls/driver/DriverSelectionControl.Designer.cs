/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
* 
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

namespace ATMLCommonLibrary.controls.driver
{
    partial class DriverSelectionControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DriverSelectionControl));
            this.panel1 = new System.Windows.Forms.Panel();
            this.vppDriverControl1 = new ATMLCommonLibrary.controls.driver.VPPDriverControl();
            this.ivicomDriverControl1 = new ATMLCommonLibrary.controls.driver.IVICOMDriverControl();
            this.ivicDriverControl1 = new ATMLCommonLibrary.controls.driver.IVICDriverControl();
            this.ivinetDriverControl1 = new ATMLCommonLibrary.controls.driver.IVINETDriverControl();
            this.cmbSelectedDriver = new System.Windows.Forms.ComboBox();
            this.helpLabel1 = new ATMLCommonLibrary.controls.HelpLabel(this.components);
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.vppDriverControl1);
            this.panel1.Controls.Add(this.ivicomDriverControl1);
            this.panel1.Controls.Add(this.ivicDriverControl1);
            this.panel1.Controls.Add(this.ivinetDriverControl1);
            this.panel1.Location = new System.Drawing.Point(0, 36);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(473, 504);
            this.panel1.TabIndex = 2;
            // 
            // vppDriverControl1
            // 
            this.vppDriverControl1.BackColor = System.Drawing.Color.AliceBlue;
            this.vppDriverControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.vppDriverControl1.Driver = ((ATMLModelLibrary.model.equipment.VPP)(resources.GetObject("vppDriverControl1.Driver")));
            this.vppDriverControl1.HasErrors = false;
            this.vppDriverControl1.HelpKeyWord = null;
            this.vppDriverControl1.LastError = null;
            this.vppDriverControl1.Location = new System.Drawing.Point(0, 0);
            this.vppDriverControl1.Name = "vppDriverControl1";
            this.vppDriverControl1.SchemaTypeName = null;
            this.vppDriverControl1.Size = new System.Drawing.Size(473, 504);
            this.vppDriverControl1.TabIndex = 3;
            this.vppDriverControl1.TargetNamespace = null;
            // 
            // ivicomDriverControl1
            // 
            this.ivicomDriverControl1.BackColor = System.Drawing.Color.AliceBlue;
            this.ivicomDriverControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ivicomDriverControl1.HasErrors = false;
            this.ivicomDriverControl1.HelpKeyWord = null;
            this.ivicomDriverControl1.LastError = null;
            this.ivicomDriverControl1.Location = new System.Drawing.Point(0, 0);
            this.ivicomDriverControl1.Name = "ivicomDriverControl1";
            this.ivicomDriverControl1.SchemaTypeName = null;
            this.ivicomDriverControl1.Size = new System.Drawing.Size(473, 504);
            this.ivicomDriverControl1.TabIndex = 2;
            this.ivicomDriverControl1.TargetNamespace = null;
            // 
            // ivicDriverControl1
            // 
            this.ivicDriverControl1.BackColor = System.Drawing.Color.AliceBlue;
            this.ivicDriverControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ivicDriverControl1.HasErrors = false;
            this.ivicDriverControl1.HelpKeyWord = null;
            this.ivicDriverControl1.LastError = null;
            this.ivicDriverControl1.Location = new System.Drawing.Point(0, 0);
            this.ivicDriverControl1.Name = "ivicDriverControl1";
            this.ivicDriverControl1.SchemaTypeName = null;
            this.ivicDriverControl1.Size = new System.Drawing.Size(473, 504);
            this.ivicDriverControl1.TabIndex = 1;
            this.ivicDriverControl1.TargetNamespace = null;
            // 
            // ivinetDriverControl1
            // 
            this.ivinetDriverControl1.BackColor = System.Drawing.Color.AliceBlue;
            this.ivinetDriverControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ivinetDriverControl1.HasErrors = false;
            this.ivinetDriverControl1.HelpKeyWord = null;
            this.ivinetDriverControl1.LastError = null;
            this.ivinetDriverControl1.Location = new System.Drawing.Point(0, 0);
            this.ivinetDriverControl1.Margin = new System.Windows.Forms.Padding(0);
            this.ivinetDriverControl1.Name = "ivinetDriverControl1";
            this.ivinetDriverControl1.SchemaTypeName = null;
            this.ivinetDriverControl1.Size = new System.Drawing.Size(473, 504);
            this.ivinetDriverControl1.TabIndex = 0;
            this.ivinetDriverControl1.TargetNamespace = null;
            // 
            // cmbSelectedDriver
            // 
            this.cmbSelectedDriver.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbSelectedDriver.FormattingEnabled = true;
            this.cmbSelectedDriver.Items.AddRange(new object[] {
            "IVI-C",
            "IVI-COM",
            "IVI.NET",
            "VPP"});
            this.cmbSelectedDriver.Location = new System.Drawing.Point(84, 12);
            this.cmbSelectedDriver.Name = "cmbSelectedDriver";
            this.cmbSelectedDriver.Size = new System.Drawing.Size(366, 21);
            this.cmbSelectedDriver.TabIndex = 0;
            this.cmbSelectedDriver.SelectedIndexChanged += new System.EventHandler(this.cmbDriverSelect_SelectedIndexChanged);
            // 
            // helpLabel1
            // 
            this.helpLabel1.AutoSize = true;
            this.helpLabel1.HelpMessageKey = "DriverSelectionControl.SelectDriver";
            this.helpLabel1.Location = new System.Drawing.Point(9, 15);
            this.helpLabel1.Name = "helpLabel1";
            this.helpLabel1.RequiredField = false;
            this.helpLabel1.RequiredFieldMarkerFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.helpLabel1.Size = new System.Drawing.Size(71, 13);
            this.helpLabel1.TabIndex = 1;
            this.helpLabel1.Text = "Select Driver:";
            // 
            // DriverSelectionControl
            // 
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.helpLabel1);
            this.Controls.Add(this.cmbSelectedDriver);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "DriverSelectionControl";
            this.Size = new System.Drawing.Size(473, 543);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbSelectedDriver;
        private HelpLabel helpLabel1;
        private System.Windows.Forms.Panel panel1;
        private IVINETDriverControl ivinetDriverControl1;
        private IVICDriverControl ivicDriverControl1;
        private IVICOMDriverControl ivicomDriverControl1;
        private VPPDriverControl vppDriverControl1;
    }
}
