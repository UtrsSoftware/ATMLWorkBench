/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
* 
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

using ATML1671Reader.forms;

namespace UTRS1671Reader.controls
{
    partial class ReaderFrame
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
            if( disposing && ( components != null ) )
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReaderFrame));
            this.inputDocumentPreviewPanel = new ATMLCommonLibrary.controls.ATMLPreviewPanel();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.lblInputDocument = new System.Windows.Forms.ToolStripLabel();
            this.btnOpenInputDocument = new System.Windows.Forms.ToolStripButton();
            this.btnParseInputDocument = new System.Windows.Forms.ToolStripButton();
            this.btnNavBack = new System.Windows.Forms.ToolStripButton();
            this.btnNavForward = new System.Windows.Forms.ToolStripButton();
            this.toolStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // inputDocumentPreviewPanel
            // 
            this.inputDocumentPreviewPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.inputDocumentPreviewPanel.Location = new System.Drawing.Point(0, 25);
            this.inputDocumentPreviewPanel.Margin = new System.Windows.Forms.Padding(0);
            this.inputDocumentPreviewPanel.Name = "inputDocumentPreviewPanel";
            this.inputDocumentPreviewPanel.SchemaTypeName = null;
            this.inputDocumentPreviewPanel.Size = new System.Drawing.Size(948, 567);
            this.inputDocumentPreviewPanel.TabIndex = 4;
            this.inputDocumentPreviewPanel.TargetNamespace = null;
            // 
            // toolStrip2
            // 
            this.toolStrip2.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblInputDocument,
            this.btnOpenInputDocument,
            this.btnParseInputDocument,
            this.btnNavBack,
            this.btnNavForward});
            this.toolStrip2.Location = new System.Drawing.Point(0, 0);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(948, 25);
            this.toolStrip2.TabIndex = 3;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // lblInputDocument
            // 
            this.lblInputDocument.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblInputDocument.Name = "lblInputDocument";
            this.lblInputDocument.Size = new System.Drawing.Size(99, 22);
            this.lblInputDocument.Text = "Input Document";
            // 
            // btnOpenInputDocument
            // 
            this.btnOpenInputDocument.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnOpenInputDocument.Image = ((System.Drawing.Image)(resources.GetObject("btnOpenInputDocument.Image")));
            this.btnOpenInputDocument.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnOpenInputDocument.Name = "btnOpenInputDocument";
            this.btnOpenInputDocument.Size = new System.Drawing.Size(23, 22);
            this.btnOpenInputDocument.ToolTipText = "Open Input File";
            this.btnOpenInputDocument.Click += new System.EventHandler(this.btnOpenInputDocument_Click);
            // 
            // btnParseInputDocument
            // 
            this.btnParseInputDocument.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnParseInputDocument.Image = ((System.Drawing.Image)(resources.GetObject("btnParseInputDocument.Image")));
            this.btnParseInputDocument.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnParseInputDocument.Name = "btnParseInputDocument";
            this.btnParseInputDocument.Size = new System.Drawing.Size(23, 22);
            this.btnParseInputDocument.ToolTipText = "Parse Input Document";
            this.btnParseInputDocument.Visible = false;
            this.btnParseInputDocument.Click += new System.EventHandler(this.btnParseInputDocument_Click);
            // 
            // btnNavBack
            // 
            this.btnNavBack.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnNavBack.Image = ((System.Drawing.Image)(resources.GetObject("btnNavBack.Image")));
            this.btnNavBack.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnNavBack.Name = "btnNavBack";
            this.btnNavBack.Size = new System.Drawing.Size(23, 22);
            this.btnNavBack.Text = "Navigate Back";
            this.btnNavBack.Visible = false;
            this.btnNavBack.Click += new System.EventHandler(this.btnNavBack_Click);
            // 
            // btnNavForward
            // 
            this.btnNavForward.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnNavForward.Image = ((System.Drawing.Image)(resources.GetObject("btnNavForward.Image")));
            this.btnNavForward.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnNavForward.Name = "btnNavForward";
            this.btnNavForward.Size = new System.Drawing.Size(23, 22);
            this.btnNavForward.Text = "Navigate Forward";
            this.btnNavForward.Visible = false;
            this.btnNavForward.Click += new System.EventHandler(this.btnNavForward_Click);
            // 
            // ReaderFrame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.inputDocumentPreviewPanel);
            this.Controls.Add(this.toolStrip2);
            this.Name = "ReaderFrame";
            this.Size = new System.Drawing.Size(948, 592);
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ATMLCommonLibrary.controls.ATMLPreviewPanel inputDocumentPreviewPanel;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripLabel lblInputDocument;
        private System.Windows.Forms.ToolStripButton btnOpenInputDocument;
        private System.Windows.Forms.ToolStripButton btnParseInputDocument;
        private System.Windows.Forms.ToolStripButton btnNavBack;
        private System.Windows.Forms.ToolStripButton btnNavForward;


    }
}