/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
*
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/
namespace ATMLCommonLibrary.controls.power
{
    partial class PowerSpecificationForm
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
            this.rbACPower = new System.Windows.Forms.RadioButton();
            this.rbDCPower = new System.Windows.Forms.RadioButton();
            this.acPowerSpecificationControl = new ATMLCommonLibrary.controls.power.ACPowerSpecificationControl();
            this.dcPowerSpecificationControl = new ATMLCommonLibrary.controls.power.DCPowerSpecificationControl();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.rbDCPower);
            this.panel1.Controls.Add(this.rbACPower);
            this.panel1.Controls.Add(this.acPowerSpecificationControl);
            this.panel1.Controls.Add(this.dcPowerSpecificationControl);
            this.panel1.Size = new System.Drawing.Size(615, 465);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(553, 484);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(472, 484);
            this.btnOk.Text = "Save";
            // 
            // lblDenoteRequiredField
            // 
            this.lblDenoteRequiredField.Location = new System.Drawing.Point(1, 495);
            // 
            // rbACPower
            // 
            this.rbACPower.AutoSize = true;
            this.rbACPower.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbACPower.Location = new System.Drawing.Point(20, 10);
            this.rbACPower.Name = "rbACPower";
            this.rbACPower.Size = new System.Drawing.Size(203, 22);
            this.rbACPower.TabIndex = 0;
            this.rbACPower.TabStop = true;
            this.rbACPower.Text = "AC Power Specification";
            this.rbACPower.UseVisualStyleBackColor = true;
            this.rbACPower.CheckedChanged += new System.EventHandler(this.rbACPower_CheckedChanged);
            // 
            // rbDCPower
            // 
            this.rbDCPower.AutoSize = true;
            this.rbDCPower.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbDCPower.Location = new System.Drawing.Point(239, 10);
            this.rbDCPower.Name = "rbDCPower";
            this.rbDCPower.Size = new System.Drawing.Size(205, 22);
            this.rbDCPower.TabIndex = 1;
            this.rbDCPower.TabStop = true;
            this.rbDCPower.Text = "DC Power Specification";
            this.rbDCPower.UseVisualStyleBackColor = true;
            this.rbDCPower.CheckedChanged += new System.EventHandler(this.rbDCPower_CheckedChanged);
            // 
            // acPowerSpecificationControl
            // 
            this.acPowerSpecificationControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.acPowerSpecificationControl.AutoScroll = true;
            this.acPowerSpecificationControl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.acPowerSpecificationControl.Location = new System.Drawing.Point(3, 38);
            this.acPowerSpecificationControl.MinimumSize = new System.Drawing.Size(543, 300);
            this.acPowerSpecificationControl.Name = "acPowerSpecificationControl";
            this.acPowerSpecificationControl.SchemaTypeName = null;
            this.acPowerSpecificationControl.Size = new System.Drawing.Size(609, 427);
            this.acPowerSpecificationControl.TabIndex = 2;
            this.acPowerSpecificationControl.TargetNamespace = null;
            // 
            // dcPowerSpecificationControl
            // 
            this.dcPowerSpecificationControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dcPowerSpecificationControl.AutoScroll = true;
            this.dcPowerSpecificationControl.Location = new System.Drawing.Point(3, 38);
            this.dcPowerSpecificationControl.MinimumSize = new System.Drawing.Size(543, 300);
            this.dcPowerSpecificationControl.Name = "dcPowerSpecificationControl";
            this.dcPowerSpecificationControl.SchemaTypeName = null;
            this.dcPowerSpecificationControl.Size = new System.Drawing.Size(616, 427);
            this.dcPowerSpecificationControl.TabIndex = 3;
            this.dcPowerSpecificationControl.TargetNamespace = null;
            // 
            // PowerSpecificationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(640, 511);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "PowerSpecificationForm";
            this.Text = "Power Specification";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton rbDCPower;
        private System.Windows.Forms.RadioButton rbACPower;
        private ACPowerSpecificationControl acPowerSpecificationControl;
        private DCPowerSpecificationControl dcPowerSpecificationControl;
    }
}
