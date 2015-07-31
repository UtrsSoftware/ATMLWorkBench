/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
*
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/
namespace ATMLCommonLibrary.controls.common
{
    partial class CollectionItemControl
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
            this.label1 = new ATMLCommonLibrary.controls.HelpLabel(this.components);
            this.edtItemName = new ATMLCommonLibrary.controls.awb.AWBTextBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // collectionControl
            // 
            this.collectionControl.Size = new System.Drawing.Size(660, 583);
            // 
            // panel1
            // 
            this.panel1.Size = new System.Drawing.Size(664, 587);
            // 
            // datumTypeControl
            // 
            this.datumTypeControl.Size = new System.Drawing.Size(660, 583);
            // 
            // indexArrayControl
            // 
            this.indexArrayControl.Size = new System.Drawing.Size(660, 583);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.HelpMessageKey = "CollectionItem.ItemName";
            this.label1.Location = new System.Drawing.Point(233, 6);
            this.label1.Name = "label1";
            this.label1.RequiredField = false;
            this.label1.RequiredFieldMarkerFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Item Name";
            // 
            // edtItemName
            // 
            this.edtItemName.Location = new System.Drawing.Point(298, 3);
            this.edtItemName.Name = "edtItemName";
            this.edtItemName.Size = new System.Drawing.Size(186, 20);
            this.edtItemName.TabIndex = 6;
            // 
            // CollectionItemControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.edtItemName);
            this.Controls.Add(this.label1);
            this.MinimumSize = new System.Drawing.Size(518, 463);
            this.Name = "CollectionItemControl";
            this.Size = new System.Drawing.Size(686, 628);
            this.Controls.SetChildIndex(this.helpLabel1, 0);
            this.Controls.SetChildIndex(this.cmbValueType, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.edtItemName, 0);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ATMLCommonLibrary.controls.HelpLabel label1;
        private ATMLCommonLibrary.controls.awb.AWBTextBox edtItemName;
    }
}
