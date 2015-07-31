/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
*
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

using System;
using System.Windows.Forms;
using ATMLCommonLibrary.forms;
using ATMLModelLibrary.model.common;
using ATMLModelLibrary.model.equipment;

namespace ATMLCommonLibrary.controls.resource
{
    public partial class ResourcePortSelectionForm : ATMLForm
    {
        /**
         * The Port to check for any other mapped ports to.
         */
        private readonly InstrumentDescription instrument;
        private readonly Port sourcePort;

        public ResourcePortSelectionForm(Port sourcePort, InstrumentDescription instrument)
        {
            InitializeComponent();
            lvResourcePorts.Columns.Add("Port Name");
            lvResourcePorts.Columns[0].Width = lvResourcePorts.Width;
            lvResourcePorts.FullRowSelect = true;
            lvResourcePorts.CheckBoxes = true;
            Resize += ResourcePortSelectionForm_Resize;
            this.sourcePort = sourcePort;
            this.instrument = instrument;
            DataToControls();
            btnOk.Click += btnOk_Click;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            sourcePort.MappedPorts.Clear();
            foreach (ListViewItem lvi in lvResourcePorts.Items)
            {
                if (lvi.Checked)
                {
                    ListViewGroup grp = lvi.Group;
                    var resource = (Resource) grp.Tag;
                    var port = (Port) lvi.Tag;
                    sourcePort.MappedPorts.Add(resource.name + "." + port.name, port);
                }
            }
        }

        private void ResourcePortSelectionForm_Resize(object sender, EventArgs e)
        {
            if (lvResourcePorts.Columns.Count > 0)
                lvResourcePorts.Columns[0].Width = lvResourcePorts.Width;
        }

        protected void DataToControls()
        {
            if (instrument != null && instrument.Resources != null)
            {
                foreach (Resource resource in instrument.Resources)
                {
                    var grp = new ListViewGroup(resource.name);
                    grp.Tag = resource;
                    lvResourcePorts.Groups.Add(grp);
                    if (resource.Interface != null && resource.Interface.Ports != null)
                    {
                        foreach (Port port in resource.Interface.Ports)
                        {
                            var lvi = new ListViewItem(port.name);
                            lvi.Group = grp;
                            lvi.Tag = port;
                            lvResourcePorts.Items.Add(lvi);
                            SetListItemCheckState(resource, port, lvi);
                        }
                    }
                }
            }
        }

        private void SetListItemCheckState(Resource resource, Port port, ListViewItem lvi)
        {
            if (sourcePort != null)
            {
                lvi.Checked = (sourcePort.MappedPorts.ContainsKey(resource.name + "." + port.name));
            }
        }
    }
}