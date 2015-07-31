/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
*
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

using ATMLModelLibrary.model.equipment;

namespace ATMLCommonLibrary.controls.driver
{
    partial class DriverUnifiedControl
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
            this.driverModule64BitControl = new DriverModuleControl();
            this.driverModule32BitControl = new DriverModuleControl();
            this.SuspendLayout();
            // 
            // driverModule64BitControl
            // 
            this.driverModule64BitControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.driverModule64BitControl.BackColor = System.Drawing.Color.AliceBlue;
            this.driverModule64BitControl.HelpKeyWord = null;
            this.driverModule64BitControl.Location = new System.Drawing.Point(2, 98);
            this.driverModule64BitControl.MinimumSize = new System.Drawing.Size(250, 87);
            this.driverModule64BitControl.Name = "driverModule64BitControl";
            this.driverModule64BitControl.SchemaTypeName = null;
            this.driverModule64BitControl.Size = new System.Drawing.Size(279, 87);
            this.driverModule64BitControl.TabIndex = 1;
            this.driverModule64BitControl.TargetNamespace = null;
            this.driverModule64BitControl.DriverItemChoiceType = DriverItemChoiceType.Bit64;
            // 
            // driverModule32BitControl
            // 
            this.driverModule32BitControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.driverModule32BitControl.BackColor = System.Drawing.Color.AliceBlue;
            this.driverModule32BitControl.HelpKeyWord = null;
            this.driverModule32BitControl.Location = new System.Drawing.Point(2, 5);
            this.driverModule32BitControl.MinimumSize = new System.Drawing.Size(250, 87);
            this.driverModule32BitControl.Name = "driverModule32BitControl";
            this.driverModule32BitControl.SchemaTypeName = null;
            this.driverModule32BitControl.Size = new System.Drawing.Size(279, 87);
            this.driverModule32BitControl.TabIndex = 0;
            this.driverModule32BitControl.TargetNamespace = null;
            this.driverModule32BitControl.DriverItemChoiceType = DriverItemChoiceType.Bit32;
            // 
            // DriverUnifiedControl
            // 
            this.Controls.Add(this.driverModule64BitControl);
            this.Controls.Add(this.driverModule32BitControl);
            this.Name = "DriverUnifiedControl";
            this.Size = new System.Drawing.Size(281, 183);
            this.ResumeLayout(false);

        }

        #endregion

        private DriverModuleControl driverModule32BitControl;
        private DriverModuleControl driverModule64BitControl;
    }
}
