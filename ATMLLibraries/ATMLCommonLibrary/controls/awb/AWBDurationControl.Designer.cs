/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
* 
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

namespace ATMLCommonLibrary.controls.awb
{
    partial class AWBDurationControl
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
            this.numYears = new System.Windows.Forms.NumericUpDown();
            this.lblYear = new System.Windows.Forms.Label();
            this.lblMonth = new System.Windows.Forms.Label();
            this.numMonths = new System.Windows.Forms.NumericUpDown();
            this.lblDay = new System.Windows.Forms.Label();
            this.numDays = new System.Windows.Forms.NumericUpDown();
            this.lblHour = new System.Windows.Forms.Label();
            this.numHours = new System.Windows.Forms.NumericUpDown();
            this.lblMinute = new System.Windows.Forms.Label();
            this.numMinutes = new System.Windows.Forms.NumericUpDown();
            this.lblSecond = new System.Windows.Forms.Label();
            this.numSeconds = new System.Windows.Forms.NumericUpDown();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.numYears)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMonths)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDays)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numHours)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMinutes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSeconds)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // numYears
            // 
            this.numYears.Location = new System.Drawing.Point(26, 3);
            this.numYears.Name = "numYears";
            this.numYears.Size = new System.Drawing.Size(45, 20);
            this.numYears.TabIndex = 0;
            this.numYears.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblYear
            // 
            this.lblYear.Location = new System.Drawing.Point(3, 0);
            this.lblYear.Name = "lblYear";
            this.lblYear.Size = new System.Drawing.Size(17, 20);
            this.lblYear.TabIndex = 1;
            this.lblYear.Text = "Y:";
            this.lblYear.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblMonth
            // 
            this.lblMonth.Location = new System.Drawing.Point(77, 0);
            this.lblMonth.Name = "lblMonth";
            this.lblMonth.Size = new System.Drawing.Size(19, 20);
            this.lblMonth.TabIndex = 3;
            this.lblMonth.Text = "M:";
            this.lblMonth.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // numMonths
            // 
            this.numMonths.Location = new System.Drawing.Point(102, 3);
            this.numMonths.Name = "numMonths";
            this.numMonths.Size = new System.Drawing.Size(45, 20);
            this.numMonths.TabIndex = 2;
            this.numMonths.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblDay
            // 
            this.lblDay.Location = new System.Drawing.Point(153, 0);
            this.lblDay.Name = "lblDay";
            this.lblDay.Size = new System.Drawing.Size(18, 20);
            this.lblDay.TabIndex = 5;
            this.lblDay.Text = "D:";
            this.lblDay.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // numDays
            // 
            this.numDays.Location = new System.Drawing.Point(177, 3);
            this.numDays.Name = "numDays";
            this.numDays.Size = new System.Drawing.Size(45, 20);
            this.numDays.TabIndex = 4;
            this.numDays.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblHour
            // 
            this.lblHour.Location = new System.Drawing.Point(228, 0);
            this.lblHour.Name = "lblHour";
            this.lblHour.Size = new System.Drawing.Size(18, 20);
            this.lblHour.TabIndex = 7;
            this.lblHour.Text = "H:";
            this.lblHour.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // numHours
            // 
            this.numHours.Location = new System.Drawing.Point(252, 3);
            this.numHours.Name = "numHours";
            this.numHours.Size = new System.Drawing.Size(45, 20);
            this.numHours.TabIndex = 6;
            this.numHours.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblMinute
            // 
            this.lblMinute.Location = new System.Drawing.Point(303, 0);
            this.lblMinute.Name = "lblMinute";
            this.lblMinute.Size = new System.Drawing.Size(18, 20);
            this.lblMinute.TabIndex = 9;
            this.lblMinute.Text = "m:";
            this.lblMinute.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // numMinutes
            // 
            this.numMinutes.Location = new System.Drawing.Point(327, 3);
            this.numMinutes.Name = "numMinutes";
            this.numMinutes.Size = new System.Drawing.Size(45, 20);
            this.numMinutes.TabIndex = 8;
            this.numMinutes.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblSecond
            // 
            this.lblSecond.Location = new System.Drawing.Point(378, 0);
            this.lblSecond.Name = "lblSecond";
            this.lblSecond.Size = new System.Drawing.Size(18, 20);
            this.lblSecond.TabIndex = 11;
            this.lblSecond.Text = "s:";
            this.lblSecond.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // numSeconds
            // 
            this.numSeconds.Location = new System.Drawing.Point(402, 3);
            this.numSeconds.Name = "numSeconds";
            this.numSeconds.Size = new System.Drawing.Size(45, 20);
            this.numSeconds.TabIndex = 10;
            this.numSeconds.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.lblYear);
            this.flowLayoutPanel1.Controls.Add(this.numYears);
            this.flowLayoutPanel1.Controls.Add(this.lblMonth);
            this.flowLayoutPanel1.Controls.Add(this.numMonths);
            this.flowLayoutPanel1.Controls.Add(this.lblDay);
            this.flowLayoutPanel1.Controls.Add(this.numDays);
            this.flowLayoutPanel1.Controls.Add(this.lblHour);
            this.flowLayoutPanel1.Controls.Add(this.numHours);
            this.flowLayoutPanel1.Controls.Add(this.lblMinute);
            this.flowLayoutPanel1.Controls.Add(this.numMinutes);
            this.flowLayoutPanel1.Controls.Add(this.lblSecond);
            this.flowLayoutPanel1.Controls.Add(this.numSeconds);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(454, 28);
            this.flowLayoutPanel1.TabIndex = 12;
            // 
            // AWBTimeSpan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.flowLayoutPanel1);
            this.Name = "AWBTimeSpan";
            this.Size = new System.Drawing.Size(454, 28);
            ((System.ComponentModel.ISupportInitialize)(this.numYears)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMonths)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDays)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numHours)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMinutes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSeconds)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.NumericUpDown numYears;
        private System.Windows.Forms.Label lblYear;
        private System.Windows.Forms.Label lblMonth;
        private System.Windows.Forms.NumericUpDown numMonths;
        private System.Windows.Forms.Label lblDay;
        private System.Windows.Forms.NumericUpDown numDays;
        private System.Windows.Forms.Label lblHour;
        private System.Windows.Forms.NumericUpDown numHours;
        private System.Windows.Forms.Label lblMinute;
        private System.Windows.Forms.NumericUpDown numMinutes;
        private System.Windows.Forms.Label lblSecond;
        private System.Windows.Forms.NumericUpDown numSeconds;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
    }
}
