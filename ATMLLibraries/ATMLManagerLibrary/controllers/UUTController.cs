/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
* 
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using ATMLDataAccessLibrary.db.beans;
using ATMLDataAccessLibrary.db.daos;
using ATMLDataAccessLibrary.managers;
using ATMLDataAccessLibrary.model;
using ATMLManagerLibrary.delegates;
using ATMLManagerLibrary.interfaces;
using ATMLModelLibrary.model.common;
using ATMLModelLibrary.model.uut;
using ATMLUtilitiesLibrary;

namespace ATMLManagerLibrary.controllers
{
    public class UUTController : PersistanceController, IAtmlController<UUTDescription>
    {
        private static volatile UUTController _instance;


        [MethodImpl( MethodImplOptions.Synchronized )]
        private UUTController()
        {
        }

        public static UUTController Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new UUTController();
                }
                return _instance;
            }
        }

        [MethodImpl( MethodImplOptions.Synchronized )]
        public string Create( string partNumber, string nomen, string model )
        {
            string refUUID = null;
            DocumentDAO dao = DataManager.getDocumentDAO();
            try
            {
                dao.StartTransaction();
                AssetIdentificationBean asset;
                var description = new UUTDescription();
                ItemDescription item = new HardwareUUT(); 
                var identificationNumber = new ManufacturerIdentificationNumber();
                identificationNumber.number = partNumber;
                identificationNumber.manufacturerName = "[Unknown]";
                identificationNumber.type = IdentificationNumberType.Part;
                description.name = nomen;
                description.uuid = Guid.NewGuid().ToString();
                item.Identification = new ItemDescriptionIdentification();
                item.Identification.ModelName = model;
                item.Identification.IdentificationNumbers = new List<IdentificationNumber>();
                item.Identification.IdentificationNumbers.Add( identificationNumber );
                description.Item = item;
                refUUID = description.uuid;

                //------------------------------------------------------------------------------------//
                //--- Add document to document database                                            ---//
                //--- The UUT is a Model Number Asset so we will use a model name for the filename ---//
                //--- We will also use the ATML Standard number (1671.3) for part of the file name ---//
                //------------------------------------------------------------------------------------//
                string docName = string.Format( "{0}{1}",
                                                FileUtils.MakeGoodFileName( model ),
                                                ATMLContext.ATML_UUT_FILENAME_SUFFIX );

                var document = new Document();
                document.Description = description.name;
                document.uuid = refUUID;
                document.name = docName;
                document.Item = description.Serialize();
                document.DocumentContent = Encoding.UTF8.GetBytes( document.Item );
                document.ContentType = ATMLContext.CONTEXT_TYPE_XML;
                document.DocumentType = dbDocument.DocumentType.UUT_DESCRIPTION;
                Save( document );

                //----------------------------------------//
                //--- Add reference id to asset lookup ---//
                //----------------------------------------//
                asset = new AssetIdentificationBean();
                asset.uuid = Guid.Parse( refUUID );
                asset.assetType = "Model";
                asset.assetNumber = model;
                asset.DataState = BASEBean.eDataState.DS_ADD;
                asset.save();

                //Add uut document to atml directory - use part number as file name + 1671.3
                //TODO: Replace with an event
                //ProjectManager.SaveATMLDocument( docName, FileManager.AtmlFileType.AtmlTypeUut, document.DocumentContent,true );

                dao.CommitTransaction();
            }
            catch (Exception e)
            {
                dao.RollbackTransaction();
                throw e;
            }
            finally
            {
                dao.EndTransaction();
            }
            return refUUID;
        }

        public void Save( UUTDescription atmlObject )
        {
            if (base.Save( atmlObject ))
                OnUutChanged( atmlObject );
        }

        public UUTDescription Find( Guid? id )
        {
            return base.Find<UUTDescription>( id.ToString() );
        }

        public UUTDescription Find( string uuid )
        {
            return base.Find<UUTDescription>( uuid );
        }

        public void AddInstrumentReference( UUTDescription atmlObject, string partNumber, string documentUuid )
        {
            throw new NotImplementedException();
        }

        public bool HasInstrumentReference( UUTDescription atmlObject, string partNumber )
        {
            throw new NotImplementedException();
        }

        public event ProjectUutChangedDeligate UutChanged;

        protected virtual void OnUutChanged( UUTDescription uutdescription )
        {
            ProjectUutChangedDeligate handler = UutChanged;
            if (handler != null) handler( uutdescription );
        }
    }
}