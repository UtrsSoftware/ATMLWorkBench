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
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ATMLCommonLibrary.forms;
using ATMLCommonLibrary.managers;
using ATMLModelLibrary.model.equipment;
using ATMLModelLibrary.model.common;

namespace ATMLCommonLibrary.forms
{
    public partial class PortSelectionForm : ATMLForm
    {


        private InstrumentDescription instrument = null;
        private List<Port> selectedPorts = new List<Port>();
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public List<Port> SelectedPorts
        {
            get { return selectedPorts; }
            set { selectedPorts = value; }
        }

        public PortSelectionForm(InstrumentDescription instrument)
        {
            InitializeComponent();
            InitResourcePortList();
            InitPhysicalPortList();
            Resize += new EventHandler(ResourcePortSelectionForm_Resize);
            this.instrument = instrument;
            DataToControls();
            btnOk.Click += new EventHandler(btnOk_Click);
        }

        private void InitResourcePortList()
        {
            lvResourcePorts.Columns.Add("Port Name");
            lvResourcePorts.Columns[0].Width = lvResourcePorts.Width;
            lvResourcePorts.FullRowSelect = true;
            lvResourcePorts.CheckBoxes = true;
        }

        private void InitPhysicalPortList()
        {
            lvPhysicalPorts.Columns.Add("Port Name");
            lvPhysicalPorts.Columns[0].Width = lvPhysicalPorts.Width;
            lvPhysicalPorts.FullRowSelect = true;
            lvPhysicalPorts.CheckBoxes = true;
        }

        void btnOk_Click(object sender, EventArgs e)
        {
            selectedPorts.Clear();
            foreach (ListViewItem lvi in lvResourcePorts.Items)
            {
                if (lvi.Checked)
                {
                    ListViewGroup grp = lvi.Group;
                    Resource resource = (Resource)grp.Tag;
                    Port port = (Port)lvi.Tag;
                    selectedPorts.Add(port);
                }
            }
            foreach (ListViewItem lvi in lvPhysicalPorts.Items)
            {
                if (lvi.Checked)
                {
                    Port port = (Port)lvi.Tag;
                    selectedPorts.Add(port);
                }
            }
        }

        void ResourcePortSelectionForm_Resize(object sender, EventArgs e)
        {
            if( lvResourcePorts.Columns.Count >= 1 )
                lvResourcePorts.Columns[0].Width = lvResourcePorts.Width;
            if (lvPhysicalPorts.Columns.Count >= 1 )
                lvPhysicalPorts.Columns[0].Width = lvPhysicalPorts.Width;
        }

        protected void DataToControls()
        {
            if (instrument != null )
            {
                FillResourcePortList();
                FillPhysicalPortList();
            }
        }

        private void FillResourcePortList()
        {
            if (instrument.Resources != null)
            {
                foreach (Resource resource in instrument.Resources)
                {
                    ListViewGroup grp = new ListViewGroup(resource.name);
                    grp.Tag = resource;
                    lvResourcePorts.Groups.Add(grp);
                    if (resource.Interface != null && resource.Interface.Ports != null)
                    {
                        foreach (Port port in resource.Interface.Ports)
                        {
                            ListViewItem lvi = new ListViewItem(port.name);
                            lvi.Group = grp;
                            lvi.Tag = port;
                            lvResourcePorts.Items.Add(lvi);
                            SetListItemCheckState(resource, port, lvi);
                        }
                    }
                }
            }
        }


        private void FillPhysicalPortList()
        {
            if ( instrument.Interface != null  )
            {
                foreach (object obj in instrument.Interface )
                {
                    if (obj is PhysicalInterfacePorts)
                    {
                        PhysicalInterfacePorts pip = obj as PhysicalInterfacePorts;
                        if (pip.Port != null)
                        {
                            foreach (Port port in pip.Port)
                            {
                                //ListViewGroup grp = new ListViewGroup(port.name);
                                //grp.Tag = port;
                                //lvResourcePorts.Groups.Add(grp);
                                //if (resource.Interface != null && resource.Interface.Ports != null)
                                //{
                                //    foreach (Port port in resource.Interface.Ports)
                                //    {
                                        ListViewItem lvi = new ListViewItem(port.name);
                                        //lvi.Group = grp;
                                        lvi.Tag = port;
                                        lvPhysicalPorts.Items.Add(lvi);
                                        SetListItemCheckState( port, lvi);
                                //    }
                                //}
                            }
                        }
                    }
                }
            }
        }


        private void SetListItemCheckState(Resource resource, Port port, ListViewItem lvi)
        {
        }

        private void SetListItemCheckState(Port port, ListViewItem lvi)
        {
        }


        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
