/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
*
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/
namespace ATMLCommonLibrary.controls.collection
{
    partial class CollectionItemForm
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
            this.collectionItemControl = new ATMLCommonLibrary.controls.common.CollectionItemControl();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.collectionItemControl);
            this.panel1.Size = new System.Drawing.Size(594, 498);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(532, 516);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(451, 516);
            // 
            // lblDenoteRequiredField
            // 
            this.lblDenoteRequiredField.Location = new System.Drawing.Point(1, 527);
            // 
            // collectionItemControl
            // 
            this.collectionItemControl.BackColor = System.Drawing.Color.AliceBlue;
            this.collectionItemControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.collectionItemControl.Location = new System.Drawing.Point(0, 0);
            this.collectionItemControl.MinimumSize = new System.Drawing.Size(518, 463);
            this.collectionItemControl.Name = "collectionItemControl";
            this.collectionItemControl.Size = new System.Drawing.Size(594, 498);
            this.collectionItemControl.TabIndex = 0;
            // 
            // CollectionItemForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(619, 543);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "CollectionItemForm";
            this.Text = "Collection Item";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private common.CollectionItemControl collectionItemControl;
    }
}
