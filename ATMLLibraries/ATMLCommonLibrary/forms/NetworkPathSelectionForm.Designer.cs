/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
* 
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

namespace ATMLCommonLibrary.forms
{
    partial class NetworkPathSelectionForm
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
            this.lvNetworkPaths = new System.Windows.Forms.ListView();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lvNetworkPaths);
            // 
            // lvNetworkPaths
            // 
            this.lvNetworkPaths.CheckBoxes = true;
            this.lvNetworkPaths.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvNetworkPaths.Location = new System.Drawing.Point(0, 0);
            this.lvNetworkPaths.Name = "lvNetworkPaths";
            this.lvNetworkPaths.Size = new System.Drawing.Size(433, 270);
            this.lvNetworkPaths.TabIndex = 0;
            this.lvNetworkPaths.UseCompatibleStateImageBehavior = false;
            this.lvNetworkPaths.View = System.Windows.Forms.View.Details;
            // 
            // NetworkPathSelectionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(458, 315);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "NetworkPathSelectionForm";
            this.Text = "Network Path Selection";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lvNetworkPaths;
    }
}