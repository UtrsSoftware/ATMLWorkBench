/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
*
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/
using ATMLCommonLibrary.controls.collection;

namespace ATMLCommonLibrary.forms
{
    partial class CollectionForm
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
            this.collectionControl1 = new CollectionControl();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.collectionControl1);
            this.panel1.Size = new System.Drawing.Size(578, 484);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(516, 504);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(435, 504);
            // 
            // lblDenoteRequiredField
            // 
            this.lblDenoteRequiredField.Location = new System.Drawing.Point(0, 520);
            // 
            // collectionControl1
            // 
            this.collectionControl1.BackColor = System.Drawing.Color.Transparent;
            this.collectionControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.collectionControl1.Location = new System.Drawing.Point(0, 0);
            this.collectionControl1.Name = "collectionControl1";
            this.collectionControl1.SchemaTypeName = null;
            this.collectionControl1.Size = new System.Drawing.Size(578, 484);
            this.collectionControl1.TabIndex = 0;
            this.collectionControl1.TargetNamespace = null;
            // 
            // CollectionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(603, 539);
            this.Name = "CollectionForm";
            this.Text = "CollectionForm";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CollectionControl collectionControl1;
    }
}