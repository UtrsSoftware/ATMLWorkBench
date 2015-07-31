/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
* 
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

namespace ATMLCommonLibrary.forms
{
    partial class ATMLNavigationWindow
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ATMLNavigationWindow));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnRefresh = new System.Windows.Forms.ToolStripButton();
            this.testSetNavigationTree = new System.Windows.Forms.TreeView();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.toolStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnRefresh});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(241, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnRefresh
            // 
            this.btnRefresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnRefresh.Image = ((System.Drawing.Image)(resources.GetObject("btnRefresh.Image")));
            this.btnRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(23, 22);
            this.btnRefresh.Text = "Refresh Navigation Tree";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // testSetNavigationTree
            // 
            this.testSetNavigationTree.AllowDrop = true;
            this.testSetNavigationTree.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.testSetNavigationTree.FullRowSelect = true;
            this.testSetNavigationTree.HideSelection = false;
            this.testSetNavigationTree.ImageIndex = 0;
            this.testSetNavigationTree.ImageList = this.imageList;
            this.testSetNavigationTree.LabelEdit = true;
            this.testSetNavigationTree.Location = new System.Drawing.Point(0, 26);
            this.testSetNavigationTree.Name = "testSetNavigationTree";
            this.testSetNavigationTree.SelectedImageIndex = 0;
            this.testSetNavigationTree.Size = new System.Drawing.Size(241, 201);
            this.testSetNavigationTree.TabIndex = 1;
            this.testSetNavigationTree.BeforeLabelEdit += new System.Windows.Forms.NodeLabelEditEventHandler(this.testSetNavigationTree_BeforeLabelEdit);
            this.testSetNavigationTree.AfterLabelEdit += new System.Windows.Forms.NodeLabelEditEventHandler(this.testSetNavigationTree_AfterLabelEdit);
            this.testSetNavigationTree.AfterCollapse += new System.Windows.Forms.TreeViewEventHandler(this.testSetNavigationTree_AfterCollapse);
            this.testSetNavigationTree.AfterExpand += new System.Windows.Forms.TreeViewEventHandler(this.testSetNavigationTree_AfterExpand);
            this.testSetNavigationTree.AfterSelect += testSetNavigationTree_AfterSelect;
            this.testSetNavigationTree.BeforeSelect += testSetNavigationTree_BeforeSelect;
            this.testSetNavigationTree.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.testSetNavigationTree_ItemDrag);
            this.testSetNavigationTree.DragDrop += new System.Windows.Forms.DragEventHandler(this.testSetNavigationTree_DragDrop);
            this.testSetNavigationTree.DragEnter += new System.Windows.Forms.DragEventHandler(this.testSetNavigationTree_DragEnter);
            this.testSetNavigationTree.DragOver += new System.Windows.Forms.DragEventHandler(this.testSetNavigationTree_DragOver);
            this.testSetNavigationTree.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.testSetNavigationTree_MouseDoubleClick);
            this.testSetNavigationTree.MouseUp += new System.Windows.Forms.MouseEventHandler(this.testSetNavigationTree_MouseUp);
            // 
            // imageList
            // 
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList.Images.SetKeyName(0, "folder-horizontal.png");
            this.imageList.Images.SetKeyName(1, "folder-horizontal-open.png");
            this.imageList.Images.SetKeyName(2, "source_code.png");
            this.imageList.Images.SetKeyName(3, "readernaut.png");
            this.imageList.Images.SetKeyName(4, "XmlFile16.gif");
            this.imageList.Images.SetKeyName(5, "document_image_ver.png");
            this.imageList.Images.SetKeyName(6, "file_extension_pdf.png");
            this.imageList.Images.SetKeyName(7, "page_word.png");
            this.imageList.Images.SetKeyName(8, "page_excel.png");
            this.imageList.Images.SetKeyName(9, "page_white_text.png");
            this.imageList.Images.SetKeyName(10, "page_white_powerpoint.png");
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.toolStrip1);
            this.panel1.Controls.Add(this.testSetNavigationTree);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(241, 227);
            this.panel1.TabIndex = 0;
            // 
            // ATMLNavigationWindow
            // 
            this.ClientSize = new System.Drawing.Size(241, 227);
            this.CloseButton = false;
            this.CloseButtonVisible = false;
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HelpButton = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ATMLNavigationWindow";
            this.Text = "Project Navigator";
            this.HelpButtonClicked += new System.ComponentModel.CancelEventHandler(this.ATMLNavigationWindow_HelpButtonClicked);
            this.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.ATMLNavigationWindow_HelpRequested);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView testSetNavigationTree;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStripButton btnRefresh;
        private System.Windows.Forms.ImageList imageList;
    }
}
