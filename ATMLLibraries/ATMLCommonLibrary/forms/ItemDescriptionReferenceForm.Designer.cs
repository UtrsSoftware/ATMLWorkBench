/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
* 
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

using ATMLCommonLibrary.controls.document;

namespace ATMLCommonLibrary.forms
{
    partial class ItemDescriptionReferenceForm
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
            this.btnEditDocumentObject = new System.Windows.Forms.Button();
            this.itemDescriptionReferenceControl1 = new ATMLCommonLibrary.controls.ItemDescriptionReferenceControl();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightSlateGray;
            this.panel1.Controls.Add(this.itemDescriptionReferenceControl1);
            this.panel1.Size = new System.Drawing.Size(671, 377);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(609, 395);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(528, 395);
            // 
            // lblDenoteRequiredField
            // 
            this.lblDenoteRequiredField.Location = new System.Drawing.Point(1, 406);
            // 
            // btnEditDocumentObject
            // 
            this.btnEditDocumentObject.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEditDocumentObject.Location = new System.Drawing.Point(447, 395);
            this.btnEditDocumentObject.Name = "btnEditDocumentObject";
            this.btnEditDocumentObject.Size = new System.Drawing.Size(75, 23);
            this.btnEditDocumentObject.TabIndex = 7;
            this.btnEditDocumentObject.Text = "Edit";
            this.btnEditDocumentObject.UseVisualStyleBackColor = true;
            this.btnEditDocumentObject.Click += new System.EventHandler(this.btnEditDocumentObject_Click);
            // 
            // itemDescriptionReferenceControl1
            // 
            this.itemDescriptionReferenceControl1.BackColor = System.Drawing.Color.LightSlateGray;
            this.itemDescriptionReferenceControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.itemDescriptionReferenceControl1.Location = new System.Drawing.Point(0, 0);
            this.itemDescriptionReferenceControl1.Name = "itemDescriptionReferenceControl1";
            this.itemDescriptionReferenceControl1.SchemaTypeName = null;
            this.itemDescriptionReferenceControl1.Size = new System.Drawing.Size(671, 377);
            this.itemDescriptionReferenceControl1.TabIndex = 0;
            this.itemDescriptionReferenceControl1.TargetNamespace = null;
            // 
            // ItemDescriptionReferenceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(696, 422);
            this.Controls.Add(this.btnEditDocumentObject);
            this.Name = "ItemDescriptionReferenceForm";
            this.Text = "Item Description Reference";
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.btnOk, 0);
            this.Controls.SetChildIndex(this.btnCancel, 0);
            this.Controls.SetChildIndex(this.lblDenoteRequiredField, 0);
            this.Controls.SetChildIndex(this.btnEditDocumentObject, 0);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnEditDocumentObject;
        private controls.ItemDescriptionReferenceControl itemDescriptionReferenceControl1;
    }
}