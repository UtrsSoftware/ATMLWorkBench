/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
*
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/
namespace ATMLCommonLibrary.controls.path
{
    partial class PathSParameterDataControl
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
            this.DatumMagnitude = new ATMLCommonLibrary.controls.datum.DatumTypeDoubleControl();
            this.DatumPhase = new ATMLCommonLibrary.controls.datum.DatumTypeDoubleControl();
            this.DatumFrequency = new ATMLCommonLibrary.controls.datum.DatumTypeDoubleControl();
            this.helpLabel1 = new ATMLCommonLibrary.controls.HelpLabel(this.components);
            this.helpLabel2 = new ATMLCommonLibrary.controls.HelpLabel(this.components);
            this.helpLabel3 = new ATMLCommonLibrary.controls.HelpLabel(this.components);
            this.SuspendLayout();
            // 
            // DatumMagnitude
            // 
            this.DatumMagnitude.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DatumMagnitude.BackColor = System.Drawing.Color.White;
            this.DatumMagnitude.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.DatumMagnitude.Location = new System.Drawing.Point(14, 21);
            this.DatumMagnitude.Name = "DatumMagnitude";
            this.DatumMagnitude.SchemaTypeName = null;
            this.DatumMagnitude.Size = new System.Drawing.Size(387, 28);
            this.DatumMagnitude.TabIndex = 0;
            this.DatumMagnitude.TargetNamespace = null;
            this.DatumMagnitude.UseFlowControl = null;
            // 
            // DatumPhase
            // 
            this.DatumPhase.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DatumPhase.BackColor = System.Drawing.Color.White;
            this.DatumPhase.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.DatumPhase.Location = new System.Drawing.Point(14, 72);
            this.DatumPhase.Name = "DatumPhase";
            this.DatumPhase.SchemaTypeName = null;
            this.DatumPhase.Size = new System.Drawing.Size(387, 27);
            this.DatumPhase.TabIndex = 1;
            this.DatumPhase.TargetNamespace = null;
            this.DatumPhase.UseFlowControl = null;
            // 
            // DatumFrequency
            // 
            this.DatumFrequency.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DatumFrequency.BackColor = System.Drawing.Color.White;
            this.DatumFrequency.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.DatumFrequency.Location = new System.Drawing.Point(14, 121);
            this.DatumFrequency.Name = "DatumFrequency";
            this.DatumFrequency.SchemaTypeName = null;
            this.DatumFrequency.Size = new System.Drawing.Size(387, 28);
            this.DatumFrequency.TabIndex = 2;
            this.DatumFrequency.TargetNamespace = null;
            this.DatumFrequency.UseFlowControl = null;
            this.DatumFrequency.Load += new System.EventHandler(this.DatumFrequency_Load);
            // 
            // helpLabel1
            // 
            this.helpLabel1.AutoSize = true;
            this.helpLabel1.HelpMessageKey = "PathSParam.PahseAngle";
            this.helpLabel1.Location = new System.Drawing.Point(11, 56);
            this.helpLabel1.Name = "helpLabel1";
            this.helpLabel1.RequiredField = false;
            this.helpLabel1.RequiredFieldMarkerFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.helpLabel1.Size = new System.Drawing.Size(67, 13);
            this.helpLabel1.TabIndex = 3;
            this.helpLabel1.Text = "Phase Angle";
            // 
            // helpLabel2
            // 
            this.helpLabel2.AutoSize = true;
            this.helpLabel2.HelpMessageKey = "PathSParam.frequency";
            this.helpLabel2.Location = new System.Drawing.Point(11, 105);
            this.helpLabel2.Name = "helpLabel2";
            this.helpLabel2.RequiredField = false;
            this.helpLabel2.RequiredFieldMarkerFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.helpLabel2.Size = new System.Drawing.Size(57, 13);
            this.helpLabel2.TabIndex = 4;
            this.helpLabel2.Text = "Frequency";
            // 
            // helpLabel3
            // 
            this.helpLabel3.AutoSize = true;
            this.helpLabel3.HelpMessageKey = "PathSParam.Magnitude";
            this.helpLabel3.Location = new System.Drawing.Point(11, 5);
            this.helpLabel3.Name = "helpLabel3";
            this.helpLabel3.RequiredField = false;
            this.helpLabel3.RequiredFieldMarkerFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.helpLabel3.Size = new System.Drawing.Size(57, 13);
            this.helpLabel3.TabIndex = 5;
            this.helpLabel3.Text = "Magnitude";
            // 
            // pathSParameterSParameterDataControl
            // 
            this.Controls.Add(this.helpLabel3);
            this.Controls.Add(this.helpLabel2);
            this.Controls.Add(this.helpLabel1);
            this.Controls.Add(this.DatumFrequency);
            this.Controls.Add(this.DatumPhase);
            this.Controls.Add(this.DatumMagnitude);
            this.Name = "pathSParameterSParameterDataControl";
            this.Size = new System.Drawing.Size(430, 168);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private datum.DatumTypeDoubleControl DatumMagnitude;
        private datum.DatumTypeDoubleControl DatumPhase;
        private datum.DatumTypeDoubleControl DatumFrequency;
        private HelpLabel helpLabel1;
        private HelpLabel helpLabel2;
        private HelpLabel helpLabel3;
    }
}
