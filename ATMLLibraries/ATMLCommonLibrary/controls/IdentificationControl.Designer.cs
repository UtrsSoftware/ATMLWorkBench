/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
*
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

using System.Windows.Forms;
using ATMLCommonLibrary.controls.manufacturer;

namespace ATMLCommonLibrary.controls
{
    partial class IdentificationControl
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
            this.label1 = new ATMLCommonLibrary.controls.HelpLabel(this.components);
            this.label4 = new ATMLCommonLibrary.controls.HelpLabel(this.components);
            this.edtIdModelName = new ATMLCommonLibrary.controls.awb.AWBTextBox(this.components);
            this.label5 = new ATMLCommonLibrary.controls.HelpLabel(this.components);
            this.edtDesignator = new ATMLCommonLibrary.controls.awb.AWBTextBox(this.components);
            this.IdentificationTabControl = new ATMLCommonLibrary.controls.awb.AWBTabControl();
            this.tabIdentificationNumbers = new System.Windows.Forms.TabPage();
            this.indentificationNumbersListControl = new ATMLCommonLibrary.controls.IndentificationNumbersListControl();
            this.manufacturerPage = new System.Windows.Forms.TabPage();
            this.manufacturerListControl = new ATMLCommonLibrary.controls.manufacturer.ManufacturerListControl();
            this.edtIdVersion = new ATMLCommonLibrary.controls.awb.AWBTextBox(this.components);
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.requiredModelNameValidator = new ATMLCommonLibrary.controls.validators.RequiredFieldValidator();
            this.IdentificationTabControl.SuspendLayout();
            this.tabIdentificationNumbers.SuspendLayout();
            this.manufacturerPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.HelpMessageKey = "Identification.designator";
            this.label1.Location = new System.Drawing.Point(300, 8);
            this.label1.Name = "label1";
            this.label1.RequiredField = false;
            this.label1.RequiredFieldMarkerFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Designator";
            // 
            // label4
            // 
            this.label4.HelpMessageKey = "Identification.ModelName";
            this.label4.Location = new System.Drawing.Point(115, 8);
            this.label4.Name = "label4";
            this.label4.RequiredField = true;
            this.label4.RequiredFieldMarkerFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Size = new System.Drawing.Size(72, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Model Name";
            // 
            // edtIdModelName
            // 
            this.edtIdModelName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtIdModelName.AttributeName = null;
            this.edtIdModelName.DataLookupKey = null;
            this.edtIdModelName.Location = new System.Drawing.Point(192, 5);
            this.edtIdModelName.Name = "edtIdModelName";
            this.edtIdModelName.Size = new System.Drawing.Size(87, 20);
            this.edtIdModelName.TabIndex = 3;
            this.edtIdModelName.Value = null;
            this.edtIdModelName.ValueType = ATMLCommonLibrary.controls.awb.AWBTextBox.eValueType.xsString;
            this.edtIdModelName.TextChanged += new System.EventHandler(this.edtIdModelName_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.HelpMessageKey = "Identification.version";
            this.label5.Location = new System.Drawing.Point(6, 8);
            this.label5.Name = "label5";
            this.label5.RequiredField = false;
            this.label5.RequiredFieldMarkerFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Size = new System.Drawing.Size(42, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Version";
            // 
            // edtDesignator
            // 
            this.edtDesignator.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.edtDesignator.AttributeName = null;
            this.edtDesignator.DataLookupKey = null;
            this.edtDesignator.Location = new System.Drawing.Point(364, 5);
            this.edtDesignator.Name = "edtDesignator";
            this.edtDesignator.Size = new System.Drawing.Size(67, 20);
            this.edtDesignator.TabIndex = 5;
            this.edtDesignator.Value = null;
            this.edtDesignator.ValueType = ATMLCommonLibrary.controls.awb.AWBTextBox.eValueType.xsString;
            // 
            // IdentificationTabControl
            // 
            this.IdentificationTabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.IdentificationTabControl.Controls.Add(this.tabIdentificationNumbers);
            this.IdentificationTabControl.Controls.Add(this.manufacturerPage);
            this.IdentificationTabControl.ItemSize = new System.Drawing.Size(140, 21);
            this.IdentificationTabControl.Location = new System.Drawing.Point(3, 34);
            this.IdentificationTabControl.MainBackColor = System.Drawing.SystemColors.Control;
            this.IdentificationTabControl.Name = "IdentificationTabControl";
            this.IdentificationTabControl.SelectedIndex = 0;
            this.IdentificationTabControl.Size = new System.Drawing.Size(435, 183);
            this.IdentificationTabControl.SizeMode = System.Windows.Forms.TabSizeMode.FillToRight;
            this.IdentificationTabControl.TabIndex = 6;
            // 
            // tabIdentificationNumbers
            // 
            this.tabIdentificationNumbers.BackColor = System.Drawing.SystemColors.Control;
            this.tabIdentificationNumbers.Controls.Add(this.indentificationNumbersListControl);
            this.tabIdentificationNumbers.Location = new System.Drawing.Point(4, 25);
            this.tabIdentificationNumbers.Name = "tabIdentificationNumbers";
            this.tabIdentificationNumbers.Padding = new System.Windows.Forms.Padding(3);
            this.tabIdentificationNumbers.Size = new System.Drawing.Size(427, 154);
            this.tabIdentificationNumbers.TabIndex = 0;
            this.tabIdentificationNumbers.Text = "Identification Numbers";
            // 
            // indentificationNumbersListControl
            // 
            this.indentificationNumbersListControl.AllowRowResequencing = false;
            this.indentificationNumbersListControl.BackColor = System.Drawing.Color.Transparent;
            this.indentificationNumbersListControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.indentificationNumbersListControl.FormTitle = null;
            this.indentificationNumbersListControl.HasErrors = false;
            this.indentificationNumbersListControl.HelpKeyWord = null;
            this.indentificationNumbersListControl.LastError = null;
            this.indentificationNumbersListControl.ListName = null;
            this.indentificationNumbersListControl.Location = new System.Drawing.Point(3, 3);
            this.indentificationNumbersListControl.Margin = new System.Windows.Forms.Padding(0);
            this.indentificationNumbersListControl.Name = "indentificationNumbersListControl";
            this.indentificationNumbersListControl.SchemaTypeName = null;
            this.indentificationNumbersListControl.ShowFind = false;
            this.indentificationNumbersListControl.Size = new System.Drawing.Size(421, 148);
            this.indentificationNumbersListControl.TabIndex = 0;
            this.indentificationNumbersListControl.TargetNamespace = null;
            this.indentificationNumbersListControl.TooltipTextAddButton = "Press to add a new ";
            this.indentificationNumbersListControl.TooltipTextDeleteButton = "Press to delete the selected ";
            this.indentificationNumbersListControl.TooltipTextEditButton = "Press to edit the selected ";
            this.indentificationNumbersListControl.Load += new System.EventHandler(this.indentificationNumbersListControl_Load);
            // 
            // manufacturerPage
            // 
            this.manufacturerPage.BackColor = System.Drawing.SystemColors.Control;
            this.manufacturerPage.Controls.Add(this.manufacturerListControl);
            this.manufacturerPage.Location = new System.Drawing.Point(4, 25);
            this.manufacturerPage.Name = "manufacturerPage";
            this.manufacturerPage.Padding = new System.Windows.Forms.Padding(3);
            this.manufacturerPage.Size = new System.Drawing.Size(427, 154);
            this.manufacturerPage.TabIndex = 1;
            this.manufacturerPage.Text = "Manufacturers";
            // 
            // manufacturerListControl
            // 
            this.manufacturerListControl.AllowRowResequencing = false;
            this.manufacturerListControl.BackColor = System.Drawing.Color.SteelBlue;
            this.manufacturerListControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.manufacturerListControl.FormTitle = null;
            this.manufacturerListControl.HasErrors = false;
            this.manufacturerListControl.HelpKeyWord = null;
            this.manufacturerListControl.LastError = null;
            this.manufacturerListControl.ListName = null;
            this.manufacturerListControl.Location = new System.Drawing.Point(3, 3);
            this.manufacturerListControl.Margin = new System.Windows.Forms.Padding(0);
            this.manufacturerListControl.Name = "manufacturerListControl";
            this.manufacturerListControl.SchemaTypeName = null;
            this.manufacturerListControl.ShowFind = false;
            this.manufacturerListControl.Size = new System.Drawing.Size(421, 148);
            this.manufacturerListControl.TabIndex = 0;
            this.manufacturerListControl.TargetNamespace = null;
            this.manufacturerListControl.TooltipTextAddButton = "Press to add a new ";
            this.manufacturerListControl.TooltipTextDeleteButton = "Press to delete the selected ";
            this.manufacturerListControl.TooltipTextEditButton = "Press to edit the selected ";
            this.manufacturerListControl.Load += new System.EventHandler(this.manufacturerListControl_Load);
            // 
            // edtIdVersion
            // 
            this.edtIdVersion.AttributeName = null;
            this.edtIdVersion.BackColor = System.Drawing.Color.PaleTurquoise;
            this.edtIdVersion.DataLookupKey = null;
            this.edtIdVersion.Location = new System.Drawing.Point(52, 5);
            this.edtIdVersion.Name = "edtIdVersion";
            this.edtIdVersion.Size = new System.Drawing.Size(48, 20);
            this.edtIdVersion.TabIndex = 1;
            this.edtIdVersion.Value = null;
            this.edtIdVersion.ValueType = ATMLCommonLibrary.controls.awb.AWBTextBox.eValueType.xsString;
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // requiredModelNameValidator
            // 
            this.requiredModelNameValidator.ControlToValidate = this.edtIdModelName;
            this.requiredModelNameValidator.ErrorMessage = "The Model Name is required";
            this.requiredModelNameValidator.ErrorProvider = this.errorProvider;
            this.requiredModelNameValidator.Icon = null;
            this.requiredModelNameValidator.InitialValue = null;
            this.requiredModelNameValidator.IsEnabled = true;
            // 
            // IdentificationControl
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.edtIdModelName);
            this.Controls.Add(this.edtDesignator);
            this.Controls.Add(this.IdentificationTabControl);
            this.Controls.Add(this.edtIdVersion);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label1);
            this.Name = "IdentificationControl";
            this.Size = new System.Drawing.Size(443, 223);
            this.IdentificationTabControl.ResumeLayout(false);
            this.tabIdentificationNumbers.ResumeLayout(false);
            this.manufacturerPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ATMLCommonLibrary.controls.HelpLabel label1;
        private ATMLCommonLibrary.controls.HelpLabel label4;
        private ATMLCommonLibrary.controls.awb.AWBTextBox edtIdModelName;
        private ATMLCommonLibrary.controls.HelpLabel label5;
        private ManufacturerListControl manufacturerListControl;
        private ATMLCommonLibrary.controls.awb.AWBTextBox edtDesignator;
        private ATMLCommonLibrary.controls.awb.AWBTabControl IdentificationTabControl;
        private System.Windows.Forms.TabPage tabIdentificationNumbers;
        private IndentificationNumbersListControl indentificationNumbersListControl;
        private System.Windows.Forms.TabPage manufacturerPage;
        private ATMLCommonLibrary.controls.awb.AWBTextBox edtIdVersion;
        private validators.RequiredFieldValidator requiredModelNameValidator;
        protected System.Windows.Forms.ErrorProvider errorProvider;

    }
}
