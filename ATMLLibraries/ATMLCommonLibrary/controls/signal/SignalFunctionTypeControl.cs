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
using System.Reflection;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Schema;
using ATMLCommonLibrary.forms;
using ATMLCommonLibrary.utils;
using ATMLDataAccessLibrary.db.beans;
using ATMLDataAccessLibrary.db.daos;
using ATMLDataAccessLibrary.managers;
using ATMLDataAccessLibrary.model;
using ATMLManagerLibrary.controllers;
using ATMLManagerLibrary.managers;
using ATMLModelLibrary.model;
using ATMLModelLibrary.model.common;
using ATMLModelLibrary.model.signal;
using ATMLModelLibrary.model.signal.basic;
using ATMLSchemaLibrary.managers;
using ATMLSignalModelLibrary.managers;
using ATMLSignalModelLibrary.signal;
using ATMLUtilitiesLibrary;

namespace ATMLCommonLibrary.controls.signal
{
    public partial class SignalFunctionTypeControl : ATMLControl
    {
        private List<string> _availableSignalParts = new List<string>();
        private object _signalFunctionType;
        private SignalModel _currentSignalModel;

        public SignalFunctionTypeControl()
        {
            InitializeComponent();
            SetColumnsWidths();
            signalAttributes.RowValidating += signalAttributes_RowValidating;
            XmlDocument tree = SignalManager.Instance.SignalTree;
            awbDropListTree.TreeModel = tree;
        }

        public object SignalFunctionType
        {
            get
            {
                ControlsToData();
                return _signalFunctionType;
            }
            set
            {
                _signalFunctionType = value;
                DataToControls();
            }
        }

        public List<string> AvailableSignalParts
        {
            get { return _availableSignalParts; }
            set { _availableSignalParts = value; }
        }

        private void signalAttributes_RowValidating( object sender, DataGridViewCellCancelEventArgs e )
        {
            var name = signalAttributes.Rows[e.RowIndex].Cells[0].Value as string;
            var type = signalAttributes.Rows[e.RowIndex].Cells[1].Value as string;
            var value = signalAttributes.Rows[e.RowIndex].Cells[2].Value as string;
            try
            {
                SignalFunctionType sf = _signalFunctionType as SignalFunctionType;
                XmlElement element = _signalFunctionType as XmlElement;
                if (sf != null && (!string.IsNullOrWhiteSpace(value) && IsPhysicalType( ATMLContext.NS_STDBSC, sf.GetType().Name, name)))
                {
                    var physical = new Physical( value );
                    physical.Validate();
                    signalAttributes.Rows[e.RowIndex].Cells[2].Style.BackColor =
                        signalAttributes.Rows[e.RowIndex].Cells[1].Style.BackColor;
                    signalAttributes.Rows[e.RowIndex].Cells[2].ToolTipText = "";
                }
                if (element != null)
                {
                    if (type != null && ( "Physical".Equals(type) || "Frequency".Equals(type) ) )//TODO: Lookup attribute type in schema
                    {
                        var physical = new Physical(value);
                        physical.Validate();
                        signalAttributes.Rows[e.RowIndex].Cells[2].Style.BackColor =
                            signalAttributes.Rows[e.RowIndex].Cells[1].Style.BackColor;
                        signalAttributes.Rows[e.RowIndex].Cells[2].ToolTipText = "";
                    }
                }
            }
            catch (Exception err)
            {
                signalAttributes.Rows[e.RowIndex].Cells[2].Style.BackColor = Color.LightPink;
                signalAttributes.Rows[e.RowIndex].Cells[2].ToolTipText = err.Message;
            }
        }


        private bool IsPhysicalType( string nameSpace, string localName, string propertyName )
        {
            bool isPhysicalType = false;
            XmlSchemaAttribute schemaAttribute;
            SchemaManager.FindAttribute(nameSpace, localName, propertyName, out schemaAttribute);
            string typeName = "";
            if (schemaAttribute != null)
            {
                XmlSchemaSimpleType simpleType = schemaAttribute.AttributeSchemaType;
                isPhysicalType = SchemaManager.IsPhysicalType(simpleType);
            }
            return isPhysicalType;
        }

        private void SetColumnsWidths()
        {
            const int colWidth = 100; //signalAttributes.Width/3;
            if (signalAttributes.Columns.Count >= 3)
            {
                signalAttributes.Columns[0].Width = colWidth; //name
                signalAttributes.Columns[1].Width = colWidth; //type
                signalAttributes.Columns[2].Width = signalAttributes.Width - ( colWidth*2 ); //value
            }
        }

        private void ControlsToData()
        {
            if (_signalFunctionType == null)
            {
                SignalModel model = awbDropListTree.SelectedSignalModel;
                if (model != null)
                {
                    var name = edtName.Text;
                    var ins = edtIn.Text;
                    var signal = model.Signal;
                    if (signal != null)
                    {
                        bool hasClass = false;
                        string signalName = signal.name;
                        string xmlns = model.SignalNameSpace;
                        var bean = CacheManager.GetNamespaceCache().getItem( xmlns ) as LuNamespaceBean;
                        if (bean != null)
                        {
                            string className = bean.appNamespace + "." + signalName;
                            object obj = Assembly.GetExecutingAssembly().CreateInstance( className );
                            if (obj is SignalFunctionType)
                            {
                                _signalFunctionType = obj as SignalFunctionType;
                                hasClass = true;
                            }
                        }
                        if( !hasClass )
                        {
                            CreateXmlElementItem(model);
                        }
                    }
                }
                else if (!string.IsNullOrEmpty( edtName.Text ))
                {
                    //CreateXmlElementItem( edtName.Text );
                }
            }

            XmlElement element = _signalFunctionType as XmlElement;
            if (element != null)
            {
                element.SetAttribute( "name", edtName.Text );
                if( string.IsNullOrWhiteSpace(edtIn.Text) )
                    element.RemoveAttribute( "in" );
                else
                    element.SetAttribute("in", edtIn.Text );
            }

            foreach (DataGridViewRow row in signalAttributes.Rows)
            {
                if (row.IsNewRow)
                    continue;

                var name = row.Cells[0].Value as string;
                var type = row.Cells[1].Value as string;
                var value = row.Cells[2].Value as string;
                var attr = row.Tag as dbSignalAttribute;

                //---------------------------------------------------//
                //--- Set the default value if the value is empty ---//
                //---------------------------------------------------//
                if (string.IsNullOrWhiteSpace( value ) && attr != null &&
                    !string.IsNullOrWhiteSpace( attr.defaultValue ))
                    value = attr.defaultValue;

                if (_signalFunctionType is SignalFunctionType)
                {
                    if (attr == null)
                        attr = new dbSignalAttribute();
                    attr.Value = value;
                    attr.attributeName = name;
                    ( (SignalFunctionType) _signalFunctionType ).Value = value;
                    if (name != null)
                    {
                        PropertyInfo pi = _signalFunctionType.GetType().GetProperty( name );
                        if (pi != null)
                        {
                            if (!string.IsNullOrWhiteSpace( value ))
                                pi.SetValue( _signalFunctionType, value, null );
                        }
                    }
                }
                else if (_signalFunctionType is XmlElement)
                {
                    var signal = (XmlElement) _signalFunctionType;
                    if (string.IsNullOrWhiteSpace( value ))
                        signal.RemoveAttribute( name );
                    else if (name != null) signal.SetAttribute( name, value );
                }
            }
        }

        private void CreateXmlElementItem(SignalModel model)
        {
            if (model != null)
            {
                var document = new XmlDocument();
                TSFType tsf = model.TSF;
                string xmlns = model.SignalNameSpace;
                string xml = XmlUtils.SerializeObject( model.Signal );
                document.LoadXml( xml );
                XmlElement root = document.DocumentElement;
                if (root != null)
                {
                    XmlElement el = root.FirstChild as XmlElement;
                    if (el != null && !string.IsNullOrEmpty( edtIn.Text ))
                    {
                        XmlAttribute attIn = document.CreateAttribute( "In" );
                        attIn.Value = edtIn.Text;
                        el.Attributes.Append( attIn );
                    }
                    _signalFunctionType = el;
                }
            }
        }

        private void DataToControls()
        {
            if (_signalFunctionType != null)
            {
                try
                {
                    if (_signalFunctionType is SignalFunctionType)
                    {
                        ProcessSignalFunctionType();
                    }
                    else if (_signalFunctionType is XmlElement)
                    {
                        ProcessXmlElement();
                    }
                }
                catch (Exception ex)
                {
                    LogManager.Error( ex );
                }
            }
        }

        private void ProcessSignalFunctionType()
        {
            edtName.Text = ( (SignalFunctionType) _signalFunctionType ).name;
            edtIn.Text = ( (SignalFunctionType) _signalFunctionType ).In;
            String name = _signalFunctionType.GetType().Name;
            SignalDAO dao = DataManager.getSignalDAO();

            //signalComboBox.SelectedIndex = signalComboBox.FindString( name );

            List<dbSignalAttribute> dbAttributes = dao.getAllSignalAttributes( name, null );
            //TODO:REPLACE NULL
            signalAttributes.Rows.Clear();
            foreach (dbSignalAttribute attr in dbAttributes)
            {
                object value = null;
                try
                {
                    PropertyInfo pi = _signalFunctionType.GetType().GetProperty( attr.attributeName );
                    if (pi != null)
                        value = pi.GetValue( _signalFunctionType, null );
                }
                catch (Exception e)
                {
                    LogManager.Error( e );
                }
                int idx = signalAttributes.Rows.Add( new[] {attr.attributeName, attr.type, value} );
                signalAttributes.Rows[idx].Tag = attr;
            }
        }

        private void ProcessXmlElement()
        {
            var signal = (XmlElement) _signalFunctionType;
            if (signal.HasAttribute( "name" ))
                edtName.Text = signal.GetAttribute( "name" );
            if (signal.HasAttribute( "In" ))
                edtName.Text = signal.GetAttribute( "In" );
            String name = signal.LocalName;
            string nameSpace = signal.NamespaceURI;
            SignalDAO dao = DataManager.getSignalDAO();

            List<dbSignalAttribute> dbAttributes = dao.getAllSignalAttributes(name, nameSpace);
            //TODO:REPLACE NULL

            signalAttributes.Rows.Clear();
            foreach (dbSignalAttribute attr in dbAttributes)
            {
                //TODO: Lookup Attribute Type
                String attrName = attr.attributeName;
                String attrValue = signal.GetAttribute( attrName );
                signalAttributes.Rows.Add( new object[] {attr.attributeName, attr.type, attrValue} );
            }
            awbDropListTree.FindNode( name, nameSpace );
        }

        private void otherAttributes_Resize( object sender, EventArgs e )
        {
            SetColumnsWidths();
        }

        private void otherAttributes_CellContentClick( object sender, DataGridViewCellEventArgs e )
        {
            var senderGrid = (DataGridView) sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0)
            {
                var form = new DatumForm();
                if (DialogResult.OK == form.ShowDialog())
                {
                    DatumType value = form.Datum;
                    senderGrid.Rows[e.RowIndex].Cells[1].Value = value.ToString();
                }
            }
        }

        private void signalComboBox_SelectedIndexChanged( object sender, EventArgs e )
        {
            try
            {
                HourGlass.Enabled = true;
                SignalModel signalModel = awbDropListTree.SelectedSignalModel;
                if (signalModel != null )
                {
                    var signal = signalModel.Signal;  //signalComboBox.SelectedItem as dbSignal;
                    if (signal != null)
                    {
                        //---------------------------------------------------//
                        //--- Find "name" in data grid and set it's value ---//
                        //---------------------------------------------------//
                        foreach (DataGridViewRow row in signalAttributes.Rows)
                        {
                            if (row.IsNewRow)
                                continue;

                            var name = row.Cells[0].Value as string;
                            var type = row.Cells[1].Value as string;
                            var value = row.Cells[2].Value as string;
                            if ("type".Equals( name ))
                            {
                                row.Cells[1].Value = edtName.Text;
                                break;
                            }
                        }
                        signalAttributes.Rows.Clear();

                        if (string.IsNullOrEmpty( edtName.Text ))
                            edtName.Text = signal.name;
                        var dao = new SignalDAO();
                        dbSignal dataSignal = dao.getSignal( signal.name, signalModel.SignalNameSpace );

                        string xmlns = signalModel.SignalNameSpace;
                        XmlSchemaComplexType complexType;
                        XmlSchemaElement element = null;
                        SchemaManager.GetComplexType( xmlns, signal.name, out complexType );
                        if (complexType == null)
                            SchemaManager.GetElement( xmlns, signal.name, out element );
                        if (complexType != null || element != null)
                        {
                            signalAttributes.Rows.Clear();
                            List<XmlSchemaAttribute> schemaAttributes = complexType != null
                                                                            ? SchemaManager.GetAttributes( complexType )
                                                                            : SchemaManager.GetAttributes( element );
                            List<dbSignalAttribute> dbAttributes = dao.getAllSignalAttributes( signal.name, signalModel.SignalNameSpace );
                            var foundAttributes = new Dictionary<string, dbSignalAttribute>();
                            foreach (dbSignalAttribute attribute in dbAttributes)
                            {
                                foundAttributes.Add( attribute.attributeName, attribute );
                                object value = null;
                                try
                                {
                                    if (_signalFunctionType != null)
                                    {
                                        PropertyInfo pi =
                                            _signalFunctionType.GetType().GetProperty( attribute.attributeName );
                                        if (pi != null)
                                            value = pi.GetValue( _signalFunctionType, null );
                                    }
                                }
                                catch (Exception err)
                                {
                                    LogManager.Error( err );
                                }
                                int idx =
                                    signalAttributes.Rows.Add( new[] {attribute.attributeName, attribute.type, value} );
                                signalAttributes.Rows[idx].Tag = attribute;
                            }

                            //-----------------------------------------------------------------------------//
                            //--- Check the database for each of the attributes found in the schema. If ---//
                            //--- the attribute does not exist in the database the add it.              ---//
                            //-----------------------------------------------------------------------------//
                            signalAttributes.Rows.Clear();
                            foreach (XmlSchemaAttribute attribute in schemaAttributes)
                            {
                                string name = attribute.Name;
                                if (!foundAttributes.ContainsKey( name ))
                                {
                                    var dbSignalAttribute = new dbSignalAttribute();
                                    dbSignalAttribute.signalId = dataSignal.signalId;
                                    dbSignalAttribute.attributeName = name;
                                    dbSignalAttribute.defaultValue = attribute.DefaultValue;
                                    dbSignalAttribute.fixedValue = attribute.FixedValue;
                                    if (attribute.AttributeSchemaType != null)
                                        dbSignalAttribute.type = attribute.AttributeSchemaType.Name;
                                    dbSignalAttribute.DataState = BASEBean.eDataState.DS_ADD;
                                    dbSignalAttribute.save();
                                    int idx = signalAttributes.Rows.Add( new[] {name, dbSignalAttribute.type, null} );
                                    signalAttributes.Rows[idx].Tag = attribute;
                                }
                            }
                        }
                    }
                }
            }
            finally
            {
                HourGlass.Enabled = false;
            }
        }

        private void edtName_TextChanged( object sender, EventArgs e )
        {
            //---------------------------------------------------//
            //--- Find "name" in data grid and set it's value ---//
            //---------------------------------------------------//
            foreach (DataGridViewRow row in signalAttributes.Rows)
            {
                if (row.IsNewRow)
                    continue;

                var name = row.Cells[0].Value as string;
                var type = row.Cells[1].Value as string;
                var value = row.Cells[2].Value as string;
                if ("name".Equals( name ))
                {
                    row.Cells[2].Value = edtName.Text;
                    break;
                }
            }
        }

        private void edtIn_TextChanged( object sender, EventArgs e )
        {
            //---------------------------------------------------//
            //--- Find "In" in data grid and set it's value ---//
            //---------------------------------------------------//
            foreach (DataGridViewRow row in signalAttributes.Rows)
            {
                if (row.IsNewRow)
                    continue;

                var name = row.Cells[0].Value as string;
                var type = row.Cells[1].Value as string;
                var value = row.Cells[2].Value as string;
                if ("In".Equals( name ))
                {
                    row.Cells[2].Value = edtIn.Text;
                    break;
                }
            }
        }

        private void btnSelectIns_Click( object sender, EventArgs e )
        {
            var form = new CheckedListForm();
            foreach (string name in AvailableSignalParts)
            {
                if (!string.IsNullOrEmpty( name ))
                    form.AddListItem( name, edtIn.Text.Contains( name ) /* TODO: Or is in signalInputList */ );
            }

            if (DialogResult.OK == form.ShowDialog())
            {
                List<object> selectedList = form.SelectedIems;

                //---------------------------------//
                //--- Clear any existing inputs ---//
                //---------------------------------//
                edtIn.Text = "";

                //------------------------------------------------------//
                //--- Walk each checked input from checked list form ---//
                //------------------------------------------------------//
                foreach (string name in selectedList)
                {
                    //---------------------------------------------------------------------------------//
                    //--- Add input items to in line separated by a space (backwards compatability) ---//
                    //---------------------------------------------------------------------------------//
                    edtIn.Text += name + @" ";
                }

                edtIn.Text = edtIn.Text.Trim();
            }
        }

        private void awbDropListTree_SignalSelected(object sender, XmlDocument tsfDocument)
        {
            var signal = sender as dbSignal;
            _currentSignalModel = sender as SignalModel;
            try
            {
                HourGlass.Start();
                Clear();
                if (!LoadSignalModel( signal ))
                {
                    if (!LoadSignalModel( _currentSignalModel ))
                    {
                        XmlNode node = SignalManager.Instance.SignalTree.SelectSingleNode( "" );
                        //--- ============================================================ ---//
                        //--- TODO: Determine what to do if the Signal Model does not load ---//
                        //--- ============================================================ ---//
                    }
                }
            }
            finally
            {
                HourGlass.Stop();
            }

        }

        private bool LoadSignalModel(dbSignal dbsignal)
        {
            bool loaded = false;
            if (dbsignal != null)
            {
                var dao = new SignalDAO();
                dbsignal = dao.getSignal(dbsignal.signalId);
                _currentSignalModel = SignalManager.GetSignalModel(dbsignal.xmlns, dbsignal.signalName);
                LoadSignalModel(_currentSignalModel);
                loaded = true;
            }
            return loaded;
        }

        private bool LoadSignalModel(SignalModel sm)
        {
            bool loaded = false;
            if (sm != null)
            {
                var modelSignal = sm.TSF.model.Item as Signal;
                var modelStandard = sm.TSF.model.Item as TSFTypeModelStandard;
                if (modelSignal != null)
                {
                    Signal signal = modelSignal;
                    var items = new List<object>();
                    items.AddRange(modelSignal.Items);
                    //signalPartsListControl.SignalItems = items;
                    signalAttributes.Rows.Clear();
                    string uuid = sm.TSF.uuid;
                    edtName.Text = modelSignal.name;
                    foreach (SignalAttribute attribute in sm.Attributes)
                        signalAttributes.Rows.Add(new object[] { attribute.Name, "" });
                }
                else if (modelStandard != null)
                {
                    //--- =========================================================================================== ---//
                    //--- TODO: TSFTypeModelStandard is not currently handled - we need to add this is an enhancement ---//
                    //--- =========================================================================================== ---//
                }
                loaded = true;
            }
            return loaded;
        }

    }
}