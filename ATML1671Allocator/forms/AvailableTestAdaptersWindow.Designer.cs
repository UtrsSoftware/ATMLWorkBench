/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
* 
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

namespace ATML1671Allocator.forms
{
    partial class AvailableTestAdaptersWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AvailableTestAdaptersWindow));
            this.lvTestAdapters = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // lvTestAdapters
            // 
            this.lvTestAdapters.CheckBoxes = true;
            this.lvTestAdapters.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvTestAdapters.FullRowSelect = true;
            this.lvTestAdapters.Location = new System.Drawing.Point(0, 0);
            this.lvTestAdapters.Name = "lvTestAdapters";
            this.lvTestAdapters.Size = new System.Drawing.Size(262, 265);
            this.lvTestAdapters.TabIndex = 3;
            this.lvTestAdapters.UseCompatibleStateImageBehavior = false;
            this.lvTestAdapters.View = System.Windows.Forms.View.Details;
            // 
            // AvailableTestAdaptersWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(262, 265);
            this.CloseButton = false;
            this.CloseButtonVisible = false;
            this.Controls.Add(this.lvTestAdapters);
            this.DockAreas = ((WeifenLuo.WinFormsUI.Docking.DockAreas)(((((WeifenLuo.WinFormsUI.Docking.DockAreas.Float | WeifenLuo.WinFormsUI.Docking.DockAreas.DockLeft) 
            | WeifenLuo.WinFormsUI.Docking.DockAreas.DockRight) 
            | WeifenLuo.WinFormsUI.Docking.DockAreas.DockTop) 
            | WeifenLuo.WinFormsUI.Docking.DockAreas.DockBottom)));
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AvailableTestAdaptersWindow";
            this.Text = "Adapters";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lvTestAdapters;
    }
}