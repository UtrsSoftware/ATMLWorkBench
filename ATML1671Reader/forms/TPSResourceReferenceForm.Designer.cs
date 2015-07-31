/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
* 
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

namespace ATML1671Reader.forms
{
    partial class TPSResourceReferenceForm
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
            this.tpsResourceReferenceControl = new ATML1671Reader.controls.TpsResourceReferenceControl();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tpsResourceReferenceControl);
            this.panel1.Size = new System.Drawing.Size(524, 448);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(462, 466);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(381, 466);
            // 
            // lblDenoteRequiredField
            // 
            this.lblDenoteRequiredField.Location = new System.Drawing.Point(1, 477);
            // 
            // tpsResourceReferenceControl
            // 
            this.tpsResourceReferenceControl.BackColor = System.Drawing.Color.LightSlateGray;
            this.tpsResourceReferenceControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tpsResourceReferenceControl.DocumentType = ATMLDataAccessLibrary.model.dbDocument.DocumentType.NONE;
            this.tpsResourceReferenceControl.HelpKeyWord = null;
            this.tpsResourceReferenceControl.Location = new System.Drawing.Point(0, 0);
            this.tpsResourceReferenceControl.Name = "tpsResourceReferenceControl";
            this.tpsResourceReferenceControl.SchemaTypeName = null;
            this.tpsResourceReferenceControl.Size = new System.Drawing.Size(524, 448);
            this.tpsResourceReferenceControl.TabIndex = 0;
            this.tpsResourceReferenceControl.TargetNamespace = null;
            // 
            // TPSResourceReferenceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(549, 493);
            this.Name = "TPSResourceReferenceForm";
            this.Text = "TPS Resource Reference";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private controls.TpsResourceReferenceControl tpsResourceReferenceControl;
    }
}
