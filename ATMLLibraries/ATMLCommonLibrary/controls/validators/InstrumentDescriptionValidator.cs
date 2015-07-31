/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
* 
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ATMLCommonLibrary.controls.instrument;
using ATMLModelLibrary.model.equipment;

namespace ATMLCommonLibrary.controls.validators
{
    internal class InstrumentDescriptionValidator : BaseValidator
    {

        protected override bool Validate()
        {
            bool results = base.Validate();

            InstrumentControl instrumentControl = _controlToValidate as InstrumentControl;
            if (instrumentControl != null)
            {
            }
            return results;

        }


    }
}
