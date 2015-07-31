/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
* 
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

using System;

namespace ATMLManagerLibrary.interfaces
{
    public interface IAtmlController<T>
    {
        string Create(string partNumber, string nomen, string model);
        //void Add(T atmlObject);
        void Save(T atmlObject);
        //void Delete(T atmlObject);
        T Find(Guid? id);
        T Find(string uuid);
        void AddInstrumentReference(T atmlObject, string partNumber, string documentUuid);
        bool HasInstrumentReference(T atmlObject, string partNumber);
    }
}
