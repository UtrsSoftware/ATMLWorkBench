/*
* Copyright (c) 2014 Universal Technical Resource Services, inc.
*
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using ATMLCommonLibrary.controls.awb;
using ATMLCommonLibrary.model;
using ATMLCommonLibrary.model.navigator;
using ATMLManagerLibrary.controllers;
using ATMLManagerLibrary.events;
using ATMLManagerLibrary.managers;
using ATMLUtilitiesLibrary;
using WeifenLuo.WinFormsUI.Docking;

namespace ATMLCommonLibrary.forms
{
    public partial class ATMLNavigationWindow : DockContent, IATMLDockableWindow
    {
//        public event OnSelectDocument SelectATMLTestAdapter;
//        public event OnSelectDocument SelectATMLTestStation;
//        public event OnSelectDocument SelectATMLInstrument;
//        public event OnSelectDocument SelectATMLUUT;
//        public event OnSelectDocument SelectSourceDocument;

        private readonly ToolStripMenuItem _addFilesLabel = new ToolStripMenuItem {Text = @"Add Files"};
//        private readonly ToolStripMenuItem _createAbfFile = new ToolStripMenuItem {Text = @"Create Atlas Build File"};

        private readonly ToolStripMenuItem _deleteLabel = new ToolStripMenuItem {Text = @"Delete"};
        private readonly ATMLNavigator _navigator;
        private readonly ToolStripMenuItem _openLabel = new ToolStripMenuItem {Text = @"Open"};
        private readonly ToolStripMenuItem _renameLabel = new ToolStripMenuItem {Text = @"Rename"};
        private readonly List<TreeNode> _selectedNodes;
        private TreeNode _firstTreeNode;
        private TreeNode _lastTreeNode;
        private string _testProgramSetName;
        private ContextMenuStrip docMenu;
        private FileSystemWatcher _fileSystemWatcher;
        private string _testProgramPath;


        public ATMLNavigationWindow( ATMLNavigator navigator )
        {
            _navigator = navigator;
            _selectedNodes = new List<TreeNode>();

            InitializeComponent();

            docMenu = new ContextMenuStrip();
            docMenu.Items.Add( _openLabel );
            docMenu.Items.Add( _deleteLabel );
            docMenu.Items.Add( _renameLabel );
            docMenu.Items.Add( _addFilesLabel );
//            docMenu.Items.Add( _createAbfFile );

            testSetNavigationTree.ContextMenuStrip = docMenu;

            _navigator.FileAdded += NavigatorFileAdded;
            _navigator.FileDeleted += NavigatorFileDeleted;
            _navigator.FileRemoved += _navigator_FileRemoved;
            _navigator.TranslatorDocumentAdded += NavigatorDocumentAdded;
            _navigator.AtmlDocumentAdded += NavigatorDocumentAdded;
            _navigator.SourceDocumentAdded += NavigatorSourceDocumentAdded;

            _openLabel.Click += openLabel_Click;
            _deleteLabel.Click += deleteLabel_Click;
            _renameLabel.Click += renameLabel_Click;
            _addFilesLabel.Click += addFilesLabel_Click;
//            _createAbfFile.Click += _createAbfFile_Click;
            UUTController.Instance.AtmlObjectNameChanged += InstanceOnAtmlObjectNameChanged;
            LoadTree();
        }

        public string TestProgramSetName
        {
            get { return _testProgramSetName; }
            set
            {
                _testProgramSetName = value;
                LoadTree();
            }
        }

        public void CloseProject()
        {
            testSetNavigationTree.Nodes.Clear();
            _testProgramSetName = null;
            _navigator.ClearFiles();
            if (_fileSystemWatcher != null)
            {
                _fileSystemWatcher.EnableRaisingEvents = false;
                _fileSystemWatcher = null;
            }
        }

        protected void PaintSelectedNodes()
        {
            foreach (TreeNode selectedNode in _selectedNodes)
            {
                PaintSelectedNode( selectedNode );
            }
        }

        private static void PaintSelectedNode( TreeNode selectedNode )
        {
            selectedNode.BackColor = SystemColors.Highlight;
            selectedNode.ForeColor = SystemColors.HighlightText;
        }

        protected void RemovedPaintedNodes()
        {
            if (_selectedNodes.Count == 0) return;

            Color bkColor = testSetNavigationTree.BackColor;
            Color frColor = testSetNavigationTree.ForeColor;

            foreach (TreeNode selectedNode in _selectedNodes)
            {
                selectedNode.BackColor = bkColor;
                selectedNode.ForeColor = frColor;
            }
        }

        protected void RemovedPaintedNodes( TreeNode node )
        {
            Color bkColor = testSetNavigationTree.BackColor;
            Color frColor = testSetNavigationTree.ForeColor;
            node.BackColor = bkColor;
            node.ForeColor = frColor;
        }


        private void InstanceOnAtmlObjectNameChanged( object sender, AtmlNameChangedEventArgs atmlNameChangedEventArgs )
        {
            string oldName = atmlNameChangedEventArgs.OldName;
            string newName = atmlNameChangedEventArgs.NewName;
            //LoadTree();
            TreeNode node = FindNodeByFileName( testSetNavigationTree.Nodes, oldName );
            TreeNode parent = node.Parent;
            var fi = node.Tag as FileInfo;
            node.Remove();
            AddNode( parent, new FileInfo( Path.Combine( fi.DirectoryName, newName ) ) );
            testSetNavigationTree.SelectedNode = node;
        }

        private void _navigator_FileRemoved( object sender, EventArgs e )
        {
            var args = e as AtmlNavigatorEventArgs;
            if (args != null)
            {
                TreeNode selectedNode = FindNodeByFileName( testSetNavigationTree.Nodes, args.FileName );
                if (selectedNode != null)
                    selectedNode.Remove();
            }
        }

        private TreeNode FindNodeByFileName( TreeNodeCollection parentNodes, string fileName )
        {
            TreeNode selectedNode = null;
            foreach (TreeNode node in parentNodes)
            {
                var fi = node.Tag as FileInfo;
                //if (fi != null && fileName.Equals( fi.Name ))
                if (node.Text.Equals( fileName ))
                {
                    selectedNode = node;
                    break;
                }

                selectedNode = FindNodeByFileName( node.Nodes, fileName );

                if (selectedNode != null)
                    break;
            }

            return selectedNode;
        }

        protected override bool ProcessCmdKey( ref Message msg, Keys keyData )
        {
            if (keyData == ( Keys.Control | Keys.F4 ))
            {
                Console.Beep();
                return true;
            }
            return base.ProcessCmdKey( ref msg, keyData );
        }

        private void NavigatorSourceDocumentAdded( FileInfo fi, string documentType )
        {
            TreeNode node = FindFolder( documentType );
            bool found = false;
            if (node != null)
            {
                foreach (TreeNode file in node.Nodes)
                {
                    found |= fi.Name.Equals( file.Name );
                }

                if (!found)
                {
                    AddNode( node, fi );
                }
            }
        }

        private void _createAbfFile_Click( object sender, EventArgs e )
        {
            var di = testSetNavigationTree.SelectedNode.Tag as DirectoryInfo;
            _navigator.CreateAbfFile( di );
        }


        private void NavigatorDocumentAdded( FileInfo fi, string documentType )
        {
            TreeNode node = FindFolder( documentType );
            bool found = false;
            if (node != null)
            {
                foreach (TreeNode file in node.Nodes)
                {
                    found |= fi.Name.Equals( file.Name );
                }

                if (!found)
                {
                    AddNode( node, fi );
                }
            }
        }


        private void NavigatorFileDeleted( FileInfo fi )
        {
            //TreeNode node = testSetNavigationTree.SelectedNode;
            //if (node != null)
            //    node.Remove();
        }

        private void NavigatorFileAdded( FileInfo fi )
        {
            //AddNode( fi ); //Handled by file watcher now
        }

        private void AddNode( FileInfo fi )
        {
            string extension = fi.Extension;
            var node = new TreeNode( fi.Name );
            TreeNode parentNode = testSetNavigationTree.SelectedNode;
            node.Name = fi.Name;
            node.Tag = fi;
            SetTreeNodeImage( extension, node, parentNode );
            if (parentNode != null)
                parentNode.Nodes.Add( node );
            else
                testSetNavigationTree.Nodes.Add( node );
        }

        private void AddNode( TreeNode parentNode, FileInfo fi )
        {
            try
            {
                this.UIThreadInvoke(delegate
                                    {
                                            string extension = fi.Extension;
                                            var node = new TreeNode( fi.Name );
                                            node.Name = fi.Name;
                                            node.Tag = fi;
                                            SetTreeNodeImage( extension, node, parentNode );
                                            if (parentNode != null)
                                                parentNode.Nodes.Add( node );
                                            else
                                                testSetNavigationTree.Nodes.Add( node );
                                    } );
            }
            catch (Exception e)
            {
                LogManager.Error( e );
            }
        }


        private void addFilesLabel_Click( object sender, EventArgs e )
        {
            try
            {
                var di = testSetNavigationTree.SelectedNode.Tag as DirectoryInfo;
                _navigator.AddFiles( di );
            }
            catch (Exception err)
            {
                LogManager.Error( err );
            }
        }

        public ICollection<FileInfo> GetSelectedFiles()
        {
            var list = new List<FileInfo>();
            foreach (TreeNode selectedNode in _selectedNodes)
            {
                if (selectedNode.Tag is FileInfo)
                    list.Add( (FileInfo) selectedNode.Tag );
            }
            return list;
        }

        private static void SetTreeNodeImage( string extension, TreeNode node, TreeNode parentNode )
        {
            bool isFile = node.Tag is FileInfo;
            bool isDirectory = node.Tag is DirectoryInfo;
            if (extension.StartsWith( ".doc" ))
                node.ImageIndex = node.SelectedImageIndex = 7;
            else if (extension.StartsWith( ".xls" ))
                node.ImageIndex = node.SelectedImageIndex = 8;
            else if (extension.StartsWith( ".pdf" ))
                node.ImageIndex = node.SelectedImageIndex = 6;
            else if (extension.StartsWith( ".xml" ))
                node.ImageIndex = node.SelectedImageIndex = 4;
            else if (extension.StartsWith( ".as" ))
                node.ImageIndex = node.SelectedImageIndex = 2;
            else if (extension.StartsWith( ".ppt" ))
                node.ImageIndex = node.SelectedImageIndex = 10;
            else if (parentNode != null)
            {
                if (parentNode.Text == @"source" || parentNode.Text == @"out")
                    node.ImageIndex = node.SelectedImageIndex = 2;
                else if (parentNode.Text == @"doc")
                    node.ImageIndex = node.SelectedImageIndex = 5;
                else if (parentNode.Text == @"reader")
                    node.ImageIndex = node.SelectedImageIndex = 3;
                else if (parentNode.Text == @"atml")
                    node.ImageIndex = node.SelectedImageIndex = 4;
                else if (isFile)
                    node.ImageIndex = node.SelectedImageIndex = 9;
            }
            else if (isFile)
                node.ImageIndex = node.SelectedImageIndex = 9;
            else if (isDirectory)
                node.ImageIndex = node.SelectedImageIndex = 0;
        }

        private void renameLabel_Click( object sender, EventArgs e )
        {
            if (testSetNavigationTree.SelectedNode != null)
            {
                testSetNavigationTree.SelectedNode.BeginEdit();
            }
        }

        private void deleteLabel_Click( object sender, EventArgs e )
        {
            if (_selectedNodes.Count > 0)
            {
                TreeNode[] list = _selectedNodes.ToArray();
                foreach (TreeNode selectedNode in list)
                {
                    DeleteFile( selectedNode );
                }
            }
            else
            {
                DeleteFile( testSetNavigationTree.SelectedNode );
            }
        }

        private void DeleteFile( TreeNode node )
        {
            if (node.Tag is FileInfo)
            {
                var fi = node.Tag as FileInfo;
                if (_navigator.DeleteFile( fi ))
                {
                    testSetNavigationTree.Nodes.Remove( node );
                    _selectedNodes.Remove( node );
                }
            }
        }

        private void openLabel_Click( object sender, EventArgs e )
        {
            _navigator.SelectTreeDocument();
        }

        private void LoadTree()
        {
            if (!string.IsNullOrEmpty( _testProgramSetName ))
            {
                if (_fileSystemWatcher != null)
                {
                    _fileSystemWatcher.EnableRaisingEvents = false;
                }
                testSetNavigationTree.Nodes.Clear();
                var testPathDir = new DirectoryInfo( ATMLContext.TESTSET_PATH );
                foreach (DirectoryInfo testSetDir in testPathDir.GetDirectories( _testProgramSetName ))
                {
                    var node = new TreeNode( testSetDir.Name );
                    node.Name = testSetDir.Name;
                    node.Tag = testSetDir;
                    testSetNavigationTree.Nodes.Add( node );
                    AddFolderToTree( testSetDir, node );
                }
                AddFilesToTree( testPathDir, null );
                testSetNavigationTree.ExpandAll();
                _testProgramPath = Path.Combine( testPathDir.FullName, _testProgramSetName );
                _fileSystemWatcher = new FileSystemWatcher(_testProgramPath );
                _fileSystemWatcher.NotifyFilter = NotifyFilters.FileName;
                _fileSystemWatcher.Filter = "*.*";
                _fileSystemWatcher.IncludeSubdirectories = true;
                _fileSystemWatcher.Created += _fileSystemWatcher_Created;
                _fileSystemWatcher.Deleted +=FileSystemWatcherOnDeleted;
                _fileSystemWatcher.EnableRaisingEvents = true;
            }
        }


        private delegate void FileSystemWatcherCallback(object sender, FileSystemEventArgs e);
        private void FileSystemWatcherOnDeleted( object sender, FileSystemEventArgs e )
        {
            try
            {
                if (InvokeRequired)
                {
                    FileSystemWatcherCallback d = FileSystemWatcherOnDeleted;
                    Invoke( d, new[] {sender, e} );
                }
                else
                {
                    if (e.ChangeType == WatcherChangeTypes.Deleted)
                    {
                        FileInfo fi = new FileInfo( e.FullPath );
                        if (fi.Directory != null)
                        {
                            string folderName = fi.Directory.Name;
                            TreeNode node = FindFolder( folderName );
                            if (node != null)
                            {
                                node = FindNodeByFileName( node.Nodes, fi.Name );
                                if (node != null)
                                    node.Remove();
                            }
                        }
                    }
                }
            }
            catch (Exception err )
            {
                LogManager.Error( err );
            }
        }


        void _fileSystemWatcher_Created(object sender, FileSystemEventArgs e)
        {
            if (e.ChangeType == WatcherChangeTypes.Created)
            {
                FileInfo fi = new FileInfo(e.FullPath);
                if (fi.Directory != null)
                {
                    string folderName = fi.Directory.Name;
                    TreeNode node = FindFolder( folderName );
                    if (node != null)
                    {
                        if( FindNodeByFileName( node.Nodes, e.Name ) == null )
                            AddNode( node, fi );
                    }
                }
            }
        }

        private void AddFolderToTree( DirectoryInfo testSetDir, TreeNode node )
        {
            //-------------------//
            //--- Add Subdirs ---//
            //-------------------//
            foreach (DirectoryInfo subDir in testSetDir.GetDirectories())
            {
                var subNode = new TreeNode( subDir.Name );
                subNode.Name = subDir.Name;
                subNode.Tag = subDir;
                node.Nodes.Add( subNode );
                AddFolderToTree( subDir, subNode );
            }

            AddFilesToTree( testSetDir, node );
        }

        private void AddFilesToTree( DirectoryInfo testSetDir, TreeNode parentNode )
        {
            //-----------------//
            //--- Add Files ---//
            //-----------------//
            foreach (FileInfo fi in testSetDir.GetFiles())
            {
                string extension = fi.Extension;
                var node = new TreeNode( fi.Name );
                node.Name = fi.Name;
                node.Tag = fi;
                SetTreeNodeImage( extension, node, parentNode );
                if (parentNode == null)
                    testSetNavigationTree.Nodes.Add( node );
                else
                    parentNode.Nodes.Add( node );
            }
        }

        /**
         * Called when the Refresh button is pressed. This forces the navigation tree to be reloaded.
         */

        private void btnRefresh_Click( object sender, EventArgs e )
        {
            LoadTree();
        }

        private void testSetNavigationTree_BeforeSelect( object sender, TreeViewCancelEventArgs e )
        {
            var fi = e.Node.Tag as FileInfo;
            var di = e.Node.Tag as DirectoryInfo;
            bool ctrlKey = ( ModifierKeys == Keys.Control );
            bool shftKey = ( ModifierKeys == Keys.ShiftKey );
            RemovedPaintedNodes();
            if (!ctrlKey && !shftKey && _selectedNodes.Count > 0)
                _selectedNodes.RemoveRange( 0, _selectedNodes.Count );

            if (ctrlKey && _selectedNodes.Contains( e.Node ))
            {
                e.Cancel = true;
                _selectedNodes.Remove( e.Node );
            }
            else
            {
                _lastTreeNode = e.Node;
                if (!shftKey)
                {
                    _firstTreeNode = e.Node;
                    RemovedPaintedNodes();
                }
            }
            PaintSelectedNodes();
        }

        private void testSetNavigationTree_AfterSelect( object sender, TreeViewEventArgs e )
        {
            var fi = e.Node.Tag as FileInfo;
            var di = e.Node.Tag as DirectoryInfo;
            bool ctrlKey = ModifierKeys == Keys.Control;
            bool shftKey = ModifierKeys == Keys.ShiftKey;
            if (ctrlKey)
                ProcessControlSelectedTreeKeys( e );
            else if (shftKey)
                ProcessShiftSelectedTreeKeys( e );
            else
                ProcessSingleSelectedTreeNode( e );
            _navigator.SelectedFile = _firstTreeNode.Tag as FileInfo;
        }

        private void ProcessSingleSelectedTreeNode( TreeViewEventArgs e )
        {
            RemovedPaintedNodes();
            if (_selectedNodes.Count > 0)
                _selectedNodes.RemoveRange( 0, _selectedNodes.Count );
            TreeNode node = testSetNavigationTree.SelectedNode;
            if (node.Tag is FileInfo)
            {
                _selectedNodes.Add( e.Node );
                //_navigator.SelectedFile = (FileInfo) node.Tag;
                if (node.Parent != null)
                    _navigator.SelectedFolder = (DirectoryInfo) node.Parent.Tag;
            }
            else if (node.Tag is DirectoryInfo)
            {
                _navigator.SelectedFolder = (DirectoryInfo) node.Tag;
            }
            PaintSelectedNodes();
        }

        private void ProcessControlSelectedTreeKeys( TreeViewEventArgs e )
        {
            if (!_selectedNodes.Contains( e.Node )) // new node ?
            {
                _selectedNodes.Add( e.Node );
            }
            else // not new, remove it from the collection
            {
                RemovedPaintedNodes();
                _selectedNodes.Remove( e.Node );
            }
            PaintSelectedNodes();
        }

        private void ProcessShiftSelectedTreeKeys( TreeViewEventArgs e )
        {
        }


        private void testSetNavigationTree_MouseDoubleClick( object sender, MouseEventArgs e )
        {
            _navigator.SelectTreeDocument();
        }

        private void testSetNavigationTree_AfterLabelEdit( object sender, NodeLabelEditEventArgs e )
        {
            var fi = e.Node.Tag as FileInfo;
            var di = e.Node.Tag as DirectoryInfo;
            if (null != fi
                && !string.IsNullOrWhiteSpace( fi.DirectoryName )
                && !string.IsNullOrWhiteSpace( e.Label ))
            {
                string oldName = fi.Name;
                string fullName = Path.Combine( fi.DirectoryName, e.Label );
                fi.MoveTo( fullName );
                LogManager.Info( "Renamed file from: {0} to: {1} ", oldName, e.Label );
            }
            else if (di != null
                     && !string.IsNullOrWhiteSpace( e.Label )
                     && !string.IsNullOrWhiteSpace( di.FullName )
                     && e.Node.Parent == null) //Only allow rename folder on root node
            {
                //Send Rename Project Message with DirectoryInfo data
                _navigator.RenameProject( di, e.Label, e );
            }
        }

        private void testSetNavigationTree_AfterCollapse( object sender, TreeViewEventArgs e )
        {
            TreeNode node = e.Node;
            node.ImageIndex = 0;
            node.SelectedImageIndex = 0;
        }

        private void testSetNavigationTree_AfterExpand( object sender, TreeViewEventArgs e )
        {
            TreeNode node = e.Node;
            node.ImageIndex = 1;
            node.SelectedImageIndex = 1;
        }

        public TreeNode FindFolder( string name )
        {
            TreeNode foundNode = null;
            TreeNode[] nodes = testSetNavigationTree.Nodes.Find( name, true );
            foreach (TreeNode node in nodes)
            {
                if (node.Tag is DirectoryInfo)
                {
                    foundNode = node;
                    break;
                }
            }
            return foundNode;
        }

        private void testSetNavigationTree_MouseUp( object sender, MouseEventArgs e )
        {
            var p = new Point( e.X, e.Y );
            TreeNode node = testSetNavigationTree.GetNodeAt( p );
            //if (testSetNavigationTree.SelectedNode != null)
            if (node != null)
            {
                object tag = node.Tag; // testSetNavigationTree.SelectedNode.Tag;
                _addFilesLabel.Visible = ( tag is DirectoryInfo );
//                _createAbfFile.Visible = ( tag is DirectoryInfo && ( (DirectoryInfo) tag ).Name.Equals( "source" ) );
                _openLabel.Visible = ( tag is FileInfo );
                _deleteLabel.Visible = ( tag is FileInfo );
                _renameLabel.Visible = ( tag is FileInfo );
            }
        }

        private void testSetNavigationTree_ItemDrag( object sender, ItemDragEventArgs e )
        {
            if (e.Item is TreeNode)
            {
                var sourceNode = e.Item as TreeNode;
                if (sourceNode.Tag is FileInfo)
                {
                    DoDragDrop( e.Item, DragDropEffects.Move );
                }
            }
        }

        private void testSetNavigationTree_DragEnter( object sender, DragEventArgs e )
        {
            e.Effect = DragDropEffects.Move;
        }

        private void testSetNavigationTree_DragDrop( object sender, DragEventArgs e )
        {
            // Retrieve the client coordinates of the drop location.
            Point targetPoint = testSetNavigationTree.PointToClient( new Point( e.X, e.Y ) );

            // Retrieve the node at the drop location.
            TreeNode targetNode = testSetNavigationTree.GetNodeAt( targetPoint );

            // Retrieve the node that was dragged.
            var draggedNode = (TreeNode) e.Data.GetData( typeof (TreeNode) );

            // Confirm that the node at the drop location is not 
            // the dragged node and that target node isn't null
            // (for example if you drag outside the control)
            if (!draggedNode.Equals( targetNode ) && targetNode != null)
            {
                //--------------------------------//
                //--- Physically move the file ---//
                //--------------------------------//
                var tag = targetNode.Tag as DirectoryInfo;
                if (tag != null)
                {
                    if (draggedNode.Tag is FileInfo)
                    {
                        bool okToDrop = true;
                        string targetFileName = Path.Combine( tag.FullName,
                                                              ( (FileInfo) draggedNode.Tag ).Name );
                        bool targetExists = File.Exists( targetFileName );
                        if (targetExists)
                        {
                            string message = "File \"{0}\" aready exists, would you like to overwrite it?";
                            okToDrop = DialogResult.Yes == MessageBox.Show( string.Format( message, targetFileName ),
                                                                            @"V E R I F Y",
                                                                            MessageBoxButtons.YesNo,
                                                                            MessageBoxIcon.Question );
                        }

                        if (okToDrop)
                        {
                            var fi = new FileInfo( targetFileName );
                            if (fi.Exists)
                            {
                                fi.IsReadOnly = false;
                                fi.Delete();
                            }
                            File.Move( ( (FileInfo) draggedNode.Tag ).FullName, targetFileName );
                            draggedNode.Tag = new FileInfo( targetFileName );
                            // Remove the node from its current 
                            // location and add it to the node at the drop location.
                            draggedNode.Remove();
//targetNode.Nodes.Add( draggedNode );

                            // Expand the node at the location 
                            // to show the dropped node.
                            targetNode.Expand();

                            //Reload tree for now to remove existing node for same file
                            if (targetExists)
                                LoadTree();
                        }
                    }
                }
            }
        }

        private void testSetNavigationTree_DragOver( object sender, DragEventArgs e )
        {
            Point targetPoint = testSetNavigationTree.PointToClient( new Point( e.X, e.Y ) );

            // Retrieve the node at the drop location.
            TreeNode targetNode = testSetNavigationTree.GetNodeAt( targetPoint );

            e.Effect = DragDropEffects.None;
            if (targetNode != null && targetNode.Tag is DirectoryInfo)
                e.Effect = DragDropEffects.Move;
        }

        private void ATMLNavigationWindow_HelpButtonClicked( object sender, CancelEventArgs e )
        {
        }

        private void ATMLNavigationWindow_HelpRequested( object sender, HelpEventArgs hlpevent )
        {
            ATMLContext.ShowHelp( this, "Project Navigator" );
        }

        private void testSetNavigationTree_BeforeLabelEdit( object sender, NodeLabelEditEventArgs e )
        {
            //-------------------------------------------------------------------------------------//
            //--- Do not allow folders to be renamed if they are not the root (project) folder. ---//
            //-------------------------------------------------------------------------------------//
            var di = e.Node.Tag as DirectoryInfo;
            if (di != null && e.Node.Parent != null)
                e.CancelEdit = true;
        }

        private delegate void AddNodeCallback( TreeNode parentNode, FileInfo fi );
    }
}