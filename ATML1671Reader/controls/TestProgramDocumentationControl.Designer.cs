/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
* 
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

namespace ATML1671Reader.controls
{
    partial class TestProgramDocumentationControl
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
            this.label1 = new System.Windows.Forms.Label();
            this.edtDocumentNumber = new ATMLCommonLibrary.controls.awb.AWBTextBox(this.components);
            this.edtLocation = new ATMLCommonLibrary.controls.awb.AWBTextBox(this.components);
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.edtItem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // lblName
            // 
            this.lblName.Location = new System.Drawing.Point(4, 54);
            this.lblName.TabIndex = 4;
            // 
            // edtDocumentName
            // 
            this.edtDocumentName.Location = new System.Drawing.Point(65, 50);
            this.edtDocumentName.TabIndex = 5;
            // 
            // edtUUID
            // 
            this.edtUUID.Location = new System.Drawing.Point(65, 73);
            this.edtUUID.TabIndex = 7;
            // 
            // lblUUID
            // 
            this.lblUUID.Location = new System.Drawing.Point(4, 76);
            this.lblUUID.TabIndex = 6;
            // 
            // edtControlNumber
            // 
            this.edtControlNumber.Location = new System.Drawing.Point(65, 96);
            this.edtControlNumber.TabIndex = 10;
            // 
            // lblControlNumber
            // 
            this.lblControlNumber.Location = new System.Drawing.Point(4, 98);
            this.lblControlNumber.TabIndex = 9;
            // 
            // edtVersion
            // 
            this.edtVersion.Location = new System.Drawing.Point(65, 119);
            this.edtVersion.TabIndex = 12;
            // 
            // lblVersion
            // 
            this.lblVersion.Location = new System.Drawing.Point(4, 120);
            this.lblVersion.TabIndex = 11;
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
            this.edtItem.Location = new System.Drawing.Point(65, 206);
            this.edtItem.Margins.FoldMarginColor = System.Drawing.Color.LightBlue;
            this.edtItem.Margins.Margin0.Width = 40;
            this.edtItem.Margins.Margin1.IsClickable = true;
            this.edtItem.Margins.Margin2.Width = 20;
            this.edtItem.Size = new System.Drawing.Size(325, 138);
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
            this.edtItem.TabIndex = 18;
            // 
            // lblItem
            // 
            this.lblItem.Location = new System.Drawing.Point(4, 201);
            this.lblItem.TabIndex = 15;
            // 
            // rbText
            // 
            this.rbText.Location = new System.Drawing.Point(68, 186);
            this.rbText.TabIndex = 16;
            // 
            // rbURL
            // 
            this.rbURL.Location = new System.Drawing.Point(120, 186);
            this.rbURL.TabIndex = 17;
            // 
            // btnAddGUID
            // 
            this.btnAddGUID.FlatAppearance.BorderSize = 0;
            this.btnAddGUID.Location = new System.Drawing.Point(366, 73);
            this.btnAddGUID.TabIndex = 8;
            // 
            // edtDescription
            // 
            this.edtDescription.Location = new System.Drawing.Point(65, 144);
            this.edtDescription.TabIndex = 14;
            // 
            // helpLabel1
            // 
            this.helpLabel1.Location = new System.Drawing.Point(4, 144);
            this.helpLabel1.TabIndex = 13;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Doc No";
            // 
            // edtDocumentNumber
            // 
            this.edtDocumentNumber.AttributeName = null;
            this.edtDocumentNumber.Location = new System.Drawing.Point(68, 4);
            this.edtDocumentNumber.Name = "edtDocumentNumber";
            this.edtDocumentNumber.Size = new System.Drawing.Size(322, 20);
            this.edtDocumentNumber.TabIndex = 1;
            this.edtDocumentNumber.Value = null;
            this.edtDocumentNumber.ValueType = ATMLCommonLibrary.controls.awb.AWBTextBox.eValueType.xsString;
            // 
            // edtLocation
            // 
            this.edtLocation.AttributeName = null;
            this.edtLocation.Location = new System.Drawing.Point(68, 27);
            this.edtLocation.Name = "edtLocation";
            this.edtLocation.Size = new System.Drawing.Size(322, 20);
            this.edtLocation.TabIndex = 3;
            this.edtLocation.Value = null;
            this.edtLocation.ValueType = ATMLCommonLibrary.controls.awb.AWBTextBox.eValueType.xsString;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Location";
            // 
            // TestProgramDocumentationControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.edtLocation);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.edtDocumentNumber);
            this.Controls.Add(this.label1);
            this.Name = "TestProgramDocumentationControl";
            this.Size = new System.Drawing.Size(422, 353);
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
            this.Controls.SetChildIndex(this.helpLabel1, 0);
            this.Controls.SetChildIndex(this.edtDescription, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.edtDocumentNumber, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.edtLocation, 0);
            ((System.ComponentModel.ISupportInitialize)(this.edtItem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private ATMLCommonLibrary.controls.awb.AWBTextBox edtDocumentNumber;
        private ATMLCommonLibrary.controls.awb.AWBTextBox edtLocation;
        private System.Windows.Forms.Label label2;
    }
}
