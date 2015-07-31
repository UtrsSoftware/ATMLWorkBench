/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
*
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/
namespace ATMLCommonLibrary.controls.environmental
{
    partial class EnvironmentalRequirementsControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.storageElements = new ATMLCommonLibrary.controls.environmental.EnvironmentalElementsControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.operationElements = new ATMLCommonLibrary.controls.environmental.EnvironmentalElementsControl();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(384, 206);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.storageElements);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(376, 180);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Storage Transport";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // storageElements
            // 
            this.storageElements.Dock = System.Windows.Forms.DockStyle.Fill;
            this.storageElements.Location = new System.Drawing.Point(3, 3);
            this.storageElements.Name = "storageElements";
            this.storageElements.SchemaTypeName = null;
            this.storageElements.Size = new System.Drawing.Size(370, 174);
            this.storageElements.TabIndex = 0;
            this.storageElements.TargetNamespace = null;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.operationElements);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(376, 180);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Operation";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // operationElements
            // 
            this.operationElements.Dock = System.Windows.Forms.DockStyle.Fill;
            this.operationElements.Location = new System.Drawing.Point(3, 3);
            this.operationElements.Name = "operationElements";
            this.operationElements.SchemaTypeName = null;
            this.operationElements.Size = new System.Drawing.Size(370, 174);
            this.operationElements.TabIndex = 0;
            this.operationElements.TargetNamespace = null;
            // 
            // EnvironmentalRequirementsControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControl1);
            this.Name = "EnvironmentalRequirementsControl";
            this.Size = new System.Drawing.Size(384, 206);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private EnvironmentalElementsControl storageElements;
        private EnvironmentalElementsControl operationElements;
       
    }
}
