/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
* 
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

namespace ATML1671Allocator.controls
{
    partial class AllocatorFrameControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AllocatorFrameControl));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.lblTestDescriptionTitle = new System.Windows.Forms.ToolStripLabel();
            this.btnFind = new System.Windows.Forms.ToolStripButton();
            this.btnCollapseAll = new System.Windows.Forms.ToolStripButton();
            this.btnExpandAll = new System.Windows.Forms.ToolStripButton();
            this.btnWordWrap = new System.Windows.Forms.ToolStripButton();
            this.edtTestDescription = new ATMLCommonLibrary.controls.ATMLPreviewPanel();
            this.btnAnalyze = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblTestDescriptionTitle,
            this.btnFind,
            this.btnCollapseAll,
            this.btnExpandAll,
            this.btnWordWrap,
            this.btnAnalyze});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1043, 25);
            this.toolStrip1.TabIndex = 5;
            this.toolStrip1.Text = "Test Description";
            // 
            // lblTestDescriptionTitle
            // 
            this.lblTestDescriptionTitle.Name = "lblTestDescriptionTitle";
            this.lblTestDescriptionTitle.Size = new System.Drawing.Size(99, 22);
            this.lblTestDescriptionTitle.Text = "Test Description";
            // 
            // btnFind
            // 
            this.btnFind.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnFind.Image = ((System.Drawing.Image)(resources.GetObject("btnFind.Image")));
            this.btnFind.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(23, 22);
            this.btnFind.Text = "Find";
            this.btnFind.Visible = false;
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // btnCollapseAll
            // 
            this.btnCollapseAll.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnCollapseAll.Image = ((System.Drawing.Image)(resources.GetObject("btnCollapseAll.Image")));
            this.btnCollapseAll.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCollapseAll.Name = "btnCollapseAll";
            this.btnCollapseAll.Size = new System.Drawing.Size(23, 22);
            this.btnCollapseAll.Text = "Collapse All";
            this.btnCollapseAll.Visible = false;
            this.btnCollapseAll.Click += new System.EventHandler(this.btnCollapseAll_Click);
            // 
            // btnExpandAll
            // 
            this.btnExpandAll.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnExpandAll.Image = ((System.Drawing.Image)(resources.GetObject("btnExpandAll.Image")));
            this.btnExpandAll.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnExpandAll.Name = "btnExpandAll";
            this.btnExpandAll.Size = new System.Drawing.Size(23, 22);
            this.btnExpandAll.Text = "Expand All";
            this.btnExpandAll.Visible = false;
            this.btnExpandAll.Click += new System.EventHandler(this.btnExpandAll_Click);
            // 
            // btnWordWrap
            // 
            this.btnWordWrap.BackColor = System.Drawing.Color.Transparent;
            this.btnWordWrap.Checked = true;
            this.btnWordWrap.CheckOnClick = true;
            this.btnWordWrap.CheckState = System.Windows.Forms.CheckState.Checked;
            this.btnWordWrap.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnWordWrap.Image = ((System.Drawing.Image)(resources.GetObject("btnWordWrap.Image")));
            this.btnWordWrap.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnWordWrap.Name = "btnWordWrap";
            this.btnWordWrap.Size = new System.Drawing.Size(23, 22);
            this.btnWordWrap.ToolTipText = "Press to toggle Word Wrapping";
            this.btnWordWrap.Visible = false;
            this.btnWordWrap.Click += new System.EventHandler(this.btnWordWrap_Click);
            // 
            // edtTestDescription
            // 
            this.edtTestDescription.BackColor = System.Drawing.Color.AliceBlue;
            this.edtTestDescription.Dock = System.Windows.Forms.DockStyle.Fill;
            this.edtTestDescription.HasErrors = false;
            this.edtTestDescription.HelpKeyWord = null;
            this.edtTestDescription.LastError = null;
            this.edtTestDescription.Location = new System.Drawing.Point(0, 25);
            this.edtTestDescription.Modified = false;
            this.edtTestDescription.Name = "edtTestDescription";
            this.edtTestDescription.SchemaTypeName = null;
            this.edtTestDescription.Size = new System.Drawing.Size(1043, 543);
            this.edtTestDescription.TabIndex = 6;
            this.edtTestDescription.TargetNamespace = null;
            // 
            // btnAnalyze
            // 
            this.btnAnalyze.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnAnalyze.Image = ((System.Drawing.Image)(resources.GetObject("btnAnalyze.Image")));
            this.btnAnalyze.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAnalyze.Name = "btnAnalyze";
            this.btnAnalyze.Size = new System.Drawing.Size(23, 22);
            this.btnAnalyze.Text = "Perform Analysis";
            this.btnAnalyze.Visible = false;
            this.btnAnalyze.Click += new System.EventHandler(this.btnAnalyze_Click);
            // 
            // AllocatorFrameControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.edtTestDescription);
            this.Controls.Add(this.toolStrip1);
            this.Name = "AllocatorFrameControl";
            this.Size = new System.Drawing.Size(1043, 568);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        //private ATMLCommonLibrary.controls.ATMLPreviewPanel edtTestDescription;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel lblTestDescriptionTitle;
        public System.Windows.Forms.ToolStripButton btnFind;
        public System.Windows.Forms.ToolStripButton btnCollapseAll;
        public System.Windows.Forms.ToolStripButton btnExpandAll;
        public System.Windows.Forms.ToolStripButton btnWordWrap;
        private ATMLCommonLibrary.controls.ATMLPreviewPanel edtTestDescription;
        private System.Windows.Forms.ToolStripButton btnAnalyze;
    }
}
