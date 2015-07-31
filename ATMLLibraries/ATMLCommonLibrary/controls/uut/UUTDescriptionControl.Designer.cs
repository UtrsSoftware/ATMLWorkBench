/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
*
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

using ATMLCommonLibrary.controls.awb;

namespace ATMLCommonLibrary.controls
{
    partial class UUTDescriptionControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UUTDescriptionControl));
            this.edtName = new System.Windows.Forms.TextBox();
            this.edtUUID = new ATMLCommonLibrary.controls.awb.AWBTextBox(this.components);
            this.edtVersion = new ATMLCommonLibrary.controls.awb.AWBTextBox(this.components);
            this.btnAddUUID = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbSoftware = new System.Windows.Forms.RadioButton();
            this.rbHardware = new System.Windows.Forms.RadioButton();
            this.panelUUT = new System.Windows.Forms.Panel();
            this.softwareUUTControl = new ATMLCommonLibrary.controls.uut.SoftwareUUTControl();
            this.hardwareUUTControl = new ATMLCommonLibrary.controls.uut.HardwareUUTControl();
            this.securityClassificationControl = new WindowsFormsApplication10.SecurityClassificationControl();
            this.label2 = new ATMLCommonLibrary.controls.HelpLabel(this.components);
            this.label1 = new ATMLCommonLibrary.controls.HelpLabel(this.components);
            this.label3 = new ATMLCommonLibrary.controls.HelpLabel(this.components);
            this.label6 = new ATMLCommonLibrary.controls.HelpLabel(this.components);
            this.requiredUUIDValidator = new ATMLCommonLibrary.controls.validators.RequiredFieldValidator();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.groupBox1.SuspendLayout();
            this.panelUUT.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // edtName
            // 
            this.edtName.Location = new System.Drawing.Point(62, 10);
            this.edtName.Name = "edtName";
            this.edtName.Size = new System.Drawing.Size(489, 20);
            this.edtName.TabIndex = 1;
            // 
            // edtUUID
            // 
            this.edtUUID.AttributeName = null;
            this.edtUUID.Location = new System.Drawing.Point(62, 62);
            this.edtUUID.Name = "edtUUID";
            this.edtUUID.Size = new System.Drawing.Size(488, 20);
            this.edtUUID.TabIndex = 7;
            this.edtUUID.Value = null;
            this.edtUUID.ValueType = ATMLCommonLibrary.controls.awb.AWBTextBox.eValueType.xsString;
            // 
            // edtVersion
            // 
            this.edtVersion.AttributeName = null;
            this.edtVersion.Location = new System.Drawing.Point(62, 36);
            this.edtVersion.Name = "edtVersion";
            this.edtVersion.Size = new System.Drawing.Size(100, 20);
            this.edtVersion.TabIndex = 3;
            this.edtVersion.Value = null;
            this.edtVersion.ValueType = ATMLCommonLibrary.controls.awb.AWBTextBox.eValueType.xsString;
            // 
            // btnAddUUID
            // 
            this.btnAddUUID.BackColor = System.Drawing.Color.Transparent;
            this.btnAddUUID.FlatAppearance.BorderSize = 0;
            this.btnAddUUID.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddUUID.Image = ((System.Drawing.Image)(resources.GetObject("btnAddUUID.Image")));
            this.btnAddUUID.Location = new System.Drawing.Point(530, 62);
            this.btnAddUUID.Name = "btnAddUUID";
            this.btnAddUUID.Size = new System.Drawing.Size(20, 20);
            this.btnAddUUID.TabIndex = 8;
            this.btnAddUUID.UseVisualStyleBackColor = false;
            this.btnAddUUID.Click += new System.EventHandler(this.btnAddUUID_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbSoftware);
            this.groupBox1.Controls.Add(this.rbHardware);
            this.groupBox1.Location = new System.Drawing.Point(587, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(141, 77);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "UUT Type";
            // 
            // rbSoftware
            // 
            this.rbSoftware.AutoSize = true;
            this.rbSoftware.Location = new System.Drawing.Point(15, 46);
            this.rbSoftware.Name = "rbSoftware";
            this.rbSoftware.Size = new System.Drawing.Size(67, 17);
            this.rbSoftware.TabIndex = 1;
            this.rbSoftware.TabStop = true;
            this.rbSoftware.Text = "Software";
            this.rbSoftware.UseVisualStyleBackColor = true;
            this.rbSoftware.CheckedChanged += new System.EventHandler(this.rbSoftware_CheckedChanged);
            // 
            // rbHardware
            // 
            this.rbHardware.AutoSize = true;
            this.rbHardware.Location = new System.Drawing.Point(15, 22);
            this.rbHardware.Name = "rbHardware";
            this.rbHardware.Size = new System.Drawing.Size(71, 17);
            this.rbHardware.TabIndex = 0;
            this.rbHardware.TabStop = true;
            this.rbHardware.Text = "Hardware";
            this.rbHardware.UseVisualStyleBackColor = true;
            this.rbHardware.CheckedChanged += new System.EventHandler(this.rbHardware_CheckedChanged);
            // 
            // panelUUT
            // 
            this.panelUUT.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelUUT.Controls.Add(this.hardwareUUTControl);
            this.panelUUT.Controls.Add(this.softwareUUTControl);
            this.panelUUT.Location = new System.Drawing.Point(0, 89);
            this.panelUUT.Name = "panelUUT";
            this.panelUUT.Size = new System.Drawing.Size(739, 429);
            this.panelUUT.TabIndex = 10;
            // 
            // softwareUUTControl
            // 
            this.softwareUUTControl.BackColor = System.Drawing.Color.AliceBlue;
            this.softwareUUTControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.softwareUUTControl.Location = new System.Drawing.Point(0, 0);
            this.softwareUUTControl.Name = "softwareUUTControl";
            this.softwareUUTControl.Size = new System.Drawing.Size(739, 429);
            this.softwareUUTControl.SoftwareUUT = null;
            this.softwareUUTControl.TabIndex = 1;
            // 
            // hardwareUUTControl
            // 
            this.hardwareUUTControl.BackColor = System.Drawing.Color.AliceBlue;
            this.hardwareUUTControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.hardwareUUTControl.Location = new System.Drawing.Point(0, 0);
            this.hardwareUUTControl.Name = "hardwareUUTControl";
            this.hardwareUUTControl.SchemaTypeName = null;
            this.hardwareUUTControl.Size = new System.Drawing.Size(739, 429);
            this.hardwareUUTControl.TabIndex = 0;
            this.hardwareUUTControl.TargetNamespace = null;
            // 
            // securityClassificationControl
            // 
            this.securityClassificationControl.Classified = false;
            this.securityClassificationControl.Location = new System.Drawing.Point(170, 36);
            this.securityClassificationControl.Name = "securityClassificationControl";
            this.securityClassificationControl.SchemaTypeName = null;
            this.securityClassificationControl.SecurityClassification = null;
            this.securityClassificationControl.Size = new System.Drawing.Size(380, 21);
            this.securityClassificationControl.TabIndex = 4;
            this.securityClassificationControl.TargetNamespace = null;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.HelpMessageKey = "UUTDescription.uuid";
            this.label2.Location = new System.Drawing.Point(22, 65);
            this.label2.Name = "label2";
            this.label2.RequiredField = false;
            this.label2.RequiredFieldMarkerFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Size = new System.Drawing.Size(34, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "UUID";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.HelpMessageKey = "UUTDescription.version";
            this.label1.Location = new System.Drawing.Point(14, 39);
            this.label1.Name = "label1";
            this.label1.RequiredField = false;
            this.label1.RequiredFieldMarkerFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Size = new System.Drawing.Size(42, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Version";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.HelpMessageKey = "UUTDescription.name";
            this.label3.Location = new System.Drawing.Point(21, 13);
            this.label3.Name = "label3";
            this.label3.RequiredField = false;
            this.label3.RequiredFieldMarkerFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Name";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial Black", 12.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Red;
            this.label6.HelpMessageKey = null;
            this.label6.Location = new System.Drawing.Point(9, 63);
            this.label6.Name = "label6";
            this.label6.RequiredField = false;
            this.label6.RequiredFieldMarkerFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Size = new System.Drawing.Size(19, 23);
            this.label6.TabIndex = 5;
            this.label6.Text = "*";
            // 
            // requiredUUIDValidator
            // 
            this.requiredUUIDValidator.ControlToValidate = this.edtUUID;
            this.requiredUUIDValidator.ErrorMessage = "A UUID is required.";
            this.requiredUUIDValidator.ErrorProvider = this.errorProvider;
            this.requiredUUIDValidator.Icon = null;
            this.requiredUUIDValidator.InitialValue = null;
            this.requiredUUIDValidator.IsEnabled = true;
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // UUTDescriptionControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.Controls.Add(this.panelUUT);
            this.Controls.Add(this.securityClassificationControl);
            this.Controls.Add(this.edtName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.edtVersion);
            this.Controls.Add(this.btnAddUUID);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.edtUUID);
            this.MinimumSize = new System.Drawing.Size(742, 428);
            this.Name = "UUTDescriptionControl";
            this.Size = new System.Drawing.Size(742, 521);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panelUUT.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox edtName;
        private ATMLCommonLibrary.controls.HelpLabel label2;
        private AWBTextBox edtUUID;
        private ATMLCommonLibrary.controls.HelpLabel label1;
        private AWBTextBox edtVersion;
        private System.Windows.Forms.Button btnAddUUID;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbSoftware;
        private System.Windows.Forms.RadioButton rbHardware;
        private ATMLCommonLibrary.controls.HelpLabel label3;
        private ATMLCommonLibrary.controls.HelpLabel label6;
        private WindowsFormsApplication10.SecurityClassificationControl securityClassificationControl;
        private System.Windows.Forms.Panel panelUUT;
        private uut.HardwareUUTControl hardwareUUTControl;
        private uut.SoftwareUUTControl softwareUUTControl;
        private validators.RequiredFieldValidator requiredUUIDValidator;
        private System.Windows.Forms.ErrorProvider errorProvider;
    }
}
