/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
* 
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

namespace ATMLCommonLibrary.controls.path
{
    partial class PathNodeControl
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
            this.edtPathName = new ATMLCommonLibrary.controls.awb.AWBTextBox(this.components);
            this.helpLabel2 = new ATMLCommonLibrary.controls.HelpLabel(this.components);
            this.requiredNameValidator = new ATMLCommonLibrary.controls.validators.RequiredFieldValidator();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(4, 67);
            // 
            // edtPathValue
            // 
            this.edtPathValue.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtPathValue.Location = new System.Drawing.Point(72, 65);
            this.edtPathValue.Size = new System.Drawing.Size(531, 46);
            // 
            // edtDescription
            // 
            this.edtDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtDescription.Location = new System.Drawing.Point(72, 118);
            this.edtDescription.Size = new System.Drawing.Size(531, 73);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(3, 118);
            // 
            // edtPathDocumentId
            // 
            this.edtPathDocumentId.Location = new System.Drawing.Point(72, 38);
            this.edtPathDocumentId.Size = new System.Drawing.Size(531, 20);
            // 
            // helpLabel1
            // 
            this.helpLabel1.Location = new System.Drawing.Point(20, 38);
            // 
            // btnSelectNetworkNode
            // 
            this.btnSelectNetworkNode.FlatAppearance.BorderSize = 0;
            this.btnSelectNetworkNode.Location = new System.Drawing.Point(607, 67);
            this.btnSelectNetworkNode.ToolTipText = "Press to select a path node";
            // 
            // edtPathName
            // 
            this.edtPathName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtPathName.AttributeName = null;
            this.edtPathName.Location = new System.Drawing.Point(72, 11);
            this.edtPathName.Name = "edtPathName";
            this.edtPathName.Size = new System.Drawing.Size(531, 20);
            this.edtPathName.TabIndex = 7;
            this.edtPathName.Value = null;
            this.edtPathName.ValueType = ATMLCommonLibrary.controls.awb.AWBTextBox.eValueType.xsString;
            // 
            // helpLabel2
            // 
            this.helpLabel2.AutoSize = true;
            this.helpLabel2.HelpMessageKey = "Path.Node.Name";
            this.helpLabel2.Location = new System.Drawing.Point(28, 13);
            this.helpLabel2.Name = "helpLabel2";
            this.helpLabel2.RequiredField = false;
            this.helpLabel2.RequiredFieldMarkerFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.helpLabel2.Size = new System.Drawing.Size(38, 13);
            this.helpLabel2.TabIndex = 6;
            this.helpLabel2.Text = "Name:";
            // 
            // requiredNameValidator
            // 
            this.requiredNameValidator.ControlToValidate = this.edtPathName;
            this.requiredNameValidator.ErrorMessage = "The Path Name is required";
            this.requiredNameValidator.ErrorProvider = null;
            this.requiredNameValidator.Icon = null;
            this.requiredNameValidator.InitialValue = null;
            this.requiredNameValidator.IsEnabled = true;
            // 
            // PathNodeControl
            // 
            this.Controls.Add(this.helpLabel2);
            this.Controls.Add(this.edtPathName);
            this.Name = "PathNodeControl";
            this.Size = new System.Drawing.Size(636, 205);
            this.Controls.SetChildIndex(this.btnSelectNetworkNode, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.edtPathValue, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.edtDescription, 0);
            this.Controls.SetChildIndex(this.helpLabel1, 0);
            this.Controls.SetChildIndex(this.edtPathDocumentId, 0);
            this.Controls.SetChildIndex(this.edtPathName, 0);
            this.Controls.SetChildIndex(this.helpLabel2, 0);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private awb.AWBTextBox edtPathName;
        private HelpLabel helpLabel2;
        private validators.RequiredFieldValidator requiredNameValidator;
    }
}
