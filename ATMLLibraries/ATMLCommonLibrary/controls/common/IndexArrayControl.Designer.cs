/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
*
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/
namespace ATMLCommonLibrary.controls.common
{
    partial class IndexArrayControl
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
            this.tabErrorLimits = new System.Windows.Forms.TabPage();
            this.tabRange = new System.Windows.Forms.TabPage();
            this.chkConfidence = new System.Windows.Forms.CheckBox();
            this.chkResolution = new System.Windows.Forms.CheckBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabItems = new System.Windows.Forms.TabPage();
            this.cmbIndexType = new System.Windows.Forms.ComboBox();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.label6 = new ATMLCommonLibrary.controls.HelpLabel(this.components);
            this.label5 = new ATMLCommonLibrary.controls.HelpLabel(this.components);
            this.cmbQualifier = new ATMLCommonLibrary.controls.QualifierComboBox(this.components);
            this.standardUnitControl = new ATMLCommonLibrary.controls.StandardUnitControl();
            this.label4 = new ATMLCommonLibrary.controls.HelpLabel(this.components);
            this.edtDimensions = new ATMLCommonLibrary.controls.awb.AWBTextBox(this.components);
            this.label3 = new ATMLCommonLibrary.controls.HelpLabel(this.components);
            this.edtNonStandardUnit = new ATMLCommonLibrary.controls.awb.AWBTextBox(this.components);
            this.label2 = new ATMLCommonLibrary.controls.HelpLabel(this.components);
            this.label1 = new ATMLCommonLibrary.controls.HelpLabel(this.components);
            this.edtConfidence = new ATMLCommonLibrary.controls.awb.AWBTextBox(this.components);
            this.edtResolution = new ATMLCommonLibrary.controls.awb.AWBTextBox(this.components);
            this.indexItemControl = new ATMLCommonLibrary.controls.lists.ATMLListControl();
            this.edtDefaultValue = new ATMLCommonLibrary.controls.awb.AWBTextBox(this.components);
            this.helpLabel2 = new ATMLCommonLibrary.controls.HelpLabel(this.components);
            this.helpLabel1 = new ATMLCommonLibrary.controls.HelpLabel(this.components);
            this.errorLimitControl = new ATMLCommonLibrary.controls.limit.LimitControl();
            this.rangeLimitControl = new ATMLCommonLibrary.controls.limit.LimitControl();
            this.xsdDimensionSchemaValidator = new ATMLCommonLibrary.controls.validators.XSDSchemaValidator();
            this.tabErrorLimits.SuspendLayout();
            this.tabRange.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabItems.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
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
            // chkConfidence
            // 
            this.chkConfidence.AutoSize = true;
            this.chkConfidence.Location = new System.Drawing.Point(5, 33);
            this.chkConfidence.Name = "chkConfidence";
            this.chkConfidence.Size = new System.Drawing.Size(15, 14);
            this.chkConfidence.TabIndex = 2;
            this.chkConfidence.UseVisualStyleBackColor = true;
            this.chkConfidence.CheckedChanged += new System.EventHandler(this.chkConfidence_CheckedChanged);
            // 
            // chkResolution
            // 
            this.chkResolution.AutoSize = true;
            this.chkResolution.Location = new System.Drawing.Point(5, 7);
            this.chkResolution.Name = "chkResolution";
            this.chkResolution.Size = new System.Drawing.Size(15, 14);
            this.chkResolution.TabIndex = 0;
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
            this.tabControl1.TabIndex = 12;
            // 
            // tabItems
            // 
            this.tabItems.BackColor = System.Drawing.Color.LightSteelBlue;
            this.tabItems.Controls.Add(this.indexItemControl);
            this.tabItems.Controls.Add(this.edtDefaultValue);
            this.tabItems.Controls.Add(this.helpLabel2);
            this.tabItems.Controls.Add(this.cmbIndexType);
            this.tabItems.Controls.Add(this.helpLabel1);
            this.tabItems.Location = new System.Drawing.Point(4, 22);
            this.tabItems.Name = "tabItems";
            this.tabItems.Size = new System.Drawing.Size(576, 436);
            this.tabItems.TabIndex = 2;
            this.tabItems.Text = "Items";
            // 
            // cmbIndexType
            // 
            this.cmbIndexType.FormattingEnabled = true;
            this.cmbIndexType.Location = new System.Drawing.Point(48, 4);
            this.cmbIndexType.Name = "cmbIndexType";
            this.cmbIndexType.Size = new System.Drawing.Size(139, 21);
            this.cmbIndexType.TabIndex = 1;
            this.cmbIndexType.SelectedIndexChanged += new System.EventHandler(this.cmbIndexType_SelectedIndexChanged);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.HelpMessageKey = "IndexArray.Confidence";
            this.label6.Location = new System.Drawing.Point(21, 34);
            this.label6.Name = "label6";
            this.label6.RequiredField = false;
            this.label6.RequiredFieldMarkerFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Size = new System.Drawing.Size(61, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Confidence";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.HelpMessageKey = "IndexArray.Resolution";
            this.label5.Location = new System.Drawing.Point(20, 8);
            this.label5.Name = "label5";
            this.label5.RequiredField = false;
            this.label5.RequiredFieldMarkerFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Size = new System.Drawing.Size(57, 13);
            this.label5.TabIndex = 15;
            this.label5.Text = "Resolution";
            this.label5.Click += new System.EventHandler(this.label5_Click);
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
            this.cmbQualifier.Location = new System.Drawing.Point(315, 56);
            this.cmbQualifier.Name = "cmbQualifier";
            this.cmbQualifier.Size = new System.Drawing.Size(240, 21);
            this.cmbQualifier.Sorted = true;
            this.cmbQualifier.TabIndex = 14;
            // 
            // standardUnitControl
            // 
            this.standardUnitControl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.standardUnitControl.BackColor = System.Drawing.Color.AliceBlue;
            this.standardUnitControl.HasErrors = false;
            this.standardUnitControl.HelpKeyWord = null;
            this.standardUnitControl.LastError = null;
            this.standardUnitControl.Location = new System.Drawing.Point(315, 5);
            this.standardUnitControl.Name = "standardUnitControl";
            this.standardUnitControl.SchemaTypeName = null;
            this.standardUnitControl.Size = new System.Drawing.Size(240, 21);
            this.standardUnitControl.TabIndex = 13;
            this.standardUnitControl.TargetNamespace = null;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.HelpMessageKey = "IndexArray.Dimension";
            this.label4.Location = new System.Drawing.Point(20, 60);
            this.label4.Name = "label4";
            this.label4.RequiredField = false;
            this.label4.RequiredFieldMarkerFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Size = new System.Drawing.Size(61, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Dimensions";
            // 
            // edtDimensions
            // 
            this.edtDimensions.AttributeName = null;
            this.edtDimensions.DataLookupKey = null;
            this.edtDimensions.Location = new System.Drawing.Point(88, 57);
            this.edtDimensions.Name = "edtDimensions";
            this.edtDimensions.Size = new System.Drawing.Size(99, 20);
            this.edtDimensions.TabIndex = 5;
            this.edtDimensions.Value = null;
            this.edtDimensions.ValueType = ATMLCommonLibrary.controls.awb.AWBTextBox.eValueType.xsString;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.HelpMessageKey = "IndexArray.DefUnitQualifier";
            this.label3.Location = new System.Drawing.Point(224, 60);
            this.label3.Name = "label3";
            this.label3.RequiredField = false;
            this.label3.RequiredFieldMarkerFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Size = new System.Drawing.Size(87, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Def Unit Qualifier";
            // 
            // edtNonStandardUnit
            // 
            this.edtNonStandardUnit.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtNonStandardUnit.AttributeName = null;
            this.edtNonStandardUnit.DataLookupKey = null;
            this.edtNonStandardUnit.Location = new System.Drawing.Point(315, 31);
            this.edtNonStandardUnit.Name = "edtNonStandardUnit";
            this.edtNonStandardUnit.Size = new System.Drawing.Size(240, 20);
            this.edtNonStandardUnit.TabIndex = 9;
            this.edtNonStandardUnit.Value = null;
            this.edtNonStandardUnit.ValueType = ATMLCommonLibrary.controls.awb.AWBTextBox.eValueType.xsString;
            this.edtNonStandardUnit.TextChanged += new System.EventHandler(this.edtNonStandardUnit_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.HelpMessageKey = "IndexArray.DefNonStandardUnit";
            this.label2.Location = new System.Drawing.Point(196, 34);
            this.label2.Name = "label2";
            this.label2.RequiredField = false;
            this.label2.RequiredFieldMarkerFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Size = new System.Drawing.Size(115, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Def Non Standard Unit";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.HelpMessageKey = "IndexArray.DefStandardUnit";
            this.label1.Location = new System.Drawing.Point(219, 8);
            this.label1.Name = "label1";
            this.label1.RequiredField = false;
            this.label1.RequiredFieldMarkerFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Size = new System.Drawing.Size(92, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Def Standard Unit";
            // 
            // edtConfidence
            // 
            this.edtConfidence.AttributeName = null;
            this.edtConfidence.DataLookupKey = null;
            this.edtConfidence.Enabled = false;
            this.edtConfidence.Location = new System.Drawing.Point(88, 31);
            this.edtConfidence.Name = "edtConfidence";
            this.edtConfidence.Size = new System.Drawing.Size(99, 20);
            this.edtConfidence.TabIndex = 3;
            this.edtConfidence.Value = null;
            this.edtConfidence.ValueType = ATMLCommonLibrary.controls.awb.AWBTextBox.eValueType.xsString;
            // 
            // edtResolution
            // 
            this.edtResolution.AttributeName = null;
            this.edtResolution.DataLookupKey = null;
            this.edtResolution.Enabled = false;
            this.edtResolution.Location = new System.Drawing.Point(88, 5);
            this.edtResolution.Name = "edtResolution";
            this.edtResolution.Size = new System.Drawing.Size(99, 20);
            this.edtResolution.TabIndex = 1;
            this.edtResolution.Value = null;
            this.edtResolution.ValueType = ATMLCommonLibrary.controls.awb.AWBTextBox.eValueType.xsString;
            // 
            // indexItemControl
            // 
            this.indexItemControl.AllowRowResequencing = false;
            this.indexItemControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.indexItemControl.BackColor = System.Drawing.Color.AliceBlue;
            this.indexItemControl.FormTitle = null;
            this.indexItemControl.HasErrors = false;
            this.indexItemControl.HelpKeyWord = null;
            this.indexItemControl.LastError = null;
            this.indexItemControl.ListName = null;
            this.indexItemControl.Location = new System.Drawing.Point(3, 30);
            this.indexItemControl.Margin = new System.Windows.Forms.Padding(0);
            this.indexItemControl.Name = "indexItemControl";
            this.indexItemControl.SchemaTypeName = null;
            this.indexItemControl.ShowFind = false;
            this.indexItemControl.Size = new System.Drawing.Size(573, 406);
            this.indexItemControl.TabIndex = 4;
            this.indexItemControl.TargetNamespace = null;
            this.indexItemControl.TooltipTextAddButton = "Press to add a new Value";
            this.indexItemControl.TooltipTextDeleteButton = "Press to delete the selected Value";
            this.indexItemControl.TooltipTextEditButton = "Press to edit the selected Value";
            // 
            // edtDefaultValue
            // 
            this.edtDefaultValue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtDefaultValue.AttributeName = null;
            this.edtDefaultValue.DataLookupKey = null;
            this.edtDefaultValue.Location = new System.Drawing.Point(242, 4);
            this.edtDefaultValue.Name = "edtDefaultValue";
            this.edtDefaultValue.Size = new System.Drawing.Size(301, 20);
            this.edtDefaultValue.TabIndex = 3;
            this.edtDefaultValue.Value = null;
            this.edtDefaultValue.ValueType = ATMLCommonLibrary.controls.awb.AWBTextBox.eValueType.xsString;
            // 
            // helpLabel2
            // 
            this.helpLabel2.AutoSize = true;
            this.helpLabel2.HelpMessageKey = "IndexArray.Items.Default";
            this.helpLabel2.Location = new System.Drawing.Point(194, 7);
            this.helpLabel2.Name = "helpLabel2";
            this.helpLabel2.RequiredField = false;
            this.helpLabel2.RequiredFieldMarkerFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.helpLabel2.Size = new System.Drawing.Size(41, 13);
            this.helpLabel2.TabIndex = 2;
            this.helpLabel2.Text = "Default";
            // 
            // helpLabel1
            // 
            this.helpLabel1.AutoSize = true;
            this.helpLabel1.HelpMessageKey = "IndexArray.Items.Type";
            this.helpLabel1.Location = new System.Drawing.Point(6, 7);
            this.helpLabel1.Name = "helpLabel1";
            this.helpLabel1.RequiredField = false;
            this.helpLabel1.RequiredFieldMarkerFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.helpLabel1.Size = new System.Drawing.Size(31, 13);
            this.helpLabel1.TabIndex = 0;
            this.helpLabel1.Text = "Type";
            // 
            // errorLimitControl
            // 
            this.errorLimitControl.BackColor = System.Drawing.Color.AliceBlue;
            this.errorLimitControl.DefaultComparitor = -1;
            this.errorLimitControl.DefaultLimitType = 0;
            this.errorLimitControl.DefaultStandardUnit = null;
            this.errorLimitControl.DefaultValue = null;
            this.errorLimitControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.errorLimitControl.HasErrors = false;
            this.errorLimitControl.HelpKeyWord = null;
            this.errorLimitControl.LastError = null;
            this.errorLimitControl.Location = new System.Drawing.Point(3, 3);
            this.errorLimitControl.Name = "errorLimitControl";
            this.errorLimitControl.SchemaTypeName = null;
            this.errorLimitControl.Size = new System.Drawing.Size(570, 430);
            this.errorLimitControl.TabIndex = 0;
            this.errorLimitControl.TargetNamespace = null;
            // 
            // rangeLimitControl
            // 
            this.rangeLimitControl.BackColor = System.Drawing.Color.AliceBlue;
            this.rangeLimitControl.DefaultComparitor = -1;
            this.rangeLimitControl.DefaultLimitType = 0;
            this.rangeLimitControl.DefaultStandardUnit = null;
            this.rangeLimitControl.DefaultValue = null;
            this.rangeLimitControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rangeLimitControl.HasErrors = false;
            this.rangeLimitControl.HelpKeyWord = null;
            this.rangeLimitControl.LastError = null;
            this.rangeLimitControl.Location = new System.Drawing.Point(3, 3);
            this.rangeLimitControl.Name = "rangeLimitControl";
            this.rangeLimitControl.SchemaTypeName = null;
            this.rangeLimitControl.Size = new System.Drawing.Size(570, 430);
            this.rangeLimitControl.TabIndex = 1;
            this.rangeLimitControl.TargetNamespace = null;
            // 
            // xsdDimensionSchemaValidator
            // 
            this.xsdDimensionSchemaValidator.ControlToValidate = this.edtDimensions;
            this.xsdDimensionSchemaValidator.ErrorMessage = "Invalid Dimension";
            this.xsdDimensionSchemaValidator.ErrorProvider = this.errorProvider1;
            this.xsdDimensionSchemaValidator.Icon = null;
            this.xsdDimensionSchemaValidator.InitialValue = null;
            this.xsdDimensionSchemaValidator.IsEnabled = true;
            this.xsdDimensionSchemaValidator.XSDAttributeName = "dimensions";
            this.xsdDimensionSchemaValidator.XSDTargetNamespace = "urn:IEEE-1671:2010:Common";
            this.xsdDimensionSchemaValidator.XSDTypeName = "IndexedArrayType";
            // 
            // IndexArrayControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cmbQualifier);
            this.Controls.Add(this.standardUnitControl);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.edtDimensions);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.edtNonStandardUnit);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.edtConfidence);
            this.Controls.Add(this.chkConfidence);
            this.Controls.Add(this.edtResolution);
            this.Controls.Add(this.chkResolution);
            this.Controls.Add(this.tabControl1);
            this.Name = "IndexArrayControl";
            this.Size = new System.Drawing.Size(595, 550);
            this.Validating += new System.ComponentModel.CancelEventHandler(this.IndexArrayControl_Validating);
            this.tabErrorLimits.ResumeLayout(false);
            this.tabRange.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabItems.ResumeLayout(false);
            this.tabItems.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
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
        private ATMLCommonLibrary.controls.awb.AWBTextBox edtDimensions;
        private ATMLCommonLibrary.controls.HelpLabel label4;
        private System.Windows.Forms.ComboBox cmbIndexType;
        private HelpLabel helpLabel1;
        private awb.AWBTextBox edtDefaultValue;
        private HelpLabel helpLabel2;
        private lists.ATMLListControl indexItemControl;
        private StandardUnitControl standardUnitControl;
        private QualifierComboBox cmbQualifier;
        private ATMLCommonLibrary.controls.HelpLabel label5;
        private ATMLCommonLibrary.controls.HelpLabel label6;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private validators.XSDSchemaValidator xsdDimensionSchemaValidator;

    }
}
