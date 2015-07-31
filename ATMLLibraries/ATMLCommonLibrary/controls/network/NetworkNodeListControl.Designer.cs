/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
*
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

using System.Windows.Forms;

namespace ATMLCommonLibrary.controls.network
{
    partial class NetworkNodeListControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NetworkNodeListControl));
            this.btnMapNetwork = new System.Windows.Forms.ToolStripButton();
            this.SuspendLayout();
            // 
            // lvList
            // 
            this.lvList.Size = new System.Drawing.Size(385, 203);
            // 
            // btnMapNetwork
            // 
            this.btnMapNetwork.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnMapNetwork.Image = ((System.Drawing.Image)(resources.GetObject("btnMapNetwork.Image")));
            this.btnMapNetwork.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnMapNetwork.Name = "btnMapNetwork";
            this.btnMapNetwork.Size = new System.Drawing.Size(23, 20);
            this.btnMapNetwork.TextImageRelation = System.Windows.Forms.TextImageRelation.Overlay;
            this.btnMapNetwork.ToolTipText = "Press to select multiple network nodes";
            this.btnMapNetwork.Click += new System.EventHandler(this.btnMapNetwork_Click);
            // 
            // NetworkNodeListControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "NetworkNodeListControl";
            this.Size = new System.Drawing.Size(424, 206);
            this.TooltipTextAddButton = "Press to add a new Network Node";
            this.TooltipTextDeleteButton = "Press to delete the selected Network Node";
            this.TooltipTextEditButton = "Press to edit the selected Network Node";
            this.ResumeLayout(false);

        }

        
        public ToolStripButton btnMapNetwork;
        #endregion
    }
}
