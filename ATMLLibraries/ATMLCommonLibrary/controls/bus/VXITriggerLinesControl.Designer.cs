/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
*
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/
namespace ATMLCommonLibrary.controls.bus
{
    partial class VXITriggerLinesControl
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
            this.label2 = new ATMLCommonLibrary.controls.HelpLabel(this.components);
            this.label1 = new ATMLCommonLibrary.controls.HelpLabel(this.components);
            this.chkSense = new System.Windows.Forms.CheckBox();
            this.chkSource = new System.Windows.Forms.CheckBox();
            this.edtSense = new System.Windows.Forms.NumericUpDown();
            this.edtSource = new System.Windows.Forms.NumericUpDown();
            this.gbFrame.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtSense)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSource)).BeginInit();
            this.SuspendLayout();
            // 
            // gbFrame
            // 
            this.gbFrame.Controls.Add(this.label2);
            this.gbFrame.Controls.Add(this.label1);
            this.gbFrame.Controls.Add(this.chkSense);
            this.gbFrame.Controls.Add(this.chkSource);
            this.gbFrame.Controls.Add(this.edtSense);
            this.gbFrame.Controls.Add(this.edtSource);
            this.gbFrame.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbFrame.Location = new System.Drawing.Point(0, 0);
            this.gbFrame.Name = "gbFrame";
            this.gbFrame.Size = new System.Drawing.Size(179, 89);
            this.gbFrame.TabIndex = 1;
            this.gbFrame.TabStop = false;
            this.gbFrame.Text = "VXI Trigger Lines";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.HelpMessageKey = "VXITriggerLines.Sense";
            this.label2.Location = new System.Drawing.Point(24, 55);
            this.label2.Name = "label2";
            this.label2.RequiredField = false;
            this.label2.RequiredFieldMarkerFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "Sense";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.HelpMessageKey = "VXITriggerLines.Source";
            this.label1.Location = new System.Drawing.Point(21, 26);
            this.label1.Name = "label1";
            this.label1.RequiredField = false;
            this.label1.RequiredFieldMarkerFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Source";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // chkSense
            // 
            this.chkSense.AutoSize = true;
            this.chkSense.Location = new System.Drawing.Point(6, 55);
            this.chkSense.Name = "chkSense";
            this.chkSense.Size = new System.Drawing.Size(15, 14);
            this.chkSense.TabIndex = 11;
            this.chkSense.UseVisualStyleBackColor = true;
            this.chkSense.CheckedChanged += new System.EventHandler(this.chkSense_CheckedChanged);
            // 
            // chkSource
            // 
            this.chkSource.AutoSize = true;
            this.chkSource.Location = new System.Drawing.Point(6, 27);
            this.chkSource.Name = "chkSource";
            this.chkSource.Size = new System.Drawing.Size(15, 14);
            this.chkSource.TabIndex = 10;
            this.chkSource.UseVisualStyleBackColor = true;
            this.chkSource.CheckedChanged += new System.EventHandler(this.chkSource_CheckedChanged);
            // 
            // edtSense
            // 
            this.edtSense.DecimalPlaces = 4;
            this.edtSense.Enabled = false;
            this.edtSense.Location = new System.Drawing.Point(67, 54);
            this.edtSense.Name = "edtSense";
            this.edtSense.Size = new System.Drawing.Size(91, 20);
            this.edtSense.TabIndex = 9;
            this.edtSense.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // edtSource
            // 
            this.edtSource.DecimalPlaces = 4;
            this.edtSource.Enabled = false;
            this.edtSource.Location = new System.Drawing.Point(67, 26);
            this.edtSource.Name = "edtSource";
            this.edtSource.Size = new System.Drawing.Size(91, 20);
            this.edtSource.TabIndex = 8;
            this.edtSource.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // VXITriggerLinesControl
            // 
            this.Controls.Add(this.gbFrame);
            this.Name = "VXITriggerLinesControl";
            this.Size = new System.Drawing.Size(179, 89);
            this.gbFrame.ResumeLayout(false);
            this.gbFrame.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtSense)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbFrame;
        private System.Windows.Forms.NumericUpDown edtSense;
        private System.Windows.Forms.NumericUpDown edtSource;
        private System.Windows.Forms.CheckBox chkSense;
        private System.Windows.Forms.CheckBox chkSource;
        private ATMLCommonLibrary.controls.HelpLabel label2;
        private ATMLCommonLibrary.controls.HelpLabel label1;
    }
}
