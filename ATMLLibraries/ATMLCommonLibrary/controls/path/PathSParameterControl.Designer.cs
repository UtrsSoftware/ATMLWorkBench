/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
*
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/
namespace ATMLCommonLibrary.controls.path
{
    partial class PathSParameterControl
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.PathList = new ATMLCommonLibrary.controls.path.PathSParameterDataListControl();
            this.edtOutputPort = new ATMLCommonLibrary.controls.awb.AWBTextBox(this.components);
            this.edtInputPort = new ATMLCommonLibrary.controls.awb.AWBTextBox(this.components);
            this.helpLabel2 = new ATMLCommonLibrary.controls.HelpLabel(this.components);
            this.helpLabel1 = new ATMLCommonLibrary.controls.HelpLabel(this.components);
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Location = new System.Drawing.Point(7, 78);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(341, 158);
            this.tabControl1.TabIndex = 4;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.PathList);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(333, 132);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "S Parameter Data";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // PathList
            // 
            this.PathList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PathList.FormTitle = null;
            this.PathList.ListName = null;
            this.PathList.Location = new System.Drawing.Point(3, 3);
            this.PathList.Margin = new System.Windows.Forms.Padding(0);
            this.PathList.Name = "PathList";
            this.PathList.SchemaTypeName = null;
            this.PathList.ShowFind = false;
            this.PathList.Size = new System.Drawing.Size(327, 126);
            this.PathList.TabIndex = 0;
            this.PathList.TargetNamespace = null;
            this.PathList.TooltipTextAddButton = "Press to add a new S Parameter";
            this.PathList.TooltipTextDeleteButton = "Press to delete the selected S Parameter";
            this.PathList.TooltipTextEditButton = "Press to edit the selected S Parameter";
            // 
            // edtOutputPort
            // 
            this.edtOutputPort.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtOutputPort.AttributeName = null;
            this.edtOutputPort.Location = new System.Drawing.Point(69, 42);
            this.edtOutputPort.Name = "edtOutputPort";
            this.edtOutputPort.Size = new System.Drawing.Size(275, 20);
            this.edtOutputPort.TabIndex = 3;
            this.edtOutputPort.Value = null;
            this.edtOutputPort.ValueType = ATMLCommonLibrary.controls.awb.AWBTextBox.eValueType.xsString;
            // 
            // edtInputPort
            // 
            this.edtInputPort.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtInputPort.AttributeName = null;
            this.edtInputPort.BackColor = System.Drawing.Color.PaleTurquoise;
            this.edtInputPort.Location = new System.Drawing.Point(69, 10);
            this.edtInputPort.Name = "edtInputPort";
            this.edtInputPort.Size = new System.Drawing.Size(275, 20);
            this.edtInputPort.TabIndex = 1;
            this.edtInputPort.Value = null;
            this.edtInputPort.ValueType = ATMLCommonLibrary.controls.awb.AWBTextBox.eValueType.xsString;
            // 
            // helpLabel2
            // 
            this.helpLabel2.AutoSize = true;
            this.helpLabel2.HelpMessageKey = null;
            this.helpLabel2.Location = new System.Drawing.Point(4, 45);
            this.helpLabel2.Name = "helpLabel2";
            this.helpLabel2.RequiredField = false;
            this.helpLabel2.RequiredFieldMarkerFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.helpLabel2.Size = new System.Drawing.Size(61, 13);
            this.helpLabel2.TabIndex = 2;
            this.helpLabel2.Text = "Output Port";
            // 
            // helpLabel1
            // 
            this.helpLabel1.AutoSize = true;
            this.helpLabel1.HelpMessageKey = null;
            this.helpLabel1.Location = new System.Drawing.Point(10, 13);
            this.helpLabel1.Name = "helpLabel1";
            this.helpLabel1.RequiredField = false;
            this.helpLabel1.RequiredFieldMarkerFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.helpLabel1.Size = new System.Drawing.Size(53, 13);
            this.helpLabel1.TabIndex = 0;
            this.helpLabel1.Text = "Input Port";
            // 
            // pathSParameterControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.edtOutputPort);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.edtInputPort);
            this.Controls.Add(this.helpLabel2);
            this.Controls.Add(this.helpLabel1);
            this.Name = "pathSParameterControl";
            this.Size = new System.Drawing.Size(359, 248);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private PathSParameterDataListControl PathList;
        private awb.AWBTextBox edtOutputPort;
        private awb.AWBTextBox edtInputPort;
        private HelpLabel helpLabel2;
        private HelpLabel helpLabel1;

    }
}
