/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
*
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/
namespace ATMLCommonLibrary.controls.connector
{
    partial class ConnectorForm
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
            if( disposing && ( components != null ) )
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConnectorForm));
            this.cmbMatingTypeSex = new System.Windows.Forms.ComboBox();
            this.cmbTypeSex = new System.Windows.Forms.ComboBox();
            this.cmbConnectorPinConfiguration = new System.Windows.Forms.ComboBox();
            this.label6 = new ATMLCommonLibrary.controls.HelpLabel(this.components);
            this.cmbConnectorLocation = new System.Windows.Forms.ComboBox();
            this.label5 = new ATMLCommonLibrary.controls.HelpLabel(this.components);
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabIdentification = new System.Windows.Forms.TabPage();
            this.identificationControl = new ATMLCommonLibrary.controls.IdentificationControl();
            this.tabDescription = new System.Windows.Forms.TabPage();
            this.edtDescription = new ATMLCommonLibrary.controls.awb.AWBTextBox(this.components);
            this.tabPins = new System.Windows.Forms.TabPage();
            this.connectorPinList = new ATMLCommonLibrary.controls.connector.ConnectorPinList();
            this.edtConnectorPinCount = new ATMLCommonLibrary.controls.awb.AWBTextBox(this.components);
            this.label4 = new ATMLCommonLibrary.controls.HelpLabel(this.components);
            this.cbConnectorMatingType = new System.Windows.Forms.ComboBox();
            this.label3 = new ATMLCommonLibrary.controls.HelpLabel(this.components);
            this.cbConnectorType = new System.Windows.Forms.ComboBox();
            this.label2 = new ATMLCommonLibrary.controls.HelpLabel(this.components);
            this.edtConnectorID = new ATMLCommonLibrary.controls.awb.AWBTextBox(this.components);
            this.label1 = new ATMLCommonLibrary.controls.HelpLabel(this.components);
            this.edtName = new ATMLCommonLibrary.controls.awb.AWBTextBox(this.components);
            this.helpLabel1 = new ATMLCommonLibrary.controls.HelpLabel(this.components);
            this.edtVersion = new ATMLCommonLibrary.controls.awb.AWBTextBox(this.components);
            this.helpLabel2 = new ATMLCommonLibrary.controls.HelpLabel(this.components);
            this.btnGeneratePins = new ATMLCommonLibrary.controls.awb.AWBButton();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.requiredIdValidator = new ATMLCommonLibrary.controls.validators.RequiredFieldValidator();
            this.requiredTypeValidator = new ATMLCommonLibrary.controls.validators.RequiredFieldValidator();
            this.requiredLocationValidator = new ATMLCommonLibrary.controls.validators.RequiredFieldValidator();
            this.btnSavePinConfiguration = new ATMLCommonLibrary.controls.awb.AWBButton();
            this.panel1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabIdentification.SuspendLayout();
            this.tabDescription.SuspendLayout();
            this.tabPins.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnSavePinConfiguration);
            this.panel1.Controls.Add(this.btnGeneratePins);
            this.panel1.Controls.Add(this.edtVersion);
            this.panel1.Controls.Add(this.helpLabel2);
            this.panel1.Controls.Add(this.edtName);
            this.panel1.Controls.Add(this.helpLabel1);
            this.panel1.Controls.Add(this.cmbMatingTypeSex);
            this.panel1.Controls.Add(this.cmbTypeSex);
            this.panel1.Controls.Add(this.cmbConnectorPinConfiguration);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.cmbConnectorLocation);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.tabControl1);
            this.panel1.Controls.Add(this.edtConnectorPinCount);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.cbConnectorMatingType);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.cbConnectorType);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.edtConnectorID);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(8, 7);
            this.panel1.Size = new System.Drawing.Size(460, 439);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(395, 451);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(314, 451);
            // 
            // lblDenoteRequiredField
            // 
            this.lblDenoteRequiredField.Location = new System.Drawing.Point(2, 463);
            // 
            // cmbMatingTypeSex
            // 
            this.cmbMatingTypeSex.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbMatingTypeSex.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMatingTypeSex.FormattingEnabled = true;
            this.cmbMatingTypeSex.Items.AddRange(new object[] {
            "Male",
            "Female"});
            this.cmbMatingTypeSex.Location = new System.Drawing.Point(351, 119);
            this.cmbMatingTypeSex.Name = "cmbMatingTypeSex";
            this.cmbMatingTypeSex.Size = new System.Drawing.Size(82, 21);
            this.cmbMatingTypeSex.TabIndex = 11;
            this.cmbMatingTypeSex.SelectedIndexChanged += new System.EventHandler(this.cmbMatingTypeSex_SelectedIndexChanged);
            // 
            // cmbTypeSex
            // 
            this.cmbTypeSex.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbTypeSex.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTypeSex.FormattingEnabled = true;
            this.cmbTypeSex.Items.AddRange(new object[] {
            "Male",
            "Female"});
            this.cmbTypeSex.Location = new System.Drawing.Point(351, 92);
            this.cmbTypeSex.Name = "cmbTypeSex";
            this.cmbTypeSex.Size = new System.Drawing.Size(82, 21);
            this.cmbTypeSex.TabIndex = 8;
            this.cmbTypeSex.SelectedIndexChanged += new System.EventHandler(this.cmbTypeSex_SelectedIndexChanged);
            // 
            // cmbConnectorPinConfiguration
            // 
            this.cmbConnectorPinConfiguration.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbConnectorPinConfiguration.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbConnectorPinConfiguration.FormattingEnabled = true;
            this.cmbConnectorPinConfiguration.Location = new System.Drawing.Point(105, 199);
            this.cmbConnectorPinConfiguration.Name = "cmbConnectorPinConfiguration";
            this.cmbConnectorPinConfiguration.Size = new System.Drawing.Size(300, 21);
            this.cmbConnectorPinConfiguration.TabIndex = 17;
            this.cmbConnectorPinConfiguration.SelectedIndexChanged += new System.EventHandler(this.cmbConnectorPinConfiguration_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.HelpMessageKey = "Connector.pinConfiguration";
            this.label6.Location = new System.Drawing.Point(13, 201);
            this.label6.Name = "label6";
            this.label6.RequiredField = false;
            this.label6.RequiredFieldMarkerFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Size = new System.Drawing.Size(90, 13);
            this.label6.TabIndex = 16;
            this.label6.Text = "Pin Configuration:";
            // 
            // cmbConnectorLocation
            // 
            this.cmbConnectorLocation.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbConnectorLocation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbConnectorLocation.FormattingEnabled = true;
            this.cmbConnectorLocation.Items.AddRange(new object[] {
            "Front",
            "Back"});
            this.cmbConnectorLocation.Location = new System.Drawing.Point(105, 146);
            this.cmbConnectorLocation.Name = "cmbConnectorLocation";
            this.cmbConnectorLocation.Size = new System.Drawing.Size(328, 21);
            this.cmbConnectorLocation.TabIndex = 13;
            // 
            // label5
            // 
            this.label5.HelpMessageKey = "Connector.location";
            this.label5.Location = new System.Drawing.Point(13, 148);
            this.label5.Name = "label5";
            this.label5.RequiredField = true;
            this.label5.RequiredFieldMarkerFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Size = new System.Drawing.Size(90, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Location:";
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabIdentification);
            this.tabControl1.Controls.Add(this.tabDescription);
            this.tabControl1.Controls.Add(this.tabPins);
            this.tabControl1.Location = new System.Drawing.Point(13, 233);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(420, 189);
            this.tabControl1.TabIndex = 18;
            // 
            // tabIdentification
            // 
            this.tabIdentification.Controls.Add(this.identificationControl);
            this.tabIdentification.Location = new System.Drawing.Point(4, 22);
            this.tabIdentification.Name = "tabIdentification";
            this.tabIdentification.Padding = new System.Windows.Forms.Padding(3);
            this.tabIdentification.Size = new System.Drawing.Size(412, 163);
            this.tabIdentification.TabIndex = 1;
            this.tabIdentification.Text = "Identification";
            // 
            // identificationControl
            // 
            this.identificationControl.BackColor = System.Drawing.Color.Transparent;
            this.identificationControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.identificationControl.HasErrors = false;
            this.identificationControl.HelpKeyWord = null;
            this.identificationControl.LastError = null;
            this.identificationControl.Location = new System.Drawing.Point(3, 3);
            this.identificationControl.Name = "identificationControl";
            this.identificationControl.SchemaTypeName = null;
            this.identificationControl.Size = new System.Drawing.Size(406, 157);
            this.identificationControl.TabIndex = 0;
            this.identificationControl.TargetNamespace = null;
            // 
            // tabDescription
            // 
            this.tabDescription.Controls.Add(this.edtDescription);
            this.tabDescription.Location = new System.Drawing.Point(4, 22);
            this.tabDescription.Name = "tabDescription";
            this.tabDescription.Size = new System.Drawing.Size(412, 163);
            this.tabDescription.TabIndex = 2;
            this.tabDescription.Text = "Description";
            this.tabDescription.UseVisualStyleBackColor = true;
            // 
            // edtDescription
            // 
            this.edtDescription.AttributeName = null;
            this.edtDescription.BackColor = System.Drawing.Color.PaleTurquoise;
            this.edtDescription.DataLookupKey = null;
            this.edtDescription.Dock = System.Windows.Forms.DockStyle.Fill;
            this.edtDescription.Location = new System.Drawing.Point(0, 0);
            this.edtDescription.Multiline = true;
            this.edtDescription.Name = "edtDescription";
            this.edtDescription.Size = new System.Drawing.Size(412, 163);
            this.edtDescription.TabIndex = 0;
            this.edtDescription.Tag = "";
            this.edtDescription.Value = null;
            this.edtDescription.ValueType = ATMLCommonLibrary.controls.awb.AWBTextBox.eValueType.xsString;
            // 
            // tabPins
            // 
            this.tabPins.Controls.Add(this.connectorPinList);
            this.tabPins.Location = new System.Drawing.Point(4, 22);
            this.tabPins.Name = "tabPins";
            this.tabPins.Padding = new System.Windows.Forms.Padding(3);
            this.tabPins.Size = new System.Drawing.Size(412, 163);
            this.tabPins.TabIndex = 0;
            this.tabPins.Text = "Pins";
            // 
            // connectorPinList
            // 
            this.connectorPinList.AllowRowResequencing = false;
            this.connectorPinList.BackColor = System.Drawing.Color.AliceBlue;
            this.connectorPinList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.connectorPinList.FormTitle = null;
            this.connectorPinList.HasErrors = false;
            this.connectorPinList.HelpKeyWord = null;
            this.connectorPinList.LastError = null;
            this.connectorPinList.ListName = null;
            this.connectorPinList.Location = new System.Drawing.Point(3, 3);
            this.connectorPinList.Margin = new System.Windows.Forms.Padding(0);
            this.connectorPinList.Name = "connectorPinList";
            this.connectorPinList.SchemaTypeName = null;
            this.connectorPinList.ShowFind = false;
            this.connectorPinList.Size = new System.Drawing.Size(406, 157);
            this.connectorPinList.TabIndex = 0;
            this.connectorPinList.TargetNamespace = null;
            this.connectorPinList.TooltipTextAddButton = "Press to add a new ";
            this.connectorPinList.TooltipTextDeleteButton = "Press to delete the selected ";
            this.connectorPinList.TooltipTextEditButton = "Press to edit the selected ";
            // 
            // edtConnectorPinCount
            // 
            this.edtConnectorPinCount.AttributeName = null;
            this.edtConnectorPinCount.DataLookupKey = null;
            this.edtConnectorPinCount.Location = new System.Drawing.Point(105, 173);
            this.edtConnectorPinCount.Name = "edtConnectorPinCount";
            this.edtConnectorPinCount.Size = new System.Drawing.Size(87, 20);
            this.edtConnectorPinCount.TabIndex = 15;
            this.edtConnectorPinCount.Value = null;
            this.edtConnectorPinCount.ValueType = ATMLCommonLibrary.controls.awb.AWBTextBox.eValueType.xsString;
            this.edtConnectorPinCount.KeyUp += new System.Windows.Forms.KeyEventHandler(this.edtConnectorPinCount_KeyUp);
            // 
            // label4
            // 
            this.label4.HelpMessageKey = "Connector.pinCount";
            this.label4.Location = new System.Drawing.Point(13, 176);
            this.label4.Name = "label4";
            this.label4.RequiredField = false;
            this.label4.RequiredFieldMarkerFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Size = new System.Drawing.Size(90, 13);
            this.label4.TabIndex = 14;
            this.label4.Text = "Pin Count:";
            // 
            // cbConnectorMatingType
            // 
            this.cbConnectorMatingType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbConnectorMatingType.FormattingEnabled = true;
            this.cbConnectorMatingType.Location = new System.Drawing.Point(105, 119);
            this.cbConnectorMatingType.Name = "cbConnectorMatingType";
            this.cbConnectorMatingType.Size = new System.Drawing.Size(223, 21);
            this.cbConnectorMatingType.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.HelpMessageKey = "Connector.matingType";
            this.label3.Location = new System.Drawing.Point(13, 121);
            this.label3.Name = "label3";
            this.label3.RequiredField = false;
            this.label3.RequiredFieldMarkerFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Size = new System.Drawing.Size(90, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Mating Type:";
            // 
            // cbConnectorType
            // 
            this.cbConnectorType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbConnectorType.FormattingEnabled = true;
            this.cbConnectorType.Location = new System.Drawing.Point(105, 92);
            this.cbConnectorType.Name = "cbConnectorType";
            this.cbConnectorType.Size = new System.Drawing.Size(223, 21);
            this.cbConnectorType.TabIndex = 7;
            this.cbConnectorType.SelectedIndexChanged += new System.EventHandler(this.cbConnectorType_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.HelpMessageKey = "Connector.type";
            this.label2.Location = new System.Drawing.Point(13, 94);
            this.label2.Name = "label2";
            this.label2.RequiredField = true;
            this.label2.RequiredFieldMarkerFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Size = new System.Drawing.Size(90, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Type:";
            // 
            // edtConnectorID
            // 
            this.edtConnectorID.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtConnectorID.AttributeName = null;
            this.edtConnectorID.BackColor = System.Drawing.Color.White;
            this.edtConnectorID.DataLookupKey = null;
            this.edtConnectorID.Location = new System.Drawing.Point(105, 14);
            this.edtConnectorID.Name = "edtConnectorID";
            this.edtConnectorID.Size = new System.Drawing.Size(328, 20);
            this.edtConnectorID.TabIndex = 1;
            this.edtConnectorID.Value = null;
            this.edtConnectorID.ValueType = ATMLCommonLibrary.controls.awb.AWBTextBox.eValueType.xsString;
            // 
            // label1
            // 
            this.label1.HelpMessageKey = "Connector.id";
            this.label1.Location = new System.Drawing.Point(13, 17);
            this.label1.Name = "label1";
            this.label1.RequiredField = true;
            this.label1.RequiredFieldMarkerFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Size = new System.Drawing.Size(90, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "ID:";
            // 
            // edtName
            // 
            this.edtName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtName.AttributeName = null;
            this.edtName.DataLookupKey = null;
            this.edtName.Location = new System.Drawing.Point(105, 40);
            this.edtName.Name = "edtName";
            this.edtName.Size = new System.Drawing.Size(328, 20);
            this.edtName.TabIndex = 3;
            this.edtName.Value = null;
            this.edtName.ValueType = ATMLCommonLibrary.controls.awb.AWBTextBox.eValueType.xsString;
            // 
            // helpLabel1
            // 
            this.helpLabel1.HelpMessageKey = "Connector.id";
            this.helpLabel1.Location = new System.Drawing.Point(13, 43);
            this.helpLabel1.Name = "helpLabel1";
            this.helpLabel1.RequiredField = false;
            this.helpLabel1.RequiredFieldMarkerFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.helpLabel1.Size = new System.Drawing.Size(90, 13);
            this.helpLabel1.TabIndex = 2;
            this.helpLabel1.Text = "Name:";
            // 
            // edtVersion
            // 
            this.edtVersion.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtVersion.AttributeName = null;
            this.edtVersion.DataLookupKey = null;
            this.edtVersion.Location = new System.Drawing.Point(105, 66);
            this.edtVersion.Name = "edtVersion";
            this.edtVersion.Size = new System.Drawing.Size(328, 20);
            this.edtVersion.TabIndex = 5;
            this.edtVersion.Value = null;
            this.edtVersion.ValueType = ATMLCommonLibrary.controls.awb.AWBTextBox.eValueType.xsString;
            // 
            // helpLabel2
            // 
            this.helpLabel2.HelpMessageKey = "Connector.id";
            this.helpLabel2.Location = new System.Drawing.Point(13, 69);
            this.helpLabel2.Name = "helpLabel2";
            this.helpLabel2.RequiredField = false;
            this.helpLabel2.RequiredFieldMarkerFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.helpLabel2.Size = new System.Drawing.Size(90, 13);
            this.helpLabel2.TabIndex = 4;
            this.helpLabel2.Text = "Version:";
            // 
            // btnGeneratePins
            // 
            this.btnGeneratePins.Active = true;
            this.btnGeneratePins.BorderColor = System.Drawing.Color.Gray;
            this.btnGeneratePins.ButtonStyle = ATMLCommonLibrary.controls.awb.AWBButton.ButtonStyles.Rectangle;
            this.btnGeneratePins.FlatAppearance.BorderSize = 0;
            this.btnGeneratePins.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGeneratePins.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold);
            this.btnGeneratePins.GradientStyle = ATMLCommonLibrary.controls.awb.AWBButton.GradientStyles.Vertical;
            this.btnGeneratePins.HoverBorderColor = System.Drawing.Color.LightSteelBlue;
            this.btnGeneratePins.HoverColorA = System.Drawing.Color.SteelBlue;
            this.btnGeneratePins.HoverColorB = System.Drawing.Color.SteelBlue;
            this.btnGeneratePins.HoverTextColor = System.Drawing.Color.White;
            this.btnGeneratePins.Image = ((System.Drawing.Image)(resources.GetObject("btnGeneratePins.Image")));
            this.btnGeneratePins.Location = new System.Drawing.Point(198, 170);
            this.btnGeneratePins.Name = "btnGeneratePins";
            this.btnGeneratePins.NormalBorderColor = System.Drawing.Color.SteelBlue;
            this.btnGeneratePins.NormalColorA = System.Drawing.Color.LightSteelBlue;
            this.btnGeneratePins.NormalColorB = System.Drawing.Color.LightSteelBlue;
            this.btnGeneratePins.Size = new System.Drawing.Size(29, 25);
            this.btnGeneratePins.SmoothingQuality = ATMLCommonLibrary.controls.awb.AWBButton.SmoothingQualities.AntiAlias;
            this.btnGeneratePins.TabIndex = 19;
            this.btnGeneratePins.ToolTipText = "Press to generate a list of default connector pins based on the Pin Count.";
            this.btnGeneratePins.UseVisualStyleBackColor = true;
            this.btnGeneratePins.Click += new System.EventHandler(this.btnGeneratePins_Click);
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // requiredIdValidator
            // 
            this.requiredIdValidator.ControlToValidate = this.edtConnectorID;
            this.requiredIdValidator.ErrorMessage = "The Connector ID is required";
            this.requiredIdValidator.ErrorProvider = this.errorProvider;
            this.requiredIdValidator.Icon = null;
            this.requiredIdValidator.InitialValue = null;
            this.requiredIdValidator.IsEnabled = true;
            // 
            // requiredTypeValidator
            // 
            this.requiredTypeValidator.ControlToValidate = this.cbConnectorType;
            this.requiredTypeValidator.ErrorMessage = "The Connector Type is required";
            this.requiredTypeValidator.ErrorProvider = this.errorProvider;
            this.requiredTypeValidator.Icon = null;
            this.requiredTypeValidator.InitialValue = null;
            this.requiredTypeValidator.IsEnabled = true;
            // 
            // requiredLocationValidator
            // 
            this.requiredLocationValidator.ControlToValidate = this.cmbConnectorLocation;
            this.requiredLocationValidator.ErrorMessage = "The Connector Location is required.";
            this.requiredLocationValidator.ErrorProvider = this.errorProvider;
            this.requiredLocationValidator.Icon = null;
            this.requiredLocationValidator.InitialValue = null;
            this.requiredLocationValidator.IsEnabled = true;
            // 
            // btnSavePinConfiguration
            // 
            this.btnSavePinConfiguration.Active = true;
            this.btnSavePinConfiguration.BorderColor = System.Drawing.Color.Gray;
            this.btnSavePinConfiguration.ButtonStyle = ATMLCommonLibrary.controls.awb.AWBButton.ButtonStyles.Rectangle;
            this.btnSavePinConfiguration.FlatAppearance.BorderSize = 0;
            this.btnSavePinConfiguration.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSavePinConfiguration.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold);
            this.btnSavePinConfiguration.GradientStyle = ATMLCommonLibrary.controls.awb.AWBButton.GradientStyles.Vertical;
            this.btnSavePinConfiguration.HoverBorderColor = System.Drawing.Color.LightSteelBlue;
            this.btnSavePinConfiguration.HoverColorA = System.Drawing.Color.SteelBlue;
            this.btnSavePinConfiguration.HoverColorB = System.Drawing.Color.SteelBlue;
            this.btnSavePinConfiguration.HoverTextColor = System.Drawing.Color.White;
            this.btnSavePinConfiguration.Image = ((System.Drawing.Image)(resources.GetObject("btnSavePinConfiguration.Image")));
            this.btnSavePinConfiguration.Location = new System.Drawing.Point(409, 196);
            this.btnSavePinConfiguration.Name = "btnSavePinConfiguration";
            this.btnSavePinConfiguration.NormalBorderColor = System.Drawing.Color.SteelBlue;
            this.btnSavePinConfiguration.NormalColorA = System.Drawing.Color.LightSteelBlue;
            this.btnSavePinConfiguration.NormalColorB = System.Drawing.Color.LightSteelBlue;
            this.btnSavePinConfiguration.Size = new System.Drawing.Size(29, 25);
            this.btnSavePinConfiguration.SmoothingQuality = ATMLCommonLibrary.controls.awb.AWBButton.SmoothingQualities.AntiAlias;
            this.btnSavePinConfiguration.TabIndex = 20;
            this.btnSavePinConfiguration.ToolTipText = "Press to save the pin configuration.";
            this.btnSavePinConfiguration.UseVisualStyleBackColor = true;
            this.btnSavePinConfiguration.Click += new System.EventHandler(this.btnSavePinConfiguration_Click);
            // 
            // ConnectorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(475, 478);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "ConnectorForm";
            this.Text = "Connector";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabIdentification.ResumeLayout(false);
            this.tabDescription.ResumeLayout(false);
            this.tabDescription.PerformLayout();
            this.tabPins.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private controls.HelpLabel label2;
        private ATMLCommonLibrary.controls.awb.AWBTextBox edtConnectorID;
        private controls.HelpLabel label1;
        private ATMLCommonLibrary.controls.awb.AWBTextBox edtConnectorPinCount;
        private controls.HelpLabel label4;
        private System.Windows.Forms.ComboBox cbConnectorMatingType;
        private controls.HelpLabel label3;
        private System.Windows.Forms.ComboBox cbConnectorType;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPins;
        private System.Windows.Forms.TabPage tabIdentification;
        private ConnectorPinList connectorPinList;
        private System.Windows.Forms.ComboBox cmbConnectorLocation;
        private controls.HelpLabel label5;
        private System.Windows.Forms.ComboBox cmbConnectorPinConfiguration;
        private controls.HelpLabel label6;
        private System.Windows.Forms.ComboBox cmbMatingTypeSex;
        private System.Windows.Forms.ComboBox cmbTypeSex;
        private controls.IdentificationControl identificationControl;
        private ATMLCommonLibrary.controls.awb.AWBTextBox edtVersion;
        private controls.HelpLabel helpLabel2;
        private ATMLCommonLibrary.controls.awb.AWBTextBox edtName;
        private controls.HelpLabel helpLabel1;
        private System.Windows.Forms.TabPage tabDescription;
        private ATMLCommonLibrary.controls.awb.AWBTextBox edtDescription;
        private ATMLCommonLibrary.controls.awb.AWBButton btnGeneratePins;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private validators.RequiredFieldValidator requiredIdValidator;
        private validators.RequiredFieldValidator requiredTypeValidator;
        private validators.RequiredFieldValidator requiredLocationValidator;
        private awb.AWBButton btnSavePinConfiguration;
    }
}