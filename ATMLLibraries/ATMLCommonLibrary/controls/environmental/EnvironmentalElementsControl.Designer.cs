/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
*
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/
namespace ATMLCommonLibrary.controls.environmental
{
    partial class EnvironmentalElementsControl
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
            this.Vibrations = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.shock = new ATMLCommonLibrary.controls.limit.LimitSimpleControl();
            this.temperature = new ATMLCommonLibrary.controls.limit.LimitSimpleControl();
            this.humidity = new ATMLCommonLibrary.controls.limit.LimitSimpleControl();
            this.altitude = new ATMLCommonLibrary.controls.limit.LimitSimpleControl();
            this.helpLabel4 = new ATMLCommonLibrary.controls.HelpLabel(this.components);
            this.helpLabel3 = new ATMLCommonLibrary.controls.HelpLabel(this.components);
            this.helpLabel2 = new ATMLCommonLibrary.controls.HelpLabel(this.components);
            this.helpLabel1 = new ATMLCommonLibrary.controls.HelpLabel(this.components);
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.environmentalElementsVibrationControl = new ATMLCommonLibrary.controls.environmental.EnvironmentalElementsVibrationControl();
            this.Vibrations.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // Vibrations
            // 
            this.Vibrations.Controls.Add(this.tabPage1);
            this.Vibrations.Controls.Add(this.tabPage2);
            this.Vibrations.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Vibrations.Location = new System.Drawing.Point(0, 0);
            this.Vibrations.Name = "Vibrations";
            this.Vibrations.SelectedIndex = 0;
            this.Vibrations.Size = new System.Drawing.Size(413, 176);
            this.Vibrations.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.shock);
            this.tabPage1.Controls.Add(this.temperature);
            this.tabPage1.Controls.Add(this.humidity);
            this.tabPage1.Controls.Add(this.altitude);
            this.tabPage1.Controls.Add(this.helpLabel4);
            this.tabPage1.Controls.Add(this.helpLabel3);
            this.tabPage1.Controls.Add(this.helpLabel2);
            this.tabPage1.Controls.Add(this.helpLabel1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(405, 150);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Elements";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // shock
            // 
            this.shock.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.shock.Limit = null;
            this.shock.Location = new System.Drawing.Point(76, 76);
            this.shock.Margin = new System.Windows.Forms.Padding(0);
            this.shock.Name = "shock";
            this.shock.SchemaTypeName = null;
            this.shock.Size = new System.Drawing.Size(302, 24);
            this.shock.TabIndex = 5;
            this.shock.TargetNamespace = null;
            // 
            // temperature
            // 
            this.temperature.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.temperature.Limit = null;
            this.temperature.Location = new System.Drawing.Point(77, 108);
            this.temperature.Margin = new System.Windows.Forms.Padding(0);
            this.temperature.Name = "temperature";
            this.temperature.SchemaTypeName = null;
            this.temperature.Size = new System.Drawing.Size(301, 24);
            this.temperature.TabIndex = 7;
            this.temperature.TargetNamespace = null;
            // 
            // humidity
            // 
            this.humidity.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.humidity.Limit = null;
            this.humidity.Location = new System.Drawing.Point(76, 41);
            this.humidity.Margin = new System.Windows.Forms.Padding(0);
            this.humidity.Name = "humidity";
            this.humidity.SchemaTypeName = null;
            this.humidity.Size = new System.Drawing.Size(302, 24);
            this.humidity.TabIndex = 3;
            this.humidity.TargetNamespace = null;
            this.humidity.Load += new System.EventHandler(this.humidity_Load);
            // 
            // altitude
            // 
            this.altitude.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.altitude.Limit = null;
            this.altitude.Location = new System.Drawing.Point(76, 10);
            this.altitude.Margin = new System.Windows.Forms.Padding(0);
            this.altitude.Name = "altitude";
            this.altitude.SchemaTypeName = null;
            this.altitude.Size = new System.Drawing.Size(302, 24);
            this.altitude.TabIndex = 1;
            this.altitude.TargetNamespace = null;
            // 
            // helpLabel4
            // 
            this.helpLabel4.AutoSize = true;
            this.helpLabel4.HelpMessageKey = "EnvironmentElements.temperature";
            this.helpLabel4.Location = new System.Drawing.Point(3, 109);
            this.helpLabel4.Name = "helpLabel4";
            this.helpLabel4.RequiredField = false;
            this.helpLabel4.RequiredFieldMarkerFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.helpLabel4.Size = new System.Drawing.Size(67, 13);
            this.helpLabel4.TabIndex = 6;
            this.helpLabel4.Text = "Temperature";
            // 
            // helpLabel3
            // 
            this.helpLabel3.AutoSize = true;
            this.helpLabel3.HelpMessageKey = "EnvironmentElements.shock";
            this.helpLabel3.Location = new System.Drawing.Point(32, 77);
            this.helpLabel3.Name = "helpLabel3";
            this.helpLabel3.RequiredField = false;
            this.helpLabel3.RequiredFieldMarkerFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.helpLabel3.Size = new System.Drawing.Size(38, 13);
            this.helpLabel3.TabIndex = 4;
            this.helpLabel3.Text = "Shock";
            // 
            // helpLabel2
            // 
            this.helpLabel2.AutoSize = true;
            this.helpLabel2.HelpMessageKey = "EnvironmentElements.Humidity";
            this.helpLabel2.Location = new System.Drawing.Point(23, 42);
            this.helpLabel2.Name = "helpLabel2";
            this.helpLabel2.RequiredField = false;
            this.helpLabel2.RequiredFieldMarkerFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.helpLabel2.Size = new System.Drawing.Size(47, 13);
            this.helpLabel2.TabIndex = 2;
            this.helpLabel2.Text = "Humidity";
            // 
            // helpLabel1
            // 
            this.helpLabel1.AutoSize = true;
            this.helpLabel1.HelpMessageKey = "EnvironmentElements.Altitude";
            this.helpLabel1.Location = new System.Drawing.Point(28, 13);
            this.helpLabel1.Name = "helpLabel1";
            this.helpLabel1.RequiredField = false;
            this.helpLabel1.RequiredFieldMarkerFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.helpLabel1.Size = new System.Drawing.Size(42, 13);
            this.helpLabel1.TabIndex = 0;
            this.helpLabel1.Text = "Altitude";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.environmentalElementsVibrationControl);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(405, 150);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Vibrations";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // environmentalElementsVibrationControl
            // 
            this.environmentalElementsVibrationControl.AutoScroll = true;
            this.environmentalElementsVibrationControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.environmentalElementsVibrationControl.Location = new System.Drawing.Point(3, 3);
            this.environmentalElementsVibrationControl.Name = "environmentalElementsVibrationControl";
            this.environmentalElementsVibrationControl.SchemaTypeName = null;
            this.environmentalElementsVibrationControl.Size = new System.Drawing.Size(399, 144);
            this.environmentalElementsVibrationControl.TabIndex = 0;
            this.environmentalElementsVibrationControl.TargetNamespace = null;
            // 
            // EnvironmentalElementsControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.Vibrations);
            this.Name = "EnvironmentalElementsControl";
            this.Size = new System.Drawing.Size(413, 176);
            this.Vibrations.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl Vibrations;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private HelpLabel helpLabel4;
        private HelpLabel helpLabel3;
        private HelpLabel helpLabel2;
        private HelpLabel helpLabel1;
        private limit.LimitSimpleControl shock;
        private limit.LimitSimpleControl temperature;
        private limit.LimitSimpleControl humidity;
        private limit.LimitSimpleControl altitude;
        private EnvironmentalElementsVibrationControl environmentalElementsVibrationControl;
    }
}
