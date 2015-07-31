/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
* 
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

using System;
using System.IO;
using ATMLManagerLibrary.events;
using ATMLModelLibrary.model;
using ATMLModelLibrary.model.common;
using ATMLModelLibrary.model.equipment;
using ATMLModelLibrary.model.uut;

namespace ATMLManagerLibrary.delegates
{
    [Serializable]
    public enum AtmlActionType
    {
        Edit,
        Add,
        Delete,
        Find
    };

    [Serializable]
    public delegate void ItemSelectionDeligate<T>(T obj, EventArgs args);

    [Serializable]
    public delegate T AtmlActionDeligate<T>(T obj, AtmlActionType actionType, EventArgs args);

    [Serializable]
    public delegate void InputDocumentOpenDelegate(FileInfo fileInfo, byte[] content);

    [Serializable]
    public delegate void AtmlDocumentOpenDelegate(Document document);

    [Serializable]
    public delegate void AtmlFileOpenDelegate(FileInfo fileInfo, byte[] content);

    [Serializable]
    public delegate void FileSavedDelegate(FileInfo fileInfo, byte[] content);

    [Serializable]
    public delegate void ProjectUutChangedDeligate(UUTDescription uutDescription);

    [Serializable]
    public delegate void ProjectTestDescriptionChangedDeligate(TestDescription testDescription);

    [Serializable]
    public delegate void ProjectTestStationChangedDeligate(TestStationDescription11 testStationDescription);

    [Serializable]
    public delegate void ProjectTestAdapterChangedDeligate(TestAdapterDescription1 testAdapterDescription);

    [Serializable]
    public delegate void ProjectInstrumentChangedDeligate(InstrumentDescription instrumentDescription);

    [Serializable]
    public delegate void ProjectTestConfigurationChangedDeligate(TestConfiguration15 testConfiguration);

    [Serializable]
    public delegate void BeginDocumentOpenDelegate();

    [Serializable]
    public delegate void ParseableInputDocumentDelegate();

    [Serializable]
    public delegate void NavigableInputDocumentDelegate();

    [Serializable]
    public delegate void AtmlNameChangedEventHandler(object sender, AtmlNameChangedEventArgs e);

}