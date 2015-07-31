/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
*
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

namespace ATMLCommonLibrary.controls.control.tool
{
    partial class ControlToolControl
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
            this.helpLabel1 = new ATMLCommonLibrary.controls.HelpLabel(this.components);
            this.edtFilePath = new ATMLCommonLibrary.controls.awb.AWBTextBox(this.components);
            this.helpLabel2 = new ATMLCommonLibrary.controls.HelpLabel(this.components);
            this.controlToolDependancyListControl1 = new ATMLCommonLibrary.controls.control.tool.ControlToolDependancyListControl();
            this.SuspendLayout();
            // 
            // helpLabel1
            // 
            this.helpLabel1.AutoSize = true;
            this.helpLabel1.HelpMessageKey = "ControlTool.Dependencies";
            this.helpLabel1.Location = new System.Drawing.Point(10, 94);
            this.helpLabel1.Name = "helpLabel1";
            this.helpLabel1.RequiredField = false;
            this.helpLabel1.RequiredFieldMarkerFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.helpLabel1.Size = new System.Drawing.Size(79, 13);
            this.helpLabel1.TabIndex = 7;
            this.helpLabel1.Text = "Dependencies:";
            // 
            // edtFilePath
            // 
            this.edtFilePath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtFilePath.AttributeName = null;
            this.edtFilePath.DataLookupKey = null;
            this.edtFilePath.Location = new System.Drawing.Point(86, 65);
            this.edtFilePath.Name = "edtFilePath";
            this.edtFilePath.Size = new System.Drawing.Size(280, 20);
            this.edtFilePath.TabIndex = 8;
            this.edtFilePath.Value = null;
            this.edtFilePath.ValueType = ATMLCommonLibrary.controls.awb.AWBTextBox.eValueType.xsString;
            // 
            // helpLabel2
            // 
            this.helpLabel2.AutoSize = true;
            this.helpLabel2.HelpMessageKey = "ControlTool.FilePath";
            this.helpLabel2.Location = new System.Drawing.Point(11, 68);
            this.helpLabel2.Name = "helpLabel2";
            this.helpLabel2.RequiredField = false;
            this.helpLabel2.RequiredFieldMarkerFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.helpLabel2.Size = new System.Drawing.Size(51, 13);
            this.helpLabel2.TabIndex = 9;
            this.helpLabel2.Text = "File Path:";
            // 
            // controlToolDependancyListControl1
            // 
            this.controlToolDependancyListControl1.AllowRowResequencing = false;
            this.controlToolDependancyListControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.controlToolDependancyListControl1.BackColor = System.Drawing.Color.AliceBlue;
            this.controlToolDependancyListControl1.FormTitle = null;
            this.controlToolDependancyListControl1.HasErrors = false;
            this.controlToolDependancyListControl1.HelpKeyWord = null;
            this.controlToolDependancyListControl1.LastError = null;
            this.controlToolDependancyListControl1.ListName = null;
            this.controlToolDependancyListControl1.Location = new System.Drawing.Point(13, 112);
            this.controlToolDependancyListControl1.Margin = new System.Windows.Forms.Padding(0);
            this.controlToolDependancyListControl1.Name = "controlToolDependancyListControl1";
            this.controlToolDependancyListControl1.SchemaTypeName = null;
            this.controlToolDependancyListControl1.ShowFind = false;
            this.controlToolDependancyListControl1.Size = new System.Drawing.Size(393, 140);
            this.controlToolDependancyListControl1.TabIndex = 10;
            this.controlToolDependancyListControl1.TargetNamespace = null;
            this.controlToolDependancyListControl1.TooltipTextAddButton = "Press to add a new ";
            this.controlToolDependancyListControl1.TooltipTextDeleteButton = "Press to delete the selected ";
            this.controlToolDependancyListControl1.TooltipTextEditButton = "Press to edit the selected ";
            this.controlToolDependancyListControl1.VersionIdentifiers = null;
            // 
            // ControlToolControl
            // 
            this.Controls.Add(this.controlToolDependancyListControl1);
            this.Controls.Add(this.helpLabel2);
            this.Controls.Add(this.edtFilePath);
            this.Controls.Add(this.helpLabel1);
            this.Name = "ControlToolControl";
            this.Padding = new System.Windows.Forms.Padding(0, 50, 0, 0);
            this.Size = new System.Drawing.Size(418, 265);
            this.Controls.SetChildIndex(this.lblVersionName, 0);
            this.Controls.SetChildIndex(this.edtVersionName, 0);
            this.Controls.SetChildIndex(this.lblVersion, 0);
            this.Controls.SetChildIndex(this.edtVersion, 0);
            this.Controls.SetChildIndex(this.lblVersionQualifier, 0);
            this.Controls.SetChildIndex(this.cmbVersionIdentifierQualifier, 0);
            this.Controls.SetChildIndex(this.helpLabel1, 0);
            this.Controls.SetChildIndex(this.edtFilePath, 0);
            this.Controls.SetChildIndex(this.helpLabel2, 0);
            this.Controls.SetChildIndex(this.controlToolDependancyListControl1, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private HelpLabel helpLabel1;
        private awb.AWBTextBox edtFilePath;
        private HelpLabel helpLabel2;
        private ControlToolDependancyListControl controlToolDependancyListControl1;
    }
}
