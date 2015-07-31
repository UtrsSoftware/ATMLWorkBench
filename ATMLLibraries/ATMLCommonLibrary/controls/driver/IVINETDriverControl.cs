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
    public partial class IVINETDriverControl : IVIDriverControl
    {
        public IVINETDriverControl()
        {
            InitializeComponent();
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new IVINET Driver
        {
            get
            {
                ControlsToData();
                return _driver as IVINET;
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
                var ivinet = _driver as IVINET;
                base.DataToControls();
                if (ivinet != null)
                {
                    edtClassName.Value = ivinet.assemblyQualifiedClassName;
                }
            }
        }

        protected override void ControlsToData()
        {
            if (_driver == null)
                _driver = new IVINET();
            base.ControlsToData();
            var ivinet = _driver as IVINET;
            if( ivinet != null )
                ivinet.assemblyQualifiedClassName = edtClassName.GetValue<string>();
        }

        protected override void OnValidating(CancelEventArgs e)
        {
            //string saved = _versionIdentifier == null ? null : _versionIdentifier.Serialize();
            //ControlsToData();
            //ValidateToSchema(_versionIdentifier);
            //_versionIdentifier = string.IsNullOrEmpty(saved) ? null : VersionIdentifier.Deserialize(saved);
        }

    }
}