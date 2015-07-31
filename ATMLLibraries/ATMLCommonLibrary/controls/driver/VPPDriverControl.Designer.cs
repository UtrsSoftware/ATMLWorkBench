/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
*
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/
namespace ATMLCommonLibrary.controls.driver
{
    partial class VPPDriverControl
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
            this.helpLabelPrefix = new ATMLCommonLibrary.controls.HelpLabel(this.components);
            this.edtPrefix = new ATMLCommonLibrary.controls.awb.AWBTextBox(this.components);
            this.SuspendLayout();
            // 
            // driverModuleControl
            // 
            this.driverModuleControl.Size = new System.Drawing.Size(458, 93);
            // 
            // driverUnifiedControl
            // 
            this.driverUnifiedControl.Size = new System.Drawing.Size(458, 183);
            // 
            // helpLabelPrefix
            // 
            this.helpLabelPrefix.AutoSize = true;
            this.helpLabelPrefix.HelpMessageKey = "VPPDriver.Prefix";
            this.helpLabelPrefix.Location = new System.Drawing.Point(173, 16);
            this.helpLabelPrefix.Name = "helpLabelPrefix";
            this.helpLabelPrefix.RequiredField = false;
            this.helpLabelPrefix.RequiredFieldMarkerFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.helpLabelPrefix.Size = new System.Drawing.Size(33, 13);
            this.helpLabelPrefix.TabIndex = 9;
            this.helpLabelPrefix.Text = "Prefix";
            // 
            // edtPrefix
            // 
            this.edtPrefix.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtPrefix.AttributeName = null;
            this.edtPrefix.Location = new System.Drawing.Point(212, 13);
            this.edtPrefix.Name = "edtPrefix";
            this.edtPrefix.Size = new System.Drawing.Size(225, 20);
            this.edtPrefix.TabIndex = 10;
            this.edtPrefix.Value = null;
            this.edtPrefix.ValueType = ATMLCommonLibrary.controls.awb.AWBTextBox.eValueType.xsString;
            // 
            // VPPDriverControl
            // 
            this.Controls.Add(this.edtPrefix);
            this.Controls.Add(this.helpLabelPrefix);
            this.Name = "VPPDriverControl";
            this.Size = new System.Drawing.Size(490, 380);
            this.Controls.SetChildIndex(this.cmbDriverType, 0);
            this.Controls.SetChildIndex(this.driverUnifiedControl, 0);
            this.Controls.SetChildIndex(this.driverModuleControl, 0);
            this.Controls.SetChildIndex(this.lblDriverType, 0);
            this.Controls.SetChildIndex(this.helpLabelPrefix, 0);
            this.Controls.SetChildIndex(this.edtPrefix, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private HelpLabel helpLabelPrefix;
        private awb.AWBTextBox edtPrefix;
    }
}
