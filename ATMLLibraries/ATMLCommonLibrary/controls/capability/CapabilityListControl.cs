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
using System.Reflection;
using System.Windows.Forms;
using System.Xml;
using ATMLCommonLibrary.controls.lists;
using ATMLCommonLibrary.forms;
using ATMLCommonLibrary.utils;
using ATMLManagerLibrary.managers;
using ATMLModelLibrary.model.common;
using ATMLModelLibrary.model.equipment;
using ATMLModelLibrary.model.signal;
using ATMLModelLibrary.model.signal.basic;
using ATMLUtilitiesLibrary;

namespace ATMLCommonLibrary.controls.capability
{
    public partial class CapabilityListControl : ATMLListControl
    {
        private const String SIGNAL = "Signal";
        private const String IN = "In";
        private const String OUT = "Out";
        private const String NAME = "name";
        private const String XMLELEMENT = "XmlElement";
        private const String TAB = "\t";
        private const String EMPTYCHAR = "";

        private List<object> _capabilityItems = new List<object>();
        private InstrumentDescription _instrumentDescription;
        private TestAdapterDescription _testAdapterDescription;
        private TestStationDescription11 _testStationDescription;

        public event EventHandler DataObjectRequested;
        protected virtual void OnDataObjectRequested( DataObjectRequestEventArgs eventArgs )
        {
            EventHandler handler = DataObjectRequested;
            if (handler != null) handler(this, eventArgs);
        }

        public CapabilityListControl()
        {
            InitializeComponent();
            InitListView();
            OnAdd += CapabilityListControl_OnAdd;
            OnEdit += CapabilityListControl_OnEdit;
            OnDelete += CapabilityListControl_OnDelete;
            lvList.DragDrop += lvCapabilities_DragDrop;
            lvList.SelectedIndexChanged += lvCapabilities_SelectedIndexChanged;
            lvList.DragEnter += lvCapabilities_DragEnter;
        }


        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool ReferenceOnly { get; set; }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public InstrumentDescription InstrumentDescription
        {
            get { return _instrumentDescription; }
            set { _instrumentDescription = value; }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public List<object> CapabilityItems
        {
            get
            {
                ControlsToData();
                return _capabilityItems.Count == 0 ? null : _capabilityItems;
            }
            set
            {
                _capabilityItems = (value == null ? new List<object>() : value.ToList());
                DataToControls();
            }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public TestStationDescription11 TestStationDescription
        {
            get { return _testStationDescription; }
            set { _testStationDescription = value; }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public TestAdapterDescription TestAdapterDescription
        {
            get { return _testAdapterDescription; }
            set { _testAdapterDescription = value; }
        }

        private void InitListView()
        {
            DataObjectName = "Capability";
            //DataObjectFormType = typeof(Capability);
            AddColumnData("Referenced", "index", .15);
            AddColumnData("Name", "name", .40);
            AddColumnData("UUID/Description", "Description", .45);
            InitColumns();
        }


        private void DataToControls()
        {
            Items.Clear();

            if (_capabilityItems != null)
            {
                foreach (object obj in _capabilityItems)
                {
                    AddCapability(obj);
                }
            }
        }

        private void AddCapability(object obj)
        {
            String reference = EMPTYCHAR;
            String name = EMPTYCHAR;
            String value = EMPTYCHAR;
            if (obj is Capability)
            {
                reference = "No";
                name = ((Capability) obj).name;
                value = ((Capability) obj).Description;
            }
            else if (obj is DocumentReference)
            {
                reference = "Yes";
                name = ((DocumentReference) obj).ID;
                value = ((DocumentReference) obj).uuid;
            }
            var item = new ListViewItem(reference);
            item.SubItems.Add(name);
            item.SubItems.Add(value);
            item.Tag = obj;
            int idx = Items.Add(item).Index;
            item.BackColor = idx % 2 == 0 ? ATMLContext.COLOR_LIST_EVEN : ATMLContext.COLOR_LIST_ODD;
        }

        private void ControlsToData()
        {
            if (_capabilityItems == null)
                _capabilityItems = new List<object>();

            _capabilityItems.Clear();
            foreach (ListViewItem lvi in Items)
            {
                object obj = lvi.Tag;
                if (obj is DocumentReference)
                {
                    if (_instrumentDescription != null)
                    {
                        if (_instrumentDescription.HasDoument(((DocumentReference) obj).uuid))
                        {
                        }
                    }
                }
                _capabilityItems.Add(obj);
            }
        }

        private void CapabilityListControl_OnAdd()
        {
            object data = GetDataObject();

            if (data != null)
            {
                var form = new CapabilityForm(data);
                form.Closed += add_form_closed;
                form.CloseOnSave = true;
                form.Show();
            }
        }

        private void add_form_closed(object sender, EventArgs e)
        {
            var form = sender as CapabilityForm;
            if (form != null)
            {
                if (DialogResult.OK == form.DialogResult)
                {
                    AddCapability(form.Capability);
                }
            }
        }

        private object GetDataObject()
        {
            var eventArgs = new DataObjectRequestEventArgs();
            OnDataObjectRequested( eventArgs );
            object data = null;
            if (_instrumentDescription != null)
                data = _instrumentDescription;
            else if (_testStationDescription != null)
                data = _testStationDescription;
            else if (_testAdapterDescription != null)
                data = _testAdapterDescription;

            if (data == null)
            {
                if (eventArgs.ObjectItemDescription is InstrumentDescription)
                    data = _instrumentDescription = eventArgs.ObjectItemDescription as InstrumentDescription;
                else if (eventArgs.ObjectItemDescription is TestAdapterDescription1 )
                    data = _testAdapterDescription = eventArgs.ObjectItemDescription as TestAdapterDescription1;
                else if (eventArgs.ObjectItemDescription is TestStationDescription11 )
                    data = _testStationDescription = eventArgs.ObjectItemDescription as TestStationDescription11;
            }

            return data;
        }

        private void CapabilityListControl_OnEdit()
        {
            if (SelectedItems.Count > 0)
            {
                ListViewItem lvi = SelectedItems[0];
                object obj = lvi.Tag;
                if (obj is Capability)
                {
                    var capability = obj as Capability;
                    object dataObject = GetDataObject();
                    if (dataObject != null)
                    {
                        var form = new CapabilityForm(dataObject);
                        form.Capability = capability;
                        form.Closed += form_Closed;
                        form.CloseOnSave = true;
                        form.Show();
                    }
                }
                else if (obj is DocumentReference)
                {
                    var reference = obj as DocumentReference;
                    var form = new CapabilityReferenceForm();
                    form.InstrumentDescription = _instrumentDescription;
                    form.DocumentReference = reference;
                    form.Closed += form_Closed;
                    form.Show();
                }
            }
        }

        private void form_Closed(object sender, EventArgs e)
        {
            var capRefForm = sender as CapabilityReferenceForm;
            var capForm = sender as CapabilityForm;
            ListViewItem lvi = SelectedItems[0];
            object obj = lvi.Tag;

            if (capForm != null && capForm.DialogResult == DialogResult.OK)
            {
                //var capability = obj as Capability;
                Capability capability = capForm.Capability;
                lvi.Tag = capability;
                lvi.SubItems[1].Text = capability.name;
                lvi.SubItems[2].Text = capability.Description;
            }
            else if (capRefForm != null && capRefForm.DialogResult == DialogResult.OK)
            {
                //var reference = obj as DocumentReference;
                DocumentReference reference = capRefForm.DocumentReference;
                lvi.Tag = reference;
                lvi.SubItems[1].Text = reference.DocumentName;
                lvi.SubItems[2].Text = reference.uuid;
            }
        }

        private void CapabilityListControl_OnDelete()
        {
            if (SelectedItems.Count > 0)
            {
                ListViewItem lvi = SelectedItems[0];
                string prompt = @"Delete this capability?";
                if (DialogResult.Yes ==
                    MessageBox.Show(prompt, @"V E R I F Y", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                {
                    lvi.Remove();
                }
            }
            foreach (ListViewItem lvi in Items)
                lvi.BackColor = lvi.Index % 2 == 0 ? ATMLContext.COLOR_LIST_EVEN : ATMLContext.COLOR_LIST_ODD;
        }

        private void lvCapabilities_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (SelectedItems.Count > 0)
            {
                object obj = SelectedItems[0].Tag;
                if (obj is Capability)
                {
                    var capability = obj as Capability;
                    Extension ext = capability.SignalDescription;
                    ProcessExtensionAsSignal(capability, ext);
                }
            }
        }

        private static void ProcessExtensionAsSignal(Capability capability, Extension ext)
        {
            if (ext != null)
            {
                List<XmlElement> any = ext.Any;
                if (any.Count > 0)
                {
                    String attIn = null;
                    String attOut = null;
                    String name = null;
                    if (SIGNAL.Equals(any[0].LocalName))
                    {
                        if (any[0].HasAttribute(IN))
                            attIn = any[0].GetAttribute(IN);
                        if (any[0].HasAttribute(OUT))
                            attIn = any[0].GetAttribute(OUT);
                        if (any[0].HasAttribute(NAME))
                            attIn = any[0].GetAttribute(NAME);

                        //Console.WriteLine(any[0].OuterXml.Trim());
                        var signal = new Signal();
                        try
                        {
                            signal = MarshallSignal(any, signal);
                        }
                        catch (Exception ee)
                        {
                            LogManager.Error(ee,
                                "An error has occured atttempting to extract the signal from Capability \"",
                                capability.name,
                                "\"\r\n\r\n",
                                ee.Message);
                        }
                    }
                }
            }
        }

        private static Signal MarshallSignal(List<XmlElement> any, Signal signal)
        {
            signal = Signal.Deserialize(any[0].OuterXml.Trim());
            foreach (object item in signal.Items)
            {
                String sigName = item.GetType().Name;
                if (XMLELEMENT.Equals(sigName))
                {
                    //MessageBox.Show(String.Format("A class was not found for signal \"{0}\" for the namespace \"{1}\"",
                    //                 ((XmlElement)item).Name, ((XmlElement)item).NamespaceURI));
                    //Console.Write(((XmlElement) item).LocalName);
                    //Console.Write(TAB);
                    //Console.Write(EMPTYCHAR);
                    //Console.Write(TAB);
                    //Console.WriteLine(((XmlElement) item).Value);
                }
                else
                {
                    foreach (PropertyInfo prop in item.GetType().GetProperties())
                    {
                        //Console.Write(prop.Name);
                        //Console.Write(TAB);
                        //Console.Write(prop.PropertyType);
                        //Console.Write(TAB);
                        //Console.WriteLine(prop.GetValue(item, null));
                    }
                }
            }
            return signal;
        }

        private void lvCapabilities_DragDrop(object sender, DragEventArgs de)
        {
            if (de.Data.GetDataPresent(DataFormats.Text))
            {
                TSFType tsf = TSFType.Deserialize((string) de.Data.GetData(DataFormats.Text));
                var capability = new Capability();
                capability.name = tsf.name;
                object item = tsf.model.Item;
                if (item is Signal)
                {
                    var signal = (Signal) item;
                    XmlElement elm = XmlUtils.Object2XmlElement(item);
                    capability.SignalDescription = new Extension();
                    if (capability.SignalDescription.Any == null)
                        capability.SignalDescription.Any = new List<XmlElement>();
                    capability.SignalDescription.Any.Add(elm);
                    capability.Interface = new Interface();

                    if (signal.In != null)
                    {
                        String[] ins = signal.In.Split(' ');
                        foreach (String i in ins)
                        {
                            var p = new Port();
                            p.name = i;
                            p.direction = PortDirection.Input;
                            p.directionSpecified = true;
                            capability.Interface.Ports.Add(p);
                        }
                    }
                    if (signal.Out != null)
                    {
                        String[] outs = signal.Out.Split(' ');
                        foreach (String o in outs)
                        {
                            var p = new Port();
                            p.name = o;
                            p.direction = PortDirection.Output;
                            p.directionSpecified = true;
                            if (capability.Interface.Ports == null)
                                capability.Interface.Ports = new List<Port>();
                            capability.Interface.Ports.Add(p);
                        }
                    }

                    var form = new CapabilityForm(_instrumentDescription);
                    form.Capability = capability;
                    if (DialogResult.OK == form.ShowDialog())
                    {
                        String reference = EMPTYCHAR;
                        String uuid = EMPTYCHAR;
                        capability = form.Capability;
                        _capabilityItems.Add(capability);
                        var lvi = new ListViewItem(reference);
                        lvi.SubItems.Add(capability.name);
                        lvi.SubItems.Add(uuid);
                        lvi.Tag = capability;
                        Items.Add(lvi);
                    }
                }
            }
        }

        private void lvCapabilities_DragEnter(object sender, DragEventArgs de)
        {
            if (de.Data.GetDataPresent(DataFormats.Text))
            {
                de.Effect = DragDropEffects.Copy;
            }
            else
            {
                de.Effect = DragDropEffects.None;
            }
        }

        private void btnImportCapabilityDocument_Click(object sender, EventArgs e)
        {
            var form = new CapabilityReferenceForm();
            form.InstrumentDescription = _instrumentDescription;
            form.DocumentReference = new DocumentReference();
            if (DialogResult.OK == form.ShowDialog())
            {
                DocumentReference docRef = form.DocumentReference;
                _capabilityItems.Add(docRef);
            }

            //Select the resource, then the resource port.
            //Create a class reporesentation of a capability mapping
        }

        private void lvList_DragDrop(object sender, DragEventArgs e)
        {
            //lvCapabilities_DragDrop(sender, e);
        }

        private void lvList_DragOver(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Text))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void lvList_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Text))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }
    }

    public class DataObjectRequestEventArgs : EventArgs
    {
        public HardwareItemDescription ObjectItemDescription { set; get; }
    }
}