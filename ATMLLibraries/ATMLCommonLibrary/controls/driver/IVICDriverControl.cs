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
    public partial class IVICDriverControl : IVIDriverControl
    {
        public IVICDriverControl()
        {
            InitializeComponent();
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new IVIC Driver
        {
            get
            {
                ControlsToData();
                return _driver as IVIC;
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
                var ivic = _driver as IVIC;
                base.DataToControls();
                if (ivic != null)
                {
                    edtPrefix.Value = ivic.prefix;
                }
            }
        }

        protected override void ControlsToData()
        {
            if (_driver == null)
                _driver = new IVIC();
            base.ControlsToData();
            var ivic = _driver as IVIC;
            if( ivic != null )
                ivic.prefix = edtPrefix.GetValue<string>();
        }

        protected override void OnValidating(CancelEventArgs e)
        {
            //string saved = _versionIdentifier == null ? null : _versionIdentifier.Serialize();
            //ControlsToData();
            //ValidateToSchema(_versionIdentifier);
            //_versionIdentifier = string.IsNullOrEmpty(saved) ? null : VersionIdentifier.Deserialize(saved);
        }

        private void tabClass_Click(object sender, System.EventArgs e)
        {

        }

    }
}