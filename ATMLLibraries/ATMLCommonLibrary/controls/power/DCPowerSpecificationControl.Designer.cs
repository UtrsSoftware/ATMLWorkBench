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
    partial class DCPowerSpecificationControl
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
            this.edtRipple = new System.Windows.Forms.NumericUpDown();
            this.edtPolarity = new System.Windows.Forms.NumericUpDown();
            this.gbPower = new System.Windows.Forms.GroupBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblPower = new System.Windows.Forms.Label();
            this.rbPowerDraw = new System.Windows.Forms.RadioButton();
            this.rbAmpres = new System.Windows.Forms.RadioButton();
            this.lmtAmpresPower = new ATMLCommonLibrary.controls.limit.LimitSimpleControl();
            this.edtLimit = new ATMLCommonLibrary.controls.awb.AWBTextBox(this.components);
            this.chkHasRipple = new System.Windows.Forms.CheckBox();
            this.chkHasPolarity = new System.Windows.Forms.CheckBox();
            this.connectorLocationPinListControl = new ATMLCommonLibrary.controls.connector.ConnectorLocationPinListControl();
            this.helpLabel5 = new ATMLCommonLibrary.controls.HelpLabel(this.components);
            this.edtDescription = new ATMLCommonLibrary.controls.awb.AWBTextBox(this.components);
            this.helpLabel4 = new ATMLCommonLibrary.controls.HelpLabel(this.components);
            this.helpLabel3 = new ATMLCommonLibrary.controls.HelpLabel(this.components);
            this.helpLabel2 = new ATMLCommonLibrary.controls.HelpLabel(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lmtVoltage = new ATMLCommonLibrary.controls.limit.LimitSimpleControl();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtRipple)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtPolarity)).BeginInit();
            this.gbPower.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.lmtAmpresPower.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.AutoScrollMargin = new System.Drawing.Size(10, 10);
            this.panel1.Controls.Add(this.edtRipple);
            this.panel1.Controls.Add(this.edtPolarity);
            this.panel1.Controls.Add(this.gbPower);
            this.panel1.Controls.Add(this.chkHasRipple);
            this.panel1.Controls.Add(this.chkHasPolarity);
            this.panel1.Controls.Add(this.connectorLocationPinListControl);
            this.panel1.Controls.Add(this.helpLabel5);
            this.panel1.Controls.Add(this.edtDescription);
            this.panel1.Controls.Add(this.helpLabel4);
            this.panel1.Controls.Add(this.helpLabel3);
            this.panel1.Controls.Add(this.helpLabel2);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.MinimumSize = new System.Drawing.Size(543, 300);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(543, 425);
            this.panel1.TabIndex = 0;
            // 
            // edtRipple
            // 
            this.edtRipple.Location = new System.Drawing.Point(272, 161);
            this.edtRipple.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.edtRipple.Name = "edtRipple";
            this.edtRipple.Size = new System.Drawing.Size(78, 20);
            this.edtRipple.TabIndex = 18;
            this.edtRipple.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // edtPolarity
            // 
            this.edtPolarity.Location = new System.Drawing.Point(103, 161);
            this.edtPolarity.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.edtPolarity.Name = "edtPolarity";
            this.edtPolarity.Size = new System.Drawing.Size(78, 20);
            this.edtPolarity.TabIndex = 17;
            this.edtPolarity.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
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
            this.gbPower.Location = new System.Drawing.Point(13, 63);
            this.gbPower.Name = "gbPower";
            this.gbPower.Size = new System.Drawing.Size(509, 89);
            this.gbPower.TabIndex = 16;
            this.gbPower.TabStop = false;
            this.gbPower.Text = "Ampres / Power Draw";
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
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox1.Location = new System.Drawing.Point(168, 42);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(121, 4);
            this.pictureBox1.TabIndex = 14;
            this.pictureBox1.TabStop = false;
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
            // lmtAmpresPower
            // 
            this.lmtAmpresPower.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lmtAmpresPower.BackColor = System.Drawing.Color.AliceBlue;
            this.lmtAmpresPower.Controls.Add(this.edtLimit);
            this.lmtAmpresPower.HasErrors = false;
            this.lmtAmpresPower.HelpKeyWord = null;
            this.lmtAmpresPower.LastError = null;
            this.lmtAmpresPower.Location = new System.Drawing.Point(113, 54);
            this.lmtAmpresPower.Margin = new System.Windows.Forms.Padding(0);
            this.lmtAmpresPower.Name = "lmtAmpresPower";
            this.lmtAmpresPower.SchemaTypeName = null;
            this.lmtAmpresPower.Size = new System.Drawing.Size(376, 25);
            this.lmtAmpresPower.TabIndex = 2;
            this.lmtAmpresPower.TargetNamespace = null;
            // 
            // edtLimit
            // 
            this.edtLimit.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtLimit.AttributeName = null;
            this.edtLimit.BackColor = System.Drawing.Color.Honeydew;
            this.edtLimit.DataLookupKey = null;
            this.edtLimit.Location = new System.Drawing.Point(52, 0);
            this.edtLimit.Multiline = true;
            this.edtLimit.Name = "edtLimit";
            this.edtLimit.ReadOnly = true;
            this.edtLimit.Size = new System.Drawing.Size(546, 30);
            this.edtLimit.TabIndex = 2;
            this.edtLimit.Value = null;
            this.edtLimit.ValueType = ATMLCommonLibrary.controls.awb.AWBTextBox.eValueType.xsString;
            // 
            // chkHasRipple
            // 
            this.chkHasRipple.AutoSize = true;
            this.chkHasRipple.Location = new System.Drawing.Point(251, 163);
            this.chkHasRipple.Name = "chkHasRipple";
            this.chkHasRipple.Size = new System.Drawing.Size(15, 14);
            this.chkHasRipple.TabIndex = 15;
            this.chkHasRipple.UseVisualStyleBackColor = true;
            this.chkHasRipple.CheckedChanged += new System.EventHandler(this.chkHasRipple_CheckedChanged);
            // 
            // chkHasPolarity
            // 
            this.chkHasPolarity.AutoSize = true;
            this.chkHasPolarity.Location = new System.Drawing.Point(81, 163);
            this.chkHasPolarity.Name = "chkHasPolarity";
            this.chkHasPolarity.Size = new System.Drawing.Size(15, 14);
            this.chkHasPolarity.TabIndex = 14;
            this.chkHasPolarity.UseVisualStyleBackColor = true;
            this.chkHasPolarity.CheckedChanged += new System.EventHandler(this.chkHasPolarity_CheckedChanged);
            // 
            // connectorLocationPinListControl
            // 
            this.connectorLocationPinListControl.AllowRowResequencing = false;
            this.connectorLocationPinListControl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.connectorLocationPinListControl.BackColor = System.Drawing.Color.AliceBlue;
            this.connectorLocationPinListControl.Connectors = null;
            this.connectorLocationPinListControl.FormTitle = null;
            this.connectorLocationPinListControl.HasErrors = false;
            this.connectorLocationPinListControl.HelpKeyWord = null;
            this.connectorLocationPinListControl.LastError = null;
            this.connectorLocationPinListControl.ListName = null;
            this.connectorLocationPinListControl.Location = new System.Drawing.Point(81, 247);
            this.connectorLocationPinListControl.Margin = new System.Windows.Forms.Padding(0);
            this.connectorLocationPinListControl.Name = "connectorLocationPinListControl";
            this.connectorLocationPinListControl.SchemaTypeName = null;
            this.connectorLocationPinListControl.ShowFind = false;
            this.connectorLocationPinListControl.Size = new System.Drawing.Size(441, 161);
            this.connectorLocationPinListControl.TabIndex = 13;
            this.connectorLocationPinListControl.TargetNamespace = null;
            this.connectorLocationPinListControl.TooltipTextAddButton = "Press to add a new ";
            this.connectorLocationPinListControl.TooltipTextDeleteButton = "Press to delete the selected ";
            this.connectorLocationPinListControl.TooltipTextEditButton = "Press to edit the selected ";
            // 
            // helpLabel5
            // 
            this.helpLabel5.HelpMessageKey = "DCPower.ConnectorPins";
            this.helpLabel5.Location = new System.Drawing.Point(15, 247);
            this.helpLabel5.Name = "helpLabel5";
            this.helpLabel5.RequiredField = false;
            this.helpLabel5.RequiredFieldMarkerFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.helpLabel5.Size = new System.Drawing.Size(60, 45);
            this.helpLabel5.TabIndex = 11;
            this.helpLabel5.Text = "Connector Pin Locations";
            // 
            // edtDescription
            // 
            this.edtDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtDescription.AttributeName = null;
            this.edtDescription.DataLookupKey = null;
            this.edtDescription.Location = new System.Drawing.Point(81, 187);
            this.edtDescription.Multiline = true;
            this.edtDescription.Name = "edtDescription";
            this.edtDescription.Size = new System.Drawing.Size(441, 50);
            this.edtDescription.TabIndex = 9;
            this.edtDescription.Value = null;
            this.edtDescription.ValueType = ATMLCommonLibrary.controls.awb.AWBTextBox.eValueType.xsString;
            // 
            // helpLabel4
            // 
            this.helpLabel4.AutoSize = true;
            this.helpLabel4.HelpMessageKey = "DCPower.Description";
            this.helpLabel4.Location = new System.Drawing.Point(15, 187);
            this.helpLabel4.Name = "helpLabel4";
            this.helpLabel4.RequiredField = false;
            this.helpLabel4.RequiredFieldMarkerFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.helpLabel4.Size = new System.Drawing.Size(60, 13);
            this.helpLabel4.TabIndex = 8;
            this.helpLabel4.Text = "Description";
            // 
            // helpLabel3
            // 
            this.helpLabel3.AutoSize = true;
            this.helpLabel3.HelpMessageKey = "DCPower.Ripple";
            this.helpLabel3.Location = new System.Drawing.Point(210, 162);
            this.helpLabel3.Name = "helpLabel3";
            this.helpLabel3.RequiredField = false;
            this.helpLabel3.RequiredFieldMarkerFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.helpLabel3.Size = new System.Drawing.Size(37, 13);
            this.helpLabel3.TabIndex = 6;
            this.helpLabel3.Text = "Ripple";
            // 
            // helpLabel2
            // 
            this.helpLabel2.AutoSize = true;
            this.helpLabel2.HelpMessageKey = "DCPower.Polarity";
            this.helpLabel2.Location = new System.Drawing.Point(15, 162);
            this.helpLabel2.Name = "helpLabel2";
            this.helpLabel2.RequiredField = false;
            this.helpLabel2.RequiredFieldMarkerFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.helpLabel2.Size = new System.Drawing.Size(41, 13);
            this.helpLabel2.TabIndex = 4;
            this.helpLabel2.Text = "Polarity";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.lmtVoltage);
            this.groupBox1.Location = new System.Drawing.Point(13, 10);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(506, 51);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Voltage";
            // 
            // lmtVoltage
            // 
            this.lmtVoltage.BackColor = System.Drawing.Color.AliceBlue;
            this.lmtVoltage.HasErrors = false;
            this.lmtVoltage.HelpKeyWord = null;
            this.lmtVoltage.LastError = null;
            this.lmtVoltage.Location = new System.Drawing.Point(9, 19);
            this.lmtVoltage.Margin = new System.Windows.Forms.Padding(0);
            this.lmtVoltage.Name = "lmtVoltage";
            this.lmtVoltage.SchemaTypeName = null;
            this.lmtVoltage.Size = new System.Drawing.Size(477, 24);
            this.lmtVoltage.TabIndex = 0;
            this.lmtVoltage.TargetNamespace = null;
            // 
            // DCPowerSpecificationControl
            // 
            this.Controls.Add(this.panel1);
            this.MinimumSize = new System.Drawing.Size(543, 300);
            this.Name = "DCPowerSpecificationControl";
            this.Size = new System.Drawing.Size(543, 425);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtRipple)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtPolarity)).EndInit();
            this.gbPower.ResumeLayout(false);
            this.gbPower.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.lmtAmpresPower.ResumeLayout(false);
            this.lmtAmpresPower.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private limit.LimitSimpleControl lmtVoltage;
        private HelpLabel helpLabel3;
        private HelpLabel helpLabel2;
        private HelpLabel helpLabel5;
        private awb.AWBTextBox edtDescription;
        private HelpLabel helpLabel4;
        private ConnectorLocationPinListControl connectorLocationPinListControl;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox chkHasRipple;
        private System.Windows.Forms.CheckBox chkHasPolarity;
        private System.Windows.Forms.GroupBox gbPower;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblPower;
        private System.Windows.Forms.RadioButton rbPowerDraw;
        private System.Windows.Forms.RadioButton rbAmpres;
        private limit.LimitSimpleControl lmtAmpresPower;
        private awb.AWBTextBox edtLimit;
        private System.Windows.Forms.NumericUpDown edtRipple;
        private System.Windows.Forms.NumericUpDown edtPolarity;
    }
}
