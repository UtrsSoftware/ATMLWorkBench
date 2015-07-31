/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
*
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

using ATMLCommonLibrary.controls.awb;

namespace ATMLCommonLibrary.controls.network
{
    partial class NetworkNodeControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NetworkNodeControl));
            this.label1 = new ATMLCommonLibrary.controls.HelpLabel(this.components);
            this.edtPathValue = new ATMLCommonLibrary.controls.awb.AWBTextBox(this.components);
            this.edtDescription = new ATMLCommonLibrary.controls.awb.AWBTextBox(this.components);
            this.label2 = new ATMLCommonLibrary.controls.HelpLabel(this.components);
            this.edtPathDocumentId = new ATMLCommonLibrary.controls.awb.AWBTextBox(this.components);
            this.helpLabel1 = new ATMLCommonLibrary.controls.HelpLabel(this.components);
            this.requiredPathValidator = new ATMLCommonLibrary.controls.validators.RequiredFieldValidator();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.btnSelectNetworkNode = new ATMLCommonLibrary.controls.awb.AWBButton();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.HelpMessageKey = "NetworkNodeControl.Path";
            this.label1.Location = new System.Drawing.Point(4, 42);
            this.label1.Name = "label1";
            this.label1.RequiredField = false;
            this.label1.RequiredFieldMarkerFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Path Value:";
            // 
            // edtPathValue
            // 
            this.edtPathValue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtPathValue.AttributeName = null;
            this.edtPathValue.DataLookupKey = null;
            this.edtPathValue.Location = new System.Drawing.Point(72, 40);
            this.edtPathValue.Multiline = true;
            this.edtPathValue.Name = "edtPathValue";
            this.edtPathValue.Size = new System.Drawing.Size(494, 48);
            this.edtPathValue.TabIndex = 3;
            this.edtPathValue.Value = null;
            this.edtPathValue.ValueType = ATMLCommonLibrary.controls.awb.AWBTextBox.eValueType.xsString;
            // 
            // edtDescription
            // 
            this.edtDescription.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtDescription.AttributeName = null;
            this.edtDescription.DataLookupKey = null;
            this.edtDescription.Location = new System.Drawing.Point(72, 94);
            this.edtDescription.Multiline = true;
            this.edtDescription.Name = "edtDescription";
            this.edtDescription.Size = new System.Drawing.Size(494, 98);
            this.edtDescription.TabIndex = 5;
            this.edtDescription.Value = null;
            this.edtDescription.ValueType = ATMLCommonLibrary.controls.awb.AWBTextBox.eValueType.xsString;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.HelpMessageKey = "NetworkNodeControl.PathDescription";
            this.label2.Location = new System.Drawing.Point(3, 94);
            this.label2.Name = "label2";
            this.label2.RequiredField = false;
            this.label2.RequiredFieldMarkerFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Description:";
            // 
            // edtPathDocumentId
            // 
            this.edtPathDocumentId.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtPathDocumentId.AttributeName = null;
            this.edtPathDocumentId.DataLookupKey = null;
            this.edtPathDocumentId.Location = new System.Drawing.Point(72, 15);
            this.edtPathDocumentId.Name = "edtPathDocumentId";
            this.edtPathDocumentId.Size = new System.Drawing.Size(494, 20);
            this.edtPathDocumentId.TabIndex = 1;
            this.edtPathDocumentId.Value = null;
            this.edtPathDocumentId.ValueType = ATMLCommonLibrary.controls.awb.AWBTextBox.eValueType.xsString;
            // 
            // helpLabel1
            // 
            this.helpLabel1.AutoSize = true;
            this.helpLabel1.HelpMessageKey = "NetworkNodeControl.Path.UUID";
            this.helpLabel1.Location = new System.Drawing.Point(20, 15);
            this.helpLabel1.Name = "helpLabel1";
            this.helpLabel1.RequiredField = false;
            this.helpLabel1.RequiredFieldMarkerFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.helpLabel1.Size = new System.Drawing.Size(46, 13);
            this.helpLabel1.TabIndex = 0;
            this.helpLabel1.Text = "Path ID:";
            // 
            // requiredPathValidator
            // 
            this.requiredPathValidator.ControlToValidate = this.edtPathValue;
            this.requiredPathValidator.ErrorMessage = "A Network Path Value is required";
            this.requiredPathValidator.ErrorProvider = this.errorProvider;
            this.requiredPathValidator.Icon = null;
            this.requiredPathValidator.InitialValue = null;
            this.requiredPathValidator.IsEnabled = true;
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // btnSelectNetworkNode
            // 
            this.btnSelectNetworkNode.Active = true;
            this.btnSelectNetworkNode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSelectNetworkNode.BorderColor = System.Drawing.Color.Gray;
            this.btnSelectNetworkNode.ButtonStyle = ATMLCommonLibrary.controls.awb.AWBButton.ButtonStyles.Rectangle;
            this.btnSelectNetworkNode.FlatAppearance.BorderSize = 0;
            this.btnSelectNetworkNode.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSelectNetworkNode.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold);
            this.btnSelectNetworkNode.GradientStyle = ATMLCommonLibrary.controls.awb.AWBButton.GradientStyles.Vertical;
            this.btnSelectNetworkNode.HoverBorderColor = System.Drawing.Color.LightSteelBlue;
            this.btnSelectNetworkNode.HoverColorA = System.Drawing.Color.SteelBlue;
            this.btnSelectNetworkNode.HoverColorB = System.Drawing.Color.SteelBlue;
            this.btnSelectNetworkNode.HoverTextColor = System.Drawing.Color.White;
            this.btnSelectNetworkNode.Image = ((System.Drawing.Image)(resources.GetObject("btnSelectNetworkNode.Image")));
            this.btnSelectNetworkNode.Location = new System.Drawing.Point(566, 41);
            this.btnSelectNetworkNode.Name = "btnSelectNetworkNode";
            this.btnSelectNetworkNode.NormalBorderColor = System.Drawing.Color.SteelBlue;
            this.btnSelectNetworkNode.NormalColorA = System.Drawing.Color.LightSteelBlue;
            this.btnSelectNetworkNode.NormalColorB = System.Drawing.Color.LightSteelBlue;
            this.btnSelectNetworkNode.Size = new System.Drawing.Size(24, 23);
            this.btnSelectNetworkNode.SmoothingQuality = ATMLCommonLibrary.controls.awb.AWBButton.SmoothingQualities.AntiAlias;
            this.btnSelectNetworkNode.TabIndex = 6;
            this.btnSelectNetworkNode.ToolTipText = "Press to select a network node";
            this.btnSelectNetworkNode.UseVisualStyleBackColor = true;
            this.btnSelectNetworkNode.Click += new System.EventHandler(this.btnSelectNetworkNode_Click);
            // 
            // NetworkNodeControl
            // 
            this.Controls.Add(this.btnSelectNetworkNode);
            this.Controls.Add(this.edtPathDocumentId);
            this.Controls.Add(this.helpLabel1);
            this.Controls.Add(this.edtDescription);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.edtPathValue);
            this.Controls.Add(this.label1);
            this.Name = "NetworkNodeControl";
            this.Size = new System.Drawing.Size(593, 204);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected ATMLCommonLibrary.controls.HelpLabel label1;
        protected awb.AWBTextBox edtPathValue;
        protected awb.AWBTextBox edtDescription;
        protected ATMLCommonLibrary.controls.HelpLabel label2;
        protected awb.AWBTextBox edtPathDocumentId;
        protected HelpLabel helpLabel1;
        private validators.RequiredFieldValidator requiredPathValidator;
        protected System.Windows.Forms.ErrorProvider errorProvider;
        protected AWBButton btnSelectNetworkNode;
    }
}
