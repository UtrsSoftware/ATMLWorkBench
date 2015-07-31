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
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using System.Xml.Linq;
using ATMLDataAccessLibrary.db.beans;
using ATMLDataAccessLibrary.db.daos;
using ATMLDataAccessLibrary.managers;
using ATMLDataAccessLibrary.model;
using ATMLManagerLibrary.interfaces;
using ATMLModelLibrary.model.common;
using ATMLModelLibrary.model.equipment;
using ATMLModelLibrary.model.uut;

namespace ATMLManagerLibrary.managers
{
    public delegate void DocumentChangedDelegate( Document document );

    public delegate void EditDocumentDelegate(
        IDocumentEditor source, Document document, object obj, bool saveDocumentOnCompletion );

    public interface IDocumentObject
    {
        void Edit( Document uutDocument, object obj, bool saveOnCompletion );
    }

    public class DocumentManager
    {
        private static String GENERIC_CONTENT_TYPE = "application/octet-stream";
        private static readonly object syncRoot = new Object();
        private static volatile DocumentManager _instance;
        private readonly Dictionary<String, List<String>> _mimeTypes = new Dictionary<String, List<String>>();
        private readonly DocumentDAO dao = DataManager.getDocumentDAO();

        private DocumentManager()
        {
            LoadMimeTypes();
        }

        public static DocumentManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (syncRoot)
                    {
                        if (_instance == null)
                            _instance = new DocumentManager();
                    }
                }
                return _instance;
            }
        }

        public event DocumentChangedDelegate DocumentChanged;
        public static event EditDocumentDelegate EditInstrument;
        public static event EditDocumentDelegate EditTestStation;
        public static event EditDocumentDelegate EditUUT;
        public static event EditDocumentDelegate EditTestAdapter;

        private static void OnEditInstrument( IDocumentEditor source, Document document, InstrumentDescription obj,
                                              bool saveDocumentOnCompletion )
        {
            bool ret = false;
            EditDocumentDelegate handler = EditInstrument;
            if (handler != null) handler( source, document, obj, saveDocumentOnCompletion );
        }

        private static void OnEditTestStation( IDocumentEditor source, Document document, TestStationDescription11 obj,
                                               bool saveDocumentOnCompletion )
        {
            EditDocumentDelegate handler = EditTestStation;
            if (handler != null) handler( source, document, obj, saveDocumentOnCompletion );
        }

        private static void OnEditUut( IDocumentEditor source, Document document, UUTDescription obj,
                                       bool saveDocumentOnCompletion )
        {
            bool ret = false;
            EditDocumentDelegate handler = EditUUT;
            if (handler != null) handler( source, document, obj, saveDocumentOnCompletion );
        }

        private static void OnEditTestAdapter( IDocumentEditor source, Document document, TestAdapterDescription1 obj,
                                               bool saveDocumentOnCompletion )
        {
            bool ret = false;
            EditDocumentDelegate handler = EditTestAdapter;
            if (handler != null) handler( source, document, obj, saveDocumentOnCompletion );
        }

        public virtual void OnDocumentChanged( Document document )
        {
            DocumentChangedDelegate handler = DocumentChanged;
            if (handler != null) handler( document );
        }

        private void LoadMimeTypes()
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            const string resourceName = "ATMLManagerLibrary.Resources.XMLMimeTypes.xml";
            using (Stream stream = assembly.GetManifestResourceStream( resourceName ))
            {
                if (stream != null)
                {
                    using (var reader = new StreamReader( stream ))
                    {
                        string result = reader.ReadToEnd();
                        XDocument document = XDocument.Parse( result );
                        var q = from lv1 in document.Descendants( "tbody" )
                                select new
                                       {
                                           Rows = lv1.Descendants( "tr" )
                                       };
                        foreach (var lv in q)
                        {
                            foreach (XElement row in lv.Rows)
                            {
                                var cols = new List<String>();
                                foreach (XElement col in row.Descendants( "td" ))
                                {
                                    cols.Add( col.Value );
                                }
                                if (!_mimeTypes.ContainsKey( cols[2] ))
                                    _mimeTypes.Add( cols[2], cols );
                                else
                                    Console.WriteLine( cols[2] + ": " + cols[1] );
                            }
                        }
                    }
                }
            }
        }

        //--- Whenever a document is changed we need to make sure we update the cached document ---//
        public static bool HasDocument( String uuid )
        {
            return Instance.dao.hasDocument( uuid );
        }

        public static bool HasDocument( string documentName, int documentType )
        {
            return Instance.dao.hasDocument( documentName, documentType );
        }

        public static Document GetDocument( String uuid )
        {
            Document document = null;
            dbDocument dbDoc = Instance.dao.openDatabaseDocument( uuid );
            if (dbDoc != null)
                document = new Document( dbDoc );
            return document;
        }

        public static Document GetDocument( Guid? uuid )
        {
            Document document = null;
            dbDocument dbDoc = Instance.dao.openDatabaseDocument( uuid.ToString() );
            if (dbDoc != null)
                document = new Document( dbDoc );
            return document;
        }

        public static Document GetDocumentByName( String name )
        {
            Document document = null;
            dbDocument dbDoc = Instance.dao.openDatabaseDocumentByName( name );
            if (dbDoc != null)
                document = new Document( dbDoc );
            return document;
        }


        public static Document GetDocument( string documentName, int documentType )
        {
            Document document = null;
            dbDocument dbDoc = Instance.dao.openDatabaseDocument( documentName, documentType );
            if (dbDoc != null)
                document = new Document( dbDoc );
            return document;
        }

        public static String GetContentType( String fileExt )
        {
            String contentType = GENERIC_CONTENT_TYPE;
            if (Instance._mimeTypes.ContainsKey( fileExt ))
                contentType = Instance._mimeTypes[fileExt][1];
            return contentType;
        }


        public static String DetermineContentType( String fileName )
        {
            String contentType = GENERIC_CONTENT_TYPE;
            int idx = fileName.LastIndexOf( "." );
            if (idx != -1)
            {
                String ext = fileName.Substring( idx );
                contentType = GetContentType( ext );
            }
            return contentType;
        }


        public static void SaveDocument( DocumentReference docRef )
        {
            bool newDocument = false;
            if (String.IsNullOrEmpty( docRef.uuid ))
                docRef.uuid = Guid.NewGuid().ToString();

            //-------------------------------------------------//
            //--- We will save to the database at this time ---//  
            //-------------------------------------------------//
            DocumentDAO documentDAO = DataManager.getDocumentDAO();
            var document = new dbDocument();
            if (documentDAO.hasDocument( docRef.uuid ))
            {
                document = documentDAO.openDatabaseDocument( docRef.uuid );
                document.DataState = BASEBean.eDataState.DS_EDIT;
                document.dateUpdated = DateTime.UtcNow;
            }
            else
            {
                document.DataState = BASEBean.eDataState.DS_ADD;
                document.dateAdded = DateTime.UtcNow;
                newDocument = true;
            }

            document.documentContent = docRef.DocumentContent;
            document.documentName = docRef.DocumentName;
            document.documentSize = docRef.DocumentContent.Length;
            document.contentType = docRef.ContentType;
            document.save();
            LogManager.Trace( "Referenced Document {0} has been {1}", document.documentName,
                              newDocument ? "Added" : "Saved" );
        }

        public static void SaveDocument( Document doc )
        {
            bool hasLocalTransaction = false;
            //------------------------------------------------------------//
            //--- Only save to the database if the content is not null ---//
            //------------------------------------------------------------//
            BASEBean.eDataState stateId;
            if (doc.DocumentContent != null)
            {
                if (String.IsNullOrEmpty( doc.uuid ))
                    doc.uuid = Guid.NewGuid().ToString();

                //-------------------------------------------------//
                //--- We will save to the database at this time ---//  
                //-------------------------------------------------//
                DocumentDAO documentDAO = DataManager.getDocumentDAO();
                try
                {
                    if (!documentDAO.IsInTransaction)
                    {
                        documentDAO.StartTransaction();
                        hasLocalTransaction = true;
                    }
                    var document = new dbDocument();
                    bool hasDocumentByUuid = documentDAO.hasDocument( doc.uuid );
                    bool hasDocumentByName = documentDAO.hasDocument( doc.name, (int) doc.DocumentType );
                    if (hasDocumentByName != hasDocumentByUuid)
                    {
                        string msg =
                            "There is an inconsistancy with the document uuid and the internal uuid for the device, please correct.";
                        MessageBox.Show( msg, @"E R R O R" );
                        throw new Exception( msg );
                    }

                    if (hasDocumentByUuid)
                    {
                        document = documentDAO.openDatabaseDocument( doc.uuid );
                        stateId = document.DataState = ( doc.DataState == BASEBean.eDataState.DS_DELETE
                                                             ? BASEBean.eDataState.DS_DELETE
                                                             : BASEBean.eDataState.DS_EDIT );
                        document.dateUpdated = DateTime.UtcNow;
                    }
                    else
                    {
                        stateId = document.DataState = BASEBean.eDataState.DS_ADD;
                        document.dateAdded = DateTime.UtcNow;
                    }

                    int assetsDeleted = 0;
                    if (stateId == BASEBean.eDataState.DS_DELETE)
                    {
                        if (documentDAO.HasAssets( doc.uuid ))
                        {
                            assetsDeleted = documentDAO.DeleteAssets( doc.uuid );
                        }
                    }
                    document.UUID = Guid.Parse( doc.uuid );
                    document.documentDescription = doc.Description;
                    document.documentTypeId = (int) doc.DocumentType;
                    document.documentContent = doc.DocumentContent;
                    document.documentName = doc.name;
                    document.documentSize = doc.DocumentContent.Length;
                    document.contentType = doc.ContentType;
                    document.crc = doc.Crc32;
                    document.save();
                    if (hasLocalTransaction )
                        documentDAO.CommitTransaction();
                    LogManager.Trace( "Document {0} has been {1}",
                                      document.documentName,
                                      stateId == BASEBean.eDataState.DS_ADD
                                          ? "Added"
                                          : stateId == BASEBean.eDataState.DS_DELETE
                                                ? "Deleted"
                                                : "Saved" );
                    if (assetsDeleted > 0)
                        LogManager.Trace( "Deleted {0} associated assets.", assetsDeleted );

                    if (document.DataState == BASEBean.eDataState.DS_ADD)
                        document.DataState = BASEBean.eDataState.DS_EDIT;
                }
                catch (Exception e)
                {
                    if (hasLocalTransaction)
                    {
                        documentDAO.RollbackTransaction();
                        LogManager.Error(e);
                    }
                    else
                    {
                        throw;
                    }
                }
            }
        }


        public static List<Document> GetDocumentsByType( int documentTypeId )
        {
            DocumentDAO documentDAO = DataManager.getDocumentDAO();
            var documents = new List<Document>();
            List<dbDocument> docs = documentDAO.GetDocumentsByType( documentTypeId );
            foreach (dbDocument doc in docs)
                documents.Add( new Document( doc ) );
            return documents;
        }


        public static AssetIdentificationBean FindAsset( string assetType, string assetNumber )
        {
            DocumentDAO dao = DataManager.getDocumentDAO();
            return dao.FindAsset( assetType, assetNumber );
        }

        public static AssetIdentificationBean FindAsset( string uuid )
        {
            DocumentDAO dao = DataManager.getDocumentDAO();
            return dao.FindAsset( uuid );
        }

        public static string CreateDocumentPlaceHolder( string partNumber, string assetType, string contentType,
                                                        string docType, string description )
        {
            string refId = null;
            var asset = new AssetIdentificationBean();
            DocumentDAO dao = DataManager.getDocumentDAO();
            try
            {
                dao.StartTransaction();
                //Lookup Part Number for document
                string rootPartNumber = partNumber.Split( '#' )[0];
                Document document = GetDocument( rootPartNumber,
                                                 (int) Enum.Parse( typeof (dbDocument.DocumentType), docType ) );
                if (document == null)
                {
                    document = new Document();
                    document.uuid = Guid.NewGuid().ToString();
                    document.name = rootPartNumber;
                    document.Item = ""; //Content
                    document.DocumentContent = Encoding.UTF8.GetBytes( document.Item );
                    document.ContentType = contentType ?? "";
                    document.Description = (description.Length>255?description.Substring( 0,254 ):description) ?? "";
                    document.DocumentType =
                        (dbDocument.DocumentType) Enum.Parse( typeof (dbDocument.DocumentType), docType );
                    SaveDocument( document );
                }

                //Add reference id to asset lookup
                asset = new AssetIdentificationBean();
                asset.uuid = Guid.Parse( document.uuid );
                asset.assetType = assetType;
                asset.assetNumber = partNumber;
                asset.DataState = BASEBean.eDataState.DS_ADD;
                asset.save();
                refId = asset.uuid.ToString();
                dao.CommitTransaction();
                LogManager.Trace( "A placeholder document for \"{0}\" has been created.", partNumber );
            }
            catch (Exception e)
            {
                dao.RollbackTransaction();
                LogManager.Error( e, "An Error occurred creating a document for \"{0}\"", partNumber );
            }
            finally
            {
                dao.EndTransaction();
            }
            return refId;
        }

        public static bool EditDocument( IDocumentEditor source, Document _document, string uuid, string documentContent,
                                         bool saveDocumentOnCompletion )
        {
            bool documentSaved = false;
            Document document = GetDocument( uuid );
            if (document != null)
            {
                string content = Encoding.UTF8.GetString( _document.DocumentContent );

                switch (document.DocumentType)
                {
                    case dbDocument.DocumentType.INSTRUMENT_DESCRIPTION:
                    {
                        InstrumentDescription obj =
                            InstrumentDescription.Deserialize( content );
                        OnEditInstrument( source, document, obj, saveDocumentOnCompletion );
                        break;
                    }
                    case dbDocument.DocumentType.TEST_ADAPTER_DESCRIPTION:
                    {
                        TestAdapterDescription1 obj =
                            TestAdapterDescription1.Deserialize( content );
                        OnEditTestAdapter( source, document, obj, saveDocumentOnCompletion );
                        break;
                    }
                    case dbDocument.DocumentType.TEST_STATION_DESCRIPTION:
                    {
                        TestStationDescription11 obj =
                            TestStationDescription11.Deserialize( content );
                        OnEditTestStation( source, document, obj, saveDocumentOnCompletion );
                        break;
                    }
                    case dbDocument.DocumentType.UUT_DESCRIPTION:
                    {
                        UUTDescription obj =
                            UUTDescription.Deserialize( content );
                        OnEditUut( source, document, obj, saveDocumentOnCompletion );
                        break;
                    }
                    default:
                    {
                        MessageBox.Show(
                            string.Format( "There is currently no editor available for document type \"{0}\".",
                                           document.DocumentType ) );
                        break;
                    }
                }
            }

            return documentSaved;
        }


        public static bool IsEditableDocumentType( dbDocument.DocumentType documentType )
        {
            bool editable = false;
            var bean = CacheManager.GetDocumentTypeCache().getItem( "" + (int) documentType ) as LuDocumentTypeBean;
            if (bean != null && bean.objectEditable != null)
                editable = bean.objectEditable.Value;
            return editable;
        }
    }


    public class MimeTypes
    {
    }
}