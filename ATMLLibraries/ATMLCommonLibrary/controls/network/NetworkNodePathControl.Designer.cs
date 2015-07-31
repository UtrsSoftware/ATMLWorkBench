/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
* 
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

namespace ATMLCommonLibrary.controls.network
{
    partial class NetworkNodePathControl
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
            this.edtPathDocumentId = new ATMLCommonLibrary.controls.awb.AWBTextBox(this.components);
            this.helpLabel1 = new ATMLCommonLibrary.controls.HelpLabel(this.components);
            this.edtPathValue = new ATMLCommonLibrary.controls.awb.AWBTextBox(this.components);
            this.label1 = new ATMLCommonLibrary.controls.HelpLabel(this.components);
            this.SuspendLayout();
            // 
            // edtPathDocumentId
            // 
            this.edtPathDocumentId.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtPathDocumentId.AttributeName = null;
            this.edtPathDocumentId.Location = new System.Drawing.Point(73, 3);
            this.edtPathDocumentId.Name = "edtPathDocumentId";
            this.edtPathDocumentId.Size = new System.Drawing.Size(435, 20);
            this.edtPathDocumentId.TabIndex = 9;
            this.edtPathDocumentId.Value = null;
            this.edtPathDocumentId.ValueType = ATMLCommonLibrary.controls.awb.AWBTextBox.eValueType.xsString;
            // 
            // helpLabel1
            // 
            this.helpLabel1.AutoSize = true;
            this.helpLabel1.HelpMessageKey = "NetworkNodeControl.Path";
            this.helpLabel1.Location = new System.Drawing.Point(21, 3);
            this.helpLabel1.Name = "helpLabel1";
            this.helpLabel1.RequiredField = false;
            this.helpLabel1.RequiredFieldMarkerFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.helpLabel1.Size = new System.Drawing.Size(46, 13);
            this.helpLabel1.TabIndex = 8;
            this.helpLabel1.Text = "Path ID:";
            // 
            // edtPathValue
            // 
            this.edtPathValue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtPathValue.AttributeName = null;
            this.edtPathValue.Location = new System.Drawing.Point(73, 28);
            this.edtPathValue.Multiline = true;
            this.edtPathValue.Name = "edtPathValue";
            this.edtPathValue.Size = new System.Drawing.Size(435, 62);
            this.edtPathValue.TabIndex = 7;
            this.edtPathValue.Value = null;
            this.edtPathValue.ValueType = ATMLCommonLibrary.controls.awb.AWBTextBox.eValueType.xsString;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.HelpMessageKey = "NetworkNodeControl.UUID";
            this.label1.Location = new System.Drawing.Point(5, 30);
            this.label1.Name = "label1";
            this.label1.RequiredField = false;
            this.label1.RequiredFieldMarkerFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Path Value:";
            // 
            // NetworkNodePathControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.edtPathDocumentId);
            this.Controls.Add(this.helpLabel1);
            this.Controls.Add(this.edtPathValue);
            this.Controls.Add(this.label1);
            this.Name = "NetworkNodePathControl";
            this.Size = new System.Drawing.Size(531, 93);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected awb.AWBTextBox edtPathDocumentId;
        protected HelpLabel helpLabel1;
        protected awb.AWBTextBox edtPathValue;
        protected HelpLabel label1;
    }
}
