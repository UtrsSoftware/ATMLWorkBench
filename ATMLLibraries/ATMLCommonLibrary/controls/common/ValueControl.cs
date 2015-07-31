/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
*
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/
using System;
using System.ComponentModel;
using System.Windows.Forms;
using ATMLModelLibrary.model.common;

namespace ATMLCommonLibrary.controls.common
{
    public partial class ValueControl : UserControl
    {
        private int _defaultComparitor = -1;
        private int _defaultDataType = 1;
        private bool _locked;

        protected Value _value;

        public bool LockTypes 
        {
            get { return _locked; }
            set { _locked = value; 
                SetControlStates(); }
        }

        public ValueControl()
        {
            InitializeComponent();
            datumTypeControl.DefaultComparitor = _defaultComparitor;
            cmbValueType.SelectedIndex = 1;
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int DefaultComparitor
        {
            get { return _defaultComparitor; }
            set { _defaultComparitor = value;
                cmbValueType.SelectedIndex = value;
            }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Value Value
        {
            get
            {
                ControlsToData();
                return _value;
            }
            set
            {
                _value = value;
                DataToControls();
            }
        }

        public int DefaultDataType
        {
            get { return _defaultDataType; }
            set { _defaultDataType = value;
                indexArrayControl.DefaultDataType = value;
            }
        }

        private void cmbValueType_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetControlStates();
            datumTypeControl.DefaultDataType = _defaultDataType;
            indexArrayControl.DefaultDataType = _defaultDataType;
        }

        private void SetControlStates()
        {
            collectionControl.Enabled = collectionControl.Visible = @"Collection".Equals(cmbValueType.Text);
            datumTypeControl.Enabled = datumTypeControl.Visible = @"Datum".Equals(cmbValueType.Text);
            indexArrayControl.Enabled = indexArrayControl.Visible = @"Indexed Array".Equals(cmbValueType.Text);
            indexArrayControl.LockTypes = _locked;
            datumTypeControl.LockTypes = _locked;
            collectionControl.LockTypes = _locked;
            cmbValueType.Enabled = !_locked;
        }

        protected virtual void ControlsToData()
        {
            if (_value == null)
                _value = new Value();

            if ("Collection".Equals(cmbValueType.Text))
            {
                _value.Item = collectionControl.Collection;
            }
            else if ("Datum".Equals(cmbValueType.Text))
            {
                _value.Item = datumTypeControl.Datum;
            }
            else if ("Indexed Array".Equals(cmbValueType.Text))
            {
                _value.Item = indexArrayControl.IndexedArray;
            }
        }

        protected virtual void DataToControls()
        {
            if (_value != null)
            {
                if (_value.Item is DatumType)
                {
                    cmbValueType.SelectedIndex = cmbValueType.FindStringExact("Datum");
                    datumTypeControl.Datum = (DatumType)_value.Item;
                    datumTypeControl.LockTypes = this.LockTypes;
                }
                else if (_value.Item is Collection)
                {
                    cmbValueType.SelectedIndex = cmbValueType.FindStringExact("Collection");
                    collectionControl.Collection = (Collection)_value.Item;
                }
                else if (_value.Item is IndexedArrayType)
                {
                    cmbValueType.SelectedIndex = cmbValueType.FindStringExact("Indexed Array");
                    indexArrayControl.IndexedArray = (IndexedArrayType)_value.Item;
                }

                SetControlStates();
            }
        }

        private void indexArrayControl_Load(object sender, EventArgs e)
        {
        }
    }
}