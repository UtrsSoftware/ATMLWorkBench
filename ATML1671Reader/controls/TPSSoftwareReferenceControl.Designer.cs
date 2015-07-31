/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
* 
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

using ATMLCommonLibrary.controls.document;

namespace ATML1671Reader.controls
{
    partial class TpsSoftwareReferenceControl
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabDescription = new System.Windows.Forms.TabPage();
            this.itemDescriptionReferenceControl = new ATMLCommonLibrary.controls.ItemDescriptionReferenceControl();
            this.tabDocumentation = new System.Windows.Forms.TabPage();
            this.documentControl = new DocumentControl();
            this.edtType = new ATMLCommonLibrary.controls.awb.AWBTextBox(this.components);
            this.label6 = new System.Windows.Forms.Label();
            this.edtItemRef = new ATMLCommonLibrary.controls.awb.AWBTextBox(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.checkSumControl = new ATML1671Reader.controls.CheckSumControl();
            this.tabControl1.SuspendLayout();
            this.tabDescription.SuspendLayout();
            this.tabDocumentation.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabDescription);
            this.tabControl1.Controls.Add(this.tabDocumentation);
            this.tabControl1.Location = new System.Drawing.Point(3, 83);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(703, 397);
            this.tabControl1.TabIndex = 9;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabDescription
            // 
            this.tabDescription.Controls.Add(this.itemDescriptionReferenceControl);
            this.tabDescription.Location = new System.Drawing.Point(4, 22);
            this.tabDescription.Name = "tabDescription";
            this.tabDescription.Padding = new System.Windows.Forms.Padding(3);
            this.tabDescription.Size = new System.Drawing.Size(695, 371);
            this.tabDescription.TabIndex = 0;
            this.tabDescription.Text = "Description";
            this.tabDescription.UseVisualStyleBackColor = true;
            // 
            // itemDescriptionReferenceControl
            // 
            this.itemDescriptionReferenceControl.BackColor = System.Drawing.Color.LightSlateGray;
            this.itemDescriptionReferenceControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.itemDescriptionReferenceControl.DocumentType = ATMLDataAccessLibrary.model.dbDocument.DocumentType.NONE;
            this.itemDescriptionReferenceControl.HelpKeyWord = null;
            this.itemDescriptionReferenceControl.Location = new System.Drawing.Point(3, 3);
            this.itemDescriptionReferenceControl.Name = "itemDescriptionReferenceControl";
            this.itemDescriptionReferenceControl.SchemaTypeName = null;
            this.itemDescriptionReferenceControl.Size = new System.Drawing.Size(689, 365);
            this.itemDescriptionReferenceControl.TabIndex = 0;
            this.itemDescriptionReferenceControl.TargetNamespace = null;
            // 
            // tabDocumentation
            // 
            this.tabDocumentation.Controls.Add(this.documentControl);
            this.tabDocumentation.Location = new System.Drawing.Point(4, 22);
            this.tabDocumentation.Name = "tabDocumentation";
            this.tabDocumentation.Padding = new System.Windows.Forms.Padding(3);
            this.tabDocumentation.Size = new System.Drawing.Size(695, 371);
            this.tabDocumentation.TabIndex = 1;
            this.tabDocumentation.Text = "Documentation";
            this.tabDocumentation.UseVisualStyleBackColor = true;
            // 
            // documentControl
            // 
            this.documentControl.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.documentControl.BackColor = System.Drawing.Color.Transparent;
            this.documentControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.documentControl.HelpKeyWord = null;
            this.documentControl.Location = new System.Drawing.Point(3, 3);
            this.documentControl.Name = "documentControl";
            this.documentControl.SchemaTypeName = null;
            this.documentControl.Size = new System.Drawing.Size(689, 365);
            this.documentControl.TabIndex = 1;
            this.documentControl.TargetNamespace = null;
            this.documentControl.ValidationEnabled = true;
            // 
            // edtType
            // 
            this.edtType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtType.AttributeName = null;
            this.edtType.Location = new System.Drawing.Point(70, 41);
            this.edtType.Name = "edtType";
            this.edtType.Size = new System.Drawing.Size(372, 20);
            this.edtType.TabIndex = 13;
            this.edtType.Value = null;
            this.edtType.ValueType = ATMLCommonLibrary.controls.awb.AWBTextBox.eValueType.xsString;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(33, 43);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(31, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Type";
            // 
            // edtItemRef
            // 
            this.edtItemRef.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtItemRef.AttributeName = null;
            this.edtItemRef.Location = new System.Drawing.Point(70, 13);
            this.edtItemRef.Name = "edtItemRef";
            this.edtItemRef.Size = new System.Drawing.Size(372, 20);
            this.edtItemRef.TabIndex = 11;
            this.edtItemRef.Value = null;
            this.edtItemRef.ValueType = ATMLCommonLibrary.controls.awb.AWBTextBox.eValueType.xsString;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(15, 15);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Item Ref";
            // 
            // checkSumControl
            // 
            this.checkSumControl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkSumControl.Checksum = null;
            this.checkSumControl.ForeColor = System.Drawing.Color.Black;
            this.checkSumControl.Location = new System.Drawing.Point(467, 3);
            this.checkSumControl.Name = "checkSumControl";
            this.checkSumControl.Size = new System.Drawing.Size(235, 74);
            this.checkSumControl.TabIndex = 14;
            // 
            // TpsSoftwareReferenceControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.checkSumControl);
            this.Controls.Add(this.edtType);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.edtItemRef);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tabControl1);
            this.Name = "TpsSoftwareReferenceControl";
            this.Size = new System.Drawing.Size(712, 487);
            this.tabControl1.ResumeLayout(false);
            this.tabDescription.ResumeLayout(false);
            this.tabDocumentation.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabDescription;
        private System.Windows.Forms.TabPage tabDocumentation;
        private ATMLCommonLibrary.controls.awb.AWBTextBox edtType;
        private System.Windows.Forms.Label label6;
        private ATMLCommonLibrary.controls.awb.AWBTextBox edtItemRef;
        private System.Windows.Forms.Label label5;
        private CheckSumControl checkSumControl;
        private ATMLCommonLibrary.controls.ItemDescriptionReferenceControl itemDescriptionReferenceControl;
        private DocumentControl documentControl;
    }
}
