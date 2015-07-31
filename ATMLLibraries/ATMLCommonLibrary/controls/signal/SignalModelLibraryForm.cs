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
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using ATMLCommonLibrary.controls.trigger;
using ATMLCommonLibrary.model;
using ATMLCommonLibrary.Properties;
using ATMLCommonLibrary.utils;
using ATMLDataAccessLibrary.db.beans;
using ATMLDataAccessLibrary.db.daos;
using ATMLDataAccessLibrary.managers;
using ATMLDataAccessLibrary.model;
using ATMLManagerLibrary.managers;
using ATMLModelLibrary.model.signal;
using ATMLModelLibrary.model.signal.basic;
using ATMLSignalModelLibrary.signal;
using WeifenLuo.WinFormsUI.Docking;

namespace ATMLCommonLibrary.controls.signal
{
    public partial class SignalModelLibraryForm : DockContent, IATMLDockableWindow
    {
        private const int WM_SETREDRAW = 0x000B;
        private SignalModelLibrary _signalModelLibrary;
        private static Color INPUT_COLOR = Color.Yellow;
        private static Color RELATED_COLOR = Color.YellowGreen;
        private static Color NORMAL_COLOR = Color.White;

        public SignalModelLibraryForm()
        {
            InitializeComponent();
        }

        public SignalModelLibrary SignalModelLibrary
        {
            get { return _signalModelLibrary; }
            set
            {
                _signalModelLibrary = value;
                DataToControls();
            }
        }

        public void CloseProject()
        {
            LogManager.Warn("CloseProject() not implemented in SignalModelLibraryForm");
        }

        private void DataToControls()
        {
            LoadSignalModelLibrary();
        }

        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, Int32 wMsg, bool wParam, Int32 lParam);

        private void LoadSignalModelLibrary()
        {
            if (_signalModelLibrary != null)
            {
                Cursor = Cursors.WaitCursor;
                lvSignals.Items.Clear();
                SendMessage(lvSignals.Handle, WM_SETREDRAW, false, 0);
                edtUUID.Text = _signalModelLibrary.TSFLibrary.uuid;
                edtTargetNamespace.Text = _signalModelLibrary.TSFLibrary.targetNamespace;
                if (_signalModelLibrary.TSFLibrary.description.Text.Any())
                    edtDescription.Text = _signalModelLibrary.TSFLibrary.description.Text[0];
                foreach (SignalModel model in _signalModelLibrary.SignalModels.Values)
                {
                    var item = new ListViewItem(model.Name);
                    item.SubItems.Add(model.TSF.uuid);
                    item.Tag = model;
                    lvSignals.Items.Add(item);
                    if (lvSignals.Columns.Count >= 2)
                    {
                        lvSignals.Columns[0].Width = -1;
                        lvSignals.Columns[1].Width = -1;
                    }
                }
                SendMessage(lvSignals.Handle, WM_SETREDRAW, true, 0);
                lvSignals.Invalidate();
                Update();
                Cursor = Cursors.Default;
            }
        }

        private void lvSignals_SelectedIndexChanged(object sender, EventArgs e)
        {
            //HourGlass.Enabled = true;
            try
            {
                if (lvSignals.SelectedItems.Count > 0)
                {
                    var model = (SignalModel) lvSignals.SelectedItems[0].Tag;
                    if (model != null)
                    {
                        lvAttributes.Items.Clear();
                        List<SignalAttribute> attributes = model.Attributes;
                        foreach (SignalAttribute attribute in attributes)
                        {
                            var item = new ListViewItem(attribute.Name);
                            item.SubItems.Add(attribute.SchemaType);
                            item.SubItems.Add(attribute.DefaultValue);
                            item.Tag = attribute;
                            lvAttributes.Items.Add(item);
                        }

                        object itm = model.TSF.model.Item;
                        if (itm is Signal)
                        {
                            var signal = (Signal) itm;
                            lvModel.Items.Clear();
                            foreach (object obj in signal.Items)
                            {
                                XmlElement element = obj as XmlElement;
                                SignalFunction signalFunction = obj as SignalFunction;
                                if (signalFunction != null )
                                {
                                    var item = new ListViewItem(obj.GetType().Name);
                                    item.SubItems.Add(signalFunction.name);
                                    item.SubItems.Add(signalFunction.type);
                                    item.SubItems.Add(signalFunction.In);
                                    item.Tag = obj;
                                    lvModel.Items.Add(item);
                                }
                                else if (element != null )
                                {
                                    XmlAttribute nameAttribute = element.Attributes["name"];
                                    XmlAttribute typeAttribute = element.Attributes["type"];
                                    XmlAttribute inAttribute = element.Attributes["in"];
                                    var item = new ListViewItem(element.LocalName);
                                    item.SubItems.Add(nameAttribute==null?"":nameAttribute.Value);
                                    item.SubItems.Add(typeAttribute == null ? "" : typeAttribute.Value);
                                    item.SubItems.Add(inAttribute == null ? "" : inAttribute.Value);
                                    item.Tag = obj;
                                    lvModel.Items.Add(item);
                                }
                            }
                        }
                    }
                }
            }
            finally
            {
                //HourGlass.Enabled = false;
            }
        }

        private void btnSaveSignal_Click(object sender, EventArgs e)
        {
            SaveSelectedSignalModel();
        }

        private void SaveSelectedSignalModel()
        {
            HourGlass.Start();
            try
            {
                SignalDAO dao = DataManager.getSignalDAO();
                if (_signalModelLibrary != null)
                {
                    dao.DeleteTSFLibrary( _signalModelLibrary.TSFLibrary.uuid,
                                          _signalModelLibrary.TSFLibrary.targetNamespace );
                    var library = new dbTSFLibrary();
                    library.IncludeKeyOnInsert = true;
                    library.lastUpdate = DateTime.UtcNow;
                    library.id = Guid.Parse( _signalModelLibrary.TSFLibrary.uuid );
                    library.content = _signalModelLibrary.XmlContent;
                    library.targetNamespace = _signalModelLibrary.TSFLibrary.targetNamespace;
                    library.libraryName = _signalModelLibrary.TSFLibrary.name;
                    library.DataState = ( !dao.hasTSFLibrary( _signalModelLibrary.TSFLibrary.uuid ) )
                                            ? BASEBean.eDataState.DS_ADD
                                            : BASEBean.eDataState.DS_EDIT;
                    library.save();

                    foreach (SignalModel sm in _signalModelLibrary.SignalModels.Values)
                    {
                        TSFType tsf = sm.TSF;
                        dbSignal dataSignal = dao.getSignal( sm.Name, library.targetNamespace );
                        if (dataSignal == null)
                        {
                            //Add Signal to the database

                            string baseSignalName = sm.BaseSignalName;
                            dbSignal baseSignal = dao.getSignal( baseSignalName, sm.BaseSignalNameSpace );
                            dataSignal = new dbSignal();
                            dataSignal.ParentSignal = baseSignal;
                            dataSignal.signalName = sm.Name;
                            dataSignal.uuid = Guid.Parse(tsf.uuid);
                            dataSignal.xmlns = library.targetNamespace;
                            foreach (SignalAttribute attribute in sm.Attributes)
                            {
                                var a = new dbSignalAttribute();
                                a.attributeName = attribute.Name;
                                a.defaultValue = attribute.DefaultValue;
                                a.DataState = BASEBean.eDataState.DS_ADD;
                                a.type = attribute.SchemaType;
                                a.fixedValue = attribute.FixedValue;
                                if (dataSignal.Attributes == null )
                                    dataSignal.Attributes = new List<dbSignalAttribute>();
                                dataSignal.Attributes.Add( a );
                            }
                            dataSignal.DataState = BASEBean.eDataState.DS_ADD;
                        }
                        else
                        {
                            dataSignal.xmlns = library.targetNamespace;
                            dataSignal.uuid = Guid.Parse(tsf.uuid);
                            List<dbSignalAttribute> attributes = dataSignal.Attributes;
                            var attrMap = new Dictionary<string, SignalAttribute>();
                            var dbAttrMap = new Dictionary<string, dbSignalAttribute>();
                            foreach (SignalAttribute sa in sm.Attributes)
                                attrMap.Add( sa.Name, sa );

                            foreach (dbSignalAttribute dbAttribute in attributes)
                            {
                                string an = dbAttribute.attributeName;
                                dbAttrMap.Add( an, dbAttribute );
                                if (attrMap.ContainsKey( an ))
                                {
                                    SignalAttribute sa = attrMap[an];
                                    dbAttribute.type = sa.SchemaType;
                                    dbAttribute.defaultValue = sa.DefaultValue;
                                    dbAttribute.fixedValue = sa.FixedValue;
                                    dbAttribute.DataState = BASEBean.eDataState.DS_EDIT;
                                }
                                else
                                {
                                    dbAttribute.DataState = BASEBean.eDataState.DS_DELETE;
                                }
                            }

                            foreach (SignalAttribute sa in sm.Attributes)
                            {
                                if (!dbAttrMap.ContainsKey( sa.Name ))
                                {
                                    var dbAttribute = new dbSignalAttribute();
                                    dbAttribute.type = sa.SchemaType;
                                    dbAttribute.defaultValue = sa.DefaultValue;
                                    dbAttribute.fixedValue = sa.FixedValue;
                                    dbAttribute.DataState = BASEBean.eDataState.DS_ADD;
                                    dataSignal.Attributes.Add( dbAttribute );
                                }
                            }
                            dataSignal.DataState = BASEBean.eDataState.DS_EDIT;
                        }
                        dataSignal.xmlns = _signalModelLibrary.TSFLibrary.targetNamespace;
                        dataSignal.save();
                    }

                    foreach (ListViewItem item in lvSignals.Items)
                    {
                        var model = item.Tag as SignalModel;
                        if (model != null)
                        {
                            var signal = new dbTSFSignal();
                            signal.signalName = model.Name;
                            signal.id = Guid.Parse( model.TSF.uuid );
                            signal.signalContent = model.TSF.Serialize();
                            signal.libraryUuid = _signalModelLibrary.TSFLibrary.uuid;
                            signal.DataState = ( !dao.hasTSFSignal( model.TSF.uuid )
                                                     ? BASEBean.eDataState.DS_ADD
                                                     : BASEBean.eDataState.DS_EDIT );
                            signal.lastUpdate = DateTime.UtcNow;
                            try
                            {
                                signal.save();
                            }
                            catch (Exception e)
                            {
                                if (e.Message.ToLower().Contains( "duplicate" ))
                                {
                                    TestSignalBean otherSignal = dao.getTSFSignal( model.Name,
                                                                                   _signalModelLibrary.TSFLibrary.uuid );
                                    LogManager.Error( "UUID Conflict between document data and the database for Signal {0} in Signal Library {1} ",
                                                      model.Name, library.libraryName );
                                    if (otherSignal != null)
                                    {
                                        LogManager.Error( "\tDocument signal uuid {0}, Database signal uuid {{{1}}} ",
                                                          model.TSF.uuid, otherSignal.id.ToString().ToUpper() );

                                        if (dao.changeTSFSignalId( otherSignal.id, Guid.Parse(model.TSF.uuid) ))
                                        {
                                            LogManager.Info(
                                                "The Database signal uuid has been changed to reflect the Document signal uuid" );
                                            signal.DataState = BASEBean.eDataState.DS_EDIT;
                                            signal.save();
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                LogManager.Error( e, "An error has occured saving the signal model library: {0}", e.Message );
            }
            finally
            {
                HourGlass.Stop();
                if (_signalModelLibrary == null)
                {
                    MessageBox.Show(Resources.A_Signal_Model_must_be_selected_to_save_);
                }
                else
                {
                    LogManager.Trace(Resources.Completed_Saving_Selected_Signal_Model);
                    MessageBox.Show(Resources.Completed_Saving_Selected_Signal_Model);
                }
            }
        }

        private void SignalModelLibraryForm_Load(object sender, EventArgs e)
        {
            SignalDAO dao = DataManager.getSignalDAO();
            List<dbTSFLibrary> list = dao.getTSFLibraries();
            foreach (dbTSFLibrary library in list)
            {
                int idx = cmbLibraryName.Items.Add(new KeyValuePair<String, dbTSFLibrary>(library.libraryName, library));
            }
        }

        private void cmbLibraryName_SelectedIndexChanged(object sender, EventArgs e)
        {
            HourGlass.Enabled = true;
            try
            {
                if (cmbLibraryName.SelectedItem != null)
                {
                    try
                    {
                        var pair = (KeyValuePair<String, dbTSFLibrary>) cmbLibraryName.SelectedItem;
                        byte[] byteArray = Encoding.UTF8.GetBytes(pair.Value.content);
                        var stream = new MemoryStream(byteArray);
                        SignalModelLibrary = new SignalModelLibrary(stream);
                        Text = String.Format("Signal Model Library - {0}", SignalModelLibrary.TSFLibrary.name);
                    }
                    catch (Exception ee)
                    {
                        LogManager.Error(ee);
                        MessageBox.Show(@"An error occurred trying to opn this Signal Model Library");
                    }
                }
            }
            finally
            {
                HourGlass.Enabled = false;
            }
        }

        private void btnImportTSF_Click(object sender, EventArgs e)
        {
            String xml = "";
            String fileName = "";
            try
            {
                if (FileManager.OpenXmlFile(out xml, out fileName))
                {
                    byte[] byteArray = Encoding.UTF8.GetBytes(xml);
                    var stream = new MemoryStream(byteArray);
                    SignalModelLibrary = new SignalModelLibrary(stream);
                    SaveSelectedSignalModel();
                    MessageBox.Show(String.Format("Finished Importing Signal Model Library \"{0}\"",
                        SignalModelLibrary.TSFLibrary.name));
                }
            }
            catch (Exception err )
            {
                StringBuilder sb = new StringBuilder(System.Web.HttpUtility.HtmlEncode(Encoding.UTF8.GetBytes(err.Message))).Append("\r\n");
                while (err.InnerException != null)
                {
                    sb.Append(System.Web.HttpUtility.HtmlEncode(Encoding.UTF8.GetBytes(err.InnerException.Message))).Append("\r\n");
                    err = err.InnerException;
                }
                LogManager.Error("An error has occurred attempting to import file \"{0}\"\r\nError:\r\n{1}", fileName, sb.ToString() );                
            }
        }

        private void lvSignals_MouseDown(object sender, MouseEventArgs e)
        {
            if (lvSignals.SelectedItems.Count > 0)
            {
                var model = (SignalModel) lvSignals.SelectedItems[0].Tag;
                lvSignals.DoDragDrop(model.TSF.Serialize(), DragDropEffects.Copy);
            }
        }

        private void btnExportTSF_Click(object sender, EventArgs e)
        {
            try
            {
                FileManager.WriteFile(SignalModelLibrary.Serialize(), "XML files (*.xml)|*.xml|All files (*.*)|*.*", null);
            }
            catch (Exception err)
            {
                LogManager.Error( "Error exporting the selected Signal Model Library", err );
            }
            
        }

        private void lvModel_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvModel.SelectedItems.Count > 0)
            {
                ListViewItem item = lvModel.SelectedItems[0];
                var sf = item.Tag as SignalFunction;
                var element = item.Tag as XmlElement;
                if (element != null)
                {
                    ResetAttributeColors();
                    foreach ( XmlAttribute attribute in element.Attributes)
                    {
                        foreach (ListViewItem lvi in lvAttributes.Items)
                        {
                            SignalAttribute sa = lvi.Tag as SignalAttribute;
                            if (sa != null && attribute.Value != null )
                            {
                                if (attribute.Value.Contains(sa.Name))
                                    lvi.BackColor = RELATED_COLOR;
                            }
                        }
                    }
                }
                if (sf != null)
                {
                    if (!String.IsNullOrEmpty(sf.In))
                    {
                        foreach (ListViewItem lvi in lvModel.Items)
                        {
                            var lvsf = lvi.Tag as SignalFunction;
                            if (lvsf != null && !sf.name.Equals(lvsf.name))
                            {
                                if (sf.In.Contains(lvsf.name))
                                    lvi.BackColor = INPUT_COLOR;
                                else
                                    lvi.BackColor = NORMAL_COLOR;
                            }
                        }
                    }
                    else
                    {
                        ResetModelColors();
                    }

                    ResetAttributeColors();

                    foreach (ListViewItem lvi in lvAttributes.Items)
                    {
                        SignalAttribute sa = lvi.Tag as SignalAttribute;
                        if (sa != null)
                        {
                            string attrName = sa.Name;
                            foreach (PropertyInfo pi in sf.GetType().GetProperties())
                            {
                                object value = pi.GetValue( sf, null );
                                if (value != null)
                                {
                                    if (IsStringArray( pi ))
                                    {
                                        foreach ( string s in ((string[])value) )
                                            TestItemColor(s, attrName, pi, lvi);
                                    }
                                    else
                                    {
                                        TestItemColor(value.ToString(), attrName, pi, lvi);
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        private static bool IsStringArray( PropertyInfo pi )
        {
            return pi.PropertyType.IsArray && pi.PropertyType.GetElementType() == typeof(string);
        }

        private void ResetAttributeColors()
        {
            foreach (ListViewItem lvi in lvAttributes.Items)
                lvi.BackColor = NORMAL_COLOR;
        }

        private void ResetModelColors()
        {
            foreach (ListViewItem lvi in lvModel.Items)
                lvi.BackColor = NORMAL_COLOR;
        }

        private void lvAttributes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvAttributes.SelectedItems.Count > 0)
            {
                ResetAttributeColors();
                String name = ((SignalAttribute) lvAttributes.SelectedItems[0].Tag).Name;
                foreach (ListViewItem lvi in lvModel.Items)
                {
                    lvi.BackColor = NORMAL_COLOR;
                    var sf = lvi.Tag as SignalFunction;
                    var el = lvi.Tag as XmlElement;
                    ProcessAttributeAsSignalFunction( sf, name, lvi );
                    if (el != null)
                    {
                        foreach (XmlAttribute attribute in el.Attributes)
                        {
                            string value = attribute.Value;
                            if (name.Equals(attribute.LocalName) 
                                || (value != null && value.Contains(name)))
                            {
                                lvi.BackColor = RELATED_COLOR;
                            }
                        }
                    }
                }
            }
        }

        private static void ProcessAttributeAsSignalFunction( SignalFunction sf, string name, ListViewItem lvi )
        {
            if (sf != null)
            {
                foreach (PropertyInfo pi in sf.GetType().GetProperties())
                {
                    object value = pi.GetValue( sf, null );
                    if (value != null)
                    {
                        if (IsStringArray( pi ))
                        {
                            foreach (string s in ( (string[]) value ))
                                TestItemColor( s, name, pi, lvi );
                        }
                        else
                        {
                            TestItemColor( value.ToString(), name, pi, lvi );
                        }
                    }
                    else if (name.Equals( pi.Name ))
                    {
                        lvi.BackColor = RELATED_COLOR;
                    }
                }
            }
        }

        private static void TestItemColor( string s, string name, PropertyInfo pi, ListViewItem lvi )
        {
            string sVal = s.Replace( "{", "" ).Replace( "}", "" );
            if (name.Equals( sVal ) || sVal.Contains( name ) || name.Equals( pi.Name ))
            {
                lvi.BackColor = RELATED_COLOR;
            }
        }

    }
}