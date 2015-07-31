/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
*
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/
using System;
using System.ComponentModel;
using System.Drawing;
using ATMLModelLibrary.model.common;

namespace ATMLCommonLibrary.controls.collection
{
    [ToolboxItem( true ), ToolboxBitmap( typeof (CollectionControl), "Resources.CollectionControl.bmp" )]
    public partial class CollectionControl : ATMLControl
    {
        private bool _locked;
        private Collection collection;


        public CollectionControl()
        {
            InitializeComponent();
            InitControls();
            //string[] sa = this.GetType().Assembly.GetManifestResourceNames();
            //collectionListControl.Columns.Add("Name");
            //collectionListControl.Columns.Add("Value");
        }

        public bool LockTypes
        {
            get { return _locked; }
            set
            {
                _locked = value;
                SetControlStates();
            }
        }

        [Browsable( false ), DesignerSerializationVisibility( DesignerSerializationVisibility.Hidden )]
        public Collection Collection
        {
            get
            {
                ControlsToData();
                return collection;
            }
            set
            {
                collection = value;
                DataToControls();
            }
        }

        private void ControlsToData()
        {
            if (collection == null)
                collection = new Collection();
            collection.ConfidenceSpecified = chkConfidence.Checked;
            collection.ResolutionSpecified = chkResolution.Checked;
            if (collection.ConfidenceSpecified)
                collection.Confidence = edtConfidence.GetValue<double>();
            if (collection.ResolutionSpecified)
                collection.Resolution = edtResolution.GetValue<double>();
            collection.defaultStandardUnit = standardUnitControl.StandardUnit;
            collection.defaultNonStandardUnit = edtNonStandardUnit.GetValue<string>();
            collection.defaultUnitQualifier = cmbQualifier.SelectedItem as String;
            collection.Range = rangeLimitControl.Limit;
            collection.ErrorLimits = errorLimitControl.Limit;

            collection.Item = null;
            if (collectionListControl.Items.Count > 0)
            {
                collection.Item = collectionListControl.CollectionItems;
            }
        }

        private void DataToControls()
        {
            if (collection != null)
            {
                chkConfidence.Checked = collection.ConfidenceSpecified;
                chkResolution.Checked = collection.ResolutionSpecified;
                if (collection.ConfidenceSpecified)
                    edtConfidence.Value = collection.Confidence;
                if (collection.ResolutionSpecified)
                    edtResolution.Value = collection.Resolution;
                standardUnitControl.StandardUnit = collection.defaultStandardUnit;
                edtNonStandardUnit.Value = collection.defaultNonStandardUnit;
                cmbQualifier.SelectedItem = collection.defaultUnitQualifier;
                rangeLimitControl.Limit = collection.Range;
                errorLimitControl.Limit = collection.ErrorLimits;
                collectionListControl.CollectionItems = collection.Item;
            }
        }

        private void SetControlStates()
        {
            edtNonStandardUnit.Enabled = !_locked;
            standardUnitControl.Enabled = !_locked;
            cmbQualifier.Enabled = !_locked;
        }

        private void chkResolution_CheckedChanged( object sender, EventArgs e )
        {
            edtResolution.Enabled = chkResolution.Checked;
        }

        private void chkConfidence_CheckedChanged( object sender, EventArgs e )
        {
            edtConfidence.Enabled = chkConfidence.Checked;
        }
    }
}