/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
*
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

namespace ATMLCommonLibrary.controls.control.tool
{
    partial class ControlToolControlForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ControlToolControlForm));
            this.controlToolControl1 = new ControlToolControl();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.controlToolControl1);
            // 
            // controlToolControl1
            // 
            this.controlToolControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.controlToolControl1.HardwareItemDescriptionControlTool = ((ATMLModelLibrary.model.equipment.HardwareItemDescriptionControlTool)(resources.GetObject("controlToolControl1.HardwareItemDescriptionControlTool")));
            this.controlToolControl1.Location = new System.Drawing.Point(0, 0);
            this.controlToolControl1.Name = "controlToolControl1";
            this.controlToolControl1.Padding = new System.Windows.Forms.Padding(0, 50, 0, 0);
            this.controlToolControl1.SchemaTypeName = null;
            this.controlToolControl1.Size = new System.Drawing.Size(433, 270);
            this.controlToolControl1.TabIndex = 0;
            this.controlToolControl1.TargetNamespace = null;
            // 
            // ControlToolControlForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(458, 315);
            this.Margin = new System.Windows.Forms.Padding(48, 22, 48, 22);
            this.Name = "ControlToolControlForm";
            this.Text = "Control Tool";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ControlToolControl controlToolControl1;

    }
}
