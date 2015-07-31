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
using System.Windows.Forms;
using ATMLCommonLibrary.controls.resource;
using ATMLCommonLibrary.forms;
using ATMLManagerLibrary.managers;
using ATMLModelLibrary.model.common;
using ATMLModelLibrary.model.equipment;

namespace ATMLCommonLibrary.controls.capability
{
    /**
     * 
     */

    public partial class CapabilityInterfaceListControl : UserControl
    {
        private InstrumentDescription _instrument;
        private Interface _interface;
        private Capability _parentCapability;
        private TestAdapterDescription1 _testAdapterDescription;
        private TestStationDescription11 _testStationDescription;

        public CapabilityInterfaceListControl()
        {
            InitializeComponent();
            SetColumnsWidths();
            btnMapping.Visible = false;
        }

        public Capability ParentCapability
        {
            get { return _parentCapability; }
            set { _parentCapability = value; }
        }

        public InstrumentDescription Instrument
        {
            get { return _instrument; }
            set { _instrument = value; }
        }

        public TestStationDescription11 TestStationDescription
        {
            get { return _testStationDescription; }
            set { _testStationDescription = value; }
        }

        public TestAdapterDescription1 TestAdapterDescription
        {
            get { return _testAdapterDescription; }
            set { _testAdapterDescription = value; }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Interface Interface
        {
            get
            {
                ControlsToData();
                return _interface;
            }
            set
            {
                _interface = value;
                DataToControls();
            }
        }

        public ListView.ListViewItemCollection Items
        {
            get { return lvPorts.Items; }
        }

        public event EventHandler PortAdded;

        protected virtual void OnPortAdded()
        {
            EventHandler handler = PortAdded;
            if (handler != null) handler(this, EventArgs.Empty);
        }

        public event EventHandler PortChanged;

        protected virtual void OnPortChanged()
        {
            EventHandler handler = PortChanged;
            if (handler != null) handler(this, EventArgs.Empty);
        }

        public event EventHandler PortRemoved;

        protected virtual void OnPortRemoved()
        {
            EventHandler handler = PortRemoved;
            if (handler != null) handler(this, EventArgs.Empty);
        }

        private void DataToControls()
        {
            if (_parentCapability == null)
                throw new Exception("The Parent Capability has no been set.");

            if (_interface != null)
            {
                AddPortsToListView();
            }
        }

        private List<Resource> GetResources()
        {
            var resources = new List<Resource>();
            if (_testStationDescription != null)
                resources = _testStationDescription.Resources;
            else if (_instrument != null)
                resources = _instrument.Resources;
            else if (_testAdapterDescription != null)
                resources = _testAdapterDescription.Resources;
            return resources;
        }

        private string GetCapabilityPortMapPath()
        {
            string path = null;
            if (_testStationDescription != null)
                path = MessageManager.getMessage("testStation.capability.port.map.path");
            else if (_instrument != null)
                path = MessageManager.getMessage("instrument.capability.port.map.path");
            else if (_testAdapterDescription != null)
                path = MessageManager.getMessage("testAdapter.capability.port.map.path");
            return path;
        }

        private string GetResourcePortMapPath()
        {
            string path = null;
            if (_testStationDescription != null)
                path = MessageManager.getMessage("testStation.resource.port.map.path");
            else if (_instrument != null)
                path = MessageManager.getMessage("instrument.resource.port.map.path");
            else if (_testAdapterDescription != null)
                path = MessageManager.getMessage("testAdapter.resource.port.map.path");
            return path;
        }


        private void AddPortsToListView()
        {
            lvPorts.Items.Clear();
            foreach (Port port in _interface.Ports)
            {
                AddPortToListView(port);
                string pathMap = GetCapabilityPortMapPath();
                List<Resource> resources = GetResources();
                if (resources != null && pathMap != null)
                {
                    //--- Find any mapped resource ports and add them to the port mapping ---//
                    String sourceName = String.Format(pathMap, _parentCapability.name, port.name);
                    foreach (Resource resource in resources)
                    {
                        if (resource.Interface != null && resource.Interface.Ports != null)
                        {
                            foreach (Port resourcePort in resource.Interface.Ports)
                            {
                                if (IsMappedToResourcePort(sourceName, resource, resourcePort))
                                {
                                    string key = resource.name + "." + resourcePort.name;
                                    if (!port.MappedPorts.ContainsKey(key))
                                        port.MappedPorts.Add(key, resourcePort);
                                    else
                                        port.MappedPorts[key] = resourcePort;
                                }
                            }
                        }
                    }
                }
            }
        }

        private List<Mapping> GetCapabilityMapping()
        {
            var mapping = new List<Mapping>();
            if (_instrument != null)
                mapping = _instrument.Capabilities.CapabilityMap;
            else if (_testStationDescription != null)
                mapping = _testStationDescription.Capabilities.CapabilityMap;
            else if (_testAdapterDescription != null)
                mapping = _testAdapterDescription.Capabilities.CapabilityMap;
            return mapping;
        }

        private bool IsMappedToResourcePort(String sourceName, Resource resource, Port resourcePort)
        {
            bool isChecked = false;
            String nodeName = String.Format(GetResourcePortMapPath(), resource.name, resourcePort.name);
            List<Mapping> mappings = GetCapabilityMapping();
            if (mappings != null)
            {
                foreach (Mapping map in mappings)
                {
                    bool sourceFound = false;
                    foreach (Network net in map.Map)
                    {
                        foreach (NetworkNode node in net.Node)
                        {
                            if (!sourceFound)
                                sourceFound = sourceName.Equals(node.Path.Value.Trim());
                            isChecked = sourceFound && nodeName.Equals(node.Path.Value.Trim());
                            if (isChecked)
                                break;
                        }
                        if (isChecked)
                            break;
                    }
                    if (isChecked)
                        break;
                }
            }
            return isChecked;
        }

        private void AddPortToListView(Port port)
        {
            var item = new ListViewItem(port.name);
            item.SubItems.Add(port.direction.ToString());
            item.SubItems.Add(port.type.ToString());
            item.Tag = port;
            item = lvPorts.Items.Add(item);
            if (item.Index%2 == 0)
            {
                item.BackColor = lvPorts.AltColor1;
            }
            else
            {
                item.BackColor = lvPorts.AltColor2;
            }
            OnPortAdded();
        }

        private void ControlsToData()
        {
            InitInterface();
            _interface.Ports.Clear();
            foreach (ListViewItem item in lvPorts.Items)
            {
                _interface.Ports.Add((Port) item.Tag);
            }
        }

        private void InitInterface()
        {
            if (_interface == null)
            {
                _interface = new Interface();
                _interface.Ports = new List<Port>();
            }
        }

        private void lvPorts_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void btnAddPort_Click(object sender, EventArgs e)
        {
            var form = new PortForm();
            if (DialogResult.OK == form.ShowDialog())
            {
                AddPortToListView(form.Port);
            }
        }

        private void btnEditPort_Click(object sender, EventArgs e)
        {
            if (lvPorts.SelectedItems.Count > 0)
            {
                var port = (Port) lvPorts.SelectedItems[0].Tag;
                var form = new PortForm();
                form.Port = port;
                if (DialogResult.OK == form.ShowDialog())
                {
                    port = form.Port;
                    lvPorts.SelectedItems[0].Tag = port;
                    lvPorts.SelectedItems[0].SubItems[0].Text = port.name;
                    lvPorts.SelectedItems[0].SubItems[1].Text = port.direction.ToString();
                    OnPortChanged();
                }
            }
        }

        private void btnDeletePort_Click(object sender, EventArgs e)
        {
            if (lvPorts.SelectedItems.Count > 0)
            {
                var port = (Port) lvPorts.SelectedItems[0].Tag;
                string prompt = String.Format(MessageManager.getMessage(MessageManager.CAPABILITY_PORT_DELETE),
                    port.name);
                if (DialogResult.Yes ==
                    MessageBox.Show(prompt, @"V E R I F Y", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                {
                    lvPorts.Items.RemoveAt(lvPorts.SelectedItems[0].Index);
                    OnPortRemoved();
                }
            }
        }

        private void lvPorts_Resize(object sender, EventArgs e)
        {
            SetColumnsWidths();
        }

        private void SetColumnsWidths()
        {
            if (lvPorts.Columns.Count >= 3)
            {
                lvPorts.Columns[0].Width = (int) ( Width*.33 );
                lvPorts.Columns[1].Width = (int) ( Width*.33 );
                lvPorts.Columns[2].Width = Width - ( lvPorts.Columns[0].Width + lvPorts.Columns[1].Width );
            }
        }

        private void btnMapping_Click(object sender, EventArgs e)
        {
            if (lvPorts.SelectedItems.Count > 0)
            {
                var port = (Port) lvPorts.SelectedItems[0].Tag;
                if (_instrument != null)
                {
                    var form = new ResourcePortSelectionForm(port, _instrument);
                    if (DialogResult.OK == form.ShowDialog())
                    {
                        //Update Capability Mapping?
                    }
                }
                else if (_testStationDescription != null)
                {
                }
                else if (_testAdapterDescription != null)
                {
                }
            }
        }
    }
}