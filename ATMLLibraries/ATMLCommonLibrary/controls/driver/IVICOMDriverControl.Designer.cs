/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
* 
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

namespace ATMLCommonLibrary.controls.driver
{
    partial class IVICOMDriverControl
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
            this.edtProgID = new ATMLCommonLibrary.controls.awb.AWBTextBox(this.components);
            this.helpLabel1 = new ATMLCommonLibrary.controls.HelpLabel(this.components);
            this.tabControl1.SuspendLayout();
            this.tabClass.SuspendLayout();
            this.tabDocument.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Location = new System.Drawing.Point(13, 224);
            this.tabControl1.Size = new System.Drawing.Size(462, 146);
            // 
            // tabClass
            // 
            this.tabClass.Size = new System.Drawing.Size(454, 120);
            // 
            // tabDocument
            // 
            this.tabDocument.Size = new System.Drawing.Size(454, 230);
            // 
            // lvClassNames
            // 
            this.lvClassNames.Size = new System.Drawing.Size(448, 114);
            // 
            // documentControl
            // 
            this.documentControl.Size = new System.Drawing.Size(448, 224);
            // 
            // driverModuleControl
            // 
            this.driverModuleControl.Size = new System.Drawing.Size(462, 93);
            // 
            // driverUnifiedControl
            // 
            this.driverUnifiedControl.Size = new System.Drawing.Size(462, 183);
            // 
            // edtProgID
            // 
            this.edtProgID.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtProgID.AttributeName = null;
            this.edtProgID.Location = new System.Drawing.Point(244, 14);
            this.edtProgID.Name = "edtProgID";
            this.edtProgID.Size = new System.Drawing.Size(197, 20);
            this.edtProgID.TabIndex = 12;
            this.edtProgID.Value = null;
            this.edtProgID.ValueType = ATMLCommonLibrary.controls.awb.AWBTextBox.eValueType.xsString;
            // 
            // helpLabel1
            // 
            this.helpLabel1.AutoSize = true;
            this.helpLabel1.HelpMessageKey = null;
            this.helpLabel1.Location = new System.Drawing.Point(173, 16);
            this.helpLabel1.Name = "helpLabel1";
            this.helpLabel1.RequiredField = false;
            this.helpLabel1.RequiredFieldMarkerFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.helpLabel1.Size = new System.Drawing.Size(60, 13);
            this.helpLabel1.TabIndex = 13;
            this.helpLabel1.Text = "Program ID";
            // 
            // IVICOMDriverControl
            // 
            this.Controls.Add(this.helpLabel1);
            this.Controls.Add(this.edtProgID);
            this.MinimumSize = new System.Drawing.Size(0, 0);
            this.Name = "IVICOMDriverControl";
            this.Size = new System.Drawing.Size(490, 380);
            this.Controls.SetChildIndex(this.driverUnifiedControl, 0);
            this.Controls.SetChildIndex(this.driverModuleControl, 0);
            this.Controls.SetChildIndex(this.cmbDriverType, 0);
            this.Controls.SetChildIndex(this.lblDriverType, 0);
            this.Controls.SetChildIndex(this.tabControl1, 0);
            this.Controls.SetChildIndex(this.edtProgID, 0);
            this.Controls.SetChildIndex(this.helpLabel1, 0);
            this.tabControl1.ResumeLayout(false);
            this.tabClass.ResumeLayout(false);
            this.tabDocument.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private awb.AWBTextBox edtProgID;
        private HelpLabel helpLabel1;
    }
}
