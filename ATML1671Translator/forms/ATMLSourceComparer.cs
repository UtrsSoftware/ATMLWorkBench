/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
* 
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

using System;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using ATML1671Translator.translator;
using ATMLCommonLibrary.model;
using ATMLManagerLibrary.managers;
using ATMLModelLibrary.interfaces;
using ATMLProject.managers;
using ATMLUtilitiesLibrary;
using ScintillaNET;
using WeifenLuo.WinFormsUI.Docking;

namespace ATML1671Translator.forms
{
    public partial class ATMLSourceComparer : DockContent, IATMLDockableWindow, IATMLTranslatorConsumer
    {
        private ATMLTranslator _translator;

        public ATMLSourceComparer()
        {
            InitializeComponent();

            ATMLContext.PropertyChanged += delegate { SetProperties(); };
            
            targetEditor.MouseDoubleClick += targetEditor_MouseDoubleClick;

            targetEditor.ConfigurationManager.Language = "xml";
            targetEditor.IsReadOnly = false;
            targetEditor.Lexing.Lexer = Lexer.Xml;
            targetEditor.Folding.IsEnabled = true;
            targetEditor.MatchBraces = true;
            targetEditor.IsBraceMatching = true;
            targetEditor.Lexing.SetProperty("fold", "1");
            targetEditor.Lexing.SetProperty("fold.html", "1");
            targetEditor.UndoRedo.EmptyUndoBuffer();
            targetEditor.Modified = false;
            targetEditor.Margins[0].Width = 40;
            targetEditor.Margins[1].Width = 16;
            targetEditor.Margins[2].Width = 40;
            targetEditor.GotFocus += new EventHandler(targetEditor_GotFocus);
            targetEditor.DoubleClick+=TargetEditorOnDoubleClick;

            sourceEditor.ConfigurationManager.Language = "fortran";
            sourceEditor.IsReadOnly = true;
            sourceEditor.Lexing.Lexer = Lexer.Fortran;
            sourceEditor.Folding.IsEnabled = true;
            sourceEditor.MatchBraces = true;
            sourceEditor.IsBraceMatching = true;
            sourceEditor.Lexing.SetProperty("fold", "1");
            sourceEditor.Lexing.SetProperty("fold.html", "1");
            sourceEditor.UndoRedo.EmptyUndoBuffer();
            sourceEditor.Modified = false;
            sourceEditor.Margins[0].Width = 40;
            sourceEditor.Margins[1].Width = 16;
            sourceEditor.Margins[2].Width = 40;
            sourceEditor.GotFocus += new EventHandler(sourceEditor_GotFocus);

        }


        void sourceEditor_GotFocus(object sender, EventArgs e)
        {
            SetProperties();
        }

        void targetEditor_GotFocus(object sender, EventArgs e)
        {
            SetProperties();
        }

        private void SetProperties()
        {
            if (targetEditor.Focused)
            {
                testConfigToolStrip.BackColor = (Color)ATMLContext.GetProperty("environment.visual.tool.active.gr2-color", Color.DarkSlateGray);
                testConfigToolStrip.ForeColor = (Color)ATMLContext.GetProperty("environment.visual.tool.active.text-color", Color.White);
                sourceCodeToolStrip.BackColor = Color.WhiteSmoke;
                sourceCodeToolStrip.ForeColor = Color.Black;
            }
            else if (sourceEditor.Focused)
            {
                sourceCodeToolStrip.BackColor = (Color)ATMLContext.GetProperty("environment.visual.tool.active.gr2-color", Color.DarkSlateGray);
                lblSourceFileName.ForeColor = sourceCodeToolStrip.ForeColor = (Color)ATMLContext.GetProperty("environment.visual.tool.active.text-color", Color.White);
                testConfigToolStrip.BackColor = Color.WhiteSmoke;
                testConfigToolStrip.ForeColor = Color.Black;
            }
            else
            {
                testConfigToolStrip.BackColor = Color.WhiteSmoke;
                testConfigToolStrip.ForeColor = Color.Black;
                sourceCodeToolStrip.BackColor = Color.WhiteSmoke;
                sourceCodeToolStrip.ForeColor = Color.Black;
            }
        }

        public String SourceCode
        {
            set { sourceEditor.Text = value; }
        }

        public String TargetCode
        {
            set
            {
                targetEditor.Text = value;
                string fileName = CreateTargetFileName();
                lbl1671FileName.Text = fileName;
                ProjectManager.SaveATMLDocument(fileName, AtmlFileType.AtmlTypeTestDescription, Encoding.UTF8.GetBytes(targetEditor.Text), true);
            }
        }

        private static string CreateTargetFileName()
        {
            return ProjectManager.ProjectName + @".1671.1.xml";
        }


        private void TargetEditorOnDoubleClick(object sender, EventArgs eventArgs)
        {
            targetEditor_MouseDoubleClick( sender, (MouseEventArgs) eventArgs );
        }


        /**
         * Navigate the source code to sync to comment for the current cursor position.
         */

        private void targetEditor_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {

            string comment = targetEditor.GetCommentForCurrentPosition();
            if (!string.IsNullOrEmpty(comment))
            {
                string[] parts = comment.Split('@');
                if (parts.Length >= 3)
                {
                    string file = GetAttributeValue(parts[1]);
                    string statement = GetAttributeValue(parts[2]);
                    string line = GetAttributeValue(parts[3]);
                    var source = ATMLContext.ProjectTranslatorSourcePath;//(String) ATMLContext.GetProperty("translator.parser.source");
                    string projectPath = Path.Combine(ATMLContext.TESTSET_PATH, ProjectManager.ProjectName);
                    file = file.ToLower();
                    //if (!file.EndsWith(".as"))
                    //    file += ".as";
                    int idx = file.LastIndexOf("\\", System.StringComparison.Ordinal);
                    if (idx >= 0)
                        file = file.Substring( idx+1 );
                    idx = file.LastIndexOf("/", System.StringComparison.Ordinal);
                    if (idx >= 0)
                        file = file.Substring(idx + 1);
                    source = Path.Combine(source, file);// source.Replace("${FILENAME}", file).Replace("${PROJECTPATH}", projectPath));
                    string xmlContent;
                    var fi = new FileInfo(source);
                    FileStream fs = File.OpenRead(source);
                    using (fs)
                    {
                        var reader = new StreamReader(fs);
                        xmlContent = reader.ReadToEnd();
                        reader.Close();
                        sourceEditor.IsReadOnly = false;
                        sourceEditor.Text = xmlContent.Trim();
                        sourceEditor.GoTo.Line(int.Parse(line) - 1);
                        sourceEditor.Caret.HighlightCurrentLine = true;
                        sourceEditor.Select();
                        sourceEditor.IsReadOnly = true;
                        lblSourceFileName.Text = file;
                    }
                }
            }
            }
            catch (Exception err )
            {

                LogManager.SourceError(ATMLTranslator.SOURCE, err);
            }
        }

        private static string GetAttributeValue(string part)
        {
            int i1 = part.IndexOf('"') + 1;
            int i2 = part.LastIndexOf('"');
            return part.Substring(i1, i2 - i1);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string fileName = CreateTargetFileName();
            ProjectManager.SaveATMLDocument(fileName, AtmlFileType.AtmlTypeTestDescription, Encoding.UTF8.GetBytes(targetEditor.Text), true);
        }

        public void CloseProject()
        {
            Close();
        }

        public void RegisterATMLTranslator(ATMLTranslator translator)
        {
            _translator = translator;
        }
    }
}