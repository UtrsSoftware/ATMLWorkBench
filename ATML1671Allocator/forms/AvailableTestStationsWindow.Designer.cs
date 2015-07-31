/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
* 
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

namespace ATML1671Allocator.forms
{
    partial class AvailableTestStationsWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AvailableTestStationsWindow));
            this.lvTestStations = new ATMLCommonLibrary.controls.awb.AWBListView();
            this.SuspendLayout();
            // 
            // lvTestStations
            // 
            this.lvTestStations.CheckBoxes = true;
            this.lvTestStations.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvTestStations.FullRowSelect = true;
            this.lvTestStations.Location = new System.Drawing.Point(0, 0);
            this.lvTestStations.Name = "lvTestStations";
            this.lvTestStations.Size = new System.Drawing.Size(262, 520);
            this.lvTestStations.TabIndex = 3;
            this.lvTestStations.UseCompatibleStateImageBehavior = false;
            this.lvTestStations.View = System.Windows.Forms.View.Details;
            this.lvTestStations.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.lvTestStations_ItemCheck);
            this.lvTestStations.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.lvTestStations_ItemChecked);
            // 
            // AvailableTestStationsWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(262, 520);
            this.CloseButton = false;
            this.CloseButtonVisible = false;
            this.Controls.Add(this.lvTestStations);
            this.DockAreas = ((WeifenLuo.WinFormsUI.Docking.DockAreas)(((((WeifenLuo.WinFormsUI.Docking.DockAreas.Float | WeifenLuo.WinFormsUI.Docking.DockAreas.DockLeft) 
            | WeifenLuo.WinFormsUI.Docking.DockAreas.DockRight) 
            | WeifenLuo.WinFormsUI.Docking.DockAreas.DockTop) 
            | WeifenLuo.WinFormsUI.Docking.DockAreas.DockBottom)));
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AvailableTestStationsWindow";
            this.Text = "Stations";
            this.ResumeLayout(false);

        }

        #endregion

        private ATMLCommonLibrary.controls.awb.AWBListView lvTestStations;
    }
}