/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
*
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/
namespace ATMLCommonLibrary.controls.datum
{
    partial class DatumTypeControl
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
            this.chkResolution = new System.Windows.Forms.CheckBox();
            this.chkConfidence = new System.Windows.Forms.CheckBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabErrorLimits = new System.Windows.Forms.TabPage();
            this.errorLimitControl = new ATMLCommonLibrary.controls.limit.LimitControl();
            this.tabRange = new System.Windows.Forms.TabPage();
            this.limitControl1 = new ATMLCommonLibrary.controls.limit.LimitControl();
            this.object_134654fd_a7d3_4ba1_93a8_0286effd0da7 = new ATMLCommonLibrary.controls.HelpLabel(this.components);
            this.object_2a9fc664_3bae_453a_b818_fca2b73518de = new ATMLCommonLibrary.controls.HelpLabel(this.components);
            this.edtLimitDescription = new ATMLCommonLibrary.controls.awb.AWBTextBox(this.components);
            this.object_03088338_8af9_4459_976b_5b47554aed26 = new ATMLCommonLibrary.controls.HelpLabel(this.components);
            this.edtLimitName = new ATMLCommonLibrary.controls.awb.AWBTextBox(this.components);
            this.object_32b4ebbf_7527_4420_a476_7ddbd3efe3f0 = new ATMLCommonLibrary.controls.HelpLabel(this.components);
            this.cmbDatumType = new System.Windows.Forms.ComboBox();
            this.edtResolution = new System.Windows.Forms.NumericUpDown();
            this.edtConfidence = new System.Windows.Forms.NumericUpDown();
            this.label4 = new ATMLCommonLibrary.controls.HelpLabel(this.components);
            this.label5 = new ATMLCommonLibrary.controls.HelpLabel(this.components);
            this.edtDatum = new ATMLCommonLibrary.controls.datum.DatumTextBox();
            this.qualifierComboBox = new ATMLCommonLibrary.controls.QualifierComboBox(this.components);
            this.standardUnitControl = new ATMLCommonLibrary.controls.StandardUnitControl();
            this.lblValue = new ATMLCommonLibrary.controls.HelpLabel(this.components);
            this.helpLabel1 = new ATMLCommonLibrary.controls.HelpLabel(this.components);
            this.label3 = new ATMLCommonLibrary.controls.HelpLabel(this.components);
            this.edtNonStandardUnit = new ATMLCommonLibrary.controls.awb.AWBTextBox(this.components);
            this.label2 = new ATMLCommonLibrary.controls.HelpLabel(this.components);
            this.label1 = new ATMLCommonLibrary.controls.HelpLabel(this.components);
            this.rangeLimitControl = new ATMLCommonLibrary.controls.limit.LimitControl();
            this.label6 = new ATMLCommonLibrary.controls.HelpLabel(this.components);
            this.label7 = new ATMLCommonLibrary.controls.HelpLabel(this.components);
            this.tabControl1.SuspendLayout();
            this.tabErrorLimits.SuspendLayout();
            this.tabRange.SuspendLayout();
            this.limitControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtResolution)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtConfidence)).BeginInit();
            this.SuspendLayout();
            // 
            // chkResolution
            // 
            this.chkResolution.AutoSize = true;
            this.chkResolution.Location = new System.Drawing.Point(6, 35);
            this.chkResolution.Name = "chkResolution";
            this.chkResolution.Size = new System.Drawing.Size(15, 14);
            this.chkResolution.TabIndex = 2;
            this.chkResolution.UseVisualStyleBackColor = true;
            this.chkResolution.CheckedChanged += new System.EventHandler(this.chkResolution_CheckedChanged);
            // 
            // chkConfidence
            // 
            this.chkConfidence.AutoSize = true;
            this.chkConfidence.Location = new System.Drawing.Point(6, 61);
            this.chkConfidence.Name = "chkConfidence";
            this.chkConfidence.Size = new System.Drawing.Size(15, 14);
            this.chkConfidence.TabIndex = 4;
            this.chkConfidence.UseVisualStyleBackColor = true;
            this.chkConfidence.CheckedChanged += new System.EventHandler(this.chkConfidence_CheckedChanged);
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabErrorLimits);
            this.tabControl1.Controls.Add(this.tabRange);
            this.tabControl1.Location = new System.Drawing.Point(6, 109);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(583, 466);
            this.tabControl1.TabIndex = 16;
            // 
            // tabErrorLimits
            // 
            this.tabErrorLimits.Controls.Add(this.errorLimitControl);
            this.tabErrorLimits.Location = new System.Drawing.Point(4, 22);
            this.tabErrorLimits.Name = "tabErrorLimits";
            this.tabErrorLimits.Padding = new System.Windows.Forms.Padding(3);
            this.tabErrorLimits.Size = new System.Drawing.Size(575, 440);
            this.tabErrorLimits.TabIndex = 0;
            this.tabErrorLimits.Text = "Error Limits";
            this.tabErrorLimits.UseVisualStyleBackColor = true;
            // 
            // errorLimitControl
            // 
            this.errorLimitControl.AutoScroll = true;
            this.errorLimitControl.BackColor = System.Drawing.Color.AliceBlue;
            this.errorLimitControl.DefaultComparitor = 0;
            this.errorLimitControl.DefaultLimitType = 0;
            this.errorLimitControl.DefaultStandardUnit = null;
            this.errorLimitControl.DefaultValue = null;
            this.errorLimitControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.errorLimitControl.HasErrors = false;
            this.errorLimitControl.HelpKeyWord = null;
            this.errorLimitControl.LastError = null;
            this.errorLimitControl.Location = new System.Drawing.Point(3, 3);
            this.errorLimitControl.MinimumSize = new System.Drawing.Size(569, 434);
            this.errorLimitControl.Name = "errorLimitControl";
            this.errorLimitControl.SchemaTypeName = null;
            this.errorLimitControl.Size = new System.Drawing.Size(569, 434);
            this.errorLimitControl.TabIndex = 0;
            this.errorLimitControl.TargetNamespace = null;
            // 
            // tabRange
            // 
            this.tabRange.Controls.Add(this.limitControl1);
            this.tabRange.Location = new System.Drawing.Point(4, 22);
            this.tabRange.Name = "tabRange";
            this.tabRange.Padding = new System.Windows.Forms.Padding(3);
            this.tabRange.Size = new System.Drawing.Size(575, 440);
            this.tabRange.TabIndex = 1;
            this.tabRange.Text = "Range";
            this.tabRange.UseVisualStyleBackColor = true;
            // 
            // limitControl1
            // 
            this.limitControl1.AutoScroll = true;
            this.limitControl1.BackColor = System.Drawing.Color.AliceBlue;
            this.limitControl1.Controls.Add(this.object_134654fd_a7d3_4ba1_93a8_0286effd0da7);
            this.limitControl1.Controls.Add(this.object_2a9fc664_3bae_453a_b818_fca2b73518de);
            this.limitControl1.Controls.Add(this.edtLimitDescription);
            this.limitControl1.Controls.Add(this.object_03088338_8af9_4459_976b_5b47554aed26);
            this.limitControl1.Controls.Add(this.edtLimitName);
            this.limitControl1.Controls.Add(this.object_32b4ebbf_7527_4420_a476_7ddbd3efe3f0);
            this.limitControl1.DefaultComparitor = 0;
            this.limitControl1.DefaultLimitType = 0;
            this.limitControl1.DefaultStandardUnit = null;
            this.limitControl1.DefaultValue = null;
            this.limitControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.limitControl1.HasErrors = false;
            this.limitControl1.HelpKeyWord = null;
            this.limitControl1.LastError = null;
            this.limitControl1.Location = new System.Drawing.Point(3, 3);
            this.limitControl1.MinimumSize = new System.Drawing.Size(569, 434);
            this.limitControl1.Name = "limitControl1";
            this.limitControl1.SchemaTypeName = null;
            this.limitControl1.Size = new System.Drawing.Size(569, 434);
            this.limitControl1.TabIndex = 1;
            this.limitControl1.TargetNamespace = null;
            // 
            // object_134654fd_a7d3_4ba1_93a8_0286effd0da7
            // 
            this.object_134654fd_a7d3_4ba1_93a8_0286effd0da7.AutoSize = true;
            this.object_134654fd_a7d3_4ba1_93a8_0286effd0da7.HelpMessageKey = null;
            this.object_134654fd_a7d3_4ba1_93a8_0286effd0da7.Location = new System.Drawing.Point(226, 170);
            this.object_134654fd_a7d3_4ba1_93a8_0286effd0da7.Name = "object_134654fd_a7d3_4ba1_93a8_0286effd0da7";
            this.object_134654fd_a7d3_4ba1_93a8_0286effd0da7.RequiredField = false;
            this.object_134654fd_a7d3_4ba1_93a8_0286effd0da7.RequiredFieldMarkerFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.object_134654fd_a7d3_4ba1_93a8_0286effd0da7.Size = new System.Drawing.Size(55, 13);
            this.object_134654fd_a7d3_4ba1_93a8_0286effd0da7.TabIndex = 9;
            this.object_134654fd_a7d3_4ba1_93a8_0286effd0da7.Text = "Limit Type";
            // 
            // object_2a9fc664_3bae_453a_b818_fca2b73518de
            // 
            this.object_2a9fc664_3bae_453a_b818_fca2b73518de.AutoSize = true;
            this.object_2a9fc664_3bae_453a_b818_fca2b73518de.HelpMessageKey = null;
            this.object_2a9fc664_3bae_453a_b818_fca2b73518de.Location = new System.Drawing.Point(14, 171);
            this.object_2a9fc664_3bae_453a_b818_fca2b73518de.Name = "object_2a9fc664_3bae_453a_b818_fca2b73518de";
            this.object_2a9fc664_3bae_453a_b818_fca2b73518de.RequiredField = false;
            this.object_2a9fc664_3bae_453a_b818_fca2b73518de.RequiredFieldMarkerFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.object_2a9fc664_3bae_453a_b818_fca2b73518de.Size = new System.Drawing.Size(48, 13);
            this.object_2a9fc664_3bae_453a_b818_fca2b73518de.TabIndex = 7;
            this.object_2a9fc664_3bae_453a_b818_fca2b73518de.Text = "Operator";
            // 
            // edtLimitDescription
            // 
            this.edtLimitDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtLimitDescription.AttributeName = null;
            this.edtLimitDescription.DataLookupKey = null;
            this.edtLimitDescription.Location = new System.Drawing.Point(81, 39);
            this.edtLimitDescription.Multiline = true;
            this.edtLimitDescription.Name = "edtLimitDescription";
            this.edtLimitDescription.Size = new System.Drawing.Size(469, 82);
            this.edtLimitDescription.TabIndex = 3;
            this.edtLimitDescription.Value = null;
            this.edtLimitDescription.ValueType = ATMLCommonLibrary.controls.awb.AWBTextBox.eValueType.xsString;
            // 
            // object_03088338_8af9_4459_976b_5b47554aed26
            // 
            this.object_03088338_8af9_4459_976b_5b47554aed26.AutoSize = true;
            this.object_03088338_8af9_4459_976b_5b47554aed26.HelpMessageKey = null;
            this.object_03088338_8af9_4459_976b_5b47554aed26.Location = new System.Drawing.Point(14, 39);
            this.object_03088338_8af9_4459_976b_5b47554aed26.Name = "object_03088338_8af9_4459_976b_5b47554aed26";
            this.object_03088338_8af9_4459_976b_5b47554aed26.RequiredField = false;
            this.object_03088338_8af9_4459_976b_5b47554aed26.RequiredFieldMarkerFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.object_03088338_8af9_4459_976b_5b47554aed26.Size = new System.Drawing.Size(60, 13);
            this.object_03088338_8af9_4459_976b_5b47554aed26.TabIndex = 2;
            this.object_03088338_8af9_4459_976b_5b47554aed26.Text = "Description";
            // 
            // edtLimitName
            // 
            this.edtLimitName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtLimitName.AttributeName = null;
            this.edtLimitName.DataLookupKey = null;
            this.edtLimitName.Location = new System.Drawing.Point(81, 13);
            this.edtLimitName.Name = "edtLimitName";
            this.edtLimitName.Size = new System.Drawing.Size(469, 20);
            this.edtLimitName.TabIndex = 1;
            this.edtLimitName.Value = null;
            this.edtLimitName.ValueType = ATMLCommonLibrary.controls.awb.AWBTextBox.eValueType.xsString;
            // 
            // object_32b4ebbf_7527_4420_a476_7ddbd3efe3f0
            // 
            this.object_32b4ebbf_7527_4420_a476_7ddbd3efe3f0.AutoSize = true;
            this.object_32b4ebbf_7527_4420_a476_7ddbd3efe3f0.HelpMessageKey = null;
            this.object_32b4ebbf_7527_4420_a476_7ddbd3efe3f0.Location = new System.Drawing.Point(14, 13);
            this.object_32b4ebbf_7527_4420_a476_7ddbd3efe3f0.Name = "object_32b4ebbf_7527_4420_a476_7ddbd3efe3f0";
            this.object_32b4ebbf_7527_4420_a476_7ddbd3efe3f0.RequiredField = false;
            this.object_32b4ebbf_7527_4420_a476_7ddbd3efe3f0.RequiredFieldMarkerFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.object_32b4ebbf_7527_4420_a476_7ddbd3efe3f0.Size = new System.Drawing.Size(35, 13);
            this.object_32b4ebbf_7527_4420_a476_7ddbd3efe3f0.TabIndex = 0;
            this.object_32b4ebbf_7527_4420_a476_7ddbd3efe3f0.Text = "Name";
            // 
            // cmbDatumType
            // 
            this.cmbDatumType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDatumType.FormattingEnabled = true;
            this.cmbDatumType.Location = new System.Drawing.Point(89, 6);
            this.cmbDatumType.Name = "cmbDatumType";
            this.cmbDatumType.Size = new System.Drawing.Size(112, 21);
            this.cmbDatumType.TabIndex = 1;
            this.cmbDatumType.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // edtResolution
            // 
            this.edtResolution.DecimalPlaces = 3;
            this.edtResolution.Location = new System.Drawing.Point(89, 34);
            this.edtResolution.Name = "edtResolution";
            this.edtResolution.Size = new System.Drawing.Size(112, 20);
            this.edtResolution.TabIndex = 3;
            this.edtResolution.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // edtConfidence
            // 
            this.edtConfidence.DecimalPlaces = 3;
            this.edtConfidence.Location = new System.Drawing.Point(89, 61);
            this.edtConfidence.Name = "edtConfidence";
            this.edtConfidence.Size = new System.Drawing.Size(112, 20);
            this.edtConfidence.TabIndex = 5;
            this.edtConfidence.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.HelpMessageKey = null;
            this.label4.Location = new System.Drawing.Point(200, 36);
            this.label4.Name = "label4";
            this.label4.RequiredField = false;
            this.label4.RequiredFieldMarkerFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Size = new System.Drawing.Size(21, 16);
            this.label4.TabIndex = 8;
            this.label4.Text = "%";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.HelpMessageKey = null;
            this.label5.Location = new System.Drawing.Point(200, 63);
            this.label5.Name = "label5";
            this.label5.RequiredField = false;
            this.label5.RequiredFieldMarkerFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Size = new System.Drawing.Size(21, 16);
            this.label5.TabIndex = 11;
            this.label5.Text = "%";
            // 
            // edtDatum
            // 
            this.edtDatum.BackColor = System.Drawing.Color.AliceBlue;
            this.edtDatum.DatumTypeIndex = -1;
            this.edtDatum.HasErrors = false;
            this.edtDatum.HelpKeyWord = null;
            this.edtDatum.Label = null;
            this.edtDatum.LastError = null;
            this.edtDatum.Location = new System.Drawing.Point(327, 5);
            this.edtDatum.Name = "edtDatum";
            this.edtDatum.SchemaTypeName = null;
            this.edtDatum.Size = new System.Drawing.Size(236, 20);
            this.edtDatum.TabIndex = 7;
            this.edtDatum.TargetNamespace = null;
            this.edtDatum.Value = null;
            // 
            // qualifierComboBox
            // 
            this.qualifierComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.qualifierComboBox.FormattingEnabled = true;
            this.qualifierComboBox.Location = new System.Drawing.Point(326, 86);
            this.qualifierComboBox.Name = "qualifierComboBox";
            this.qualifierComboBox.Size = new System.Drawing.Size(237, 21);
            this.qualifierComboBox.Sorted = true;
            this.qualifierComboBox.TabIndex = 15;
            // 
            // standardUnitControl
            // 
            this.standardUnitControl.BackColor = System.Drawing.Color.AliceBlue;
            this.standardUnitControl.HasErrors = false;
            this.standardUnitControl.HelpKeyWord = null;
            this.standardUnitControl.LastError = null;
            this.standardUnitControl.Location = new System.Drawing.Point(327, 32);
            this.standardUnitControl.Name = "standardUnitControl";
            this.standardUnitControl.SchemaTypeName = null;
            this.standardUnitControl.Size = new System.Drawing.Size(236, 21);
            this.standardUnitControl.TabIndex = 10;
            this.standardUnitControl.TargetNamespace = null;
            // 
            // lblValue
            // 
            this.lblValue.HelpMessageKey = "DatumType.Value";
            this.lblValue.Location = new System.Drawing.Point(228, 6);
            this.lblValue.Name = "lblValue";
            this.lblValue.RequiredField = false;
            this.lblValue.RequiredFieldMarkerFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValue.Size = new System.Drawing.Size(92, 20);
            this.lblValue.TabIndex = 6;
            this.lblValue.Text = "Value";
            this.lblValue.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // helpLabel1
            // 
            this.helpLabel1.AutoSize = true;
            this.helpLabel1.HelpMessageKey = "DatumType.DatumType";
            this.helpLabel1.Location = new System.Drawing.Point(17, 10);
            this.helpLabel1.Name = "helpLabel1";
            this.helpLabel1.RequiredField = false;
            this.helpLabel1.RequiredFieldMarkerFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.helpLabel1.Size = new System.Drawing.Size(65, 13);
            this.helpLabel1.TabIndex = 0;
            this.helpLabel1.Text = "Datum Type";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.HelpMessageKey = "DatumType.UnitQualifier";
            this.label3.Location = new System.Drawing.Point(253, 88);
            this.label3.Name = "label3";
            this.label3.RequiredField = false;
            this.label3.RequiredFieldMarkerFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Size = new System.Drawing.Size(67, 13);
            this.label3.TabIndex = 14;
            this.label3.Text = "Unit Qualifier";
            // 
            // edtNonStandardUnit
            // 
            this.edtNonStandardUnit.AttributeName = null;
            this.edtNonStandardUnit.DataLookupKey = null;
            this.edtNonStandardUnit.Location = new System.Drawing.Point(326, 59);
            this.edtNonStandardUnit.Name = "edtNonStandardUnit";
            this.edtNonStandardUnit.Size = new System.Drawing.Size(237, 20);
            this.edtNonStandardUnit.TabIndex = 13;
            this.edtNonStandardUnit.Value = null;
            this.edtNonStandardUnit.ValueType = ATMLCommonLibrary.controls.awb.AWBTextBox.eValueType.xsString;
            this.edtNonStandardUnit.KeyUp += new System.Windows.Forms.KeyEventHandler(this.edtNonStandardUnit_KeyUp);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.HelpMessageKey = "DatumType.NonStandardUnit";
            this.label2.Location = new System.Drawing.Point(225, 62);
            this.label2.Name = "label2";
            this.label2.RequiredField = false;
            this.label2.RequiredFieldMarkerFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Size = new System.Drawing.Size(95, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Non Standard Unit";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.HelpMessageKey = "DatumType.StandardUnit";
            this.label1.Location = new System.Drawing.Point(248, 36);
            this.label1.Name = "label1";
            this.label1.RequiredField = false;
            this.label1.RequiredFieldMarkerFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Size = new System.Drawing.Size(72, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Standard Unit";
            // 
            // rangeLimitControl
            // 
            this.rangeLimitControl.BackColor = System.Drawing.Color.AliceBlue;
            this.rangeLimitControl.DefaultComparitor = 0;
            this.rangeLimitControl.DefaultLimitType = 0;
            this.rangeLimitControl.DefaultStandardUnit = null;
            this.rangeLimitControl.DefaultValue = null;
            this.rangeLimitControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rangeLimitControl.HasErrors = false;
            this.rangeLimitControl.HelpKeyWord = null;
            this.rangeLimitControl.LastError = null;
            this.rangeLimitControl.Location = new System.Drawing.Point(3, 3);
            this.rangeLimitControl.MinimumSize = new System.Drawing.Size(569, 434);
            this.rangeLimitControl.Name = "rangeLimitControl";
            this.rangeLimitControl.SchemaTypeName = null;
            this.rangeLimitControl.Size = new System.Drawing.Size(569, 434);
            this.rangeLimitControl.TabIndex = 1;
            this.rangeLimitControl.TargetNamespace = null;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.HelpMessageKey = "DatumType.Resolution";
            this.label6.Location = new System.Drawing.Point(22, 36);
            this.label6.Name = "label6";
            this.label6.RequiredField = false;
            this.label6.RequiredFieldMarkerFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Size = new System.Drawing.Size(57, 13);
            this.label6.TabIndex = 17;
            this.label6.Text = "Resolution";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.HelpMessageKey = "DatumType.Confidence";
            this.label7.Location = new System.Drawing.Point(22, 62);
            this.label7.Name = "label7";
            this.label7.RequiredField = false;
            this.label7.RequiredFieldMarkerFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Size = new System.Drawing.Size(61, 13);
            this.label7.TabIndex = 18;
            this.label7.Text = "Confidence";
            // 
            // DatumTypeControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.edtConfidence);
            this.Controls.Add(this.edtResolution);
            this.Controls.Add(this.edtDatum);
            this.Controls.Add(this.qualifierComboBox);
            this.Controls.Add(this.standardUnitControl);
            this.Controls.Add(this.lblValue);
            this.Controls.Add(this.cmbDatumType);
            this.Controls.Add(this.helpLabel1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.edtNonStandardUnit);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.chkConfidence);
            this.Controls.Add(this.chkResolution);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.HelpKeyWord = "Datum Type";
            this.MinimumSize = new System.Drawing.Size(594, 548);
            this.Name = "DatumTypeControl";
            this.Size = new System.Drawing.Size(594, 578);
            this.Validating += new System.ComponentModel.CancelEventHandler(this.DatumTypeControl_Validating);
            this.tabControl1.ResumeLayout(false);
            this.tabErrorLimits.ResumeLayout(false);
            this.tabRange.ResumeLayout(false);
            this.limitControl1.ResumeLayout(false);
            this.limitControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtResolution)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtConfidence)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected System.Windows.Forms.CheckBox chkResolution;
        protected System.Windows.Forms.CheckBox chkConfidence;
        protected ATMLCommonLibrary.controls.HelpLabel label1;
        protected ATMLCommonLibrary.controls.awb.AWBTextBox edtNonStandardUnit;
        protected ATMLCommonLibrary.controls.HelpLabel label2;
        protected ATMLCommonLibrary.controls.HelpLabel label3;
        protected System.Windows.Forms.TabControl tabControl1;
        protected System.Windows.Forms.TabPage tabErrorLimits;
        protected limit.LimitControl errorLimitControl;
        protected System.Windows.Forms.TabPage tabRange;
        protected limit.LimitControl rangeLimitControl;
        protected HelpLabel helpLabel1;
        protected System.Windows.Forms.ComboBox cmbDatumType;
        protected HelpLabel lblValue;
        private StandardUnitControl standardUnitControl;
        private QualifierComboBox qualifierComboBox;
        private datum.DatumTextBox edtDatum;
        private System.Windows.Forms.NumericUpDown edtResolution;
        private System.Windows.Forms.NumericUpDown edtConfidence;
        private ATMLCommonLibrary.controls.HelpLabel label4;
        private ATMLCommonLibrary.controls.HelpLabel label5;
        protected limit.LimitControl limitControl1;
        private HelpLabel object_134654fd_a7d3_4ba1_93a8_0286effd0da7;
        private HelpLabel object_2a9fc664_3bae_453a_b818_fca2b73518de;
        private awb.AWBTextBox edtLimitDescription;
        private HelpLabel object_03088338_8af9_4459_976b_5b47554aed26;
        private awb.AWBTextBox edtLimitName;
        private HelpLabel object_32b4ebbf_7527_4420_a476_7ddbd3efe3f0;
        private ATMLCommonLibrary.controls.HelpLabel label6;
        private ATMLCommonLibrary.controls.HelpLabel label7;
    }
}
