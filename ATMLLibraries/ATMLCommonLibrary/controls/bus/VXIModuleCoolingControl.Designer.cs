/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
*
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/
namespace ATMLCommonLibrary.controls.bus
{
    partial class VXIModuleCoolingControl
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
            this.lblAirFlow = new ATMLCommonLibrary.controls.HelpLabel(this.components);
            this.lblBackPressure = new ATMLCommonLibrary.controls.HelpLabel(this.components);
            this.edtAirFlow = new System.Windows.Forms.NumericUpDown();
            this.edtBackPressure = new System.Windows.Forms.NumericUpDown();
            this.gbFrame.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtAirFlow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBackPressure)).BeginInit();
            this.SuspendLayout();
            // 
            // gbFrame
            // 
            this.gbFrame.Controls.Add(this.lblAirFlow);
            this.gbFrame.Controls.Add(this.lblBackPressure);
            this.gbFrame.Controls.Add(this.edtAirFlow);
            this.gbFrame.Controls.Add(this.edtBackPressure);
            this.gbFrame.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbFrame.Location = new System.Drawing.Point(0, 0);
            this.gbFrame.Name = "gbFrame";
            this.gbFrame.Size = new System.Drawing.Size(195, 91);
            this.gbFrame.TabIndex = 2;
            this.gbFrame.TabStop = false;
            this.gbFrame.Text = "VXI Module Cooling";
            // 
            // lblAirFlow
            // 
            this.lblAirFlow.HelpMessageKey = "VXI.AirFlow";
            this.lblAirFlow.Location = new System.Drawing.Point(6, 56);
            this.lblAirFlow.Name = "lblAirFlow";
            this.lblAirFlow.RequiredField = true;
            this.lblAirFlow.RequiredFieldMarkerFont = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAirFlow.Size = new System.Drawing.Size(49, 13);
            this.lblAirFlow.TabIndex = 11;
            this.lblAirFlow.Text = "Air Flow";
            // 
            // lblBackPressure
            // 
            this.lblBackPressure.HelpMessageKey = "VXI.BackPressure";
            this.lblBackPressure.Location = new System.Drawing.Point(6, 28);
            this.lblBackPressure.Name = "lblBackPressure";
            this.lblBackPressure.RequiredField = true;
            this.lblBackPressure.RequiredFieldMarkerFont = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBackPressure.Size = new System.Drawing.Size(81, 13);
            this.lblBackPressure.TabIndex = 10;
            this.lblBackPressure.Text = "Back Pressure";
            // 
            // edtAirFlow
            // 
            this.edtAirFlow.DecimalPlaces = 4;
            this.edtAirFlow.Location = new System.Drawing.Point(89, 54);
            this.edtAirFlow.Name = "edtAirFlow";
            this.edtAirFlow.Size = new System.Drawing.Size(87, 20);
            this.edtAirFlow.TabIndex = 9;
            this.edtAirFlow.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // edtBackPressure
            // 
            this.edtBackPressure.DecimalPlaces = 4;
            this.edtBackPressure.Location = new System.Drawing.Point(89, 26);
            this.edtBackPressure.Name = "edtBackPressure";
            this.edtBackPressure.Size = new System.Drawing.Size(87, 20);
            this.edtBackPressure.TabIndex = 8;
            this.edtBackPressure.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // VXIModuleCoolingControl
            // 
            this.Controls.Add(this.gbFrame);
            this.Name = "VXIModuleCoolingControl";
            this.Size = new System.Drawing.Size(195, 91);
            this.gbFrame.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.edtAirFlow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBackPressure)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbFrame;
        private HelpLabel lblBackPressure;
        private System.Windows.Forms.NumericUpDown edtAirFlow;
        private System.Windows.Forms.NumericUpDown edtBackPressure;
        private HelpLabel lblAirFlow;
    }
}
