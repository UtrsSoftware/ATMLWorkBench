/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
*
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

using ATMLCommonLibrary.controls.connector;

namespace ATMLCommonLibrary.controls.power
{
    partial class ACPowerSpecificationControl
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.cmbPhase = new System.Windows.Forms.ComboBox();
            this.connectorLocationPinListControl = new ATMLCommonLibrary.controls.connector.ConnectorLocationPinListControl();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lmtFrequency = new ATMLCommonLibrary.controls.limit.LimitSimpleControl();
            this.lblDescription = new ATMLCommonLibrary.controls.HelpLabel(this.components);
            this.lblConnectorPinLocations = new ATMLCommonLibrary.controls.HelpLabel(this.components);
            this.edtDescription = new ATMLCommonLibrary.controls.awb.AWBTextBox(this.components);
            this.lblPhase = new ATMLCommonLibrary.controls.HelpLabel(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lmtVoltage = new ATMLCommonLibrary.controls.limit.LimitSimpleControl();
            this.gbPower = new System.Windows.Forms.GroupBox();
            this.lmtAmpresPower = new ATMLCommonLibrary.controls.limit.LimitSimpleControl();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.phaseValidator = new ATMLCommonLibrary.controls.validators.RangeFieldValidator();
            this.rbPowerDraw = new System.Windows.Forms.RadioButton();
            this.rbAmpres = new System.Windows.Forms.RadioButton();
            this.lblPower = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.gbPower.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.AutoScrollMargin = new System.Drawing.Size(10, 10);
            this.panel1.Controls.Add(this.cmbPhase);
            this.panel1.Controls.Add(this.connectorLocationPinListControl);
            this.panel1.Controls.Add(this.groupBox3);
            this.panel1.Controls.Add(this.lblDescription);
            this.panel1.Controls.Add(this.lblConnectorPinLocations);
            this.panel1.Controls.Add(this.edtDescription);
            this.panel1.Controls.Add(this.lblPhase);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.gbPower);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(543, 425);
            this.panel1.TabIndex = 0;
            // 
            // cmbPhase
            // 
            this.cmbPhase.FormattingEnabled = true;
            this.cmbPhase.Location = new System.Drawing.Point(83, 209);
            this.cmbPhase.Name = "cmbPhase";
            this.cmbPhase.Size = new System.Drawing.Size(121, 21);
            this.cmbPhase.TabIndex = 9;
            // 
            // connectorLocationPinListControl
            // 
            this.connectorLocationPinListControl.AllowRowResequencing = false;
            this.connectorLocationPinListControl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.connectorLocationPinListControl.BackColor = System.Drawing.Color.AliceBlue;
            this.connectorLocationPinListControl.Connectors = null;
            this.connectorLocationPinListControl.FormTitle = null;
            this.connectorLocationPinListControl.HelpKeyWord = null;
            this.connectorLocationPinListControl.ListName = null;
            this.connectorLocationPinListControl.Location = new System.Drawing.Point(83, 290);
            this.connectorLocationPinListControl.Margin = new System.Windows.Forms.Padding(0);
            this.connectorLocationPinListControl.Name = "connectorLocationPinListControl";
            this.connectorLocationPinListControl.SchemaTypeName = null;
            this.connectorLocationPinListControl.ShowFind = false;
            this.connectorLocationPinListControl.Size = new System.Drawing.Size(439, 122);
            this.connectorLocationPinListControl.TabIndex = 8;
            this.connectorLocationPinListControl.TargetNamespace = null;
            this.connectorLocationPinListControl.TooltipTextAddButton = "Press to add a new ";
            this.connectorLocationPinListControl.TooltipTextDeleteButton = "Press to delete the selected ";
            this.connectorLocationPinListControl.TooltipTextEditButton = "Press to edit the selected ";
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.lmtFrequency);
            this.groupBox3.Location = new System.Drawing.Point(13, 60);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(509, 45);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Frequency";
            // 
            // lmtFrequency
            // 
            this.lmtFrequency.AutoSize = true;
            this.lmtFrequency.BackColor = System.Drawing.Color.AliceBlue;
            this.lmtFrequency.HelpKeyWord = null;
            this.lmtFrequency.Location = new System.Drawing.Point(9, 16);
            this.lmtFrequency.Margin = new System.Windows.Forms.Padding(0);
            this.lmtFrequency.Name = "lmtFrequency";
            this.lmtFrequency.Padding = new System.Windows.Forms.Padding(3);
            this.lmtFrequency.SchemaTypeName = null;
            this.lmtFrequency.Size = new System.Drawing.Size(480, 25);
            this.lmtFrequency.TabIndex = 0;
            this.lmtFrequency.TargetNamespace = null;
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.HelpMessageKey = "ACPowerRequirement.Description";
            this.lblDescription.Location = new System.Drawing.Point(20, 239);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.RequiredField = false;
            this.lblDescription.RequiredFieldMarkerFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescription.Size = new System.Drawing.Size(60, 13);
            this.lblDescription.TabIndex = 5;
            this.lblDescription.Text = "Description";
            // 
            // lblConnectorPinLocations
            // 
            this.lblConnectorPinLocations.HelpMessageKey = "ACPowerRequirement.Pins";
            this.lblConnectorPinLocations.Location = new System.Drawing.Point(20, 290);
            this.lblConnectorPinLocations.Name = "lblConnectorPinLocations";
            this.lblConnectorPinLocations.RequiredField = false;
            this.lblConnectorPinLocations.RequiredFieldMarkerFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConnectorPinLocations.Size = new System.Drawing.Size(60, 45);
            this.lblConnectorPinLocations.TabIndex = 7;
            this.lblConnectorPinLocations.Text = "Connector Pin Locations";
            // 
            // edtDescription
            // 
            this.edtDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtDescription.AttributeName = null;
            this.edtDescription.Location = new System.Drawing.Point(83, 239);
            this.edtDescription.Multiline = true;
            this.edtDescription.Name = "edtDescription";
            this.edtDescription.Size = new System.Drawing.Size(439, 40);
            this.edtDescription.TabIndex = 6;
            this.edtDescription.Value = null;
            this.edtDescription.ValueType = ATMLCommonLibrary.controls.awb.AWBTextBox.eValueType.xsString;
            // 
            // lblPhase
            // 
            this.lblPhase.AutoSize = true;
            this.lblPhase.HelpMessageKey = "ACPowerRequirement.Phase";
            this.lblPhase.Location = new System.Drawing.Point(20, 211);
            this.lblPhase.Name = "lblPhase";
            this.lblPhase.RequiredField = false;
            this.lblPhase.RequiredFieldMarkerFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPhase.Size = new System.Drawing.Size(37, 13);
            this.lblPhase.TabIndex = 3;
            this.lblPhase.Text = "Phase";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.lmtVoltage);
            this.groupBox1.Location = new System.Drawing.Point(13, 10);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(509, 44);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Voltage";
            // 
            // lmtVoltage
            // 
            this.lmtVoltage.AutoSize = true;
            this.lmtVoltage.BackColor = System.Drawing.Color.AliceBlue;
            this.lmtVoltage.HelpKeyWord = null;
            this.lmtVoltage.Location = new System.Drawing.Point(9, 16);
            this.lmtVoltage.Margin = new System.Windows.Forms.Padding(0);
            this.lmtVoltage.Name = "lmtVoltage";
            this.lmtVoltage.Padding = new System.Windows.Forms.Padding(3);
            this.lmtVoltage.SchemaTypeName = null;
            this.lmtVoltage.Size = new System.Drawing.Size(480, 25);
            this.lmtVoltage.TabIndex = 0;
            this.lmtVoltage.TargetNamespace = null;
            // 
            // gbPower
            // 
            this.gbPower.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbPower.Controls.Add(this.pictureBox2);
            this.gbPower.Controls.Add(this.pictureBox1);
            this.gbPower.Controls.Add(this.lblPower);
            this.gbPower.Controls.Add(this.rbPowerDraw);
            this.gbPower.Controls.Add(this.rbAmpres);
            this.gbPower.Controls.Add(this.lmtAmpresPower);
            this.gbPower.Location = new System.Drawing.Point(13, 111);
            this.gbPower.Name = "gbPower";
            this.gbPower.Size = new System.Drawing.Size(509, 89);
            this.gbPower.TabIndex = 2;
            this.gbPower.TabStop = false;
            this.gbPower.Text = "Ampres / Power Draw";
            this.gbPower.Enter += new System.EventHandler(this.gbPower_Enter);
            // 
            // lmtAmpresPower
            // 
            this.lmtAmpresPower.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lmtAmpresPower.BackColor = System.Drawing.Color.AliceBlue;
            this.lmtAmpresPower.HelpKeyWord = null;
            this.lmtAmpresPower.Location = new System.Drawing.Point(113, 54);
            this.lmtAmpresPower.Margin = new System.Windows.Forms.Padding(0);
            this.lmtAmpresPower.Name = "lmtAmpresPower";
            this.lmtAmpresPower.SchemaTypeName = null;
            this.lmtAmpresPower.Size = new System.Drawing.Size(376, 25);
            this.lmtAmpresPower.TabIndex = 2;
            this.lmtAmpresPower.TargetNamespace = null;
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // phaseValidator
            // 
            this.phaseValidator.ControlToValidate = null;
            this.phaseValidator.ErrorMessage = "Phase must be 1, 2 or 3";
            this.phaseValidator.ErrorProvider = this.errorProvider;
            this.phaseValidator.HighRange = 3D;
            this.phaseValidator.Icon = null;
            this.phaseValidator.InitialValue = null;
            this.phaseValidator.IsEnabled = true;
            this.phaseValidator.LowRange = 1D;
            // 
            // rbPowerDraw
            // 
            this.rbPowerDraw.AutoSize = true;
            this.rbPowerDraw.Location = new System.Drawing.Point(19, 54);
            this.rbPowerDraw.Name = "rbPowerDraw";
            this.rbPowerDraw.Size = new System.Drawing.Size(83, 17);
            this.rbPowerDraw.TabIndex = 12;
            this.rbPowerDraw.TabStop = true;
            this.rbPowerDraw.Text = "Power Draw";
            this.rbPowerDraw.UseVisualStyleBackColor = true;
            this.rbPowerDraw.CheckedChanged += new System.EventHandler(this.rbPowerDraw_CheckedChanged);
            // 
            // rbAmpres
            // 
            this.rbAmpres.AutoSize = true;
            this.rbAmpres.Location = new System.Drawing.Point(19, 31);
            this.rbAmpres.Name = "rbAmpres";
            this.rbAmpres.Size = new System.Drawing.Size(60, 17);
            this.rbAmpres.TabIndex = 11;
            this.rbAmpres.TabStop = true;
            this.rbAmpres.Text = "Ampres";
            this.rbAmpres.UseVisualStyleBackColor = true;
            this.rbAmpres.CheckedChanged += new System.EventHandler(this.rbAmpres_CheckedChanged);
            // 
            // lblPower
            // 
            this.lblPower.Location = new System.Drawing.Point(273, 33);
            this.lblPower.Name = "lblPower";
            this.lblPower.Size = new System.Drawing.Size(100, 16);
            this.lblPower.TabIndex = 13;
            this.lblPower.Text = "Ampres";
            this.lblPower.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox1.Location = new System.Drawing.Point(168, 42);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(121, 4);
            this.pictureBox1.TabIndex = 14;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox2.Location = new System.Drawing.Point(357, 42);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(128, 4);
            this.pictureBox2.TabIndex = 15;
            this.pictureBox2.TabStop = false;
            // 
            // ACPowerSpecificationControl
            // 
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MinimumSize = new System.Drawing.Size(543, 300);
            this.Name = "ACPowerSpecificationControl";
            this.Size = new System.Drawing.Size(543, 425);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.gbPower.ResumeLayout(false);
            this.gbPower.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ConnectorLocationPinListControl connectorLocationPinListControl;
        private System.Windows.Forms.GroupBox groupBox3;
        private limit.LimitSimpleControl lmtFrequency;
        private HelpLabel lblDescription;
        private HelpLabel lblConnectorPinLocations;
        private awb.AWBTextBox edtDescription;
        private HelpLabel lblPhase;
        private System.Windows.Forms.GroupBox groupBox1;
        private limit.LimitSimpleControl lmtVoltage;
        private System.Windows.Forms.GroupBox gbPower;
        private System.Windows.Forms.Panel panel1;
        private limit.LimitSimpleControl lmtAmpresPower;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private validators.RangeFieldValidator phaseValidator;
        private System.Windows.Forms.ComboBox cmbPhase;
        private System.Windows.Forms.RadioButton rbPowerDraw;
        private System.Windows.Forms.RadioButton rbAmpres;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblPower;
        private System.Windows.Forms.PictureBox pictureBox2;

    }
}
