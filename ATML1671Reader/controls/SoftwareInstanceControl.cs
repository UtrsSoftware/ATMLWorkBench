/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
* 
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

using System.ComponentModel;
using ATMLModelLibrary.model.common;

namespace ATML1671Reader.controls
{
    public partial class SoftwareInstanceControl : ItemInstanceControl
    {
        public SoftwareInstanceControl()
        {
            InitializeComponent();
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public SoftwareInstance SoftwareInstance
        {
            set
            {
                _itemDescriptionReference = value;
                DataToControls();
            }
            get
            {
                ControlsToData();
                return _itemDescriptionReference as SoftwareInstance;
            }
        }

        protected new void DataToControls()
        {
            base.DataToControls();
            if (_itemDescriptionReference != null)
            {
                var instance = _itemDescriptionReference as SoftwareInstance;
                if (instance != null)
                {
                    dteReleaseDate.Checked = instance.ReleaseDateSpecified;
                    if (dteReleaseDate.Checked)
                    {
                        dteReleaseDate.Value = instance.ReleaseDate;
                    }
                }
            }
        }

        protected new void ControlsToData()
        {
            if (_itemDescriptionReference == null)
                _itemDescriptionReference = new SoftwareInstance();
            base.ControlsToData();
            var instance = _itemDescriptionReference as SoftwareInstance;
            if (instance != null)
            {
                instance.ReleaseDateSpecified = dteReleaseDate.Checked;
                if (dteReleaseDate.Checked)
                    instance.ReleaseDate = dteReleaseDate.Value;
            }
        }
    }
}