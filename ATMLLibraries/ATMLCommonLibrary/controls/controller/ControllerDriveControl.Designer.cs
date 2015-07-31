/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
*
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/
namespace ATMLCommonLibrary.controls.controller
{
    partial class ControllerDriveControl
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
            this.helpLabel1 = new ATMLCommonLibrary.controls.HelpLabel(this.components);
            this.helpLabel2 = new ATMLCommonLibrary.controls.HelpLabel(this.components);
            this.helpLabel3 = new ATMLCommonLibrary.controls.HelpLabel(this.components);
            this.BDcheck = new System.Windows.Forms.CheckBox();
            this.edtName = new ATMLCommonLibrary.controls.awb.AWBTextBox(this.components);
            this.DatumSize = new ATMLCommonLibrary.controls.datum.DatumTypeDoubleControl();
            this.SuspendLayout();
            // 
            // helpLabel1
            // 
            this.helpLabel1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.helpLabel1.AutoSize = true;
            this.helpLabel1.HelpMessageKey = "ControllerDrive.BootDrive";
            this.helpLabel1.Location = new System.Drawing.Point(11, 108);
            this.helpLabel1.Name = "helpLabel1";
            this.helpLabel1.RequiredField = false;
            this.helpLabel1.RequiredFieldMarkerFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.helpLabel1.Size = new System.Drawing.Size(57, 13);
            this.helpLabel1.TabIndex = 0;
            this.helpLabel1.Text = "Boot Drive";
            // 
            // helpLabel2
            // 
            this.helpLabel2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.helpLabel2.AutoSize = true;
            this.helpLabel2.HelpMessageKey = "ControllerDrive.Name";
            this.helpLabel2.Location = new System.Drawing.Point(11, 82);
            this.helpLabel2.Name = "helpLabel2";
            this.helpLabel2.RequiredField = false;
            this.helpLabel2.RequiredFieldMarkerFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.helpLabel2.Size = new System.Drawing.Size(35, 13);
            this.helpLabel2.TabIndex = 1;
            this.helpLabel2.Text = "Name";
            // 
            // helpLabel3
            // 
            this.helpLabel3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.helpLabel3.AutoSize = true;
            this.helpLabel3.HelpMessageKey = "ControllerDrive.Size";
            this.helpLabel3.Location = new System.Drawing.Point(11, 8);
            this.helpLabel3.Name = "helpLabel3";
            this.helpLabel3.RequiredField = false;
            this.helpLabel3.RequiredFieldMarkerFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.helpLabel3.Size = new System.Drawing.Size(27, 13);
            this.helpLabel3.TabIndex = 2;
            this.helpLabel3.Text = "Size";
            // 
            // BDcheck
            // 
            this.BDcheck.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.BDcheck.AutoSize = true;
            this.BDcheck.Location = new System.Drawing.Point(74, 108);
            this.BDcheck.Name = "BDcheck";
            this.BDcheck.Size = new System.Drawing.Size(15, 14);
            this.BDcheck.TabIndex = 3;
            this.BDcheck.UseVisualStyleBackColor = true;
            // 
            // edtName
            // 
            this.edtName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.edtName.AttributeName = null;
            this.edtName.DataLookupKey = null;
            this.edtName.Location = new System.Drawing.Point(52, 79);
            this.edtName.Name = "edtName";
            this.edtName.Size = new System.Drawing.Size(128, 20);
            this.edtName.TabIndex = 4;
            this.edtName.Value = null;
            this.edtName.ValueType = ATMLCommonLibrary.controls.awb.AWBTextBox.eValueType.xsString;
            // 
            // DatumSize
            // 
            this.DatumSize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.DatumSize.BackColor = System.Drawing.Color.White;
            this.DatumSize.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.DatumSize.HasErrors = false;
            this.DatumSize.HelpKeyWord = null;
            this.DatumSize.LastError = null;
            this.DatumSize.Location = new System.Drawing.Point(14, 27);
            this.DatumSize.Name = "DatumSize";
            this.DatumSize.SchemaTypeName = null;
            this.DatumSize.Size = new System.Drawing.Size(166, 46);
            this.DatumSize.TabIndex = 5;
            this.DatumSize.TargetNamespace = null;
            this.DatumSize.UseFlowControl = null;
            // 
            // ControllerDriveControl
            // 
            this.Controls.Add(this.DatumSize);
            this.Controls.Add(this.edtName);
            this.Controls.Add(this.BDcheck);
            this.Controls.Add(this.helpLabel3);
            this.Controls.Add(this.helpLabel2);
            this.Controls.Add(this.helpLabel1);
            this.Name = "ControllerDriveControl";
            this.Size = new System.Drawing.Size(196, 137);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private HelpLabel helpLabel1;
        private HelpLabel helpLabel2;
        private HelpLabel helpLabel3;
        private System.Windows.Forms.CheckBox BDcheck;
        private awb.AWBTextBox edtName;
        private datum.DatumTypeDoubleControl DatumSize;
    }
}
