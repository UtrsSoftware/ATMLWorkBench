/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
* 
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

using System.ComponentModel;
using System.Windows.Forms;
using ATMLCommonLibrary.forms;
using ATMLModelLibrary.model.equipment;

namespace ATMLCommonLibrary.controls.hardware
{
    public partial class VersionIdentifierForm : ATMLForm
    {
        public VersionIdentifierForm()
        {
            InitializeComponent();
            ValidateSchema += new System.EventHandler(VersionIdentifierForm_ValidateSchema);
        }

        public override bool ValidateChildren(ValidationConstraints validationConstraints)
        {
            bool isValid = base.ValidateChildren(validationConstraints);
            ValidateToSchema(versionIdentifierControl.VersionIdentifier);
            return isValid;
        }

        void VersionIdentifierForm_ValidateSchema(object sender, System.EventArgs e)
        {
            
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public VersionIdentifier VersionIdentifier
        {
            set
            {
                StoreOriginalValue(value);
                versionIdentifierControl.VersionIdentifier = value; }
            get { return versionIdentifierControl.VersionIdentifier; }
        }
    }
}