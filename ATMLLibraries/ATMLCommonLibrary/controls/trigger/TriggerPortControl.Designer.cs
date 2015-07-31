/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
* 
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

using ATMLCommonLibrary.controls.common;

namespace ATMLCommonLibrary.controls.trigger
{
    partial class TriggerPortControl
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
            this.helpLabel1 = new ATMLCommonLibrary.controls.HelpLabel(this.components);
            this.helpLabel2 = new ATMLCommonLibrary.controls.HelpLabel(this.components);
            this.helpLabel3 = new ATMLCommonLibrary.controls.HelpLabel(this.components);
            this.edtName = new System.Windows.Forms.TextBox();
            this.cmbPortDirection = new ATMLCommonLibrary.controls.common.PortDirectionComboBox(this.components);
            this.cmbPortType = new TriggerPortTypeComboBox(this.components);
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.requiredNameValidator = new ATMLCommonLibrary.controls.validators.RequiredFieldValidator();
            this.edtDescription = new System.Windows.Forms.TextBox();
            this.helpLabel4 = new ATMLCommonLibrary.controls.HelpLabel(this.components);
            this.requiredDirectionValidator = new ATMLCommonLibrary.controls.validators.RequiredFieldValidator();
            this.requiredTypeValidator = new ATMLCommonLibrary.controls.validators.RequiredFieldValidator();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // helpLabel1
            // 
            this.helpLabel1.HelpMessageKey = "Port.name";
            this.helpLabel1.Location = new System.Drawing.Point(24, 15);
            this.helpLabel1.Name = "helpLabel1";
            this.helpLabel1.RequiredField = true;
            this.helpLabel1.RequiredFieldMarkerFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.helpLabel1.Size = new System.Drawing.Size(40, 20);
            this.helpLabel1.TabIndex = 0;
            this.helpLabel1.Text = "Name";
            // 
            // helpLabel2
            // 
            this.helpLabel2.HelpMessageKey = "Port.direction";
            this.helpLabel2.Location = new System.Drawing.Point(9, 48);
            this.helpLabel2.Name = "helpLabel2";
            this.helpLabel2.RequiredField = true;
            this.helpLabel2.RequiredFieldMarkerFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.helpLabel2.Size = new System.Drawing.Size(55, 17);
            this.helpLabel2.TabIndex = 2;
            this.helpLabel2.Text = "Direction";
            // 
            // helpLabel3
            // 
            this.helpLabel3.HelpMessageKey = "Port.type";
            this.helpLabel3.Location = new System.Drawing.Point(25, 75);
            this.helpLabel3.Name = "helpLabel3";
            this.helpLabel3.RequiredField = true;
            this.helpLabel3.RequiredFieldMarkerFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.helpLabel3.Size = new System.Drawing.Size(39, 21);
            this.helpLabel3.TabIndex = 4;
            this.helpLabel3.Text = "Type";
            // 
            // edtName
            // 
            this.edtName.Location = new System.Drawing.Point(69, 15);
            this.edtName.Name = "edtName";
            this.edtName.Size = new System.Drawing.Size(142, 20);
            this.edtName.TabIndex = 1;
            // 
            // cmbPortDirection
            // 
            this.cmbPortDirection.FormattingEnabled = true;
            this.cmbPortDirection.Location = new System.Drawing.Point(69, 44);
            this.cmbPortDirection.Name = "cmbPortDirection";
            this.cmbPortDirection.Size = new System.Drawing.Size(141, 21);
            this.cmbPortDirection.TabIndex = 3;
            // 
            // cmbPortType
            // 
            this.cmbPortType.FormattingEnabled = true;
            this.cmbPortType.Location = new System.Drawing.Point(69, 75);
            this.cmbPortType.Name = "cmbPortType";
            this.cmbPortType.Size = new System.Drawing.Size(141, 21);
            this.cmbPortType.TabIndex = 5;
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // requiredNameValidator
            // 
            this.requiredNameValidator.ControlToValidate = this.edtName;
            this.requiredNameValidator.ErrorMessage = "The Port Name is required";
            this.requiredNameValidator.ErrorProvider = this.errorProvider;
            this.requiredNameValidator.Icon = null;
            this.requiredNameValidator.InitialValue = null;
            this.requiredNameValidator.IsEnabled = true;
            // 
            // edtDescription
            // 
            this.edtDescription.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtDescription.Location = new System.Drawing.Point(69, 105);
            this.edtDescription.Multiline = true;
            this.edtDescription.Name = "edtDescription";
            this.edtDescription.Size = new System.Drawing.Size(345, 114);
            this.edtDescription.TabIndex = 7;
            // 
            // helpLabel4
            // 
            this.helpLabel4.HelpMessageKey = "Port.name";
            this.helpLabel4.Location = new System.Drawing.Point(3, 105);
            this.helpLabel4.Name = "helpLabel4";
            this.helpLabel4.RequiredField = false;
            this.helpLabel4.RequiredFieldMarkerFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.helpLabel4.Size = new System.Drawing.Size(60, 20);
            this.helpLabel4.TabIndex = 6;
            this.helpLabel4.Text = "Description";
            // 
            // requiredDirectionValidator
            // 
            this.requiredDirectionValidator.ControlToValidate = this.cmbPortDirection;
            this.requiredDirectionValidator.ErrorMessage = "The Port Direction is required";
            this.requiredDirectionValidator.ErrorProvider = this.errorProvider;
            this.requiredDirectionValidator.Icon = null;
            this.requiredDirectionValidator.InitialValue = null;
            this.requiredDirectionValidator.IsEnabled = true;
            // 
            // requiredTypeValidator
            // 
            this.requiredTypeValidator.ControlToValidate = this.cmbPortType;
            this.requiredTypeValidator.ErrorMessage = "The Port Type is required";
            this.requiredTypeValidator.ErrorProvider = this.errorProvider;
            this.requiredTypeValidator.Icon = null;
            this.requiredTypeValidator.InitialValue = null;
            this.requiredTypeValidator.IsEnabled = true;
            // 
            // TriggerPortControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.edtDescription);
            this.Controls.Add(this.helpLabel4);
            this.Controls.Add(this.cmbPortType);
            this.Controls.Add(this.cmbPortDirection);
            this.Controls.Add(this.edtName);
            this.Controls.Add(this.helpLabel3);
            this.Controls.Add(this.helpLabel2);
            this.Controls.Add(this.helpLabel1);
            this.Name = "TriggerPortControl";
            this.Size = new System.Drawing.Size(428, 238);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private HelpLabel helpLabel1;
        private HelpLabel helpLabel2;
        private HelpLabel helpLabel3;
        private System.Windows.Forms.TextBox edtName;
        private PortDirectionComboBox cmbPortDirection;
        private TriggerPortTypeComboBox cmbPortType;
        private validators.RequiredFieldValidator requiredNameValidator;
        private System.Windows.Forms.TextBox edtDescription;
        private HelpLabel helpLabel4;
        private validators.RequiredFieldValidator requiredDirectionValidator;
        private validators.RequiredFieldValidator requiredTypeValidator;
        protected System.Windows.Forms.ErrorProvider errorProvider;
    }
}
