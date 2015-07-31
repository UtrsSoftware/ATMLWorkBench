/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
* 
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

namespace ATML1671Reader.controls
{
    partial class ItemInstanceControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.panel2 = new System.Windows.Forms.Panel();
            this.edtSerialNumber = new ATMLCommonLibrary.controls.awb.AWBTextBox(this.components);
            this.helpLabel1 = new ATMLCommonLibrary.controls.HelpLabel(this.components);
            this.itemDescriptionControl.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // rbDefinition
            // 
            this.rbDefinition.TabIndex = 1;
            // 
            // rbDocumentReference
            // 
            this.rbDocumentReference.TabIndex = 0;
            // 
            // documentReferenceControl
            // 
            this.documentReferenceControl.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.documentReferenceControl.Size = new System.Drawing.Size(560, 335);
            this.documentReferenceControl.TabIndex = 1;
            // 
            // itemDescriptionControl
            // 
            this.itemDescriptionControl.Size = new System.Drawing.Size(560, 335);
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(0, 64);
            this.panel1.Size = new System.Drawing.Size(560, 335);
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.Color.AliceBlue;
            this.panel2.Controls.Add(this.edtSerialNumber);
            this.panel2.Controls.Add(this.helpLabel1);
            this.panel2.Location = new System.Drawing.Point(0, 27);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(560, 37);
            this.panel2.TabIndex = 0;
            // 
            // edtSerialNumber
            // 
            this.edtSerialNumber.AttributeName = null;
            this.edtSerialNumber.Location = new System.Drawing.Point(113, 9);
            this.edtSerialNumber.Name = "edtSerialNumber";
            this.edtSerialNumber.Size = new System.Drawing.Size(100, 20);
            this.edtSerialNumber.TabIndex = 1;
            this.edtSerialNumber.Value = null;
            this.edtSerialNumber.ValueType = ATMLCommonLibrary.controls.awb.AWBTextBox.eValueType.xsString;
            // 
            // helpLabel1
            // 
            this.helpLabel1.AutoSize = true;
            this.helpLabel1.HelpMessageKey = null;
            this.helpLabel1.Location = new System.Drawing.Point(8, 12);
            this.helpLabel1.Name = "helpLabel1";
            this.helpLabel1.RequiredField = false;
            this.helpLabel1.RequiredFieldMarkerFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.helpLabel1.Size = new System.Drawing.Size(73, 13);
            this.helpLabel1.TabIndex = 0;
            this.helpLabel1.Text = "Serial Number";
            // 
            // ItemInstanceControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel2);
            this.Name = "ItemInstanceControl";
            this.Size = new System.Drawing.Size(560, 400);
            this.Controls.SetChildIndex(this.rbDocumentReference, 0);
            this.Controls.SetChildIndex(this.rbDefinition, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.panel2, 0);
            this.itemDescriptionControl.ResumeLayout(false);
            this.itemDescriptionControl.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected System.Windows.Forms.Panel panel2;
        protected ATMLCommonLibrary.controls.awb.AWBTextBox edtSerialNumber;
        protected ATMLCommonLibrary.controls.HelpLabel helpLabel1;
    }
}
