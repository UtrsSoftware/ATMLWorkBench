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

namespace ATMLCommonLibrary.controls.driver
{
    public partial class DriverSelectionControl : ATMLControl
    {
        public enum DriverType
        { 
            IVIC = 0,
            IVICOM = 1,
            IVINET = 2,
            VPPD = 3
        }

        private Driver _selectedDriver;

        public event EventHandler DriverSelected;

        protected virtual void OnSelectedDriver(DriverSelectEvent driverElectedEventArgs )
        {
            EventHandler handler = DriverSelected;
            if (handler != null) handler(this, driverElectedEventArgs);
        }

        public DriverSelectionControl()
        {
            InitializeComponent();
            ivicDriverControl1.Enabled = ivicDriverControl1.Visible = false;
            ivicomDriverControl1.Enabled = ivicomDriverControl1.Visible = false;
            ivinetDriverControl1.Enabled = ivinetDriverControl1.Visible = false;
            vppDriverControl1.Enabled = vppDriverControl1.Visible = false;
        }

        [Browsable( false ), DesignerSerializationVisibility( DesignerSerializationVisibility.Hidden )]
        public Driver DriverSelect
        {
            get
            {
                ControlsToData(); 
                return _selectedDriver; 
            }
            set
            {
                _selectedDriver = value;
                DataToControls();
            }
            
        }

        protected void ControlsToData()
        {
            switch (cmbSelectedDriver.SelectedIndex)
            {
                case (int)DriverType.IVIC:
                    _selectedDriver = ivicDriverControl1.Driver;
                    break;
                case (int)DriverType.IVICOM:
                    _selectedDriver = ivicomDriverControl1.Driver;
                    break;
                case (int)DriverType.IVINET:
                    _selectedDriver = ivinetDriverControl1.Driver;
                    break;
                case (int)DriverType.VPPD:
                    _selectedDriver = vppDriverControl1.Driver;
                    break;
            }
        }

        protected void DataToControls()
        {
            if (_selectedDriver != null)
            {
                if (_selectedDriver is IVIC)
                {
                    ivicDriverControl1.Driver = _selectedDriver as IVIC;
                    cmbSelectedDriver.SelectedIndex = (int)DriverType.IVIC;
                }
                else if (_selectedDriver is IVICOM)
                {
                    ivicomDriverControl1.Driver = _selectedDriver as IVICOM;
                    cmbSelectedDriver.SelectedIndex = (int)DriverType.IVICOM;
                }
                else if (_selectedDriver is IVINET)
                {
                    ivinetDriverControl1.Driver = _selectedDriver as IVINET;
                    cmbSelectedDriver.SelectedIndex = (int)DriverType.IVINET;
                }
                else if (_selectedDriver is VPP)
                {
                    vppDriverControl1.Driver = _selectedDriver as VPP;
                    cmbSelectedDriver.SelectedIndex = (int)DriverType.VPPD;
                }
            }
        }

        private void cmbDriverSelect_SelectedIndexChanged( object sender, EventArgs e )
        {
            ivicDriverControl1.Enabled = ivicDriverControl1.Visible = cmbSelectedDriver.SelectedIndex == 0;
            ivicomDriverControl1.Enabled = ivicomDriverControl1.Visible = cmbSelectedDriver.SelectedIndex == 1;
            ivinetDriverControl1.Enabled = ivinetDriverControl1.Visible = cmbSelectedDriver.SelectedIndex == 2;
            vppDriverControl1.Enabled = vppDriverControl1.Visible = cmbSelectedDriver.SelectedIndex == 3;
            if (cmbSelectedDriver.SelectedIndex == (int)DriverType.IVIC)
            {
                _selectedDriver = ivicDriverControl1.Driver;
            }
            else if (cmbSelectedDriver.SelectedIndex == (int)DriverType.IVICOM)
            {
                _selectedDriver = ivicomDriverControl1.Driver;
            }
            else if (cmbSelectedDriver.SelectedIndex == (int)DriverType.IVINET)
            {
                _selectedDriver = ivinetDriverControl1.Driver;
            }
            else if (cmbSelectedDriver.SelectedIndex == (int)DriverType.VPPD)
            {
                _selectedDriver = vppDriverControl1.Driver;
            }
            OnSelectedDriver(new DriverSelectEvent( (DriverType)cmbSelectedDriver.SelectedIndex));
        }
    }

    public class DriverSelectEvent : EventArgs
    {
        public DriverSelectEvent( DriverSelectionControl.DriverType driverType )
        {
            DriverType = driverType;
        }
        public DriverSelectionControl.DriverType DriverType { set; get; }
    }


}