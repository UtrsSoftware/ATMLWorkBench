/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
* 
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

using System;
using ATMLDataAccessLibrary.db.daos;

namespace ATMLDataAccessLibrary.db.beans
{
    public partial class AssetIdentificationBean
    {
        public AssetIdentificationBean DetermineDataState(String type, String number, String uuid)
        {
            assetNumber = number;
            assetType = type;
            this.uuid = Guid.Parse(uuid);
            var dao = new DocumentDAO();
            if (dao.HasAsset(type, number, uuid))
                DataState = eDataState.DS_EDIT;
            else
                DataState = eDataState.DS_ADD;
            return this;
        }

        public AssetIdentificationBean DetermineDataState()
        {
            var dao = new DocumentDAO();
            if (dao.HasAsset(assetType, assetNumber, uuid.ToString() ) )
                DataState = eDataState.DS_EDIT;
            else
                DataState = eDataState.DS_ADD;
            return this;
        }
    }
}