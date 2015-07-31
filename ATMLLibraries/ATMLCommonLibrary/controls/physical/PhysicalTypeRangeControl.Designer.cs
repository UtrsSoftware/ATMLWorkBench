/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
* 
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

namespace ATMLCommonLibrary.controls.physical
{
    partial class PhysicalTypeRangeControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PhysicalTypeRangeControl));
            this.cbLLPrefix = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.edtLLValue = new ATMLCommonLibrary.controls.awb.AWBQuantityControl(this.components);
            this.cbLLUnit = new System.Windows.Forms.ComboBox();
            this.helpLabel3 = new ATMLCommonLibrary.controls.HelpLabel(this.components);
            this.helpLabel9 = new ATMLCommonLibrary.controls.HelpLabel(this.components);
            this.helpLabel2 = new ATMLCommonLibrary.controls.HelpLabel(this.components);
            this.edtULValue = new ATMLCommonLibrary.controls.awb.AWBQuantityControl(this.components);
            this.cbULUnit = new System.Windows.Forms.ComboBox();
            this.helpLabel10 = new ATMLCommonLibrary.controls.HelpLabel(this.components);
            this.edtRange = new System.Windows.Forms.TextBox();
            this.cbULPrefix = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.helpLabel11 = new ATMLCommonLibrary.controls.HelpLabel(this.components);
            this.helpLabel13 = new ATMLCommonLibrary.controls.HelpLabel(this.components);
            this.helpLabel1 = new ATMLCommonLibrary.controls.HelpLabel(this.components);
            this.edtErrorLimit = new System.Windows.Forms.TextBox();
            this.btnLimit = new System.Windows.Forms.Button();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtLLValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtULValue)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbLLPrefix
            // 
            this.cbLLPrefix.FormattingEnabled = true;
            this.cbLLPrefix.Location = new System.Drawing.Point(57, 57);
            this.cbLLPrefix.Name = "cbLLPrefix";
            this.cbLLPrefix.Size = new System.Drawing.Size(96, 21);
            this.cbLLPrefix.TabIndex = 5;
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
            this.groupBox2.Text = "Low Value";
            // 
            // edtLLValue
            // 
            this.edtLLValue.DecimalPlaces = 2;
            this.edtLLValue.Location = new System.Drawing.Point(57, 29);
            this.edtLLValue.Maximum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.edtLLValue.Minimum = new decimal(new int[] {
            999,
            0,
            0,
            -2147483648});
            this.edtLLValue.Name = "edtLLValue";
            quantity1.Unit = null;
            quantity1.Value = 0D;
            this.edtLLValue.Quantity = quantity1;
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
            quantity2.Unit = null;
            quantity2.Value = 0D;
            this.edtULValue.Quantity = quantity2;
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
            // edtRange
            // 
            this.edtRange.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(255)))), ((int)(((byte)(220)))));
            this.edtRange.Location = new System.Drawing.Point(8, 213);
            this.edtRange.Name = "edtRange";
            this.edtRange.ReadOnly = true;
            this.edtRange.Size = new System.Drawing.Size(419, 20);
            this.edtRange.TabIndex = 5;
            // 
            // cbULPrefix
            // 
            this.cbULPrefix.FormattingEnabled = true;
            this.cbULPrefix.Location = new System.Drawing.Point(57, 57);
            this.cbULPrefix.Name = "cbULPrefix";
            this.cbULPrefix.Size = new System.Drawing.Size(96, 21);
            this.cbULPrefix.TabIndex = 5;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnLimit);
            this.groupBox1.Controls.Add(this.edtErrorLimit);
            this.groupBox1.Controls.Add(this.helpLabel1);
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Location = new System.Drawing.Point(8, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(419, 197);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Range";
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
            this.groupBox3.Text = "High Value";
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
            // helpLabel1
            // 
            this.helpLabel1.AutoSize = true;
            this.helpLabel1.HelpMessageKey = null;
            this.helpLabel1.Location = new System.Drawing.Point(13, 171);
            this.helpLabel1.Name = "helpLabel1";
            this.helpLabel1.RequiredField = false;
            this.helpLabel1.RequiredFieldMarkerFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.helpLabel1.Size = new System.Drawing.Size(53, 13);
            this.helpLabel1.TabIndex = 8;
            this.helpLabel1.Text = "Error Limit";
            // 
            // edtErrorLimit
            // 
            this.edtErrorLimit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(255)))), ((int)(((byte)(220)))));
            this.edtErrorLimit.Location = new System.Drawing.Point(72, 168);
            this.edtErrorLimit.Name = "edtErrorLimit";
            this.edtErrorLimit.ReadOnly = true;
            this.edtErrorLimit.Size = new System.Drawing.Size(295, 20);
            this.edtErrorLimit.TabIndex = 6;
            // 
            // btnLimit
            // 
            this.btnLimit.FlatAppearance.BorderSize = 0;
            this.btnLimit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLimit.Image = ((System.Drawing.Image)(resources.GetObject("btnLimit.Image")));
            this.btnLimit.Location = new System.Drawing.Point(371, 165);
            this.btnLimit.Name = "btnLimit";
            this.btnLimit.Size = new System.Drawing.Size(28, 23);
            this.btnLimit.TabIndex = 9;
            this.btnLimit.UseVisualStyleBackColor = true;
            this.btnLimit.Click += new System.EventHandler(this.btnLimit_Click);
            // 
            // PhysicalTypeRangeControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.edtRange);
            this.Controls.Add(this.groupBox1);
            this.Name = "PhysicalTypeRangeControl";
            this.Size = new System.Drawing.Size(435, 244);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtLLValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtULValue)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbLLPrefix;
        private System.Windows.Forms.GroupBox groupBox2;
        private awb.AWBQuantityControl edtLLValue;
        private System.Windows.Forms.ComboBox cbLLUnit;
        private HelpLabel helpLabel3;
        private HelpLabel helpLabel9;
        private HelpLabel helpLabel2;
        private awb.AWBQuantityControl edtULValue;
        private System.Windows.Forms.ComboBox cbULUnit;
        private HelpLabel helpLabel10;
        private System.Windows.Forms.TextBox edtRange;
        private System.Windows.Forms.ComboBox cbULPrefix;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox3;
        private HelpLabel helpLabel11;
        private HelpLabel helpLabel13;
        private HelpLabel helpLabel1;
        private System.Windows.Forms.Button btnLimit;
        private System.Windows.Forms.TextBox edtErrorLimit;
    }
}
