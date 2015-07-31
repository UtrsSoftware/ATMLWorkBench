/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
*
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/
namespace ATMLCommonLibrary.controls.switching
{
    partial class SwitchControl
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabInterface = new System.Windows.Forms.TabPage();
            this.lvInterface = new ATMLCommonLibrary.controls.lists.ATMLListControl();
            this.tabSwitchRelays = new System.Windows.Forms.TabPage();
            this.lvSwitchRelays = new ATMLCommonLibrary.controls.lists.ATMLListControl();
            this.tabControl1.SuspendLayout();
            this.tabInterface.SuspendLayout();
            this.tabSwitchRelays.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabInterface);
            this.tabControl1.Controls.Add(this.tabSwitchRelays);
            this.tabControl1.Location = new System.Drawing.Point(6, 160);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(488, 171);
            this.tabControl1.TabIndex = 12;
            // 
            // tabInterface
            // 
            this.tabInterface.Controls.Add(this.lvInterface);
            this.tabInterface.Location = new System.Drawing.Point(4, 22);
            this.tabInterface.Name = "tabInterface";
            this.tabInterface.Padding = new System.Windows.Forms.Padding(3);
            this.tabInterface.Size = new System.Drawing.Size(480, 145);
            this.tabInterface.TabIndex = 0;
            this.tabInterface.Text = "Interface";
            this.tabInterface.UseVisualStyleBackColor = true;
            // 
            // lvInterface
            // 
            this.lvInterface.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvInterface.Location = new System.Drawing.Point(3, 3);
            this.lvInterface.Name = "lvInterface";
            this.lvInterface.Size = new System.Drawing.Size(474, 139);
            this.lvInterface.TabIndex = 1;
            // 
            // tabSwitchRelays
            // 
            this.tabSwitchRelays.Controls.Add(this.lvSwitchRelays);
            this.tabSwitchRelays.Location = new System.Drawing.Point(4, 22);
            this.tabSwitchRelays.Name = "tabSwitchRelays";
            this.tabSwitchRelays.Padding = new System.Windows.Forms.Padding(3);
            this.tabSwitchRelays.Size = new System.Drawing.Size(480, 145);
            this.tabSwitchRelays.TabIndex = 1;
            this.tabSwitchRelays.Text = "Switch Relays";
            this.tabSwitchRelays.UseVisualStyleBackColor = true;
            // 
            // lvSwitchRelays
            // 
            this.lvSwitchRelays.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvSwitchRelays.Location = new System.Drawing.Point(3, 3);
            this.lvSwitchRelays.Name = "lvSwitchRelays";
            this.lvSwitchRelays.Size = new System.Drawing.Size(474, 139);
            this.lvSwitchRelays.TabIndex = 0;
            // 
            // SwitchControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControl1);
            this.Name = "SwitchControl";
            this.Size = new System.Drawing.Size(507, 344);
            this.Controls.SetChildIndex(this.edtName, 0);
            this.Controls.SetChildIndex(this.edtDescription, 0);
            this.Controls.SetChildIndex(this.lblName, 0);
            this.Controls.SetChildIndex(this.lblDescription, 0);
            this.Controls.SetChildIndex(this.tabControl1, 0);
            this.tabControl1.ResumeLayout(false);
            this.tabInterface.ResumeLayout(false);
            this.tabSwitchRelays.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabInterface;
        private System.Windows.Forms.TabPage tabSwitchRelays;
        private lists.ATMLListControl lvSwitchRelays;
        private lists.ATMLListControl lvInterface;
    }
}
