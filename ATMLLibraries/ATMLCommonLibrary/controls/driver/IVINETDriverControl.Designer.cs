/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
* 
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

namespace ATMLCommonLibrary.controls.driver
{
    partial class IVINETDriverControl
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
            this.edtClassName = new ATMLCommonLibrary.controls.awb.AWBTextBox(this.components);
            this.helpLabel1 = new ATMLCommonLibrary.controls.HelpLabel(this.components);
            this.tabControl1.SuspendLayout();
            this.tabClass.SuspendLayout();
            this.tabDocument.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Location = new System.Drawing.Point(13, 224);
            this.tabControl1.Size = new System.Drawing.Size(456, 143);
            // 
            // tabClass
            // 
            this.tabClass.Size = new System.Drawing.Size(448, 117);
            // 
            // tabDocument
            // 
            this.tabDocument.Size = new System.Drawing.Size(448, 227);
            // 
            // lvClassNames
            // 
            this.lvClassNames.Size = new System.Drawing.Size(442, 111);
            // 
            // documentControl
            // 
            this.documentControl.Size = new System.Drawing.Size(442, 221);
            // 
            // driverModuleControl
            // 
            this.driverModuleControl.Size = new System.Drawing.Size(456, 93);
            // 
            // driverUnifiedControl
            // 
            this.driverUnifiedControl.Size = new System.Drawing.Size(456, 183);
            // 
            // edtClassName
            // 
            this.edtClassName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtClassName.AttributeName = null;
            this.edtClassName.Location = new System.Drawing.Point(249, 14);
            this.edtClassName.Name = "edtClassName";
            this.edtClassName.Size = new System.Drawing.Size(186, 20);
            this.edtClassName.TabIndex = 12;
            this.edtClassName.Value = null;
            this.edtClassName.ValueType = ATMLCommonLibrary.controls.awb.AWBTextBox.eValueType.xsString;
            // 
            // helpLabel1
            // 
            this.helpLabel1.AutoSize = true;
            this.helpLabel1.HelpMessageKey = null;
            this.helpLabel1.Location = new System.Drawing.Point(173, 16);
            this.helpLabel1.Name = "helpLabel1";
            this.helpLabel1.RequiredField = false;
            this.helpLabel1.RequiredFieldMarkerFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.helpLabel1.Size = new System.Drawing.Size(63, 13);
            this.helpLabel1.TabIndex = 13;
            this.helpLabel1.Text = "Class Name";
            // 
            // IVINETDriverControl
            // 
            this.Controls.Add(this.helpLabel1);
            this.Controls.Add(this.edtClassName);
            this.MinimumSize = new System.Drawing.Size(0, 0);
            this.Name = "IVINETDriverControl";
            this.Size = new System.Drawing.Size(490, 380);
            this.Controls.SetChildIndex(this.cmbDriverType, 0);
            this.Controls.SetChildIndex(this.driverUnifiedControl, 0);
            this.Controls.SetChildIndex(this.driverModuleControl, 0);
            this.Controls.SetChildIndex(this.lblDriverType, 0);
            this.Controls.SetChildIndex(this.edtClassName, 0);
            this.Controls.SetChildIndex(this.helpLabel1, 0);
            this.Controls.SetChildIndex(this.tabControl1, 0);
            this.tabControl1.ResumeLayout(false);
            this.tabClass.ResumeLayout(false);
            this.tabDocument.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private awb.AWBTextBox edtClassName;
        private HelpLabel helpLabel1;
    }
}
