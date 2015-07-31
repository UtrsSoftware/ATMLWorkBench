/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
*
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/
namespace ATMLCommonLibrary.controls.control.language
{
    partial class ControlLanguageControl
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
            this.rdoGeneric = new System.Windows.Forms.RadioButton();
            this.rdoRegister = new System.Windows.Forms.RadioButton();
            this.rdoSCPI = new System.Windows.Forms.RadioButton();
            this.helpLabel2 = new ATMLCommonLibrary.controls.HelpLabel(this.components);
            this.helpLabel3 = new ATMLCommonLibrary.controls.HelpLabel(this.components);
            this.helpLabel4 = new ATMLCommonLibrary.controls.HelpLabel(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.helpLabel5 = new ATMLCommonLibrary.controls.HelpLabel(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.edtItem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblName
            // 
            this.lblName.Location = new System.Drawing.Point(4, 36);
            // 
            // edtDocumentName
            // 
            this.edtDocumentName.Location = new System.Drawing.Point(65, 36);
            this.edtDocumentName.Size = new System.Drawing.Size(321, 20);
            // 
            // edtUUID
            // 
            this.edtUUID.Location = new System.Drawing.Point(65, 59);
            this.edtUUID.Size = new System.Drawing.Size(286, 20);
            // 
            // lblUUID
            // 
            this.lblUUID.Location = new System.Drawing.Point(4, 59);
            // 
            // edtControlNumber
            // 
            this.edtControlNumber.Location = new System.Drawing.Point(65, 82);
            this.edtControlNumber.Size = new System.Drawing.Size(321, 20);
            // 
            // lblControlNumber
            // 
            this.lblControlNumber.Location = new System.Drawing.Point(4, 82);
            // 
            // edtVersion
            // 
            this.edtVersion.Location = new System.Drawing.Point(65, 105);
            this.edtVersion.Size = new System.Drawing.Size(321, 20);
            // 
            // lblVersion
            // 
            this.lblVersion.Location = new System.Drawing.Point(4, 105);
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
            this.edtItem.Location = new System.Drawing.Point(65, 188);
            this.edtItem.Margins.FoldMarginColor = System.Drawing.Color.LightBlue;
            this.edtItem.Margins.Margin0.Width = 40;
            this.edtItem.Margins.Margin1.IsClickable = true;
            this.edtItem.Margins.Margin2.Width = 20;
            this.edtItem.Size = new System.Drawing.Size(321, 64);
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
            this.lblItem.Location = new System.Drawing.Point(4, 188);
            // 
            // rbText
            // 
            this.rbText.Location = new System.Drawing.Point(68, 168);
            // 
            // rbURL
            // 
            this.rbURL.Location = new System.Drawing.Point(120, 168);
            // 
            // btnAddGUID
            // 
            this.btnAddGUID.FlatAppearance.BorderSize = 0;
            this.btnAddGUID.Location = new System.Drawing.Point(366, 57);
            // 
            // edtDescription
            // 
            this.edtDescription.Location = new System.Drawing.Point(65, 128);
            this.edtDescription.Size = new System.Drawing.Size(321, 37);
            // 
            // helpLabel1
            // 
            this.helpLabel1.Location = new System.Drawing.Point(4, 128);
            // 
            // rdoGeneric
            // 
            this.rdoGeneric.AutoSize = true;
            this.rdoGeneric.Location = new System.Drawing.Point(14, 11);
            this.rdoGeneric.Name = "rdoGeneric";
            this.rdoGeneric.Size = new System.Drawing.Size(62, 17);
            this.rdoGeneric.TabIndex = 15;
            this.rdoGeneric.TabStop = true;
            this.rdoGeneric.Text = "Generic";
            this.rdoGeneric.UseVisualStyleBackColor = true;
            // 
            // rdoRegister
            // 
            this.rdoRegister.AutoSize = true;
            this.rdoRegister.Location = new System.Drawing.Point(81, 11);
            this.rdoRegister.Name = "rdoRegister";
            this.rdoRegister.Size = new System.Drawing.Size(64, 17);
            this.rdoRegister.TabIndex = 16;
            this.rdoRegister.TabStop = true;
            this.rdoRegister.Text = "Register";
            this.rdoRegister.UseVisualStyleBackColor = true;
            // 
            // rdoSCPI
            // 
            this.rdoSCPI.AutoSize = true;
            this.rdoSCPI.Location = new System.Drawing.Point(149, 11);
            this.rdoSCPI.Name = "rdoSCPI";
            this.rdoSCPI.Size = new System.Drawing.Size(49, 17);
            this.rdoSCPI.TabIndex = 17;
            this.rdoSCPI.TabStop = true;
            this.rdoSCPI.Text = "SCPI";
            this.rdoSCPI.UseVisualStyleBackColor = true;
            // 
            // helpLabel2
            // 
            this.helpLabel2.AutoSize = true;
            this.helpLabel2.HelpMessageKey = "ControlLanguage.Generic";
            this.helpLabel2.Location = new System.Drawing.Point(28, 13);
            this.helpLabel2.Name = "helpLabel2";
            this.helpLabel2.RequiredField = false;
            this.helpLabel2.RequiredFieldMarkerFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.helpLabel2.Size = new System.Drawing.Size(44, 13);
            this.helpLabel2.TabIndex = 18;
            this.helpLabel2.Text = "Generic";
            // 
            // helpLabel3
            // 
            this.helpLabel3.AutoSize = true;
            this.helpLabel3.HelpMessageKey = "ControlLanguage.Register";
            this.helpLabel3.Location = new System.Drawing.Point(97, 13);
            this.helpLabel3.Name = "helpLabel3";
            this.helpLabel3.RequiredField = false;
            this.helpLabel3.RequiredFieldMarkerFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.helpLabel3.Size = new System.Drawing.Size(46, 13);
            this.helpLabel3.TabIndex = 19;
            this.helpLabel3.Text = "Register";
            // 
            // helpLabel4
            // 
            this.helpLabel4.AutoSize = true;
            this.helpLabel4.HelpMessageKey = "ControlLanguage.SCPI";
            this.helpLabel4.Location = new System.Drawing.Point(165, 14);
            this.helpLabel4.Name = "helpLabel4";
            this.helpLabel4.RequiredField = false;
            this.helpLabel4.RequiredFieldMarkerFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.helpLabel4.Size = new System.Drawing.Size(31, 13);
            this.helpLabel4.TabIndex = 20;
            this.helpLabel4.Text = "SCPI";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.helpLabel3);
            this.groupBox1.Controls.Add(this.helpLabel2);
            this.groupBox1.Controls.Add(this.helpLabel4);
            this.groupBox1.Controls.Add(this.rdoSCPI);
            this.groupBox1.Controls.Add(this.rdoRegister);
            this.groupBox1.Controls.Add(this.rdoGeneric);
            this.groupBox1.Location = new System.Drawing.Point(66, -1);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(214, 34);
            this.groupBox1.TabIndex = 21;
            this.groupBox1.TabStop = false;
            // 
            // helpLabel5
            // 
            this.helpLabel5.AutoSize = true;
            this.helpLabel5.HelpMessageKey = "ControlLanguage.Type";
            this.helpLabel5.Location = new System.Drawing.Point(3, 13);
            this.helpLabel5.Name = "helpLabel5";
            this.helpLabel5.RequiredField = false;
            this.helpLabel5.RequiredFieldMarkerFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.helpLabel5.Size = new System.Drawing.Size(31, 13);
            this.helpLabel5.TabIndex = 22;
            this.helpLabel5.Text = "Type";
            // 
            // ControlLanguageControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.helpLabel5);
            this.Controls.Add(this.groupBox1);
            this.Name = "ControlLanguageControl";
            this.Padding = new System.Windows.Forms.Padding(0, 30, 0, 0);
            this.Size = new System.Drawing.Size(404, 262);
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
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.helpLabel5, 0);
            ((System.ComponentModel.ISupportInitialize)(this.edtItem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton rdoGeneric;
        private System.Windows.Forms.RadioButton rdoRegister;
        private System.Windows.Forms.RadioButton rdoSCPI;
        private HelpLabel helpLabel2;
        private HelpLabel helpLabel3;
        private HelpLabel helpLabel4;
        private System.Windows.Forms.GroupBox groupBox1;
        private HelpLabel helpLabel5;


    }
}
