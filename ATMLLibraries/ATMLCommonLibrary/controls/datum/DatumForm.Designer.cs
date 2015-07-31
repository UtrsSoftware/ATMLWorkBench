/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
*
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/
using ATMLCommonLibrary.controls.datum;

namespace ATMLCommonLibrary.forms
{
    partial class DatumForm
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
            this.datumTypeControl = new ATMLCommonLibrary.controls.datum.DatumTypeControl();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.datumTypeControl);
            this.panel1.Size = new System.Drawing.Size(602, 565);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(540, 584);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(459, 584);
            // 
            // lblDenoteRequiredField
            // 
            this.lblDenoteRequiredField.Location = new System.Drawing.Point(1, 594);
            // 
            // datumTypeControl
            // 
            this.datumTypeControl.BackColor = System.Drawing.Color.AliceBlue;
            this.datumTypeControl.DefaultComparitor = -1;
            this.datumTypeControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.datumTypeControl.Location = new System.Drawing.Point(0, 0);
            this.datumTypeControl.MinimumSize = new System.Drawing.Size(594, 548);
            this.datumTypeControl.Name = "datumTypeControl";
            this.datumTypeControl.SchemaTypeName = null;
            this.datumTypeControl.Size = new System.Drawing.Size(602, 565);
            this.datumTypeControl.TabIndex = 2;
            this.datumTypeControl.TargetNamespace = null;
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // DatumForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(627, 609);
            this.MinimumSize = new System.Drawing.Size(643, 581);
            this.Name = "DatumForm";
            this.Text = "Datum";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DatumTypeControl datumTypeControl;
        private System.Windows.Forms.ErrorProvider errorProvider;
    }
}