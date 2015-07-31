/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
*
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/
namespace ATMLCommonLibrary.controls.capability
{
    partial class CapabilityListControl
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
            this.SuspendLayout();
            // 
            // lvList
            // 
            this.lvList.AllowDrop = true;
            this.lvList.Size = new System.Drawing.Size(323, 147);
            this.lvList.DragDrop += new System.Windows.Forms.DragEventHandler(this.lvList_DragDrop);
            this.lvList.DragEnter += new System.Windows.Forms.DragEventHandler(this.lvList_DragEnter);
            this.lvList.DragOver += new System.Windows.Forms.DragEventHandler(this.lvList_DragOver);
            // 
            // CapabilityListControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "CapabilityListControl";
            this.Size = new System.Drawing.Size(362, 150);
            this.TooltipTextAddButton = "Press to add a new Capability";
            this.TooltipTextDeleteButton = "Press to delete the selected Capability";
            this.TooltipTextEditButton = "Press to edit the selected Capability";
            this.ResumeLayout(false);

        }

        #endregion

    }
}
