/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
*
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/
namespace ATMLCommonLibrary.controls
{
    partial class IndentificationNumbersListControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(IndentificationNumbersListControl));
            //this.btnAdd = new System.Windows.Forms.ToolStripButton();
            //this.btnEdit = new System.Windows.Forms.ToolStripButton();
            //this.btnDelete = new System.Windows.Forms.ToolStripButton();
            this.SuspendLayout();
            // 
            // lvList
            // 
            this.lvList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)));
            this.lvList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvList.Size = new System.Drawing.Size(389, 208);
            // 
            // IndentificationNumbersListControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SteelBlue;
            this.Name = "IndentificationNumbersListControl";
            this.Size = new System.Drawing.Size(413, 208);
            this.ResumeLayout(false);

        }

        #endregion

        //private System.Windows.Forms.ToolStripButton btnAdd;
        //private System.Windows.Forms.ToolStripButton btnEdit;
        //private System.Windows.Forms.ToolStripButton btnDelete;

    }
}
