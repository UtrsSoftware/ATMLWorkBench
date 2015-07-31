/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
*
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/
using ATMLCommonLibrary.controls.trigger;

namespace ATMLCommonLibrary.controls
{
    partial class ResourceControl
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
            if( disposing && ( components != null ) )
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
            this.edtIndex = new ATMLCommonLibrary.controls.awb.AWBTextBox(this.components);
            this.label3 = new ATMLCommonLibrary.controls.HelpLabel(this.components);
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.portListControl = new ATMLCommonLibrary.controls.common.PortListControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.triggerListControl = new ATMLCommonLibrary.controls.trigger.TriggerListControl();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // edtBaseIndex
            // 
            this.edtBaseIndex.Location = new System.Drawing.Point(72, 101);
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(9, 104);
            // 
            // edtCount
            // 
            this.edtCount.Location = new System.Drawing.Point(171, 101);
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(133, 104);
            // 
            // edtReplacementChar
            // 
            this.edtReplacementChar.Location = new System.Drawing.Point(429, 101);
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(366, 104);
            // 
            // edtIncrementBy
            // 
            this.edtIncrementBy.Location = new System.Drawing.Point(304, 101);
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(233, 104);
            // 
            // edtDescription
            // 
            this.edtDescription.Size = new System.Drawing.Size(500, 56);
            this.edtDescription.TabIndex = 4;
            // 
            // edtName
            // 
            this.edtName.Size = new System.Drawing.Size(500, 20);
            this.edtName.TabIndex = 2;
            // 
            // lblName
            // 
            this.lblName.TabIndex = 1;
            // 
            // lblDescription
            // 
            this.lblDescription.TabIndex = 3;
            // 
            // edtIndex
            // 
            this.edtIndex.AttributeName = null;
            this.edtIndex.Location = new System.Drawing.Point(529, 101);
            this.edtIndex.Name = "edtIndex";
            this.edtIndex.Size = new System.Drawing.Size(42, 20);
            this.edtIndex.TabIndex = 13;
            this.edtIndex.Tag = 0;
            this.edtIndex.Text = "0";
            this.edtIndex.Value = 0;
            this.edtIndex.ValueType = ATMLCommonLibrary.controls.awb.AWBTextBox.eValueType.xsInteger;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.HelpMessageKey = "ResourceControl.Index";
            this.label3.Location = new System.Drawing.Point(490, 104);
            this.label3.Name = "label3";
            this.label3.RequiredField = false;
            this.label3.RequiredFieldMarkerFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Size = new System.Drawing.Size(33, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Index";
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(13, 131);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(556, 172);
            this.tabControl1.TabIndex = 14;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.portListControl);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(548, 146);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Interface";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // portListControl
            // 
            this.portListControl.AllowRowResequencing = false;
            this.portListControl.BackColor = System.Drawing.Color.Transparent;
            this.portListControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.portListControl.FormTitle = null;
            this.portListControl.HelpKeyWord = null;
            this.portListControl.ListName = null;
            this.portListControl.Location = new System.Drawing.Point(3, 3);
            this.portListControl.Margin = new System.Windows.Forms.Padding(0);
            this.portListControl.Name = "portListControl";
            this.portListControl.SchemaTypeName = null;
            this.portListControl.ShowFind = false;
            this.portListControl.Size = new System.Drawing.Size(542, 140);
            this.portListControl.TabIndex = 0;
            this.portListControl.TargetNamespace = null;
            this.portListControl.TooltipTextAddButton = "Press to add a new ";
            this.portListControl.TooltipTextDeleteButton = "Press to delete the selected ";
            this.portListControl.TooltipTextEditButton = "Press to edit the selected ";
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.LightSteelBlue;
            this.tabPage2.Controls.Add(this.triggerListControl);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(578, 218);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Triggers";
            // 
            // triggerListControl
            // 
            this.triggerListControl.AllowRowResequencing = false;
            this.triggerListControl.BackColor = System.Drawing.Color.LightSteelBlue;
            this.triggerListControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.triggerListControl.FormTitle = null;
            this.triggerListControl.HelpKeyWord = null;
            this.triggerListControl.ListName = null;
            this.triggerListControl.Location = new System.Drawing.Point(3, 3);
            this.triggerListControl.Margin = new System.Windows.Forms.Padding(0);
            this.triggerListControl.Name = "triggerListControl";
            this.triggerListControl.SchemaTypeName = null;
            this.triggerListControl.ShowFind = false;
            this.triggerListControl.Size = new System.Drawing.Size(572, 212);
            this.triggerListControl.TabIndex = 0;
            this.triggerListControl.TargetNamespace = null;
            this.triggerListControl.TooltipTextAddButton = "Press to add a new ";
            this.triggerListControl.TooltipTextDeleteButton = "Press to delete the selected ";
            this.triggerListControl.TooltipTextEditButton = "Press to edit the selected ";
            this.triggerListControl.Load += new System.EventHandler(this.triggerListControl_Load);
            // 
            // ResourceControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.edtIndex);
            this.Controls.Add(this.label3);
            this.MinimumSize = new System.Drawing.Size(0, 0);
            this.Name = "ResourceControl";
            this.Size = new System.Drawing.Size(603, 318);
            this.Validating += new System.ComponentModel.CancelEventHandler(this.ResourceControl_Validating);
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
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.edtIndex, 0);
            this.Controls.SetChildIndex(this.tabControl1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private awb.AWBTextBox edtIndex;
        private ATMLCommonLibrary.controls.HelpLabel label3;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private ATMLCommonLibrary.controls.common.PortListControl portListControl;
        private TriggerListControl triggerListControl;
    }
}
