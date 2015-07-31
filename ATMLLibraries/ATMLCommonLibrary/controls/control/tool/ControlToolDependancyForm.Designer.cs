/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
* 
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

namespace ATMLCommonLibrary.controls.control.tool
{
    partial class ControlToolDependancyForm
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
            this.rbDriver = new System.Windows.Forms.RadioButton();
            this.rbSoftware = new System.Windows.Forms.RadioButton();
            this.controlToolDependancyControl1 = new ATMLCommonLibrary.controls.control.tool.ControlToolDependancyControl();
            this.helpLabel1 = new ATMLCommonLibrary.controls.HelpLabel(this.components);
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.helpLabel1);
            this.panel1.Controls.Add(this.rbSoftware);
            this.panel1.Controls.Add(this.rbDriver);
            this.panel1.Controls.Add(this.controlToolDependancyControl1);
            this.panel1.Size = new System.Drawing.Size(407, 97);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(345, 115);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(264, 115);
            // 
            // lblDenoteRequiredField
            // 
            this.lblDenoteRequiredField.Location = new System.Drawing.Point(1, 126);
            // 
            // rbDriver
            // 
            this.rbDriver.AutoSize = true;
            this.rbDriver.Location = new System.Drawing.Point(108, 9);
            this.rbDriver.Name = "rbDriver";
            this.rbDriver.Size = new System.Drawing.Size(53, 17);
            this.rbDriver.TabIndex = 0;
            this.rbDriver.TabStop = true;
            this.rbDriver.Text = "Driver";
            this.rbDriver.UseVisualStyleBackColor = true;
            // 
            // rbSoftware
            // 
            this.rbSoftware.AutoSize = true;
            this.rbSoftware.Location = new System.Drawing.Point(179, 9);
            this.rbSoftware.Name = "rbSoftware";
            this.rbSoftware.Size = new System.Drawing.Size(67, 17);
            this.rbSoftware.TabIndex = 1;
            this.rbSoftware.TabStop = true;
            this.rbSoftware.Text = "Software";
            this.rbSoftware.UseVisualStyleBackColor = true;
            // 
            // controlToolDependancyControl1
            // 
            this.controlToolDependancyControl1.BackColor = System.Drawing.Color.AliceBlue;
            this.controlToolDependancyControl1.HasErrors = false;
            this.controlToolDependancyControl1.HelpKeyWord = null;
            this.controlToolDependancyControl1.LastError = null;
            this.controlToolDependancyControl1.Location = new System.Drawing.Point(18, 22);
            this.controlToolDependancyControl1.Name = "controlToolDependancyControl1";
            this.controlToolDependancyControl1.SchemaTypeName = null;
            this.controlToolDependancyControl1.Size = new System.Drawing.Size(390, 65);
            this.controlToolDependancyControl1.TabIndex = 2;
            this.controlToolDependancyControl1.TargetNamespace = null;
            // 
            // helpLabel1
            // 
            this.helpLabel1.AutoSize = true;
            this.helpLabel1.HelpMessageKey = "ControlToolDepenency.DependencyType";
            this.helpLabel1.Location = new System.Drawing.Point(8, 10);
            this.helpLabel1.Name = "helpLabel1";
            this.helpLabel1.RequiredField = false;
            this.helpLabel1.RequiredFieldMarkerFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.helpLabel1.Size = new System.Drawing.Size(95, 13);
            this.helpLabel1.TabIndex = 3;
            this.helpLabel1.Text = "Dependancy Type";
            // 
            // ControlToolDependancyForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(432, 142);
            this.Location = new System.Drawing.Point(0, 0);
            this.MaximumSize = new System.Drawing.Size(700, 180);
            this.MinimumSize = new System.Drawing.Size(448, 180);
            this.Name = "ControlToolDependancyForm";
            this.Text = "Control Tool Dependancy";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton rbSoftware;
        private System.Windows.Forms.RadioButton rbDriver;
        private HelpLabel helpLabel1;
        private ControlToolDependancyControl controlToolDependancyControl1;
    }
}