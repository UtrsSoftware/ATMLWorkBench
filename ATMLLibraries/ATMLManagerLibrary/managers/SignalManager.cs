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
using System.Text;
using System.Xml;
using ATMLDataAccessLibrary.db.daos;
using ATMLDataAccessLibrary.model;
using ATMLManagerLibrary.managers;
using ATMLModelLibrary.model.common;
using ATMLModelLibrary.model.signal.basic;
using ATMLSignalModelLibrary.signal;

namespace ATMLSignalModelLibrary.managers
{
    public sealed class SignalManager
    {
        private static volatile SignalManager _instance = null;
        private static readonly object syncRoot = new Object();
        private XmlDocument _signalTree;
        private readonly Dictionary<string,SignalModelLibrary> _signalModelLibraryCache = new Dictionary<string, SignalModelLibrary>(); 

        private SignalManager()
        {
            LoadSignalModelLibraryCache();
        }

        public static SignalManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (syncRoot)
                    {
                        if (_instance == null)
                            _instance = new SignalManager();
                    }
                }
                return _instance;
            }
        }

        public XmlDocument SignalTree
        {
            get
            {
                try
                {
                    if (_signalTree == null)
                    {
                        SignalDAO dao = new SignalDAO();
                        _signalTree = dao.BuildSignalTree();
                    }
                }
                catch (Exception e )
                {
                    LogManager.Error( e );
                }
                return _signalTree;
            }
        }


        public XmlDocument TSFSignalTree
        {
            get
            {
                XmlDocument tree = SignalTree;
                if (tree != null)
                {
                    XmlNodeList xnList = tree.SelectNodes("/SignalFunction/TSF");
                    if (xnList.Count > 0)
                    {
                        XmlNode node = xnList.Item(0);
                        var doc = new XmlDocument();
                        if (node != null)
                        {
                            doc.AppendChild(doc.ImportNode(node, true));
                        }
                        tree = doc;
                    }
                }
                return tree;
            }
        }


        public void LoadSignalModelLibraryCache()
        {
            SignalDAO dao = new SignalDAO();
            List<dbTSFLibrary> list = dao.getTSFLibraries();
            _signalModelLibraryCache.Clear();
            foreach (dbTSFLibrary library in list)
            {
                string xmlns = library.targetNamespace;
                string content = library.content;
                if (string.IsNullOrEmpty(xmlns))
                {
                    LogManager.Warn("A namespace does not exist for {0} and therefore not added to the schema cache.", library.libraryName );
                }
                else
                {
                    MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(content));
                    SignalModelLibrary sml = new SignalModelLibrary(ms);
                    _signalModelLibraryCache.Add(xmlns, sml);
                }
            }
        }


        public static SignalModel GetSignalModel(string nameSpace, string signalName)
        {
            SignalModel model = null;
            SignalModelLibrary library = null;
            SignalManager sm = Instance;
            if (sm._signalModelLibraryCache.ContainsKey(nameSpace))
            {
                library = sm._signalModelLibraryCache[nameSpace];
            }
            else
            {
                SignalDAO dao = new SignalDAO();
                dbTSFLibrary tsfLib = dao.getTSFLibraryByNameSpace(nameSpace);
                if (tsfLib != null)
                {
                    string content = tsfLib.content;
                    MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(content));
                    library = new SignalModelLibrary(ms);
                    sm._signalModelLibraryCache.Add(nameSpace, library);
                }
            }
            if (library != null) 
                model = library.GetSignalModel(signalName);

            return model;
        }


        public static List<Signal> ExtractSignalsFromExtension(Extension ext)
        {
            List<Signal> _signals = null;
            //------------------------------------------------------------//
            //--- Process the SignalDescription as a Extension element ---//
            //------------------------------------------------------------//
            if (ext != null)
            {
                List<XmlElement> any = ext.Any;
                if (any != null)
                {
                    _signals = new List<Signal>(any.Count);
                    foreach( XmlElement element in any )
                    {
                        _signals.Add( SignalModel.ExtractSignalFromElement( element ) );
                    }
                }
            }
            return _signals;
        }

    }
}
