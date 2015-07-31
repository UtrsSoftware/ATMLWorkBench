/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
*
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/
namespace ATMLCommonLibrary.forms
{
    partial class PortSelectionForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PortSelectionForm));
            this.lvResourcePorts = new System.Windows.Forms.ListView();
            this.tabVontrol = new System.Windows.Forms.TabControl();
            this.tabResourcePorts = new System.Windows.Forms.TabPage();
            this.tabPhysicalPorts = new System.Windows.Forms.TabPage();
            this.lvPhysicalPorts = new System.Windows.Forms.ListView();
            this.panel1.SuspendLayout();
            this.tabVontrol.SuspendLayout();
            this.tabResourcePorts.SuspendLayout();
            this.tabPhysicalPorts.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tabVontrol);
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // lvResourcePorts
            // 
            this.lvResourcePorts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvResourcePorts.FullRowSelect = true;
            this.lvResourcePorts.Location = new System.Drawing.Point(3, 3);
            this.lvResourcePorts.Name = "lvResourcePorts";
            this.lvResourcePorts.Size = new System.Drawing.Size(419, 238);
            this.lvResourcePorts.TabIndex = 0;
            this.lvResourcePorts.UseCompatibleStateImageBehavior = false;
            this.lvResourcePorts.View = System.Windows.Forms.View.Details;
            // 
            // tabVontrol
            // 
            this.tabVontrol.Controls.Add(this.tabResourcePorts);
            this.tabVontrol.Controls.Add(this.tabPhysicalPorts);
            this.tabVontrol.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabVontrol.Location = new System.Drawing.Point(0, 0);
            this.tabVontrol.Name = "tabVontrol";
            this.tabVontrol.SelectedIndex = 0;
            this.tabVontrol.Size = new System.Drawing.Size(433, 270);
            this.tabVontrol.TabIndex = 1;
            // 
            // tabResourcePorts
            // 
            this.tabResourcePorts.Controls.Add(this.lvResourcePorts);
            this.tabResourcePorts.Location = new System.Drawing.Point(4, 22);
            this.tabResourcePorts.Name = "tabResourcePorts";
            this.tabResourcePorts.Padding = new System.Windows.Forms.Padding(3);
            this.tabResourcePorts.Size = new System.Drawing.Size(425, 244);
            this.tabResourcePorts.TabIndex = 0;
            this.tabResourcePorts.Text = "Resource Ports";
            this.tabResourcePorts.UseVisualStyleBackColor = true;
            // 
            // tabPhysicalPorts
            // 
            this.tabPhysicalPorts.Controls.Add(this.lvPhysicalPorts);
            this.tabPhysicalPorts.Location = new System.Drawing.Point(4, 22);
            this.tabPhysicalPorts.Name = "tabPhysicalPorts";
            this.tabPhysicalPorts.Padding = new System.Windows.Forms.Padding(3);
            this.tabPhysicalPorts.Size = new System.Drawing.Size(425, 244);
            this.tabPhysicalPorts.TabIndex = 1;
            this.tabPhysicalPorts.Text = "Physical Ports";
            this.tabPhysicalPorts.UseVisualStyleBackColor = true;
            // 
            // lvPhysicalPorts
            // 
            this.lvPhysicalPorts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvPhysicalPorts.FullRowSelect = true;
            this.lvPhysicalPorts.Location = new System.Drawing.Point(3, 3);
            this.lvPhysicalPorts.Name = "lvPhysicalPorts";
            this.lvPhysicalPorts.Size = new System.Drawing.Size(419, 238);
            this.lvPhysicalPorts.TabIndex = 1;
            this.lvPhysicalPorts.UseCompatibleStateImageBehavior = false;
            this.lvPhysicalPorts.View = System.Windows.Forms.View.Details;
            // 
            // PortSelectionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(458, 315);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "PortSelectionForm";
            this.Text = "Port Selection";
            this.panel1.ResumeLayout(false);
            this.tabVontrol.ResumeLayout(false);
            this.tabResourcePorts.ResumeLayout(false);
            this.tabPhysicalPorts.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lvResourcePorts;
        private System.Windows.Forms.TabControl tabVontrol;
        private System.Windows.Forms.TabPage tabResourcePorts;
        private System.Windows.Forms.TabPage tabPhysicalPorts;
        private System.Windows.Forms.ListView lvPhysicalPorts;
    }
}