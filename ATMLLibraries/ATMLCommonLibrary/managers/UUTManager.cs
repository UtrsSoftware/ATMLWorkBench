/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
* 
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

using System;
using System.Collections;
using System.IO;
using System.Text;
using System.Timers;
using System.Windows.Forms;
using ATMLCommonLibrary.forms;
using ATMLDataAccessLibrary.db.beans;
using ATMLDataAccessLibrary.model;
using ATMLManagerLibrary.managers;
using ATMLModelLibrary.model;
using ATMLModelLibrary.model.common;
using ATMLModelLibrary.model.uut;
using ATMLUtilitiesLibrary;

namespace ATMLCommonLibrary.managers
{
    public class UutManager : IDocumentObject
    {
        private const string FILTER = "*.3.xml";

        static private UutManager _instance;
        private static readonly object syncRoot = new Object();

        static public UutManager Instance
        {
            get
            {
                if (_instance == null)
                    lock (syncRoot)
                    {
                        if (_instance == null)
                        {
                            _instance = new UutManager();
                        }
                    }
                return _instance;
            }
        }

        private UutManager()
        {
            
        }

        public static UUTDescription FindUut(ItemDescriptionReference uutReference)
        {
            UUTDescription uut = null;
            string uuid;
            if (uutReference != null && uutReference.Item is DocumentReference)
            {
                uuid = ((DocumentReference) uutReference.Item).uuid;
                Document document = DocumentManager.GetDocument(uuid);
                if (document != null && document.DocumentContent != null)
                {
                    uut = UUTDescription.Deserialize(Encoding.UTF8.GetString(document.DocumentContent));
                }
            }

            return uut;
        }


        public static UUTDescription FindUut(string uuid)
        {
            UUTDescription uut = null;
            if (!string.IsNullOrWhiteSpace(uuid))
            {
                Document document = DocumentManager.GetDocument(uuid);
                if (document != null && document.DocumentContent != null)
                {
                    uut = UUTDescription.Deserialize(Encoding.UTF8.GetString(document.DocumentContent));
                }
            }
            return uut;
        }


        public static UUTDescription GetUutFromFile(string fileName)
        {
            return UUTDescription.Deserialize( StringUtils.RemoveByteOrderMarkUTF8(Encoding.UTF8.GetString(FileManager.ReadFile(fileName))));
        }

        /**
         * Determines if the UUT exists for the id provided.
         * @returns bool true if the UUT exists in the database
         */
        public bool HasUut(string uuid)
        {
            return FindUut(uuid) != null;
        }


        public void Edit(Document uutDocument, object obj, bool saveOnCompletion)
        {
            UUTDescription uut = obj as UUTDescription;
            if (uut != null)
            {
                UUTDescriptionForm form = new UUTDescriptionForm();
                form.UUTDescription = uut;
                if (DialogResult.OK == form.ShowDialog())
                {
                    uut = form.UUTDescription;
                    uutDocument.DocumentContent = Encoding.UTF8.GetBytes(uut.Serialize());
                    if (saveOnCompletion)
                    {
                        Save(uut);
                    }
                }
            }
        }


        public static bool ProjectHasUUT(string projectName)
        {
            string path = System.IO.Path.Combine(ATMLContext.TESTSET_PATH, projectName, "atml" );
            return Directory.GetFileSystemEntries(path, FILTER).Length > 0;
        }

        public static string BuildAtmlFileName(string uutModelName)
        {
            return string.Format("{0}{1}", FileUtils.MakeGoodFileName(uutModelName), ATMLContext.ATML_UUT_FILENAME_SUFFIX);
        }

        public static UUTDescription GetProjectUUT(string projectName)
        {
            UUTDescription uut = null;
            string path = System.IO.Path.Combine(ATMLContext.TESTSET_PATH, projectName, "atml" );
            string fileName = Path.Combine(path, BuildAtmlFileName(projectName));
            if (File.Exists(fileName))
            {
                uut = UUTDescription.Deserialize(Encoding.UTF8.GetString(FileManager.ReadFile(fileName)));
            }
            else
            {
                foreach (string fileSystemEntry in Directory.GetFileSystemEntries(path, FILTER))
                {
                    uut = UUTDescription.Deserialize(Encoding.UTF8.GetString(FileManager.ReadFile(fileSystemEntry)));
                    break;
                }
            }
            return uut;
        }


        public static void Save(UUTDescription uut)
        {
            string uuid;
            if (uut != null)
            {
                string model = uut.Item.Identification.ModelName;
                string documentName = BuildAtmlFileName(model);
                uuid = uut.uuid;
                Document document = DocumentManager.GetDocument(uuid);
                if (document != null)
                {
                    document.DocumentContent = Encoding.UTF8.GetBytes(uut.Serialize());
                    document.DataState = BASEBean.eDataState.DS_EDIT;
                    document.name = documentName;
                    DocumentManager.SaveDocument(document);
                }
                else
                {
                    AssetIdentificationBean bean = new AssetIdentificationBean();
                    document = new Document();
                    document.name = documentName;
                    document.DocumentContent = Encoding.UTF8.GetBytes(uut.Serialize());
                    document.DocumentType = dbDocument.DocumentType.UUT_DESCRIPTION;
                    document.ContentType = "text/xml";
                    DocumentManager.SaveDocument(document);
                    bean.assetNumber = model;
                    bean.assetType = "Part";
                    bean.uuid = Guid.Parse(uuid);
                    bean.DataState = BASEBean.eDataState.DS_ADD;
                    bean.save();
                }
            }
        }

    }
}