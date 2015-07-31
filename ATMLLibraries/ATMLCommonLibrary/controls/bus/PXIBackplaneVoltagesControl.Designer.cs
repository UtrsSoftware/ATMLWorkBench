/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
*
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/
namespace ATMLCommonLibrary
{
    partial class PXIBackplaneVoltagesControl
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
            this.gbFrame = new System.Windows.Forms.GroupBox();
            this.edtMinus12 = new System.Windows.Forms.NumericUpDown();
            this.edtPlus12 = new System.Windows.Forms.NumericUpDown();
            this.edtPlus5 = new System.Windows.Forms.NumericUpDown();
            this.edtPlus3_3 = new System.Windows.Forms.NumericUpDown();
            this.lblPXIBackplaneVoltage_Minus12 = new ATMLCommonLibrary.controls.HelpLabel(this.components);
            this.lblPXIBackplaneVoltagePlus12 = new ATMLCommonLibrary.controls.HelpLabel(this.components);
            this.lblPXIBackplaneVoltagePlus5 = new ATMLCommonLibrary.controls.HelpLabel(this.components);
            this.lblPXIBackplaneVoltagePlus3_3 = new ATMLCommonLibrary.controls.HelpLabel(this.components);
            this.gbFrame.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtMinus12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtPlus12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtPlus5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtPlus3_3)).BeginInit();
            this.SuspendLayout();
            // 
            // gbFrame
            // 
            this.gbFrame.Controls.Add(this.edtMinus12);
            this.gbFrame.Controls.Add(this.edtPlus12);
            this.gbFrame.Controls.Add(this.edtPlus5);
            this.gbFrame.Controls.Add(this.edtPlus3_3);
            this.gbFrame.Controls.Add(this.lblPXIBackplaneVoltage_Minus12);
            this.gbFrame.Controls.Add(this.lblPXIBackplaneVoltagePlus12);
            this.gbFrame.Controls.Add(this.lblPXIBackplaneVoltagePlus5);
            this.gbFrame.Controls.Add(this.lblPXIBackplaneVoltagePlus3_3);
            this.gbFrame.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbFrame.Location = new System.Drawing.Point(0, 0);
            this.gbFrame.Name = "gbFrame";
            this.gbFrame.Size = new System.Drawing.Size(177, 143);
            this.gbFrame.TabIndex = 0;
            this.gbFrame.TabStop = false;
            this.gbFrame.Text = "PXI Backplane Voltages";
            // 
            // edtMinus12
            // 
            this.edtMinus12.DecimalPlaces = 4;
            this.edtMinus12.Location = new System.Drawing.Point(55, 104);
            this.edtMinus12.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.edtMinus12.Name = "edtMinus12";
            this.edtMinus12.Size = new System.Drawing.Size(100, 20);
            this.edtMinus12.TabIndex = 31;
            this.edtMinus12.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // edtPlus12
            // 
            this.edtPlus12.DecimalPlaces = 4;
            this.edtPlus12.Location = new System.Drawing.Point(55, 78);
            this.edtPlus12.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.edtPlus12.Name = "edtPlus12";
            this.edtPlus12.Size = new System.Drawing.Size(100, 20);
            this.edtPlus12.TabIndex = 30;
            this.edtPlus12.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // edtPlus5
            // 
            this.edtPlus5.DecimalPlaces = 4;
            this.edtPlus5.Location = new System.Drawing.Point(55, 52);
            this.edtPlus5.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.edtPlus5.Name = "edtPlus5";
            this.edtPlus5.Size = new System.Drawing.Size(100, 20);
            this.edtPlus5.TabIndex = 29;
            this.edtPlus5.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // edtPlus3_3
            // 
            this.edtPlus3_3.DecimalPlaces = 4;
            this.edtPlus3_3.Location = new System.Drawing.Point(55, 26);
            this.edtPlus3_3.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.edtPlus3_3.Name = "edtPlus3_3";
            this.edtPlus3_3.Size = new System.Drawing.Size(100, 20);
            this.edtPlus3_3.TabIndex = 28;
            this.edtPlus3_3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblPXIBackplaneVoltage_Minus12
            // 
            this.lblPXIBackplaneVoltage_Minus12.AutoSize = true;
            this.lblPXIBackplaneVoltage_Minus12.HelpMessageKey = "PXIBackplaneVoltage.Minus12";
            this.lblPXIBackplaneVoltage_Minus12.Location = new System.Drawing.Point(24, 106);
            this.lblPXIBackplaneVoltage_Minus12.Name = "lblPXIBackplaneVoltage_Minus12";
            this.lblPXIBackplaneVoltage_Minus12.RequiredField = false;
            this.lblPXIBackplaneVoltage_Minus12.RequiredFieldMarkerFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPXIBackplaneVoltage_Minus12.Size = new System.Drawing.Size(25, 13);
            this.lblPXIBackplaneVoltage_Minus12.TabIndex = 6;
            this.lblPXIBackplaneVoltage_Minus12.Text = "- 12";
            this.lblPXIBackplaneVoltage_Minus12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblPXIBackplaneVoltagePlus12
            // 
            this.lblPXIBackplaneVoltagePlus12.AutoSize = true;
            this.lblPXIBackplaneVoltagePlus12.HelpMessageKey = "PXIBackplaneVoltage.Plus12";
            this.lblPXIBackplaneVoltagePlus12.Location = new System.Drawing.Point(21, 80);
            this.lblPXIBackplaneVoltagePlus12.Name = "lblPXIBackplaneVoltagePlus12";
            this.lblPXIBackplaneVoltagePlus12.RequiredField = false;
            this.lblPXIBackplaneVoltagePlus12.RequiredFieldMarkerFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPXIBackplaneVoltagePlus12.Size = new System.Drawing.Size(28, 13);
            this.lblPXIBackplaneVoltagePlus12.TabIndex = 4;
            this.lblPXIBackplaneVoltagePlus12.Text = "+ 12";
            this.lblPXIBackplaneVoltagePlus12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblPXIBackplaneVoltagePlus5
            // 
            this.lblPXIBackplaneVoltagePlus5.AutoSize = true;
            this.lblPXIBackplaneVoltagePlus5.HelpMessageKey = "PXIBackplaneVoltage.Plus5";
            this.lblPXIBackplaneVoltagePlus5.Location = new System.Drawing.Point(27, 54);
            this.lblPXIBackplaneVoltagePlus5.Name = "lblPXIBackplaneVoltagePlus5";
            this.lblPXIBackplaneVoltagePlus5.RequiredField = false;
            this.lblPXIBackplaneVoltagePlus5.RequiredFieldMarkerFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPXIBackplaneVoltagePlus5.Size = new System.Drawing.Size(22, 13);
            this.lblPXIBackplaneVoltagePlus5.TabIndex = 2;
            this.lblPXIBackplaneVoltagePlus5.Text = "+ 5";
            this.lblPXIBackplaneVoltagePlus5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblPXIBackplaneVoltagePlus3_3
            // 
            this.lblPXIBackplaneVoltagePlus3_3.AutoSize = true;
            this.lblPXIBackplaneVoltagePlus3_3.HelpMessageKey = "PXIBackplaneVoltage.Plus3.3";
            this.lblPXIBackplaneVoltagePlus3_3.Location = new System.Drawing.Point(18, 28);
            this.lblPXIBackplaneVoltagePlus3_3.Name = "lblPXIBackplaneVoltagePlus3_3";
            this.lblPXIBackplaneVoltagePlus3_3.RequiredField = false;
            this.lblPXIBackplaneVoltagePlus3_3.RequiredFieldMarkerFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPXIBackplaneVoltagePlus3_3.Size = new System.Drawing.Size(31, 13);
            this.lblPXIBackplaneVoltagePlus3_3.TabIndex = 0;
            this.lblPXIBackplaneVoltagePlus3_3.Text = "+ 3.3";
            this.lblPXIBackplaneVoltagePlus3_3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // PXIBackplaneVoltagesControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gbFrame);
            this.Name = "PXIBackplaneVoltagesControl";
            this.Size = new System.Drawing.Size(177, 143);
            this.gbFrame.ResumeLayout(false);
            this.gbFrame.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtMinus12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtPlus12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtPlus5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtPlus3_3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbFrame;
        private controls.HelpLabel lblPXIBackplaneVoltagePlus3_3;
        private controls.HelpLabel lblPXIBackplaneVoltage_Minus12;
        private controls.HelpLabel lblPXIBackplaneVoltagePlus12;
        private controls.HelpLabel lblPXIBackplaneVoltagePlus5;
        private System.Windows.Forms.NumericUpDown edtMinus12;
        private System.Windows.Forms.NumericUpDown edtPlus12;
        private System.Windows.Forms.NumericUpDown edtPlus5;
        private System.Windows.Forms.NumericUpDown edtPlus3_3;
    }
}
