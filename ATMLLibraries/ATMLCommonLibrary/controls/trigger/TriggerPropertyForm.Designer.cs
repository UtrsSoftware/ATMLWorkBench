/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
* 
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

namespace ATMLCommonLibrary.controls.trigger
{
    partial class TriggerPropertyForm
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
            this.edtName = new ATMLCommonLibrary.controls.awb.AWBTextBox(this.components);
            this.edtDescription = new ATMLCommonLibrary.controls.awb.AWBTextBox(this.components);
            this.cmbPropertyType = new System.Windows.Forms.ComboBox();
            this.helpLabel1 = new ATMLCommonLibrary.controls.HelpLabel(this.components);
            this.helpLabel2 = new ATMLCommonLibrary.controls.HelpLabel(this.components);
            this.cmbEdgeDetection = new System.Windows.Forms.ComboBox();
            this.helpLabel4 = new ATMLCommonLibrary.controls.HelpLabel(this.components);
            this.cmbLevelDetection = new System.Windows.Forms.ComboBox();
            this.helpLabel5 = new ATMLCommonLibrary.controls.HelpLabel(this.components);
            this.helpLabel6 = new ATMLCommonLibrary.controls.HelpLabel(this.components);
            this.edtLevelTypeValue = new ATMLCommonLibrary.controls.awb.AWBTextBox(this.components);
            this.helpLabel3 = new ATMLCommonLibrary.controls.HelpLabel(this.components);
            this.cmbLevelUnits = new System.Windows.Forms.ComboBox();
            this.helpLabel7 = new ATMLCommonLibrary.controls.HelpLabel(this.components);
            this.helpLabel8 = new ATMLCommonLibrary.controls.HelpLabel(this.components);
            this.edtNumberOfBits = new ATMLCommonLibrary.controls.awb.AWBTextBox(this.components);
            this.gbDigitalTrigger = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.cmbPulseUnits = new System.Windows.Forms.ComboBox();
            this.edtPulseValue = new ATMLCommonLibrary.controls.awb.AWBTextBox(this.components);
            this.helpLabel10 = new ATMLCommonLibrary.controls.HelpLabel(this.components);
            this.helpLabel9 = new ATMLCommonLibrary.controls.HelpLabel(this.components);
            this.gbAnalogTrigger = new System.Windows.Forms.GroupBox();
            this.levelTypeValidator = new ATMLCommonLibrary.controls.validators.NumericFieldValidator();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.numberOfBitsValidator = new ATMLCommonLibrary.controls.validators.NumericFieldValidator();
            this.nameValidator = new ATMLCommonLibrary.controls.validators.RequiredFieldValidator();
            this.panel1.SuspendLayout();
            this.gbDigitalTrigger.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.gbAnalogTrigger.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.gbAnalogTrigger);
            this.panel1.Controls.Add(this.gbDigitalTrigger);
            this.panel1.Controls.Add(this.helpLabel3);
            this.panel1.Controls.Add(this.helpLabel2);
            this.panel1.Controls.Add(this.helpLabel1);
            this.panel1.Controls.Add(this.cmbPropertyType);
            this.panel1.Controls.Add(this.edtDescription);
            this.panel1.Controls.Add(this.edtName);
            this.panel1.Size = new System.Drawing.Size(436, 445);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(374, 464);
            this.btnCancel.TabIndex = 2;
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(293, 464);
            this.btnOk.TabIndex = 1;
            // 
            // lblDenoteRequiredField
            // 
            this.lblDenoteRequiredField.Location = new System.Drawing.Point(1, 475);
            // 
            // edtName
            // 
            this.edtName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtName.AttributeName = null;
            this.edtName.Location = new System.Drawing.Point(107, 38);
            this.edtName.Name = "edtName";
            this.edtName.Size = new System.Drawing.Size(309, 20);
            this.edtName.TabIndex = 3;
            this.edtName.Tag = "";
            this.edtName.Value = null;
            this.edtName.ValueType = ATMLCommonLibrary.controls.awb.AWBTextBox.eValueType.xsString;
            // 
            // edtDescription
            // 
            this.edtDescription.AcceptsReturn = true;
            this.edtDescription.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtDescription.AttributeName = null;
            this.edtDescription.Location = new System.Drawing.Point(107, 65);
            this.edtDescription.Multiline = true;
            this.edtDescription.Name = "edtDescription";
            this.edtDescription.Size = new System.Drawing.Size(309, 49);
            this.edtDescription.TabIndex = 5;
            this.edtDescription.Tag = "";
            this.edtDescription.Value = null;
            this.edtDescription.ValueType = ATMLCommonLibrary.controls.awb.AWBTextBox.eValueType.xsString;
            // 
            // cmbPropertyType
            // 
            this.cmbPropertyType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbPropertyType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPropertyType.FormattingEnabled = true;
            this.cmbPropertyType.Items.AddRange(new object[] {
            "Analog Trigger Property Group",
            "Digital Trigger Property Group",
            "LAN Trigger Property Group",
            "Software Trigger Property Group"});
            this.cmbPropertyType.Location = new System.Drawing.Point(107, 10);
            this.cmbPropertyType.Name = "cmbPropertyType";
            this.cmbPropertyType.Size = new System.Drawing.Size(309, 21);
            this.cmbPropertyType.TabIndex = 1;
            this.cmbPropertyType.SelectedIndexChanged += new System.EventHandler(this.cmbPropertyType_SelectedIndexChanged);
            // 
            // helpLabel1
            // 
            this.helpLabel1.HelpMessageKey = "Trigger.property.name";
            this.helpLabel1.Location = new System.Drawing.Point(11, 38);
            this.helpLabel1.Name = "helpLabel1";
            this.helpLabel1.RequiredField = true;
            this.helpLabel1.RequiredFieldMarkerFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.helpLabel1.Size = new System.Drawing.Size(42, 20);
            this.helpLabel1.TabIndex = 2;
            this.helpLabel1.Text = "Name";
            // 
            // helpLabel2
            // 
            this.helpLabel2.HelpMessageKey = "Trigger.property.description";
            this.helpLabel2.Location = new System.Drawing.Point(11, 65);
            this.helpLabel2.Name = "helpLabel2";
            this.helpLabel2.RequiredField = false;
            this.helpLabel2.RequiredFieldMarkerFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.helpLabel2.Size = new System.Drawing.Size(70, 17);
            this.helpLabel2.TabIndex = 4;
            this.helpLabel2.Text = "Description";
            // 
            // cmbEdgeDetection
            // 
            this.cmbEdgeDetection.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbEdgeDetection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEdgeDetection.FormattingEnabled = true;
            this.cmbEdgeDetection.Location = new System.Drawing.Point(111, 24);
            this.cmbEdgeDetection.Name = "cmbEdgeDetection";
            this.cmbEdgeDetection.Size = new System.Drawing.Size(274, 21);
            this.cmbEdgeDetection.TabIndex = 1;
            // 
            // helpLabel4
            // 
            this.helpLabel4.HelpMessageKey = "Trigger.digital.edge.detection";
            this.helpLabel4.Location = new System.Drawing.Point(14, 24);
            this.helpLabel4.Name = "helpLabel4";
            this.helpLabel4.RequiredField = false;
            this.helpLabel4.RequiredFieldMarkerFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.helpLabel4.Size = new System.Drawing.Size(89, 21);
            this.helpLabel4.TabIndex = 0;
            this.helpLabel4.Text = "Edge Detection";
            // 
            // cmbLevelDetection
            // 
            this.cmbLevelDetection.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbLevelDetection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLevelDetection.FormattingEnabled = true;
            this.cmbLevelDetection.Location = new System.Drawing.Point(111, 52);
            this.cmbLevelDetection.Name = "cmbLevelDetection";
            this.cmbLevelDetection.Size = new System.Drawing.Size(274, 21);
            this.cmbLevelDetection.TabIndex = 3;
            // 
            // helpLabel5
            // 
            this.helpLabel5.HelpMessageKey = "Trigger.digital.level.detection";
            this.helpLabel5.Location = new System.Drawing.Point(14, 52);
            this.helpLabel5.Name = "helpLabel5";
            this.helpLabel5.RequiredField = false;
            this.helpLabel5.RequiredFieldMarkerFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.helpLabel5.Size = new System.Drawing.Size(89, 21);
            this.helpLabel5.TabIndex = 2;
            this.helpLabel5.Text = "Level Detection";
            // 
            // helpLabel6
            // 
            this.helpLabel6.HelpMessageKey = "Trigger.analog.level.type";
            this.helpLabel6.Location = new System.Drawing.Point(15, 20);
            this.helpLabel6.Name = "helpLabel6";
            this.helpLabel6.RequiredField = false;
            this.helpLabel6.RequiredFieldMarkerFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.helpLabel6.Size = new System.Drawing.Size(99, 20);
            this.helpLabel6.TabIndex = 0;
            this.helpLabel6.Text = "Level Type Value";
            this.helpLabel6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // edtLevelTypeValue
            // 
            this.edtLevelTypeValue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtLevelTypeValue.AttributeName = null;
            this.edtLevelTypeValue.Location = new System.Drawing.Point(112, 20);
            this.edtLevelTypeValue.Name = "edtLevelTypeValue";
            this.edtLevelTypeValue.Size = new System.Drawing.Size(274, 20);
            this.edtLevelTypeValue.TabIndex = 1;
            this.edtLevelTypeValue.Tag = "0";
            this.edtLevelTypeValue.Text = "0";
            this.edtLevelTypeValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.edtLevelTypeValue.Value = 0D;
            this.edtLevelTypeValue.ValueType = ATMLCommonLibrary.controls.awb.AWBTextBox.eValueType.xsDouble;
            // 
            // helpLabel3
            // 
            this.helpLabel3.HelpMessageKey = "Trigger.property.type";
            this.helpLabel3.Location = new System.Drawing.Point(11, 10);
            this.helpLabel3.Name = "helpLabel3";
            this.helpLabel3.RequiredField = false;
            this.helpLabel3.RequiredFieldMarkerFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.helpLabel3.Size = new System.Drawing.Size(70, 21);
            this.helpLabel3.TabIndex = 0;
            this.helpLabel3.Text = "Property Type";
            // 
            // cmbLevelUnits
            // 
            this.cmbLevelUnits.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbLevelUnits.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLevelUnits.FormattingEnabled = true;
            this.cmbLevelUnits.Location = new System.Drawing.Point(111, 47);
            this.cmbLevelUnits.Name = "cmbLevelUnits";
            this.cmbLevelUnits.Size = new System.Drawing.Size(273, 21);
            this.cmbLevelUnits.TabIndex = 3;
            // 
            // helpLabel7
            // 
            this.helpLabel7.HelpMessageKey = "Trigger.analog.level.unit";
            this.helpLabel7.Location = new System.Drawing.Point(15, 49);
            this.helpLabel7.Name = "helpLabel7";
            this.helpLabel7.RequiredField = false;
            this.helpLabel7.RequiredFieldMarkerFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.helpLabel7.Size = new System.Drawing.Size(70, 18);
            this.helpLabel7.TabIndex = 2;
            this.helpLabel7.Text = "Level Units";
            // 
            // helpLabel8
            // 
            this.helpLabel8.HelpMessageKey = "Trigger.analog.number_of_bits";
            this.helpLabel8.Location = new System.Drawing.Point(15, 75);
            this.helpLabel8.Name = "helpLabel8";
            this.helpLabel8.RequiredField = false;
            this.helpLabel8.RequiredFieldMarkerFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.helpLabel8.Size = new System.Drawing.Size(89, 20);
            this.helpLabel8.TabIndex = 4;
            this.helpLabel8.Text = "Number of bits";
            this.helpLabel8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // edtNumberOfBits
            // 
            this.edtNumberOfBits.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtNumberOfBits.AttributeName = null;
            this.edtNumberOfBits.Location = new System.Drawing.Point(110, 75);
            this.edtNumberOfBits.Name = "edtNumberOfBits";
            this.edtNumberOfBits.Size = new System.Drawing.Size(274, 20);
            this.edtNumberOfBits.TabIndex = 5;
            this.edtNumberOfBits.Tag = "0";
            this.edtNumberOfBits.Text = "0";
            this.edtNumberOfBits.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.edtNumberOfBits.Value = 0;
            this.edtNumberOfBits.ValueType = ATMLCommonLibrary.controls.awb.AWBTextBox.eValueType.xsInteger;
            // 
            // gbDigitalTrigger
            // 
            this.gbDigitalTrigger.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbDigitalTrigger.Controls.Add(this.groupBox3);
            this.gbDigitalTrigger.Controls.Add(this.cmbLevelDetection);
            this.gbDigitalTrigger.Controls.Add(this.helpLabel4);
            this.gbDigitalTrigger.Controls.Add(this.cmbEdgeDetection);
            this.gbDigitalTrigger.Controls.Add(this.helpLabel5);
            this.gbDigitalTrigger.Location = new System.Drawing.Point(16, 127);
            this.gbDigitalTrigger.Name = "gbDigitalTrigger";
            this.gbDigitalTrigger.Size = new System.Drawing.Size(400, 170);
            this.gbDigitalTrigger.TabIndex = 6;
            this.gbDigitalTrigger.TabStop = false;
            this.gbDigitalTrigger.Text = "Digital Trigger Attributes";
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.cmbPulseUnits);
            this.groupBox3.Controls.Add(this.edtPulseValue);
            this.groupBox3.Controls.Add(this.helpLabel10);
            this.groupBox3.Controls.Add(this.helpLabel9);
            this.groupBox3.Location = new System.Drawing.Point(17, 79);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(368, 78);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Minimum Pulse Width";
            // 
            // cmbPulseUnits
            // 
            this.cmbPulseUnits.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbPulseUnits.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPulseUnits.FormattingEnabled = true;
            this.cmbPulseUnits.Location = new System.Drawing.Point(114, 46);
            this.cmbPulseUnits.Name = "cmbPulseUnits";
            this.cmbPulseUnits.Size = new System.Drawing.Size(229, 21);
            this.cmbPulseUnits.TabIndex = 3;
            // 
            // edtPulseValue
            // 
            this.edtPulseValue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtPulseValue.AttributeName = null;
            this.edtPulseValue.Location = new System.Drawing.Point(115, 19);
            this.edtPulseValue.Name = "edtPulseValue";
            this.edtPulseValue.Size = new System.Drawing.Size(227, 20);
            this.edtPulseValue.TabIndex = 1;
            this.edtPulseValue.Tag = "0";
            this.edtPulseValue.Text = "0";
            this.edtPulseValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.edtPulseValue.Value = 0D;
            this.edtPulseValue.ValueType = ATMLCommonLibrary.controls.awb.AWBTextBox.eValueType.xsDouble;
            // 
            // helpLabel10
            // 
            this.helpLabel10.HelpMessageKey = "Trigger.digital.pulse.unit";
            this.helpLabel10.Location = new System.Drawing.Point(18, 48);
            this.helpLabel10.Name = "helpLabel10";
            this.helpLabel10.RequiredField = false;
            this.helpLabel10.RequiredFieldMarkerFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.helpLabel10.Size = new System.Drawing.Size(70, 18);
            this.helpLabel10.TabIndex = 2;
            this.helpLabel10.Text = "Pulse Units";
            // 
            // helpLabel9
            // 
            this.helpLabel9.HelpMessageKey = "Trigger.digital.pulse.value";
            this.helpLabel9.Location = new System.Drawing.Point(18, 19);
            this.helpLabel9.Name = "helpLabel9";
            this.helpLabel9.RequiredField = false;
            this.helpLabel9.RequiredFieldMarkerFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.helpLabel9.Size = new System.Drawing.Size(99, 20);
            this.helpLabel9.TabIndex = 0;
            this.helpLabel9.Text = "Pulse Value";
            this.helpLabel9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.helpLabel9.Click += new System.EventHandler(this.helpLabel9_Click);
            // 
            // gbAnalogTrigger
            // 
            this.gbAnalogTrigger.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbAnalogTrigger.Controls.Add(this.cmbLevelUnits);
            this.gbAnalogTrigger.Controls.Add(this.edtLevelTypeValue);
            this.gbAnalogTrigger.Controls.Add(this.helpLabel8);
            this.gbAnalogTrigger.Controls.Add(this.helpLabel6);
            this.gbAnalogTrigger.Controls.Add(this.edtNumberOfBits);
            this.gbAnalogTrigger.Controls.Add(this.helpLabel7);
            this.gbAnalogTrigger.Location = new System.Drawing.Point(15, 310);
            this.gbAnalogTrigger.Name = "gbAnalogTrigger";
            this.gbAnalogTrigger.Size = new System.Drawing.Size(401, 117);
            this.gbAnalogTrigger.TabIndex = 7;
            this.gbAnalogTrigger.TabStop = false;
            this.gbAnalogTrigger.Text = "Analog Trigger Attributes";
            // 
            // levelTypeValidator
            // 
            this.levelTypeValidator.ControlToValidate = this.edtLevelTypeValue;
            this.levelTypeValidator.ErrorMessage = "Numeric value required";
            this.levelTypeValidator.ErrorProvider = this.errorProvider;
            this.levelTypeValidator.Icon = null;
            this.levelTypeValidator.InitialValue = null;
            this.levelTypeValidator.IsEnabled = true;
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // numberOfBitsValidator
            // 
            this.numberOfBitsValidator.ControlToValidate = this.edtNumberOfBits;
            this.numberOfBitsValidator.ErrorMessage = "Numeric value required";
            this.numberOfBitsValidator.ErrorProvider = this.errorProvider;
            this.numberOfBitsValidator.Icon = null;
            this.numberOfBitsValidator.InitialValue = null;
            this.numberOfBitsValidator.IsEnabled = true;
            // 
            // nameValidator
            // 
            this.nameValidator.ControlToValidate = this.edtName;
            this.nameValidator.ErrorMessage = "The name is required";
            this.nameValidator.ErrorProvider = this.errorProvider;
            this.nameValidator.Icon = null;
            this.nameValidator.InitialValue = null;
            this.nameValidator.IsEnabled = true;
            // 
            // TriggerPropertyForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(461, 491);
            this.MinimumSize = new System.Drawing.Size(442, 283);
            this.Name = "TriggerPropertyForm";
            this.Text = "Trigger Property Group";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.gbDigitalTrigger.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.gbAnalogTrigger.ResumeLayout(false);
            this.gbAnalogTrigger.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private awb.AWBTextBox edtName;
        private awb.AWBTextBox edtDescription;
        private System.Windows.Forms.ComboBox cmbPropertyType;
        private HelpLabel helpLabel2;
        private HelpLabel helpLabel1;
        private HelpLabel helpLabel8;
        private awb.AWBTextBox edtNumberOfBits;
        private System.Windows.Forms.ComboBox cmbLevelUnits;
        private HelpLabel helpLabel7;
        private HelpLabel helpLabel3;
        private HelpLabel helpLabel6;
        private awb.AWBTextBox edtLevelTypeValue;
        private System.Windows.Forms.ComboBox cmbLevelDetection;
        private HelpLabel helpLabel5;
        private System.Windows.Forms.ComboBox cmbEdgeDetection;
        private HelpLabel helpLabel4;
        private System.Windows.Forms.GroupBox gbAnalogTrigger;
        private System.Windows.Forms.GroupBox gbDigitalTrigger;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ComboBox cmbPulseUnits;
        private awb.AWBTextBox edtPulseValue;
        private HelpLabel helpLabel10;
        private HelpLabel helpLabel9;
        private validators.NumericFieldValidator levelTypeValidator;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private validators.NumericFieldValidator numberOfBitsValidator;
        private validators.RequiredFieldValidator nameValidator;
    }
}