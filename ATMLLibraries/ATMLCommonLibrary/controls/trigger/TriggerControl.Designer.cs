/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
* 
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

namespace ATMLCommonLibrary.controls
{
    partial class TriggerControl
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabProperties = new System.Windows.Forms.TabPage();
            this.propertyListControl = new ATMLCommonLibrary.controls.trigger.PropertyListControl();
            this.tabPorts = new System.Windows.Forms.TabPage();
            this.portListControl = new ATMLCommonLibrary.controls.trigger.TriggerPortListControl();
            this.edtDescription = new ATMLCommonLibrary.controls.awb.AWBTextBox(this.components);
            this.label2 = new ATMLCommonLibrary.controls.HelpLabel(this.components);
            this.edtName = new ATMLCommonLibrary.controls.awb.AWBTextBox(this.components);
            this.label1 = new ATMLCommonLibrary.controls.HelpLabel(this.components);
            this.tabControl1.SuspendLayout();
            this.tabProperties.SuspendLayout();
            this.tabPorts.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabProperties);
            this.tabControl1.Controls.Add(this.tabPorts);
            this.tabControl1.Location = new System.Drawing.Point(7, 110);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(610, 210);
            this.tabControl1.TabIndex = 29;
            // 
            // tabProperties
            // 
            this.tabProperties.Controls.Add(this.propertyListControl);
            this.tabProperties.Location = new System.Drawing.Point(4, 22);
            this.tabProperties.Name = "tabProperties";
            this.tabProperties.Padding = new System.Windows.Forms.Padding(3);
            this.tabProperties.Size = new System.Drawing.Size(602, 184);
            this.tabProperties.TabIndex = 0;
            this.tabProperties.Text = "Properties";
            this.tabProperties.UseVisualStyleBackColor = true;
            // 
            // propertyListControl
            // 
            this.propertyListControl.BackColor = System.Drawing.Color.Transparent;
            this.propertyListControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.propertyListControl.ListName = null;
            this.propertyListControl.Location = new System.Drawing.Point(3, 3);
            this.propertyListControl.Margin = new System.Windows.Forms.Padding(0);
            this.propertyListControl.Name = "propertyListControl";
            this.propertyListControl.SchemaTypeName = null;
            this.propertyListControl.Size = new System.Drawing.Size(596, 178);
            this.propertyListControl.TabIndex = 0;
            this.propertyListControl.TargetNamespace = null;
            // 
            // tabPorts
            // 
            this.tabPorts.Controls.Add(this.portListControl);
            this.tabPorts.Location = new System.Drawing.Point(4, 22);
            this.tabPorts.Name = "tabPorts";
            this.tabPorts.Padding = new System.Windows.Forms.Padding(3);
            this.tabPorts.Size = new System.Drawing.Size(602, 184);
            this.tabPorts.TabIndex = 1;
            this.tabPorts.Text = "Ports";
            this.tabPorts.UseVisualStyleBackColor = true;
            // 
            // portListControl
            // 
            this.portListControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.portListControl.Location = new System.Drawing.Point(3, 3);
            this.portListControl.Name = "portListControl";
            this.portListControl.Size = new System.Drawing.Size(596, 178);
            this.portListControl.TabIndex = 0;
            // 
            // edtDescription
            // 
            this.edtDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtDescription.AttributeName = null;
            this.edtDescription.Location = new System.Drawing.Point(71, 32);
            this.edtDescription.Multiline = true;
            this.edtDescription.Name = "edtDescription";
            this.edtDescription.Size = new System.Drawing.Size(543, 69);
            this.edtDescription.TabIndex = 18;
            this.edtDescription.Value = null;
            this.edtDescription.ValueType = ATMLCommonLibrary.controls.awb.AWBTextBox.eValueType.xsString;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.HelpMessageKey = "TriggerControl.Description";
            this.label2.Location = new System.Drawing.Point(3, 34);
            this.label2.Name = "label2";
            this.label2.RequiredField = false;
            this.label2.RequiredFieldMarkerFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 17;
            this.label2.Text = "Description";
            // 
            // edtName
            // 
            this.edtName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtName.AttributeName = null;
            this.edtName.Location = new System.Drawing.Point(71, 6);
            this.edtName.Name = "edtName";
            this.edtName.Size = new System.Drawing.Size(543, 20);
            this.edtName.TabIndex = 16;
            this.edtName.Value = null;
            this.edtName.ValueType = ATMLCommonLibrary.controls.awb.AWBTextBox.eValueType.xsString;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.HelpMessageKey = "TriggerControl.Name";
            this.label1.Location = new System.Drawing.Point(28, 8);
            this.label1.Name = "label1";
            this.label1.RequiredField = false;
            this.label1.RequiredFieldMarkerFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 15;
            this.label1.Text = "Name";
            // 
            // TriggerControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.edtDescription);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.edtName);
            this.Controls.Add(this.label1);
            this.Name = "TriggerControl";
            this.Size = new System.Drawing.Size(625, 328);
            this.tabControl1.ResumeLayout(false);
            this.tabProperties.ResumeLayout(false);
            this.tabPorts.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabProperties;
        private System.Windows.Forms.TabPage tabPorts;
        private ATMLCommonLibrary.controls.awb.AWBTextBox edtDescription;
        private ATMLCommonLibrary.controls.HelpLabel label2;
        private ATMLCommonLibrary.controls.awb.AWBTextBox edtName;
        private ATMLCommonLibrary.controls.HelpLabel label1;
        private ATMLCommonLibrary.controls.trigger.PropertyListControl propertyListControl;
        private ATMLCommonLibrary.controls.trigger.TriggerPortListControl portListControl;
    }
}
