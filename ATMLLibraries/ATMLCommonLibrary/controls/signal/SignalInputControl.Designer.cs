/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
*
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/
using ATMLModelLibrary.model.signal.basic;


namespace ATMLCommonLibrary.controls.signal
{
    partial class SignalInputControl
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
            this.edtSignalInputName = new System.Windows.Forms.TextBox();
            this.helpLabel1 = new ATMLCommonLibrary.controls.HelpLabel(this.components);
            this.helpLabel2 = new ATMLCommonLibrary.controls.HelpLabel(this.components);
            this.cmbSignalInputType = new ATMLCommonLibrary.controls.signal.SignalInputTypeComboBox(this.components);
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.signalInputNameValidator = new ATMLCommonLibrary.controls.validators.RequiredFieldValidator();
            this.chkInputType = new System.Windows.Forms.CheckBox();
            this.numericFieldValidator1 = new ATMLCommonLibrary.controls.validators.NumericFieldValidator();
            this.edtMaxChannels = new System.Windows.Forms.MaskedTextBox();
            this.label1 = new ATMLCommonLibrary.controls.HelpLabel(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // edtSignalInputName
            // 
            this.edtSignalInputName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtSignalInputName.Location = new System.Drawing.Point(84, 12);
            this.edtSignalInputName.Name = "edtSignalInputName";
            this.edtSignalInputName.Size = new System.Drawing.Size(205, 20);
            this.edtSignalInputName.TabIndex = 8;
            // 
            // helpLabel1
            // 
            this.helpLabel1.AutoSize = true;
            this.helpLabel1.HelpMessageKey = "SignalInputControl.Name";
            this.helpLabel1.Location = new System.Drawing.Point(45, 15);
            this.helpLabel1.Name = "helpLabel1";
            this.helpLabel1.RequiredField = false;
            this.helpLabel1.RequiredFieldMarkerFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.helpLabel1.Size = new System.Drawing.Size(35, 13);
            this.helpLabel1.TabIndex = 7;
            this.helpLabel1.Text = "Name";
            this.helpLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // helpLabel2
            // 
            this.helpLabel2.AutoSize = true;
            this.helpLabel2.HelpMessageKey = "SignalInputControl.MaxChannels";
            this.helpLabel2.Location = new System.Drawing.Point(6, 41);
            this.helpLabel2.Name = "helpLabel2";
            this.helpLabel2.RequiredField = false;
            this.helpLabel2.RequiredFieldMarkerFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.helpLabel2.Size = new System.Drawing.Size(74, 13);
            this.helpLabel2.TabIndex = 9;
            this.helpLabel2.Text = "Max Channels";
            this.helpLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmbSignalInputType
            // 
            this.cmbSignalInputType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbSignalInputType.FormattingEnabled = true;
            this.cmbSignalInputType.Items.AddRange(new object[] {
            ATMLModelLibrary.model.signal.basic.SignalININ.Gate,
            ATMLModelLibrary.model.signal.basic.SignalININ.In,
            ATMLModelLibrary.model.signal.basic.SignalININ.Sync});
            this.cmbSignalInputType.Location = new System.Drawing.Point(104, 64);
            this.cmbSignalInputType.Name = "cmbSignalInputType";
            this.cmbSignalInputType.Size = new System.Drawing.Size(185, 21);
            this.cmbSignalInputType.TabIndex = 12;
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // signalInputNameValidator
            // 
            this.signalInputNameValidator.ControlToValidate = this.edtSignalInputName;
            this.signalInputNameValidator.ErrorMessage = "The Signal Input Name is required";
            this.signalInputNameValidator.ErrorProvider = this.errorProvider;
            this.signalInputNameValidator.Icon = null;
            this.signalInputNameValidator.InitialValue = null;
            this.signalInputNameValidator.IsEnabled = true;
            // 
            // chkInputType
            // 
            this.chkInputType.AutoSize = true;
            this.chkInputType.Location = new System.Drawing.Point(74, 67);
            this.chkInputType.Name = "chkInputType";
            this.chkInputType.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkInputType.Size = new System.Drawing.Size(15, 14);
            this.chkInputType.TabIndex = 13;
            this.chkInputType.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkInputType.UseVisualStyleBackColor = true;
            this.chkInputType.CheckedChanged += new System.EventHandler(this.chkInputType_CheckedChanged);
            // 
            // numericFieldValidator1
            // 
            this.numericFieldValidator1.ControlToValidate = this.edtMaxChannels;
            this.numericFieldValidator1.ErrorMessage = "The Max Channels must be numeric";
            this.numericFieldValidator1.ErrorProvider = this.errorProvider;
            this.numericFieldValidator1.Icon = null;
            this.numericFieldValidator1.InitialValue = "0";
            this.numericFieldValidator1.IsEnabled = true;
            // 
            // edtMaxChannels
            // 
            this.edtMaxChannels.Location = new System.Drawing.Point(84, 38);
            this.edtMaxChannels.Mask = "00";
            this.edtMaxChannels.Name = "edtMaxChannels";
            this.edtMaxChannels.Size = new System.Drawing.Size(205, 20);
            this.edtMaxChannels.TabIndex = 14;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.HelpMessageKey = "SignalInput.InputType";
            this.label1.Location = new System.Drawing.Point(10, 67);
            this.label1.Name = "label1";
            this.label1.RequiredField = false;
            this.label1.RequiredFieldMarkerFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 15;
            this.label1.Text = "Input Type";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // SignalInputControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.edtMaxChannels);
            this.Controls.Add(this.chkInputType);
            this.Controls.Add(this.cmbSignalInputType);
            this.Controls.Add(this.helpLabel2);
            this.Controls.Add(this.edtSignalInputName);
            this.Controls.Add(this.helpLabel1);
            this.Name = "SignalInputControl";
            this.Size = new System.Drawing.Size(313, 101);
            this.Validating += new System.ComponentModel.CancelEventHandler(this.SignalInputControl_Validating);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox edtSignalInputName;
        private HelpLabel helpLabel1;
        private HelpLabel helpLabel2;
        private SignalInputTypeComboBox cmbSignalInputType;
        private validators.RequiredFieldValidator signalInputNameValidator;
        private System.Windows.Forms.CheckBox chkInputType;
        private validators.NumericFieldValidator numericFieldValidator1;
        private System.Windows.Forms.MaskedTextBox edtMaxChannels;
        private ATMLCommonLibrary.controls.HelpLabel label1;
        protected System.Windows.Forms.ErrorProvider errorProvider;
    }
}
