/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
* 
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

namespace ATMLCommonLibrary.controls.component
{
    partial class ComponentControl
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
            this.helpLabel1 = new ATMLCommonLibrary.controls.HelpLabel(this.components);
            this.edtId = new ATMLCommonLibrary.controls.awb.AWBTextBox(this.components);
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // rbDefinition
            // 
            this.rbDefinition.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rbDefinition.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbDefinition.Location = new System.Drawing.Point(391, 5);
            this.rbDefinition.Size = new System.Drawing.Size(79, 17);
            // 
            // rbDocumentReference
            // 
            this.rbDocumentReference.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rbDocumentReference.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbDocumentReference.Location = new System.Drawing.Point(240, 5);
            this.rbDocumentReference.Size = new System.Drawing.Size(145, 17);
            // 
            // documentReferenceControl
            // 
            this.documentReferenceControl.Size = new System.Drawing.Size(624, 345);
            // 
            // itemDescriptionControl
            // 
            this.itemDescriptionControl.Size = new System.Drawing.Size(491, 310);
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(0, 28);
            this.panel1.Size = new System.Drawing.Size(491, 310);
            // 
            // helpLabel1
            // 
            this.helpLabel1.AutoSize = true;
            this.helpLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.helpLabel1.ForeColor = System.Drawing.Color.White;
            this.helpLabel1.HelpMessageKey = null;
            this.helpLabel1.Location = new System.Drawing.Point(7, 8);
            this.helpLabel1.Name = "helpLabel1";
            this.helpLabel1.RequiredField = false;
            this.helpLabel1.RequiredFieldMarkerFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.helpLabel1.Size = new System.Drawing.Size(20, 13);
            this.helpLabel1.TabIndex = 9;
            this.helpLabel1.Text = "ID";
            // 
            // edtId
            // 
            this.edtId.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtId.AttributeName = null;
            this.edtId.Location = new System.Drawing.Point(32, 4);
            this.edtId.Name = "edtId";
            this.edtId.Size = new System.Drawing.Size(193, 20);
            this.edtId.TabIndex = 10;
            this.edtId.Value = null;
            this.edtId.ValueType = ATMLCommonLibrary.controls.awb.AWBTextBox.eValueType.xsString;
            // 
            // ComponentControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.edtId);
            this.Controls.Add(this.helpLabel1);
            this.Name = "ComponentControl";
            this.Size = new System.Drawing.Size(491, 338);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.helpLabel1, 0);
            this.Controls.SetChildIndex(this.edtId, 0);
            this.Controls.SetChildIndex(this.rbDocumentReference, 0);
            this.Controls.SetChildIndex(this.rbDefinition, 0);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private HelpLabel helpLabel1;
        private awb.AWBTextBox edtId;
    }
}
