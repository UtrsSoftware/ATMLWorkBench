/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
*
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/
namespace ATMLCommonLibrary.controls.path
{
    partial class PathVSWRValueControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PathVSWRValueControl));
            this.helpLabel1 = new ATMLCommonLibrary.controls.HelpLabel(this.components);
            this.edtInputPort = new ATMLCommonLibrary.controls.awb.AWBTextBox(this.components);
            this.helpLabel2 = new ATMLCommonLibrary.controls.HelpLabel(this.components);
            this.edtFrequency = new ATMLCommonLibrary.controls.awb.AWBTextBox(this.components);
            this.btnFrequencyLimit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(12, 8);
            // 
            // edtLimitName
            // 
            this.edtLimitName.Location = new System.Drawing.Point(79, 8);
            this.edtLimitName.Size = new System.Drawing.Size(506, 20);
            // 
            // edtLimitDescription
            // 
            this.edtLimitDescription.Location = new System.Drawing.Point(79, 34);
            this.edtLimitDescription.Size = new System.Drawing.Size(506, 82);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(12, 34);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(12, 166);
            // 
            // cmbOperator
            // 
            this.cmbOperator.Location = new System.Drawing.Point(79, 162);
            // 
            // cmbLimitType
            // 
            this.cmbLimitType.Location = new System.Drawing.Point(285, 162);
            this.cmbLimitType.Size = new System.Drawing.Size(151, 21);
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(224, 165);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Location = new System.Drawing.Point(15, 247);
            this.panel1.Size = new System.Drawing.Size(570, 197);
            this.panel1.TabIndex = 18;
            // 
            // edtQuickEntry
            // 
            this.edtQuickEntry.Location = new System.Drawing.Point(79, 122);
            this.edtQuickEntry.Size = new System.Drawing.Size(476, 31);
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(10, 125);
            // 
            // btnSubmit
            // 
            this.btnSubmit.Location = new System.Drawing.Point(560, 122);
            // 
            // helpLabel1
            // 
            this.helpLabel1.AutoSize = true;
            this.helpLabel1.HelpMessageKey = "PathSVWR.Frequency";
            this.helpLabel1.Location = new System.Drawing.Point(12, 197);
            this.helpLabel1.Name = "helpLabel1";
            this.helpLabel1.RequiredField = false;
            this.helpLabel1.RequiredFieldMarkerFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.helpLabel1.Size = new System.Drawing.Size(56, 13);
            this.helpLabel1.TabIndex = 11;
            this.helpLabel1.Text = "Input Port:";
            // 
            // edtInputPort
            // 
            this.edtInputPort.AttributeName = null;
            this.edtInputPort.Location = new System.Drawing.Point(77, 194);
            this.edtInputPort.Name = "edtInputPort";
            this.edtInputPort.Size = new System.Drawing.Size(482, 20);
            this.edtInputPort.TabIndex = 12;
            this.edtInputPort.Value = null;
            this.edtInputPort.ValueType = ATMLCommonLibrary.controls.awb.AWBTextBox.eValueType.xsString;
            // 
            // helpLabel2
            // 
            this.helpLabel2.AutoSize = true;
            this.helpLabel2.HelpMessageKey = null;
            this.helpLabel2.Location = new System.Drawing.Point(10, 219);
            this.helpLabel2.Name = "helpLabel2";
            this.helpLabel2.RequiredField = false;
            this.helpLabel2.RequiredFieldMarkerFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.helpLabel2.Size = new System.Drawing.Size(60, 13);
            this.helpLabel2.TabIndex = 15;
            this.helpLabel2.Text = "Frequency:";
            // 
            // edtFrequency
            // 
            this.edtFrequency.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtFrequency.AttributeName = null;
            this.edtFrequency.BackColor = System.Drawing.Color.Honeydew;
            this.edtFrequency.Location = new System.Drawing.Point(79, 221);
            this.edtFrequency.Name = "edtFrequency";
            this.edtFrequency.ReadOnly = true;
            this.edtFrequency.Size = new System.Drawing.Size(480, 20);
            this.edtFrequency.TabIndex = 16;
            this.edtFrequency.Value = null;
            this.edtFrequency.ValueType = ATMLCommonLibrary.controls.awb.AWBTextBox.eValueType.xsString;
            // 
            // btnFrequencyLimit
            // 
            this.btnFrequencyLimit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFrequencyLimit.FlatAppearance.BorderSize = 0;
            this.btnFrequencyLimit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFrequencyLimit.Image = ((System.Drawing.Image)(resources.GetObject("btnFrequencyLimit.Image")));
            this.btnFrequencyLimit.Location = new System.Drawing.Point(565, 221);
            this.btnFrequencyLimit.Name = "btnFrequencyLimit";
            this.btnFrequencyLimit.Size = new System.Drawing.Size(20, 19);
            this.btnFrequencyLimit.TabIndex = 17;
            this.btnFrequencyLimit.UseVisualStyleBackColor = true;
            this.btnFrequencyLimit.Click += new System.EventHandler(this.btnFrequencyLimit_Click);
            // 
            // PathVSWRValueControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.Controls.Add(this.btnFrequencyLimit);
            this.Controls.Add(this.edtFrequency);
            this.Controls.Add(this.helpLabel2);
            this.Controls.Add(this.edtInputPort);
            this.Controls.Add(this.helpLabel1);
            this.Name = "PathVSWRValueControl";
            this.Size = new System.Drawing.Size(603, 466);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.edtLimitName, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.edtLimitDescription, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.cmbOperator, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.cmbLimitType, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.edtQuickEntry, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.btnSubmit, 0);
            this.Controls.SetChildIndex(this.helpLabel1, 0);
            this.Controls.SetChildIndex(this.edtInputPort, 0);
            this.Controls.SetChildIndex(this.helpLabel2, 0);
            this.Controls.SetChildIndex(this.edtFrequency, 0);
            this.Controls.SetChildIndex(this.btnFrequencyLimit, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private HelpLabel helpLabel1;
        private awb.AWBTextBox edtInputPort;
        private HelpLabel helpLabel2;
        private awb.AWBTextBox edtFrequency;
        private System.Windows.Forms.Button btnFrequencyLimit;
    }
}
