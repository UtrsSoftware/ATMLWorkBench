/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
* 
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using ATMLDataAccessLibrary.db.beans;

namespace ATMLDataAccessLibrary.db.daos
{
    public class DocumentTypeLibraryDAO : DAO
    {
        public void SaveDocumentTypeLibrary(DocumentTypeLibraryBean bean)
        {
            if( bean.ID == null )
                bean.DataState = BASEBean.eDataState.DS_ADD;
            bean.save();
        }

        public DocumentTypeLibraryBean FindTypeBySignature(byte[] signature)
        {
            string sql = builSelectSQLStatement(DocumentTypeLibraryBean._TABLE_NAME, 
                                                new[] { BASEBean._ALL },
                                                new[] { DocumentTypeLibraryBean._SIGNATURE});
            OleDbParameter[] parameters = { new OleDbParameter(DocumentTypeLibraryBean._SIGNATURE, signature) };
            return CreateBean<DocumentTypeLibraryBean>(sql, parameters);
        }

        public DocumentTypeLibraryBean FindTypeByASCII(string ascii)
        {
            string sql = builSelectSQLStatement(DocumentTypeLibraryBean._TABLE_NAME,
                                                new[] { BASEBean._ALL },
                                                new[] { DocumentTypeLibraryBean._ASCII });
            OleDbParameter[] parameters = { new OleDbParameter(DocumentTypeLibraryBean._ASCII, ascii) };
            return CreateBean<DocumentTypeLibraryBean>(sql, parameters);
        }

        public DocumentTypeLibraryBean FindTypeByID(int id)
        {
            string sql = builSelectSQLStatement(DocumentTypeLibraryBean._TABLE_NAME,
                                                new[] { BASEBean._ALL },
                                                new[] { DocumentTypeLibraryBean._ID });
            OleDbParameter[] parameters = { new OleDbParameter(DocumentTypeLibraryBean._ID, id) };
            return CreateBean<DocumentTypeLibraryBean>(sql, parameters);
        }
    
    }
}
