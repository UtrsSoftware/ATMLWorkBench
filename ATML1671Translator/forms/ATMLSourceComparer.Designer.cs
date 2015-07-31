/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
* 
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

namespace ATML1671Translator.forms
{
    partial class ATMLSourceComparer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ATMLSourceComparer));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnSave = new System.Windows.Forms.ToolStripButton();
            this.btnClose = new System.Windows.Forms.ToolStripButton();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.sourceCodeToolStrip = new System.Windows.Forms.ToolStrip();
            this.lblSourceFileName = new System.Windows.Forms.ToolStripLabel();
            this.testConfigToolStrip = new System.Windows.Forms.ToolStrip();
            this.lbl1671FileName = new System.Windows.Forms.ToolStripLabel();
            this.sourceEditor = new ATMLCommonLibrary.controls.awb.AWBEditor();
            this.targetEditor = new ATMLCommonLibrary.controls.awb.AWBEditor();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.sourceCodeToolStrip.SuspendLayout();
            this.testConfigToolStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sourceEditor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.targetEditor)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnSave,
            this.btnClose});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(892, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnSave
            // 
            this.btnSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(23, 22);
            this.btnSave.ToolTipText = "Press to save the 1671.1 ATML file.";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(23, 22);
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 25);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.sourceCodeToolStrip);
            this.splitContainer1.Panel1.Controls.Add(this.sourceEditor);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.testConfigToolStrip);
            this.splitContainer1.Panel2.Controls.Add(this.targetEditor);
            this.splitContainer1.Size = new System.Drawing.Size(892, 491);
            this.splitContainer1.SplitterDistance = 424;
            this.splitContainer1.TabIndex = 1;
            // 
            // sourceCodeToolStrip
            // 
            this.sourceCodeToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.sourceCodeToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblSourceFileName});
            this.sourceCodeToolStrip.Location = new System.Drawing.Point(0, 0);
            this.sourceCodeToolStrip.Name = "sourceCodeToolStrip";
            this.sourceCodeToolStrip.Size = new System.Drawing.Size(424, 25);
            this.sourceCodeToolStrip.TabIndex = 1;
            this.sourceCodeToolStrip.Text = "toolStrip2";
            // 
            // lblSourceFileName
            // 
            this.lblSourceFileName.Name = "lblSourceFileName";
            this.lblSourceFileName.Size = new System.Drawing.Size(74, 22);
            this.lblSourceFileName.Text = "Source Code";
            // 
            // testConfigToolStrip
            // 
            this.testConfigToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.testConfigToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lbl1671FileName});
            this.testConfigToolStrip.Location = new System.Drawing.Point(0, 0);
            this.testConfigToolStrip.Name = "testConfigToolStrip";
            this.testConfigToolStrip.Size = new System.Drawing.Size(464, 25);
            this.testConfigToolStrip.TabIndex = 2;
            this.testConfigToolStrip.Text = "toolStrip3";
            // 
            // lbl1671FileName
            // 
            this.lbl1671FileName.Name = "lbl1671FileName";
            this.lbl1671FileName.Size = new System.Drawing.Size(137, 22);
            this.lbl1671FileName.Text = "project_name.1671.1.xml";
            // 
            // sourceEditor
            // 
            this.sourceEditor.AllowDrop = true;
            this.sourceEditor.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.sourceEditor.Location = new System.Drawing.Point(0, 28);
            this.sourceEditor.Name = "sourceEditor";
            this.sourceEditor.Size = new System.Drawing.Size(422, 463);
            this.sourceEditor.TabIndex = 0;
            // 
            // targetEditor
            // 
            this.targetEditor.AllowDrop = true;
            this.targetEditor.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.targetEditor.Location = new System.Drawing.Point(0, 28);
            this.targetEditor.Name = "targetEditor";
            this.targetEditor.Size = new System.Drawing.Size(464, 463);
            this.targetEditor.TabIndex = 1;
            // 
            // ATMLSourceComparer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(892, 516);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.toolStrip1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "ATMLSourceComparer";
            this.Text = "ATML Source Comparer";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.sourceCodeToolStrip.ResumeLayout(false);
            this.sourceCodeToolStrip.PerformLayout();
            this.testConfigToolStrip.ResumeLayout(false);
            this.testConfigToolStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sourceEditor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.targetEditor)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ToolStrip sourceCodeToolStrip;
        private ATMLCommonLibrary.controls.awb.AWBEditor sourceEditor;
        private System.Windows.Forms.ToolStrip testConfigToolStrip;
        private ATMLCommonLibrary.controls.awb.AWBEditor targetEditor;
        private System.Windows.Forms.ToolStripButton btnSave;
        private System.Windows.Forms.ToolStripButton btnClose;
        private System.Windows.Forms.ToolStripLabel lblSourceFileName;
        private System.Windows.Forms.ToolStripLabel lbl1671FileName;
    }
}