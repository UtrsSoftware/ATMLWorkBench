/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
* 
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

namespace ATML1671Reader.forms
{
    partial class TestEquipmentReferenceForm
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
            this.softwareInstanceControl1 = new ATML1671Reader.controls.SoftwareInstanceControl();
            this.itemInstanceControl1 = new ATML1671Reader.controls.ItemInstanceControl();
            this.testEquipmentControl1 = new ATML1671Reader.controls.TestEquipmentControl();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.testEquipmentControl1);
            this.panel1.Size = new System.Drawing.Size(567, 525);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(505, 544);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(424, 544);
            // 
            // lblDenoteRequiredField
            // 
            this.lblDenoteRequiredField.Location = new System.Drawing.Point(10, 557);
            // 
            // softwareInstanceControl1
            // 
            this.softwareInstanceControl1.BackColor = System.Drawing.Color.LightSlateGray;
            this.softwareInstanceControl1.DocumentType = ATMLDataAccessLibrary.model.dbDocument.DocumentType.NONE;
            this.softwareInstanceControl1.HelpKeyWord = null;
            this.softwareInstanceControl1.Location = new System.Drawing.Point(0, 0);
            this.softwareInstanceControl1.Name = "softwareInstanceControl1";
            this.softwareInstanceControl1.SchemaTypeName = null;
            this.softwareInstanceControl1.Size = new System.Drawing.Size(560, 400);
            this.softwareInstanceControl1.TabIndex = 0;
            this.softwareInstanceControl1.TargetNamespace = null;
            // 
            // itemInstanceControl1
            // 
            this.itemInstanceControl1.BackColor = System.Drawing.Color.LightSlateGray;
            this.itemInstanceControl1.DocumentType = ATMLDataAccessLibrary.model.dbDocument.DocumentType.NONE;
            this.itemInstanceControl1.HelpKeyWord = null;
            this.itemInstanceControl1.Location = new System.Drawing.Point(0, 0);
            this.itemInstanceControl1.Name = "itemInstanceControl1";
            this.itemInstanceControl1.SchemaTypeName = null;
            this.itemInstanceControl1.Size = new System.Drawing.Size(560, 400);
            this.itemInstanceControl1.TabIndex = 0;
            this.itemInstanceControl1.TargetNamespace = null;
            // 
            // testEquipmentControl1
            // 
            this.testEquipmentControl1.BackColor = System.Drawing.Color.LightSlateGray;
            this.testEquipmentControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.testEquipmentControl1.DocumentType = ATMLDataAccessLibrary.model.dbDocument.DocumentType.NONE;
            this.testEquipmentControl1.HelpKeyWord = null;
            this.testEquipmentControl1.Location = new System.Drawing.Point(0, 0);
            this.testEquipmentControl1.Name = "testEquipmentControl1";
            this.testEquipmentControl1.SchemaTypeName = null;
            this.testEquipmentControl1.Size = new System.Drawing.Size(567, 525);
            this.testEquipmentControl1.TabIndex = 0;
            this.testEquipmentControl1.TargetNamespace = null;
            // 
            // TestEquipmentReferenceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(592, 579);
            this.Name = "TestEquipmentReferenceForm";
            this.Text = "TestEquipmentReferenceForm";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private controls.SoftwareInstanceControl softwareInstanceControl1;
        private controls.ItemInstanceControl itemInstanceControl1;
        private controls.TestEquipmentControl testEquipmentControl1;
    }
}