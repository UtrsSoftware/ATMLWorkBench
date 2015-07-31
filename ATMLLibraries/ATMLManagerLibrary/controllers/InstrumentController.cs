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
using ATMLManagerLibrary.managers;
using ATMLModelLibrary.model.common;
using ATMLModelLibrary.model.equipment;
using ATMLUtilitiesLibrary;

namespace ATMLManagerLibrary.controllers
{
    public class InstrumentController : PersistanceController, IAtmlController<InstrumentDescription>
    {
        private static volatile InstrumentController _instance;
        private static readonly object _lock = new object();
        public event ProjectInstrumentChangedDeligate InstrumentDescriptionChanged;

        protected virtual void OnInstrumentDescriptionChanged(InstrumentDescription testDescription)
        {
            ProjectInstrumentChangedDeligate handler = InstrumentDescriptionChanged;
            if (handler != null) handler(testDescription);
        }

        private InstrumentController()
        {
        }

        public static InstrumentController Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_lock)
                    {
                        if (_instance == null)
                        {
                            _instance = new InstrumentController();
                        }
                    }
                }
                return _instance;
            }
        }

        public static InstrumentDescription FindInstrument(string partNumber)
        {
            AssetIdentificationBean asset = DocumentManager.FindAsset("Part", partNumber);
            if( asset == null )
                throw new Exception( string.Format("Failed to locate Asset Id \"{0}\"", partNumber) );
            Document document = DocumentManager.GetDocument(asset.uuid);
            if( document == null )
                throw new Exception( string.Format("Failed to locate Document Id \"{0}\"", asset.uuid) );
            return InstrumentDescription.Deserialize(Encoding.UTF8.GetString(document.DocumentContent));
        }


        public static InstrumentDescription CreateInstrument(string partNumber, string stationType)
        {
            InstrumentDescription description = null;
            DocumentDAO dao = DataManager.getDocumentDAO();
            try
            {
                AssetIdentificationBean stationAsset = DocumentManager.FindAsset("Model", stationType);
                if (stationAsset == null)
                    throw new Exception(string.Format("Failed to locate the \"{0}\" Test Station", stationType));

                TestStationDescription11 testStation = TestStationController.Instance.Find(stationAsset.uuid);
                if (testStation == null)
                    throw new Exception(string.Format("Failed to locate the \"{0}\" Test Station", stationType));

                //---------------------------------------------------------------//
                //--- String off any numeric instance count (suffix in #xxxx) ---//
                //---------------------------------------------------------------//
                string fullPartNumber = partNumber.Split('#')[0];

                //--------------------------------//
                //--- Prepend the station name ---//
                //--------------------------------//
                fullPartNumber = stationType + "." + fullPartNumber;

                dao.StartTransaction();
                AssetIdentificationBean asset;
                description = new InstrumentDescription();
                var identificationNumber = new ManufacturerIdentificationNumber();
                identificationNumber.number = fullPartNumber;
                identificationNumber.manufacturerName = "[Unknown]";
                identificationNumber.type = IdentificationNumberType.Part;
                description.name = fullPartNumber;
                description.uuid = Guid.NewGuid().ToString();
                description.Identification = new ItemDescriptionIdentification();
                description.Identification.ModelName = partNumber;
                description.Identification.IdentificationNumbers = new List<IdentificationNumber>();
                description.Identification.IdentificationNumbers.Add(identificationNumber);
                //Add document to document database
                //The UUT is a Model Number Asset so we will use a model name for the filename
                //We will also use the ATML Standard number (1671.3) for part of the file name
                string docName = string.Format("{0}.1671.2.xml", FileUtils.MakeGoodFileName(fullPartNumber));

                var document = new Document();
                document.Description = description.name;
                document.uuid = description.uuid;
                document.name = docName;
                document.Item = description.Serialize();
                document.DocumentContent = Encoding.UTF8.GetBytes(document.Item);
                document.ContentType = "text/xml";
                document.DocumentType = dbDocument.DocumentType.INSTRUMENT_DESCRIPTION;
                PersistanceController.Save(document);

                //Add reference id to asset lookup
                asset = new AssetIdentificationBean();
                asset.uuid = Guid.Parse(description.uuid);
                asset.assetType = "Part";
                asset.assetNumber = fullPartNumber;
                asset.DataState = BASEBean.eDataState.DS_ADD;
                asset.save();

                //Add instrument document to atml directory - use part number as file name + 1671.2
                //TODO: Think about this: ProjectManager.SaveATMLDocument(docName, ProjectManager.AtmlTypeInstrument, document.DocumentContent);

                //----------------------------------------------//
                //--- Add the instrument to the test station ---//
                //----------------------------------------------//
                TestStationController.Instance.AddInstrumentReference(testStation, 
                                                              partNumber, 
                                                              document.uuid );//,
                                                              //document.DocumentContent );
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
            return description;
        }

        public string Create( string partNumber, string nomen, string model )
        {
            return null;
        }

        public void Save( InstrumentDescription atmlObject )
        {
            if (base.Save(atmlObject))
                OnInstrumentDescriptionChanged(atmlObject);
        }

        public InstrumentDescription Find( Guid? id )
        {
            return base.Find<InstrumentDescription>(id.ToString());
        }

        public InstrumentDescription Find( string uuid )
        {
            return base.Find<InstrumentDescription>(uuid);
        }

        public void AddInstrumentReference( InstrumentDescription atmlObject, string partNumber, string documentUuid )
        {
            
        }

        public bool HasInstrumentReference( InstrumentDescription atmlObject, string partNumber )
        {
            return false;
        }
    }
}