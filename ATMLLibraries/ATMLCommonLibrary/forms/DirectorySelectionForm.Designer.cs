/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
* 
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

namespace ATMLCommonLibrary.forms
{
    partial class DirectorySelectionForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DirectorySelectionForm));
            this.lbDirectories = new System.Windows.Forms.ListBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lbDirectories);
            this.panel1.Size = new System.Drawing.Size(275, 208);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(213, 226);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(132, 226);
            // 
            // lblDenoteRequiredField
            // 
            this.lblDenoteRequiredField.Location = new System.Drawing.Point(1, 237);
            // 
            // lbDirectories
            // 
            this.lbDirectories.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbDirectories.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDirectories.FormattingEnabled = true;
            this.lbDirectories.ItemHeight = 20;
            this.lbDirectories.Location = new System.Drawing.Point(0, 0);
            this.lbDirectories.Name = "lbDirectories";
            this.lbDirectories.Size = new System.Drawing.Size(275, 208);
            this.lbDirectories.TabIndex = 1;
            this.lbDirectories.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.lbDirectories_DrawItem);
            this.lbDirectories.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lbDirectories_MouseDoubleClick);
            // 
            // DirectorySelectionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(300, 253);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(316, 291);
            this.Name = "DirectorySelectionForm";
            this.Text = "Select Folder";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lbDirectories;
    }
}