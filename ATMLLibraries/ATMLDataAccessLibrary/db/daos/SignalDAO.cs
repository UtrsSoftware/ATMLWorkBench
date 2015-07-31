/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
* 
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Xml;
using System.Text;
using System.Data.OleDb;
using ATMLDataAccessLibrary.model;
using ATMLDataAccessLibrary.db.beans;

namespace ATMLDataAccessLibrary.db.daos
{
    public class SignalDAO : DAO
    {

        public String getSignalTree()
        {
            StringBuilder sb = new StringBuilder();

            return sb.ToString();
        }


        public List<dbSignal> getRootSignals()
        {
            XmlDocument doc = new XmlDocument();
            List<dbSignal> signals = new List<dbSignal>();

            String sql = "SELECT * FROM signal_master WHERE parent_signal_id=? ORDER BY signal_name";
            OleDbParameter[] dbParams = { CreateParameter("@parent_signal_id", 1) };
            using (OleDbDataReader reader = ExecuteSqlQuery( sql, dbParams ))
            {
                if (reader != null)
                {
                    while (reader.Read())
                    {
                        dbSignal signal = new dbSignal();
                        signal.load( reader );
                        signal.ChildSignals = getChildSignals( signal.signalId );
                        signal.Attributes = getSignalAttributes( signal.signalId );
                        signals.Add( signal );
                    }
                    reader.Close();
                    reader.Dispose();
                }
            }
            return signals;            
        }

        public List<dbSignal> GetAllTsfSignals()
        {
            var doc = new XmlDocument();
            var signals = new List<dbSignal>();

            var sql = new StringBuilder();
            sql.Append("SELECT a.* FROM ")
                .Append(SignalMasterBean._TABLE_NAME)
                .Append(" a, ")
                .Append(TestSignalLibraryBean._TABLE_NAME)
                .Append(" b WHERE a.")
                .Append(SignalMasterBean._XMLNS)
                .Append(" = b.")
                .Append(TestSignalLibraryBean._TARGET_NAMESPACE)
                .Append(" ORDER BY ")
                .Append(SignalMasterBean._SIGNAL_NAME);
            OleDbParameter[] dbParams = { CreateParameter("@parent_signal_id", 1) };
            using (OleDbDataReader reader = ExecuteSqlQuery( sql.ToString(), dbParams ))
            {
                if (reader != null)
                {
                    while (reader.Read())
                    {
                        var signal = new dbSignal();
                        signal.load( reader );
                        signal.ChildSignals = getChildSignals( signal.signalId );
                        signal.Attributes = getSignalAttributes( signal.signalId );
                        signals.Add( signal );
                    }
                    reader.Close();
                    reader.Dispose();
                }
            }
            return signals;
        }

        public List<dbSignal> getAllSignals()
        {
            XmlDocument doc = new XmlDocument();
            List<dbSignal> signals = new List<dbSignal>();

            String sql = "SELECT * FROM signal_master ORDER BY signal_name";
            OleDbParameter[] dbParams = {};
            using (OleDbDataReader reader = ExecuteSqlQuery( sql, dbParams ))
            {
                if (reader != null)
                {
                    while (reader.Read())
                    {
                        dbSignal signal = new dbSignal();
                        signal.load( reader );
                        signal.ChildSignals = getChildSignals( signal.signalId );
                        signal.Attributes = getSignalAttributes( signal.signalId );
                        signals.Add( signal );
                    }
                    reader.Close();
                    reader.Dispose();
                }
            }
            return signals;
        }


        public List<dbSignalAttribute> getSignalAttributes(int? signalId)
        {
            List<dbSignalAttribute> signalAttributes = new List<dbSignalAttribute>();
            String sql = "SELECT * FROM signal_attribute_master WHERE signal_id = ?";
            OleDbParameter[] dbParams = { CreateParameter("@signal_id", signalId) };
            using (OleDbDataReader reader = ExecuteSqlQuery( sql, dbParams ))
            {
                if (reader != null)
                {
                    while (reader.Read())
                    {
                        dbSignalAttribute signalAttribute = new dbSignalAttribute();
                        signalAttribute.load( reader );
                        signalAttributes.Add( signalAttribute );
                    }
                    reader.Close();
                    reader.Dispose();
                }
            }
            return signalAttributes;
        }


        public bool hasAttribute( int? signalId, String attributeName )
        {
            int count = 0;
            String sql = "SELECT count(*) FROM signal_attribute_master WHERE signal_id = ? AND attribute_name = ?";
            OleDbParameter[] dbParams = { CreateParameter(dbSignalAttribute._SIGNAL_ID, signalId), 
                                          CreateParameter(dbSignalAttribute._ATTRIBUTE_NAME, attributeName ) };
            using (OleDbDataReader reader = ExecuteSqlQuery( sql, dbParams ))
            {
                if (reader != null)
                {
                    if (reader.Read())
                    {
                        count = reader.GetInt32( 0 );
                    }
                    reader.Close();
                    reader.Dispose();
                }
            }
            return count>0;
        }


        public dbSignalAttribute GetAttribute(int? signalId, String attributeName)
        {
            dbSignalAttribute attribute = null;
            String sql = "SELECT * FROM signal_attribute_master WHERE signal_id = ? AND attribute_name = ?";
            OleDbParameter[] dbParams = { CreateParameter(dbSignalAttribute._SIGNAL_ID, signalId), 
                                          CreateParameter(dbSignalAttribute._ATTRIBUTE_NAME, attributeName ) };
            attribute = CreateBean<dbSignalAttribute>(sql, dbParams);
            return attribute;
        }


        public List<dbSignalAttribute> getAllSignalAttributes(String signalName, string nameSpace)
        {
            List<dbSignalAttribute> signalAttributes = new List<dbSignalAttribute>();
            List<dbSignal> signals = new List<dbSignal>();
            getDescendantSignals(signalName, nameSpace, signals);
            foreach (dbSignal signal in signals)
            {
                List<dbSignalAttribute> attributes = getSignalAttributes(signal.signalId);
                foreach (dbSignalAttribute attribute in attributes)
                {
                    signalAttributes.Add(attribute);
                }
            }
            return signalAttributes;
        }


        public List<dbSignalAttribute> getAllSignalAttributes(int? signalId)
        {
            List<dbSignalAttribute> signalAttributes = new List<dbSignalAttribute>();
            List<dbSignal> signals = new List<dbSignal>();
            getDescendantSignals(signalId, signals );
            foreach (dbSignal signal in signals)
            {
                List<dbSignalAttribute> attributes = getSignalAttributes(signal.signalId);
                foreach (dbSignalAttribute attribute in attributes)
                {
                    signalAttributes.Add(attribute);
                }
            }
            return signalAttributes;
        }




        public List<dbSignal> getChildSignals(int? parentSignalId)
        {
            List<dbSignal> signals = new List<dbSignal>();
            if (parentSignalId != null)
            {
                String sql = "SELECT * FROM signal_master WHERE parent_signal_id = ?";
                OleDbParameter[] dbParams = {CreateParameter("@parent_signal_id", parentSignalId)};
                OleDbDataReader reader = ExecuteSqlQuery(sql, dbParams);
                if (reader != null)
                {
                    while (reader.Read())
                    {
                        dbSignal signal = new dbSignal();
                        signal.load(reader);
                        signal.ChildSignals = getChildSignals(signal.signalId);
                        signal.Attributes = getSignalAttributes(signal.signalId);
                        signals.Add(signal);
                    }
                    reader.Close();
                    reader.Dispose();
                }
            }
            return signals;
        }


        public void getDescendantSignals(int? signalId, List<dbSignal> signals )
        {
            dbSignal signal = getSignal(signalId);
            if (signal != null)
            {
                signals.Add(signal);
                getDescendantSignals(signal.parentSignalId, signals);
            }
        }

        public void getDescendantSignals(string signalName, string nameSpace, List<dbSignal> signals)
        {
            dbSignal signal = getSignal(signalName, nameSpace);
            if (signal != null)
            {
                signals.Add(signal);
                getDescendantSignals(signal.parentSignalId, signals);
            }
        }

        public dbSignal getSignal(int? signalId)
        {
            dbSignal signal = null;
            if (signalId != null)
            {
                String sql = "SELECT * FROM signal_master WHERE signal_id = ?";
                OleDbParameter[] dbParams = {CreateParameter("@signal_id", signalId)};
                OleDbDataReader reader = ExecuteSqlQuery(sql, dbParams);
                if (reader != null)
                {
                    if (reader.Read())
                    {
                        signal = new dbSignal();
                        signal.load(reader);
                        signal.ChildSignals = getChildSignals(signal.signalId);
                        signal.Attributes = getSignalAttributes(signal.signalId);
                        if (signal.parentSignalId != null)
                            signal.ParentSignal = getSignal( signal.parentSignalId );
                    }
                    reader.Close();
                    reader.Dispose();
                }
            }
            return signal;
        }

        public dbSignal getSignal(string signalName, string nameSpace )
        {
            dbSignal signal = null;
            if (signalName != null)
            {
                String sql = "SELECT * FROM signal_master WHERE signal_name = ?";
                List<OleDbParameter> dbParams = new List<OleDbParameter>();
                dbParams.Add(CreateParameter("@signal_name", signalName));
                if (!string.IsNullOrEmpty(nameSpace))
                {
                    sql += " AND xmlns = ? ";
                    dbParams.Add(CreateParameter("@xmlns", nameSpace));
                }

                OleDbDataReader reader = ExecuteSqlQuery(sql, dbParams.ToArray());
                if (reader != null)
                {
                    if (reader.Read())
                    {
                        signal = new dbSignal();
                        signal.load(reader);
                        signal.ChildSignals = getChildSignals(signal.signalId);
                        signal.Attributes = getSignalAttributes(signal.signalId);
                        if (signal.parentSignalId != null)
                            signal.ParentSignal = getSignal(signal.parentSignalId);

                    }
                    reader.Close();
                    reader.Dispose();
                }
            }
            return signal;
        }

        public bool hasTSFLibrary(String uuid)
        {
            bool hasLibrary = false;
            String sql = "SELECT count(*) as _count FROM " 
                        + TestSignalLibraryBean._TABLE_NAME 
                        + " WHERE " 
                        + TestSignalLibraryBean._ID 
                        + " = ?";
            OleDbParameter[] dbParams = { CreateParameter(TestSignalLibraryBean._ID, uuid) };
            OleDbDataReader reader = ExecuteSqlQuery(sql, dbParams);
            if (reader != null)
            {
                if (reader.Read())
                {
                    Int32? count = reader.GetInt32(0);
                    hasLibrary = count == null || count == 0 ? false : true;
                }
                reader.Close();
                reader.Dispose();
            }
            return hasLibrary;
        }

        public bool hasTSFSignal(String uuid)
        {
            bool hasSignal = false;
            String sql = "SELECT count(*) as _count FROM "
                        + TestSignalBean._TABLE_NAME
                        + " WHERE "
                        + TestSignalBean._ID
                        + " = ?";
            OleDbParameter[] dbParams = { CreateParameter(TestSignalBean._ID, uuid) };
            OleDbDataReader reader = ExecuteSqlQuery(sql, dbParams);
            if (reader != null)
            {
                if (reader.Read())
                {
                    Int32? count = reader.GetInt32(0);
                    hasSignal = count == null || count == 0 ? false : true;
                }
                reader.Close();
                reader.Dispose();
            }
            return hasSignal;
        }


        public bool changeTSFSignalId(Guid? oldUuid, Guid newUuid)
        {
            int count;
            bool hasSignal = false;
            String sql = string.Format( "UPDATE {0} SET {1}=? WHERE {1}=?", TestSignalBean._TABLE_NAME,
                                        TestSignalBean._ID );
            OleDbParameter[] dbParams = { CreateParameter(TestSignalBean._ID, newUuid), CreateParameter(TestSignalBean._ID, oldUuid) };
            ExecuteSqlCommand( sql, dbParams, out count );
            return count == 1;
        }


        public TestSignalBean getTSFSignal(String name, string libraryUuid )
        {
            String sql = string.Format( "SELECT * FROM {0} WHERE {1} = ? AND {2} = ?", 
                                        TestSignalBean._TABLE_NAME, 
                                        TestSignalBean._SIGNAL_NAME, 
                                        TestSignalBean._LIBRARY_UUID );
            OleDbParameter[] dbParams = { CreateParameter(TestSignalBean._SIGNAL_NAME, name), 
                                          CreateParameter(TestSignalBean._LIBRARY_UUID, libraryUuid) };
            return CreateBean<TestSignalBean>( sql, dbParams );
        }


        public List<TestSignalBean> getTSFSignals(String name)
        {
            String sql = string.Format("SELECT * FROM {0} WHERE {1} = ? ",
                                        TestSignalBean._TABLE_NAME,
                                        TestSignalBean._SIGNAL_NAME);
            OleDbParameter[] dbParams = { CreateParameter(TestSignalBean._SIGNAL_NAME, name) };
            return CreateList<TestSignalBean>(sql, dbParams);
        }


        public dbTSFLibrary getTSFLibrary(Guid libraryUUID)
        {
            dbTSFLibrary lb = new dbTSFLibrary();
            String sql = "SELECT * FROM "
                        + dbTSFLibrary._TABLE_NAME
                        + " WHERE "
                        + dbTSFLibrary._ID
                        + " = ?";
            OleDbParameter[] dbParams = { CreateParameter(dbTSFLibrary._ID, libraryUUID) };
            OleDbDataReader reader = ExecuteSqlQuery(sql, dbParams);
            if (reader != null)
            {
                while (reader.Read())
                {
                    lb.load(reader);
                    lb.Signals = getTSFLibrarySignals(libraryUUID);
                }
                reader.Close();
                reader.Dispose();
            }
            return lb;
        }


        public dbTSFLibrary getTSFLibraryByName(String libraryName )
        {
            dbTSFLibrary lb = new dbTSFLibrary();
            String sql = "SELECT * FROM "
                        + dbTSFLibrary._TABLE_NAME
                        + " WHERE "
                        + dbTSFLibrary._LIBRARY_NAME
                        + " = ?";
            OleDbParameter[] dbParams = { CreateParameter(dbTSFLibrary._ID, libraryName) };
            OleDbDataReader reader = ExecuteSqlQuery(sql, dbParams);
            if (reader != null)
            {
                while (reader.Read())
                {
                    lb.load(reader);
                    lb.Signals = getTSFLibrarySignals(lb.id);
                }
                reader.Close();
                reader.Dispose();
            }
            return lb;
        }


        public dbTSFLibrary getTSFLibraryByNameSpace(String libraryNameSpace)
        {
            dbTSFLibrary lb = null;
            String sql = "SELECT * FROM "
                        + dbTSFLibrary._TABLE_NAME
                        + " WHERE "
                        + dbTSFLibrary._TARGET_NAMESPACE
                        + " = ?";
            OleDbParameter[] dbParams = { CreateParameter(dbTSFLibrary._ID, libraryNameSpace) };
            OleDbDataReader reader = ExecuteSqlQuery(sql, dbParams);
            if (reader != null)
            {
                bool reading = reader.Read();
                if (reading)
                {
                    lb = new dbTSFLibrary();
                    while (reading)
                    {
                        lb.load(reader);
                        lb.Signals = getTSFLibrarySignals(lb.id);
                        reading = reader.Read();
                    }
                }
                reader.Close();
                reader.Dispose();
            }
            return lb;
        }


        public List<dbTSFLibrary> getTSFLibraries()
        {
            List<dbTSFLibrary> list = new List<dbTSFLibrary>();
            String sql = "SELECT * FROM "
                        + dbTSFLibrary._TABLE_NAME;
            OleDbParameter[] dbParams = {};
            OleDbDataReader reader = ExecuteSqlQuery(sql, dbParams);
            if (reader != null)
            {
                while (reader.Read())
                {
                    dbTSFLibrary lb = new dbTSFLibrary();
                    lb.load(reader);
                    list.Add(lb);
                }
                reader.Close();
                reader.Dispose();
            }
            return list;
        }

        public List<dbTSFSignal> getTSFLibrarySignals(Guid? libraryUUID )
        {
            List<dbTSFSignal> list = new List<dbTSFSignal>();
            String sql = "SELECT * FROM "
                        + dbTSFSignal._TABLE_NAME
                        + " WHERE "
                        + dbTSFSignal._LIBRARY_UUID
                        + " = ?";
            OleDbParameter[] dbParams = { CreateParameter(dbTSFSignal._LIBRARY_UUID, libraryUUID) };
            OleDbDataReader reader = ExecuteSqlQuery(sql, dbParams);
            if (reader != null)
            {
                while (reader.Read())
                {
                    dbTSFSignal lb = new dbTSFSignal();
                    lb.load(reader);
                    //TODO - FIX THIS lb.SignalParts = getTSFLibrarySignalParts(lb.id.ToString());
                    list.Add(lb);
                }
                reader.Close();
                reader.Dispose();
            }
            return list;
        }

        public dbSignal GetBaseBSCSignal()
        {
            dbSignal signal = null;
            String sql = "SELECT * FROM signal_master WHERE parent_signal_id = 1 AND xmlns LIKE '%STDBSC'";
            List<OleDbParameter> dbParams = new List<OleDbParameter>();
            OleDbDataReader reader = ExecuteSqlQuery(sql, dbParams.ToArray());
            if (reader != null)
            {
                if (reader.Read())
                {
                    signal = new dbSignal();
                    signal.load(reader);
                    signal.ChildSignals = getChildSignals(signal.signalId);
                    signal.Attributes = getSignalAttributes(signal.signalId);
                }
                reader.Close();
                reader.Dispose();
            }
            return signal;
        }

        public XmlDocument BuildSignalTree()
        {
            XmlDocument document = new XmlDocument();
            dbSignal basSignal = GetBaseBSCSignal();
            ProcessBSCSignalTreeNode(basSignal, document, null);
            return document;
        }

        private void ProcessBSCSignalTreeNode( dbSignal signal, XmlDocument document, XmlElement parentElement )
        {
            if (signal != null)
            {
                XmlElement basElement = document.CreateElement(signal.signalName);
                XmlAttribute id = document.CreateAttribute("id");
                XmlAttribute xmlns = document.CreateAttribute("xmlns");
                XmlAttribute uuid = document.CreateAttribute("uuid");
                id.Value = signal.signalId.ToString();
                xmlns.Value = signal.xmlns;
                uuid.Value = signal.uuid==null?"":signal.uuid.ToString();
                basElement.Attributes.Append(id);
                basElement.Attributes.Append(xmlns);
                basElement.Attributes.Append(uuid);
                foreach (dbSignalAttribute attribute in signal.Attributes)
                {
                    XmlAttribute att = document.CreateAttribute(attribute.attributeName);
                    att.Value = attribute.Value;
                    basElement.Attributes.Append(att);
                }
                if (parentElement == null)
                    document.AppendChild(basElement);
                else
                    parentElement.AppendChild(basElement);
                foreach (dbSignal child in signal.ChildSignals)
                {
                    ProcessBSCSignalTreeNode(child, document, basElement);
                }
                if (signal.signalName.Equals("TSF"))
                {
                    //Process TSFs
                    List<dbTSFLibrary> tsfs = getTSFLibraries();
                    foreach (dbTSFLibrary dbTsfLibrary in tsfs)
                    {
                        XmlElement lElement = document.CreateElement(dbTsfLibrary.libraryName);
                        List<dbTSFSignal> sigs = getTSFLibrarySignals(dbTsfLibrary.id);
                        foreach (dbTSFSignal dbTsfSignal in sigs )
                        {
                            dbSignal tsfSignal = getSignal(dbTsfSignal.signalName, dbTsfLibrary.targetNamespace);
                            ProcessBSCSignalTreeNode(tsfSignal, document, lElement );
                        }
                        basElement.AppendChild(lElement);
                    }
                }
            }            
        }

        public List<dbTSFSignalSignal> getTSFLibrarySignalParts(String signalUUID)
        {
            List<dbTSFSignalSignal> list = new List<dbTSFSignalSignal>();
            String sql = "SELECT * FROM "
                        + dbTSFSignalSignal._TABLE_NAME
                        + " WHERE "
                        + dbTSFSignalSignal._SIGNAL_UUID
                        + " = ?";
            OleDbParameter[] dbParams = { CreateParameter(TestSignalLibraryBean._ID, signalUUID) };
            OleDbDataReader reader = ExecuteSqlQuery(sql, dbParams);
            if (reader != null)
            {
                while (reader.Read())
                {
                    dbTSFSignalSignal lb = new dbTSFSignalSignal();
                    lb.load(reader);
                }
                reader.Close();
                reader.Dispose();
            }
            return list;
        }

        public void saveTSFLibrary(dbTSFLibrary library)
        {
            if (library.id == null)
            {
                library.DataState = BASEBean.eDataState.DS_ADD;
                library.id = Guid.NewGuid();
            }
            library.save();
        }

        public int DeleteTSFLibrary( string uuid, string nameSpace )
        {
            int count;
            string sql = BuildDeleteSqlStatement(TestSignalBean._TABLE_NAME, new List<string>() { TestSignalBean._LIBRARY_UUID });
            OleDbParameter[] dbParams = { CreateParameter(TestSignalBean._LIBRARY_UUID, Guid.Parse( uuid )) };
            ExecuteSqlCommand(sql, dbParams, out count);
            DeleteMasterSignalsByNameSpace( nameSpace );
            return count;
        }

        public int DeleteMasterSignalsByNameSpace(string nameSpace)
        {
            int count;
            string sql = BuildDeleteSqlStatement( SignalMasterBean._TABLE_NAME, new List<string>() {SignalMasterBean._XMLNS} );
            OleDbParameter[] dbParams = { CreateParameter(SignalMasterBean._XMLNS, nameSpace) };
            ExecuteSqlCommand( sql, dbParams, out count );
            return count;
        }


        public List<dbSignalAttribute> FindAttributes( string name, double value)
        {
            return null;
        }



        public void ScoreInstruments(dbSignal signal)
        {
            //Search all the signal attributes where each attribute value 
            // falls within the range of the hi and lo values in the capabilities database
            //Store the instrument with the attribute
            //Group all the instruments with the attributes that are within scope
            //Score the instruments based on the number of attributes it has
            //100% == all attributes
            
        }
    }
}
