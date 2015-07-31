/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
*
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

using System;
using ATMLModelLibrary.model.equipment;

namespace ATMLCommonLibrary.controls.driver
{
    public partial class DriverControl : ATMLControl
    {
        protected Driver _driver;

        public DriverControl()
        {
            InitializeComponent();
            cmbDriverType.DataSource = Enum.GetNames( typeof (DriverItemChoiceType) );
        }

        public Driver Driver
        {
            get
            {
                ControlsToData();
                return _driver;
            }
            set
            {
                _driver = value;
                DataToControls();
            }
        }

        public event EventHandler SelectedModule;

        protected virtual void DataToControls()
        {
            if (_driver != null)
            {
                cmbDriverType.SelectedIndex = (int)_driver.ItemElementName;
                var module = _driver.Item as DriverModule;
                var unified = _driver.Item as DriverUnified;
                if (module != null)
                {
                    driverModuleControl.DriverModule = module;
                    driverModuleControl.DriverItemChoiceType = _driver.ItemElementName;
                }
                if (unified != null)
                {
                    driverUnifiedControl.DriverUnified = unified;
                }
            }
        }

        protected virtual void ControlsToData()
        {
            if (_driver != null)
            {
                _driver.ItemElementName = (DriverItemChoiceType)Enum.Parse(typeof(DriverItemChoiceType), cmbDriverType.SelectedItem.ToString());
                if (_driver.ItemElementName == DriverItemChoiceType.Unified )
                    _driver.Item = driverUnifiedControl.DriverUnified;
                else
                    _driver.Item = driverModuleControl.DriverModule;
            }
        }

        protected virtual void OnSelectedModule( ModuleSelectEventArgs moduleSelectEventArgs )
        {
            EventHandler handler = SelectedModule;
            if (handler != null) handler( this, moduleSelectEventArgs );
        }

        private void cmbVersionIdentifierQualifier_SelectedIndexChanged( object sender, EventArgs e )
        {
            string unifiedName = Enum.GetName( typeof (DriverItemChoiceType), DriverItemChoiceType.Unified );
            if (unifiedName != null && unifiedName.Equals( cmbDriverType.SelectedItem ))
            {
                driverModuleControl.Enabled = driverModuleControl.Visible = false;
                driverUnifiedControl.Enabled = driverUnifiedControl.Visible = true;
            }
            else
            {
                driverModuleControl.Enabled = driverModuleControl.Visible = true;
                driverUnifiedControl.Enabled = driverUnifiedControl.Visible = false;
            }
            var moduleSelectEventArgs = new ModuleSelectEventArgs();
            driverModuleControl.DriverItemChoiceType =
                moduleSelectEventArgs.DriverItemChoiceType =
                (DriverItemChoiceType)
                Enum.Parse( typeof (DriverItemChoiceType), cmbDriverType.SelectedItem.ToString() );
            OnSelectedModule( moduleSelectEventArgs );
        }
    }

    public class ModuleSelectEventArgs : EventArgs
    {
        public DriverItemChoiceType DriverItemChoiceType { set; get; }
    }
}