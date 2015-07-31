/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
*
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/
using System.ComponentModel;
using ATMLModelLibrary.model.equipment;

namespace ATMLCommonLibrary.controls.bus
{
    public partial class VXIKeyingControl : ATMLControl
    {
        private VXIKeying _VXIKeying;

        public VXIKeyingControl()
        {
            InitializeComponent();
            InitControls();
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public VXIKeying VXIKeying
        {
            get{ ControlsToData(); return _VXIKeying; }
            set { _VXIKeying = value; DataToControls(); }
        }


        private void DataToControls()
        {
            if (_VXIKeying != null)
            {
                edtBottomLeft.Value = _VXIKeying.bottomLeft;
                edtBottomRight.Value = _VXIKeying.bottomRight;
                edtTopLeft.Value = _VXIKeying.topLeft;
                edtTopRight.Value = _VXIKeying.topRight;
            }
        }

        private void ControlsToData()
        {
            if (_VXIKeying == null)
                _VXIKeying = new VXIKeying();
            _VXIKeying.bottomLeft = (int) edtBottomLeft.Value;
            _VXIKeying.bottomRight = (int) edtBottomRight.Value;
            _VXIKeying.topLeft = (int) edtTopLeft.Value;
            _VXIKeying.topRight = (int) edtTopRight.Value;
        }
    }
}