/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
*
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/
namespace ATMLCommonLibrary.controls.bus
{
    partial class SupportedClockSourcesControl
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
            this.chkInternal = new System.Windows.Forms.CheckBox();
            this.chkExternal = new System.Windows.Forms.CheckBox();
            this.chkBackplane = new System.Windows.Forms.CheckBox();
            this.gbFrame = new System.Windows.Forms.GroupBox();
            this.lblInternal = new ATMLCommonLibrary.controls.HelpLabel(this.components);
            this.lblExternal = new ATMLCommonLibrary.controls.HelpLabel(this.components);
            this.lblBackplane = new ATMLCommonLibrary.controls.HelpLabel(this.components);
            this.gbFrame.SuspendLayout();
            this.SuspendLayout();
            // 
            // chkInternal
            // 
            this.chkInternal.AutoSize = true;
            this.chkInternal.Location = new System.Drawing.Point(23, 24);
            this.chkInternal.Name = "chkInternal";
            this.chkInternal.Size = new System.Drawing.Size(15, 14);
            this.chkInternal.TabIndex = 0;
            this.chkInternal.UseVisualStyleBackColor = true;
            // 
            // chkExternal
            // 
            this.chkExternal.AutoSize = true;
            this.chkExternal.Location = new System.Drawing.Point(23, 47);
            this.chkExternal.Name = "chkExternal";
            this.chkExternal.Size = new System.Drawing.Size(15, 14);
            this.chkExternal.TabIndex = 1;
            this.chkExternal.UseVisualStyleBackColor = true;
            // 
            // chkBackplane
            // 
            this.chkBackplane.AutoSize = true;
            this.chkBackplane.Location = new System.Drawing.Point(23, 70);
            this.chkBackplane.Name = "chkBackplane";
            this.chkBackplane.Size = new System.Drawing.Size(15, 14);
            this.chkBackplane.TabIndex = 2;
            this.chkBackplane.UseVisualStyleBackColor = true;
            // 
            // gbFrame
            // 
            this.gbFrame.Controls.Add(this.lblBackplane);
            this.gbFrame.Controls.Add(this.lblExternal);
            this.gbFrame.Controls.Add(this.lblInternal);
            this.gbFrame.Controls.Add(this.chkExternal);
            this.gbFrame.Controls.Add(this.chkBackplane);
            this.gbFrame.Controls.Add(this.chkInternal);
            this.gbFrame.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbFrame.Location = new System.Drawing.Point(0, 0);
            this.gbFrame.Name = "gbFrame";
            this.gbFrame.Size = new System.Drawing.Size(164, 98);
            this.gbFrame.TabIndex = 3;
            this.gbFrame.TabStop = false;
            this.gbFrame.Text = "Supported Clock Sources";
            // 
            // lblInternal
            // 
            this.lblInternal.AutoSize = true;
            this.lblInternal.HelpMessageKey = "SupportedClockSources.Internal";
            this.lblInternal.Location = new System.Drawing.Point(44, 25);
            this.lblInternal.Name = "lblInternal";
            this.lblInternal.RequiredField = false;
            this.lblInternal.RequiredFieldMarkerFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInternal.Size = new System.Drawing.Size(42, 13);
            this.lblInternal.TabIndex = 3;
            this.lblInternal.Text = "Internal";
            // 
            // lblExternal
            // 
            this.lblExternal.AutoSize = true;
            this.lblExternal.HelpMessageKey = "SupportedClockSources.External";
            this.lblExternal.Location = new System.Drawing.Point(44, 48);
            this.lblExternal.Name = "lblExternal";
            this.lblExternal.RequiredField = false;
            this.lblExternal.RequiredFieldMarkerFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblExternal.Size = new System.Drawing.Size(45, 13);
            this.lblExternal.TabIndex = 4;
            this.lblExternal.Text = "External";
            // 
            // lblBackplane
            // 
            this.lblBackplane.AutoSize = true;
            this.lblBackplane.HelpMessageKey = "SupportedClockSources.Backplane";
            this.lblBackplane.Location = new System.Drawing.Point(44, 71);
            this.lblBackplane.Name = "lblBackplane";
            this.lblBackplane.RequiredField = false;
            this.lblBackplane.RequiredFieldMarkerFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBackplane.Size = new System.Drawing.Size(58, 13);
            this.lblBackplane.TabIndex = 5;
            this.lblBackplane.Text = "Backplane";
            // 
            // SupportedClockSourcesControl
            // 
            this.Controls.Add(this.gbFrame);
            this.Name = "SupportedClockSourcesControl";
            this.Size = new System.Drawing.Size(164, 98);
            this.gbFrame.ResumeLayout(false);
            this.gbFrame.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckBox chkInternal;
        private System.Windows.Forms.CheckBox chkExternal;
        private System.Windows.Forms.CheckBox chkBackplane;
        private System.Windows.Forms.GroupBox gbFrame;
        private HelpLabel lblBackplane;
        private HelpLabel lblExternal;
        private HelpLabel lblInternal;
    }
}
