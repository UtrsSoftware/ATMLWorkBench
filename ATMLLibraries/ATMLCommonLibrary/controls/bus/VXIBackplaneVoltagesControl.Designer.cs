/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
*
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/
namespace ATMLCommonLibrary.controls.bus
{
    partial class VXIBackplaneVoltagesControl
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
            this.gbFrame = new System.Windows.Forms.GroupBox();
            this.edtMinus52 = new System.Windows.Forms.NumericUpDown();
            this.edtMinus24 = new System.Windows.Forms.NumericUpDown();
            this.edtMinus12 = new System.Windows.Forms.NumericUpDown();
            this.edtMinus2 = new System.Windows.Forms.NumericUpDown();
            this.edtPlus24 = new System.Windows.Forms.NumericUpDown();
            this.edtPlus12 = new System.Windows.Forms.NumericUpDown();
            this.edtPlus5 = new System.Windows.Forms.NumericUpDown();
            this.edtPlus5Standby = new System.Windows.Forms.NumericUpDown();
            this.lblMinus52 = new ATMLCommonLibrary.controls.HelpLabel(this.components);
            this.lblMinus24 = new ATMLCommonLibrary.controls.HelpLabel(this.components);
            this.lblPlus24 = new ATMLCommonLibrary.controls.HelpLabel(this.components);
            this.lblMinus2 = new ATMLCommonLibrary.controls.HelpLabel(this.components);
            this.lblMinus12 = new ATMLCommonLibrary.controls.HelpLabel(this.components);
            this.lblPlus12 = new ATMLCommonLibrary.controls.HelpLabel(this.components);
            this.lblPlus5 = new ATMLCommonLibrary.controls.HelpLabel(this.components);
            this.lblPlus5Standby = new ATMLCommonLibrary.controls.HelpLabel(this.components);
            this.gbFrame.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtMinus52)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtMinus24)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtMinus12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtMinus2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtPlus24)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtPlus12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtPlus5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtPlus5Standby)).BeginInit();
            this.SuspendLayout();
            // 
            // gbFrame
            // 
            this.gbFrame.Controls.Add(this.edtMinus52);
            this.gbFrame.Controls.Add(this.edtMinus24);
            this.gbFrame.Controls.Add(this.edtMinus12);
            this.gbFrame.Controls.Add(this.edtMinus2);
            this.gbFrame.Controls.Add(this.edtPlus24);
            this.gbFrame.Controls.Add(this.edtPlus12);
            this.gbFrame.Controls.Add(this.edtPlus5);
            this.gbFrame.Controls.Add(this.edtPlus5Standby);
            this.gbFrame.Controls.Add(this.lblMinus52);
            this.gbFrame.Controls.Add(this.lblMinus24);
            this.gbFrame.Controls.Add(this.lblPlus24);
            this.gbFrame.Controls.Add(this.lblMinus2);
            this.gbFrame.Controls.Add(this.lblMinus12);
            this.gbFrame.Controls.Add(this.lblPlus12);
            this.gbFrame.Controls.Add(this.lblPlus5);
            this.gbFrame.Controls.Add(this.lblPlus5Standby);
            this.gbFrame.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbFrame.Location = new System.Drawing.Point(0, 0);
            this.gbFrame.Name = "gbFrame";
            this.gbFrame.Size = new System.Drawing.Size(343, 141);
            this.gbFrame.TabIndex = 16;
            this.gbFrame.TabStop = false;
            this.gbFrame.Text = "VXI Backplane Voltages";
            // 
            // edtMinus52
            // 
            this.edtMinus52.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.edtMinus52.DecimalPlaces = 4;
            this.edtMinus52.Location = new System.Drawing.Point(221, 103);
            this.edtMinus52.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.edtMinus52.Name = "edtMinus52";
            this.edtMinus52.Size = new System.Drawing.Size(94, 20);
            this.edtMinus52.TabIndex = 34;
            this.edtMinus52.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // edtMinus24
            // 
            this.edtMinus24.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.edtMinus24.DecimalPlaces = 4;
            this.edtMinus24.Location = new System.Drawing.Point(221, 77);
            this.edtMinus24.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.edtMinus24.Name = "edtMinus24";
            this.edtMinus24.Size = new System.Drawing.Size(94, 20);
            this.edtMinus24.TabIndex = 33;
            this.edtMinus24.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // edtMinus12
            // 
            this.edtMinus12.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.edtMinus12.DecimalPlaces = 4;
            this.edtMinus12.Location = new System.Drawing.Point(221, 51);
            this.edtMinus12.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.edtMinus12.Name = "edtMinus12";
            this.edtMinus12.Size = new System.Drawing.Size(94, 20);
            this.edtMinus12.TabIndex = 32;
            this.edtMinus12.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // edtMinus2
            // 
            this.edtMinus2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.edtMinus2.DecimalPlaces = 4;
            this.edtMinus2.Location = new System.Drawing.Point(221, 25);
            this.edtMinus2.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.edtMinus2.Name = "edtMinus2";
            this.edtMinus2.Size = new System.Drawing.Size(94, 20);
            this.edtMinus2.TabIndex = 31;
            this.edtMinus2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // edtPlus24
            // 
            this.edtPlus24.DecimalPlaces = 4;
            this.edtPlus24.Location = new System.Drawing.Point(80, 104);
            this.edtPlus24.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.edtPlus24.Name = "edtPlus24";
            this.edtPlus24.Size = new System.Drawing.Size(94, 20);
            this.edtPlus24.TabIndex = 30;
            this.edtPlus24.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // edtPlus12
            // 
            this.edtPlus12.DecimalPlaces = 4;
            this.edtPlus12.Location = new System.Drawing.Point(80, 78);
            this.edtPlus12.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.edtPlus12.Name = "edtPlus12";
            this.edtPlus12.Size = new System.Drawing.Size(94, 20);
            this.edtPlus12.TabIndex = 29;
            this.edtPlus12.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // edtPlus5
            // 
            this.edtPlus5.DecimalPlaces = 4;
            this.edtPlus5.Location = new System.Drawing.Point(80, 52);
            this.edtPlus5.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.edtPlus5.Name = "edtPlus5";
            this.edtPlus5.Size = new System.Drawing.Size(94, 20);
            this.edtPlus5.TabIndex = 28;
            this.edtPlus5.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // edtPlus5Standby
            // 
            this.edtPlus5Standby.DecimalPlaces = 4;
            this.edtPlus5Standby.Location = new System.Drawing.Point(80, 26);
            this.edtPlus5Standby.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.edtPlus5Standby.Name = "edtPlus5Standby";
            this.edtPlus5Standby.Size = new System.Drawing.Size(94, 20);
            this.edtPlus5Standby.TabIndex = 27;
            this.edtPlus5Standby.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblMinus52
            // 
            this.lblMinus52.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblMinus52.HelpMessageKey = "VXIBackplane.Minus52";
            this.lblMinus52.Location = new System.Drawing.Point(187, 106);
            this.lblMinus52.Name = "lblMinus52";
            this.lblMinus52.RequiredField = true;
            this.lblMinus52.RequiredFieldMarkerFont = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMinus52.Size = new System.Drawing.Size(34, 13);
            this.lblMinus52.TabIndex = 26;
            this.lblMinus52.Text = "- 5.2";
            this.lblMinus52.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblMinus24
            // 
            this.lblMinus24.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblMinus24.HelpMessageKey = "VXIBackplane.Minus24";
            this.lblMinus24.Location = new System.Drawing.Point(187, 80);
            this.lblMinus24.Name = "lblMinus24";
            this.lblMinus24.RequiredField = true;
            this.lblMinus24.RequiredFieldMarkerFont = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMinus24.Size = new System.Drawing.Size(31, 13);
            this.lblMinus24.TabIndex = 24;
            this.lblMinus24.Text = "- 24";
            this.lblMinus24.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblPlus24
            // 
            this.lblPlus24.HelpMessageKey = "VXIBackplane.Plus24";
            this.lblPlus24.Location = new System.Drawing.Point(42, 106);
            this.lblPlus24.Name = "lblPlus24";
            this.lblPlus24.RequiredField = true;
            this.lblPlus24.RequiredFieldMarkerFont = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPlus24.Size = new System.Drawing.Size(34, 13);
            this.lblPlus24.TabIndex = 20;
            this.lblPlus24.Text = "+ 24";
            this.lblPlus24.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblMinus2
            // 
            this.lblMinus2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblMinus2.HelpMessageKey = "VXIBackplane.Minus2";
            this.lblMinus2.Location = new System.Drawing.Point(193, 28);
            this.lblMinus2.Name = "lblMinus2";
            this.lblMinus2.RequiredField = true;
            this.lblMinus2.RequiredFieldMarkerFont = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMinus2.Size = new System.Drawing.Size(25, 13);
            this.lblMinus2.TabIndex = 19;
            this.lblMinus2.Text = "- 2";
            this.lblMinus2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblMinus12
            // 
            this.lblMinus12.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblMinus12.HelpMessageKey = "VXIBackplane.Minus12";
            this.lblMinus12.Location = new System.Drawing.Point(187, 54);
            this.lblMinus12.Name = "lblMinus12";
            this.lblMinus12.RequiredField = true;
            this.lblMinus12.RequiredFieldMarkerFont = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMinus12.Size = new System.Drawing.Size(31, 13);
            this.lblMinus12.TabIndex = 18;
            this.lblMinus12.Text = "- 12";
            this.lblMinus12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblPlus12
            // 
            this.lblPlus12.HelpMessageKey = "VXIBackplane.Plus12";
            this.lblPlus12.Location = new System.Drawing.Point(42, 80);
            this.lblPlus12.Name = "lblPlus12";
            this.lblPlus12.RequiredField = true;
            this.lblPlus12.RequiredFieldMarkerFont = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPlus12.Size = new System.Drawing.Size(34, 13);
            this.lblPlus12.TabIndex = 16;
            this.lblPlus12.Text = "+ 12";
            this.lblPlus12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblPlus5
            // 
            this.lblPlus5.HelpMessageKey = "VXIBackplane.Plus5";
            this.lblPlus5.Location = new System.Drawing.Point(48, 54);
            this.lblPlus5.Name = "lblPlus5";
            this.lblPlus5.RequiredField = true;
            this.lblPlus5.RequiredFieldMarkerFont = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPlus5.Size = new System.Drawing.Size(28, 13);
            this.lblPlus5.TabIndex = 14;
            this.lblPlus5.Text = "+ 5";
            this.lblPlus5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblPlus5Standby
            // 
            this.lblPlus5Standby.HelpMessageKey = "VXIBackplane.Plus5Standby";
            this.lblPlus5Standby.Location = new System.Drawing.Point(6, 27);
            this.lblPlus5Standby.Name = "lblPlus5Standby";
            this.lblPlus5Standby.RequiredField = true;
            this.lblPlus5Standby.RequiredFieldMarkerFont = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPlus5Standby.Size = new System.Drawing.Size(70, 13);
            this.lblPlus5Standby.TabIndex = 12;
            this.lblPlus5Standby.Text = "+ 5 Standby";
            this.lblPlus5Standby.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // VXIBackplaneVoltagesControl
            // 
            this.Controls.Add(this.gbFrame);
            this.Name = "VXIBackplaneVoltagesControl";
            this.Size = new System.Drawing.Size(343, 141);
            this.gbFrame.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.edtMinus52)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtMinus24)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtMinus12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtMinus2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtPlus24)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtPlus12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtPlus5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtPlus5Standby)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbFrame;
        private HelpLabel lblMinus52;
        private HelpLabel lblMinus24;
        private HelpLabel lblPlus24;
        private HelpLabel lblMinus2;
        private HelpLabel lblMinus12;
        private HelpLabel lblPlus12;
        private HelpLabel lblPlus5;
        private HelpLabel lblPlus5Standby;
        private System.Windows.Forms.NumericUpDown edtMinus52;
        private System.Windows.Forms.NumericUpDown edtMinus24;
        private System.Windows.Forms.NumericUpDown edtMinus12;
        private System.Windows.Forms.NumericUpDown edtMinus2;
        private System.Windows.Forms.NumericUpDown edtPlus24;
        private System.Windows.Forms.NumericUpDown edtPlus12;
        private System.Windows.Forms.NumericUpDown edtPlus5;
        private System.Windows.Forms.NumericUpDown edtPlus5Standby;
    }
}
