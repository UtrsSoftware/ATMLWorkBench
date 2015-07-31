/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
* 
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

using ATMLCommonLibrary.controls.hardware;

namespace ATMLCommonLibrary.controls.control.driver
{
    partial class ControlDriver
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.driverSelectionControl1 = new ATMLCommonLibrary.controls.driver.DriverSelectionControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.manufacturerControl1 = new ATMLCommonLibrary.controls.manufacturer.ManufacturerControl();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this._controlDriverDependenciesControl1 = new ControlDriverDependenciesControl();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Location = new System.Drawing.Point(13, 64);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(493, 515);
            this.tabControl1.TabIndex = 6;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.driverSelectionControl1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(485, 489);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Type";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // driverSelectionControl1
            // 
            this.driverSelectionControl1.AutoScroll = true;
            this.driverSelectionControl1.BackColor = System.Drawing.Color.AliceBlue;
            this.driverSelectionControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.driverSelectionControl1.DriverSelect = null;
            this.driverSelectionControl1.HelpKeyWord = null;
            this.driverSelectionControl1.Location = new System.Drawing.Point(3, 3);
            this.driverSelectionControl1.Name = "driverSelectionControl1";
            this.driverSelectionControl1.SchemaTypeName = null;
            this.driverSelectionControl1.Size = new System.Drawing.Size(479, 483);
            this.driverSelectionControl1.TabIndex = 0;
            this.driverSelectionControl1.TargetNamespace = null;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.manufacturerControl1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(485, 489);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Manufacturer";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // manufacturerControl1
            // 
            this.manufacturerControl1.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.manufacturerControl1.BackColor = System.Drawing.Color.AliceBlue;
            this.manufacturerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.manufacturerControl1.HelpKeyWord = null;
            this.manufacturerControl1.Location = new System.Drawing.Point(3, 3);
            this.manufacturerControl1.Name = "manufacturerControl1";
            this.manufacturerControl1.SchemaTypeName = null;
            this.manufacturerControl1.Size = new System.Drawing.Size(479, 483);
            this.manufacturerControl1.TabIndex = 0;
            this.manufacturerControl1.TargetNamespace = null;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this._controlDriverDependenciesControl1);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(485, 489);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Dependencies";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // _controlDriverDependenciesControl1
            // 
            this._controlDriverDependenciesControl1.BackColor = System.Drawing.Color.AliceBlue;
            this._controlDriverDependenciesControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this._controlDriverDependenciesControl1.HelpKeyWord = null;
            this._controlDriverDependenciesControl1.Location = new System.Drawing.Point(3, 3);
            this._controlDriverDependenciesControl1.Name = "_controlDriverDependenciesControl1";
            this._controlDriverDependenciesControl1.SchemaTypeName = null;
            this._controlDriverDependenciesControl1.Size = new System.Drawing.Size(479, 483);
            this._controlDriverDependenciesControl1.TabIndex = 0;
            this._controlDriverDependenciesControl1.TargetNamespace = null;
            // 
            // tabPage4
            // 
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(485, 489);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Platform";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // ControlDriver
            // 
            this.Controls.Add(this.tabControl1);
            this.Name = "ControlDriver";
            this.Size = new System.Drawing.Size(532, 600);
            this.Controls.SetChildIndex(this.tabControl1, 0);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private controls.driver.DriverSelectionControl driverSelectionControl1;
        private manufacturer.ManufacturerControl manufacturerControl1;
        private ControlDriverDependenciesControl _controlDriverDependenciesControl1;
    }
}
