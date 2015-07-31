/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
*
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/
namespace ATMLCommonLibrary.controls.limit
{
    partial class LimitPairControl
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
            this.simpleLimitControl1 = new ATMLCommonLibrary.controls.limit.SimpleLimitControl();
            this.cmbOperator = new System.Windows.Forms.ComboBox();
            this.simpleLimitControl2 = new ATMLCommonLibrary.controls.limit.SimpleLimitControl();
            this.label4 = new ATMLCommonLibrary.controls.HelpLabel(this.components);
            this.edtNominalValue = new ATMLCommonLibrary.controls.awb.AWBTextBox(this.components);
            this.label3 = new ATMLCommonLibrary.controls.HelpLabel(this.components);
            this.edtName = new ATMLCommonLibrary.controls.awb.AWBTextBox(this.components);
            this.label1 = new ATMLCommonLibrary.controls.HelpLabel(this.components);
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // simpleLimitControl1
            // 
            this.simpleLimitControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.simpleLimitControl1.ExpectedLimit = null;
            this.simpleLimitControl1.LimitControlType = ATMLCommonLibrary.controls.limit.SimpleLimitControl.ControlType.SimpleLimit;
            this.simpleLimitControl1.LimitName = "Limit";
            this.simpleLimitControl1.Location = new System.Drawing.Point(0, 64);
            this.simpleLimitControl1.MinimumSize = new System.Drawing.Size(455, 42);
            this.simpleLimitControl1.Name = "simpleLimitControl1";
            this.simpleLimitControl1.SchemaTypeName = null;
            this.simpleLimitControl1.ShowTextPanel = false;
            this.simpleLimitControl1.ShowTitle = true;
            this.simpleLimitControl1.Size = new System.Drawing.Size(472, 42);
            this.simpleLimitControl1.TabIndex = 8;
            this.simpleLimitControl1.TargetNamespace = null;
            // 
            // cmbOperator
            // 
            this.cmbOperator.FormattingEnabled = true;
            this.cmbOperator.Items.AddRange(new object[] {
            "AND",
            "OR"});
            this.cmbOperator.Location = new System.Drawing.Point(63, 108);
            this.cmbOperator.Name = "cmbOperator";
            this.cmbOperator.Size = new System.Drawing.Size(114, 21);
            this.cmbOperator.TabIndex = 6;
            // 
            // simpleLimitControl2
            // 
            this.simpleLimitControl2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.simpleLimitControl2.ExpectedLimit = null;
            this.simpleLimitControl2.LimitControlType = ATMLCommonLibrary.controls.limit.SimpleLimitControl.ControlType.SimpleLimit;
            this.simpleLimitControl2.LimitName = "Limit";
            this.simpleLimitControl2.Location = new System.Drawing.Point(0, 129);
            this.simpleLimitControl2.MinimumSize = new System.Drawing.Size(455, 42);
            this.simpleLimitControl2.Name = "simpleLimitControl2";
            this.simpleLimitControl2.SchemaTypeName = null;
            this.simpleLimitControl2.ShowTextPanel = false;
            this.simpleLimitControl2.ShowTitle = true;
            this.simpleLimitControl2.Size = new System.Drawing.Size(472, 42);
            this.simpleLimitControl2.TabIndex = 9;
            this.simpleLimitControl2.TargetNamespace = null;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.HelpMessageKey = "LimitPairControl.Nominal";
            this.label4.Location = new System.Drawing.Point(9, 41);
            this.label4.Name = "label4";
            this.label4.RequiredField = false;
            this.label4.RequiredFieldMarkerFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Size = new System.Drawing.Size(45, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Nominal";
            // 
            // edtNominalValue
            // 
            this.edtNominalValue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtNominalValue.AttributeName = null;
            this.edtNominalValue.Location = new System.Drawing.Point(63, 38);
            this.edtNominalValue.Name = "edtNominalValue";
            this.edtNominalValue.Size = new System.Drawing.Size(403, 20);
            this.edtNominalValue.TabIndex = 3;
            this.edtNominalValue.Value = null;
            this.edtNominalValue.ValueType = ATMLCommonLibrary.controls.awb.AWBTextBox.eValueType.xsString;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.HelpMessageKey = "LimitPairControl.Operator";
            this.label3.Location = new System.Drawing.Point(9, 113);
            this.label3.Name = "label3";
            this.label3.RequiredField = false;
            this.label3.RequiredFieldMarkerFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Size = new System.Drawing.Size(48, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Operator";
            // 
            // edtName
            // 
            this.edtName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtName.AttributeName = null;
            this.edtName.Location = new System.Drawing.Point(63, 10);
            this.edtName.Name = "edtName";
            this.edtName.Size = new System.Drawing.Size(403, 20);
            this.edtName.TabIndex = 1;
            this.edtName.Value = null;
            this.edtName.ValueType = ATMLCommonLibrary.controls.awb.AWBTextBox.eValueType.xsString;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.HelpMessageKey = "LimitPairControl.Name";
            this.label1.Location = new System.Drawing.Point(9, 13);
            this.label1.Name = "label1";
            this.label1.RequiredField = false;
            this.label1.RequiredFieldMarkerFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name";
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // LimitPairControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.simpleLimitControl1);
            this.Controls.Add(this.cmbOperator);
            this.Controls.Add(this.simpleLimitControl2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.edtNominalValue);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.edtName);
            this.Controls.Add(this.label1);
            this.MinimumSize = new System.Drawing.Size(485, 183);
            this.Name = "LimitPairControl";
            this.Size = new System.Drawing.Size(485, 183);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ATMLCommonLibrary.controls.awb.AWBTextBox edtName;
        private ATMLCommonLibrary.controls.HelpLabel label1;
        private System.Windows.Forms.ComboBox cmbOperator;
        private ATMLCommonLibrary.controls.HelpLabel label3;
        private ATMLCommonLibrary.controls.awb.AWBTextBox edtNominalValue;
        private ATMLCommonLibrary.controls.HelpLabel label4;
        private SimpleLimitControl simpleLimitControl2;
        private SimpleLimitControl simpleLimitControl1;
        protected System.Windows.Forms.ErrorProvider errorProvider;
    }
}
