/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
* 
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

namespace ATMLCommonLibrary.controls.hardware.characteristics
{
    partial class PhysicalCharacteristicsControl
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
            this.tabControl1 = new ATMLCommonLibrary.controls.awb.AWBTabControl();
            this.tabMeasurements = new System.Windows.Forms.TabPage();
            this.DatumMass = new ATMLCommonLibrary.controls.datum.DatumTypeDoubleControl();
            this.label2 = new ATMLCommonLibrary.controls.HelpLabel(this.components);
            this.DatumVolume = new ATMLCommonLibrary.controls.datum.DatumTypeDoubleControl();
            this.label1 = new ATMLCommonLibrary.controls.HelpLabel(this.components);
            this.tabLinearMeasurements = new System.Windows.Forms.TabPage();
            this.physicalCharLinearControl = new ATMLCommonLibrary.controls.hardware.characteristics.PhysicalCharLinearControl();
            this.tabOther = new System.Windows.Forms.TabPage();
            this.otherListControl = new ATMLCommonLibrary.controls.common.NamedValueListControl();
            this.tabControl1.SuspendLayout();
            this.tabMeasurements.SuspendLayout();
            this.tabLinearMeasurements.SuspendLayout();
            this.tabOther.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabMeasurements);
            this.tabControl1.Controls.Add(this.tabLinearMeasurements);
            this.tabControl1.Controls.Add(this.tabOther);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(541, 248);
            this.tabControl1.TabIndex = 0;
            // 
            // tabMeasurements
            // 
            this.tabMeasurements.Controls.Add(this.DatumMass);
            this.tabMeasurements.Controls.Add(this.label2);
            this.tabMeasurements.Controls.Add(this.DatumVolume);
            this.tabMeasurements.Controls.Add(this.label1);
            this.tabMeasurements.Location = new System.Drawing.Point(4, 22);
            this.tabMeasurements.Name = "tabMeasurements";
            this.tabMeasurements.Padding = new System.Windows.Forms.Padding(3);
            this.tabMeasurements.Size = new System.Drawing.Size(533, 222);
            this.tabMeasurements.TabIndex = 0;
            this.tabMeasurements.Text = "Measurements";
            // 
            // DatumMass
            // 
            this.DatumMass.BackColor = System.Drawing.Color.White;
            this.DatumMass.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.DatumMass.HasErrors = false;
            this.DatumMass.HelpKeyWord = null;
            this.DatumMass.LastError = null;
            this.DatumMass.Location = new System.Drawing.Point(11, 27);
            this.DatumMass.Name = "DatumMass";
            this.DatumMass.SchemaTypeName = null;
            this.DatumMass.Size = new System.Drawing.Size(306, 30);
            this.DatumMass.TabIndex = 1;
            this.DatumMass.TargetNamespace = null;
            this.DatumMass.UseFlowControl = null;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.HelpMessageKey = "PhysicalChacaterisics.Volume";
            this.label2.Location = new System.Drawing.Point(11, 77);
            this.label2.Name = "label2";
            this.label2.RequiredField = false;
            this.label2.RequiredFieldMarkerFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Size = new System.Drawing.Size(42, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Volume";
            // 
            // DatumVolume
            // 
            this.DatumVolume.BackColor = System.Drawing.Color.White;
            this.DatumVolume.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.DatumVolume.HasErrors = false;
            this.DatumVolume.HelpKeyWord = null;
            this.DatumVolume.LastError = null;
            this.DatumVolume.Location = new System.Drawing.Point(11, 92);
            this.DatumVolume.Name = "DatumVolume";
            this.DatumVolume.SchemaTypeName = null;
            this.DatumVolume.Size = new System.Drawing.Size(306, 30);
            this.DatumVolume.TabIndex = 3;
            this.DatumVolume.TargetNamespace = null;
            this.DatumVolume.UseFlowControl = null;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.HelpMessageKey = "PhysicalChacaterisics.Mass";
            this.label1.Location = new System.Drawing.Point(11, 11);
            this.label1.Name = "label1";
            this.label1.RequiredField = false;
            this.label1.RequiredFieldMarkerFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mass";
            // 
            // tabLinearMeasurements
            // 
            this.tabLinearMeasurements.Controls.Add(this.physicalCharLinearControl);
            this.tabLinearMeasurements.Location = new System.Drawing.Point(4, 22);
            this.tabLinearMeasurements.Name = "tabLinearMeasurements";
            this.tabLinearMeasurements.Size = new System.Drawing.Size(533, 222);
            this.tabLinearMeasurements.TabIndex = 2;
            this.tabLinearMeasurements.Text = "Linear Measurements";
            // 
            // physicalCharLinearControl
            // 
            this.physicalCharLinearControl.BackColor = System.Drawing.Color.AliceBlue;
            this.physicalCharLinearControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.physicalCharLinearControl.HasErrors = false;
            this.physicalCharLinearControl.HelpKeyWord = null;
            this.physicalCharLinearControl.LastError = null;
            this.physicalCharLinearControl.Location = new System.Drawing.Point(0, 0);
            this.physicalCharLinearControl.MinimumSize = new System.Drawing.Size(329, 223);
            this.physicalCharLinearControl.Name = "physicalCharLinearControl";
            this.physicalCharLinearControl.SchemaTypeName = null;
            this.physicalCharLinearControl.Size = new System.Drawing.Size(533, 223);
            this.physicalCharLinearControl.TabIndex = 5;
            this.physicalCharLinearControl.TargetNamespace = null;
            this.physicalCharLinearControl.Load += new System.EventHandler(this.physicalCharLinearControl_Load);
            // 
            // tabOther
            // 
            this.tabOther.Controls.Add(this.otherListControl);
            this.tabOther.Location = new System.Drawing.Point(4, 22);
            this.tabOther.Name = "tabOther";
            this.tabOther.Padding = new System.Windows.Forms.Padding(3);
            this.tabOther.Size = new System.Drawing.Size(533, 222);
            this.tabOther.TabIndex = 1;
            this.tabOther.Text = "Other";
            // 
            // otherListControl
            // 
            this.otherListControl.AllowRowResequencing = false;
            this.otherListControl.BackColor = System.Drawing.Color.AliceBlue;
            this.otherListControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.otherListControl.FormTitle = null;
            this.otherListControl.HasErrors = false;
            this.otherListControl.HelpKeyWord = null;
            this.otherListControl.LastError = null;
            this.otherListControl.ListName = null;
            this.otherListControl.Location = new System.Drawing.Point(3, 3);
            this.otherListControl.Margin = new System.Windows.Forms.Padding(0);
            this.otherListControl.Name = "otherListControl";
            this.otherListControl.NamedValues = null;
            this.otherListControl.SchemaTypeName = null;
            this.otherListControl.ShowFind = false;
            this.otherListControl.Size = new System.Drawing.Size(527, 216);
            this.otherListControl.TabIndex = 0;
            this.otherListControl.TargetNamespace = null;
            this.otherListControl.TooltipTextAddButton = "Press to add a new Physical Characteristic";
            this.otherListControl.TooltipTextDeleteButton = "Press to delete the selected Physical Characteristic";
            this.otherListControl.TooltipTextEditButton = "Press to edit the selected Physical Characteristic";
            // 
            // PhysicalCharacteristicsControl
            // 
            this.Controls.Add(this.tabControl1);
            this.MinimumSize = new System.Drawing.Size(488, 248);
            this.Name = "PhysicalCharacteristicsControl";
            this.Size = new System.Drawing.Size(541, 248);
            this.tabControl1.ResumeLayout(false);
            this.tabMeasurements.ResumeLayout(false);
            this.tabMeasurements.PerformLayout();
            this.tabLinearMeasurements.ResumeLayout(false);
            this.tabOther.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private ATMLCommonLibrary.controls.awb.AWBTabControl tabControl1;
        private System.Windows.Forms.TabPage tabMeasurements;
        private System.Windows.Forms.TabPage tabOther;
        //private common.NamedValueListControl namedValueListControl1;
        private datum.DatumTypeDoubleControl DatumVolume;
        private ATMLCommonLibrary.controls.HelpLabel label1;
        private common.NamedValueListControl otherListControl;
        private ATMLCommonLibrary.controls.HelpLabel label2;
        private datum.DatumTypeDoubleControl DatumMass;
        private System.Windows.Forms.TabPage tabLinearMeasurements;
        private PhysicalCharLinearControl physicalCharLinearControl;



    }
}
