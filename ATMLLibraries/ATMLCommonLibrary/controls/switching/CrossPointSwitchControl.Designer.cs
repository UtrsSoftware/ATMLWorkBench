/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
*
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/
namespace ATMLCommonLibrary.controls.switching
{
    partial class CrossPointSwitchControl
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
            this.lblPin = new ATMLCommonLibrary.controls.HelpLabel(this.components);
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.lvColumns = new ATMLCommonLibrary.controls.lists.ATMLListControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.lvRows = new ATMLCommonLibrary.controls.lists.ATMLListControl();
            this.helpLabel1 = new ATMLCommonLibrary.controls.HelpLabel(this.components);
            this.edtLineCount = new ATMLCommonLibrary.controls.awb.AWBTextBox(this.components);
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblPin
            // 
            this.lblPin.AutoSize = true;
            this.lblPin.HelpMessageKey = "CrossPointSwitchControl.Ports";
            this.lblPin.Location = new System.Drawing.Point(30, 160);
            this.lblPin.Name = "lblPin";
            this.lblPin.RequiredField = false;
            this.lblPin.RequiredFieldMarkerFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPin.Size = new System.Drawing.Size(31, 13);
            this.lblPin.TabIndex = 6;
            this.lblPin.Text = "Ports";
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(71, 154);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(404, 152);
            this.tabControl1.TabIndex = 7;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.lvColumns);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(396, 126);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Columns";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // lvColumns
            // 
            this.lvColumns.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvColumns.ListName = null;
            this.lvColumns.Location = new System.Drawing.Point(3, 3);
            this.lvColumns.Margin = new System.Windows.Forms.Padding(0);
            this.lvColumns.Name = "lvColumns";
            this.lvColumns.SchemaTypeName = null;
            this.lvColumns.Size = new System.Drawing.Size(390, 120);
            this.lvColumns.TabIndex = 0;
            this.lvColumns.TargetNamespace = null;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.lvRows);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(396, 126);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Rows";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // lvRows
            // 
            this.lvRows.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvRows.ListName = null;
            this.lvRows.Location = new System.Drawing.Point(3, 3);
            this.lvRows.Margin = new System.Windows.Forms.Padding(0);
            this.lvRows.Name = "lvRows";
            this.lvRows.SchemaTypeName = null;
            this.lvRows.Size = new System.Drawing.Size(390, 120);
            this.lvRows.TabIndex = 1;
            this.lvRows.TargetNamespace = null;
            // 
            // helpLabel1
            // 
            this.helpLabel1.HelpMessageKey = "CrossPointSwitchControl.LineCount";
            this.helpLabel1.Location = new System.Drawing.Point(4, 127);
            this.helpLabel1.Name = "helpLabel1";
            this.helpLabel1.RequiredField = true;
            this.helpLabel1.RequiredFieldMarkerFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.helpLabel1.Size = new System.Drawing.Size(63, 18);
            this.helpLabel1.TabIndex = 4;
            this.helpLabel1.Text = "Line Count";
            this.helpLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // edtLineCount
            // 
            this.edtLineCount.AttributeName = null;
            this.edtLineCount.Location = new System.Drawing.Point(71, 128);
            this.edtLineCount.Name = "edtLineCount";
            this.edtLineCount.Size = new System.Drawing.Size(86, 20);
            this.edtLineCount.TabIndex = 5;
            this.edtLineCount.Value = null;
            this.edtLineCount.ValueType = ATMLCommonLibrary.controls.awb.AWBTextBox.eValueType.xsString;
            // 
            // CrossPointSwitchControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.edtLineCount);
            this.Controls.Add(this.helpLabel1);
            this.Controls.Add(this.lblPin);
            this.Controls.Add(this.tabControl1);
            this.Name = "CrossPointSwitchControl";
            this.Size = new System.Drawing.Size(500, 317);
            this.Controls.SetChildIndex(this.edtName, 0);
            this.Controls.SetChildIndex(this.edtDescription, 0);
            this.Controls.SetChildIndex(this.lblName, 0);
            this.Controls.SetChildIndex(this.lblDescription, 0);
            this.Controls.SetChildIndex(this.tabControl1, 0);
            this.Controls.SetChildIndex(this.lblPin, 0);
            this.Controls.SetChildIndex(this.helpLabel1, 0);
            this.Controls.SetChildIndex(this.edtLineCount, 0);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private HelpLabel lblPin;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private lists.ATMLListControl lvColumns;
        private System.Windows.Forms.TabPage tabPage2;
        private lists.ATMLListControl lvRows;
        private HelpLabel helpLabel1;
        private awb.AWBTextBox edtLineCount;
    }
}
