/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
*
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
using ATMLCommonLibrary.controls.collection;
using ATMLCommonLibrary.forms;
using ATMLManagerLibrary.managers;
using ATMLModelLibrary.model.common;

namespace ATMLCommonLibrary.controls.common
{
    [ToolboxItem( true ), ToolboxBitmap( typeof (CollectionControl), "Resources.CollectionControl.bmp" )]
    public partial class IndexArrayControl : UserControl
    {
        private int _defaultDataType = 1;
        private IndexedArrayType _indexedArray;
        private bool _locked;

        public IndexArrayControl()
        {
            InitializeComponent();
            InitListView();
            string[] sa = GetType().Assembly.GetManifestResourceNames();

            if (!this.IsInDesignMode())
            {
                cmbIndexType.DataSource = Enum.GetNames( typeof (Datum.DatumTypes) );
                indexItemControl.OnAdd += indexItemControl_OnAdd;
                indexItemControl.OnDelete += indexItemControl_OnDelete;
                indexItemControl.OnEdit += indexItemControl_OnEdit;
                indexItemControl.SelectedIndexChanged += IndexItemControlOnSelectedIndexChanged;
            }
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
        public IndexedArrayType IndexedArray
        {
            get
            {
                ControlsToData();
                return _indexedArray;
            }
            set
            {
                _indexedArray = value;
                DataToControls();
            }
        }

        public int DefaultDataType
        {
            get { return _defaultDataType; }
            set
            {
                _defaultDataType = value;
                cmbIndexType.SelectedIndex = value;
            }
        }

        private void SetControlStates()
        {
            standardUnitControl.Enabled = !_locked;
            edtNonStandardUnit.Enabled = !_locked;
            cmbIndexType.Enabled = !_locked;
            cmbQualifier.Enabled = !_locked;
        }

        private void InitListView()
        {
            indexItemControl.AddColumnData( "Value", "ToString()", 1d );
            indexItemControl.InitColumns();
            indexItemControl.AllowRowResequencing = true;
        }

        private void DataToControls()
        {
            SetItemType();
            if (_indexedArray != null)
            {
                chkConfidence.Checked = _indexedArray.ConfidenceSpecified;
                chkResolution.Checked = _indexedArray.ResolutionSpecified;
                if (_indexedArray.ConfidenceSpecified)
                    edtConfidence.Value = _indexedArray.Confidence;
                if (_indexedArray.ResolutionSpecified)
                    edtResolution.Value = _indexedArray.Resolution;
                standardUnitControl.StandardUnit = _indexedArray.standardUnit;
                edtNonStandardUnit.Value = _indexedArray.nonStandardUnit;
                cmbQualifier.SelectedItem = _indexedArray.unitQualifier;
                rangeLimitControl.Limit = _indexedArray.Range;
                errorLimitControl.Limit = _indexedArray.ErrorLimits;
                edtDimensions.Value = _indexedArray.dimensions;
                try
                {
                    if (_indexedArray is binaryArray)
                        LoadItemArray<binaryArray, binaryArrayElement>( (binaryArray) _indexedArray );
                    else if (_indexedArray is booleanArray)
                        LoadItemArray<booleanArray, booleanArrayElement>( (booleanArray) _indexedArray );
                    else if (_indexedArray is complexArray)
                        LoadItemArray<complexArray, complexArrayElement>( (complexArray) _indexedArray );
                    else if (_indexedArray is dateTimeArray)
                        LoadItemArray<dateTimeArray, dateTimeArrayElement>( (dateTimeArray) _indexedArray );
                    else if (_indexedArray is doubleArray)
                        LoadItemArray<doubleArray, doubleArrayElement>( (doubleArray) _indexedArray );
                    else if (_indexedArray is hexadecimalArray)
                        LoadItemArray<hexadecimalArray, hexadecimalArrayElement>( (hexadecimalArray) _indexedArray );
                    else if (_indexedArray is integerArray)
                        LoadItemArray<integerArray, integerArrayElement>( (integerArray) _indexedArray );
                    else if (_indexedArray is longArray)
                        LoadItemArray<longArray, longArrayElement>( (longArray) _indexedArray );
                    else if (_indexedArray is octalArray)
                        LoadItemArray<octalArray, octalArrayElement>( (octalArray) _indexedArray );
                    else if (_indexedArray is stringArray)
                        LoadItemArray<stringArray, stringArrayElement>( (stringArray) _indexedArray );
                    else if (_indexedArray is unsignedIntegerArray)
                        LoadItemArray<unsignedIntegerArray, unsignedIntegerArrayElement>(
                            (unsignedIntegerArray) _indexedArray );
                    else if (_indexedArray is unsignedLongArray)
                        LoadItemArray<unsignedLongArray, unsignedLongArrayElement>( (unsignedLongArray) _indexedArray );
                }
                catch (Exception e)
                {
                    LogManager.Error( e );
                }
            }
        }

        private void ControlsToData()
        {
            if (_indexedArray != null)
            {
                _indexedArray.ConfidenceSpecified = chkConfidence.Checked;
                _indexedArray.ResolutionSpecified = chkResolution.Checked;
                if (_indexedArray.ConfidenceSpecified)
                    _indexedArray.Confidence = edtConfidence.GetValue<double>();
                if (_indexedArray.ResolutionSpecified)
                    _indexedArray.Resolution = edtResolution.GetValue<double>();
                _indexedArray.standardUnit = standardUnitControl.StandardUnit;
                _indexedArray.nonStandardUnit = edtNonStandardUnit.GetValue<string>();
                _indexedArray.unitQualifier = cmbQualifier.SelectedItem as String;
                _indexedArray.dimensions = edtDimensions.GetValue<string>();
                _indexedArray.Range = rangeLimitControl.Limit;
                _indexedArray.ErrorLimits = errorLimitControl.Limit;
                List<Value> list = indexItemControl.GetData<Value>();
                DispatchArray( list );
            }
        }


        private void LoadItemArray<T, TA>( T array )
        {
            if (array != null)
            {
                PropertyInfo piDefault = array.GetType().GetProperty( "DefaultElementValue" );
                PropertyInfo piElement = array.GetType().GetProperty( "Element" );
                if (piDefault != null)
                    edtDefaultValue.Value = piDefault.GetValue( array, null );
                if (piElement != null)
                {
                    var values = (IEnumerable<TA>) piElement.GetValue( array, null );
                    if (values != null)
                    {
                        foreach (TA item in values)
                        {
                            indexItemControl.AddListViewObject( ElementToValue( item ) );
                        }
                    }
                }
            }
        }

        private Value ElementToValue<T>( T element )
        {
            var v = new Value();
            v.Item = element;
            return v;
        }

        private void DispatchArray( IEnumerable<Value> list )
        {
            if (_indexedArray is doubleArray)
                ( (doubleArray) _indexedArray ).Element = ProcessArray( list, ( (doubleArray) _indexedArray ).Element );
            else if (_indexedArray is integerArray)
                ( (integerArray) _indexedArray ).Element = ProcessArray( list, ( (integerArray) _indexedArray ).Element );
            else if (_indexedArray is booleanArray)
                ( (booleanArray) _indexedArray ).Element = ProcessArray( list, ( (booleanArray) _indexedArray ).Element );
            else if (_indexedArray is binaryArray)
                ( (binaryArray) _indexedArray ).Element = ProcessArray( list, ( (binaryArray) _indexedArray ).Element );
            else if (_indexedArray is complexArray)
                ( (complexArray) _indexedArray ).Element = ProcessArray( list, ( (complexArray) _indexedArray ).Element );
            else if (_indexedArray is dateTimeArray)
                ( (dateTimeArray) _indexedArray ).Element = ProcessArray( list,
                                                                          ( (dateTimeArray) _indexedArray ).Element );
            else if (_indexedArray is hexadecimalArray)
                ( (hexadecimalArray) _indexedArray ).Element = ProcessArray( list,
                                                                             ( (hexadecimalArray) _indexedArray )
                                                                                 .Element );
            else if (_indexedArray is longArray)
                ( (longArray) _indexedArray ).Element = ProcessArray( list, ( (longArray) _indexedArray ).Element );
            else if (_indexedArray is octalArray)
                ( (octalArray) _indexedArray ).Element = ProcessArray( list, ( (octalArray) _indexedArray ).Element );
            else if (_indexedArray is stringArray)
                ( (stringArray) _indexedArray ).Element = ProcessArray( list, ( (stringArray) _indexedArray ).Element );
            else if (_indexedArray is unsignedIntegerArray)
                ( (unsignedIntegerArray) _indexedArray ).Element = ProcessArray( list,
                                                                                 ( (unsignedIntegerArray) _indexedArray )
                                                                                     .Element );
            else if (_indexedArray is unsignedLongArray)
                ( (unsignedLongArray) _indexedArray ).Element = ProcessArray( list,
                                                                              ( (unsignedLongArray) _indexedArray )
                                                                                  .Element );
        }

        private List<T> ProcessArray<T>( IEnumerable<Value> list, List<T> array )
        {
            List<T> elements = array;
            if (elements == null)
                elements = new List<T>();
            elements.Clear();
            int pos = 0;
            foreach (Value value in list)
            {
                object obj = value.Item;
                var datum = obj as DatumType;
                var collection = obj as Collection;
                var indexedArray = obj as IndexedArrayType;
                var dae = Activator.CreateInstance<T>();
                if (datum != null)
                {
                    if (dae is DatumType)
                    {
                        datum.CopyTo( dae as DatumType );
                    }
                    PropertyInfo piValue = dae.GetType().GetProperty( "value" );
                    if (piValue != null)
                        piValue.SetValue( dae, Datum.GetDatumValue( datum ), null );
                }

                PropertyInfo piPos = dae.GetType().GetProperty( "position" );
                if (piPos != null)
                    piPos.SetValue( dae, "[" + pos++ + "]", null );
                elements.Add( dae );
            }
            return elements;
        }

        private void indexItemControl_OnEdit()
        {
            if (indexItemControl.HasSelected)
            {
                var value = indexItemControl.SelectedObject as Value;
                ListViewItem lvi = indexItemControl.SelectedListViewItem;
                if (value != null)
                {
                    var form = new ValueForm();
                    form.Value = value;
                    form.LockTypes = true;
                    if (DialogResult.OK == form.ShowDialog())
                    {
                        lvi.Tag = value;
                        lvi.SubItems[0].Text = value.ToString();
                    }
                }
            }
        }

        private void indexItemControl_OnDelete()
        {
            if (indexItemControl.HasSelected)
            {
                if (DialogResult.Yes ==
                    MessageBox.Show( @"Are you sure you want to delete the selected index array items?",
                                     @"V E R I F I C A T I O N",
                                     MessageBoxButtons.YesNo,
                                     MessageBoxIcon.Question ))
                {
                    foreach (ListViewItem lvi in indexItemControl.SelectedItems)
                    {
                        lvi.Remove();
                    }
                }
            }
        }

        private void indexItemControl_OnAdd()
        {
            var form = new ValueForm();

            var value = new Value();

            //--- Need to determine if it is a collection/indexed array/Datum
            DatumType datum = Datum.GetDatumFromType( cmbIndexType );
            datum.standardUnit = standardUnitControl.StandardUnit;
            datum.nonStandardUnit = edtNonStandardUnit.Text;
            datum.Confidence = edtConfidence.GetValue<double>();
            datum.ConfidenceSpecified = chkConfidence.Checked;
            datum.Resolution = edtResolution.GetValue<double>();
            datum.ResolutionSpecified = chkResolution.Checked;
            value.Item = datum;
            form.LockTypes = true;
            form.Value = value;
            form.DefaultDataType = cmbIndexType.SelectedIndex;
            if (DialogResult.OK == form.ShowDialog())
            {
                value = form.Value;
                if (value != null)
                {
                    var lvi = new ListViewItem( value.ToString() );
                    lvi.Tag = value;
                    indexItemControl.Items.Add( lvi );
                }
            }
        }

        private void SetItemType()
        {
            if (_indexedArray != null)
            {
                if (_indexedArray is binaryArray)
                    cmbIndexType.SelectedIndex = (int) Datum.DatumTypes.BINARY;
                else if (_indexedArray is booleanArray)
                    cmbIndexType.SelectedIndex = (int) Datum.DatumTypes.BOOL;
                else if (_indexedArray is complexArray)
                    cmbIndexType.SelectedIndex = (int) Datum.DatumTypes.COMPLEX;
                else if (_indexedArray is dateTimeArray)
                    cmbIndexType.SelectedIndex = (int) Datum.DatumTypes.DATETIME;
                else if (_indexedArray is doubleArray)
                    cmbIndexType.SelectedIndex = (int) Datum.DatumTypes.DOUBLE;
                else if (_indexedArray is hexadecimalArray)
                    cmbIndexType.SelectedIndex = (int) Datum.DatumTypes.HEX;
                else if (_indexedArray is integerArray)
                    cmbIndexType.SelectedIndex = (int) Datum.DatumTypes.INT;
                else if (_indexedArray is longArray)
                    cmbIndexType.SelectedIndex = (int) Datum.DatumTypes.LONG;
                else if (_indexedArray is octalArray)
                    cmbIndexType.SelectedIndex = (int) Datum.DatumTypes.OCT;
                else if (_indexedArray is stringArray)
                    cmbIndexType.SelectedIndex = (int) Datum.DatumTypes.STRING;
                else if (_indexedArray is unsignedIntegerArray)
                    cmbIndexType.SelectedIndex = (int) Datum.DatumTypes.UINT;
                else if (_indexedArray is unsignedLongArray)
                    cmbIndexType.SelectedIndex = (int) Datum.DatumTypes.ULONG;
            }
        }

        private void cmbIndexType_SelectedIndexChanged( object sender, EventArgs e )
        {
            _defaultDataType = cmbIndexType.SelectedIndex;
            switch (cmbIndexType.SelectedIndex)
            {
                case (int) Datum.DatumTypes.BINARY:
                    if (!( _indexedArray is binaryArray ))
                        _indexedArray = new binaryArray();
                    break;
                case (int) Datum.DatumTypes.BOOL:
                    if (!( _indexedArray is booleanArray ))
                        _indexedArray = new booleanArray();
                    break;
                case (int) Datum.DatumTypes.COMPLEX:
                    if (!( _indexedArray is complexArray ))
                        _indexedArray = new complexArray();
                    break;
                case (int) Datum.DatumTypes.DATETIME:
                    if (!( _indexedArray is dateTimeArray ))
                        _indexedArray = new dateTimeArray();
                    break;
                case (int) Datum.DatumTypes.DOUBLE:
                    if (!( _indexedArray is doubleArray ))
                        _indexedArray = new doubleArray();
                    break;
                case (int) Datum.DatumTypes.HEX:
                    if (!( _indexedArray is hexadecimalArray ))
                        _indexedArray = new hexadecimalArray();
                    break;
                case (int) Datum.DatumTypes.INT:
                    if (!( _indexedArray is integerArray ))
                        _indexedArray = new integerArray();
                    break;
                case (int) Datum.DatumTypes.LONG:
                    if (!( _indexedArray is longArray ))
                        _indexedArray = new longArray();
                    break;
                case (int) Datum.DatumTypes.OCT:
                    if (!( _indexedArray is octalArray ))
                        _indexedArray = new octalArray();
                    break;
                case (int) Datum.DatumTypes.STRING:
                    if (!( _indexedArray is stringArray ))
                        _indexedArray = new stringArray();
                    break;
                case (int) Datum.DatumTypes.UINT:
                    if (!( _indexedArray is unsignedIntegerArray ))
                        _indexedArray = new unsignedIntegerArray();
                    break;
                case (int) Datum.DatumTypes.ULONG:
                    if (!( _indexedArray is unsignedLongArray ))
                        _indexedArray = new unsignedLongArray();
                    break;
            }
        }


        private void edtNonStandardUnit_TextChanged( object sender, EventArgs e )
        {
            String text = edtNonStandardUnit.Text;
            if (!String.IsNullOrEmpty( text ))
            {
                standardUnitControl.Clear();
            }
        }

        private void chkResolution_CheckedChanged( object sender, EventArgs e )
        {
            edtResolution.Enabled = chkResolution.Checked;
        }

        private void chkConfidence_CheckedChanged( object sender, EventArgs e )
        {
            edtConfidence.Enabled = chkConfidence.Checked;
        }

        private void label5_Click( object sender, EventArgs e )
        {
        }

        private void IndexArrayControl_Validating( object sender, CancelEventArgs e )
        {
            if (Visible)
            {
                errorProvider1.SetError( edtDimensions, "" );
                if (string.IsNullOrEmpty( edtDimensions.Text ))
                {
                    errorProvider1.SetError( edtDimensions,
                                             "You must enter an array dimension in the format of [a,b,c,…,n] " );
                    e.Cancel = true;
                }
                else
                {
                    string dim = edtDimensions.Text.Replace( "[", "" ).Replace( "]", "" );
                    string[] parts = dim.Split( ',' );
                    var iDims = new int[parts.Length];
                    var iVals = new List<int>();
                    int totalRowsRequired = 1;
                    int i = 0;
                    foreach (string part in parts)
                    {
                        if (!int.TryParse( part, out iDims[i] ))
                        {
                            errorProvider1.SetError( edtDimensions, "Dimension values must be numeric." );
                            e.Cancel = true;
                        }
                        else
                        {
                            iVals.Add( iDims[i] );
                            totalRowsRequired *= iDims[i];
                        }
                        i++;
                    }
                    if (!e.Cancel && indexItemControl.Items.Count < totalRowsRequired)
                    {
                        errorProvider1.SetError( edtDimensions,
                                                 string.Format( "An array dimension of {0} requires {1} row entries. ",
                                                                edtDimensions.Text,
                                                                totalRowsRequired )
                            );
                        e.Cancel = true;
                    }
                }
            }
        }


        private void IndexItemControlOnSelectedIndexChanged( object sender, EventArgs eventArgs )
        {
        }
    }
}