/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
*
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/
namespace ATMLCommonLibrary.controls.path
{
    partial class PathSignalDelayControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PathSignalDelayControl));
            this.helpLabel1 = new ATMLCommonLibrary.controls.HelpLabel(this.components);
            this.helpLabel2 = new ATMLCommonLibrary.controls.HelpLabel(this.components);
            this.helpLabel3 = new ATMLCommonLibrary.controls.HelpLabel(this.components);
            this.edtInputPort = new ATMLCommonLibrary.controls.awb.AWBTextBox(this.components);
            this.edtOutputPort = new ATMLCommonLibrary.controls.awb.AWBTextBox(this.components);
            this.edtFrequency = new ATMLCommonLibrary.controls.awb.AWBTextBox(this.components);
            this.btnFrequencyLimit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // edtLimitName
            // 
            this.edtLimitName.Size = new System.Drawing.Size(388, 20);
            // 
            // edtLimitDescription
            // 
            this.edtLimitDescription.Size = new System.Drawing.Size(388, 82);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(14, 132);
            // 
            // cmbOperator
            // 
            this.cmbOperator.Location = new System.Drawing.Point(81, 128);
            // 
            // cmbLimitType
            // 
            this.cmbLimitType.Location = new System.Drawing.Point(287, 128);
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(226, 131);
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(17, 250);
            this.panel1.Size = new System.Drawing.Size(452, 139);
            // 
            // edtQuickEntry
            // 
            this.edtQuickEntry.Size = new System.Drawing.Size(353, 31);
            this.edtQuickEntry.Visible = false;
            // 
            // label5
            // 
            this.label5.Visible = false;
            // 
            // btnSubmit
            // 
            this.btnSubmit.FlatAppearance.BorderSize = 0;
            this.btnSubmit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSubmit.Image = ((System.Drawing.Image)(resources.GetObject("btnSubmit.Image")));
            this.btnSubmit.Location = new System.Drawing.Point(439, 127);
            this.btnSubmit.Size = new System.Drawing.Size(33, 34);
            this.btnSubmit.Visible = false;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // helpLabel1
            // 
            this.helpLabel1.AutoSize = true;
            this.helpLabel1.HelpMessageKey = null;
            this.helpLabel1.Location = new System.Drawing.Point(14, 219);
            this.helpLabel1.Name = "helpLabel1";
            this.helpLabel1.RequiredField = false;
            this.helpLabel1.RequiredFieldMarkerFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.helpLabel1.Size = new System.Drawing.Size(57, 13);
            this.helpLabel1.TabIndex = 2;
            this.helpLabel1.Text = "Frequency";
            // 
            // helpLabel2
            // 
            this.helpLabel2.AutoSize = true;
            this.helpLabel2.HelpMessageKey = null;
            this.helpLabel2.Location = new System.Drawing.Point(14, 166);
            this.helpLabel2.Name = "helpLabel2";
            this.helpLabel2.RequiredField = false;
            this.helpLabel2.RequiredFieldMarkerFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.helpLabel2.Size = new System.Drawing.Size(56, 13);
            this.helpLabel2.TabIndex = 3;
            this.helpLabel2.Text = "Inport Port";
            // 
            // helpLabel3
            // 
            this.helpLabel3.AutoSize = true;
            this.helpLabel3.HelpMessageKey = null;
            this.helpLabel3.Location = new System.Drawing.Point(14, 192);
            this.helpLabel3.Name = "helpLabel3";
            this.helpLabel3.RequiredField = false;
            this.helpLabel3.RequiredFieldMarkerFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.helpLabel3.Size = new System.Drawing.Size(61, 13);
            this.helpLabel3.TabIndex = 4;
            this.helpLabel3.Text = "Output Port";
            // 
            // edtInputPort
            // 
            this.edtInputPort.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtInputPort.AttributeName = null;
            this.edtInputPort.Location = new System.Drawing.Point(81, 164);
            this.edtInputPort.Name = "edtInputPort";
            this.edtInputPort.Size = new System.Drawing.Size(388, 20);
            this.edtInputPort.TabIndex = 5;
            this.edtInputPort.Value = null;
            this.edtInputPort.ValueType = ATMLCommonLibrary.controls.awb.AWBTextBox.eValueType.xsString;
            // 
            // edtOutputPort
            // 
            this.edtOutputPort.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtOutputPort.AttributeName = null;
            this.edtOutputPort.Location = new System.Drawing.Point(81, 190);
            this.edtOutputPort.Name = "edtOutputPort";
            this.edtOutputPort.Size = new System.Drawing.Size(388, 20);
            this.edtOutputPort.TabIndex = 6;
            this.edtOutputPort.Value = null;
            this.edtOutputPort.ValueType = ATMLCommonLibrary.controls.awb.AWBTextBox.eValueType.xsString;
            // 
            // edtFrequency
            // 
            this.edtFrequency.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtFrequency.AttributeName = null;
            this.edtFrequency.BackColor = System.Drawing.Color.Honeydew;
            this.edtFrequency.Location = new System.Drawing.Point(81, 217);
            this.edtFrequency.Name = "edtFrequency";
            this.edtFrequency.ReadOnly = true;
            this.edtFrequency.Size = new System.Drawing.Size(353, 20);
            this.edtFrequency.TabIndex = 12;
            this.edtFrequency.Value = null;
            this.edtFrequency.ValueType = ATMLCommonLibrary.controls.awb.AWBTextBox.eValueType.xsString;
            // 
            // btnFrequencyLimit
            // 
            this.btnFrequencyLimit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFrequencyLimit.FlatAppearance.BorderSize = 0;
            this.btnFrequencyLimit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFrequencyLimit.Image = ((System.Drawing.Image)(resources.GetObject("btnFrequencyLimit.Image")));
            this.btnFrequencyLimit.Location = new System.Drawing.Point(437, 213);
            this.btnFrequencyLimit.Name = "btnFrequencyLimit";
            this.btnFrequencyLimit.Size = new System.Drawing.Size(34, 31);
            this.btnFrequencyLimit.TabIndex = 13;
            this.btnFrequencyLimit.UseVisualStyleBackColor = true;
            this.btnFrequencyLimit.Click += new System.EventHandler(this.btnFrequencyLimit_Click);
            // 
            // PathSignalDelayControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.Controls.Add(this.btnFrequencyLimit);
            this.Controls.Add(this.edtFrequency);
            this.Controls.Add(this.edtOutputPort);
            this.Controls.Add(this.edtInputPort);
            this.Controls.Add(this.helpLabel3);
            this.Controls.Add(this.helpLabel2);
            this.Controls.Add(this.helpLabel1);
            this.Name = "PathSignalDelayControl";
            this.Size = new System.Drawing.Size(485, 404);
            this.Controls.SetChildIndex(this.helpLabel1, 0);
            this.Controls.SetChildIndex(this.helpLabel2, 0);
            this.Controls.SetChildIndex(this.helpLabel3, 0);
            this.Controls.SetChildIndex(this.edtInputPort, 0);
            this.Controls.SetChildIndex(this.edtOutputPort, 0);
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
            this.Controls.SetChildIndex(this.edtFrequency, 0);
            this.Controls.SetChildIndex(this.btnFrequencyLimit, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private HelpLabel helpLabel1;
        private HelpLabel helpLabel2;
        private HelpLabel helpLabel3;
        private awb.AWBTextBox edtInputPort;
        private awb.AWBTextBox edtOutputPort;
        private awb.AWBTextBox edtFrequency;
        private System.Windows.Forms.Button btnFrequencyLimit;
    }
}
