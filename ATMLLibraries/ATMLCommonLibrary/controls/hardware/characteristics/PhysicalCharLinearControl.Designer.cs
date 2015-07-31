/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
*
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/
namespace ATMLCommonLibrary.controls.hardware.characteristics
{
    partial class PhysicalCharLinearControl
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
            this.label4 = new ATMLCommonLibrary.controls.HelpLabel(this.components);
            this.label3 = new ATMLCommonLibrary.controls.HelpLabel(this.components);
            this.label5 = new ATMLCommonLibrary.controls.HelpLabel(this.components);
            this.label9 = new ATMLCommonLibrary.controls.HelpLabel(this.components);
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label8 = new ATMLCommonLibrary.controls.HelpLabel(this.components);
            this.label7 = new ATMLCommonLibrary.controls.HelpLabel(this.components);
            this.label6 = new ATMLCommonLibrary.controls.HelpLabel(this.components);
            this.edtTextRack = new ATMLCommonLibrary.controls.awb.AWBTextBox(this.components);
            this.label2 = new ATMLCommonLibrary.controls.HelpLabel(this.components);
            this.label1 = new ATMLCommonLibrary.controls.HelpLabel(this.components);
            this.rdoMilli = new System.Windows.Forms.RadioButton();
            this.rdoInch = new System.Windows.Forms.RadioButton();
            this.rdoRack = new System.Windows.Forms.RadioButton();
            this.datumDepth = new ATMLCommonLibrary.controls.datum.DatumTypeDoubleControl();
            this.datumWidth = new ATMLCommonLibrary.controls.datum.DatumTypeDoubleControl();
            this.datumHeight = new ATMLCommonLibrary.controls.datum.DatumTypeDoubleControl();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.HelpMessageKey = "PhysicalCharLinearControl.Width";
            this.label4.Location = new System.Drawing.Point(13, 50);
            this.label4.Name = "label4";
            this.label4.RequiredField = false;
            this.label4.RequiredFieldMarkerFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 19;
            this.label4.Text = "Width";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.HelpMessageKey = "PhysicalCharLinearControl.Height";
            this.label3.Location = new System.Drawing.Point(13, 5);
            this.label3.Name = "label3";
            this.label3.RequiredField = false;
            this.label3.RequiredFieldMarkerFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 18;
            this.label3.Text = "Height";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.HelpMessageKey = "PhysicalCharLinearControl.Depth";
            this.label5.Location = new System.Drawing.Point(13, 95);
            this.label5.Name = "label5";
            this.label5.RequiredField = false;
            this.label5.RequiredFieldMarkerFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Size = new System.Drawing.Size(36, 13);
            this.label5.TabIndex = 20;
            this.label5.Text = "Depth";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.HelpMessageKey = "PhysicalChar.LinearMeasurments.RackSize";
            this.label9.Location = new System.Drawing.Point(9, -2);
            this.label9.Name = "label9";
            this.label9.RequiredField = false;
            this.label9.RequiredFieldMarkerFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Size = new System.Drawing.Size(56, 13);
            this.label9.TabIndex = 14;
            this.label9.Text = "Rack Size";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.edtTextRack);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.rdoMilli);
            this.groupBox2.Controls.Add(this.rdoInch);
            this.groupBox2.Controls.Add(this.rdoRack);
            this.groupBox2.Location = new System.Drawing.Point(324, 21);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(143, 110);
            this.groupBox2.TabIndex = 17;
            this.groupBox2.TabStop = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.HelpMessageKey = "PhysicalCharLinearControl.Millimeters";
            this.label8.Location = new System.Drawing.Point(26, 84);
            this.label8.Name = "label8";
            this.label8.RequiredField = false;
            this.label8.RequiredFieldMarkerFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Size = new System.Drawing.Size(55, 13);
            this.label8.TabIndex = 9;
            this.label8.Text = "Millimeters";
            this.label8.Click += new System.EventHandler(this.rdoMilli_CheckedChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.HelpMessageKey = "PhysicalCharLinearControl.Inches";
            this.label7.Location = new System.Drawing.Point(26, 60);
            this.label7.Name = "label7";
            this.label7.RequiredField = false;
            this.label7.RequiredFieldMarkerFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Size = new System.Drawing.Size(39, 13);
            this.label7.TabIndex = 8;
            this.label7.Text = "Inches";
            this.label7.Click += new System.EventHandler(this.rdoInch_CheckedChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.HelpMessageKey = "PhysicalCharLinearControl.RackUnits";
            this.label6.Location = new System.Drawing.Point(26, 38);
            this.label6.Name = "label6";
            this.label6.RequiredField = false;
            this.label6.RequiredFieldMarkerFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Size = new System.Drawing.Size(60, 13);
            this.label6.TabIndex = 7;
            this.label6.Text = "Rack Units";
            this.label6.Click += new System.EventHandler(this.rdoRack_CheckedChanged);
            // 
            // edtTextRack
            // 
            this.edtTextRack.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtTextRack.AttributeName = null;
            this.edtTextRack.DataLookupKey = null;
            this.edtTextRack.Location = new System.Drawing.Point(90, 57);
            this.edtTextRack.Name = "edtTextRack";
            this.edtTextRack.Size = new System.Drawing.Size(42, 20);
            this.edtTextRack.TabIndex = 6;
            this.edtTextRack.Tag = "0";
            this.edtTextRack.Text = "0";
            this.edtTextRack.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.edtTextRack.Value = 0D;
            this.edtTextRack.ValueType = ATMLCommonLibrary.controls.awb.AWBTextBox.eValueType.xsDouble;
            this.edtTextRack.TextChanged += new System.EventHandler(this.edtTextRack_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.HelpMessageKey = null;
            this.label2.Location = new System.Drawing.Point(99, 88);
            this.label2.Name = "label2";
            this.label2.RequiredField = false;
            this.label2.RequiredFieldMarkerFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Size = new System.Drawing.Size(0, 13);
            this.label2.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.HelpMessageKey = "PhysicalCharLinearControl.ChooseEntry";
            this.label1.Location = new System.Drawing.Point(5, 16);
            this.label1.Name = "label1";
            this.label1.RequiredField = false;
            this.label1.RequiredFieldMarkerFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Size = new System.Drawing.Size(112, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Choose Entry Mtheod:";
            // 
            // rdoMilli
            // 
            this.rdoMilli.AutoSize = true;
            this.rdoMilli.Location = new System.Drawing.Point(6, 84);
            this.rdoMilli.Name = "rdoMilli";
            this.rdoMilli.Size = new System.Drawing.Size(14, 13);
            this.rdoMilli.TabIndex = 2;
            this.rdoMilli.UseVisualStyleBackColor = true;
            this.rdoMilli.Click += new System.EventHandler(this.rdoMilli_CheckedChanged);
            // 
            // rdoInch
            // 
            this.rdoInch.AutoSize = true;
            this.rdoInch.Location = new System.Drawing.Point(6, 61);
            this.rdoInch.Name = "rdoInch";
            this.rdoInch.Size = new System.Drawing.Size(14, 13);
            this.rdoInch.TabIndex = 1;
            this.rdoInch.UseVisualStyleBackColor = true;
            this.rdoInch.Click += new System.EventHandler(this.rdoInch_CheckedChanged);
            // 
            // rdoRack
            // 
            this.rdoRack.AutoSize = true;
            this.rdoRack.Checked = true;
            this.rdoRack.Location = new System.Drawing.Point(6, 38);
            this.rdoRack.Name = "rdoRack";
            this.rdoRack.Size = new System.Drawing.Size(14, 13);
            this.rdoRack.TabIndex = 0;
            this.rdoRack.TabStop = true;
            this.rdoRack.UseVisualStyleBackColor = true;
            this.rdoRack.Click += new System.EventHandler(this.rdoRack_CheckedChanged);
            // 
            // datumDepth
            // 
            this.datumDepth.BackColor = System.Drawing.Color.White;
            this.datumDepth.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.datumDepth.HasErrors = false;
            this.datumDepth.HelpKeyWord = null;
            this.datumDepth.LastError = null;
            this.datumDepth.Location = new System.Drawing.Point(13, 111);
            this.datumDepth.Name = "datumDepth";
            this.datumDepth.SchemaTypeName = null;
            this.datumDepth.Size = new System.Drawing.Size(297, 27);
            this.datumDepth.TabIndex = 16;
            this.datumDepth.TargetNamespace = null;
            this.datumDepth.UseFlowControl = null;
            // 
            // datumWidth
            // 
            this.datumWidth.BackColor = System.Drawing.Color.White;
            this.datumWidth.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.datumWidth.HasErrors = false;
            this.datumWidth.HelpKeyWord = null;
            this.datumWidth.LastError = null;
            this.datumWidth.Location = new System.Drawing.Point(13, 66);
            this.datumWidth.Name = "datumWidth";
            this.datumWidth.SchemaTypeName = null;
            this.datumWidth.Size = new System.Drawing.Size(297, 27);
            this.datumWidth.TabIndex = 15;
            this.datumWidth.TargetNamespace = null;
            this.datumWidth.UseFlowControl = null;
            // 
            // datumHeight
            // 
            this.datumHeight.BackColor = System.Drawing.Color.White;
            this.datumHeight.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.datumHeight.HasErrors = false;
            this.datumHeight.HelpKeyWord = null;
            this.datumHeight.LastError = null;
            this.datumHeight.Location = new System.Drawing.Point(13, 21);
            this.datumHeight.Name = "datumHeight";
            this.datumHeight.SchemaTypeName = null;
            this.datumHeight.Size = new System.Drawing.Size(297, 27);
            this.datumHeight.TabIndex = 14;
            this.datumHeight.TargetNamespace = null;
            this.datumHeight.UseFlowControl = null;
            // 
            // PhysicalCharLinearControl
            // 
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.datumDepth);
            this.Controls.Add(this.datumWidth);
            this.Controls.Add(this.datumHeight);
            this.MinimumSize = new System.Drawing.Size(329, 150);
            this.Name = "PhysicalCharLinearControl";
            this.Size = new System.Drawing.Size(482, 150);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private HelpLabel label4;
        private HelpLabel label3;
        private HelpLabel label5;
        private HelpLabel label9;
        private System.Windows.Forms.GroupBox groupBox2;
        private HelpLabel label8;
        private HelpLabel label7;
        private HelpLabel label6;
        private awb.AWBTextBox edtTextRack;
        private HelpLabel label2;
        private HelpLabel label1;
        private System.Windows.Forms.RadioButton rdoMilli;
        private System.Windows.Forms.RadioButton rdoInch;
        private System.Windows.Forms.RadioButton rdoRack;
        private datum.DatumTypeDoubleControl datumDepth;
        private datum.DatumTypeDoubleControl datumWidth;
        private datum.DatumTypeDoubleControl datumHeight;


    }
}
