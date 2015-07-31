/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
* 
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

namespace ATMLCommonLibrary.controls.driver
{
    partial class IVICDriverControl
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
            this.edtPrefix = new ATMLCommonLibrary.controls.awb.AWBTextBox(this.components);
            this.tabControl1.SuspendLayout();
            this.tabClass.SuspendLayout();
            this.tabDocument.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Location = new System.Drawing.Point(15, 224);
            this.tabControl1.Size = new System.Drawing.Size(457, 142);
            // 
            // tabClass
            // 
            this.tabClass.Size = new System.Drawing.Size(449, 116);
            this.tabClass.Click += new System.EventHandler(this.tabClass_Click);
            // 
            // tabDocument
            // 
            this.tabDocument.Size = new System.Drawing.Size(449, 116);
            // 
            // lvClassNames
            // 
            this.lvClassNames.Size = new System.Drawing.Size(443, 110);
            // 
            // documentControl
            // 
            this.documentControl.Size = new System.Drawing.Size(443, 110);
            // 
            // driverModuleControl
            // 
            this.driverModuleControl.Size = new System.Drawing.Size(459, 97);
            // 
            // driverUnifiedControl
            // 
            this.driverUnifiedControl.Size = new System.Drawing.Size(459, 187);
            // 
            // helpLabel1
            // 
            this.helpLabel1.AutoSize = true;
            this.helpLabel1.HelpMessageKey = null;
            this.helpLabel1.Location = new System.Drawing.Point(173, 16);
            this.helpLabel1.Name = "helpLabel1";
            this.helpLabel1.RequiredField = false;
            this.helpLabel1.RequiredFieldMarkerFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.helpLabel1.Size = new System.Drawing.Size(36, 13);
            this.helpLabel1.TabIndex = 12;
            this.helpLabel1.Text = "Prefix:";
            // 
            // edtPrefix
            // 
            this.edtPrefix.AttributeName = null;
            this.edtPrefix.DataLookupKey = null;
            this.edtPrefix.Location = new System.Drawing.Point(212, 13);
            this.edtPrefix.Name = "edtPrefix";
            this.edtPrefix.Size = new System.Drawing.Size(227, 20);
            this.edtPrefix.TabIndex = 13;
            this.edtPrefix.Value = null;
            this.edtPrefix.ValueType = ATMLCommonLibrary.controls.awb.AWBTextBox.eValueType.xsString;
            // 
            // IVICDriverControl
            // 
            this.Controls.Add(this.edtPrefix);
            this.Controls.Add(this.helpLabel1);
            this.Name = "IVICDriverControl";
            this.Controls.SetChildIndex(this.driverUnifiedControl, 0);
            this.Controls.SetChildIndex(this.driverModuleControl, 0);
            this.Controls.SetChildIndex(this.cmbDriverType, 0);
            this.Controls.SetChildIndex(this.lblDriverType, 0);
            this.Controls.SetChildIndex(this.tabControl1, 0);
            this.Controls.SetChildIndex(this.helpLabel1, 0);
            this.Controls.SetChildIndex(this.edtPrefix, 0);
            this.tabControl1.ResumeLayout(false);
            this.tabClass.ResumeLayout(false);
            this.tabDocument.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private HelpLabel helpLabel1;
        private awb.AWBTextBox edtPrefix;
    }
}
