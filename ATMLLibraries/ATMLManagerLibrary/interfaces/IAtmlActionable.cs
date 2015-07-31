/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
* 
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

using ATMLManagerLibrary.delegates;
using ATMLModelLibrary.interfaces;

namespace ATMLManagerLibrary.interfaces
{
    public interface IAtmlActionable
    {
        event AtmlActionDeligate<IAtmlObject> AtmlObjectAction;
    }
}