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
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ATMLModelLibrary.model.common;

namespace ATMLCommonLibrary.controls.validators
{
    internal class IdentifierValidator : RequiredFieldValidator
    {

        private Collection _identificationNumberList;
        private Collection _manufacturerList;

        [Category("Behaviour")]
        [Description("Gets or sets the Identification Number List to validate.")]
        public Collection IdentificationNumberList
        {
            get { return _identificationNumberList; }
            set
            {
                _identificationNumberList = value;
            }
        }

        [Category("Behaviour")]
        [Description("Gets or sets the Manufacturer List to validate.")]
        public Collection ManufacturerList
        {
            get { return _manufacturerList; }
            set
            {
                _manufacturerList = value;
            }
        }


        protected override bool Validate()
        {
            bool results =  base.Validate();

            //if( results && )

            return results;

        }
    }
}
