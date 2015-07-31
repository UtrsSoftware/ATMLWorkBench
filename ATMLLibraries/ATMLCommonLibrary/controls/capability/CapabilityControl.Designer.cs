/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
*
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

using System.Windows.Forms;
using ATMLCommonLibrary.controls.awb;

namespace ATMLCommonLibrary.controls.capability
{
    partial class CapabilityControl
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
            this.helpLabel1 = new ATMLCommonLibrary.controls.HelpLabel(this.components);
            this.helpLabel2 = new ATMLCommonLibrary.controls.HelpLabel(this.components);
            this.edtName = new ATMLCommonLibrary.controls.awb.AWBTextBox(this.components);
            this.edtDescription = new ATMLCommonLibrary.controls.awb.AWBTextBox(this.components);
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabInterface = new System.Windows.Forms.TabPage();
            this.interfaceListControl = new ATMLCommonLibrary.controls.capability.CapabilityInterfaceListControl();
            this.tabSignal = new System.Windows.Forms.TabPage();
            this.signalControl = new ATMLCommonLibrary.controls.signal.SignalControl();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.requiredName = new ATMLCommonLibrary.controls.validators.RequiredFieldValidator();
            this.tabControl.SuspendLayout();
            this.tabInterface.SuspendLayout();
            this.tabSignal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // helpLabel1
            // 
            this.helpLabel1.AutoSize = true;
            this.helpLabel1.HelpMessageKey = "Capability.Name";
            this.helpLabel1.Location = new System.Drawing.Point(10, 12);
            this.helpLabel1.Name = "helpLabel1";
            this.helpLabel1.RequiredField = false;
            this.helpLabel1.RequiredFieldMarkerFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.helpLabel1.Size = new System.Drawing.Size(35, 13);
            this.helpLabel1.TabIndex = 0;
            this.helpLabel1.Text = "Name";
            // 
            // helpLabel2
            // 
            this.helpLabel2.AutoSize = true;
            this.helpLabel2.HelpMessageKey = "Capability.Description";
            this.helpLabel2.Location = new System.Drawing.Point(10, 41);
            this.helpLabel2.Name = "helpLabel2";
            this.helpLabel2.RequiredField = false;
            this.helpLabel2.RequiredFieldMarkerFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.helpLabel2.Size = new System.Drawing.Size(60, 13);
            this.helpLabel2.TabIndex = 1;
            this.helpLabel2.Text = "Description";
            // 
            // edtName
            // 
            this.edtName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtName.AttributeName = null;
            this.edtName.Location = new System.Drawing.Point(76, 12);
            this.edtName.Name = "edtName";
            this.edtName.Size = new System.Drawing.Size(447, 20);
            this.edtName.TabIndex = 2;
            this.edtName.Value = null;
            this.edtName.ValueType = ATMLCommonLibrary.controls.awb.AWBTextBox.eValueType.xsString;
            // 
            // edtDescription
            // 
            this.edtDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtDescription.AttributeName = null;
            this.edtDescription.Location = new System.Drawing.Point(76, 38);
            this.edtDescription.Name = "edtDescription";
            this.edtDescription.Size = new System.Drawing.Size(447, 20);
            this.edtDescription.TabIndex = 3;
            this.edtDescription.Value = null;
            this.edtDescription.ValueType = ATMLCommonLibrary.controls.awb.AWBTextBox.eValueType.xsString;
            // 
            // tabControl
            // 
            this.tabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl.Controls.Add(this.tabInterface);
            this.tabControl.Controls.Add(this.tabSignal);
            this.tabControl.Location = new System.Drawing.Point(10, 74);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(532, 441);
            this.tabControl.TabIndex = 4;
            this.tabControl.Selected += new System.Windows.Forms.TabControlEventHandler(this.tabControl_Selected);
            // 
            // tabInterface
            // 
            this.tabInterface.Controls.Add(this.interfaceListControl);
            this.tabInterface.Location = new System.Drawing.Point(4, 22);
            this.tabInterface.Name = "tabInterface";
            this.tabInterface.Padding = new System.Windows.Forms.Padding(3);
            this.tabInterface.Size = new System.Drawing.Size(484, 482);
            this.tabInterface.TabIndex = 0;
            this.tabInterface.Text = "Interface";
            this.tabInterface.UseVisualStyleBackColor = true;
            // 
            // interfaceListControl
            // 
            this.interfaceListControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.interfaceListControl.Instrument = null;
            this.interfaceListControl.Location = new System.Drawing.Point(3, 3);
            this.interfaceListControl.Name = "interfaceListControl";
            this.interfaceListControl.ParentCapability = null;
            this.interfaceListControl.Size = new System.Drawing.Size(478, 476);
            this.interfaceListControl.TabIndex = 0;
            this.interfaceListControl.TestAdapterDescription = null;
            this.interfaceListControl.TestStationDescription = null;
            this.interfaceListControl.Load += new System.EventHandler(this.interfaceListControl_Load);
            // 
            // tabSignal
            // 
            this.tabSignal.Controls.Add(this.signalControl);
            this.tabSignal.Location = new System.Drawing.Point(4, 22);
            this.tabSignal.Name = "tabSignal";
            this.tabSignal.Padding = new System.Windows.Forms.Padding(3);
            this.tabSignal.Size = new System.Drawing.Size(524, 415);
            this.tabSignal.TabIndex = 1;
            this.tabSignal.Text = "Signal";
            this.tabSignal.UseVisualStyleBackColor = true;
            // 
            // signalControl
            // 
            this.signalControl.AllowDrop = true;
            this.signalControl.BackColor = System.Drawing.Color.AliceBlue;
            this.signalControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.signalControl.HasErrors = false;
            this.signalControl.HelpKeyWord = null;
            this.signalControl.LastError = null;
            this.signalControl.Location = new System.Drawing.Point(3, 3);
            this.signalControl.Name = "signalControl";
            this.signalControl.SchemaTypeName = null;
            this.signalControl.Size = new System.Drawing.Size(518, 409);
            this.signalControl.TabIndex = 0;
            this.signalControl.TargetNamespace = null;
            this.signalControl.Load += new System.EventHandler(this.signalControl1_Load);
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // requiredName
            // 
            this.requiredName.ControlToValidate = this.edtName;
            this.requiredName.ErrorMessage = "The capability name is required";
            this.requiredName.ErrorProvider = this.errorProvider;
            this.requiredName.Icon = null;
            this.requiredName.InitialValue = null;
            this.requiredName.IsEnabled = true;
            // 
            // CapabilityControl
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.edtDescription);
            this.Controls.Add(this.edtName);
            this.Controls.Add(this.helpLabel2);
            this.Controls.Add(this.helpLabel1);
            this.Name = "CapabilityControl";
            this.Size = new System.Drawing.Size(552, 525);
            this.tabControl.ResumeLayout(false);
            this.tabInterface.ResumeLayout(false);
            this.tabSignal.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private HelpLabel helpLabel1;
        private HelpLabel helpLabel2;
        private ATMLCommonLibrary.controls.awb.AWBTextBox edtName;
        private ATMLCommonLibrary.controls.awb.AWBTextBox edtDescription;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabInterface;
        private ATMLCommonLibrary.controls.capability.CapabilityInterfaceListControl interfaceListControl;
        private System.Windows.Forms.TabPage tabSignal;
        private signal.SignalControl signalControl;
        private validators.RequiredFieldValidator requiredName;
        protected ErrorProvider errorProvider;
    }
}
