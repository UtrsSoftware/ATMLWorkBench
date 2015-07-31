/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
*
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

namespace ATMLCommonLibrary.controls.network
{
    partial class MappingControl
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
            this.edtBaseIndex = new System.Windows.Forms.TextBox();
            this.label7 = new ATMLCommonLibrary.controls.HelpLabel(this.components);
            this.edtCount = new System.Windows.Forms.TextBox();
            this.label6 = new ATMLCommonLibrary.controls.HelpLabel(this.components);
            this.edtReplacementChar = new System.Windows.Forms.TextBox();
            this.label5 = new ATMLCommonLibrary.controls.HelpLabel(this.components);
            this.edtIncrementBy = new System.Windows.Forms.TextBox();
            this.label4 = new ATMLCommonLibrary.controls.HelpLabel(this.components);
            this.edtIndex = new System.Windows.Forms.TextBox();
            this.label3 = new ATMLCommonLibrary.controls.HelpLabel(this.components);
            this.networkListControl = new NetworkListControl();
            this.label1 = new ATMLCommonLibrary.controls.HelpLabel(this.components);
            this.SuspendLayout();
            // 
            // edtBaseIndex
            // 
            this.edtBaseIndex.Location = new System.Drawing.Point(523, 17);
            this.edtBaseIndex.Name = "edtBaseIndex";
            this.edtBaseIndex.Size = new System.Drawing.Size(48, 20);
            this.edtBaseIndex.TabIndex = 23;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.HelpMessageKey = "MappingControl.BaseIndex";
            this.label7.Location = new System.Drawing.Point(455, 19);
            this.label7.Name = "label7";
            this.label7.RequiredField = false;
            this.label7.RequiredFieldMarkerFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Size = new System.Drawing.Size(60, 13);
            this.label7.TabIndex = 22;
            this.label7.Text = "Base Index";
            // 
            // edtCount
            // 
            this.edtCount.Location = new System.Drawing.Point(145, 17);
            this.edtCount.Name = "edtCount";
            this.edtCount.Size = new System.Drawing.Size(48, 20);
            this.edtCount.TabIndex = 17;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.HelpMessageKey = "MappingControl.Count";
            this.label6.Location = new System.Drawing.Point(107, 19);
            this.label6.Name = "label6";
            this.label6.RequiredField = false;
            this.label6.RequiredFieldMarkerFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Size = new System.Drawing.Size(35, 13);
            this.label6.TabIndex = 16;
            this.label6.Text = "Count";
            // 
            // edtReplacementChar
            // 
            this.edtReplacementChar.Location = new System.Drawing.Point(393, 17);
            this.edtReplacementChar.Name = "edtReplacementChar";
            this.edtReplacementChar.Size = new System.Drawing.Size(48, 20);
            this.edtReplacementChar.TabIndex = 21;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.HelpMessageKey = "MappingControl.ReplChar";
            this.label5.Location = new System.Drawing.Point(330, 19);
            this.label5.Name = "label5";
            this.label5.RequiredField = false;
            this.label5.RequiredFieldMarkerFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Size = new System.Drawing.Size(60, 13);
            this.label5.TabIndex = 20;
            this.label5.Text = "Repl. Char.";
            // 
            // edtIncrementBy
            // 
            this.edtIncrementBy.Location = new System.Drawing.Point(272, 17);
            this.edtIncrementBy.Name = "edtIncrementBy";
            this.edtIncrementBy.Size = new System.Drawing.Size(48, 20);
            this.edtIncrementBy.TabIndex = 19;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.HelpMessageKey = "MappingControl.IncrementBy";
            this.label4.Location = new System.Drawing.Point(201, 19);
            this.label4.Name = "label4";
            this.label4.RequiredField = false;
            this.label4.RequiredFieldMarkerFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Size = new System.Drawing.Size(69, 13);
            this.label4.TabIndex = 18;
            this.label4.Text = "Increment By";
            // 
            // edtIndex
            // 
            this.edtIndex.Location = new System.Drawing.Point(54, 17);
            this.edtIndex.Name = "edtIndex";
            this.edtIndex.Size = new System.Drawing.Size(48, 20);
            this.edtIndex.TabIndex = 15;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.HelpMessageKey = "MappingControl.Index";
            this.label3.Location = new System.Drawing.Point(13, 19);
            this.label3.Name = "label3";
            this.label3.RequiredField = false;
            this.label3.RequiredFieldMarkerFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Size = new System.Drawing.Size(33, 13);
            this.label3.TabIndex = 14;
            this.label3.Text = "Index";
            // 
            // networkListControl
            // 
            this.networkListControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.networkListControl.ListName = null;
            this.networkListControl.Location = new System.Drawing.Point(13, 66);
            this.networkListControl.Margin = new System.Windows.Forms.Padding(0);
            this.networkListControl.Name = "networkListControl";
            this.networkListControl.SchemaTypeName = null;
            this.networkListControl.Size = new System.Drawing.Size(558, 167);
            this.networkListControl.TabIndex = 24;
            this.networkListControl.TargetNamespace = null;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.HelpMessageKey = null;
            this.label1.Location = new System.Drawing.Point(10, 47);
            this.label1.Name = "label1";
            this.label1.RequiredField = false;
            this.label1.RequiredFieldMarkerFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Size = new System.Drawing.Size(33, 13);
            this.label1.TabIndex = 25;
            this.label1.Text = "Maps";
            // 
            // MappingControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.networkListControl);
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
            this.MinimumSize = new System.Drawing.Size(587, 247);
            this.Name = "MappingControl";
            this.Size = new System.Drawing.Size(587, 247);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox edtBaseIndex;
        private ATMLCommonLibrary.controls.HelpLabel	 label7;
        private System.Windows.Forms.TextBox edtCount;
        private ATMLCommonLibrary.controls.HelpLabel	 label6;
        private System.Windows.Forms.TextBox edtReplacementChar;
        private ATMLCommonLibrary.controls.HelpLabel	 label5;
        private System.Windows.Forms.TextBox edtIncrementBy;
        private ATMLCommonLibrary.controls.HelpLabel	 label4;
        private System.Windows.Forms.TextBox edtIndex;
        private ATMLCommonLibrary.controls.HelpLabel	 label3;
        private NetworkListControl networkListControl;
        private ATMLCommonLibrary.controls.HelpLabel	 label1;
    }
}
