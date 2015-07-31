/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
*
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/
namespace ATMLCommonLibrary.controls.hardware
{
    partial class LegalDocumentControl
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
            this.lblType = new ATMLCommonLibrary.controls.HelpLabel(this.components);
            this.cmbLegalDocumentType = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.edtItem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // lblName
            // 
            this.lblName.Location = new System.Drawing.Point(6, 36);
            // 
            // edtDocumentName
            // 
            this.edtDocumentName.Location = new System.Drawing.Point(65, 36);
            this.edtDocumentName.Size = new System.Drawing.Size(339, 20);
            // 
            // edtUUID
            // 
            this.edtUUID.Location = new System.Drawing.Point(65, 60);
            this.edtUUID.Size = new System.Drawing.Size(309, 20);
            // 
            // lblUUID
            // 
            this.lblUUID.Location = new System.Drawing.Point(6, 60);
            // 
            // edtControlNumber
            // 
            this.edtControlNumber.Location = new System.Drawing.Point(65, 84);
            this.edtControlNumber.Size = new System.Drawing.Size(339, 20);
            // 
            // lblControlNumber
            // 
            this.lblControlNumber.Location = new System.Drawing.Point(6, 84);
            // 
            // edtVersion
            // 
            this.edtVersion.Location = new System.Drawing.Point(65, 108);
            this.edtVersion.Size = new System.Drawing.Size(339, 20);
            // 
            // lblVersion
            // 
            this.lblVersion.Location = new System.Drawing.Point(6, 108);
            // 
            // edtItem
            // 
            this.edtItem.ConfigurationManager.Language = "xml";
            this.edtItem.Folding.Flags = ScintillaNET.FoldFlag.Box;
            this.edtItem.Indentation.ShowGuides = true;
            this.edtItem.Indentation.SmartIndentType = ScintillaNET.SmartIndent.CPP;
            this.edtItem.Indentation.TabWidth = 2;
            this.edtItem.Lexing.Lexer = ScintillaNET.Lexer.Hypertext;
            this.edtItem.Lexing.LexerName = "hypertext";
            this.edtItem.Lexing.LineCommentPrefix = "//";
            this.edtItem.Lexing.StreamCommentPrefix = "<!-- ";
            this.edtItem.Lexing.StreamCommentSufix = " -->";
            this.edtItem.LineWrapping.IndentMode = ScintillaNET.LineWrappingIndentMode.Indent;
            this.edtItem.LineWrapping.Mode = ScintillaNET.LineWrappingMode.Word;
            this.edtItem.Location = new System.Drawing.Point(65, 195);
            this.edtItem.Margins.FoldMarginColor = System.Drawing.Color.LightBlue;
            this.edtItem.Margins.Margin0.Width = 40;
            this.edtItem.Margins.Margin1.IsClickable = true;
            this.edtItem.Margins.Margin2.Width = 20;
            this.edtItem.Size = new System.Drawing.Size(339, 175);
            this.edtItem.Styles.BraceBad.FontName = "Courier New";
            this.edtItem.Styles.BraceBad.Size = 10F;
            this.edtItem.Styles.BraceLight.Bold = true;
            this.edtItem.Styles.BraceLight.FontName = "Courier New";
            this.edtItem.Styles.BraceLight.ForeColor = System.Drawing.Color.Red;
            this.edtItem.Styles.BraceLight.Size = 10F;
            this.edtItem.Styles.ControlChar.FontName = "Courier New";
            this.edtItem.Styles.ControlChar.Size = 10F;
            this.edtItem.Styles.Default.BackColor = System.Drawing.SystemColors.Window;
            this.edtItem.Styles.Default.FontName = "Courier New";
            this.edtItem.Styles.Default.Size = 10F;
            this.edtItem.Styles.IndentGuide.FontName = "Courier New";
            this.edtItem.Styles.IndentGuide.Size = 10F;
            this.edtItem.Styles.LastPredefined.FontName = "Courier New";
            this.edtItem.Styles.LastPredefined.Size = 10F;
            this.edtItem.Styles.LineNumber.FontName = "Courier New";
            this.edtItem.Styles.LineNumber.Size = 10F;
            this.edtItem.Styles.Max.FontName = "Courier New";
            this.edtItem.Styles.Max.Size = 10F;
            // 
            // lblItem
            // 
            this.lblItem.Location = new System.Drawing.Point(6, 195);
            // 
            // rbText
            // 
            this.rbText.Location = new System.Drawing.Point(68, 176);
            // 
            // rbURL
            // 
            this.rbURL.Location = new System.Drawing.Point(120, 176);
            // 
            // btnAddGUID
            // 
            this.btnAddGUID.FlatAppearance.BorderSize = 0;
            this.btnAddGUID.Location = new System.Drawing.Point(379, 59);
            // 
            // edtDescription
            // 
            this.edtDescription.Location = new System.Drawing.Point(65, 133);
            this.edtDescription.Size = new System.Drawing.Size(339, 37);
            // 
            // helpLabel1
            // 
            this.helpLabel1.Location = new System.Drawing.Point(4, 133);
            // 
            // lblType
            // 
            this.lblType.AutoSize = true;
            this.lblType.HelpMessageKey = "LegalDocument.Type";
            this.lblType.Location = new System.Drawing.Point(6, 13);
            this.lblType.Name = "lblType";
            this.lblType.RequiredField = false;
            this.lblType.RequiredFieldMarkerFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblType.Size = new System.Drawing.Size(31, 13);
            this.lblType.TabIndex = 13;
            this.lblType.Text = "Type";
            // 
            // cmbLegalDocumentType
            // 
            this.cmbLegalDocumentType.FormattingEnabled = true;
            this.cmbLegalDocumentType.Location = new System.Drawing.Point(65, 11);
            this.cmbLegalDocumentType.Name = "cmbLegalDocumentType";
            this.cmbLegalDocumentType.Size = new System.Drawing.Size(151, 21);
            this.cmbLegalDocumentType.TabIndex = 14;
            // 
            // LegalDocumentControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cmbLegalDocumentType);
            this.Controls.Add(this.lblType);
            this.Name = "LegalDocumentControl";
            this.Size = new System.Drawing.Size(427, 390);
            this.Controls.SetChildIndex(this.helpLabel1, 0);
            this.Controls.SetChildIndex(this.edtDescription, 0);
            this.Controls.SetChildIndex(this.lblName, 0);
            this.Controls.SetChildIndex(this.edtDocumentName, 0);
            this.Controls.SetChildIndex(this.lblUUID, 0);
            this.Controls.SetChildIndex(this.edtUUID, 0);
            this.Controls.SetChildIndex(this.lblControlNumber, 0);
            this.Controls.SetChildIndex(this.edtControlNumber, 0);
            this.Controls.SetChildIndex(this.lblVersion, 0);
            this.Controls.SetChildIndex(this.edtVersion, 0);
            this.Controls.SetChildIndex(this.lblItem, 0);
            this.Controls.SetChildIndex(this.edtItem, 0);
            this.Controls.SetChildIndex(this.rbText, 0);
            this.Controls.SetChildIndex(this.rbURL, 0);
            this.Controls.SetChildIndex(this.btnAddGUID, 0);
            this.Controls.SetChildIndex(this.lblType, 0);
            this.Controls.SetChildIndex(this.cmbLegalDocumentType, 0);
            ((System.ComponentModel.ISupportInitialize)(this.edtItem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private HelpLabel lblType;
        private System.Windows.Forms.ComboBox cmbLegalDocumentType;


    }
}
