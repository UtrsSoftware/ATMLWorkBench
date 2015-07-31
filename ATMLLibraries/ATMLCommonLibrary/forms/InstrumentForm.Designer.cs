/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
*
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/
using ATMLCommonLibrary.controls.instrument;

namespace ATMLCommonLibrary.forms
{
    partial class InstrumentForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InstrumentForm));
            this.instrumentControl = new ATMLCommonLibrary.controls.instrument.InstrumentControl();
            this.btnValidate = new System.Windows.Forms.Button();
            this.btnViewATML = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.instrumentControl);
            this.panel1.Location = new System.Drawing.Point(13, 15);
            this.panel1.Size = new System.Drawing.Size(745, 559);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(683, 582);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Close";
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(602, 582);
            this.btnOk.TabIndex = 2;
            this.btnOk.Text = "Save";
            this.btnOk.Validating += new System.ComponentModel.CancelEventHandler(this.btnOk_Validating);
            // 
            // lblDenoteRequiredField
            // 
            this.lblDenoteRequiredField.Location = new System.Drawing.Point(1, 598);
            this.lblDenoteRequiredField.TabIndex = 0;
            // 
            // instrumentControl
            // 
            this.instrumentControl.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.instrumentControl.BackColor = System.Drawing.Color.AliceBlue;
            this.instrumentControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.instrumentControl.HasErrors = false;
            this.instrumentControl.HelpKeyWord = null;
            this.instrumentControl.LastError = null;
            this.instrumentControl.Location = new System.Drawing.Point(0, 0);
            this.instrumentControl.Name = "instrumentControl";
            this.instrumentControl.SchemaTypeName = "InstrumentDescription";
            this.instrumentControl.Size = new System.Drawing.Size(745, 559);
            this.instrumentControl.TabIndex = 0;
            this.instrumentControl.TargetNamespace = "urn:IEEE-1671.2:2012:InstrumentDescription";
            // 
            // btnValidate
            // 
            this.btnValidate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnValidate.Location = new System.Drawing.Point(521, 582);
            this.btnValidate.Name = "btnValidate";
            this.btnValidate.Size = new System.Drawing.Size(75, 23);
            this.btnValidate.TabIndex = 1;
            this.btnValidate.Text = "Validate";
            this.btnValidate.UseVisualStyleBackColor = true;
            this.btnValidate.Click += new System.EventHandler(this.btnValidate_Click);
            // 
            // btnViewATML
            // 
            this.btnViewATML.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnViewATML.Location = new System.Drawing.Point(440, 582);
            this.btnViewATML.Name = "btnViewATML";
            this.btnViewATML.Size = new System.Drawing.Size(75, 23);
            this.btnViewATML.TabIndex = 4;
            this.btnViewATML.Text = "View ATML";
            this.btnViewATML.UseVisualStyleBackColor = true;
            this.btnViewATML.Click += new System.EventHandler(this.btnViewATML_Click);
            // 
            // InstrumentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(770, 612);
            this.Controls.Add(this.btnViewATML);
            this.Controls.Add(this.btnValidate);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "InstrumentForm";
            this.Text = "Instrument Description";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.InstrumentForm_FormClosing);
            this.Validating += new System.ComponentModel.CancelEventHandler(this.InstrumentForm_Validating);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.btnOk, 0);
            this.Controls.SetChildIndex(this.btnCancel, 0);
            this.Controls.SetChildIndex(this.lblDenoteRequiredField, 0);
            this.Controls.SetChildIndex(this.btnValidate, 0);
            this.Controls.SetChildIndex(this.btnViewATML, 0);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private InstrumentControl instrumentControl;
        private System.Windows.Forms.Button btnValidate;
        private System.Windows.Forms.Button btnViewATML;

    }
}