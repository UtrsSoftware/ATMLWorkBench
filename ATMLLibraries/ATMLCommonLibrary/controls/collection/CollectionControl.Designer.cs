/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
*
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

namespace ATMLCommonLibrary.controls.collection
{
    partial class CollectionControl
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
            this.label3 = new ATMLCommonLibrary.controls.HelpLabel(this.components);
            this.errorLimitControl = new ATMLCommonLibrary.controls.limit.LimitControl();
            this.edtNonStandardUnit = new ATMLCommonLibrary.controls.awb.AWBTextBox(this.components);
            this.tabErrorLimits = new System.Windows.Forms.TabPage();
            this.label2 = new ATMLCommonLibrary.controls.HelpLabel(this.components);
            this.tabRange = new System.Windows.Forms.TabPage();
            this.rangeLimitControl = new ATMLCommonLibrary.controls.limit.LimitControl();
            this.label1 = new ATMLCommonLibrary.controls.HelpLabel(this.components);
            this.edtConfidence = new ATMLCommonLibrary.controls.awb.AWBTextBox(this.components);
            this.chkConfidence = new System.Windows.Forms.CheckBox();
            this.edtResolution = new ATMLCommonLibrary.controls.awb.AWBTextBox(this.components);
            this.chkResolution = new System.Windows.Forms.CheckBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabItems = new System.Windows.Forms.TabPage();
            this.collectionListControl = new CollectionListControl();
            this.standardUnitControl = new ATMLCommonLibrary.controls.StandardUnitControl();
            this.cmbQualifier = new ATMLCommonLibrary.controls.QualifierComboBox(this.components);
            this.label4 = new ATMLCommonLibrary.controls.HelpLabel(this.components);
            this.label5 = new ATMLCommonLibrary.controls.HelpLabel(this.components);
            this.tabErrorLimits.SuspendLayout();
            this.tabRange.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabItems.SuspendLayout();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.HelpMessageKey = "Collection.DefUnitQualifier";
            this.label3.Location = new System.Drawing.Point(229, 60);
            this.label3.Name = "label3";
            this.label3.RequiredField = false;
            this.label3.RequiredFieldMarkerFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Size = new System.Drawing.Size(87, 13);
            this.label3.TabIndex = 19;
            this.label3.Text = "Def Unit Qualifier";
            // 
            // errorLimitControl
            // 
            this.errorLimitControl.DefaultComparitor = -1;
            this.errorLimitControl.DefaultLimitType = 0;
            this.errorLimitControl.DefaultStandardUnit = null;
            this.errorLimitControl.DefaultValue = null;
            this.errorLimitControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.errorLimitControl.HelpKeyWord = null;
            this.errorLimitControl.Location = new System.Drawing.Point(3, 3);
            this.errorLimitControl.Name = "errorLimitControl";
            this.errorLimitControl.SchemaTypeName = null;
            this.errorLimitControl.Size = new System.Drawing.Size(570, 430);
            this.errorLimitControl.TabIndex = 0;
            this.errorLimitControl.TargetNamespace = null;
            // 
            // edtNonStandardUnit
            // 
            this.edtNonStandardUnit.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtNonStandardUnit.AttributeName = null;
            this.edtNonStandardUnit.Location = new System.Drawing.Point(320, 31);
            this.edtNonStandardUnit.Name = "edtNonStandardUnit";
            this.edtNonStandardUnit.Size = new System.Drawing.Size(240, 20);
            this.edtNonStandardUnit.TabIndex = 18;
            this.edtNonStandardUnit.Value = null;
            this.edtNonStandardUnit.ValueType = ATMLCommonLibrary.controls.awb.AWBTextBox.eValueType.xsString;
            // 
            // tabErrorLimits
            // 
            this.tabErrorLimits.Controls.Add(this.errorLimitControl);
            this.tabErrorLimits.Location = new System.Drawing.Point(4, 22);
            this.tabErrorLimits.Name = "tabErrorLimits";
            this.tabErrorLimits.Padding = new System.Windows.Forms.Padding(3);
            this.tabErrorLimits.Size = new System.Drawing.Size(576, 436);
            this.tabErrorLimits.TabIndex = 0;
            this.tabErrorLimits.Text = "Error Limits";
            this.tabErrorLimits.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.HelpMessageKey = "Collection.DefNonStndardUnit";
            this.label2.Location = new System.Drawing.Point(201, 34);
            this.label2.Name = "label2";
            this.label2.RequiredField = false;
            this.label2.RequiredFieldMarkerFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Size = new System.Drawing.Size(115, 13);
            this.label2.TabIndex = 17;
            this.label2.Text = "Def Non Standard Unit";
            // 
            // tabRange
            // 
            this.tabRange.Controls.Add(this.rangeLimitControl);
            this.tabRange.Location = new System.Drawing.Point(4, 22);
            this.tabRange.Name = "tabRange";
            this.tabRange.Padding = new System.Windows.Forms.Padding(3);
            this.tabRange.Size = new System.Drawing.Size(576, 436);
            this.tabRange.TabIndex = 1;
            this.tabRange.Text = "Range";
            this.tabRange.UseVisualStyleBackColor = true;
            // 
            // rangeLimitControl
            // 
            this.rangeLimitControl.DefaultComparitor = -1;
            this.rangeLimitControl.DefaultLimitType = 0;
            this.rangeLimitControl.DefaultStandardUnit = null;
            this.rangeLimitControl.DefaultValue = null;
            this.rangeLimitControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rangeLimitControl.HelpKeyWord = null;
            this.rangeLimitControl.Location = new System.Drawing.Point(3, 3);
            this.rangeLimitControl.Name = "rangeLimitControl";
            this.rangeLimitControl.SchemaTypeName = null;
            this.rangeLimitControl.Size = new System.Drawing.Size(570, 430);
            this.rangeLimitControl.TabIndex = 1;
            this.rangeLimitControl.TargetNamespace = null;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.HelpMessageKey = "Collection.DefStndardUnit";
            this.label1.Location = new System.Drawing.Point(224, 8);
            this.label1.Name = "label1";
            this.label1.RequiredField = false;
            this.label1.RequiredFieldMarkerFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Size = new System.Drawing.Size(92, 13);
            this.label1.TabIndex = 15;
            this.label1.Text = "Def Standard Unit";
            // 
            // edtConfidence
            // 
            this.edtConfidence.AttributeName = null;
            this.edtConfidence.Enabled = false;
            this.edtConfidence.Location = new System.Drawing.Point(88, 31);
            this.edtConfidence.Name = "edtConfidence";
            this.edtConfidence.Size = new System.Drawing.Size(94, 20);
            this.edtConfidence.TabIndex = 14;
            this.edtConfidence.Value = null;
            this.edtConfidence.ValueType = ATMLCommonLibrary.controls.awb.AWBTextBox.eValueType.xsString;
            // 
            // chkConfidence
            // 
            this.chkConfidence.AutoSize = true;
            this.chkConfidence.Location = new System.Drawing.Point(5, 33);
            this.chkConfidence.Name = "chkConfidence";
            this.chkConfidence.Size = new System.Drawing.Size(15, 14);
            this.chkConfidence.TabIndex = 13;
            this.chkConfidence.UseVisualStyleBackColor = true;
            this.chkConfidence.CheckedChanged += new System.EventHandler(this.chkConfidence_CheckedChanged);
            // 
            // edtResolution
            // 
            this.edtResolution.AttributeName = null;
            this.edtResolution.Enabled = false;
            this.edtResolution.Location = new System.Drawing.Point(88, 5);
            this.edtResolution.Name = "edtResolution";
            this.edtResolution.Size = new System.Drawing.Size(94, 20);
            this.edtResolution.TabIndex = 12;
            this.edtResolution.Value = null;
            this.edtResolution.ValueType = ATMLCommonLibrary.controls.awb.AWBTextBox.eValueType.xsString;
            // 
            // chkResolution
            // 
            this.chkResolution.AutoSize = true;
            this.chkResolution.Location = new System.Drawing.Point(5, 7);
            this.chkResolution.Name = "chkResolution";
            this.chkResolution.Size = new System.Drawing.Size(15, 14);
            this.chkResolution.TabIndex = 11;
            this.chkResolution.UseVisualStyleBackColor = true;
            this.chkResolution.CheckedChanged += new System.EventHandler(this.chkResolution_CheckedChanged);
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabItems);
            this.tabControl1.Controls.Add(this.tabErrorLimits);
            this.tabControl1.Controls.Add(this.tabRange);
            this.tabControl1.Location = new System.Drawing.Point(5, 83);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(584, 462);
            this.tabControl1.TabIndex = 21;
            // 
            // tabItems
            // 
            this.tabItems.Controls.Add(this.collectionListControl);
            this.tabItems.Location = new System.Drawing.Point(4, 22);
            this.tabItems.Name = "tabItems";
            this.tabItems.Size = new System.Drawing.Size(576, 436);
            this.tabItems.TabIndex = 2;
            this.tabItems.Text = "Collections";
            this.tabItems.UseVisualStyleBackColor = true;
            // 
            // collectionListControl
            // 
            this.collectionListControl.AllowRowResequencing = false;
            this.collectionListControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.collectionListControl.BackColor = System.Drawing.Color.Transparent;
            this.collectionListControl.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.collectionListControl.FormTitle = null;
            this.collectionListControl.HelpKeyWord = null;
            this.collectionListControl.ListName = null;
            this.collectionListControl.Location = new System.Drawing.Point(0, 33);
            this.collectionListControl.Margin = new System.Windows.Forms.Padding(0);
            this.collectionListControl.Name = "collectionListControl";
            this.collectionListControl.SchemaTypeName = null;
            this.collectionListControl.ShowFind = false;
            this.collectionListControl.Size = new System.Drawing.Size(576, 403);
            this.collectionListControl.TabIndex = 0;
            this.collectionListControl.TargetNamespace = null;
            this.collectionListControl.TooltipTextAddButton = "Press to add a new ";
            this.collectionListControl.TooltipTextDeleteButton = "Press to delete the selected ";
            this.collectionListControl.TooltipTextEditButton = "Press to edit the selected ";
            // 
            // standardUnitControl
            // 
            this.standardUnitControl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.standardUnitControl.HelpKeyWord = null;
            this.standardUnitControl.Location = new System.Drawing.Point(320, 5);
            this.standardUnitControl.Name = "standardUnitControl";
            this.standardUnitControl.SchemaTypeName = null;
            this.standardUnitControl.Size = new System.Drawing.Size(240, 21);
            this.standardUnitControl.TabIndex = 22;
            this.standardUnitControl.TargetNamespace = null;
            // 
            // cmbQualifier
            // 
            this.cmbQualifier.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbQualifier.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbQualifier.FormattingEnabled = true;
            this.cmbQualifier.Items.AddRange(new object[] {
            "av",
            "inst_max",
            "inst_min",
            "pk",
            "pk_neg",
            "pk_pk",
            "pk_pos",
            "trms"});
            this.cmbQualifier.Location = new System.Drawing.Point(320, 58);
            this.cmbQualifier.Name = "cmbQualifier";
            this.cmbQualifier.Size = new System.Drawing.Size(240, 21);
            this.cmbQualifier.Sorted = true;
            this.cmbQualifier.TabIndex = 23;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.HelpMessageKey = "Collection.Resolution";
            this.label4.Location = new System.Drawing.Point(21, 7);
            this.label4.Name = "label4";
            this.label4.RequiredField = false;
            this.label4.RequiredFieldMarkerFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Size = new System.Drawing.Size(57, 13);
            this.label4.TabIndex = 24;
            this.label4.Text = "Resolution";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.HelpMessageKey = "Collection.Confidence";
            this.label5.Location = new System.Drawing.Point(21, 34);
            this.label5.Name = "label5";
            this.label5.RequiredField = false;
            this.label5.RequiredFieldMarkerFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Size = new System.Drawing.Size(61, 13);
            this.label5.TabIndex = 25;
            this.label5.Text = "Confidence";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // CollectionControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cmbQualifier);
            this.Controls.Add(this.standardUnitControl);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.edtNonStandardUnit);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.edtConfidence);
            this.Controls.Add(this.chkConfidence);
            this.Controls.Add(this.edtResolution);
            this.Controls.Add(this.chkResolution);
            this.Controls.Add(this.tabControl1);
            this.Name = "CollectionControl";
            this.Size = new System.Drawing.Size(595, 550);
            this.tabErrorLimits.ResumeLayout(false);
            this.tabRange.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabItems.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ATMLCommonLibrary.controls.HelpLabel label3;
        private limit.LimitControl errorLimitControl;
        private ATMLCommonLibrary.controls.awb.AWBTextBox edtNonStandardUnit;
        private System.Windows.Forms.TabPage tabErrorLimits;
        private ATMLCommonLibrary.controls.HelpLabel label2;
        private System.Windows.Forms.TabPage tabRange;
        private limit.LimitControl rangeLimitControl;
        private ATMLCommonLibrary.controls.HelpLabel label1;
        private ATMLCommonLibrary.controls.awb.AWBTextBox edtConfidence;
        private System.Windows.Forms.CheckBox chkConfidence;
        private ATMLCommonLibrary.controls.awb.AWBTextBox edtResolution;
        private System.Windows.Forms.CheckBox chkResolution;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabItems;
        private StandardUnitControl standardUnitControl;
        private QualifierComboBox cmbQualifier;
        private CollectionListControl collectionListControl;
        private ATMLCommonLibrary.controls.HelpLabel label4;
        private ATMLCommonLibrary.controls.HelpLabel label5;

    }
}
