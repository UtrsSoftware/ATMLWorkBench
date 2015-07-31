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

namespace ATMLCommonLibrary.controls
{
    public partial class ItemDescriptionControl : UserControl
    {
        protected ItemDescription itemDescription;

        public ItemDescriptionControl()
        {
            InitializeComponent();
        }

        public ItemDescriptionControl( ItemDescription itemDescription )
        {
            InitializeComponent();
            this.itemDescription = itemDescription;
            DataToControls();
        }

        [Browsable( false ), DesignerSerializationVisibility( DesignerSerializationVisibility.Hidden )]
        public ItemDescription ItemDescription
        {
            get
            {
                ControlsToData();
                return itemDescription;
            }
            set
            {
                itemDescription = value;
                DataToControls();
            }
        }

        private void ItemDescriptionControl_Load( object sender, EventArgs e )
        {
        }

        protected virtual void DataToControls()
        {
            if (itemDescription != null)
            {
                edtName.Value = itemDescription.name;
                edtVersion.Value = itemDescription.version;
                edtDescription.Value = itemDescription.Description;
                identificationControl.Identification = itemDescription.Identification;
                identificationControl.DataToControls();
            }
        }

        protected virtual void ControlsToData()
        {
            if (itemDescription == null)
                itemDescription = new ItemDescription();
            if (identificationControl != null)
                identificationControl.ControlsToData();
            itemDescription.name = edtName.GetValue<string>();
            itemDescription.version = edtVersion.GetValue<string>();
            itemDescription.Description = edtDescription.GetValue<string>();
            if (identificationControl != null)
                itemDescription.Identification = identificationControl.Identification;
        }

        private void ItemDescriptionControl_Validating( object sender, CancelEventArgs e )
        {
            if (String.IsNullOrEmpty( edtName.Text ))
            {
                e.Cancel = !ValidateChildren();
            }
        }

        public override bool ValidateChildren()
        {
            bool v = base.ValidateChildren();
            return v;
        }

        public override bool ValidateChildren( ValidationConstraints validationConstraints )
        {
            bool v = base.ValidateChildren( validationConstraints );
            return v;
        }
    }
}