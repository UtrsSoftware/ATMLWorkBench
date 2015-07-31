/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
*
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/
namespace ATMLCommonLibrary.controls
{
    partial class ATMLPreviewPanel
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
            this.webBrowser = new System.Windows.Forms.WebBrowser();
            this.previewPanel = new System.Windows.Forms.Panel();
            this.sourcePreviewer = new ATMLCommonLibrary.controls.awb.AWBEditor();
            ((System.ComponentModel.ISupportInitialize)(this.sourcePreviewer)).BeginInit();
            this.SuspendLayout();
            // 
            // webBrowser
            // 
            this.webBrowser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowser.Location = new System.Drawing.Point(0, 0);
            this.webBrowser.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser.Name = "webBrowser";
            this.webBrowser.Size = new System.Drawing.Size(350, 244);
            this.webBrowser.TabIndex = 0;
            this.webBrowser.Visible = false;
            // 
            // previewPanel
            // 
            this.previewPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.previewPanel.Location = new System.Drawing.Point(0, 0);
            this.previewPanel.Name = "previewPanel";
            this.previewPanel.Size = new System.Drawing.Size(350, 244);
            this.previewPanel.TabIndex = 5;
            this.previewPanel.Resize += new System.EventHandler(this.previewPanel_Resize);
            // 
            // sourcePreviewer
            // 
            this.sourcePreviewer.AllowDrop = true;
            this.sourcePreviewer.ConfigurationManager.Language = "xml";
            this.sourcePreviewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sourcePreviewer.Folding.Flags = ScintillaNET.FoldFlag.Box;
            this.sourcePreviewer.Indentation.ShowGuides = true;
            this.sourcePreviewer.Indentation.SmartIndentType = ScintillaNET.SmartIndent.CPP;
            this.sourcePreviewer.Indentation.TabWidth = 2;
            this.sourcePreviewer.IsBraceMatching = true;
            this.sourcePreviewer.Lexing.Lexer = ScintillaNET.Lexer.Xml;
            this.sourcePreviewer.Lexing.LexerName = "xml";
            this.sourcePreviewer.Lexing.LineCommentPrefix = "";
            this.sourcePreviewer.Lexing.StreamCommentPrefix = "";
            this.sourcePreviewer.Lexing.StreamCommentSufix = "";
            this.sourcePreviewer.LineWrapping.IndentMode = ScintillaNET.LineWrappingIndentMode.Indent;
            this.sourcePreviewer.LineWrapping.Mode = ScintillaNET.LineWrappingMode.Word;
            this.sourcePreviewer.Location = new System.Drawing.Point(0, 0);
            this.sourcePreviewer.Margins.FoldMarginColor = System.Drawing.Color.LightBlue;
            this.sourcePreviewer.Margins.Margin0.Width = 60;
            this.sourcePreviewer.Margins.Margin1.IsClickable = true;
            this.sourcePreviewer.Margins.Margin2.Width = 20;
            this.sourcePreviewer.Name = "sourcePreviewer";
            this.sourcePreviewer.Size = new System.Drawing.Size(350, 244);
            this.sourcePreviewer.Styles.BraceBad.FontName = "Verdana\0\0\0\0\0\0\0\0\0\0\0\0\0";
            this.sourcePreviewer.Styles.BraceLight.FontName = "Verdana\0\0\0\0\0\0\0\0\0\0\0\0\0";
            this.sourcePreviewer.Styles.CallTip.FontName = "Segoe UI\0\0\0\0\0\0\0\0\0\0\0\0";
            this.sourcePreviewer.Styles.ControlChar.FontName = "Verdana\0\0\0\0\0\0\0\0\0\0\0\0\0";
            this.sourcePreviewer.Styles.Default.FontName = "Verdana\0\0\0\0\0\0\0\0\0\0\0\0\0";
            this.sourcePreviewer.Styles.IndentGuide.FontName = "Verdana\0\0\0\0\0\0\0\0\0\0\0\0\0";
            this.sourcePreviewer.Styles.LastPredefined.FontName = "Verdana\0\0\0\0\0\0\0\0\0\0\0\0\0";
            this.sourcePreviewer.Styles.LineNumber.FontName = "Verdana\0\0\0\0\0\0\0\0\0\0\0\0\0";
            this.sourcePreviewer.Styles.Max.FontName = "Verdana\0\0\0\0\0\0\0\0\0\0\0\0\0";
            this.sourcePreviewer.TabIndex = 15;
            this.sourcePreviewer.KeyUp += new System.Windows.Forms.KeyEventHandler(this.sourcePreviewer_KeyUp);
            this.sourcePreviewer.MouseUp += new System.Windows.Forms.MouseEventHandler(this.sourcePreviewer_MouseUp);
            // 
            // ATMLPreviewPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.sourcePreviewer);
            this.Controls.Add(this.webBrowser);
            this.Controls.Add(this.previewPanel);
            this.Name = "ATMLPreviewPanel";
            this.Size = new System.Drawing.Size(350, 244);
            ((System.ComponentModel.ISupportInitialize)(this.sourcePreviewer)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        protected System.Windows.Forms.WebBrowser webBrowser;
        protected System.Windows.Forms.Panel previewPanel;
        protected ATMLCommonLibrary.controls.awb.AWBEditor sourcePreviewer;
    }
}
