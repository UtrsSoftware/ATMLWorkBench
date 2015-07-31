/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
*
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/
using ATMLModelLibrary.model.common;

namespace ATMLCommonLibrary.forms
{
    public partial class ValueForm : ATMLForm
    {
        public int DefaultDataType
        {
            set { valueControl.DefaultDataType = value;  }
            get { return valueControl.DefaultDataType;  }

        }

        public int DefaultComparitor
        {
            set { valueControl.DefaultComparitor = value; }
            get { return valueControl.DefaultComparitor; }

        }


        public ValueForm()
        {
            InitializeComponent();
        }

        public Value Value
        {
            get { return valueControl.Value; }
            set { valueControl.Value = value; }
        }

        public bool LockTypes
        {
            set { valueControl.LockTypes = value; }
            get { return valueControl.LockTypes; }
        }

    }
}