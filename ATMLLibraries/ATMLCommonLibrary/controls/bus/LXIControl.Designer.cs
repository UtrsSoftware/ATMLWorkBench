/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
*
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/
namespace ATMLCommonLibrary.controls.bus
{
    partial class LXIControl
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
            this.lblLXIVersion = new ATMLCommonLibrary.controls.HelpLabel(this.components);
            this.edtLXIVersion = new ATMLCommonLibrary.controls.awb.AWBTextBox(this.components);
            this.helpLabel2 = new ATMLCommonLibrary.controls.HelpLabel(this.components);
            this.cmbLXIClass = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // lblLXIVersion
            // 
            this.lblLXIVersion.HelpMessageKey = "LXI.Version";
            this.lblLXIVersion.Location = new System.Drawing.Point(10, 59);
            this.lblLXIVersion.Name = "lblLXIVersion";
            this.lblLXIVersion.RequiredField = true;
            this.lblLXIVersion.RequiredFieldMarkerFont = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLXIVersion.Size = new System.Drawing.Size(66, 13);
            this.lblLXIVersion.TabIndex = 9;
            this.lblLXIVersion.Text = "LXI Version";
            // 
            // edtLXIVersion
            // 
            this.edtLXIVersion.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtLXIVersion.Location = new System.Drawing.Point(97, 59);
            this.edtLXIVersion.Name = "edtLXIVersion";
            this.edtLXIVersion.Size = new System.Drawing.Size(166, 20);
            this.edtLXIVersion.TabIndex = 10;
            this.edtLXIVersion.Value = null;
            this.edtLXIVersion.ValueType = ATMLCommonLibrary.controls.awb.AWBTextBox.eValueType.xsString;
            // 
            // helpLabel2
            // 
            this.helpLabel2.HelpMessageKey = "LXI.Class";
            this.helpLabel2.Location = new System.Drawing.Point(10, 87);
            this.helpLabel2.Name = "helpLabel2";
            this.helpLabel2.RequiredField = true;
            this.helpLabel2.RequiredFieldMarkerFont = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.helpLabel2.Size = new System.Drawing.Size(56, 13);
            this.helpLabel2.TabIndex = 11;
            this.helpLabel2.Text = "LXI Class";
            // 
            // cmbLXIClass
            // 
            this.cmbLXIClass.FormattingEnabled = true;
            this.cmbLXIClass.Location = new System.Drawing.Point(97, 85);
            this.cmbLXIClass.Name = "cmbLXIClass";
            this.cmbLXIClass.Size = new System.Drawing.Size(71, 21);
            this.cmbLXIClass.TabIndex = 12;
            // 
            // LXIControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cmbLXIClass);
            this.Controls.Add(this.helpLabel2);
            this.Controls.Add(this.edtLXIVersion);
            this.Controls.Add(this.lblLXIVersion);
            this.Name = "LXIControl";
            this.Size = new System.Drawing.Size(289, 115);
            this.Controls.SetChildIndex(this.edtDefaultAddress, 0);
            this.Controls.SetChildIndex(this.lblDefaultAddress, 0);
            this.Controls.SetChildIndex(this.lblLXIVersion, 0);
            this.Controls.SetChildIndex(this.edtLXIVersion, 0);
            this.Controls.SetChildIndex(this.helpLabel2, 0);
            this.Controls.SetChildIndex(this.cmbLXIClass, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private HelpLabel lblLXIVersion;
        private awb.AWBTextBox edtLXIVersion;
        private HelpLabel helpLabel2;
        private System.Windows.Forms.ComboBox cmbLXIClass;
    }
}
