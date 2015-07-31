/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
* 
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

namespace ATMLCommonLibrary.forms
{
    partial class ItemDescriptionForm
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
            this.itemDescriptionControl1 = new ATMLCommonLibrary.controls.ItemDescriptionControl();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.itemDescriptionControl1);
            this.panel1.Size = new System.Drawing.Size(682, 377);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(620, 395);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(539, 395);
            // 
            // lblDenoteRequiredField
            // 
            this.lblDenoteRequiredField.Location = new System.Drawing.Point(1, 406);
            // 
            // itemDescriptionControl1
            // 
            this.itemDescriptionControl1.BackColor = System.Drawing.Color.AliceBlue;
            this.itemDescriptionControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.itemDescriptionControl1.Location = new System.Drawing.Point(0, 0);
            this.itemDescriptionControl1.Name = "itemDescriptionControl1";
            this.itemDescriptionControl1.Size = new System.Drawing.Size(682, 377);
            this.itemDescriptionControl1.TabIndex = 0;
            // 
            // ItemDescriptionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(707, 422);
            this.Name = "ItemDescriptionForm";
            this.Text = "Item Description";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private controls.ItemDescriptionControl itemDescriptionControl1;
    }
}
