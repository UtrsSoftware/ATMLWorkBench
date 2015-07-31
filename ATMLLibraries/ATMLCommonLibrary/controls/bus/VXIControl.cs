/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
*
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/
using System;
using System.ComponentModel;
using ATMLModelLibrary.model.equipment;

namespace ATMLCommonLibrary.controls.bus
{
    public partial class VXIControl : BusControl
    {
        public VXIControl()
        {
            InitializeComponent();
            InitControls();
            cmbDeviceCategory.DataSource = Enum.GetNames(typeof (DeviceCategory));
            cmbVXIAddressSpace.DataSource = Enum.GetNames(typeof (VXIAddressSpace));
            cmbVXIDeviceClass.DataSource = Enum.GetNames(typeof (VXIDeviceClass));
            cmbSlotSize.DataSource = Enum.GetNames(typeof (VXISlotSize));
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public VXI VXI
        {
            get
            {
                ControlsToData();
                return (VXI) Bus;
            }
            set
            {
                Bus = value;
                DataToControls();
            }
        }

        protected override void DataToControls()
        {
            if (_bus == null)
                return;
            base.DataToControls();
            var vxi = (VXI) _bus;
            edtInteruptLines.Value = vxi.interruptLines;
            edtRequiredMemory.Value = vxi.requiredMemory;
            edtSlotWeight.Value = (decimal) vxi.slotWeight;
            edtMfgId.Value = vxi.manufacturerID;
            edtModelCode.Value = vxi.modelCode;
            edtSlots.Value = vxi.slots;
            chkDynamicConfig.Checked = vxi.dynamicallyConfigured;
            cmbDeviceCategory.SelectedItem = Enum.GetName(typeof(DeviceCategory), vxi.deviceCategory );
            cmbSlotSize.SelectedItem = Enum.GetName(typeof(VXISlotSize), vxi.slotSize );
            cmbVXIAddressSpace.SelectedItem = Enum.GetName(typeof(VXIAddressSpace), vxi.addressSpace );
            cmbVXIDeviceClass.SelectedItem = Enum.GetName(typeof(VXIDeviceClass), vxi.deviceClass );
            vxiDynamicCurrentControl.VXIBackplaneVoltages = vxi.DynamicCurrent;
            vxiECLTriggerControl.VXITriggerLines = vxi.ECLTrigger;
            vxiKeyingControl.VXIKeying = vxi.Keying;
            vxiModuleCoolingControl.VXIModuleCooling = vxi.ModuleCooling;
            vxiPeakCurrentControl.VXIBackplaneVoltages = vxi.PeakCurrent;
            vxiTTLTriggerControl.VXITriggerLines = vxi.TTLTrigger;
            supportedClockSourcesControl.SupportedClockSources = vxi.SupportedClockSources;
        }

        protected override void ControlsToData()
        {
            if (_bus == null)
                _bus = new VXI();
            base.ControlsToData();
            var vxi = (VXI) _bus;
            vxi.interruptLines = (int) edtInteruptLines.Value;
            vxi.requiredMemory = edtRequiredMemory.GetValue<string>();
            vxi.slotWeight = (double) edtSlotWeight.Value;
            vxi.manufacturerID = edtMfgId.GetValue<string>();
            vxi.modelCode = edtModelCode.GetValue<string>();
            vxi.slots = (int) edtSlots.Value;
            vxi.dynamicallyConfigured = chkDynamicConfig.Checked;
            vxi.deviceCategory =
                (DeviceCategory) Enum.Parse(typeof (DeviceCategory), (string) cmbDeviceCategory.SelectedItem);
            vxi.slotSize = (VXISlotSize) Enum.Parse(typeof (VXISlotSize), (string) cmbSlotSize.SelectedItem);
            vxi.addressSpace =
                (VXIAddressSpace) Enum.Parse(typeof (VXIAddressSpace), (string) cmbVXIAddressSpace.SelectedItem);
            vxi.deviceClass =
                (VXIDeviceClass) Enum.Parse(typeof (VXIDeviceClass), (string) cmbVXIDeviceClass.SelectedItem);
            vxi.DynamicCurrent = vxiDynamicCurrentControl.VXIBackplaneVoltages;
            vxi.ECLTrigger = vxiECLTriggerControl.VXITriggerLines;
            vxi.Keying = vxiKeyingControl.VXIKeying;
            vxi.ModuleCooling = vxiModuleCoolingControl.VXIModuleCooling;
            vxi.PeakCurrent = vxiPeakCurrentControl.VXIBackplaneVoltages;
            vxi.TTLTrigger = vxiTTLTriggerControl.VXITriggerLines;
            vxi.SupportedClockSources = supportedClockSourcesControl.SupportedClockSources;
        }
    }
}