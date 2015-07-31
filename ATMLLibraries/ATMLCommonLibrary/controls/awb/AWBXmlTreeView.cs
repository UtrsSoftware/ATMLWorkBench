/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
* 
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Xml;

namespace ATMLCommonLibrary.controls.awb
{
    public partial class AWBXmlTreeView : TreeView
    {
        private XmlDocument _treeModel;

        public bool IncludeAttributes { set; get; }

        public AWBXmlTreeView()
        {
            InitializeComponent();
        }

        protected override void OnBeforeSelect( TreeViewCancelEventArgs e )
        {
            base.OnBeforeSelect( e );
            TreeNode node = e.Node;
            XmlElement el = node.Tag as XmlElement;
            if (el != null)
            {
                if (node.Nodes.Count == 0)
                {
                    if (IncludeAttributes)
                        AddElementAttributes(el, node);
                }
            }

        }

        public AWBXmlTreeView( IContainer container )
        {
            container.Add( this );
            InitializeComponent();
        }

        private void ProcessTreeNode( XmlNode parentNode, TreeNode parentTreeNode )
        {
            var element = parentNode as XmlElement;
            if ( element != null )
            {
                var tn = new TreeNode( element.Name );
                tn.Tag = element;
                if (parentTreeNode == null)
                    Nodes.Add( tn );
                else
                    parentTreeNode.Nodes.Add( tn );
                foreach (XmlNode childNode in element.ChildNodes)
                {
                    ProcessTreeNode( childNode, tn );
                }

                if (IncludeAttributes)
                    AddElementAttributes(element, tn);
            }
        }


        private static void SortAttributes( XmlAttribute[] attributes )
        {
            int len = attributes.Length;
            if (len > 2)
            {
                XmlAttribute temp = attributes[0];
                for (int i = 0; i < len; i++)
                {
                    for (int j = i + 1; j < len; j++)
                    {
                        if (attributes[i].LocalName.CompareTo( attributes[j].LocalName ) > 0)
                        {
                            temp = attributes[i];
                            attributes[i] = attributes[j];
                            attributes[j] = temp;
                        }
                    }
                }
            }
        }

        private static void AddElementAttributes( XmlNode parentNode, TreeNode tn )
        {
            if (parentNode.Attributes != null)
            {
                XmlAttribute[] array = new XmlAttribute[parentNode.Attributes.Count];
                parentNode.Attributes.CopyTo( array, 0 );
                SortAttributes(array);
                foreach (XmlAttribute xmlAttribute in array )
                {
                    if (!"xmlns, id, uuid".Contains( xmlAttribute.LocalName ))
                    {
                        var tnAttribute = new TreeNode( xmlAttribute.LocalName );
                        tnAttribute.Tag = xmlAttribute;
                        tn.Nodes.Add( tnAttribute );
                    }
                }
            }
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
                        ProcessTreeNode(node, null);
                    }

                    if (Nodes.Count > 0 )
                        Nodes[0].Expand();
                    
                }
            }
        }


        public void ResetBackColors( Color color, TreeNode parent = null )
        {
            TreeNodeCollection nodes = Nodes;
            if (parent != null)
            {
                nodes = parent.Nodes;
                parent.BackColor = color;
            }
            foreach (TreeNode treeNode in nodes)
            {
                treeNode.BackColor = color;
                ResetBackColors(color, treeNode);
            }
        }

        public void ResetImages(int idx, TreeNode parent = null)
        {
            TreeNodeCollection nodes = Nodes;
            if (parent != null)
            {
                parent.ImageIndex = idx;
                parent.SelectedImageIndex = idx;
                nodes = parent.Nodes;
            }
            foreach (TreeNode treeNode in nodes)
            {
                treeNode.ImageIndex = idx;
                treeNode.SelectedImageIndex = idx;
                ResetImages(idx, treeNode);
            }
        }

        public TreeNode FindNodeByTagValue( object value, TreeNode parent = null )
        {
            TreeNode selected = null;
            TreeNodeCollection nodes = Nodes;
            if (parent != null)
            {
                nodes = parent.Nodes;
            }
            foreach (TreeNode treeNode in nodes)
            {
                if (value.Equals( treeNode.Tag ))
                {
                    selected = treeNode;
                    break;
                }

                selected = FindNodeByTagValue( value, treeNode );
                if( selected != null )
                    break;
            }
            return selected;
        }

        public TreeNode FindNode( params string[] values )
        {
            TreeNode foundNode = null;
            int i = 0;
            TreeNodeCollection nodes = Nodes;
            foreach (string value in values)
            {
                foundNode = FindNodeByValue( nodes, value );
                if (foundNode!=null)
                {
                    nodes = foundNode.Nodes;
                }
            }
            return foundNode;
        }

        private TreeNode FindNodeByValue( TreeNodeCollection nodes, string value )
        {
            TreeNode foundNode = null;
            foreach (TreeNode node in nodes)
            {
                if (node.Text.Equals(value))
                {
                    foundNode = node;
                    break;
                }
            }
            return foundNode;
        }



    }
}