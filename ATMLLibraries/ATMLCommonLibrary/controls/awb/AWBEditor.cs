/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
* 
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

using System;
using System.ComponentModel;
using System.Text;
using System.Windows.Forms;
using ATMLCommonLibrary.controls.document;
using ATMLCommonLibrary.utils;
using ATMLManagerLibrary.managers;
using ScintillaNET;
using Document = ATMLModelLibrary.model.common.Document;

namespace ATMLCommonLibrary.controls.awb
{
    public partial class AWBEditor : Scintilla
    {
        private Document _document;

        public AWBEditor()
        {
            InitializeComponent();
            this.MouseDown+= delegate( object sender, MouseEventArgs args )
                             {
                                 if (args.Clicks > 1)
                                 {
                                     OnDoubleClick( args );
                                     AWBEditor_DoubleClick( sender, args );
                                 }
                             };
            //NOTE: Switching to Scintilla 2.6 broke mouse clicks - the only one that works is the MouseDown event
            //MouseDoubleClick += AWBEditor_DoubleClick;
            SelectionChanged += OnSelectionChanged;
            AllowDrop = true;
        }


        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Document Document
        {
            get
            {
                if (_document == null)
                    _document = new Document();
                _document.Item = Text;
                return _document;
            }
            set
            {
                _document = value;
                Text = _document.Item;
            }
        }

        protected override void OnMouseDoubleClick( MouseEventArgs e )
        {
            base.OnMouseDoubleClick( e );

        }

        public bool IsXML
        {
            get { return !string.IsNullOrWhiteSpace(this.Text) && this.Text.Trim().StartsWith("<") && Text.Trim().EndsWith(">"); }
        }

        public override string Text
        {
            get { return base.Text;  }
            set
            {
                bool mode = IsReadOnly;
                IsReadOnly = false;
                base.Text = value;
                IsReadOnly = mode;
            }
        }

        public bool IsWordWrap
        {
            get { return LineWrapping.Mode == LineWrappingMode.Word; }
        }

        private void OnSelectionChanged(object sender, EventArgs eventArgs)
        {
            DirectMessage((int) Constants.SCI_ENSUREVISIBLEENFORCEPOLICY, 
                            (IntPtr) Selection.Range.EndingLine.Number,
                            (IntPtr) 0);
        }

        public void InitForXML()
        {
            ConfigurationManager.Language = "xml";
            MatchBraces = true;
            IsBraceMatching = true;
            Lexing.Lexer = Lexer.Xml;
            Folding.IsEnabled = true;
            Lexing.SetProperty("fold", "1");
            Lexing.SetProperty("fold.html", "1");
            Margins[0].Width = 60;
            Margins[1].Width = 16;
            Margins[2].Width = 40;
            UndoRedo.EmptyUndoBuffer();
            Modified = false;
        }

        public void InitForATLAS()
        {
            ConfigurationManager.Language = "pascal";
            MatchBraces = false;
            IsBraceMatching = false;
            Lexing.Lexer = Lexer.Pascal;
            Folding.IsEnabled = false;
            Lexing.SetProperty("fold", "0");
            Lexing.SetProperty("fold.html", "0");
            Margins[0].Width = 40;
            Margins[1].Width = 16;
            Margins[2].Width = 40;
            UndoRedo.EmptyUndoBuffer();
            Indentation.ShowGuides = false;
            Modified = false;
        }

        public void InitForText()
        {
            ConfigurationManager.Language = "text";
            Indentation.ShowGuides = false;
            MatchBraces = false;
            IsBraceMatching = false;
            Lexing.Lexer = Lexer.Automatic;
            Folding.IsEnabled = false;
            Lexing.SetProperty("fold", "0");
            Lexing.SetProperty("fold.html", "0");
            Margins[0].Width = 40;
            Margins[1].Width = 16;
            Margins[2].Width = 40;
            UndoRedo.EmptyUndoBuffer();
            Modified = false;
        }
        
        protected override void OnDragEnter(DragEventArgs drgevent)
        {
            base.OnDragEnter(drgevent);
            drgevent.Effect = DragDropEffects.All;
        }

        protected override void OnDragDrop(DragEventArgs drgevent)
        {
            base.OnDragDrop(drgevent);
            LogManager.Trace("Document Dropped");
        }

        protected override void OnDragOver(DragEventArgs drgevent)
        {
            base.OnDragOver(drgevent);
            drgevent.Effect = DragDropEffects.All;
        }

        private void AWBEditor_DocumentChange(object sender, NativeScintillaEventArgs e)
        {
            int i = 0;
        }

        private void AWBEditor_Load(object sender, EventArgs e)
        {
            LogManager.Trace("Document Loaded");
        }

        private void AWBEditor_DoubleClick(object sender, MouseEventArgs e)
        {
            Guid result;
            String attributeValue = "";
            //MessageBox.Show(result.ToString());
            attributeValue = GetAttributeValueFromPosition(Selection.Text);

            if (ModifierKeys == Keys.Control )//e.Control && e.KeyCode == Keys.O)
            {
                if (Guid.TryParse(Selection.Text, out result))
                {
                    var form = new DocumentForm();
                    Document document = DocumentManager.GetDocument(attributeValue);
                    if (document == null)
                    {
                        MessageBox.Show(string.Format("The document with id \"{0}\" does not exist in the database.",
                                                      attributeValue));
                    }
                    else
                    {
                        form.Document = document;
                        form.StartPosition = FormStartPosition.WindowsDefaultLocation;
                        form.ShowDialog();
                    }
                }
                //from current position go back upto 32 chars to see if there is a quote
            }
        }


        public void FoldAll()
        {
            using (new HourGlass())
            {
                foreach (Line line in Lines)
                {
                    if (line.IsFoldPoint && line.FoldExpanded)
                    {
                        line.ToggleFoldExpanded();
                    }
                }
            }
        }

        public void FoldAll(string target)
        {
            using (new HourGlass())
            {
                foreach (Line line in Lines)
                {
                    if (line.IsFoldPoint && line.FoldExpanded && line.Text.Contains(target))
                    {
                        line.ToggleFoldExpanded();
                    }
                }
            }
        }

        public void UnfoldAll()
        {
            using (new HourGlass())
            {
                foreach (Line line in Lines)
                {
                    if (line.IsFoldPoint)
                    {
                        line.ToggleFoldExpanded();
                    }
                }
            }
        }

        public void UnfoldAll(string target)
        {
            using (new HourGlass())
            {
                foreach (Line line in Lines)
                {
                    if (line.IsFoldPoint && !line.FoldExpanded && line.Text.Contains(target))
                    {
                        line.ToggleFoldExpanded();
                    }
                }
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
        }

        public void SaveDocument()
        {
            if (_document != null)
            {
                DocumentManager.SaveDocument(_document);
                Modified = false;
                UndoRedo.EmptyUndoBuffer();
                OnTextChanged(null);
                CurrentPos = Tag != null ? (int)Tag : 0;
            }
        }



        protected override void OnKeyDown(KeyEventArgs e)
        {
            try
            {
                if (e.Alt && e.KeyCode == Keys.F2)
                {
                    ToggleBookmark();
                }
                else if (e.KeyCode == Keys.F2)
                {
                    GotoNextBookmark();
                }
                else if (e.KeyCode == Keys.Up
                         || e.KeyCode == Keys.Down
                         || e.KeyCode == Keys.Left
                         || e.KeyCode == Keys.Right
                         || e.Control)
                {
                    //Check if valid guid
                    Guid result;
                    String attributeValue = "";

                    if (e.Control && e.KeyCode == Keys.O)
                    {
                        if (Guid.TryParse( Selection.Text, out result ))
                        {
                            attributeValue = GetAttributeValueFromPosition( Selection.Text );
                            var form = new DocumentForm();
                            form.Document = DocumentManager.GetDocument( attributeValue );
                            form.StartPosition = FormStartPosition.WindowsDefaultLocation;
                            form.ShowDialog();
                        }
                        //from current position go back upto 32 chars to see if there is a quote
                    }
                    else if (e.Control && e.Alt && e.KeyCode == Keys.Space)
                    {
                        Line line = Lines.Current;
                        if (line != null)
                            line.ToggleFoldExpanded();
                    }
                    else if (e.Control && e.Alt && e.KeyCode == Keys.M)
                    {
                        Commands.Execute( BindableCommand.ShowFind );
                    }
                    else if (e.Control && e.KeyCode == Keys.W)
                    {
                        ToggleWordWrap();
                    }
                    else
                    {
                        base.OnKeyDown( e );
                    }
                }
                else
                {
                    base.OnKeyDown( e );
                }
            }
            catch (Exception exception)
            {
                LogManager.Error( exception );
            }
        }

        private void GotoNextBookmark()
        {
            try
            {
                Line next = Markers.FindNextMarker() ?? Markers.FindNextMarker( 1 );
                if (next != null)
                {
                    Caret.Position = next.EndPosition;
                    next.Range.SetIndicator( 2 );
                    Caret.Goto( next.EndPosition );
                    Focus();
                }
            }
            catch (Exception err)
            {
                LogManager.Debug( err );
            }
        }

        private void ToggleBookmark()
        {
            try
            {
                Line currentLine = Lines.Current;
                if (Markers.GetMarkerMask( currentLine ) == 0)
                {
                    currentLine.AddMarker( 0 );
                }
                else
                {
                    currentLine.DeleteMarker( 0 );
                }
            }
            catch (Exception err)
            {
                LogManager.Debug( err );
            }
        }

        public bool ToggleWordWrap()
        {
            bool wordWrapOn = false;
            if (LineWrapping.Mode == LineWrappingMode.None)
            {
                LineWrapping.Mode = LineWrappingMode.Word;
                wordWrapOn = true;
            }
            else
            {
                LineWrapping.Mode = LineWrappingMode.None;
                wordWrapOn = false;
            }
            return wordWrapOn;
        }

        //<!--
        //-->
        public string GetCommentForCurrentPosition()
        {
            var sb = new StringBuilder();
            int pos = CurrentPos;
            int startPos = -1;
            int endPos = -1;

            string subText = Text.Substring(0, pos);
            int startComment = subText.LastIndexOf("<!--");
            if (startComment != -1)
            {
                string restOfFile = Text.Substring(startComment);
                int endComment = restOfFile.IndexOf("-->");
                if (endComment != -1)
                    sb.Append(restOfFile.Substring(4, endComment - 3));
                else
                    sb.Append(restOfFile.Substring(4));
            }
            return sb.ToString();
        }


        private string GetAttributeValueFromPosition(string attributeValue)
        {
            int pos = CurrentPos;
            int startPos = -1;
            int endPos = -1;
            if (CharAt(pos) == '"' || CharAt(pos - 1) == '"')
                return attributeValue;

            for (int i = pos; i > pos - 36; i--)
            {
                char c = CharAt(i);
                if (c == '"')
                {
                    if (CharAt(i - 1) == '=')
                        startPos = i + 1;
                    break;
                }
            }

            if (startPos != -1)
            {
                for (int i = pos; i < pos + 36; i++)
                {
                    char c = CharAt(i);
                    if (c == '"')
                    {
                        endPos = i;
                        break;
                    }
                }
                if (endPos != -1)
                {
                    Selection.Range = GetRange(startPos, endPos);
                    attributeValue = Selection.Range.Text;
                }
            }
            return attributeValue;
        }
    }
}