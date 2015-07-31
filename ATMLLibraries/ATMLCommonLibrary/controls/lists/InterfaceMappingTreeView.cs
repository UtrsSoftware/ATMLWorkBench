/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
* 
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ATMLModelLibrary.model.common;
using ATMLModelLibrary.model.equipment;

namespace ATMLCommonLibrary.controls.lists
{
    public class InterfaceMappingTreeView : TreeView
    {
        private ItemDescription _item;

        public ItemDescription Item
        {
            get { return _item; }
            set { _item = value;
                Load();
            }
        }


        private void Load()
        {
            HardwareItemDescription hid = _item as HardwareItemDescription;
            if (hid != null)
            {
                Nodes.Add(hid.GetType().Name, hid.GetType().Name );
                List<object> ports = hid.Interface;
                if (ports != null)
                {
                    foreach (object port in ports)
                    {
                        PhysicalInterfacePorts pip = port as PhysicalInterfacePorts;
                        if (pip != null)
                        {
                            List<PhysicalInterfacePortsPort> pipps = pip.Port;
                            if (pipps != null)
                            {
                                foreach (PhysicalInterfacePortsPort pipp in pipps)
                                {
                                    string name = pipp.name;
                                    string direction = pipp.directionSpecified?pipp.direction.ToString():"";
                                    string type = pipp.typeSpecified ? pipp.type.ToString() : "";
                                    Nodes[hid.GetType().Name].Nodes.Add(name, name + " " + direction + " " + type );
                                    Nodes[hid.GetType().Name].Nodes[name].Tag = pipp;
                                }
                            }
                        }
                    }
                }
            }
        }

    }
}
