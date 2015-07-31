/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
*
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

using ATMLCommonLibrary.controls.document;

namespace ATMLCommonLibrary.forms
{
    partial class ComponentForm
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
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.requiredIDValidator = new ATMLCommonLibrary.controls.validators.RequiredFieldValidator();
            this.componentControl = new ATMLCommonLibrary.controls.component.ComponentControl();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.componentControl);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Size = new System.Drawing.Size(517, 423);
            this.panel1.TabIndex = 4;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(454, 439);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(373, 439);
            // 
            // lblDenoteRequiredField
            // 
            this.lblDenoteRequiredField.Location = new System.Drawing.Point(1, 449);
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // requiredIDValidator
            // 
            this.requiredIDValidator.ControlToValidate = null;
            this.requiredIDValidator.ErrorMessage = "The Component ID is required.";
            this.requiredIDValidator.ErrorProvider = this.errorProvider;
            this.requiredIDValidator.Icon = null;
            this.requiredIDValidator.InitialValue = null;
            this.requiredIDValidator.IsEnabled = true;
            // 
            // componentControl
            // 
            this.componentControl.BackColor = System.Drawing.Color.LightSlateGray;
            this.componentControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.componentControl.DocumentType = ATMLDataAccessLibrary.model.dbDocument.DocumentType.NONE;
            this.componentControl.HelpKeyWord = null;
            this.componentControl.Location = new System.Drawing.Point(0, 0);
            this.componentControl.Name = "componentControl";
            this.componentControl.SchemaTypeName = null;
            this.componentControl.Size = new System.Drawing.Size(517, 423);
            this.componentControl.TabIndex = 0;
            this.componentControl.TargetNamespace = null;
            // 
            // ComponentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(541, 464);
            this.Name = "ComponentForm";
            this.Text = "Component";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ErrorProvider errorProvider;
        private controls.validators.RequiredFieldValidator requiredIDValidator;
        private controls.component.ComponentControl componentControl;
    }
}