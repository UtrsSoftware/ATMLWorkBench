/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
* 
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

namespace ATML1671Reader.forms
{
    partial class SoftwareInstanceForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SoftwareInstanceForm));
            this.softwareInstanceControl1 = new ATML1671Reader.controls.SoftwareInstanceControl();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.softwareInstanceControl1);
            this.panel1.Size = new System.Drawing.Size(519, 421);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(457, 440);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(375, 440);
            // 
            // lblDenoteRequiredField
            // 
            this.lblDenoteRequiredField.Location = new System.Drawing.Point(10, 452);
            // 
            // softwareInstanceControl1
            // 
            this.softwareInstanceControl1.BackColor = System.Drawing.Color.LightSlateGray;
            this.softwareInstanceControl1.HelpKeyWord = null;
            this.softwareInstanceControl1.ItemInstance = ((ATMLModelLibrary.model.common.ItemInstance)(resources.GetObject("softwareInstanceControl1.ItemInstance")));
            this.softwareInstanceControl1.Location = new System.Drawing.Point(0, 0);
            this.softwareInstanceControl1.Name = "softwareInstanceControl1";
            this.softwareInstanceControl1.SchemaTypeName = null;
            this.softwareInstanceControl1.Size = new System.Drawing.Size(516, 418);
            this.softwareInstanceControl1.SoftwareInstance = null;
            this.softwareInstanceControl1.TabIndex = 0;
            this.softwareInstanceControl1.TargetNamespace = null;
            // 
            // SoftwareInstanceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(544, 474);
            this.Name = "SoftwareInstanceForm";
            this.Text = "Software Instance";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private controls.SoftwareInstanceControl softwareInstanceControl1;
    }
}