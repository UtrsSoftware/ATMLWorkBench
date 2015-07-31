/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
* 
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

namespace ATML1671Allocator.forms
{
    partial class ATMLAllocatorToolWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ATMLAllocatorToolWindow));
            this.allocatorFrameControl = new ATML1671Allocator.controls.AllocatorFrameControl();
            this.SuspendLayout();
            // 
            // allocatorFrameControl
            // 
            this.allocatorFrameControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.allocatorFrameControl.Location = new System.Drawing.Point(0, 0);
            this.allocatorFrameControl.Name = "allocatorFrameControl";
            this.allocatorFrameControl.Size = new System.Drawing.Size(771, 355);
            this.allocatorFrameControl.TabIndex = 0;
            this.allocatorFrameControl.Load += new System.EventHandler(this.allocatorFrameControl_Load);
            // 
            // ATMLAllocatorToolWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(771, 355);
            this.Controls.Add(this.allocatorFrameControl);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HideOnClose = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ATMLAllocatorToolWindow";
            this.Text = "Allocator";
            this.Activated += new System.EventHandler(this.ATMLAllocatorToolWindow_Activated);
            this.Deactivate += new System.EventHandler(this.ATMLAllocatorToolWindow_Deactivate);
            this.ResumeLayout(false);

        }

        #endregion

        private controls.AllocatorFrameControl allocatorFrameControl;
    }
}