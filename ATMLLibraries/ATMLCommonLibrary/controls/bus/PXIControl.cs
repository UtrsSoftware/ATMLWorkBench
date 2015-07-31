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
    public partial class PXIControl : PCIControl
    {
        public PXIControl()
        {
            InitializeComponent();
            InitControls();
            cmbSlotSize.DataSource = Enum.GetNames(typeof (PXISlotSize));
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public PXI PXI
        {
            set
            {
                Bus = value;
                DataToControls();
            }
            get
            {
                ControlsToData();
                return _bus as PXI;
            }
        }

        protected override void DataToControls()
        {
            if (_bus == null) return;
            base.DataToControls();
            PXI pxi = (PXI) _bus;
            dynamicCurrentControl.PXIBackplaneVoltages = pxi.DynamicCurrent;
            peakCurrentControl.PXIBackplaneVoltages = pxi.PeakCurrent;
            edtMemorySize.Value = pxi.memorySize;
            edtSlotWeight.Value = (decimal)pxi.slotWeigth;
            edtSlots.Value = pxi.slots;
            peakCurrentControl.PXIBackplaneVoltages = pxi.PeakCurrent;
            dynamicCurrentControl.PXIBackplaneVoltages = pxi.DynamicCurrent;
            supportedClockServiceControl.SupportedClockSources = pxi.SupportedClockSources;
            cmbSlotSize.SelectedItem = Enum.GetName(typeof(PXISlotSize),pxi.slotSize);
        }

        protected override void ControlsToData()
        {
            if (_bus == null)
                _bus = new PXI();
            base.ControlsToData();
            PXI pxi = (PXI)_bus;
            pxi.DynamicCurrent = dynamicCurrentControl.PXIBackplaneVoltages;
            pxi.PeakCurrent = peakCurrentControl.PXIBackplaneVoltages;
            pxi.memorySize = (int)edtMemorySize.Value;
            pxi.slotWeigth = (double)edtSlotWeight.Value;
            pxi.slots = (int)edtSlots.Value;
            pxi.PeakCurrent = peakCurrentControl.PXIBackplaneVoltages;
            pxi.DynamicCurrent = dynamicCurrentControl.PXIBackplaneVoltages;
            pxi.SupportedClockSources = supportedClockServiceControl.SupportedClockSources;
            pxi.slotSize = (PXISlotSize)Enum.Parse(typeof(PXISlotSize), (string)cmbSlotSize.SelectedItem);
        }
    }
}