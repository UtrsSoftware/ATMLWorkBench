/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
* 
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

namespace ATML1671Translator.forms
{
    partial class ATMLTranslatorOutputWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ATMLTranslatorOutputWindow));
            this.btnCompare = new System.Windows.Forms.ToolStripButton();
            this.btnValidate = new System.Windows.Forms.ToolStripButton();
            this.SuspendLayout();
            // 
            // atmlPreviewPanel
            // 
            this.atmlPreviewPanel.Size = new System.Drawing.Size(573, 370);
            // 
            // btnCompare
            // 
            this.btnCompare.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnCompare.Image = ((System.Drawing.Image)(resources.GetObject("btnCompare.Image")));
            this.btnCompare.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCompare.Name = "btnCompare";
            this.btnCompare.Size = new System.Drawing.Size(23, 22);
            this.btnCompare.ToolTipText = "Compare to source code";
            this.btnCompare.Click += new System.EventHandler(this.btnCompare_Click);
            // 
            // btnValidate
            // 
            this.btnValidate.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnValidate.Image = ((System.Drawing.Image)(resources.GetObject("btnValidate.Image")));
            this.btnValidate.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnValidate.Name = "btnValidate";
            this.btnValidate.Size = new System.Drawing.Size(23, 22);
            this.btnValidate.ToolTipText = "Click to validate the Test Description";
            this.btnValidate.Click += new System.EventHandler(this.btnValidate_Click);
            // 
            // ATMLTranslatorOutputWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(573, 395);
            this.CloseButton = false;
            this.CloseButtonVisible = false;
            this.Name = "ATMLTranslatorOutputWindow";
            this.Text = "1671.1 Test Description";
            this.Activated += new System.EventHandler(this.ATMLTranslatorOutputWindow_Activated);
            this.Deactivate += new System.EventHandler(this.ATMLTranslatorOutputWindow_Deactivate);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        //private System.Windows.Forms.ToolStrip toolStrip1;
        //private System.Windows.Forms.ToolStripButton btnSave;
        private System.Windows.Forms.ToolStripButton btnCompare;
        private System.Windows.Forms.ToolStripButton btnValidate;
        //private ATMLCommonLibrary.controls.awb.AWBEditor edtOutputDocument;

    }
}