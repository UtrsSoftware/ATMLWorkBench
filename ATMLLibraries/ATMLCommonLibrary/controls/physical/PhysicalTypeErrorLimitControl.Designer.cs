/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
* 
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

namespace ATMLCommonLibrary.controls.physical
{
    partial class PhysicalTypeErrorLimitControl
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
            ATMLModelLibrary.model.Quantity quantity1 = new ATMLModelLibrary.model.Quantity();
            ATMLModelLibrary.model.Quantity quantity2 = new ATMLModelLibrary.model.Quantity();
            ATMLModelLibrary.model.Quantity quantity3 = new ATMLModelLibrary.model.Quantity();
            ATMLModelLibrary.model.Quantity quantity4 = new ATMLModelLibrary.model.Quantity();
            this.edtErrorLimit = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.chkIncludeResolution = new System.Windows.Forms.CheckBox();
            this.edtResolution = new ATMLCommonLibrary.controls.awb.AWBQuantityControl(this.components);
            this.cbResUnit = new System.Windows.Forms.ComboBox();
            this.helpLabel15 = new ATMLCommonLibrary.controls.HelpLabel(this.components);
            this.helpLabel16 = new ATMLCommonLibrary.controls.HelpLabel(this.components);
            this.cbResPrefix = new System.Windows.Forms.ComboBox();
            this.helpLabel18 = new ATMLCommonLibrary.controls.HelpLabel(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.edtConfidence = new ATMLCommonLibrary.controls.awb.AWBQuantityControl(this.components);
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.edtULValue = new ATMLCommonLibrary.controls.awb.AWBQuantityControl(this.components);
            this.cbULUnit = new System.Windows.Forms.ComboBox();
            this.helpLabel10 = new ATMLCommonLibrary.controls.HelpLabel(this.components);
            this.helpLabel11 = new ATMLCommonLibrary.controls.HelpLabel(this.components);
            this.cbULPrefix = new System.Windows.Forms.ComboBox();
            this.helpLabel13 = new ATMLCommonLibrary.controls.HelpLabel(this.components);
            this.helpLabel14 = new ATMLCommonLibrary.controls.HelpLabel(this.components);
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.edtLLValue = new ATMLCommonLibrary.controls.awb.AWBQuantityControl(this.components);
            this.cbLLUnit = new System.Windows.Forms.ComboBox();
            this.helpLabel3 = new ATMLCommonLibrary.controls.HelpLabel(this.components);
            this.helpLabel9 = new ATMLCommonLibrary.controls.HelpLabel(this.components);
            this.cbLLPrefix = new System.Windows.Forms.ComboBox();
            this.helpLabel2 = new ATMLCommonLibrary.controls.HelpLabel(this.components);
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtResolution)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtConfidence)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtULValue)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtLLValue)).BeginInit();
            this.SuspendLayout();
            // 
            // edtErrorLimit
            // 
            this.edtErrorLimit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(255)))), ((int)(((byte)(220)))));
            this.edtErrorLimit.Location = new System.Drawing.Point(11, 202);
            this.edtErrorLimit.Name = "edtErrorLimit";
            this.edtErrorLimit.ReadOnly = true;
            this.edtErrorLimit.Size = new System.Drawing.Size(605, 20);
            this.edtErrorLimit.TabIndex = 2;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.chkIncludeResolution);
            this.groupBox4.Controls.Add(this.edtResolution);
            this.groupBox4.Controls.Add(this.cbResUnit);
            this.groupBox4.Controls.Add(this.helpLabel15);
            this.groupBox4.Controls.Add(this.helpLabel16);
            this.groupBox4.Controls.Add(this.cbResPrefix);
            this.groupBox4.Controls.Add(this.helpLabel18);
            this.groupBox4.Location = new System.Drawing.Point(443, 8);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(173, 188);
            this.groupBox4.TabIndex = 1;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Resolution";
            // 
            // chkIncludeResolution
            // 
            this.chkIncludeResolution.AutoSize = true;
            this.chkIncludeResolution.Location = new System.Drawing.Point(20, 28);
            this.chkIncludeResolution.Name = "chkIncludeResolution";
            this.chkIncludeResolution.Size = new System.Drawing.Size(114, 17);
            this.chkIncludeResolution.TabIndex = 6;
            this.chkIncludeResolution.Text = "Include Resolution";
            this.chkIncludeResolution.UseVisualStyleBackColor = true;
            this.chkIncludeResolution.CheckedChanged += new System.EventHandler(this.chkIncludeResolution_CheckedChanged);
            // 
            // edtResolution
            // 
            this.edtResolution.DecimalPlaces = 2;
            this.edtResolution.Location = new System.Drawing.Point(57, 58);
            this.edtResolution.Name = "edtResolution";
            quantity1.Unit = null;
            quantity1.Value = 0D;
            this.edtResolution.Quantity = quantity1;
            this.edtResolution.Size = new System.Drawing.Size(96, 20);
            this.edtResolution.TabIndex = 1;
            this.edtResolution.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // cbResUnit
            // 
            this.cbResUnit.FormattingEnabled = true;
            this.cbResUnit.Location = new System.Drawing.Point(57, 115);
            this.cbResUnit.Name = "cbResUnit";
            this.cbResUnit.Size = new System.Drawing.Size(96, 21);
            this.cbResUnit.TabIndex = 5;
            // 
            // helpLabel15
            // 
            this.helpLabel15.AutoSize = true;
            this.helpLabel15.HelpMessageKey = null;
            this.helpLabel15.Location = new System.Drawing.Point(17, 115);
            this.helpLabel15.Name = "helpLabel15";
            this.helpLabel15.RequiredField = false;
            this.helpLabel15.RequiredFieldMarkerFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.helpLabel15.Size = new System.Drawing.Size(26, 13);
            this.helpLabel15.TabIndex = 4;
            this.helpLabel15.Text = "Unit";
            // 
            // helpLabel16
            // 
            this.helpLabel16.AutoSize = true;
            this.helpLabel16.HelpMessageKey = null;
            this.helpLabel16.Location = new System.Drawing.Point(17, 58);
            this.helpLabel16.Name = "helpLabel16";
            this.helpLabel16.RequiredField = false;
            this.helpLabel16.RequiredFieldMarkerFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.helpLabel16.Size = new System.Drawing.Size(34, 13);
            this.helpLabel16.TabIndex = 0;
            this.helpLabel16.Text = "Value";
            // 
            // cbResPrefix
            // 
            this.cbResPrefix.FormattingEnabled = true;
            this.cbResPrefix.Location = new System.Drawing.Point(57, 86);
            this.cbResPrefix.Name = "cbResPrefix";
            this.cbResPrefix.Size = new System.Drawing.Size(96, 21);
            this.cbResPrefix.TabIndex = 3;
            // 
            // helpLabel18
            // 
            this.helpLabel18.AutoSize = true;
            this.helpLabel18.HelpMessageKey = null;
            this.helpLabel18.Location = new System.Drawing.Point(17, 86);
            this.helpLabel18.Name = "helpLabel18";
            this.helpLabel18.RequiredField = false;
            this.helpLabel18.RequiredFieldMarkerFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.helpLabel18.Size = new System.Drawing.Size(33, 13);
            this.helpLabel18.TabIndex = 2;
            this.helpLabel18.Text = "Prefix";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.edtConfidence);
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.helpLabel14);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Location = new System.Drawing.Point(11, 8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(419, 188);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Error Limit";
            // 
            // edtConfidence
            // 
            this.edtConfidence.DecimalPlaces = 2;
            this.edtConfidence.Location = new System.Drawing.Point(303, 157);
            this.edtConfidence.Name = "edtConfidence";
            quantity2.Unit = null;
            quantity2.Value = 0D;
            this.edtConfidence.Quantity = quantity2;
            this.edtConfidence.Size = new System.Drawing.Size(96, 20);
            this.edtConfidence.TabIndex = 3;
            this.edtConfidence.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.edtULValue);
            this.groupBox3.Controls.Add(this.cbULUnit);
            this.groupBox3.Controls.Add(this.helpLabel10);
            this.groupBox3.Controls.Add(this.helpLabel11);
            this.groupBox3.Controls.Add(this.cbULPrefix);
            this.groupBox3.Controls.Add(this.helpLabel13);
            this.groupBox3.Location = new System.Drawing.Point(226, 29);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(173, 122);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Plus Value";
            // 
            // edtULValue
            // 
            this.edtULValue.DecimalPlaces = 2;
            this.edtULValue.Location = new System.Drawing.Point(57, 29);
            this.edtULValue.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.edtULValue.Name = "edtULValue";
            quantity3.Unit = null;
            quantity3.Value = 0D;
            this.edtULValue.Quantity = quantity3;
            this.edtULValue.Size = new System.Drawing.Size(96, 20);
            this.edtULValue.TabIndex = 3;
            this.edtULValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // cbULUnit
            // 
            this.cbULUnit.FormattingEnabled = true;
            this.cbULUnit.Location = new System.Drawing.Point(57, 86);
            this.cbULUnit.Name = "cbULUnit";
            this.cbULUnit.Size = new System.Drawing.Size(96, 21);
            this.cbULUnit.TabIndex = 7;
            // 
            // helpLabel10
            // 
            this.helpLabel10.AutoSize = true;
            this.helpLabel10.HelpMessageKey = null;
            this.helpLabel10.Location = new System.Drawing.Point(17, 86);
            this.helpLabel10.Name = "helpLabel10";
            this.helpLabel10.RequiredField = false;
            this.helpLabel10.RequiredFieldMarkerFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.helpLabel10.Size = new System.Drawing.Size(26, 13);
            this.helpLabel10.TabIndex = 6;
            this.helpLabel10.Text = "Unit";
            // 
            // helpLabel11
            // 
            this.helpLabel11.AutoSize = true;
            this.helpLabel11.HelpMessageKey = null;
            this.helpLabel11.Location = new System.Drawing.Point(17, 29);
            this.helpLabel11.Name = "helpLabel11";
            this.helpLabel11.RequiredField = false;
            this.helpLabel11.RequiredFieldMarkerFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.helpLabel11.Size = new System.Drawing.Size(34, 13);
            this.helpLabel11.TabIndex = 2;
            this.helpLabel11.Text = "Value";
            // 
            // cbULPrefix
            // 
            this.cbULPrefix.FormattingEnabled = true;
            this.cbULPrefix.Location = new System.Drawing.Point(57, 57);
            this.cbULPrefix.Name = "cbULPrefix";
            this.cbULPrefix.Size = new System.Drawing.Size(96, 21);
            this.cbULPrefix.TabIndex = 5;
            // 
            // helpLabel13
            // 
            this.helpLabel13.AutoSize = true;
            this.helpLabel13.HelpMessageKey = null;
            this.helpLabel13.Location = new System.Drawing.Point(17, 57);
            this.helpLabel13.Name = "helpLabel13";
            this.helpLabel13.RequiredField = false;
            this.helpLabel13.RequiredFieldMarkerFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.helpLabel13.Size = new System.Drawing.Size(33, 13);
            this.helpLabel13.TabIndex = 4;
            this.helpLabel13.Text = "Prefix";
            // 
            // helpLabel14
            // 
            this.helpLabel14.AutoSize = true;
            this.helpLabel14.HelpMessageKey = null;
            this.helpLabel14.Location = new System.Drawing.Point(233, 161);
            this.helpLabel14.Name = "helpLabel14";
            this.helpLabel14.RequiredField = false;
            this.helpLabel14.RequiredFieldMarkerFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.helpLabel14.Size = new System.Drawing.Size(61, 13);
            this.helpLabel14.TabIndex = 2;
            this.helpLabel14.Text = "Confidence";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.edtLLValue);
            this.groupBox2.Controls.Add(this.cbLLUnit);
            this.groupBox2.Controls.Add(this.helpLabel3);
            this.groupBox2.Controls.Add(this.helpLabel9);
            this.groupBox2.Controls.Add(this.cbLLPrefix);
            this.groupBox2.Controls.Add(this.helpLabel2);
            this.groupBox2.Location = new System.Drawing.Point(16, 29);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(173, 122);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Minus Value";
            // 
            // edtLLValue
            // 
            this.edtLLValue.DecimalPlaces = 2;
            this.edtLLValue.Location = new System.Drawing.Point(57, 29);
            this.edtLLValue.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.edtLLValue.Name = "edtLLValue";
            quantity4.Unit = null;
            quantity4.Value = 0D;
            this.edtLLValue.Quantity = quantity4;
            this.edtLLValue.Size = new System.Drawing.Size(96, 20);
            this.edtLLValue.TabIndex = 3;
            this.edtLLValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // cbLLUnit
            // 
            this.cbLLUnit.FormattingEnabled = true;
            this.cbLLUnit.Location = new System.Drawing.Point(57, 86);
            this.cbLLUnit.Name = "cbLLUnit";
            this.cbLLUnit.Size = new System.Drawing.Size(96, 21);
            this.cbLLUnit.TabIndex = 7;
            // 
            // helpLabel3
            // 
            this.helpLabel3.AutoSize = true;
            this.helpLabel3.HelpMessageKey = null;
            this.helpLabel3.Location = new System.Drawing.Point(17, 86);
            this.helpLabel3.Name = "helpLabel3";
            this.helpLabel3.RequiredField = false;
            this.helpLabel3.RequiredFieldMarkerFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.helpLabel3.Size = new System.Drawing.Size(26, 13);
            this.helpLabel3.TabIndex = 6;
            this.helpLabel3.Text = "Unit";
            // 
            // helpLabel9
            // 
            this.helpLabel9.AutoSize = true;
            this.helpLabel9.HelpMessageKey = null;
            this.helpLabel9.Location = new System.Drawing.Point(17, 29);
            this.helpLabel9.Name = "helpLabel9";
            this.helpLabel9.RequiredField = false;
            this.helpLabel9.RequiredFieldMarkerFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.helpLabel9.Size = new System.Drawing.Size(34, 13);
            this.helpLabel9.TabIndex = 2;
            this.helpLabel9.Text = "Value";
            // 
            // cbLLPrefix
            // 
            this.cbLLPrefix.FormattingEnabled = true;
            this.cbLLPrefix.Location = new System.Drawing.Point(57, 57);
            this.cbLLPrefix.Name = "cbLLPrefix";
            this.cbLLPrefix.Size = new System.Drawing.Size(96, 21);
            this.cbLLPrefix.TabIndex = 5;
            // 
            // helpLabel2
            // 
            this.helpLabel2.AutoSize = true;
            this.helpLabel2.HelpMessageKey = null;
            this.helpLabel2.Location = new System.Drawing.Point(17, 57);
            this.helpLabel2.Name = "helpLabel2";
            this.helpLabel2.RequiredField = false;
            this.helpLabel2.RequiredFieldMarkerFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.helpLabel2.Size = new System.Drawing.Size(33, 13);
            this.helpLabel2.TabIndex = 4;
            this.helpLabel2.Text = "Prefix";
            // 
            // PhysicalTypeErrorLimitControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.edtErrorLimit);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox1);
            this.Name = "PhysicalTypeErrorLimitControl";
            this.Size = new System.Drawing.Size(627, 236);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtResolution)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtConfidence)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtULValue)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtLLValue)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbLLPrefix;
        private HelpLabel helpLabel2;
        private System.Windows.Forms.ComboBox cbLLUnit;
        private HelpLabel helpLabel3;
        private awb.AWBQuantityControl edtLLValue;
        private HelpLabel helpLabel9;
        private System.Windows.Forms.GroupBox groupBox1;
        private awb.AWBQuantityControl edtConfidence;
        private System.Windows.Forms.GroupBox groupBox3;
        private awb.AWBQuantityControl edtULValue;
        private System.Windows.Forms.ComboBox cbULUnit;
        private HelpLabel helpLabel10;
        private HelpLabel helpLabel11;
        private System.Windows.Forms.ComboBox cbULPrefix;
        private HelpLabel helpLabel13;
        private HelpLabel helpLabel14;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox4;
        private awb.AWBQuantityControl edtResolution;
        private System.Windows.Forms.ComboBox cbResUnit;
        private HelpLabel helpLabel15;
        private HelpLabel helpLabel16;
        private System.Windows.Forms.ComboBox cbResPrefix;
        private HelpLabel helpLabel18;
        private System.Windows.Forms.TextBox edtErrorLimit;
        private System.Windows.Forms.CheckBox chkIncludeResolution;
    }
}
