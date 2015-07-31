/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
* 
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

namespace ATML1671Allocator.forms
{
    partial class RequiredSignalsWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RequiredSignalsWindow));
            this.lvSignals = new ATMLCommonLibrary.controls.awb.AWBListView();
            this.SuspendLayout();
            // 
            // lvSignals
            // 
            this.lvSignals.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvSignals.Location = new System.Drawing.Point(0, 0);
            this.lvSignals.Name = "lvSignals";
            this.lvSignals.Size = new System.Drawing.Size(284, 262);
            this.lvSignals.TabIndex = 0;
            this.lvSignals.UseCompatibleStateImageBehavior = false;
            this.lvSignals.View = System.Windows.Forms.View.Details;
            this.lvSignals.SelectedIndexChanged += new System.EventHandler(this.lvSignals_SelectedIndexChanged);
            // 
            // RequiredSignalsWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.CloseButton = false;
            this.CloseButtonVisible = false;
            this.Controls.Add(this.lvSignals);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "RequiredSignalsWindow";
            this.Text = "Required Signals";
            this.ResumeLayout(false);

        }

        #endregion

        private ATMLCommonLibrary.controls.awb.AWBListView lvSignals;
    }
}