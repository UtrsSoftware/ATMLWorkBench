/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
* 
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

using System.Windows.Forms;
using ATMLModelLibrary.model.common;

namespace ATML1671Reader.controls
{
    public partial class CheckSumControl : UserControl
    {
        private ConfigurationSoftwareReferenceChecksum _checksum;

        public CheckSumControl()
        {
            InitializeComponent();
        }

        public ConfigurationSoftwareReferenceChecksum Checksum
        {
            get
            {
                ControlsToData(); return _checksum; }
            set { _checksum = value; DataToControls(); }
        }

        protected virtual void ControlsToData()
        {
            if (edtValue.HasValue())
            {
                if (_checksum == null)
                    _checksum = new ConfigurationSoftwareReferenceChecksum();
                _checksum.type = edtType.GetValue<string>();
                _checksum.value = edtValue.GetValue<string>();
            }
            else
            {
                _checksum = null;
            }
        }

        protected virtual void DataToControls()
        {
            if (_checksum != null)
            {
                edtType.Value = _checksum.type;
                edtValue.Value = _checksum.value;
            }
        }
    
    }
}
