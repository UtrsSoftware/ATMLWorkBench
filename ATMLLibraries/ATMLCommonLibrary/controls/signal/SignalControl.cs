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
using System.Linq;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;
using ATMLCommonLibrary.forms;
using ATMLCommonLibrary.utils;
using ATMLDataAccessLibrary.db.daos;
using ATMLDataAccessLibrary.model;
using ATMLModelLibrary.model.common;
using ATMLModelLibrary.model.signal;
using ATMLModelLibrary.model.signal.basic;
using ATMLSignalModelLibrary.managers;
using ATMLSignalModelLibrary.signal;

namespace ATMLCommonLibrary.controls.signal
{
    public partial class SignalControl : ATMLControl
    {
        private readonly List<object> _availableIns = new List<object>();
        private readonly List<object> _availableOuts = new List<object>();
        private SignalModel _currentSignalModel;

        private Signal _signal;

        private SignalFunctionType _signalFunctionType;

        public SignalControl()
        {
            _signal = new Signal();
            InitializeComponent();

            signalInputList.SignalINs = new List<SignalIN>();
            SetOtherAttributesColumnWidths();
            SetInterfaceAttributesColumnWidths();
            Clear();

            XmlDocument tree = SignalManager.Instance.TSFSignalTree;
            awbDropListTree.TreeModel = tree;
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public List<object> Ports { get; set; }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Signal Signal
        {
            get
            {
                ControlsToData();
                return _signal;
            }
            set
            {
                _signal = value;
                DataToControls();
            }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public SignalFunctionType SignalFunctionType
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

        public List<object> AvailableIns
        {
            get { return _availableIns; }
        }

        public List<object> AvailableOuts
        {
            get { return _availableOuts; }
        }

        private void SignalControl_Load(object sender, EventArgs e)
        {
        }

        public override void Clear()
        {
            base.Clear();
            signalPartsListControl.Clear();
            signalInputList.Clear();
            otherAttributes.Rows.Clear();
            //dgInterfaceAttributes.Rows.Clear();
        }

        private void DataToControls()
        {
            Clear();
            if (_signal != null)
            {
                List<XmlAttribute> attributes = _signal.AnyAttr != null ? _signal.AnyAttr.ToList() : null;
                if (attributes != null)
                {
                    foreach (XmlAttribute attribute in attributes)
                        otherAttributes.Rows.Add(new object[] {attribute.Name, attribute.Value});
                }
                edtName.Text = _signal.name;
                edtIn.Text = _signal.In;
                edtOut.Text = _signal.Out;
                edtScriptEngine.Text = _signal.scriptEngine;
                edtType.Text = _signal.type;
                edtRefType.Text = _signal.reftype;
                if (_signal.Items != null)
                    signalPartsListControl.SignalItems = _signal.Items.ToList();
                if (_signal.Ins != null)
                    signalInputList.SignalINs = _signal.Ins.ToList();
                //--- Check for schema location ---//
                string tsfName = "";
                string tsfNameSpace = "";
                string tsfUuid = "";
                if (_signal.AnyAttr != null)
                {
                    foreach (XmlAttribute attribute in _signal.AnyAttr)
                    {
                         
                    }
                }

                if (_signal.Items != null && _signal.Items.Length > 0)
                {
                    XmlElement element = _signal.Items[0] as XmlElement;
                    if (element != null)
                    {
                        tsfName = element.LocalName;
                        tsfNameSpace = element.NamespaceURI;
                    }
                }

                awbDropListTree.FindNode(tsfName, tsfNameSpace);
                /*
                if (_signal.Items != null && !string.IsNullOrEmpty(_signal.Out))
                {
                    foreach (object item in _signal.Items)
                    {
                        //--------------------------------------------------------//
                        //--- Signal Function Type is the root for all signals ---//
                        //--------------------------------------------------------//
                        var type = item as SignalFunctionType;
                        var element = item as XmlElement;
                        if (element != null)
                        {
                            var nameSpace = element.NamespaceURI;
                            var localName = element.LocalName;
                            awbDropListTree.FindNode( localName, nameSpace );
                            break;
                        }
                        else if (type != null)
                        {
                            SignalFunctionType subSignal = type;

                            if (_signal.Out.Equals(subSignal.name))
                            {
                                //signalComboBox.SelectedIndex = signalComboBox.FindStringExact(subSignal.GetType().Name);
                                if (string.IsNullOrEmpty(_signal.name))
                                {
                                    edtName.Text = _signal.name = subSignal.name;
                                }
                                break;
                            }
                        }
                    }
                }
                 */
            }

            if (_signalFunctionType != null)
            {
                edtName.Text = _signalFunctionType.name;
                edtIn.Text = _signalFunctionType.In;
                edtScriptEngine.Text = _signalFunctionType.scriptEngine;
                edtType.Text = _signalFunctionType.type;
                edtRefType.Text = _signalFunctionType.reftype;
                List<XmlAttribute> attributes = _signalFunctionType.AnyAttr.ToList();
                foreach (XmlAttribute attribute in attributes)
                    otherAttributes.Rows.Add(new object[] {attribute.Name, attribute.Value});
            }
        }

        private void ControlsToData()
        {
            if (_signal != null)
            {
                _signal.name = edtName.Text;
                if (signalInputList.SignalINs != null )
                    _signal.Ins = signalInputList.SignalINs.ToArray();
                _signal.Out = edtOut.Text;
                _signal.type = edtType.Text;
                _signal.reftype = edtRefType.Text;
                _signal.scriptEngine = edtScriptEngine.Text;

                List<object> items = signalPartsListControl.SignalItems;
                if (items != null)
                    _signal.Items = items.ToArray();
                var selectedTypes = new List<SignalItemsChoiceType>();
                if (items != null)
                {
                    foreach (object item in items)
                    {
                        var sft = item as SignalFunctionType;
                        var elm = item as XmlElement;
                        if (sft != null)
                        {
                            selectedTypes.Add(
                                (SignalItemsChoiceType) Enum.Parse(typeof (SignalItemsChoiceType), sft.GetType().Name));
                        }
                        else if( elm != null )
                        {
                            selectedTypes.Add( SignalItemsChoiceType.Item );
                        }
                    }

                    _signal.ItemsElementName = selectedTypes.ToArray();
                }
            }
        }

        private void btnSelectIns_Click(object sender, EventArgs e)
        {
            if (_availableIns != null)
            {
                //----------------------------------------------------------------------------------//
                //--- Pass in "name" as the property name from the port to use as the list value ---//
                //----------------------------------------------------------------------------------//
                var form = new CheckedListForm("name");
                foreach (Port port in _availableIns)
                {
                    if (port.direction == PortDirection.Input
                        || port.direction == PortDirection.BiDirectional)
                    {
                        form.AddListItem(port, edtIn.Text.Contains(port.name) /* TODO: Or is in signalInputList */);
                    }
                }

                if (DialogResult.OK == form.ShowDialog())
                {
                    List<object> selectedList = form.SelectedIems;
                    //---------------------------------//
                    //--- Clear any existing inputs ---//
                    //---------------------------------//
                    if (signalInputList.SignalINs != null )
                        signalInputList.SignalINs.Clear();
                    edtIn.Text = "";

                    //------------------------------------------------------//
                    //--- Walk each checked input from checked list form ---//
                    //------------------------------------------------------//
                    foreach (object item in selectedList)
                    {
                        var port = (Port) item;
                        //---------------------------------------------------------------------------------//
                        //--- Add input items to in line separated by a space (backwards compatability) ---//
                        //---------------------------------------------------------------------------------//
                        edtIn.Text += port.name + " ";
                        //-------------------------------//
                        //--- Add input to input list ---//
                        //-------------------------------//
                        var sin = new SignalIN();
                        sin.name = port.name;
                        sin.In = SignalININ.In;
                        signalInputList.AddSignalInput(sin);
                    }
                }
            }
        }

        private void btnSelectOuts_Click(object sender, EventArgs e)
        {
            if (_availableOuts != null)
            {
                //----------------------------------------------------------------------------------//
                //--- Pass in "name" as the property name from the port to use as the list value ---//
                //----------------------------------------------------------------------------------//
                var form = new CheckedListForm("name");
                foreach (Port port in _availableOuts)
                {
                    if (port.direction == PortDirection.Output
                        || port.direction == PortDirection.BiDirectional)
                    {
                        form.AddListItem(port, edtOut.Text.Contains(port.name));
                    }
                }

                if (DialogResult.OK == form.ShowDialog())
                {
                    List<object> selectedList = form.SelectedIems;
                    //---------------------------------//
                    //--- Clear any existing inputs ---//
                    //---------------------------------//
                    edtOut.Text = "";

                    //------------------------------------------------------//
                    //--- Walk each checked input from checked list form ---//
                    //------------------------------------------------------//
                    foreach (object item in selectedList)
                    {
                        var port = (Port) item;
                        //----------------------------------------------------------------------------------//
                        //--- Add output items to in line separated by a space (backwards compatability) ---//
                        //----------------------------------------------------------------------------------//
                        edtOut.Text += port.name + " ";
                    }
                }
            }
        }

        private void otherAttributes_Resize(object sender, EventArgs e)
        {
            SetOtherAttributesColumnWidths();
        }

        private void SetOtherAttributesColumnWidths()
        {
            if (otherAttributes.Columns.Count >= 2)
            {
                otherAttributes.Columns[0].Width = otherAttributes.Width/2;
                otherAttributes.Columns[1].Width = otherAttributes.Width/2;
            }
        }

        private void SetInterfaceAttributesColumnWidths()
        {
            //dgInterfaceAttributes.Columns[0].Width = otherAttributes.Width / 2;
            //dgInterfaceAttributes.Columns[1].Width = otherAttributes.Width / 2;
        }

        private void awbDropListTree_SignalSelected(object sender, XmlDocument tsfDocument )
        {
            var signal = sender as dbSignal;
            _currentSignalModel = sender as SignalModel;
            var bscName = sender as string;
            try
            {
                HourGlass.Start();
                Clear();
                if (!string.IsNullOrWhiteSpace( bscName ))
                {
                       
                }
                else if (!LoadSignalModel( signal, tsfDocument ))
                {
                    LoadSignalModel( _currentSignalModel, tsfDocument );
                }
            }
            finally
            {
                HourGlass.Stop();
            }
        }

        private bool LoadSignalModel(dbSignal dbsignal, XmlDocument tsfDocument)
        {
            bool loaded = false;
            if (dbsignal != null)
            {
                var dao = new SignalDAO();
                dbsignal = dao.getSignal(dbsignal.signalId);
                _currentSignalModel = SignalManager.GetSignalModel(dbsignal.xmlns, dbsignal.signalName);
                LoadSignalModel(_currentSignalModel, tsfDocument);
                loaded = true;
            }
            return loaded;
        }


        private bool LoadSignalModel(SignalModel sm, XmlDocument tsfDocument )
        {
            bool loaded = false;
            if (sm != null)
            {
                string tsfNameSpace = sm.SignalNameSpace;
                string tsfName = sm.TSF.name;
                string tsfUuid = sm.TSF.uuid;
                _currentSignalModel = sm;

                Signal modelSignal = new Signal();
                modelSignal.name = tsfName;
                XmlElement el = tsfDocument.CreateElement("tsf", tsfName, tsfNameSpace);
                foreach (SignalAttribute attr in sm.Attributes)
                    el.Attributes.Append( tsfDocument.CreateAttribute( attr.Name ) );

                modelSignal.Items = new[] { el };

                Signal = modelSignal;
                var items = new List<object>();
                items.AddRange(modelSignal.Items);
                signalPartsListControl.SignalItems = items;

                /*
                var modelSignal = sm.TSF.model.Item as Signal;
                var modelStandard = sm.TSF.model.Item as TSFTypeModelStandard;
                if (modelSignal != null)
                {
                    modelSignal.type = tsfName;
                    var la = new List<XmlAttribute>( modelSignal.AnyAttr );
                    if (tsfDocument != null)
                    {
                        XmlAttribute xAttribute1 = tsfDocument.CreateAttribute("tsf-xmlns");
                        XmlAttribute xAttribute2 = tsfDocument.CreateAttribute("tsf-uuid");
                        XmlAttribute xAttribute3 = tsfDocument.CreateAttribute("tsf-name");
                        xAttribute1.Value = tsfNameSpace;
                        xAttribute2.Value = tsfUuid;
                        xAttribute3.Value = tsfName;
                        la.Add(xAttribute1);
                        la.Add(xAttribute2);
                        la.Add(xAttribute3);
                    }
                    modelSignal.AnyAttr = la.ToArray();
                    Signal = modelSignal;
                    var items = new List<object>();
                    items.AddRange(modelSignal.Items);
                    signalPartsListControl.SignalItems = items;
                    signalInterfaceListControl.Load( sm );
                    //dg.Rows.Clear();
                    //string uuid = sm.TSF.uuid;
                    //foreach (SignalAttribute attribute in sm.Attributes)
                    //    dgInterfaceAttributes.Rows.Add(new object[] { attribute.Name, "" });
                }
                else if (modelStandard != null) //TODO: Figure out TSFTypeModelStandard
                {
                }
                 * */
                loaded = true;
            }
            return loaded;
        }

        private void tabSignalFunctions_Click(object sender, EventArgs e)
        {
        }

        private void awbDropListTree_Load(object sender, EventArgs e)
        {
        }

        private void dgInterfaceAttributes_Resize(object sender, EventArgs e)
        {
            SetInterfaceAttributesColumnWidths();
        }
    }
}