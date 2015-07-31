/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
*
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

using ATMLCommonLibrary.controls.awb;

namespace ATMLCommonLibrary.controls.document
{
    partial class DocumentControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DocumentControl));
            this.rbText = new System.Windows.Forms.RadioButton();
            this.rbURL = new System.Windows.Forms.RadioButton();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.btnAddGUID = new ATMLCommonLibrary.controls.awb.AWBButton();
            this.lblItem = new ATMLCommonLibrary.controls.HelpLabel(this.components);
            this.edtVersion = new ATMLCommonLibrary.controls.awb.AWBTextBox(this.components);
            this.lblVersion = new ATMLCommonLibrary.controls.HelpLabel(this.components);
            this.edtControlNumber = new ATMLCommonLibrary.controls.awb.AWBTextBox(this.components);
            this.lblControlNumber = new ATMLCommonLibrary.controls.HelpLabel(this.components);
            this.edtUUID = new ATMLCommonLibrary.controls.awb.AWBTextBox(this.components);
            this.lblUUID = new ATMLCommonLibrary.controls.HelpLabel(this.components);
            this.edtDocumentName = new ATMLCommonLibrary.controls.awb.AWBTextBox(this.components);
            this.lblName = new ATMLCommonLibrary.controls.HelpLabel(this.components);
            this.requiredNameValidator = new ATMLCommonLibrary.controls.validators.RequiredFieldValidator();
            this.requiredUUIDValidator = new ATMLCommonLibrary.controls.validators.RequiredFieldValidator();
            this.requiredTypeValidator = new ATMLCommonLibrary.controls.validators.RequiredFieldValidator();
            this.edtDescription = new ATMLCommonLibrary.controls.awb.AWBTextBox(this.components);
            this.helpLabel1 = new ATMLCommonLibrary.controls.HelpLabel(this.components);
            this.btnCollapseAll = new System.Windows.Forms.Button();
            this.btnExpandAll = new System.Windows.Forms.Button();
            this.edtItem = new ATMLCommonLibrary.controls.awb.AWBEditor();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtItem)).BeginInit();
            this.SuspendLayout();
            // 
            // rbText
            // 
            this.rbText.AutoSize = true;
            this.rbText.Location = new System.Drawing.Point(68, 138);
            this.rbText.Name = "rbText";
            this.rbText.Size = new System.Drawing.Size(46, 17);
            this.rbText.TabIndex = 11;
            this.rbText.TabStop = true;
            this.rbText.Text = "Text";
            this.rbText.UseVisualStyleBackColor = true;
            this.rbText.CheckedChanged += new System.EventHandler(this.rbText_CheckedChanged);
            // 
            // rbURL
            // 
            this.rbURL.AutoSize = true;
            this.rbURL.Location = new System.Drawing.Point(120, 138);
            this.rbURL.Name = "rbURL";
            this.rbURL.Size = new System.Drawing.Size(47, 17);
            this.rbURL.TabIndex = 12;
            this.rbURL.TabStop = true;
            this.rbURL.Text = "URL";
            this.rbURL.UseVisualStyleBackColor = true;
            this.rbURL.CheckedChanged += new System.EventHandler(this.rbURL_CheckedChanged);
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // btnAddGUID
            // 
            this.btnAddGUID.Active = true;
            this.btnAddGUID.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddGUID.BorderColor = System.Drawing.Color.Gray;
            this.btnAddGUID.ButtonStyle = ATMLCommonLibrary.controls.awb.AWBButton.ButtonStyles.Rectangle;
            this.btnAddGUID.FlatAppearance.BorderSize = 0;
            this.btnAddGUID.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddGUID.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold);
            this.btnAddGUID.GradientStyle = ATMLCommonLibrary.controls.awb.AWBButton.GradientStyles.Vertical;
            this.btnAddGUID.HoverBorderColor = System.Drawing.Color.LightSteelBlue;
            this.btnAddGUID.HoverColorA = System.Drawing.Color.SteelBlue;
            this.btnAddGUID.HoverColorB = System.Drawing.Color.SteelBlue;
            this.btnAddGUID.HoverTextColor = System.Drawing.Color.White;
            this.btnAddGUID.Image = ((System.Drawing.Image)(resources.GetObject("btnAddGUID.Image")));
            this.btnAddGUID.Location = new System.Drawing.Point(366, 27);
            this.btnAddGUID.Name = "btnAddGUID";
            this.btnAddGUID.NormalBorderColor = System.Drawing.Color.SteelBlue;
            this.btnAddGUID.NormalColorA = System.Drawing.Color.LightSteelBlue;
            this.btnAddGUID.NormalColorB = System.Drawing.Color.LightSteelBlue;
            this.btnAddGUID.Size = new System.Drawing.Size(24, 22);
            this.btnAddGUID.SmoothingQuality = ATMLCommonLibrary.controls.awb.AWBButton.SmoothingQualities.AntiAlias;
            this.btnAddGUID.TabIndex = 4;
            this.btnAddGUID.ToolTipText = "Press to generate a new UUID";
            this.btnAddGUID.UseVisualStyleBackColor = true;
            this.btnAddGUID.Click += new System.EventHandler(this.btnAddGUID_Click);
            // 
            // lblItem
            // 
            this.lblItem.HelpMessageKey = "Document.text";
            this.lblItem.Location = new System.Drawing.Point(4, 153);
            this.lblItem.Name = "lblItem";
            this.lblItem.RequiredField = true;
            this.lblItem.RequiredFieldMarkerFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblItem.Size = new System.Drawing.Size(35, 13);
            this.lblItem.TabIndex = 13;
            this.lblItem.Text = "Text";
            // 
            // edtVersion
            // 
            this.edtVersion.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtVersion.AttributeName = null;
            this.edtVersion.DataLookupKey = null;
            this.edtVersion.Location = new System.Drawing.Point(65, 72);
            this.edtVersion.Name = "edtVersion";
            this.edtVersion.Size = new System.Drawing.Size(325, 20);
            this.edtVersion.TabIndex = 8;
            this.edtVersion.Value = null;
            this.edtVersion.ValueType = ATMLCommonLibrary.controls.awb.AWBTextBox.eValueType.xsString;
            // 
            // lblVersion
            // 
            this.lblVersion.AutoSize = true;
            this.lblVersion.HelpMessageKey = "Document.version";
            this.lblVersion.Location = new System.Drawing.Point(4, 72);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.RequiredField = false;
            this.lblVersion.RequiredFieldMarkerFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVersion.Size = new System.Drawing.Size(42, 13);
            this.lblVersion.TabIndex = 7;
            this.lblVersion.Text = "Version";
            // 
            // edtControlNumber
            // 
            this.edtControlNumber.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtControlNumber.AttributeName = null;
            this.edtControlNumber.DataLookupKey = null;
            this.edtControlNumber.Location = new System.Drawing.Point(65, 50);
            this.edtControlNumber.Name = "edtControlNumber";
            this.edtControlNumber.Size = new System.Drawing.Size(325, 20);
            this.edtControlNumber.TabIndex = 6;
            this.edtControlNumber.Value = null;
            this.edtControlNumber.ValueType = ATMLCommonLibrary.controls.awb.AWBTextBox.eValueType.xsString;
            // 
            // lblControlNumber
            // 
            this.lblControlNumber.AutoSize = true;
            this.lblControlNumber.HelpMessageKey = "Document.controlNumber";
            this.lblControlNumber.Location = new System.Drawing.Point(4, 50);
            this.lblControlNumber.Name = "lblControlNumber";
            this.lblControlNumber.RequiredField = false;
            this.lblControlNumber.RequiredFieldMarkerFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblControlNumber.Size = new System.Drawing.Size(57, 13);
            this.lblControlNumber.TabIndex = 5;
            this.lblControlNumber.Text = "Control No";
            // 
            // edtUUID
            // 
            this.edtUUID.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtUUID.AttributeName = null;
            this.edtUUID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.edtUUID.DataLookupKey = null;
            this.edtUUID.Location = new System.Drawing.Point(65, 28);
            this.edtUUID.Name = "edtUUID";
            this.edtUUID.Size = new System.Drawing.Size(295, 20);
            this.edtUUID.TabIndex = 3;
            this.edtUUID.Value = null;
            this.edtUUID.ValueType = ATMLCommonLibrary.controls.awb.AWBTextBox.eValueType.xsString;
            // 
            // lblUUID
            // 
            this.lblUUID.HelpMessageKey = "Document.uuid";
            this.lblUUID.Location = new System.Drawing.Point(4, 28);
            this.lblUUID.Name = "lblUUID";
            this.lblUUID.RequiredField = true;
            this.lblUUID.RequiredFieldMarkerFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUUID.Size = new System.Drawing.Size(42, 13);
            this.lblUUID.TabIndex = 2;
            this.lblUUID.Text = "UUID";
            // 
            // edtDocumentName
            // 
            this.edtDocumentName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtDocumentName.AttributeName = null;
            this.edtDocumentName.DataLookupKey = null;
            this.edtDocumentName.Location = new System.Drawing.Point(65, 6);
            this.edtDocumentName.Name = "edtDocumentName";
            this.edtDocumentName.Size = new System.Drawing.Size(325, 20);
            this.edtDocumentName.TabIndex = 1;
            this.edtDocumentName.Value = null;
            this.edtDocumentName.ValueType = ATMLCommonLibrary.controls.awb.AWBTextBox.eValueType.xsString;
            this.edtDocumentName.TextChanged += new System.EventHandler(this.edtDocumentName_TextChanged);
            // 
            // lblName
            // 
            this.lblName.HelpMessageKey = "Document.name";
            this.lblName.Location = new System.Drawing.Point(4, 6);
            this.lblName.Name = "lblName";
            this.lblName.RequiredField = true;
            this.lblName.RequiredFieldMarkerFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.Size = new System.Drawing.Size(42, 13);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "Name";
            // 
            // requiredNameValidator
            // 
            this.requiredNameValidator.ControlToValidate = this.edtDocumentName;
            this.requiredNameValidator.ErrorMessage = "The document name is required";
            this.requiredNameValidator.ErrorProvider = this.errorProvider;
            this.requiredNameValidator.Icon = null;
            this.requiredNameValidator.InitialValue = null;
            this.requiredNameValidator.IsEnabled = true;
            // 
            // requiredUUIDValidator
            // 
            this.requiredUUIDValidator.ControlToValidate = this.edtUUID;
            this.requiredUUIDValidator.ErrorMessage = "The UUID is required";
            this.requiredUUIDValidator.ErrorProvider = this.errorProvider;
            this.requiredUUIDValidator.Icon = null;
            this.requiredUUIDValidator.InitialValue = null;
            this.requiredUUIDValidator.IsEnabled = true;
            // 
            // requiredTypeValidator
            // 
            this.requiredTypeValidator.ControlToValidate = this.edtItem;
            this.requiredTypeValidator.ErrorMessage = "The Text or URL is required";
            this.requiredTypeValidator.ErrorProvider = this.errorProvider;
            this.requiredTypeValidator.Icon = null;
            this.requiredTypeValidator.InitialValue = null;
            this.requiredTypeValidator.IsEnabled = true;
            // 
            // edtDescription
            // 
            this.edtDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtDescription.AttributeName = null;
            this.edtDescription.DataLookupKey = null;
            this.edtDescription.Location = new System.Drawing.Point(65, 98);
            this.edtDescription.Multiline = true;
            this.edtDescription.Name = "edtDescription";
            this.edtDescription.Size = new System.Drawing.Size(325, 37);
            this.edtDescription.TabIndex = 10;
            this.edtDescription.Value = null;
            this.edtDescription.ValueType = ATMLCommonLibrary.controls.awb.AWBTextBox.eValueType.xsString;
            // 
            // helpLabel1
            // 
            this.helpLabel1.AutoSize = true;
            this.helpLabel1.HelpMessageKey = "Document.description";
            this.helpLabel1.Location = new System.Drawing.Point(4, 98);
            this.helpLabel1.Name = "helpLabel1";
            this.helpLabel1.RequiredField = false;
            this.helpLabel1.RequiredFieldMarkerFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.helpLabel1.Size = new System.Drawing.Size(60, 13);
            this.helpLabel1.TabIndex = 9;
            this.helpLabel1.Text = "Description";
            // 
            // btnCollapseAll
            // 
            this.btnCollapseAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCollapseAll.FlatAppearance.BorderSize = 0;
            this.btnCollapseAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCollapseAll.Location = new System.Drawing.Point(396, 158);
            this.btnCollapseAll.Name = "btnCollapseAll";
            this.btnCollapseAll.Size = new System.Drawing.Size(16, 18);
            this.btnCollapseAll.TabIndex = 15;
            this.btnCollapseAll.Text = "-";
            this.btnCollapseAll.UseVisualStyleBackColor = true;
            this.btnCollapseAll.Click += new System.EventHandler(this.btnCollapseAll_Click);
            // 
            // btnExpandAll
            // 
            this.btnExpandAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExpandAll.FlatAppearance.BorderSize = 0;
            this.btnExpandAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExpandAll.Location = new System.Drawing.Point(396, 179);
            this.btnExpandAll.Name = "btnExpandAll";
            this.btnExpandAll.Size = new System.Drawing.Size(16, 18);
            this.btnExpandAll.TabIndex = 15;
            this.btnExpandAll.Text = "+";
            this.btnExpandAll.UseVisualStyleBackColor = true;
            this.btnExpandAll.Click += new System.EventHandler(this.btnExpandAll_Click);
            // 
            // edtItem
            // 
            this.edtItem.AllowDrop = true;
            this.edtItem.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtItem.ConfigurationManager.Language = "xml";
            this.edtItem.Folding.Flags = ScintillaNET.FoldFlag.Box;
            this.edtItem.Indentation.ShowGuides = true;
            this.edtItem.Indentation.SmartIndentType = ScintillaNET.SmartIndent.CPP;
            this.edtItem.Indentation.TabWidth = 2;
            this.edtItem.IsBraceMatching = true;
            this.edtItem.Lexing.Lexer = ScintillaNET.Lexer.Xml;
            this.edtItem.Lexing.LexerName = "xml";
            this.edtItem.Lexing.LineCommentPrefix = "";
            this.edtItem.Lexing.StreamCommentPrefix = "";
            this.edtItem.Lexing.StreamCommentSufix = "";
            this.edtItem.LineWrapping.IndentMode = ScintillaNET.LineWrappingIndentMode.Indent;
            this.edtItem.LineWrapping.Mode = ScintillaNET.LineWrappingMode.Word;
            this.edtItem.Location = new System.Drawing.Point(65, 158);
            this.edtItem.Margins.FoldMarginColor = System.Drawing.Color.LightBlue;
            this.edtItem.Margins.Margin0.Width = 40;
            this.edtItem.Margins.Margin1.IsClickable = true;
            this.edtItem.Margins.Margin2.Width = 20;
            this.edtItem.Name = "edtItem";
            this.edtItem.Size = new System.Drawing.Size(325, 94);
            this.edtItem.Styles.BraceBad.FontName = "Verdana\0\0\0\0\0\0\0\0\0\0\0\0\0";
            this.edtItem.Styles.BraceLight.FontName = "Verdana\0\0\0\0\0\0\0\0\0\0\0\0\0";
            this.edtItem.Styles.CallTip.FontName = "Segoe UI\0\0\0\0\0\0\0\0\0\0\0\0";
            this.edtItem.Styles.ControlChar.FontName = "Verdana\0\0\0\0\0\0\0\0\0\0\0\0\0";
            this.edtItem.Styles.Default.FontName = "Verdana\0\0\0\0\0\0\0\0\0\0\0\0\0";
            this.edtItem.Styles.IndentGuide.FontName = "Verdana\0\0\0\0\0\0\0\0\0\0\0\0\0";
            this.edtItem.Styles.LastPredefined.FontName = "Verdana\0\0\0\0\0\0\0\0\0\0\0\0\0";
            this.edtItem.Styles.LineNumber.FontName = "Verdana\0\0\0\0\0\0\0\0\0\0\0\0\0";
            this.edtItem.Styles.Max.FontName = "Verdana\0\0\0\0\0\0\0\0\0\0\0\0\0";
            this.edtItem.TabIndex = 14;
            this.edtItem.TextChanged += new System.EventHandler(this.edtItem_TextChanged);
            // 
            // DocumentControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.btnExpandAll);
            this.Controls.Add(this.btnCollapseAll);
            this.Controls.Add(this.edtDescription);
            this.Controls.Add(this.helpLabel1);
            this.Controls.Add(this.btnAddGUID);
            this.Controls.Add(this.rbURL);
            this.Controls.Add(this.rbText);
            this.Controls.Add(this.edtItem);
            this.Controls.Add(this.lblItem);
            this.Controls.Add(this.edtVersion);
            this.Controls.Add(this.lblVersion);
            this.Controls.Add(this.edtControlNumber);
            this.Controls.Add(this.lblControlNumber);
            this.Controls.Add(this.edtUUID);
            this.Controls.Add(this.lblUUID);
            this.Controls.Add(this.edtDocumentName);
            this.Controls.Add(this.lblName);
            this.Name = "DocumentControl";
            this.Size = new System.Drawing.Size(422, 258);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtItem)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected ATMLCommonLibrary.controls.HelpLabel lblName;
        protected ATMLCommonLibrary.controls.awb.AWBTextBox edtDocumentName;
        protected ATMLCommonLibrary.controls.awb.AWBTextBox edtUUID;
        protected ATMLCommonLibrary.controls.HelpLabel lblUUID;
        protected ATMLCommonLibrary.controls.awb.AWBTextBox edtControlNumber;
        protected ATMLCommonLibrary.controls.HelpLabel lblControlNumber;
        protected ATMLCommonLibrary.controls.awb.AWBTextBox edtVersion;
        protected ATMLCommonLibrary.controls.HelpLabel lblVersion;
        //protected ATMLCommonLibrary.controls.awb.AWBTextBox edtItem;
        protected ATMLCommonLibrary.controls.awb.AWBEditor edtItem;
        protected ATMLCommonLibrary.controls.HelpLabel lblItem;
        protected System.Windows.Forms.RadioButton rbText;
        protected System.Windows.Forms.RadioButton rbURL;
        protected ATMLCommonLibrary.controls.awb.AWBButton btnAddGUID;
        protected System.Windows.Forms.ErrorProvider errorProvider;
        private validators.RequiredFieldValidator requiredNameValidator;
        private validators.RequiredFieldValidator requiredUUIDValidator;
        private validators.RequiredFieldValidator requiredTypeValidator;
        protected AWBTextBox edtDescription;
        protected HelpLabel helpLabel1;
        private System.Windows.Forms.Button btnCollapseAll;
        private System.Windows.Forms.Button btnExpandAll;
    }
}
