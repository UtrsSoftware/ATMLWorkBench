/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
*
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

namespace ATMLCommonLibrary.controls.network
{
    partial class NetworkControl
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
            this.edtIndex = new ATMLCommonLibrary.controls.awb.AWBTextBox(this.components);
            this.label3 = new ATMLCommonLibrary.controls.HelpLabel(this.components);
            this.edtDescription = new ATMLCommonLibrary.controls.awb.AWBTextBox(this.components);
            this.label2 = new ATMLCommonLibrary.controls.HelpLabel(this.components);
            this.label1 = new ATMLCommonLibrary.controls.HelpLabel(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.networkNodeListControl = new NetworkNodeListControl();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // edtBaseIndex
            // 
            this.edtBaseIndex.AttributeName = null;
            this.edtBaseIndex.Location = new System.Drawing.Point(538, 106);
            this.edtBaseIndex.Name = "edtBaseIndex";
            this.edtBaseIndex.Size = new System.Drawing.Size(48, 20);
            this.edtBaseIndex.TabIndex = 25;
            this.edtBaseIndex.Value = null;
            this.edtBaseIndex.ValueType = ATMLCommonLibrary.controls.awb.AWBTextBox.eValueType.xsString;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.HelpMessageKey = "NetworkControl.BaseIndex";
            this.label7.Location = new System.Drawing.Point(475, 108);
            this.label7.Name = "label7";
            this.label7.RequiredField = false;
            this.label7.RequiredFieldMarkerFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Size = new System.Drawing.Size(60, 13);
            this.label7.TabIndex = 24;
            this.label7.Text = "Base Index";
            // 
            // edtCount
            // 
            this.edtCount.AttributeName = null;
            this.edtCount.Location = new System.Drawing.Point(173, 106);
            this.edtCount.Name = "edtCount";
            this.edtCount.Size = new System.Drawing.Size(48, 20);
            this.edtCount.TabIndex = 19;
            this.edtCount.Value = null;
            this.edtCount.ValueType = ATMLCommonLibrary.controls.awb.AWBTextBox.eValueType.xsString;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.HelpMessageKey = "NetworkControl.Count";
            this.label6.Location = new System.Drawing.Point(135, 108);
            this.label6.Name = "label6";
            this.label6.RequiredField = false;
            this.label6.RequiredFieldMarkerFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Size = new System.Drawing.Size(35, 13);
            this.label6.TabIndex = 18;
            this.label6.Text = "Count";
            // 
            // edtReplacementChar
            // 
            this.edtReplacementChar.AttributeName = null;
            this.edtReplacementChar.Location = new System.Drawing.Point(420, 106);
            this.edtReplacementChar.Name = "edtReplacementChar";
            this.edtReplacementChar.Size = new System.Drawing.Size(48, 20);
            this.edtReplacementChar.TabIndex = 23;
            this.edtReplacementChar.Value = null;
            this.edtReplacementChar.ValueType = ATMLCommonLibrary.controls.awb.AWBTextBox.eValueType.xsString;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.HelpMessageKey = "NetworkControl.ReplChar";
            this.label5.Location = new System.Drawing.Point(357, 108);
            this.label5.Name = "label5";
            this.label5.RequiredField = false;
            this.label5.RequiredFieldMarkerFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Size = new System.Drawing.Size(60, 13);
            this.label5.TabIndex = 22;
            this.label5.Text = "Repl. Char.";
            // 
            // edtIncrementBy
            // 
            this.edtIncrementBy.AttributeName = null;
            this.edtIncrementBy.Location = new System.Drawing.Point(299, 106);
            this.edtIncrementBy.Name = "edtIncrementBy";
            this.edtIncrementBy.Size = new System.Drawing.Size(48, 20);
            this.edtIncrementBy.TabIndex = 21;
            this.edtIncrementBy.Value = null;
            this.edtIncrementBy.ValueType = ATMLCommonLibrary.controls.awb.AWBTextBox.eValueType.xsString;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.HelpMessageKey = "NetworkControl.IncrementBy";
            this.label4.Location = new System.Drawing.Point(228, 108);
            this.label4.Name = "label4";
            this.label4.RequiredField = false;
            this.label4.RequiredFieldMarkerFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Size = new System.Drawing.Size(69, 13);
            this.label4.TabIndex = 20;
            this.label4.Text = "Increment By";
            // 
            // edtIndex
            // 
            this.edtIndex.AttributeName = null;
            this.edtIndex.Location = new System.Drawing.Point(81, 106);
            this.edtIndex.Name = "edtIndex";
            this.edtIndex.Size = new System.Drawing.Size(48, 20);
            this.edtIndex.TabIndex = 17;
            this.edtIndex.Value = null;
            this.edtIndex.ValueType = ATMLCommonLibrary.controls.awb.AWBTextBox.eValueType.xsString;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.HelpMessageKey = "NetworkControl.Index";
            this.label3.Location = new System.Drawing.Point(37, 108);
            this.label3.Name = "label3";
            this.label3.RequiredField = false;
            this.label3.RequiredFieldMarkerFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Size = new System.Drawing.Size(33, 13);
            this.label3.TabIndex = 16;
            this.label3.Text = "Index";
            // 
            // edtDescription
            // 
            this.edtDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtDescription.AttributeName = null;
            this.edtDescription.Location = new System.Drawing.Point(81, 15);
            this.edtDescription.Multiline = true;
            this.edtDescription.Name = "edtDescription";
            this.edtDescription.Size = new System.Drawing.Size(505, 85);
            this.edtDescription.TabIndex = 15;
            this.edtDescription.Value = null;
            this.edtDescription.ValueType = ATMLCommonLibrary.controls.awb.AWBTextBox.eValueType.xsString;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.HelpMessageKey = "NetworkControl.Description";
            this.label2.Location = new System.Drawing.Point(10, 17);
            this.label2.Name = "label2";
            this.label2.RequiredField = false;
            this.label2.RequiredFieldMarkerFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "Description";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.HelpMessageKey = "NetworkControl.Nodes";
            this.label1.Location = new System.Drawing.Point(10, 145);
            this.label1.Name = "label1";
            this.label1.RequiredField = false;
            this.label1.RequiredFieldMarkerFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 27;
            this.label1.Text = "Nodes";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(12, 136);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(574, 1);
            this.pictureBox1.TabIndex = 28;
            this.pictureBox1.TabStop = false;
            // 
            // networkNodeListControl
            // 
            this.networkNodeListControl.ListName = null;
            this.networkNodeListControl.Location = new System.Drawing.Point(13, 161);
            this.networkNodeListControl.Margin = new System.Windows.Forms.Padding(0);
            this.networkNodeListControl.Name = "networkNodeListControl";
            this.networkNodeListControl.SchemaTypeName = null;
            this.networkNodeListControl.ShowFind = false;
            this.networkNodeListControl.Size = new System.Drawing.Size(573, 203);
            this.networkNodeListControl.TabIndex = 29;
            this.networkNodeListControl.TargetNamespace = null;
            // 
            // NetworkControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.networkNodeListControl);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.edtBaseIndex);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.edtCount);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.edtReplacementChar);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.edtIncrementBy);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.edtIndex);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.edtDescription);
            this.Controls.Add(this.label2);
            this.MinimumSize = new System.Drawing.Size(599, 370);
            this.Name = "NetworkControl";
            this.Size = new System.Drawing.Size(599, 370);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ATMLCommonLibrary.controls.awb.AWBTextBox edtBaseIndex;
        private ATMLCommonLibrary.controls.HelpLabel label7;
        private ATMLCommonLibrary.controls.awb.AWBTextBox edtCount;
        private ATMLCommonLibrary.controls.HelpLabel label6;
        private ATMLCommonLibrary.controls.awb.AWBTextBox edtReplacementChar;
        private ATMLCommonLibrary.controls.HelpLabel label5;
        private ATMLCommonLibrary.controls.awb.AWBTextBox edtIncrementBy;
        private ATMLCommonLibrary.controls.HelpLabel label4;
        private ATMLCommonLibrary.controls.awb.AWBTextBox edtIndex;
        private ATMLCommonLibrary.controls.HelpLabel label3;
        private ATMLCommonLibrary.controls.awb.AWBTextBox edtDescription;
        private ATMLCommonLibrary.controls.HelpLabel label2;
        private ATMLCommonLibrary.controls.HelpLabel label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private NetworkNodeListControl networkNodeListControl;
    }
}
