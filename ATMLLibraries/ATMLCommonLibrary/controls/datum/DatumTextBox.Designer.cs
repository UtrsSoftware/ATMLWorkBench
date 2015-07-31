/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
*
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/
namespace ATMLCommonLibrary.controls.datum
{
    partial class DatumTextBox
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
            this.rbFalse = new System.Windows.Forms.RadioButton();
            this.rbTrue = new System.Windows.Forms.RadioButton();
            this.edtValue = new ATMLCommonLibrary.controls.awb.AWBTextBox(this.components);
            this.dateTimeValue = new System.Windows.Forms.DateTimePicker();
            this.edtReal = new ATMLCommonLibrary.controls.awb.AWBTextBox(this.components);
            this.edtImaginary = new ATMLCommonLibrary.controls.awb.AWBTextBox(this.components);
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // rbFalse
            // 
            this.rbFalse.AutoSize = true;
            this.rbFalse.Location = new System.Drawing.Point(66, 0);
            this.rbFalse.Name = "rbFalse";
            this.rbFalse.Size = new System.Drawing.Size(50, 17);
            this.rbFalse.TabIndex = 11;
            this.rbFalse.TabStop = true;
            this.rbFalse.Text = "False";
            this.rbFalse.UseVisualStyleBackColor = false;
            this.rbFalse.CheckedChanged += new System.EventHandler(this.rbFalse_CheckedChanged);
            // 
            // rbTrue
            // 
            this.rbTrue.AutoSize = true;
            this.rbTrue.Location = new System.Drawing.Point(16, 0);
            this.rbTrue.Name = "rbTrue";
            this.rbTrue.Size = new System.Drawing.Size(47, 17);
            this.rbTrue.TabIndex = 12;
            this.rbTrue.TabStop = true;
            this.rbTrue.Text = "True";
            this.rbTrue.UseVisualStyleBackColor = true;
            this.rbTrue.CheckedChanged += new System.EventHandler(this.rbTrue_CheckedChanged);
            // 
            // edtValue
            // 
            this.edtValue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtValue.AttributeName = null;
            this.edtValue.Location = new System.Drawing.Point(0, 0);
            this.edtValue.Name = "edtValue";
            this.edtValue.Size = new System.Drawing.Size(177, 20);
            this.edtValue.TabIndex = 13;
            this.edtValue.Value = null;
            this.edtValue.ValueType = ATMLCommonLibrary.controls.awb.AWBTextBox.eValueType.xsString;
            this.edtValue.KeyUp += new System.Windows.Forms.KeyEventHandler(this.edtValue_KeyUp);
            // 
            // dateTimeValue
            // 
            this.dateTimeValue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dateTimeValue.CustomFormat = "dd MMM yyyy HH:mm:ss";
            this.dateTimeValue.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimeValue.Location = new System.Drawing.Point(0, 0);
            this.dateTimeValue.Name = "dateTimeValue";
            this.dateTimeValue.Size = new System.Drawing.Size(176, 20);
            this.dateTimeValue.TabIndex = 14;
            this.dateTimeValue.ValueChanged += new System.EventHandler(this.dateTimeValue_ValueChanged);
            // 
            // edtReal
            // 
            this.edtReal.AttributeName = null;
            this.edtReal.Location = new System.Drawing.Point(0, 0);
            this.edtReal.Name = "edtReal";
            this.edtReal.Size = new System.Drawing.Size(71, 20);
            this.edtReal.TabIndex = 9;
            this.edtReal.Value = null;
            this.edtReal.ValueType = ATMLCommonLibrary.controls.awb.AWBTextBox.eValueType.xsString;
            this.edtReal.KeyUp += new System.Windows.Forms.KeyEventHandler(this.edtReal_KeyUp);
            // 
            // edtImaginary
            // 
            this.edtImaginary.AttributeName = null;
            this.edtImaginary.Location = new System.Drawing.Point(72, 0);
            this.edtImaginary.Name = "edtImaginary";
            this.edtImaginary.Size = new System.Drawing.Size(86, 20);
            this.edtImaginary.TabIndex = 10;
            this.edtImaginary.Value = null;
            this.edtImaginary.ValueType = ATMLCommonLibrary.controls.awb.AWBTextBox.eValueType.xsString;
            this.edtImaginary.KeyUp += new System.Windows.Forms.KeyEventHandler(this.edtImaginary_KeyUp);
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // DatumTextBox
            // 
            this.Controls.Add(this.edtValue);
            this.Controls.Add(this.dateTimeValue);
            this.Controls.Add(this.rbFalse);
            this.Controls.Add(this.rbTrue);
            this.Controls.Add(this.edtImaginary);
            this.Controls.Add(this.edtReal);
            this.Name = "DatumTextBox";
            this.Size = new System.Drawing.Size(179, 20);
            this.Resize += new System.EventHandler(this.DatumTextBox_Resize);
            this.Validating += new System.ComponentModel.CancelEventHandler(this.DatumTextBox_Validating);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected System.Windows.Forms.RadioButton rbFalse;
        protected System.Windows.Forms.RadioButton rbTrue;
        protected awb.AWBTextBox edtValue;
        protected System.Windows.Forms.DateTimePicker dateTimeValue;
        protected awb.AWBTextBox edtReal;
        protected awb.AWBTextBox edtImaginary;
        protected System.Windows.Forms.ErrorProvider errorProvider;
    }
}
