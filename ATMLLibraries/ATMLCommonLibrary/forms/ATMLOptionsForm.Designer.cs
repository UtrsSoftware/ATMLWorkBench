/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
* 
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

namespace ATMLCommonLibrary.forms
{
    partial class ATMLOptionsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ATMLOptionsForm));
            this.splitPanel = new System.Windows.Forms.Panel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.optionTree = new System.Windows.Forms.TreeView();
            this.optionsImageList = new System.Windows.Forms.ImageList(this.components);
            this.propertyGrid = new System.Windows.Forms.PropertyGrid();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.splitContainer1);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Size = new System.Drawing.Size(622, 322);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(543, 324);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(462, 324);
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click_1);
            // 
            // lblDenoteRequiredField
            // 
            this.lblDenoteRequiredField.Location = new System.Drawing.Point(12, 327);
            this.lblDenoteRequiredField.Visible = false;
            // 
            // splitPanel
            // 
            this.splitPanel.Location = new System.Drawing.Point(0, 0);
            this.splitPanel.Name = "splitPanel";
            this.splitPanel.Size = new System.Drawing.Size(200, 100);
            this.splitPanel.TabIndex = 0;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.optionTree);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.propertyGrid);
            this.splitContainer1.Size = new System.Drawing.Size(622, 322);
            this.splitContainer1.SplitterDistance = 207;
            this.splitContainer1.TabIndex = 0;
            // 
            // optionTree
            // 
            this.optionTree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.optionTree.FullRowSelect = true;
            this.optionTree.HideSelection = false;
            this.optionTree.ImageIndex = 0;
            this.optionTree.ImageList = this.optionsImageList;
            this.optionTree.Location = new System.Drawing.Point(0, 0);
            this.optionTree.Name = "optionTree";
            this.optionTree.SelectedImageIndex = 0;
            this.optionTree.ShowLines = false;
            this.optionTree.Size = new System.Drawing.Size(207, 322);
            this.optionTree.TabIndex = 0;
            this.optionTree.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.optionTree_AfterSelect);
            // 
            // optionsImageList
            // 
            this.optionsImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("optionsImageList.ImageStream")));
            this.optionsImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.optionsImageList.Images.SetKeyName(0, "web_template_editor.png");
            this.optionsImageList.Images.SetKeyName(1, "reading_view.png");
            this.optionsImageList.Images.SetKeyName(2, "selection_pane.png");
            this.optionsImageList.Images.SetKeyName(3, "compile.png");
            this.optionsImageList.Images.SetKeyName(4, "visual_basic.png");
            this.optionsImageList.Images.SetKeyName(5, "database.png");
            this.optionsImageList.Images.SetKeyName(6, "network_ip.png");
            this.optionsImageList.Images.SetKeyName(7, "networking_green.png");
            this.optionsImageList.Images.SetKeyName(8, "raw_access_logs.png");
            // 
            // propertyGrid
            // 
            this.propertyGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.propertyGrid.Location = new System.Drawing.Point(0, 0);
            this.propertyGrid.Name = "propertyGrid";
            this.propertyGrid.PropertySort = System.Windows.Forms.PropertySort.Categorized;
            this.propertyGrid.Size = new System.Drawing.Size(411, 322);
            this.propertyGrid.TabIndex = 0;
            this.propertyGrid.ToolbarVisible = false;
            this.propertyGrid.Click += new System.EventHandler(this.propertyGrid_Click);
            // 
            // ATMLOptionsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(622, 349);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "ATMLOptionsForm";
            this.Text = "ATML Workbench Property Options";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ATMLOptionsForm_FormClosing);
            this.panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel splitPanel;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TreeView optionTree;
        private System.Windows.Forms.ImageList optionsImageList;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.PropertyGrid propertyGrid;
    }
}