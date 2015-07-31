/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
*
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

using System.ComponentModel;
using ATMLModelLibrary.model.equipment;

namespace ATMLCommonLibrary.controls.path
{
    public partial class PathSParameterControl : ATMLControl
    {
        private PathSParameter _pathSParameter;

        public PathSParameterControl()
        {
            InitializeComponent();
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public PathSParameter PathSParameter
        {
            get
            {
                ControlsToData();
                return _pathSParameter;
            }
            set
            {
                _pathSParameter = value;
                DataToControls();
            }
        }

        private void DataToControls()
        {
            if (_pathSParameter != null)
            {
                edtInputPort.Value = _pathSParameter.inputPort;
                edtOutputPort.Value = _pathSParameter.outputPort;
                PathList.PathData = _pathSParameter.SParameterData;
            }
        }

        private void ControlsToData()
        {
            if (_pathSParameter == null)
                _pathSParameter = new PathSParameter();
            _pathSParameter.inputPort = edtInputPort.GetValue<string>();
            _pathSParameter.outputPort = edtOutputPort.GetValue<string>();
            _pathSParameter.SParameterData = PathList.PathData;
        }
    }
}