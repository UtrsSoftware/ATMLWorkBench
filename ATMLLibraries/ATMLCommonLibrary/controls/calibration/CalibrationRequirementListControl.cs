/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
*
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using ATMLCommonLibrary.controls.lists;
using ATMLModelLibrary.model.equipment;

namespace ATMLCommonLibrary.controls.calibration
{
    public partial class CalibrationRequirementListControl : ATMLListControl
    {
        private List<HardwareItemDescriptionCalibrationRequirement> _calibrationReq =
            new List<HardwareItemDescriptionCalibrationRequirement>();

        public CalibrationRequirementListControl()
        {
            InitializeComponent();
            InitListView();
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public List<HardwareItemDescriptionCalibrationRequirement> CalibrationRequirements
        {
            get { ControlsToData(); return _calibrationReq; }
            set { _calibrationReq = value; DataToControls(); }
        }

        private void InitListView()
        {
            DataObjectName = "HardwareItemDescriptionCalibrationRequirement";
            DataObjectFormType = typeof (CalibrationRequirementsForm);
            AddColumnData("Frequency", "frequency", 1);
            InitColumns();
        }

        private void DataToControls()
        {
            if (_calibrationReq != null)
            {
                lvList.Items.Clear();
                foreach (HardwareItemDescriptionCalibrationRequirement resource in _calibrationReq)
                {
                    AddListViewObject(resource);
                }
            }
        }

        private void ControlsToData()
        {
            _calibrationReq = null;
            if (lvList.Items.Count > 0)
            {
                _calibrationReq = new List<HardwareItemDescriptionCalibrationRequirement>();
                foreach (ListViewItem lvi in lvList.Items)
                {
                    var calibreq = (HardwareItemDescriptionCalibrationRequirement) lvi.Tag;
                    _calibrationReq.Add(calibreq);
                }
            }
        }
    }
}