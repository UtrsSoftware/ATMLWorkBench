/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
*
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/
namespace ATMLCommonLibrary.controls.controller
{
    partial class ControllerProcessorControl
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
            this.helpLabel4 = new ATMLCommonLibrary.controls.HelpLabel(this.components);
            this.edtDatumSpeed = new ATMLCommonLibrary.controls.datum.DatumTypeDoubleControl();
            this.edtQuantity = new ATMLCommonLibrary.controls.awb.AWBTextBox(this.components);
            this.edtType = new ATMLCommonLibrary.controls.awb.AWBTextBox(this.components);
            this.edtArchitecture = new ATMLCommonLibrary.controls.awb.AWBTextBox(this.components);
            this.helpLabel3 = new ATMLCommonLibrary.controls.HelpLabel(this.components);
            this.helpLabel2 = new ATMLCommonLibrary.controls.HelpLabel(this.components);
            this.helpLabel1 = new ATMLCommonLibrary.controls.HelpLabel(this.components);
            this.requiredFieldValidatorArchitecture = new ATMLCommonLibrary.controls.validators.RequiredFieldValidator();
            this.requiredFieldValidatorType = new ATMLCommonLibrary.controls.validators.RequiredFieldValidator();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // helpLabel4
            // 
            this.helpLabel4.AutoSize = true;
            this.helpLabel4.HelpMessageKey = "TestEquipment.ControllerProcessor.Speed";
            this.helpLabel4.Location = new System.Drawing.Point(10, 87);
            this.helpLabel4.Name = "helpLabel4";
            this.helpLabel4.RequiredField = false;
            this.helpLabel4.RequiredFieldMarkerFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.helpLabel4.Size = new System.Drawing.Size(38, 13);
            this.helpLabel4.TabIndex = 7;
            this.helpLabel4.Text = "Speed";
            // 
            // edtDatumSpeed
            // 
            this.edtDatumSpeed.BackColor = System.Drawing.Color.White;
            this.edtDatumSpeed.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.edtDatumSpeed.Location = new System.Drawing.Point(75, 87);
            this.edtDatumSpeed.Name = "edtDatumSpeed";
            this.edtDatumSpeed.SchemaTypeName = null;
            this.edtDatumSpeed.Size = new System.Drawing.Size(304, 28);
            this.edtDatumSpeed.TabIndex = 6;
            this.edtDatumSpeed.TargetNamespace = null;
            this.edtDatumSpeed.UseFlowControl = null;
            // 
            // edtQuantity
            // 
            this.edtQuantity.AttributeName = null;
            this.edtQuantity.Location = new System.Drawing.Point(75, 59);
            this.edtQuantity.Name = "edtQuantity";
            this.edtQuantity.Size = new System.Drawing.Size(181, 20);
            this.edtQuantity.TabIndex = 5;
            this.edtQuantity.Tag = 0;
            this.edtQuantity.Text = "0";
            this.edtQuantity.Value = 0;
            this.edtQuantity.ValueType = ATMLCommonLibrary.controls.awb.AWBTextBox.eValueType.xsInteger;
            // 
            // edtType
            // 
            this.edtType.AttributeName = null;
            this.edtType.Location = new System.Drawing.Point(75, 31);
            this.edtType.Name = "edtType";
            this.edtType.Size = new System.Drawing.Size(181, 20);
            this.edtType.TabIndex = 4;
            this.edtType.Value = null;
            this.edtType.ValueType = ATMLCommonLibrary.controls.awb.AWBTextBox.eValueType.xsString;
            // 
            // edtArchitecture
            // 
            this.edtArchitecture.AttributeName = null;
            this.edtArchitecture.Location = new System.Drawing.Point(75, 5);
            this.edtArchitecture.Name = "edtArchitecture";
            this.edtArchitecture.Size = new System.Drawing.Size(181, 20);
            this.edtArchitecture.TabIndex = 3;
            this.edtArchitecture.Value = null;
            this.edtArchitecture.ValueType = ATMLCommonLibrary.controls.awb.AWBTextBox.eValueType.xsString;
            // 
            // helpLabel3
            // 
            this.helpLabel3.AutoSize = true;
            this.helpLabel3.HelpMessageKey = "TestEquipment.ControllerProcessor.Quantity";
            this.helpLabel3.Location = new System.Drawing.Point(10, 59);
            this.helpLabel3.Name = "helpLabel3";
            this.helpLabel3.RequiredField = false;
            this.helpLabel3.RequiredFieldMarkerFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.helpLabel3.Size = new System.Drawing.Size(46, 13);
            this.helpLabel3.TabIndex = 2;
            this.helpLabel3.Text = "Quantity";
            // 
            // helpLabel2
            // 
            this.helpLabel2.AutoSize = true;
            this.helpLabel2.HelpMessageKey = "TestEquipment.ControllerProcessor.Type";
            this.helpLabel2.Location = new System.Drawing.Point(10, 34);
            this.helpLabel2.Name = "helpLabel2";
            this.helpLabel2.RequiredField = false;
            this.helpLabel2.RequiredFieldMarkerFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.helpLabel2.Size = new System.Drawing.Size(31, 13);
            this.helpLabel2.TabIndex = 1;
            this.helpLabel2.Text = "Type";
            // 
            // helpLabel1
            // 
            this.helpLabel1.AutoSize = true;
            this.helpLabel1.HelpMessageKey = "TestEquipment.ControllerProcessor.Architecture";
            this.helpLabel1.Location = new System.Drawing.Point(10, 12);
            this.helpLabel1.Name = "helpLabel1";
            this.helpLabel1.RequiredField = false;
            this.helpLabel1.RequiredFieldMarkerFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.helpLabel1.Size = new System.Drawing.Size(64, 13);
            this.helpLabel1.TabIndex = 0;
            this.helpLabel1.Text = "Architecture";
            // 
            // requiredFieldValidatorArchitecture
            // 
            this.requiredFieldValidatorArchitecture.ControlToValidate = this.edtArchitecture;
            this.requiredFieldValidatorArchitecture.ErrorMessage = "Architeture required";
            this.requiredFieldValidatorArchitecture.ErrorProvider = null;
            this.requiredFieldValidatorArchitecture.Icon = null;
            this.requiredFieldValidatorArchitecture.InitialValue = null;
            this.requiredFieldValidatorArchitecture.IsEnabled = true;
            // 
            // requiredFieldValidatorType
            // 
            this.requiredFieldValidatorType.ControlToValidate = this.edtType;
            this.requiredFieldValidatorType.ErrorMessage = null;
            this.requiredFieldValidatorType.ErrorProvider = null;
            this.requiredFieldValidatorType.Icon = null;
            this.requiredFieldValidatorType.InitialValue = null;
            this.requiredFieldValidatorType.IsEnabled = true;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // ControllerProcessorControl
            // 
            this.Controls.Add(this.helpLabel4);
            this.Controls.Add(this.edtDatumSpeed);
            this.Controls.Add(this.edtQuantity);
            this.Controls.Add(this.edtType);
            this.Controls.Add(this.edtArchitecture);
            this.Controls.Add(this.helpLabel3);
            this.Controls.Add(this.helpLabel2);
            this.Controls.Add(this.helpLabel1);
            this.Name = "ControllerProcessorControl";
            this.Size = new System.Drawing.Size(412, 128);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private HelpLabel helpLabel1;
        private HelpLabel helpLabel2;
        private HelpLabel helpLabel3;
        private awb.AWBTextBox edtArchitecture;
        private awb.AWBTextBox edtType;
        private awb.AWBTextBox edtQuantity;
        private datum.DatumTypeDoubleControl edtDatumSpeed;
        private HelpLabel helpLabel4;
        private validators.RequiredFieldValidator requiredFieldValidatorArchitecture;
        private validators.RequiredFieldValidator requiredFieldValidatorType;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}
