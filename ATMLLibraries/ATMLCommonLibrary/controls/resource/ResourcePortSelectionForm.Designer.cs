/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
*
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/
namespace ATMLCommonLibrary.controls.resource
{
    partial class ResourcePortSelectionForm
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
            this.lvResourcePorts = new System.Windows.Forms.ListView();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lvResourcePorts);
            // 
            // lvResourcePorts
            // 
            this.lvResourcePorts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvResourcePorts.FullRowSelect = true;
            this.lvResourcePorts.Location = new System.Drawing.Point(0, 0);
            this.lvResourcePorts.Name = "lvResourcePorts";
            this.lvResourcePorts.Size = new System.Drawing.Size(433, 270);
            this.lvResourcePorts.TabIndex = 0;
            this.lvResourcePorts.UseCompatibleStateImageBehavior = false;
            this.lvResourcePorts.View = System.Windows.Forms.View.Details;
            // 
            // ResourcePortSelectionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(458, 315);
            this.Name = "ResourcePortSelectionForm";
            this.Text = "Resource Port Selection";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lvResourcePorts;
    }
}