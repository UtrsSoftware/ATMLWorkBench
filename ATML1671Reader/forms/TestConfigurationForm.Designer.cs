/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
* 
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

using ATML1671Reader.controls;

namespace ATML1671Reader.forms
{
    partial class TestConfigurationForm
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
            this.testConfigurationControl1 = new ATML1671Reader.controls.TestConfigurationControl();
            this.SuspendLayout();
            // 
            // testConfigurationControl1
            // 
            this.testConfigurationControl1.AutoScroll = true;
            this.testConfigurationControl1.AutoScrollMargin = new System.Drawing.Size(10, 10);
            this.testConfigurationControl1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.testConfigurationControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.testConfigurationControl1.HasErrors = false;
            this.testConfigurationControl1.HelpKeyWord = null;
            this.testConfigurationControl1.LastError = null;
            this.testConfigurationControl1.Location = new System.Drawing.Point(0, 0);
            this.testConfigurationControl1.Name = "testConfigurationControl1";
            this.testConfigurationControl1.SchemaTypeName = null;
            this.testConfigurationControl1.Size = new System.Drawing.Size(243, 440);
            this.testConfigurationControl1.TabIndex = 0;
            this.testConfigurationControl1.TargetNamespace = null;
            this.testConfigurationControl1.Load += new System.EventHandler(this.testConfigurationControl1_Load);
            // 
            // TestConfigurationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(243, 440);
            this.CloseButton = false;
            this.CloseButtonVisible = false;
            this.Controls.Add(this.testConfigurationControl1);
            this.DockAreas = ((WeifenLuo.WinFormsUI.Docking.DockAreas)(((((WeifenLuo.WinFormsUI.Docking.DockAreas.Float | WeifenLuo.WinFormsUI.Docking.DockAreas.DockLeft) 
            | WeifenLuo.WinFormsUI.Docking.DockAreas.DockRight) 
            | WeifenLuo.WinFormsUI.Docking.DockAreas.DockTop) 
            | WeifenLuo.WinFormsUI.Docking.DockAreas.DockBottom)));
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "TestConfigurationForm";
            this.Text = "Test Configuration";
            this.ResumeLayout(false);

        }

        #endregion

        private TestConfigurationControl testConfigurationControl1;
    }
}