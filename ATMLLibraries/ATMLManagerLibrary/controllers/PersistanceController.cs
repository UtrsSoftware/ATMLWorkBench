/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
* 
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;
using ATMLDataAccessLibrary.db.beans;
using ATMLDataAccessLibrary.db.daos;
using ATMLManagerLibrary.delegates;
using ATMLManagerLibrary.events;
using ATMLManagerLibrary.managers;
using ATMLModelLibrary.interfaces;
using ATMLModelLibrary.model;
using ATMLModelLibrary.model.common;
using ATMLModelLibrary.model.equipment;
using ATMLModelLibrary.model.signal.basic;
using ATMLModelLibrary.model.uut;
using ATMLSchemaLibrary.managers;
using ATMLSignalModelLibrary.managers;
using ATMLUtilitiesLibrary;
using Path = System.IO.Path;

namespace ATMLManagerLibrary.controllers
{
    public class PersistanceController
    {
        public event AtmlNameChangedEventHandler AtmlObjectNameChanged;

        protected virtual void OnAtmlObjectNameChanged( string oldName, string newName, string uuid,
                                                        AtmlFileType fileType )
        {
            AtmlNameChangedEventHandler handler = AtmlObjectNameChanged;
            var args = new AtmlNameChangedEventArgs();
            args.OldName = oldName;
            args.NewName = newName;
            args.AtmlFileType = fileType;
            args.Uuid = uuid;
            if (handler != null) handler( this, args );
        }


        public static void Save( IAtmlObject atmlObject, Capability capability )
        {
            string id = atmlObject.GetAtmlId();
            var dao = new EquipmentDAO();
            if (capability.SignalDescription != null)
            {
                List<Signal> signals = SignalManager.ExtractSignalsFromExtension( capability.SignalDescription );
                foreach (Signal signal in signals)
                {
                    string signalName = signal.name;
                    string signalNameSpace = signal.GetSignalNameSpace();
                    string capabilityName = capability.name;
                    object[] items = signal.Items;

                    foreach (object item in items)
                    {
                        var element = item as XmlElement;
                        if (element != null)
                        {
                            XmlSchemaComplexType complexType;
                            string elementName = element.Name;
                            string localName = element.LocalName;
                            XmlSchema schema = SchemaManager.GetSchema( element.NamespaceURI );
                            SchemaManager.GetComplexType( element.NamespaceURI, localName, out complexType );
                            var xmlSchemaObjects =
                                new Dictionary<string, XmlSchemaObject>();
                            SchemaManager.ExtractAttributes( complexType, xmlSchemaObjects );


                            foreach (XmlAttribute attribute in element.Attributes)
                            {
                                string propertyName = attribute.Name;
                                string value = attribute.Value;
                                try
                                {
                                    XmlSchemaAttribute schemaAttribute;
                                    SchemaManager.FindAttribute( element.NamespaceURI, localName, propertyName,
                                                                 out schemaAttribute );
                                    bool isPhysicalType = false;
                                    string typeName = "";
                                    if (schemaAttribute != null)
                                    {
                                        XmlSchemaSimpleType simpleType = schemaAttribute.AttributeSchemaType;
                                        XmlQualifiedName qn = schemaAttribute.SchemaTypeName;
                                        isPhysicalType = SchemaManager.IsPhysicalType( simpleType );
                                        if (!isPhysicalType)
                                            isPhysicalType = SchemaManager.IsPhysicalType( qn );
                                    }

                                    Physical physical;

                                    try
                                    {
                                        physical = new Physical( value );
                                    }
                                    catch (Exception)
                                    {
                                        continue;
                                    }

                                    RangingInformation range = physical.GetMergedRange();
                                    //TODO: need SignalType, SignalNamespace
                                    if (range != null)
                                    {
                                        InstrumentCapabilitiesBean bean =
                                            dao.GetSignalCapabilityAttribute( Guid.Parse( id ),
                                                                              capabilityName,
                                                                              signalName,
                                                                              propertyName );
                                        if (bean == null)
                                        {
                                            bean = new InstrumentCapabilitiesBean();
                                            bean.DataState = BASEBean.eDataState.DS_ADD;
                                        }
                                        else
                                        {
                                            bean.DataState = atmlObject.IsDeleted()
                                                                 ? BASEBean.eDataState.DS_DELETE
                                                                 : BASEBean.eDataState.DS_EDIT;
                                        }
                                        //bean.signalType =;
                                        bean.capabilityName = capabilityName;
                                        bean.signalNamespace = signalNameSpace;
                                        bean.IncludeKeyOnInsert = true;
                                        bean.instrumentUuid = id;
                                        bean.attribute = propertyName;
                                        bean.signalName = signalName;
                                        if (range.FromQuantity != null)
                                        {
                                            bean.lowValue = range.FromQuantity.NominalValue;
                                            bean.lowUnit = range.FromQuantity.Unit.BaseUnitString;
                                        }
                                        if (range.ToQuantity != null)
                                        {
                                            bean.highValue = range.ToQuantity.NominalValue;
                                            bean.highUnit = range.ToQuantity.Unit.BaseUnitString;
                                        }
                                        bean.save();
                                    }
                                }
                                catch (Exception)
                                {
                                    throw;
                                }
                            }
                        }
                        else
                        {
                            string signalFunctionName = item.GetType().Name;
                            PropertyInfo piName = item.GetType().GetProperty( "name" );
                            if (piName != null)
                            {
                                object value = piName.GetValue( item, null );
                                //if (value != null)
                                //   propertyName = value as string;
                            }
                            foreach (
                                PropertyInfo pi in
                                    item.GetType()
                                        .GetProperties( BindingFlags.Public | BindingFlags.Instance |
                                                        BindingFlags.DeclaredOnly ))
                            {
                                string propertyName = pi.Name;
                                object value = pi.GetValue( item, null );
                                if (value != null)
                                {
                                    try
                                    {
                                        //TODO: need SignalType, SignalNamespace
                                        if (
                                            !SchemaManager.IsPhysicalType( "urn:IEEE-1641:2010:STDBSC",
                                                                           signalFunctionName, propertyName ))
                                            continue;
                                        var physicalValue = new Physical( value.ToString() );
                                        Console.WriteLine( physicalValue.ToString() );
                                        RangingInformation range = physicalValue.GetMergedRange();
                                        InstrumentCapabilitiesBean bean =
                                            dao.GetSignalCapabilityAttribute( Guid.Parse( id ),
                                                                              capabilityName,
                                                                              signalName,
                                                                              pi.Name );
                                        if (bean == null)
                                        {
                                            bean = new InstrumentCapabilitiesBean();
                                            bean.DataState = BASEBean.eDataState.DS_ADD;
                                        }
                                        else
                                        {
                                            bean.DataState = atmlObject.IsDeleted()
                                                                 ? BASEBean.eDataState.DS_DELETE
                                                                 : BASEBean.eDataState.DS_EDIT;
                                        }
                                        //bean.signalType =;
                                        bean.capabilityName = capabilityName;
                                        bean.signalNamespace = signalNameSpace;
                                        bean.IncludeKeyOnInsert = true;
                                        bean.instrumentUuid = id;
                                        bean.attribute = pi.Name;
                                        bean.signalName = signalName;
                                        if (range != null)
                                        {
                                            if (range.FromQuantity != null)
                                            {
                                                bean.lowValue = range.FromQuantity.NominalValue;
                                                bean.lowUnit = range.FromQuantity.Unit.BaseUnitString;
                                            }
                                            if (range.ToQuantity != null)
                                            {
                                                bean.highValue = range.ToQuantity.NominalValue;
                                                bean.highUnit = range.ToQuantity.Unit.BaseUnitString;
                                            }
                                        }
                                        bean.save();
                                    }
                                    catch (Exception err)
                                    {
                                        LogManager.Error( err,
                                                          "Error Saving Capability [{0}] - Item:{1}, Value:{2}",
                                                          capability.name,
                                                          item.GetType().Name,
                                                          value
                                            );
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        public static void Save( Document document )
        {
            try
            {
                DocumentManager.SaveDocument( document );
            }
            catch (Exception e)
            {
                LogManager.Error( e.Message );
            }
        }


        public static void Save( DocumentReference documentReference )
        {
            try
            {
                DocumentManager.SaveDocument( documentReference );
            }
            catch (Exception e)
            {
                LogManager.Error( e.Message );
            }
        }

        public static void Delete( UUTDescription uut )
        {
            var dao = new DocumentDAO();
            if (!string.IsNullOrWhiteSpace( uut.uuid ))
            {
                if (!dao.hasDocument( uut.uuid ))
                {
                    LogManager.Error( "Failed to locate UUT \"{0}\" ({1}) in the document dabase.", uut.name, uut.uuid );
                }
                else
                {
                    var document = new Document( dao.openDatabaseDocument( uut.uuid ) );
                    document.DataState = BASEBean.eDataState.DS_DELETE;
                    Save( document );
                }
            }
        }


        public bool Save( IAtmlObject atmlObject )
        {
            bool results = false;
            bool localTransaction = false;
            bool isDeleted = atmlObject.IsDeleted();
            var dao = new DocumentDAO();
            try
            {
                if (!dao.IsInTransaction)
                {
                    dao.StartTransaction();
                    localTransaction = true;
                }
                string uuid = atmlObject.GetAtmlId();
                if (!string.IsNullOrWhiteSpace( uuid ))
                {
                    byte[] content = Serialize( atmlObject );
                    var document = new Document();
                    if (dao.hasDocument( uuid ))
                    {
                        document = new Document( dao.openDatabaseDocument( uuid ) );
                        document.DataState = atmlObject.IsDeleted()
                                                 ? BASEBean.eDataState.DS_DELETE
                                                 : BASEBean.eDataState.DS_EDIT;
                    }
                    else
                    {
                        document.DataState = BASEBean.eDataState.DS_ADD;
                        document.ContentType = atmlObject.GetAtmlFileContext();
                        document.DocumentType = atmlObject.GetAtmlDocumentType();
                        document.uuid = uuid;
                    }
                    string originalFileName = document.name;
                    document.name = atmlObject.GetAtmlFileName();
                    document.Description = atmlObject.GetAtmlFileDescription();
                    document.DocumentContent = content;
                    Save( document );

                    //-----------------------------------------------------------------------------//
                    //--- Save Asset Numbers - these include all model numbers and part numbers ---//
                    //-----------------------------------------------------------------------------//
                    ItemDescriptionIdentification identification = DetermineIdentification( atmlObject, dao, uuid );
                    if (identification != null && !isDeleted)
                        //When Deleting - let the cascade delete handle the related records.
                    {
                        SaveAssets( atmlObject, identification, dao, uuid );
                    }

                    //------------------------------------//
                    //--- Save Capabilities Separately ---//
                    //------------------------------------//
                    PropertyInfo piCapabilities = atmlObject.GetType().GetProperty( "Capabilities" );
                    if (piCapabilities != null)
                    {
                        var capabilities = piCapabilities.GetValue( atmlObject, null ) as Capabilities;
                        SaveCapabilities( atmlObject, capabilities );
                    }

                    if (localTransaction)
                        dao.CommitTransaction();
                    results = true;
                    if (!string.IsNullOrEmpty( originalFileName )
                        && !originalFileName.Equals( atmlObject.GetAtmlFileName() ))
                        OnAtmlObjectNameChanged( originalFileName, atmlObject.GetAtmlFileName(), uuid,
                                                 atmlObject.GetAtmlFileType() );

                    //-------------------------------------------------------------------------------------//
                    //--- We only want to save a file to the project directory if a project is open and ---//
                    //--- the file name contains the project name. This will only occur for the Test    ---//
                    //--- Configuration and the Test Description documents.                             ---//
                    //-------------------------------------------------------------------------------------//
                    if (ATMLContext.HasProjectOpen && document.name.Contains( ATMLContext.CurrentProjectName ))
                    {
                        FileManager.WriteFile( Path.Combine( ATMLContext.ProjectAtmlPath, document.name ),
                                               document.DocumentContent );
                    }
                }
            }
            catch (Exception e)
            {
                LogManager.Error( e );
                if (localTransaction)
                    dao.RollbackTransaction();
            }
            return results;
        }

        private ItemDescriptionIdentification DetermineIdentification( IAtmlObject atmlObject, DocumentDAO dao,
                                                                       string uuid )
        {
            ItemDescriptionIdentification identification = null;
            PropertyInfo piId = atmlObject.GetType().GetProperty( "Identification" );
            if (piId != null)
            {
                identification = piId.GetValue( atmlObject, null ) as ItemDescriptionIdentification;
            }
            else
            {
                piId = atmlObject.GetType().GetProperty( "Item" );
                if (piId != null)
                {
                    var item = piId.GetValue( atmlObject, null ) as ItemDescription;
                    if (item != null)
                    {
                        piId = item.GetType().GetProperty( "Identification" );
                        if (piId != null)
                        {
                            identification = piId.GetValue( item, null ) as ItemDescriptionIdentification;
                        }
                    }
                }
            }
            return identification;
        }

        private void SaveCapabilities( IAtmlObject atmlObject, Capabilities capabilities )
        {
            var dao = new EquipmentDAO();
            dao.ClearEquipmentCapabilities( Guid.Parse( atmlObject.GetAtmlId() ) );
            if (!atmlObject.IsDeleted() && capabilities != null && capabilities.Items != null)
            {
                foreach (object item in capabilities.Items)
                {
                    var capability = item as Capability;
                    if (capability != null)
                    {
                        Save( atmlObject, capability );
                    }
                }
            }
        }

        protected void SaveAssets( IAtmlObject atmlObject,
                                   ItemDescriptionIdentification identification,
                                   DocumentDAO dao,
                                   string uuid )
        {
            if (identification != null)
            {
                //----------------------------------------------------------------------------------//
                //--- Get existing assets for this entity and remove those assets already listed ---//
                //--- whatever is left over in the list can be deleted. These would be those     ---//
                //--- assets that may have been deleted or renamed.                              ---//
                //----------------------------------------------------------------------------------//
                Dictionary<object, AssetIdentificationBean> existingAssets = dao.GetAssetsByUuid( uuid );
                var asset = new AssetIdentificationBean();
                string modelNo = atmlObject.GetAtmlName();
                if (!string.IsNullOrEmpty( modelNo ))
                    modelNo = modelNo.Trim();
                if (modelNo != null && existingAssets.ContainsKey( modelNo ))
                {
                    asset.ID = existingAssets[atmlObject.GetAtmlName()].ID;
                    existingAssets.Remove( modelNo );
                }
                asset.assetNumber = modelNo;
                asset.assetType = "Model";
                asset.uuid = Guid.Parse( uuid );
                if (atmlObject.IsDeleted())
                    asset.DataState = BASEBean.eDataState.DS_DELETE;
                else
                    asset.DetermineDataState();
                asset.save();
                if (identification.IdentificationNumbers != null)
                {
                    foreach (IdentificationNumber idNumber in identification.IdentificationNumbers)
                    {
                        string type = Enum.GetName( typeof (IdentificationNumberType), idNumber.type );
                        string number = idNumber.number;
                        if (!string.IsNullOrEmpty( number ))
                            number = number.Trim();

                        //-------------------------------------------------------------------------------------------------------------//
                        //--- There is no need to save the asset if the model Number is duplicated as another identification number ---//
                        //-------------------------------------------------------------------------------------------------------------//
                        if (!number.Equals( modelNo ))
                        {
                            asset = new AssetIdentificationBean();
                            if (existingAssets.ContainsKey( number ))
                            {
                                asset.ID = existingAssets[number].ID;
                                existingAssets.Remove( number );
                            }
                            asset.assetNumber = number;
                            asset.assetType = type;
                            asset.uuid = Guid.Parse( uuid );
                            if (atmlObject.IsDeleted())
                                asset.DataState = BASEBean.eDataState.DS_DELETE;
                            else
                                asset.DetermineDataState();
                            try
                            {
                                asset.save();
                            }
                            catch (Exception exception)
                            {
                                string msg = exception.Message;
                                throw new Exception(
                                    string.Format( "Failed adding the identifier \"{0}\" as a new asset. Error: {1}",
                                                   idNumber,
                                                   msg.Contains( "duplicate" )
                                                       ? "The Identification Number is already assigned to another piece of equipment."
                                                       : msg ) );
                            }
                        }
                    }
                }

                //----------------------------------------//
                //--- Remove Assets no longer attached ---//
                //----------------------------------------//
                foreach (AssetIdentificationBean assetBean in existingAssets.Values)
                {
                    assetBean.DataState = BASEBean.eDataState.DS_DELETE;
                    assetBean.save();
                }
            }
        }

        public T Find<T>( string uuid )
        {
            T atmlObject = default( T );
            Document document = DocumentManager.GetDocument( uuid );
            if (document != null)
            {
                atmlObject = Deserialize<T>( document.DocumentContent );
            }
            return atmlObject;
        }

        protected T Deserialize<T>( byte[] input )
        {
            T atmlObject;
            var serializer = new XmlSerializer( typeof (T) );
            using (var ms = new MemoryStream( input ))
            {
                atmlObject = (T) serializer.Deserialize( ms );
            }
            return atmlObject;
        }

        protected byte[] Serialize( object obj )
        {
            byte[] data;
            using (var memoryStream = new MemoryStream())
            {
                var serializer = new XmlSerializer( obj.GetType() );
                serializer.Serialize( memoryStream, obj );
                memoryStream.Position = 0;
                data = memoryStream.ToArray();
            }
            return data;
        }
    }
}