/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
*
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/
namespace ATMLCommonLibrary.controls.limit
{
    partial class SingleLimitSimpleControl
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
            this.simpleLimitControl = new ATMLCommonLibrary.controls.limit.SimpleLimitControl();
            this.lblLimitString = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // simpleLimitControl
            // 
            this.simpleLimitControl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.simpleLimitControl.LimitName = "Limit";
            this.simpleLimitControl.Location = new System.Drawing.Point(0, 3);
            this.simpleLimitControl.Name = "simpleLimitControl";
            this.simpleLimitControl.SchemaTypeName = null;
            this.simpleLimitControl.ShowTitle = true;
            this.simpleLimitControl.Size = new System.Drawing.Size(452, 43);
            this.simpleLimitControl.TabIndex = 0;
            this.simpleLimitControl.TargetNamespace = null;
            // 
            // lblLimitString
            // 
            this.lblLimitString.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblLimitString.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLimitString.Location = new System.Drawing.Point(15, 53);
            this.lblLimitString.Name = "lblLimitString";
            this.lblLimitString.Size = new System.Drawing.Size(424, 105);
            this.lblLimitString.TabIndex = 1;
            // 
            // SingleLimitSimpleControl
            // 
            this.Controls.Add(this.lblLimitString);
            this.Controls.Add(this.simpleLimitControl);
            this.MinimumSize = new System.Drawing.Size(455, 175);
            this.Name = "SingleLimitSimpleControl";
            this.Size = new System.Drawing.Size(455, 175);
            this.ResumeLayout(false);

        }

        #endregion

        private SimpleLimitControl simpleLimitControl;
        private System.Windows.Forms.Label lblLimitString;
    }
}
