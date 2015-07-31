/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
*
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/
using ATMLCommonLibrary.controls.specification;

namespace ATMLCommonLibrary.forms
{
    partial class SpecificationForm
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
            if( disposing && ( components != null ) )
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
            this.specificationControl = new SpecificationControl();
            this.specificationGroupControl = new ATMLCommonLibrary.controls.SpecificationGroupControl();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbSpecificationType = new System.Windows.Forms.ComboBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cmbSpecificationType);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Size = new System.Drawing.Size(521, 411);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(459, 430);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(378, 430);
            // 
            // lblDenoteRequiredField
            // 
            this.lblDenoteRequiredField.Location = new System.Drawing.Point(1, 440);
            // 
            // specificationControl
            // 
            this.specificationControl.BackColor = System.Drawing.Color.AliceBlue;
            this.specificationControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.specificationControl.Location = new System.Drawing.Point(0, 0);
            this.specificationControl.Name = "specificationControl";
            this.specificationControl.Size = new System.Drawing.Size(521, 382);
            this.specificationControl.TabIndex = 4;
            // 
            // specificationGroupControl
            // 
            this.specificationGroupControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.specificationGroupControl.Location = new System.Drawing.Point(0, 0);
            this.specificationGroupControl.Name = "specificationGroupControl";
            this.specificationGroupControl.SchemaTypeName = null;
            this.specificationGroupControl.Size = new System.Drawing.Size(521, 382);
            this.specificationGroupControl.TabIndex = 7;
            this.specificationGroupControl.TargetNamespace = null;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.specificationControl);
            this.panel2.Controls.Add(this.specificationGroupControl);
            this.panel2.Location = new System.Drawing.Point(0, 29);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(521, 382);
            this.panel2.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(37, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Type";
            // 
            // cmbSpecificationType
            // 
            this.cmbSpecificationType.FormattingEnabled = true;
            this.cmbSpecificationType.Items.AddRange(new object[] {
            "Characteristic",
            "Feature",
            "Guaranteed",
            "Nominal",
            "Specification Group",
            "Typical"});
            this.cmbSpecificationType.Location = new System.Drawing.Point(71, 14);
            this.cmbSpecificationType.Name = "cmbSpecificationType";
            this.cmbSpecificationType.Size = new System.Drawing.Size(434, 21);
            this.cmbSpecificationType.TabIndex = 10;
            this.cmbSpecificationType.SelectedIndexChanged += new System.EventHandler(this.cmbSpecificationType_SelectedIndexChanged);
            // 
            // SpecificationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(546, 456);
            this.Name = "SpecificationForm";
            this.Text = "Specification";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private SpecificationControl specificationControl;
        private System.Windows.Forms.Panel panel2;
        private controls.SpecificationGroupControl specificationGroupControl;
        private System.Windows.Forms.ComboBox cmbSpecificationType;
        private System.Windows.Forms.Label label1;
    }
}