/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
*
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/
using System;
using System.ComponentModel;
using System.Windows.Forms;
using ATMLCommonLibrary.forms;
using ATMLModelLibrary.model.equipment;

namespace ATMLCommonLibrary.controls.bus
{
    public partial class BusForm : ATMLForm
    {
        private const int _EIA232 = 0;
        private const int _Ethernet = 1;
        private const int _IEEE488 = 2;
        private const int _IEEE1394 = 3;
        private const int _LXI = 4;
        private const int _PCI = 5;
        private const int _PCIe = 6;
        private const int _PXI = 7;
        private const int _PXIe = 8;
        private const int _USB = 9;
        private const int _VME = 10;
        private const int _VXI = 11;

        private readonly string[] titles =
        {
            "EIA-232", "Ethernet", "IEEE-488", "IEEE-1394", "LXI", "PCI", "PCIe", "PXI",
            "PXIe", "USB", "VME", "VXI"
        };

        private Bus bus;

        public BusForm()
        {
            InitializeComponent();
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Bus Bus
        {
            get
            {
                ControlsToData();
                return bus;
            }
            set
            {
                bus = value;
                DataToControls();
            }
        }

        private void DataToControls()
        {
            if (bus != null)
            {
                Type type = bus.GetType();
                cmbBusType.SelectedIndex = cmbBusType.FindStringExact(type.Name);
                switch (cmbBusType.SelectedIndex)
                {
                    case _EIA232:
                        eiA232Control.EIA232 = bus as EIA232;
                        break;
                    case _Ethernet:
                        ethernetControl.Ethernet = bus as Ethernet;
                        break;
                    case _IEEE488:
                        ieeE488Control.IEEE488 = bus as IEEE488;
                        break;
                    case _IEEE1394:
                        ieeE1394Control.IEEE1394 = bus as IEEE1394;
                        break;
                    case _LXI:
                        lxiControl.LXI = bus as LXI;
                        break;
                    case _PCI:
                        pciControl.PCI = bus as PCI;
                        break;
                    case _PCIe:
                        pcIeControl.PCIe = bus as PCIe;
                        break;
                    case _PXI:
                        pxiControl.PXI = bus as PXI;
                        break;
                    case _PXIe:
                        pxIeControl.PXIe = bus as PXIe;
                        break;
                    case _USB:
                        usbControl.USB = bus as USB;
                        break;
                    case _VME:
                        vmeControl.VME = bus as VME;
                        break;
                    case _VXI:
                        vxiControl.VXI = bus as VXI;
                        break;
                }
            }
        }

        private void ControlsToData()
        {
            switch (cmbBusType.SelectedIndex)
            {
                case _EIA232:
                    bus = eiA232Control.EIA232;
                    break;
                case _Ethernet:
                    bus = ethernetControl.Ethernet;
                    break;
                case _IEEE488:
                    bus = ieeE488Control.IEEE488;
                    break;
                case _IEEE1394:
                    bus = ieeE1394Control.IEEE1394;
                    break;
                case _LXI:
                    bus = lxiControl.LXI;
                    break;
                case _PCI:
                    bus = pciControl.PCI;
                    break;
                case _PCIe:
                    bus = pcIeControl.PCIe;
                    break;
                case _PXI:
                    bus = pxiControl.PXI;
                    break;
                case _PXIe:
                    bus = pxIeControl.PXIe;
                    break;
                case _USB:
                    bus = usbControl.USB;
                    break;
                case _VME:
                    bus = vmeControl.VME;
                    break;
                case _VXI:
                    bus = vxiControl.VXI;
                    break;
            }
        }

        private void cmbBusType_SelectedIndexChanged(object sender, EventArgs e)
        {
            pcIeControl.Enabled = pcIeControl.Visible = cmbBusType.SelectedIndex == _PCIe;
            vxiControl.Enabled = vxiControl.Visible = cmbBusType.SelectedIndex == _VXI;
            pxIeControl.Enabled = pxIeControl.Visible = cmbBusType.SelectedIndex == _PXIe;
            pxiControl.Enabled = pxiControl.Visible = cmbBusType.SelectedIndex == _PXI;
            pciControl.Enabled = pciControl.Visible = cmbBusType.SelectedIndex == _PCI;
            eiA232Control.Enabled = eiA232Control.Visible = cmbBusType.SelectedIndex == _EIA232;
            ethernetControl.Enabled = ethernetControl.Visible = cmbBusType.SelectedIndex == _Ethernet;
            usbControl.Enabled = usbControl.Visible = cmbBusType.SelectedIndex == _USB;
            vmeControl.Enabled = vmeControl.Visible = cmbBusType.SelectedIndex == _VME;
            lxiControl.Enabled = lxiControl.Visible = cmbBusType.SelectedIndex == _LXI;
            ieeE1394Control.Enabled = ieeE1394Control.Visible = cmbBusType.SelectedIndex == _IEEE1394;
            ieeE488Control.Enabled = ieeE488Control.Visible = cmbBusType.SelectedIndex == _IEEE488;
            Text = string.Format("{0} Bus", titles[cmbBusType.SelectedIndex]);
        }
    }
}