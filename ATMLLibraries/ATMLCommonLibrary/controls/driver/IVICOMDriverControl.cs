/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
* 
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

using System.ComponentModel;
using ATMLCommonLibrary.controls.hardware;
using ATMLModelLibrary.model.equipment;

namespace ATMLCommonLibrary.controls.driver
{
    public partial class IVICOMDriverControl : IVIDriverControl
    {
        public IVICOMDriverControl()
        {
            InitializeComponent();
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new IVICOM Driver
        {
            get
            {
                ControlsToData();
                return _driver as IVICOM;
            }
            set
            {
                _driver = value;
                DataToControls();
            }
        }

        protected override void DataToControls()
        {
            if (_driver != null)
            {
                base.DataToControls();
                var ivicom = _driver as IVICOM;
                if (ivicom != null)
                {
                    edtProgID.Value = ivicom.progID;
                }
            }
        }

        protected override void ControlsToData()
        {
            if (_driver == null)
                _driver = new IVICOM();
            base.ControlsToData();
            var ivicom = _driver as IVICOM;
            if (ivicom != null)
                ivicom.progID = edtProgID.GetValue<string>();
        }

        protected override void OnValidating( CancelEventArgs e )
        {
            //string saved = _versionIdentifier == null ? null : _versionIdentifier.Serialize();
            //ControlsToData();
            //ValidateToSchema(_versionIdentifier);
            //_versionIdentifier = string.IsNullOrEmpty(saved) ? null : VersionIdentifier.Deserialize(saved);
        }
    }
}