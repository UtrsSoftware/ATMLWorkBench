/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
*
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/
namespace ATMLCommonLibrary.controls.equipment
{
    partial class TerminalBlockForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TerminalBlockForm));
            this.terminalBlockControl = new ATMLCommonLibrary.controls.equipment.TerminalBlockControl();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.terminalBlockControl);
            this.panel1.Size = new System.Drawing.Size(506, 382);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(444, 400);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(363, 400);
            // 
            // lblDenoteRequiredField
            // 
            this.lblDenoteRequiredField.Location = new System.Drawing.Point(1, 411);
            // 
            // terminalBlockControl
            // 
            this.terminalBlockControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.terminalBlockControl.Location = new System.Drawing.Point(0, 0);
            this.terminalBlockControl.Margin = new System.Windows.Forms.Padding(0);
            this.terminalBlockControl.MinimumSize = new System.Drawing.Size(507, 167);
            this.terminalBlockControl.Name = "terminalBlockControl";
            this.terminalBlockControl.SchemaTypeName = null;
            this.terminalBlockControl.Size = new System.Drawing.Size(507, 382);
            this.terminalBlockControl.TabIndex = 0;
            this.terminalBlockControl.TargetNamespace = null;
            this.terminalBlockControl.TerminalBlock = ((ATMLModelLibrary.model.equipment.TestEquipmentTerminalBlocksTerminalBlock)(resources.GetObject("terminalBlockControl.TerminalBlock")));
            // 
            // TerminalBlockForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(531, 427);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "TerminalBlockForm";
            this.Text = "Terminal Blocks";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TerminalBlockControl terminalBlockControl;
    }
}
