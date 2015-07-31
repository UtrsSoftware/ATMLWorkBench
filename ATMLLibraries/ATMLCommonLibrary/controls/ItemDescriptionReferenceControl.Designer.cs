/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
* 
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

using ATMLCommonLibrary.controls.document;

namespace ATMLCommonLibrary.controls
{
    partial class ItemDescriptionReferenceControl
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
            this.rbDefinition = new System.Windows.Forms.RadioButton();
            this.rbDocumentReference = new System.Windows.Forms.RadioButton();
            this.documentReferenceControl = new ATMLCommonLibrary.controls.document.DocumentReferenceControl();
            this.itemDescriptionControl = new ATMLCommonLibrary.controls.ItemDescriptionControl();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // rbDefinition
            // 
            this.rbDefinition.AutoSize = true;
            this.rbDefinition.ForeColor = System.Drawing.Color.White;
            this.rbDefinition.Location = new System.Drawing.Point(144, 4);
            this.rbDefinition.Name = "rbDefinition";
            this.rbDefinition.Size = new System.Drawing.Size(69, 17);
            this.rbDefinition.TabIndex = 6;
            this.rbDefinition.TabStop = true;
            this.rbDefinition.Text = "Definition";
            this.rbDefinition.UseVisualStyleBackColor = true;
            // 
            // rbDocumentReference
            // 
            this.rbDocumentReference.AutoSize = true;
            this.rbDocumentReference.ForeColor = System.Drawing.Color.White;
            this.rbDocumentReference.Location = new System.Drawing.Point(11, 4);
            this.rbDocumentReference.Name = "rbDocumentReference";
            this.rbDocumentReference.Size = new System.Drawing.Size(127, 17);
            this.rbDocumentReference.TabIndex = 5;
            this.rbDocumentReference.TabStop = true;
            this.rbDocumentReference.Text = "Document Reference";
            this.rbDocumentReference.UseVisualStyleBackColor = true;
            // 
            // documentReferenceControl
            // 
            this.documentReferenceControl.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.documentReferenceControl.BackColor = System.Drawing.Color.AliceBlue;
            this.documentReferenceControl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.documentReferenceControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.documentReferenceControl.DocumentType = ATMLDataAccessLibrary.model.dbDocument.DocumentType.NONE;
            this.documentReferenceControl.Location = new System.Drawing.Point(0, 0);
            this.documentReferenceControl.Name = "documentReferenceControl";
            this.documentReferenceControl.Size = new System.Drawing.Size(451, 300);
            this.documentReferenceControl.TabIndex = 4;
            // 
            // itemDescriptionControl
            // 
            this.itemDescriptionControl.BackColor = System.Drawing.Color.AliceBlue;
            this.itemDescriptionControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.itemDescriptionControl.Location = new System.Drawing.Point(0, 0);
            this.itemDescriptionControl.Name = "itemDescriptionControl";
            this.itemDescriptionControl.Size = new System.Drawing.Size(451, 300);
            this.itemDescriptionControl.TabIndex = 7;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.documentReferenceControl);
            this.panel1.Controls.Add(this.itemDescriptionControl);
            this.panel1.Location = new System.Drawing.Point(0, 27);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(451, 300);
            this.panel1.TabIndex = 8;
            // 
            // ItemDescriptionReferenceControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSlateGray;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.rbDefinition);
            this.Controls.Add(this.rbDocumentReference);
            this.Name = "ItemDescriptionReferenceControl";
            this.Size = new System.Drawing.Size(451, 327);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected System.Windows.Forms.RadioButton rbDefinition;
        protected System.Windows.Forms.RadioButton rbDocumentReference;
        protected DocumentReferenceControl documentReferenceControl;
        protected ItemDescriptionControl itemDescriptionControl;
        protected System.Windows.Forms.Panel panel1;
    }
}
