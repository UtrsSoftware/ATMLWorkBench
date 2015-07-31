/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
* 
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

using ATMLDataAccessLibrary.model;

namespace ATMLModelLibrary.interfaces
{
    public enum AtmlFileType
    {
        AtmlTypeTestDescription = 1,
        AtmlTypeInstrument = 2,
        AtmlTypeUut = 3,
        AtmlTypeTestConfiguration = 4,
        AtmlTypeTestAdapter = 5,
        AtmlTypeTestStation = 6
    }

    public interface IAtmlObject
    {
        bool IsDeleted( bool? deleted = null );
        string GetAtmlId();
        string GetAtmlName();
        string GetAtmlFileName();
        string GetAtmlFileContext();
        string GetAtmlFileDescription();
        dbDocument.DocumentType GetAtmlDocumentType();
        AtmlFileType GetAtmlFileType();
    }
}