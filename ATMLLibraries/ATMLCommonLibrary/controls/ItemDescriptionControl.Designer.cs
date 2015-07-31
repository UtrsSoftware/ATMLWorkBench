/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
*
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

using ATMLModelLibrary;

namespace ATMLCommonLibrary.controls
{
    public partial class ItemDescriptionControl
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
            this.edtName = new ATMLCommonLibrary.controls.awb.AWBTextBox(this.components);
            this.edtDescription = new ATMLCommonLibrary.controls.awb.AWBTextBox(this.components);
            this.edtVersion = new ATMLCommonLibrary.controls.awb.AWBTextBox(this.components);
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.label3 = new ATMLCommonLibrary.controls.HelpLabel(this.components);
            this.label2 = new ATMLCommonLibrary.controls.HelpLabel(this.components);
            this.identificationControl = new ATMLCommonLibrary.controls.IdentificationControl();
            this.label1 = new ATMLCommonLibrary.controls.HelpLabel(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // edtName
            // 
            this.edtName.AttributeName = null;
            this.edtName.Location = new System.Drawing.Point(67, 10);
            this.edtName.Name = "edtName";
            this.edtName.Size = new System.Drawing.Size(353, 20);
            this.edtName.TabIndex = 1;
            this.edtName.Value = null;
            this.edtName.ValueType = ATMLCommonLibrary.controls.awb.AWBTextBox.eValueType.xsString;
            // 
            // edtDescription
            // 
            this.edtDescription.AttributeName = null;
            this.edtDescription.Location = new System.Drawing.Point(67, 64);
            this.edtDescription.Multiline = true;
            this.edtDescription.Name = "edtDescription";
            this.edtDescription.Size = new System.Drawing.Size(353, 39);
            this.edtDescription.TabIndex = 5;
            this.edtDescription.Value = null;
            this.edtDescription.ValueType = ATMLCommonLibrary.controls.awb.AWBTextBox.eValueType.xsString;
            // 
            // edtVersion
            // 
            this.edtVersion.AttributeName = null;
            this.edtVersion.Location = new System.Drawing.Point(67, 36);
            this.edtVersion.Name = "edtVersion";
            this.edtVersion.Size = new System.Drawing.Size(162, 20);
            this.edtVersion.TabIndex = 3;
            this.edtVersion.Value = null;
            this.edtVersion.ValueType = ATMLCommonLibrary.controls.awb.AWBTextBox.eValueType.xsString;
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.HelpMessageKey = "ItemDescription.version";
            this.label3.Location = new System.Drawing.Point(4, 38);
            this.label3.Name = "label3";
            this.label3.RequiredField = false;
            this.label3.RequiredFieldMarkerFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Size = new System.Drawing.Size(42, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Version";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.HelpMessageKey = "ItemDescription.description";
            this.label2.Location = new System.Drawing.Point(4, 66);
            this.label2.Name = "label2";
            this.label2.RequiredField = false;
            this.label2.RequiredFieldMarkerFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Description";
            // 
            // identificationControl
            // 
            this.identificationControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.identificationControl.BackColor = System.Drawing.Color.LightSteelBlue;
            this.identificationControl.HasErrors = false;
            this.identificationControl.HelpKeyWord = null;
            this.identificationControl.LastError = null;
            this.identificationControl.Location = new System.Drawing.Point(7, 114);
            this.identificationControl.Name = "identificationControl";
            this.identificationControl.SchemaTypeName = null;
            this.identificationControl.Size = new System.Drawing.Size(439, 172);
            this.identificationControl.TabIndex = 6;
            this.identificationControl.TargetNamespace = null;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.HelpMessageKey = "ItemDescription.name";
            this.label1.Location = new System.Drawing.Point(4, 12);
            this.label1.Name = "label1";
            this.label1.RequiredField = false;
            this.label1.RequiredFieldMarkerFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name";
            // 
            // ItemDescriptionControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.Controls.Add(this.edtVersion);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.edtDescription);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.identificationControl);
            this.Controls.Add(this.edtName);
            this.Controls.Add(this.label1);
            this.Name = "ItemDescriptionControl";
            this.Size = new System.Drawing.Size(453, 296);
            this.Load += new System.EventHandler(this.ItemDescriptionControl_Load);
            this.Validating += new System.ComponentModel.CancelEventHandler(this.ItemDescriptionControl_Validating);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected ATMLCommonLibrary.controls.HelpLabel label1;
        protected ATMLCommonLibrary.controls.awb.AWBTextBox edtName;
        protected ATMLCommonLibrary.controls.IdentificationControl identificationControl;
        protected ATMLCommonLibrary.controls.awb.AWBTextBox edtDescription;
        protected ATMLCommonLibrary.controls.HelpLabel label2;
        protected ATMLCommonLibrary.controls.awb.AWBTextBox edtVersion;
        protected ATMLCommonLibrary.controls.HelpLabel label3;
        protected System.Windows.Forms.ErrorProvider errorProvider;
    }
}
