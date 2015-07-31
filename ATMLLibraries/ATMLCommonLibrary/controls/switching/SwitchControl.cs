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
using ATMLCommonLibrary.forms;
using ATMLModelLibrary.model.common;
using ATMLModelLibrary.model.equipment;

namespace ATMLCommonLibrary.controls.switching
{
    public partial class SwitchControl : RepeatedItemControl
    {
        private InstrumentDescription instrument;

        public SwitchControl()
        {
            InitializeComponent();
            lvInterface.OnAdd += lvInterface_OnAdd;
            lvInterface.OnDelete += lvInterface_OnDelete;
            lvInterface.OnEdit += lvInterface_OnEdit;
            lvSwitchRelays.OnAdd += lvSwitchRelays_OnAdd;
            lvSwitchRelays.OnDelete += lvSwitchRelays_OnDelete;
            lvSwitchRelays.OnEdit += lvSwitchRelays_OnEdit;
            InitInterfaceListView();
            InitConnectionListView();
            Resize += SwitchControl_Resize;
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public InstrumentDescription Instrument
        {
            get { return instrument; }
            set { instrument = value; }
        }


        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Switch Switch
        {
            get
            {
                ControlsToData();
                return (Switch) RepeatedItem;
            }
            set
            {
                RepeatedItem = value;
                DataToControl();
            }
        }

        private void SwitchControl_Resize(object sender, EventArgs e)
        {
            SetInterfaceListViewColumnWidths();
            SetConnectionListViewColumnWidths();
        }

        private void InitInterfaceListView()
        {
            lvInterface.Columns.Add("Port");
            lvInterface.TooltipTextAddButton = "Click to add a new Interface Port";
            lvInterface.TooltipTextEditButton = "Click to edit the selected Interface Port";
            lvInterface.TooltipTextDeleteButton = "Click to delete the selected Interface Port";
            SetInterfaceListViewColumnWidths();
        }

        private void InitConnectionListView()
        {
            lvSwitchRelays.Columns.Add("Name");
            lvSwitchRelays.TooltipTextAddButton = "Click to add a new Switch Relay Connection";
            lvSwitchRelays.TooltipTextEditButton = "Click to edit the selected Switch Relay Connection";
            lvSwitchRelays.TooltipTextDeleteButton = "Click to delete the selected Switch Relay Connection";
            SetConnectionListViewColumnWidths();
        }


        private void SetInterfaceListViewColumnWidths()
        {
            if( lvInterface.Columns.Count >= 1 )
                lvInterface.Columns[0].Width = lvInterface.Width;
        }

        private void SetConnectionListViewColumnWidths()
        {
            if (lvInterface.Columns.Count >= 1)
                lvInterface.Columns[0].Width = lvInterface.Width;
        }


        protected void DataToControl()
        {
            var @switch = _item as Switch;
            if (@switch != null)
            {
                if (@switch.Interface != null)
                {
                    if (@switch.Interface.Ports != null)
                    {
                        foreach (Port port in @switch.Interface.Ports)
                        {
                            AddInterfacePort(port);
                        }
                    }
                }

                if (@switch.Connections != null)
                {
                    foreach (SwitchRelaySetting srs in @switch.Connections)
                    {
                        AddConnection(srs);
                    }
                }
            }
        }

        private void AddConnection(SwitchRelaySetting srs)
        {
            var lvi = new ListViewItem(srs.name) {Tag = srs};
            lvSwitchRelays.Items.Add(lvi);
        }

        private void AddInterfacePort(Port port)
        {
            var lvi = new ListViewItem(port.ToString());
            lvi.Tag = port;
            lvInterface.Items.Add(lvi);
        }

        protected override void ControlsToData()
        {
            if (_item == null)
                _item = new Switch();
            base.ControlsToData();
            if (((Switch)_item).Interface == null)
                ((Switch)_item).Interface = new Interface();
            if (((Switch)_item).Interface.Ports == null)
                ((Switch)_item).Interface.Ports = new List<Port>();
            ((Switch)_item).Interface.Ports.Clear();
            foreach (ListViewItem lvi in lvInterface.Items)
            {
                var port = lvi.Tag as Port;
                if (port is PhysicalInterfacePortsPort)
                {
                    var p = new Port
                    {
                        direction = port.direction,
                        directionSpecified = port.directionSpecified,
                        Extension = port.Extension,
                        name = port.name,
                        type = port.type,
                        typeSpecified = port.typeSpecified
                    };
                    port = p;
                }

                ((Switch)_item).Interface.Ports.Add(port);
            }

            List<SwitchRelaySetting> srsList =
                (from ListViewItem lvi in lvSwitchRelays.Items select lvi.Tag as SwitchRelaySetting).ToList();

            ((Switch)_item).Connections = srsList;
        }

        private void lvSwitchRelays_OnEdit()
        {
            if (lvSwitchRelays.HasSelected)
            {
                var form = new SwitchRelayForm(GetPortList())
                {
                    SwitchRelaySetting = lvSwitchRelays.SelectedItems[0].Tag as SwitchRelaySetting
                };
                if (DialogResult.OK == form.ShowDialog())
                {
                    lvSwitchRelays.SelectedItems[0].Tag = form.SwitchRelaySetting;
                    lvSwitchRelays.SelectedItems[0].SubItems[0].Text = form.SwitchRelaySetting.name;
                }
            }
        }

        private void lvSwitchRelays_OnDelete()
        {
            if (lvSwitchRelays.HasSelected)
            {
                var srs = lvSwitchRelays.SelectedItems[0].Tag as SwitchRelaySetting;
                if (srs != null)
                {
                    if (DialogResult.Yes == MessageBox.Show(String.Format("Delete Switch Connection \"{0}\"", srs.name),
                                                            @"D E L E T E",
                                                            MessageBoxButtons.YesNo,
                                                            MessageBoxIcon.Question))
                    {
                        lvSwitchRelays.SelectedItems[0].Remove();
                    }
                }
            }
        }

        private void lvSwitchRelays_OnAdd()
        {
            List<Port> ports = GetPortList();
            var form = new SwitchRelayForm(ports);
            if (DialogResult.OK == form.ShowDialog())
            {
                AddConnection(form.SwitchRelaySetting);
            }
        }

        private List<Port> GetPortList()
        {
            return (from ListViewItem lvi in lvInterface.Items select lvi.Tag as Port).ToList();
        }

        private void lvInterface_OnEdit()
        {
            if (lvInterface.HasSelected)
            {
                var form = new PortForm {Port = lvInterface.SelectedItems[0].Tag as Port};
                if (DialogResult.OK == form.ShowDialog())
                {
                    Port port = form.Port;
                    lvInterface.SelectedItems[0].Tag = port;
                    lvInterface.SelectedItems[0].SubItems[0].Text = port.ToString();
                }
            }
        }

        private void lvInterface_OnDelete()
        {
            if (lvInterface.HasSelected)
            {
                var port = lvInterface.SelectedItems[0].Tag as Port;
                if (port != null)
                {
                    if (DialogResult.Yes == MessageBox.Show(String.Format("Delete Interface Port \"{0}\"", port.name),
                                                            @"D E L E T E",
                                                            MessageBoxButtons.YesNo,
                                                            MessageBoxIcon.Question))
                    {
                        lvInterface.SelectedItems[0].Remove();
                    }
                }
            }
        }

        private void lvInterface_OnAdd()
        {
            //------------------------------------------------------------------------------------------------------------------//
            //--- We need to be able to select a port from either the resource interface list or the hardware interface list ---//
            //------------------------------------------------------------------------------------------------------------------//
            var form = new PortSelectionForm(instrument);
            if (DialogResult.OK == form.ShowDialog())
            {
                foreach (Port port in form.SelectedPorts)
                {
                    if (!HasPort(port))
                    {
                        AddInterfacePort(port);
                    }
                }
            }
        }

        private bool HasPort(Port port)
        {
            bool found = false;
            foreach (ListViewItem lvi in lvInterface.Items)
            {
                var port1 = lvi.Tag as Port;
                if (port1 != null) found |= port1.name.Equals(port.name);
            }
            return found;
        }
    }
}