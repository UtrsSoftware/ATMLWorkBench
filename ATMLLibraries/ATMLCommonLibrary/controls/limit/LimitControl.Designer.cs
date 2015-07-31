/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
*
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/
namespace ATMLCommonLibrary.controls.limit
{
    partial class LimitControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.label5 = new ATMLCommonLibrary.controls.HelpLabel(this.components);
            this.edtQuickEntry = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cmbLimitType = new System.Windows.Forms.ComboBox();
            this.label4 = new ATMLCommonLibrary.controls.HelpLabel(this.components);
            this.cmbOperator = new System.Windows.Forms.ComboBox();
            this.label3 = new ATMLCommonLibrary.controls.HelpLabel(this.components);
            this.edtLimitDescription = new ATMLCommonLibrary.controls.awb.AWBTextBox(this.components);
            this.label2 = new ATMLCommonLibrary.controls.HelpLabel(this.components);
            this.edtLimitName = new ATMLCommonLibrary.controls.awb.AWBTextBox(this.components);
            this.label1 = new ATMLCommonLibrary.controls.HelpLabel(this.components);
            this.SuspendLayout();
            // 
            // btnSubmit
            // 
            this.btnSubmit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSubmit.Location = new System.Drawing.Point(525, 10);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(25, 23);
            this.btnSubmit.TabIndex = 2;
            this.btnSubmit.Text = "...";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.HelpMessageKey = "LimitControl.QuickEntry";
            this.label5.Location = new System.Drawing.Point(12, 10);
            this.label5.Name = "label5";
            this.label5.RequiredField = false;
            this.label5.RequiredFieldMarkerFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Size = new System.Drawing.Size(62, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Quick Entry";
            // 
            // edtQuickEntry
            // 
            this.edtQuickEntry.AcceptsReturn = true;
            this.edtQuickEntry.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtQuickEntry.Location = new System.Drawing.Point(81, 10);
            this.edtQuickEntry.Multiline = true;
            this.edtQuickEntry.Name = "edtQuickEntry";
            this.edtQuickEntry.Size = new System.Drawing.Size(439, 31);
            this.edtQuickEntry.TabIndex = 1;
            this.edtQuickEntry.KeyDown += new System.Windows.Forms.KeyEventHandler(this.edtQuickEntry_KeyDown);
            this.edtQuickEntry.KeyUp += new System.Windows.Forms.KeyEventHandler(this.edtQuickEntry_KeyUp);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.AutoScroll = true;
            this.panel1.AutoSize = true;
            this.panel1.Location = new System.Drawing.Point(17, 200);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(533, 216);
            this.panel1.TabIndex = 11;
            // 
            // cmbLimitType
            // 
            this.cmbLimitType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLimitType.FormattingEnabled = true;
            this.cmbLimitType.Items.AddRange(new object[] {
            "Limit Expected",
            "Limit Mask",
            "Limit Pair",
            "Single Limit"});
            this.cmbLimitType.Location = new System.Drawing.Point(287, 167);
            this.cmbLimitType.Name = "cmbLimitType";
            this.cmbLimitType.Size = new System.Drawing.Size(139, 21);
            this.cmbLimitType.TabIndex = 10;
            this.cmbLimitType.SelectedIndexChanged += new System.EventHandler(this.cmbLimitType_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.HelpMessageKey = "LimitControl.LimitType";
            this.label4.Location = new System.Drawing.Point(226, 170);
            this.label4.Name = "label4";
            this.label4.RequiredField = false;
            this.label4.RequiredFieldMarkerFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Size = new System.Drawing.Size(55, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Limit Type";
            // 
            // cmbOperator
            // 
            this.cmbOperator.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbOperator.FormattingEnabled = true;
            this.cmbOperator.Items.AddRange(new object[] {
            "AND",
            "OR"});
            this.cmbOperator.Location = new System.Drawing.Point(81, 167);
            this.cmbOperator.Name = "cmbOperator";
            this.cmbOperator.Size = new System.Drawing.Size(118, 21);
            this.cmbOperator.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.HelpMessageKey = "LimitControl.Operator";
            this.label3.Location = new System.Drawing.Point(14, 171);
            this.label3.Name = "label3";
            this.label3.RequiredField = false;
            this.label3.RequiredFieldMarkerFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Size = new System.Drawing.Size(48, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Operator";
            // 
            // edtLimitDescription
            // 
            this.edtLimitDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtLimitDescription.AttributeName = null;
            this.edtLimitDescription.Location = new System.Drawing.Point(81, 73);
            this.edtLimitDescription.Multiline = true;
            this.edtLimitDescription.Name = "edtLimitDescription";
            this.edtLimitDescription.Size = new System.Drawing.Size(469, 82);
            this.edtLimitDescription.TabIndex = 6;
            this.edtLimitDescription.Value = null;
            this.edtLimitDescription.ValueType = ATMLCommonLibrary.controls.awb.AWBTextBox.eValueType.xsString;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.HelpMessageKey = "LimitControl.Description";
            this.label2.Location = new System.Drawing.Point(14, 73);
            this.label2.Name = "label2";
            this.label2.RequiredField = false;
            this.label2.RequiredFieldMarkerFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Description";
            // 
            // edtLimitName
            // 
            this.edtLimitName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtLimitName.AttributeName = null;
            this.edtLimitName.Location = new System.Drawing.Point(81, 47);
            this.edtLimitName.Name = "edtLimitName";
            this.edtLimitName.Size = new System.Drawing.Size(469, 20);
            this.edtLimitName.TabIndex = 4;
            this.edtLimitName.Value = null;
            this.edtLimitName.ValueType = ATMLCommonLibrary.controls.awb.AWBTextBox.eValueType.xsString;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.HelpMessageKey = "LimitControl.Name";
            this.label1.Location = new System.Drawing.Point(14, 47);
            this.label1.Name = "label1";
            this.label1.RequiredField = false;
            this.label1.RequiredFieldMarkerFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Name";
            // 
            // LimitControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.edtQuickEntry);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.cmbLimitType);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cmbOperator);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.edtLimitDescription);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.edtLimitName);
            this.Controls.Add(this.label1);
            this.Name = "LimitControl";
            this.Size = new System.Drawing.Size(569, 434);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected ATMLCommonLibrary.controls.HelpLabel label1;
        protected awb.AWBTextBox edtLimitName;
        protected awb.AWBTextBox edtLimitDescription;
        protected ATMLCommonLibrary.controls.HelpLabel label2;
        protected ATMLCommonLibrary.controls.HelpLabel label3;
        protected System.Windows.Forms.ComboBox cmbOperator;
        protected System.Windows.Forms.ComboBox cmbLimitType;
        protected ATMLCommonLibrary.controls.HelpLabel label4;
        protected System.Windows.Forms.Panel panel1;
        protected System.Windows.Forms.TextBox edtQuickEntry;
        protected ATMLCommonLibrary.controls.HelpLabel label5;
        protected System.Windows.Forms.Button btnSubmit;
    }
}
