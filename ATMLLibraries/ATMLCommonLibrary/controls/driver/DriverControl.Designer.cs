/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
*
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

using ATMLCommonLibrary.controls.hardware;
using ATMLModelLibrary.model.equipment;

namespace ATMLCommonLibrary.controls.driver
{
    partial class DriverControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DriverControl));
            this.driverModuleControl = new ATMLCommonLibrary.controls.driver.DriverModuleControl();
            this.cmbDriverType = new System.Windows.Forms.ComboBox();
            this.lblDriverType = new ATMLCommonLibrary.controls.HelpLabel(this.components);
            this.driverUnifiedControl = new DriverUnifiedControl();
            this.SuspendLayout();
            // 
            // driverModuleControl
            // 
            this.driverModuleControl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.driverModuleControl.BackColor = System.Drawing.Color.AliceBlue;
            this.driverModuleControl.DriverItemChoiceType = ATMLModelLibrary.model.equipment.DriverItemChoiceType.Bit16;
            this.driverModuleControl.DriverModule = ((ATMLModelLibrary.model.equipment.DriverModule)(resources.GetObject("driverModuleControl.DriverModule")));
            this.driverModuleControl.HelpKeyWord = null;
            this.driverModuleControl.Location = new System.Drawing.Point(13, 40);
            this.driverModuleControl.MinimumSize = new System.Drawing.Size(250, 87);
            this.driverModuleControl.Name = "driverModuleControl";
            this.driverModuleControl.SchemaTypeName = null;
            this.driverModuleControl.Size = new System.Drawing.Size(464, 93);
            this.driverModuleControl.TabIndex = 8;
            this.driverModuleControl.TargetNamespace = null;
            // 
            // cmbDriverType
            // 
            this.cmbDriverType.FormattingEnabled = true;
            this.cmbDriverType.Location = new System.Drawing.Point(88, 13);
            this.cmbDriverType.Name = "cmbDriverType";
            this.cmbDriverType.Size = new System.Drawing.Size(67, 21);
            this.cmbDriverType.TabIndex = 7;
            this.cmbDriverType.SelectedIndexChanged += new System.EventHandler(this.cmbVersionIdentifierQualifier_SelectedIndexChanged);
            // 
            // lblDriverType
            // 
            this.lblDriverType.HelpMessageKey = "Driver.Module";
            this.lblDriverType.Location = new System.Drawing.Point(12, 12);
            this.lblDriverType.Name = "lblDriverType";
            this.lblDriverType.RequiredField = false;
            this.lblDriverType.RequiredFieldMarkerFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDriverType.Size = new System.Drawing.Size(73, 21);
            this.lblDriverType.TabIndex = 6;
            this.lblDriverType.Text = "Driver Type";
            this.lblDriverType.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // driverUnifiedControl
            // 
            this.driverUnifiedControl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.driverUnifiedControl.BackColor = System.Drawing.Color.AliceBlue;
            this.driverUnifiedControl.HelpKeyWord = null;
            this.driverUnifiedControl.Location = new System.Drawing.Point(11, 35);
            this.driverUnifiedControl.Name = "driverUnifiedControl";
            this.driverUnifiedControl.SchemaTypeName = null;
            this.driverUnifiedControl.Size = new System.Drawing.Size(464, 183);
            this.driverUnifiedControl.TabIndex = 9;
            this.driverUnifiedControl.TargetNamespace = null;
            // 
            // DriverControl
            // 
            this.Controls.Add(this.lblDriverType);
            this.Controls.Add(this.cmbDriverType);
            this.Controls.Add(this.driverModuleControl);
            this.Controls.Add(this.driverUnifiedControl);
            this.Name = "DriverControl";
            this.Size = new System.Drawing.Size(491, 225);
            this.ResumeLayout(false);

        }

        #endregion

        protected System.Windows.Forms.ComboBox cmbDriverType;
        protected HelpLabel lblDriverType;
        protected DriverModuleControl driverModuleControl;
        protected DriverUnifiedControl driverUnifiedControl;
    }
}
