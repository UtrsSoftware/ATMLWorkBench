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
using System.Text;
using ATMLDataAccessLibrary.db.daos;
using ATMLDataAccessLibrary.managers;
using ATMLDataAccessLibrary.model;
using ATMLManagerLibrary.managers;
using ATMLModelLibrary.model.common;
using ATMLUtilitiesLibrary;

namespace ATMLWorkBench.servers
{
    public class DocumentServer : HttpServer
    {
        public DocumentServer( int port, object parent )
            : base( port, parent )
        {
        }

        public override void handleGETRequest( HttpProcessor p )
        {
            try
            {
                string contextPath = p.ContextPath;
                if ("/document".Equals( contextPath ))
                {
                    processDocument( p );
                }
                else if (contextPath.StartsWith( "/tsf" ))
                {
                    processTSF( p );
                }
                else
                {
                    Dictionary<String, String> properties = p.Properties;
                    p.writeSuccess();
                    p.outputStream.WriteLine( "<html><body><h1>Test Document Server (GET)</h1>" );
                    p.outputStream.WriteLine( "Current Time: " + DateTime.Now );
                    p.outputStream.WriteLine( "url : {0}", p.http_url );
                    p.outputStream.WriteLine( "context: {0}", contextPath );
                    p.outputStream.WriteLine( "<table>" );
                    foreach (string key in properties.Keys)
                    {
                        p.outputStream.WriteLine( "\t<tr>" );
                        p.outputStream.Write( "\t\t<td>" );
                        p.outputStream.Write( properties[key] );
                        p.outputStream.Write( "\t\t</td>" );
                        p.outputStream.WriteLine( "\t<;tr>" );
                    }
                    p.outputStream.WriteLine( "</table>" );
                }
            }
            catch (Exception e)
            {
                //p.writeFailure();
                p.outputStream.WriteLine( "<html><body style=\"color:red\"><h1>Error</h1><p>" );
                p.outputStream.WriteLine( e.Message );
                p.outputStream.WriteLine( "</p></body></html>" );
            }
        }

        private void processTSF( HttpProcessor p )
        {
            string url = p.http_url;
            //Strip off /tsf/
            url = url.Substring( 5 );
            string[] parts = url.Split( '/' );
            if (parts.Length != 2)
                throw new Exception( "Invalid URL" );
            string name = parts[0];
            string version = parts[1];

            SignalDAO dao = DataManager.getSignalDAO();
            dbTSFLibrary lb = dao.getTSFLibraryByName( name );
            if (lb == null || lb.content == null)
                throw new Exception( string.Format( "Signal Model Library \"{0}\" was not found.", name ) );
            p.httpHeaders.Add( "Content-Type", "text/xml" );
            p.httpHeaders.Add( "Content-Disposition", "inline; filename=" + name + ".xml" );
            var writer = new BinaryWriter( p.outputStream.BaseStream, Encoding.UTF8 );
            writer.Write( Encoding.UTF8.GetBytes( lb.content ) );
        }

        private void processDocument( HttpProcessor p )
        {
            const string key = "uuid";
            const string name = "name";
            Document document;
            string uuid = "";
            string fileName = "";
            Dictionary<String, String> properties = p.Properties;
            if (!properties.ContainsKey( key ) && !properties.ContainsKey( name ))
                throw new Exception( "Missing uuid or name" );
            if (properties.ContainsKey( key ))
                uuid = properties[key];
            if (properties.ContainsKey( name ))
                fileName = properties[name];
            if (!string.IsNullOrWhiteSpace( uuid ))
                document = DocumentManager.GetDocument( uuid );
            else
                document = DocumentManager.GetDocumentByName( fileName );

            if (document == null)
                throw new Exception( String.Format( "Document \"{0}\" was not found.", uuid ) );
            p.httpHeaders.Add( "Content-Type", document.ContentType );
            p.httpHeaders.Add( "Content-Disposition", "Attachment; filename=" + document.name );
            var writer = new BinaryWriter( p.outputStream.BaseStream, Encoding.UTF8 );
            writer.Write( document.DocumentContent );
        }

        public override void handlePOSTRequest( HttpProcessor p, StreamReader inputData )
        {
            throw new NotImplementedException();
        }
    }
}