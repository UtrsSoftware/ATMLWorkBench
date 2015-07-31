/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
*
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

using System.ComponentModel;
using System.Drawing;
using ATMLModelLibrary.model.equipment;

namespace ATMLCommonLibrary.controls.path
{
    public partial class PathControl : ATMLControl
    {
        private Path _path;

        public PathControl()
        {
            InitializeComponent();
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Path Path
        {
            get
            {
                ControlsToData();
                return _path;
            }
            set
            {
                _path = value;
                DataToControls();
            }
        }

        public HardwareItemDescription HardwareItemDescription
        {
            get { return NodeListControl1.HardwareItemDescription; }
            set { NodeListControl1.HardwareItemDescription = value; }
        }

        private void DataToControls()
        {
            if (_path != null)
            {
                datumResistance.DoubleValue = _path.Resistance;
                edtName.Value = _path.name;
                NodeListControl1.PathNode = _path.PathNodes;
                VSWRValueListControl1.PathVSWR = _path.VSWRValues;
                SignalDelayListControl1.PathSignalDelay = _path.SignalDelays;
                SParameterList.PathList = _path.SParameters;
            }
        }

        private void ControlsToData()
        {
            if (_path == null)
                _path = new Path();
            _path.name = edtName.GetValue<string>();
            _path.Resistance = datumResistance.DoubleValue;
            _path.SignalDelays = SignalDelayListControl1.PathSignalDelay;
            _path.SParameters = SParameterList.PathList;
            _path.VSWRValues = VSWRValueListControl1.PathVSWR;
            _path.PathNodes = NodeListControl1.PathNode;
        }

        public override bool ValidateChildren()
        {
            bool valid = base.ValidateChildren();
            return valid;
        }

        protected override void OnValidating( CancelEventArgs e )
        {
            base.OnValidating( e );
            errorProvider1.SetError(this.NodeListControl1, "" );
            if (this.NodeListControl1.Items.Count < 2)
            {
                errorProvider1.SetError(lblError, "A minimum of 2 nodes are required." );
                tabControl1.TabPages[0].BackColor = Color.LightCoral;
                e.Cancel = true;
            }
        }

    }
}