/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
* 
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

using ATMLCommonLibrary.controls.instrument;

namespace ATMLCommonLibrary.controls.equipment
{
    partial class TestStationDescriptionInstrumentForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TestStationDescriptionInstrumentForm));
            this.testStationDescriptionInstrumentControl1 = new ATMLCommonLibrary.controls.instrument.TestStationDescriptionInstrumentControl();
            this.btnEditObject = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.testStationDescriptionInstrumentControl1);
            this.panel1.Size = new System.Drawing.Size(617, 431);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(555, 449);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(474, 449);
            // 
            // lblDenoteRequiredField
            // 
            this.lblDenoteRequiredField.Location = new System.Drawing.Point(1, 460);
            // 
            // testStationDescriptionInstrumentControl1
            // 
            this.testStationDescriptionInstrumentControl1.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.testStationDescriptionInstrumentControl1.BackColor = System.Drawing.Color.LightSlateGray;
            this.testStationDescriptionInstrumentControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.testStationDescriptionInstrumentControl1.Location = new System.Drawing.Point(0, 0);
            this.testStationDescriptionInstrumentControl1.Name = "testStationDescriptionInstrumentControl1";
            this.testStationDescriptionInstrumentControl1.SchemaTypeName = null;
            this.testStationDescriptionInstrumentControl1.Size = new System.Drawing.Size(617, 431);
            this.testStationDescriptionInstrumentControl1.TabIndex = 0;
            this.testStationDescriptionInstrumentControl1.TargetNamespace = null;
            this.testStationDescriptionInstrumentControl1.TestStationDescriptionInstrument = ((ATMLModelLibrary.model.equipment.TestStationDescriptionInstrument)(resources.GetObject("testStationDescriptionInstrumentControl1.TestStationDescriptionInstrument")));
            // 
            // btnEditObject
            // 
            this.btnEditObject.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEditObject.Location = new System.Drawing.Point(393, 449);
            this.btnEditObject.Name = "btnEditObject";
            this.btnEditObject.Size = new System.Drawing.Size(75, 23);
            this.btnEditObject.TabIndex = 7;
            this.btnEditObject.Text = "Edit";
            this.btnEditObject.UseVisualStyleBackColor = true;
            this.btnEditObject.Click += new System.EventHandler(this.btnEditObject_Click);
            // 
            // TestStationDescriptionInstrumentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(642, 476);
            this.Controls.Add(this.btnEditObject);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TestStationDescriptionInstrumentForm";
            this.Text = "Test Station Instrument";
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.btnOk, 0);
            this.Controls.SetChildIndex(this.btnCancel, 0);
            this.Controls.SetChildIndex(this.lblDenoteRequiredField, 0);
            this.Controls.SetChildIndex(this.btnEditObject, 0);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TestStationDescriptionInstrumentControl testStationDescriptionInstrumentControl1;
        private System.Windows.Forms.Button btnEditObject;

    }
}
