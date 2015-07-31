/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
* 
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

namespace ATML1671Reader.controls
{
    partial class TpsResourceReferenceControl
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
            this.label4 = new System.Windows.Forms.Label();
            this.edtQuantity = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.edtLocation = new ATMLCommonLibrary.controls.awb.AWBTextBox(this.components);
            this.edtType = new ATMLCommonLibrary.controls.awb.AWBTextBox(this.components);
            this.label6 = new System.Windows.Forms.Label();
            this.itemDescriptionControl.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtQuantity)).BeginInit();
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
            this.documentReferenceControl.Size = new System.Drawing.Size(624, 350);
            this.documentReferenceControl.TabIndex = 0;
            // 
            // itemDescriptionControl
            // 
            this.itemDescriptionControl.Size = new System.Drawing.Size(451, 289);
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(0, 50);
            this.panel1.Size = new System.Drawing.Size(451, 289);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(10, 27);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(23, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Qty";
            // 
            // edtQuantity
            // 
            this.edtQuantity.Location = new System.Drawing.Point(36, 25);
            this.edtQuantity.Name = "edtQuantity";
            this.edtQuantity.Size = new System.Drawing.Size(41, 20);
            this.edtQuantity.TabIndex = 3;
            this.edtQuantity.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(93, 27);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Location";
            // 
            // edtLocation
            // 
            this.edtLocation.AttributeName = null;
            this.edtLocation.Location = new System.Drawing.Point(144, 25);
            this.edtLocation.Name = "edtLocation";
            this.edtLocation.Size = new System.Drawing.Size(101, 20);
            this.edtLocation.TabIndex = 5;
            this.edtLocation.Value = null;
            this.edtLocation.ValueType = ATMLCommonLibrary.controls.awb.AWBTextBox.eValueType.xsString;
            // 
            // edtType
            // 
            this.edtType.AttributeName = null;
            this.edtType.Location = new System.Drawing.Point(302, 24);
            this.edtType.Name = "edtType";
            this.edtType.Size = new System.Drawing.Size(118, 20);
            this.edtType.TabIndex = 7;
            this.edtType.Value = null;
            this.edtType.ValueType = ATMLCommonLibrary.controls.awb.AWBTextBox.eValueType.xsString;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(265, 27);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(31, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "Type";
            // 
            // TpsResourceReferenceControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.edtType);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.edtLocation);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.edtQuantity);
            this.Controls.Add(this.label4);
            this.Name = "TpsResourceReferenceControl";
            this.Size = new System.Drawing.Size(451, 339);
            this.Controls.SetChildIndex(this.rbDocumentReference, 0);
            this.Controls.SetChildIndex(this.rbDefinition, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.edtQuantity, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.edtLocation, 0);
            this.Controls.SetChildIndex(this.label6, 0);
            this.Controls.SetChildIndex(this.edtType, 0);
            this.itemDescriptionControl.ResumeLayout(false);
            this.itemDescriptionControl.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.edtQuantity)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown edtQuantity;
        private System.Windows.Forms.Label label5;
        private ATMLCommonLibrary.controls.awb.AWBTextBox edtLocation;
        private ATMLCommonLibrary.controls.awb.AWBTextBox edtType;
        private System.Windows.Forms.Label label6;
    }
}
