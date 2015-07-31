/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
* 
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Xml;
using ATMLModelLibrary.model.signal.basic;
using ATMLSignalModelLibrary.managers;
using ATMLSignalModelLibrary.signal;
using Control = System.Windows.Forms.Control;

namespace ATMLCommonLibrary.controls.awb
{
    public delegate void SignalSelectHandler( object sender, XmlDocument tsfDocument );

    public partial class AWBDropListView : UserControl
    {
        private DropListTreeForm _treeForm;
        private XmlDocument _treeModel;

        public event SignalSelectHandler SignalSelected;

        public AWBDropListView()
        {
            InitializeComponent();

            Control parent = Parent;
            if (parent != null) parent.Move += ParentForm_Move;
        }

        public XmlDocument TreeModel
        {
            get { return _treeModel; }
            set { _treeModel = value; }
        }

        public SignalModel SelectedSignalModel { get; private set; }

        protected virtual void OnSignalSelected( SignalModel model, XmlDocument tsfDocument )
        {
            SelectedSignalModel = model;
            SignalSelectHandler handler = SignalSelected;
            if (handler != null) handler(model, tsfDocument);
        }

        protected virtual void OnSignalSelected(string bscName, XmlDocument tsfDocument)
        {
            SignalSelectHandler handler = SignalSelected;
            if (handler != null) handler(bscName, tsfDocument);
        }


        public XmlNode FindNode( string name, string nameSpace )
        {
            XmlNode selectedNode = null;
            if (_treeModel != null)
            {
                XmlNodeList selectedNodeList = _treeModel.SelectNodes( ".//*" );
                var result = new List<XmlNode>();
                if (selectedNodeList != null)
                {
                    foreach (XmlNode node in selectedNodeList)
                    {
                        result.Add( node );
                        if (node.Attributes != null)
                        {
                            XmlAttribute ax = node.Attributes["xmlns"];
                            if (name.Equals( node.Name ) && nameSpace.Equals( ax.Value ))
                            {
                                selectedNode = node;
                                edtSelectedValue.Text = name;
                                edtSelectedValue.Tag = node;
                                break;
                            }
                        }
                    }
                }
            }
            return selectedNode;
        }

        private void _treeForm_LostFocus( object sender, EventArgs e )
        {
            if (!btnDown.RectangleToScreen( btnDown.ClientRectangle ).Contains( Cursor.Position ))
            {
                CloseTree();
            }
        }

        private void _treeForm_SignalSelect( object sender, XmlDocument tsfDocument )
        {
            var element = sender as XmlElement;
            if (element != null)
            {
                edtSelectedValue.Text = element.Name;
                edtSelectedValue.Tag = element;
                string xmlns = element.GetAttribute( "xmlns" );
                SignalModel model = SignalManager.GetSignalModel( xmlns, element.Name );
                if (xmlns.Contains("STDBSC"))
                    OnSignalSelected(element.Name, element.OwnerDocument);
                else
                    OnSignalSelected(model, element.OwnerDocument);
            }
            CloseTree();
        }


        private void ParentForm_Move( object sender, EventArgs e )
        {
            CloseTree();
        }

        private void CloseTree()
        {
            if (_treeForm != null)
                _treeForm.Close();
            _treeForm = null;
        }


        private void btnDown_Click( object sender, EventArgs e )
        {
            var pt = new Point( 0, panel1.Height );
            if (_treeForm == null)
            {
                _treeForm = new DropListTreeForm();
                _treeForm.TreeModel = _treeModel;
                _treeForm.Location = PointToScreen( pt );
                _treeForm.Width = edtSelectedValue.Width + btnDown.Width;
                _treeForm.SignalSelect += _treeForm_SignalSelect;
                _treeForm.TreeLostFocus += _treeForm_TreeLostFocus;
                if (!string.IsNullOrEmpty( edtSelectedValue.Text ))
                    _treeForm.FindElement( (XmlElement) edtSelectedValue.Tag );
                _treeForm.Show();
            }
            else
            {
                CloseTree();
            }
        }

        private void _treeForm_TreeLostFocus( object sender, EventArgs e )
        {
            if (!btnDown.RectangleToScreen( btnDown.ClientRectangle ).Contains( Cursor.Position ))
            {
                CloseTree();
            }
        }

        private void edtSelectedValue_KeyDown( object sender, KeyEventArgs e )
        {
        }

        private void btnDown_KeyDown( object sender, KeyEventArgs e )
        {
        }
    }

    public class DropListTreeForm : Form
    {
        private const int AW_HOR_POSITIVE = 0x00000001;
        private const int AW_HOR_NEGATIVE = 0x00000002;
        private const int AW_VER_POSITIVE = 0x00000004;
        private const int AW_VER_NEGATIVE = 0x00000008;
        private const int AW_CENTER = 0x00000010;
        private const int AW_HIDE = 0x00010000;
        private const int AW_ACTIVATE = 0x00020000;
        private const int AW_SLIDE = 0x00040000;
        private const int AW_BLEND = 0x00080000;

        private readonly Panel _treePanel = new Panel();
        private readonly TreeView _treeView = new TreeView();
        private XmlDocument _treeModel;

        public DropListTreeForm()
        {
            FormBorderStyle = FormBorderStyle.None;
            StartPosition = FormStartPosition.Manual;
            ShowInTaskbar = false;
            BackColor = SystemColors.Control;
            Layout += _treeForm_Layout;
            Load += DropListTreeForm_Load;
            Closing += DropListTreeForm_Closing;
            TopMost = true;

            _treeView.Location = new Point( 0, 0 );
            _treeView.BorderStyle = BorderStyle.None;
            _treeView.LostFocus += _treeView_LostFocus;
            _treeView.KeyDown += _treeView_KeyDown;
            _treeView.NodeMouseClick += _treeView_NodeMouseClick;
            _treeView.Dock = DockStyle.Fill;

            _treePanel.BorderStyle = BorderStyle.FixedSingle;
            _treePanel.BackColor = Color.White;
            _treePanel.Dock = DockStyle.Fill;

            _treePanel.Controls.Add( _treeView );
            Controls.Add( _treePanel );
        }

        public XmlDocument TreeModel
        {
            get { return _treeModel; }
            set
            {
                _treeModel = value;
                if (_treeModel != null)
                {
                    foreach (XmlNode node in _treeModel.ChildNodes)
                    {
                        ProcessTreeNode( node, null );
                    }
                }
                _treeView.ExpandAll();
            }
        }

        [DllImport( "user32" )]
        private static extern bool AnimateWindow( IntPtr hwnd, int time, int flags );

        public event EventHandler TreeLostFocus;

        protected virtual void OnTreeLostFocus()
        {
            EventHandler handler = TreeLostFocus;
            if (handler != null) handler( this, EventArgs.Empty );
        }

        public event SignalSelectHandler SignalSelect;

        protected virtual void OnSignalSelect( object sender, XmlDocument tsfDocument )
        {
            SignalSelectHandler handler = SignalSelect;
            if (handler != null) handler(sender, tsfDocument);
        }

        private void DropListTreeForm_Closing( object sender, CancelEventArgs e )
        {
            AnimateWindow( Handle, 200, AW_SLIDE | AW_VER_NEGATIVE | AW_HIDE );
        }

        private void DropListTreeForm_Load( object sender, EventArgs e )
        {
            AnimateWindow( Handle, 200, AW_SLIDE | AW_VER_POSITIVE );
        }


        public bool FindElement( XmlElement element )
        {
            bool found = false;
            foreach (TreeNode node in _treeView.Nodes)
            {
                found = FindNode( node, element );
                if (found)
                    break;
            }
            return found;
        }

        private bool FindNode( TreeNode parentNode, XmlElement element )
        {
            bool found = false;
            foreach (TreeNode node in parentNode.Nodes)
            {
                if (node.Tag == element)
                {
                    found = true;
                    _treeView.SelectedNode = node;
                    break;
                }
                found = FindNode( node, element );
                if (found)
                    break;
            }
            return found;
        }

        private void ProcessTreeNode( XmlNode parentNode, TreeNode parentTreeNode )
        {
            var element = parentNode as XmlElement;
            if (element != null)
            {
                var tn = new TreeNode( element.Name );
                tn.Tag = element;
                if (parentTreeNode == null)
                    _treeView.Nodes.Add( tn );
                else
                    parentTreeNode.Nodes.Add( tn );
                foreach (XmlNode childNode in element.ChildNodes)
                {
                    ProcessTreeNode( childNode, tn );
                }
            }
        }

        private void _treeView_NodeMouseClick( object sender, TreeNodeMouseClickEventArgs e )
        {
            SelectSignal( e.Node );
        }

        private void _treeView_KeyDown( object sender, KeyEventArgs e )
        {
            if (e.KeyCode == Keys.Enter)
                SelectSignal( _treeView.SelectedNode );
        }


        private void _treeView_LostFocus( object sender, EventArgs e )
        {
            OnTreeLostFocus();
        }

        private void _treeForm_Layout( object sender, LayoutEventArgs e )
        {
            int i = 0;
        }

        private void SelectSignal( TreeNode node )
        {
            if (node != null && node.Nodes.Count == 0)
            {
                var element = node.Tag as XmlElement;
                if( element != null )
                    OnSignalSelect( element, element.OwnerDocument );
                Close();
            }
        }
    }
}