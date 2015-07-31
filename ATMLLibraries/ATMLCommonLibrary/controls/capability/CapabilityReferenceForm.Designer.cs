/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
*
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

namespace ATMLCommonLibrary.controls.capability
{
    partial class CapabilityReferenceForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CapabilityReferenceForm));
            this.edtName = new ATMLCommonLibrary.controls.awb.AWBTextBox(this.components);
            this.capabilityListControl = new CapabilityListControl();
            this.edtVersion = new ATMLCommonLibrary.controls.awb.AWBTextBox(this.components);
            this.edtUUID = new ATMLCommonLibrary.controls.awb.AWBTextBox(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnImportCapabilityDocument = new System.Windows.Forms.ToolStripButton();
            this.btnSearchDatabase = new System.Windows.Forms.ToolStripButton();
            this.panel1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.edtUUID);
            this.panel1.Controls.Add(this.edtVersion);
            this.panel1.Controls.Add(this.capabilityListControl);
            this.panel1.Controls.Add(this.edtName);
            this.panel1.Location = new System.Drawing.Point(7, 50);
            this.panel1.Size = new System.Drawing.Size(636, 362);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(568, 431);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(487, 431);
            // 
            // lblDenoteRequiredField
            // 
            this.lblDenoteRequiredField.Location = new System.Drawing.Point(2, 441);
            // 
            // edtName
            // 
            this.edtName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtName.Location = new System.Drawing.Point(15, 26);
            this.edtName.Name = "edtName";
            this.edtName.Size = new System.Drawing.Size(603, 20);
            this.edtName.TabIndex = 0;
            this.edtName.Value = null;
            this.edtName.ValueType = ATMLCommonLibrary.controls.awb.AWBTextBox.eValueType.xsString;
            // 
            // capabilityListControl
            // 
            this.capabilityListControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.capabilityListControl.CapabilityItems = null;
            this.capabilityListControl.InstrumentDescription = null;
            this.capabilityListControl.Location = new System.Drawing.Point(15, 107);
            this.capabilityListControl.Name = "capabilityListControl";
            this.capabilityListControl.ReferenceOnly = false;
            this.capabilityListControl.Size = new System.Drawing.Size(603, 242);
            this.capabilityListControl.TabIndex = 1;
            // 
            // edtVersion
            // 
            this.edtVersion.Location = new System.Drawing.Point(15, 65);
            this.edtVersion.Name = "edtVersion";
            this.edtVersion.Size = new System.Drawing.Size(148, 20);
            this.edtVersion.TabIndex = 2;
            this.edtVersion.Value = null;
            this.edtVersion.ValueType = ATMLCommonLibrary.controls.awb.AWBTextBox.eValueType.xsString;
            // 
            // edtUUID
            // 
            this.edtUUID.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtUUID.Location = new System.Drawing.Point(180, 65);
            this.edtUUID.Name = "edtUUID";
            this.edtUUID.Size = new System.Drawing.Size(438, 20);
            this.edtUUID.TabIndex = 3;
            this.edtUUID.Value = null;
            this.edtUUID.ValueType = ATMLCommonLibrary.controls.awb.AWBTextBox.eValueType.xsString;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Version";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(177, 49);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "UUID";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 91);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Capabilities";
            // 
            // toolStrip1
            // 
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnImportCapabilityDocument,
            this.btnSearchDatabase});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(651, 31);
            this.toolStrip1.TabIndex = 7;
            this.toolStrip1.Text = "toolStrip";
            // 
            // btnImportCapabilityDocument
            // 
            this.btnImportCapabilityDocument.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnImportCapabilityDocument.Image = ((System.Drawing.Image)(resources.GetObject("btnImportCapabilityDocument.Image")));
            this.btnImportCapabilityDocument.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnImportCapabilityDocument.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnImportCapabilityDocument.Name = "btnImportCapabilityDocument";
            this.btnImportCapabilityDocument.Size = new System.Drawing.Size(28, 28);
            this.btnImportCapabilityDocument.Text = "toolStripButton";
            this.btnImportCapabilityDocument.ToolTipText = "Press to import a Capability Reference Document";
            this.btnImportCapabilityDocument.Click += new System.EventHandler(this.btnImportCapabilityDocument_Click);
            // 
            // btnSearchDatabase
            // 
            this.btnSearchDatabase.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnSearchDatabase.Image = ((System.Drawing.Image)(resources.GetObject("btnSearchDatabase.Image")));
            this.btnSearchDatabase.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSearchDatabase.Name = "btnSearchDatabase";
            this.btnSearchDatabase.Size = new System.Drawing.Size(28, 28);
            this.btnSearchDatabase.Text = "Press to search the database for a Capablility Reference Document";
            this.btnSearchDatabase.Click += new System.EventHandler(this.btnSearchDatabase_Click);
            // 
            // CapabilityReferenceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(651, 459);
            this.Controls.Add(this.toolStrip1);
            this.Name = "CapabilityReferenceForm";
            this.Text = "Capability Reference";
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.btnOk, 0);
            this.Controls.SetChildIndex(this.btnCancel, 0);
            this.Controls.SetChildIndex(this.lblDenoteRequiredField, 0);
            this.Controls.SetChildIndex(this.toolStrip1, 0);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private ATMLCommonLibrary.controls.awb.AWBTextBox edtUUID;
        private ATMLCommonLibrary.controls.awb.AWBTextBox edtVersion;
        private CapabilityListControl capabilityListControl;
        private ATMLCommonLibrary.controls.awb.AWBTextBox edtName;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnImportCapabilityDocument;
        private System.Windows.Forms.ToolStripButton btnSearchDatabase;
    }
}