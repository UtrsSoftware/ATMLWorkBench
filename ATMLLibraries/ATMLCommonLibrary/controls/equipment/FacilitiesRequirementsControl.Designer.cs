/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
* 
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

using ATMLCommonLibrary.controls.document;

namespace ATMLCommonLibrary.controls.hardware
{
    partial class FacilitiesRequirementsControl
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
            this.components = new System.ComponentModel.Container();
            this.tabControl1 = new ATMLCommonLibrary.controls.awb.AWBTabControl();
            this.Requirements = new System.Windows.Forms.TabPage();
            this.label3 = new ATMLCommonLibrary.controls.HelpLabel(this.components);
            this.label2 = new ATMLCommonLibrary.controls.HelpLabel(this.components);
            this.label1 = new ATMLCommonLibrary.controls.HelpLabel(this.components);
            this.edtPneumatic = new ATMLCommonLibrary.controls.awb.AWBTextBox(this.components);
            this.edtHydraulic = new ATMLCommonLibrary.controls.awb.AWBTextBox(this.components);
            this.edtCooling = new ATMLCommonLibrary.controls.awb.AWBTextBox(this.components);
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.documentListControl1 = new DocumentListControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.portListControl = new ATMLCommonLibrary.controls.common.PortListControl();
            this.tabControl1.SuspendLayout();
            this.Requirements.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.Requirements);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(451, 360);
            this.tabControl1.TabIndex = 0;
            // 
            // Requirements
            // 
            this.Requirements.Controls.Add(this.label3);
            this.Requirements.Controls.Add(this.label2);
            this.Requirements.Controls.Add(this.label1);
            this.Requirements.Controls.Add(this.edtPneumatic);
            this.Requirements.Controls.Add(this.edtHydraulic);
            this.Requirements.Controls.Add(this.edtCooling);
            this.Requirements.Location = new System.Drawing.Point(4, 22);
            this.Requirements.Name = "Requirements";
            this.Requirements.Padding = new System.Windows.Forms.Padding(3);
            this.Requirements.Size = new System.Drawing.Size(438, 329);
            this.Requirements.TabIndex = 0;
            this.Requirements.Text = "Requirements";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.HelpMessageKey = "Hardware.FacilitiesReq.Pneumatic";
            this.label3.Location = new System.Drawing.Point(18, 97);
            this.label3.Name = "label3";
            this.label3.RequiredField = false;
            this.label3.RequiredFieldMarkerFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Size = new System.Drawing.Size(57, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Pneumatic";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.HelpMessageKey = "Hardware.FacilitiesReq.Hydraulic";
            this.label2.Location = new System.Drawing.Point(18, 56);
            this.label2.Name = "label2";
            this.label2.RequiredField = false;
            this.label2.RequiredFieldMarkerFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Size = new System.Drawing.Size(51, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Hydraulic";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.HelpMessageKey = "Hardware.FacilitiesReq.Cooling";
            this.label1.Location = new System.Drawing.Point(18, 15);
            this.label1.Name = "label1";
            this.label1.RequiredField = false;
            this.label1.RequiredFieldMarkerFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Size = new System.Drawing.Size(42, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Cooling";
            // 
            // edtPneumatic
            // 
            this.edtPneumatic.AttributeName = null;
            this.edtPneumatic.Location = new System.Drawing.Point(21, 112);
            this.edtPneumatic.Name = "edtPneumatic";
            this.edtPneumatic.Size = new System.Drawing.Size(100, 20);
            this.edtPneumatic.TabIndex = 2;
            this.edtPneumatic.Value = null;
            this.edtPneumatic.ValueType = ATMLCommonLibrary.controls.awb.AWBTextBox.eValueType.xsString;
            // 
            // edtHydraulic
            // 
            this.edtHydraulic.AttributeName = null;
            this.edtHydraulic.Location = new System.Drawing.Point(21, 72);
            this.edtHydraulic.Name = "edtHydraulic";
            this.edtHydraulic.Size = new System.Drawing.Size(100, 20);
            this.edtHydraulic.TabIndex = 1;
            this.edtHydraulic.Value = null;
            this.edtHydraulic.ValueType = ATMLCommonLibrary.controls.awb.AWBTextBox.eValueType.xsString;
            // 
            // edtCooling
            // 
            this.edtCooling.AttributeName = null;
            this.edtCooling.Location = new System.Drawing.Point(21, 31);
            this.edtCooling.Name = "edtCooling";
            this.edtCooling.Size = new System.Drawing.Size(100, 20);
            this.edtCooling.TabIndex = 0;
            this.edtCooling.Value = null;
            this.edtCooling.ValueType = ATMLCommonLibrary.controls.awb.AWBTextBox.eValueType.xsString;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.documentListControl1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(438, 329);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Document";
            // 
            // documentListControl1
            // 
            this.documentListControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.documentListControl1.Location = new System.Drawing.Point(3, 3);
            this.documentListControl1.Name = "documentListControl1";
            this.documentListControl1.Size = new System.Drawing.Size(432, 323);
            this.documentListControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.portListControl);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(443, 334);
            this.tabPage1.TabIndex = 2;
            this.tabPage1.Text = "Interface";
            // 
            // portListControl
            // 
            this.portListControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.portListControl.ListName = null;
            this.portListControl.Location = new System.Drawing.Point(3, 3);
            this.portListControl.Margin = new System.Windows.Forms.Padding(0);
            this.portListControl.Name = "portListControl";
            this.portListControl.SchemaTypeName = null;
            this.portListControl.ShowFind = false;
            this.portListControl.Size = new System.Drawing.Size(437, 328);
            this.portListControl.TabIndex = 0;
            this.portListControl.TargetNamespace = null;
            // 
            // FacilitiesRequirementsControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControl1);
            this.Name = "FacilitiesRequirementsControl";
            this.Size = new System.Drawing.Size(451, 360);
            this.tabControl1.ResumeLayout(false);
            this.Requirements.ResumeLayout(false);
            this.Requirements.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private ATMLCommonLibrary.controls.awb.AWBTabControl tabControl1;
        private System.Windows.Forms.TabPage Requirements;
        private awb.AWBTextBox edtCooling;
        private System.Windows.Forms.TabPage tabPage2;
        private awb.AWBTextBox edtPneumatic;
        private awb.AWBTextBox edtHydraulic;
        private ATMLCommonLibrary.controls.HelpLabel label3;
        private ATMLCommonLibrary.controls.HelpLabel label2;
        private ATMLCommonLibrary.controls.HelpLabel label1;
        private System.Windows.Forms.TabPage tabPage1;
        private common.PortListControl portListControl;
        private DocumentListControl documentListControl1;
    }
}
