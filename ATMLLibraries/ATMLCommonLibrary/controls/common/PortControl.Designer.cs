/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
*
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

using System.Windows.Forms;

namespace ATMLCommonLibrary.controls.common
{
    partial class PortControl
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
            this.cmbPortType = new ATMLCommonLibrary.controls.common.PortTypeComboBox(this.components);
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.requiredNameValidator = new ATMLCommonLibrary.controls.validators.RequiredFieldValidator();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // helpLabel1
            // 
            this.helpLabel1.HelpMessageKey = "Port.name";
            this.helpLabel1.Location = new System.Drawing.Point(19, 15);
            this.helpLabel1.Name = "helpLabel1";
            this.helpLabel1.RequiredField = true;
            this.helpLabel1.RequiredFieldMarkerFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.helpLabel1.Size = new System.Drawing.Size(41, 15);
            this.helpLabel1.TabIndex = 0;
            this.helpLabel1.Text = "Name";
            // 
            // helpLabel2
            // 
            this.helpLabel2.AutoSize = true;
            this.helpLabel2.HelpMessageKey = "Port.direction";
            this.helpLabel2.Location = new System.Drawing.Point(14, 50);
            this.helpLabel2.Name = "helpLabel2";
            this.helpLabel2.RequiredField = false;
            this.helpLabel2.RequiredFieldMarkerFont = null;
            this.helpLabel2.Size = new System.Drawing.Size(49, 13);
            this.helpLabel2.TabIndex = 1;
            this.helpLabel2.Text = "Direction";
            // 
            // helpLabel3
            // 
            this.helpLabel3.AutoSize = true;
            this.helpLabel3.HelpMessageKey = "Port.type";
            this.helpLabel3.Location = new System.Drawing.Point(32, 78);
            this.helpLabel3.Name = "helpLabel3";
            this.helpLabel3.RequiredField = false;
            this.helpLabel3.RequiredFieldMarkerFont = null;
            this.helpLabel3.Size = new System.Drawing.Size(31, 13);
            this.helpLabel3.TabIndex = 2;
            this.helpLabel3.Text = "Type";
            // 
            // edtName
            // 
            this.edtName.Location = new System.Drawing.Point(69, 15);
            this.edtName.Name = "edtName";
            this.edtName.Size = new System.Drawing.Size(142, 20);
            this.edtName.TabIndex = 3;
            // 
            // cmbPortDirection
            // 
            this.cmbPortDirection.Location = new System.Drawing.Point(70, 46);
            this.cmbPortDirection.Name = "cmbPortDirection";
            this.cmbPortDirection.Size = new System.Drawing.Size(141, 21);
            this.cmbPortDirection.TabIndex = 6;
            // 
            // cmbPortType
            // 
            this.cmbPortType.Location = new System.Drawing.Point(70, 78);
            this.cmbPortType.Name = "cmbPortType";
            this.cmbPortType.Size = new System.Drawing.Size(141, 21);
            this.cmbPortType.TabIndex = 7;
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
            // PortControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cmbPortType);
            this.Controls.Add(this.cmbPortDirection);
            this.Controls.Add(this.edtName);
            this.Controls.Add(this.helpLabel3);
            this.Controls.Add(this.helpLabel2);
            this.Controls.Add(this.helpLabel1);
            this.Name = "PortControl";
            this.Size = new System.Drawing.Size(237, 123);
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
        private PortTypeComboBox cmbPortType;
        private validators.RequiredFieldValidator requiredNameValidator;
        protected System.Windows.Forms.ErrorProvider errorProvider;
    }
}
