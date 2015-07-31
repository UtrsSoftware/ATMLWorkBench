/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
*
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/
namespace ATMLCommonLibrary.controls
{
    partial class RepeatedItemControl
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
            this.edtBaseIndex = new ATMLCommonLibrary.controls.awb.AWBTextBox(this.components);
            this.label7 = new ATMLCommonLibrary.controls.HelpLabel(this.components);
            this.edtCount = new ATMLCommonLibrary.controls.awb.AWBTextBox(this.components);
            this.label6 = new ATMLCommonLibrary.controls.HelpLabel(this.components);
            this.edtReplacementChar = new ATMLCommonLibrary.controls.awb.AWBTextBox(this.components);
            this.label5 = new ATMLCommonLibrary.controls.HelpLabel(this.components);
            this.edtIncrementBy = new ATMLCommonLibrary.controls.awb.AWBTextBox(this.components);
            this.label4 = new ATMLCommonLibrary.controls.HelpLabel(this.components);
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // edtDescription
            // 
            this.edtDescription.Location = new System.Drawing.Point(71, 37);
            // 
            // edtName
            // 
            this.edtName.Location = new System.Drawing.Point(71, 11);
            // 
            // lblName
            // 
            this.lblName.Location = new System.Drawing.Point(28, 14);
            // 
            // lblDescription
            // 
            this.lblDescription.Location = new System.Drawing.Point(3, 40);
            // 
            // edtBaseIndex
            // 
            this.edtBaseIndex.AttributeName = null;
            this.edtBaseIndex.Location = new System.Drawing.Point(72, 140);
            this.edtBaseIndex.Name = "edtBaseIndex";
            this.edtBaseIndex.Size = new System.Drawing.Size(42, 20);
            this.edtBaseIndex.TabIndex = 5;
            this.edtBaseIndex.Tag = "";
            this.edtBaseIndex.Value = 0;
            this.edtBaseIndex.ValueType = ATMLCommonLibrary.controls.awb.AWBTextBox.eValueType.xsInteger;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.HelpMessageKey = "RepeatedItem.BaseIndex";
            this.label7.Location = new System.Drawing.Point(9, 142);
            this.label7.Name = "label7";
            this.label7.RequiredField = false;
            this.label7.RequiredFieldMarkerFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Size = new System.Drawing.Size(60, 13);
            this.label7.TabIndex = 4;
            this.label7.Text = "Base Index";
            // 
            // edtCount
            // 
            this.edtCount.AttributeName = null;
            this.edtCount.Location = new System.Drawing.Point(171, 141);
            this.edtCount.Name = "edtCount";
            this.edtCount.Size = new System.Drawing.Size(43, 20);
            this.edtCount.TabIndex = 7;
            this.edtCount.Tag = "";
            this.edtCount.Value = 0;
            this.edtCount.ValueType = ATMLCommonLibrary.controls.awb.AWBTextBox.eValueType.xsInteger;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.HelpMessageKey = "RepeatedItem.Count";
            this.label6.Location = new System.Drawing.Point(133, 143);
            this.label6.Name = "label6";
            this.label6.RequiredField = false;
            this.label6.RequiredFieldMarkerFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Size = new System.Drawing.Size(35, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "Count";
            // 
            // edtReplacementChar
            // 
            this.edtReplacementChar.AttributeName = null;
            this.edtReplacementChar.Location = new System.Drawing.Point(429, 141);
            this.edtReplacementChar.Name = "edtReplacementChar";
            this.edtReplacementChar.Size = new System.Drawing.Size(48, 20);
            this.edtReplacementChar.TabIndex = 11;
            this.edtReplacementChar.Tag = "";
            this.edtReplacementChar.Value = null;
            this.edtReplacementChar.ValueType = ATMLCommonLibrary.controls.awb.AWBTextBox.eValueType.xsString;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.HelpMessageKey = "RepeatedItem.ReplChar";
            this.label5.Location = new System.Drawing.Point(366, 143);
            this.label5.Name = "label5";
            this.label5.RequiredField = false;
            this.label5.RequiredFieldMarkerFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Size = new System.Drawing.Size(60, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Repl. Char.";
            // 
            // edtIncrementBy
            // 
            this.edtIncrementBy.AttributeName = null;
            this.edtIncrementBy.Location = new System.Drawing.Point(304, 142);
            this.edtIncrementBy.Name = "edtIncrementBy";
            this.edtIncrementBy.Size = new System.Drawing.Size(43, 20);
            this.edtIncrementBy.TabIndex = 9;
            this.edtIncrementBy.Tag = "";
            this.edtIncrementBy.Value = 0;
            this.edtIncrementBy.ValueType = ATMLCommonLibrary.controls.awb.AWBTextBox.eValueType.xsInteger;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.HelpMessageKey = "RepeatedItem.IncrementBy";
            this.label4.Location = new System.Drawing.Point(233, 144);
            this.label4.Name = "label4";
            this.label4.RequiredField = false;
            this.label4.RequiredFieldMarkerFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Size = new System.Drawing.Size(69, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Increment By";
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // RepeatedItemControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.edtBaseIndex);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.edtCount);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.edtReplacementChar);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.edtIncrementBy);
            this.Controls.Add(this.label4);
            this.MinimumSize = new System.Drawing.Size(507, 167);
            this.Name = "RepeatedItemControl";
            this.Size = new System.Drawing.Size(507, 173);
            this.Validating += new System.ComponentModel.CancelEventHandler(this.RepeatedItemControl_Validating);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.edtIncrementBy, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.edtReplacementChar, 0);
            this.Controls.SetChildIndex(this.label6, 0);
            this.Controls.SetChildIndex(this.edtCount, 0);
            this.Controls.SetChildIndex(this.label7, 0);
            this.Controls.SetChildIndex(this.edtBaseIndex, 0);
            this.Controls.SetChildIndex(this.edtName, 0);
            this.Controls.SetChildIndex(this.edtDescription, 0);
            this.Controls.SetChildIndex(this.lblName, 0);
            this.Controls.SetChildIndex(this.lblDescription, 0);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected awb.AWBTextBox edtBaseIndex;
        protected HelpLabel label7;
        protected awb.AWBTextBox edtCount;
        protected HelpLabel label6;
        protected awb.AWBTextBox edtReplacementChar;
        protected HelpLabel label5;
        protected awb.AWBTextBox edtIncrementBy;
        protected HelpLabel label4;
    }
}
