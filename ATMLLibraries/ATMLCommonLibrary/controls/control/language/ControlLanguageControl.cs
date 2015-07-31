/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
*
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

using System;
using System.ComponentModel;
using ATMLCommonLibrary.controls.document;
using ATMLModelLibrary.model.equipment;

namespace ATMLCommonLibrary.controls.control.language
{
    public partial class ControlLanguageControl : DocumentControl
    {
        private ControlLanguage _controlLanguage;

        public ControlLanguageControl()
        {
            InitializeComponent();
            rdoGeneric.Checked = true;
            rdoSCPI.CheckedChanged += rdoSCPI_CheckedChanged;
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ControlLanguage ControlLanguage
        {
            set
            {
                _controlLanguage = value;
                DataToControls();
            }
            get
            {
                ControlsToData();
                return _controlLanguage;
            }
        }

        private void rdoSCPI_CheckedChanged(object sender, EventArgs e)
        {
            int i = 0;
        }

        protected new void ControlsToData()
        {
            base.ControlsToData();
            if (_controlLanguage == null)
            {
                if (rdoGeneric.Checked)
                    _controlLanguage = new Generic();
                else if (rdoRegister.Checked)
                    _controlLanguage = new Register();
                else if (rdoSCPI.Checked)
                    _controlLanguage = new SCPI();
                else
                {
                    _controlLanguage = new Generic();
                    rdoGeneric.Checked = true;
                }
            }
            if (rdoGeneric.Checked && !(_controlLanguage is Generic))
            {
                _controlLanguage = new Generic();
            }
            if (rdoRegister.Checked && !(_controlLanguage is Register))
            {
                _controlLanguage = new Register();
            }
            if (rdoSCPI.Checked && !(_controlLanguage is SCPI))
            {
                _controlLanguage = new SCPI();
            }

            _controlLanguage.Documentation = _document;
        }

        private new void DataToControls()
        {
            base.DataToControls();
            if (_controlLanguage != null)
            {
                rdoGeneric.Checked = _controlLanguage is Generic;
                rdoRegister.Checked = _controlLanguage is Register;
                rdoSCPI.Checked = _controlLanguage is SCPI;
                Document = _controlLanguage.Documentation;
            }
        }
    }
}