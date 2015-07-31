/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
* 
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Xml;
using ATML1671Translator.translator;
using ATMLCommonLibrary.forms;
using ATMLCommonLibrary.utils;
using ATMLDataAccessLibrary.db.beans;
using ATMLDataAccessLibrary.db.daos;
using ATMLManagerLibrary.managers;
using ATMLUtilitiesLibrary;

namespace ATML1671Translator.forms
{
    public partial class ATMLSignalMappingForm : ATMLForm
    {
        private List<string> _usedSignalList;

        public ATMLSignalMappingForm(List<string> usedSignalList)
        {
            InitializeComponent();
            _usedSignalList = usedSignalList;
            cmbSourceType.SelectedIndex = 0;
            signalModelLibrary.IncludeAttributes = true;
            InitMappedSignals();
            Saved += OnSaved;
        }

        private void InitMappedSignals()
        {
            var hiddenColumns = new[] { 0, 1, 5, 6, 7, 8, 9, 10 };
            var signalMappingDao = new SignalMappingDAO();
            List<SourceSignalMapBean> sourceSignals = signalMappingDao.GetSourceSignals( "ATLAS" );
            List<SourceSignalMapBean> filteredSourceSignals = new List<SourceSignalMapBean>();
            foreach (SourceSignalMapBean bean in sourceSignals)
            {
                if (_usedSignalList.Contains( bean.sourceName )) 
                    filteredSourceSignals.Add( bean );
            }

            mappedSignals.DataSource = filteredSourceSignals; //sourceSignals;
            foreach (int hiddenColumn in hiddenColumns)
                mappedSignals.Columns[hiddenColumn].Visible = false;
            mappedSignals.Columns[2].DefaultCellStyle.BackColor = Color.Honeydew;
            mappedSignals.Columns[2].ReadOnly = true;
            mappedSignals.Columns[2].HeaderText = @"Source Name";
            mappedSignals.Columns[3].HeaderText = @"Target Type";
            mappedSignals.Columns[4].HeaderText = @"Target Name";
            mappedSignals.RowEnter += MappedSignalsOnRowEnter;
            mappedSignals.RowLeave += MappedSignalsOnRowLeave;
            mappedSignals.RowValidating += MappedSignalsOnRowValidating;
            ResizeMappedSignals();
        }

        private void MappedSignalsOnRowValidating( object sender, DataGridViewCellCancelEventArgs dataGridViewCellCancelEventArgs )
        {
            
        }

        private void MappedSignalsOnRowLeave( object sender, DataGridViewCellEventArgs dataGridViewCellEventArgs )
        {
        }

        public XmlDocument TreeModel
        {
            set { signalModelLibrary.TreeModel = value; }
        }

        public List<string> UsedSignalList { set; get; }

        private XmlElement DetermineBestModelForSelectedSignal(string sourceSignalName)
        {
            XmlElement bestMatch = null;
            double bestRate = 0d;
            List<string> sourceAttributes = new List<string>();
            foreach (DataGridViewRow row in mappedSignalAttributes.Rows)
            {
                object val = row.Cells[2].Value;
                if (val != null)
                {
                    string source = val.ToString().ToLower().Replace( "-", " " ).Replace( "_", " " );
                    if ("voltage".Equals( source ))
                    {
                        if (mappedSignals.SelectedRows.Count > 0)
                        {
                            
                            if (sourceSignalName.Contains( "DC" ))
                                source = "dc ampl";
                            else if (sourceSignalName.Contains( "AC" ))
                                source = "ac ampl";
                            else
                                source = "ampl";
                        }
                    }
                    sourceAttributes.Add( source );
                }
            }
            XmlDocument model = signalModelLibrary.TreeModel;
            XmlElement tsf = model.DocumentElement;
            foreach (XmlNode tsfNode in tsf.ChildNodes)
            {
                XmlElement tsfLibrary = tsfNode as XmlElement;
                if (tsfLibrary != null)
                {
                    foreach (XmlNode signalNode in tsfLibrary.ChildNodes)
                    {
                        XmlElement signal = signalNode as XmlElement;
                        if (signal != null)
                        {
                            List<string> targetAttributes = new List<string>();
                            foreach (XmlAttribute attribute in signal.Attributes)
                            {
                                string name = attribute.Name.ToLower().Replace( "-", " " ).Replace( "_", " " );
                                if (!name.Equals( "id" ) && !name.Equals( "xmlns" ) && !name.Equals( "uuid" ))
                                    targetAttributes.Add( name );
                            }
                            int totalMatches = 0;
                            foreach (string sourceAttribute in sourceAttributes)
                            {
                                if (targetAttributes.Contains( sourceAttribute ))
                                    totalMatches += 1;
                            }

                            //Console.WriteLine( @"Library: {0} Signal: {1} matches {2} out of {3}", tsfLibrary.Name, signal.Name, totalMatches, sourceAttributes.Count );
                            if (sourceAttributes.Count > 0)
                            {
                                double rate = (double) totalMatches/(double) sourceAttributes.Count;
                                if (rate > bestRate)
                                {
                                    bestRate = rate;
                                    bestMatch = signal;
                                }
                            }
                        }
                    }

                }
            }
            return bestMatch;
        }


        private void OnSaved( object sender, EventArgs eventArgs )
        {
            SaveMappedSignals();
            SaveMappedAttributes();
            LogManager.SourceInfo(ATMLTranslator.SOURCE, "Signal Mapping Saved");
        }

        private void SaveMappedSignals()
        {
            foreach (DataGridViewRow row in mappedSignals.Rows)
            {
                var bean = row.DataBoundItem as SourceSignalMapBean;
                DataGridViewCell cell = row.Cells["targetName"];
                if (bean != null && IsCellDirty( cell ))
                {
                    bean.DataState = BASEBean.eDataState.DS_EDIT;
                    bean.save();
                }
            }
        }

        private void SaveMappedAttributes()
        {
            foreach (DataGridViewRow row in mappedSignalAttributes.Rows)
            {
                var bean = row.DataBoundItem as SourceSignalAttributeMapBean;
                DataGridViewCell cell = row.Cells["targetName"];
                if (bean != null && IsCellDirty( cell ))
                {
                    bean.DataState = BASEBean.eDataState.DS_EDIT;
                    bean.save();
                }
            }
        }

        private void MappedSignalsOnRowEnter( object sender, DataGridViewCellEventArgs dataGridViewCellEventArgs )
        {
            //signalModelLibrary.ResetBackColors(Color.White);
            signalModelLibrary.ResetImages( 0 );
            int idxOld = -1;
            if (mappedSignals.CurrentRow != null)
            {
                idxOld = mappedSignals.CurrentRow.Index;
                SaveMappedAttributes();
            }
            int idx = dataGridViewCellEventArgs.RowIndex;
            string signalName = mappedSignals.Rows[idx].Cells[2].Value.ToString();
            string targetName = mappedSignals.Rows[idx].Cells[4].Value!=null?mappedSignals.Rows[idx].Cells[4].Value.ToString():null;
            TreeNode selectedSignalModelNode = null;
            if (idx != idxOld)
            {
                var bean = mappedSignals.Rows[idx].DataBoundItem as SourceSignalMapBean;
                if (bean != null)
                {
                    selectedSignalModelNode = signalModelLibrary.FindNode( "TSF", bean.targetType, bean.targetName );
                    if (selectedSignalModelNode != null)
                    {
                        signalModelLibrary.SelectedNode = selectedSignalModelNode;
                        signalModelLibrary.SelectedNode.SelectedImageIndex = 1;
                        signalModelLibrary.SelectedNode.ImageIndex = 1;
                    }
                    var signalMappingDao = new SignalMappingDAO();
                    var hiddenColumns = new[] {0, 1, 3, 4, 5, 6, 12, 13, 14, 15, 16, 17};
                    mappedSignalAttributes.DataSource = signalMappingDao.GetSignalAttributes( bean.id );
                    foreach (int hiddenColumn in hiddenColumns)
                        mappedSignalAttributes.Columns[hiddenColumn].Visible = false;

                    mappedSignalAttributes.Columns[2].DefaultCellStyle.BackColor = Color.Honeydew;
                    mappedSignalAttributes.Columns[2].ReadOnly = true;
                    mappedSignalAttributes.Columns[2].HeaderText = @"Source Name";
                    mappedSignalAttributes.Columns[3].HeaderText = @"Source Type";
                    mappedSignalAttributes.Columns[4].HeaderText = @"Source Default";
                    mappedSignalAttributes.Columns[5].HeaderText = @"Source Suffix";
                    mappedSignalAttributes.Columns[6].HeaderText = @"Source Unit";
                    mappedSignalAttributes.Columns[7].HeaderText = @"Target Name";
                    mappedSignalAttributes.Columns[8].HeaderText = @"Target Type";
                    mappedSignalAttributes.Columns[9].HeaderText = @"Target Default";
                    mappedSignalAttributes.Columns[10].HeaderText = @"Target Suffix";
                    mappedSignalAttributes.Columns[11].HeaderText = @"Target Unit";
                    mappedSignalAttributes.CellLeave += mappedSignalAttributes_CellEndEdit;
                    //--- Save original Values ---//
                    foreach (DataGridViewRow row in mappedSignalAttributes.Rows)
                    {
                        foreach (DataGridViewCell cell in row.Cells)
                        {
                            if (cell != null)
                                cell.Tag = cell.Value as string;
                        }
                    }
                }
                if (string.IsNullOrEmpty(targetName) || selectedSignalModelNode==null)
                {
                    XmlElement bestMatch = DetermineBestModelForSelectedSignal( signalName );
                    if (bestMatch != null)
                    {
                        TreeNode node = signalModelLibrary.FindNodeByTagValue( bestMatch );
                        if (node != null)
                        {
                            //node.BackColor = Color.GreenYellow;
                            node.ImageIndex = 1;
                            node.SelectedImageIndex = 1;
                        }
                    }
                }
            }
        }

        private void mappedSignalAttributes_CellEndEdit( object sender, DataGridViewCellEventArgs e )
        {
            DataGridViewCell cell = mappedSignalAttributes.Rows[e.RowIndex].Cells[e.ColumnIndex];
            cell.Style.ForeColor = IsCellDirty( cell ) ? Color.Blue : Color.Black;
        }

        private bool IsCellDirty(DataGridViewCell cell)
        {
            bool isDirty = false;
            if (cell != null)
            {
                var oldText = cell.Tag as string;
                if (cell.EditedFormattedValue != null)
                {
                    string newText = cell.EditedFormattedValue.ToString();
                    isDirty = !newText.Equals(oldText);
                }
            }
            return isDirty;

        }

        private void mappedSignalAttributes_DragDrop( object sender, DragEventArgs e )
        {
            var dscreen = new Point( e.X, e.Y );
            Point dclient = mappedSignalAttributes.PointToClient( dscreen );
            DataGridView.HitTestInfo hit = mappedSignalAttributes.HitTest( dclient.X, dclient.Y );
            if (hit.Type == DataGridViewHitTestType.Cell)
            {
                DataGridViewCell cell = mappedSignalAttributes.Rows[hit.RowIndex].Cells[hit.ColumnIndex];
                var oldText = cell.Value as string;
                var bean = mappedSignalAttributes.Rows[hit.RowIndex].DataBoundItem as SourceSignalAttributeMapBean;
                if (bean != null)
                {
                    string data = e.Data.GetData(DataFormats.Text).ToString();
                    string[] parts = data.Split('|');
                    bean.targetName = parts[1];
                    mappedSignalAttributes.InvalidateRow( hit.RowIndex );
                    mappedSignalAttributes.Update();
                    cell.Style.ForeColor = bean.targetName.Equals(oldText) ? Color.Black : Color.Blue;
                }
            }
        }

        private void signalModelLibrary_MouseDown( object sender, MouseEventArgs e )
        {
            TreeNode node = signalModelLibrary.GetNodeAt( e.X, e.Y );
            if (node != null
                && node.Parent != null
                && node.Parent.Tag is XmlElement )
            {
                XmlElement parent = node.Parent.Tag as XmlElement;
                string data = parent.LocalName + "|" + node.Text;
                signalModelLibrary.SelectedNode = node;
                signalModelLibrary.DoDragDrop(data, DragDropEffects.Copy);
            }
        }

        private void mappedSignalAttributes_DragEnter( object sender, DragEventArgs e )
        {
            e.Effect = e.Data.GetDataPresent( DataFormats.Text ) ? DragDropEffects.Copy : DragDropEffects.None;
        }

        private void mappedSignals_Resize(object sender, EventArgs e)
        {
            ResizeMappedSignals();
        }

        private void ResizeMappedSignals()
        {
            if (mappedSignals.ColumnCount > 0)
            {
                int a = mappedSignals.Columns[2].Width = (int) ( mappedSignals.Width*.35 );
                int b = mappedSignals.Columns[3].Width = (int) ( mappedSignals.Width*.20 );
                mappedSignals.Columns[4].Width = mappedSignals.Width - ( a + b + 2 );
            }
        }

        private void mappedSignalAttributes_Resize(object sender, EventArgs e)
        {

        }

        private void mappedSignals_DragDrop(object sender, DragEventArgs e)
        {
            var dscreen = new Point(e.X, e.Y);
            Point dclient = mappedSignals.PointToClient(dscreen);
            DataGridView.HitTestInfo hit = mappedSignals.HitTest(dclient.X, dclient.Y);
            if (hit.Type == DataGridViewHitTestType.Cell)
            {
                DataGridViewCell cell = mappedSignals.Rows[hit.RowIndex].Cells[hit.ColumnIndex];
                var oldText = cell.Value as string;
                var bean = mappedSignals.Rows[hit.RowIndex].DataBoundItem as SourceSignalMapBean;
                if (bean != null)
                {
                    string data = e.Data.GetData(DataFormats.Text).ToString();
                    string[] parts = data.Split( '|' );
                    bean.targetType = parts[0];
                    bean.targetName = parts[1];
                    mappedSignals.InvalidateRow(hit.RowIndex);
                    mappedSignals.Update();
                    cell.Style.ForeColor = bean.targetName.Equals(oldText) ? Color.Black : Color.Blue;
//                    cell = mappedSignals.Rows[hit.RowIndex].Cells[hit.ColumnIndex-1];
//                    cell.Style.ForeColor = bean.targetName.Equals(oldText) ? Color.Black : Color.Blue;
                    TreeNode node = signalModelLibrary.SelectedNode;
                    if (node != null)
                    {
                        foreach (TreeNode child in node.Nodes)
                        {
                            string text = child.Text.ToLower().Replace( "-"," " ).Replace( "_", " " );
                            foreach (DataGridViewRow row in mappedSignalAttributes.Rows)
                            {
                                string source = row.Cells[2].Value as string;
                                if (source != null)
                                {
                                    if (text.Equals( source.ToLower().Replace( "-", " " ).Replace( "_", " " ) ))
                                        row.Cells[7].Value = child.Text;
                                }
                            }


                        }
                    }

                }
            }
        }

        private void mappedSignals_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = e.Data.GetDataPresent(DataFormats.Text) ? DragDropEffects.Copy : DragDropEffects.None;
        }

        private void signalModelLibrary_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }
    }
}