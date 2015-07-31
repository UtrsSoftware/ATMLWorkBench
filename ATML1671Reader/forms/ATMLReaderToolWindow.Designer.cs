/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
* 
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

using UTRS1671Reader.controls;

namespace ATML1671Reader.forms
{
    partial class ATMLReaderToolWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ATMLReaderToolWindow));
            this.readerFrameControl = new UTRS1671Reader.controls.ReaderFrame();
            this.SuspendLayout();
            // 
            // readerFrameControl
            // 
            this.readerFrameControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.readerFrameControl.Location = new System.Drawing.Point(0, 0);
            this.readerFrameControl.Name = "readerFrameControl";
            this.readerFrameControl.Size = new System.Drawing.Size(829, 444);
            this.readerFrameControl.TabIndex = 0;
            // 
            // ATMLReaderToolWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(829, 444);
            this.Controls.Add(this.readerFrameControl);
            this.DockAreas = WeifenLuo.WinFormsUI.Docking.DockAreas.Document;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HelpButton = true;
            this.HideOnClose = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ATMLReaderToolWindow";
            this.ShowHint = WeifenLuo.WinFormsUI.Docking.DockState.Document;
            this.TabText = "Reader";
            this.Text = "ATMLReaderToolWindow";
            this.Activated += new System.EventHandler(this.ATMLReaderToolWindow_Activated);
            this.Deactivate += new System.EventHandler(this.ATMLReaderToolWindow_Deactivate);
            this.ResumeLayout(false);

        }

        #endregion

        private ReaderFrame readerFrameControl;
    }
}