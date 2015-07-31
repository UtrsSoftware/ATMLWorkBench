/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
* 
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Threading;

namespace ATMLUtilitiesLibrary
{
    //-----------------------------------------------------------------------------//
    //--- offered to the public domain for any use with no restriction          ---//
    //--- and also with no warranty of any kind, please enjoy. - David Jeske.   ---//
    //---                                                                       ---//
    //--- simple HTTP explanation                                               ---//
    //--- http://www.jmarshall.com/easy/http/                                   ---//
    // ----------------------------------------------------------------------------//
    public class HttpProcessor
    {
        private const int BUF_SIZE = 4096;
        private static int MAX_POST_SIZE = 10*1024*1024; // 10MB
        private string contextPath;
        public Hashtable httpHeaders = new Hashtable();
        public String http_method;
        public String http_protocol_versionstring;
        public String http_url;
        private Stream inputStream;
        public StreamWriter outputStream;

        private Dictionary<String, String> properties = new Dictionary<string, string>();
        public TcpClient socket;
        public HttpServer srv;
        public HttpProcessor( TcpClient s, HttpServer srv )
        {
            socket = s;
            this.srv = srv;
        }

        public Dictionary<String, String> Properties
        {
            get { return properties; }
            set { properties = value; }
        }

        public string ContextPath
        {
            get { return contextPath; }
            set { contextPath = value; }
        }

        public String GetProperty( String propertyName )
        {
            String value = null;
            if (properties.ContainsKey( propertyName ))
                value = properties[propertyName];
            return value;
        }

        private string streamReadLine( Stream inputStream )
        {
            int next_char;
            string data = "";
            while (true)
            {
                next_char = inputStream.ReadByte();
                if (next_char == '\n')
                {
                    break;
                }
                if (next_char == '\r')
                {
                    continue;
                }
                if (next_char == -1)
                {
                    Thread.Sleep( 1 );
                    continue;
                }
                ;
                data += Convert.ToChar( next_char );
            }
            return data;
        }


        public void process()
        {
            Console.WriteLine( "Processing Request..." );

            // we can't use a StreamReader for input, because it buffers up extra data on us inside it's
            // "processed" view of the world, and we want the data raw after the headers
            inputStream = new BufferedStream( socket.GetStream() );

            // we probably shouldn't be using a streamwriter for all output from handlers either
            outputStream = new StreamWriter( new BufferedStream( socket.GetStream() ) );
            try
            {
                parseRequest();
                readHeaders();
                if (http_method.Equals( "GET" ))
                {
                    handleGETRequest();
                }
                else if (http_method.Equals( "POST" ))
                {
                    handlePOSTRequest();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine( "Exception: " + e );
                writeFailure();
            }
            outputStream.Flush();
            // bs.Flush(); // flush any remaining output
            inputStream = null;
            outputStream = null; // bs = null;            
            socket.Close();
        }

        public void parseRequest()
        {
            String request = streamReadLine( inputStream );
            string[] tokens = request.Split( ' ' );
            if (tokens.Length != 3)
            {
                throw new Exception( "invalid http request line" );
            }
            http_method = tokens[0].ToUpper();
            http_url = tokens[1];
            http_protocol_versionstring = tokens[2];

            string[] parts = http_url.Split( '?' );
            contextPath = parts[0];
            if (parts.Length > 1)
            {
                string[] props = parts[1].Split( '&' );
                foreach (String propPair in props)
                {
                    string[] pair = propPair.Split( '=' );
                    String key = pair[0];
                    String value = null;
                    if (pair.Length > 1)
                        value = pair[1];
                    properties.Add( key, value );
                }
            }
            Console.WriteLine( "starting: " + request );
        }


        public void readHeaders()
        {
            Console.WriteLine( "readHeaders()" );
            String line;
            while (( line = streamReadLine( inputStream ) ) != null)
            {
                if (line.Equals( "" ))
                {
                    Console.WriteLine( "got headers" );
                    return;
                }

                int separator = line.IndexOf( ':' );
                if (separator == -1)
                {
                    throw new Exception( "invalid http header line: " + line );
                }
                String name = line.Substring( 0, separator );
                int pos = separator + 1;
                while (( pos < line.Length ) && ( line[pos] == ' ' ))
                {
                    pos++; // strip any spaces
                }

                string value = line.Substring( pos, line.Length - pos );
                Console.WriteLine( "header: {0}:{1}", name, value );
                httpHeaders[name] = value;
            }
        }

        public void handleGETRequest()
        {
            srv.handleGETRequest( this );
        }

        public void handlePOSTRequest()
        {
            // this post data processing just reads everything into a memory stream.
            // this is fine for smallish things, but for large stuff we should really
            // hand an input stream to the request processor. However, the input stream 
            // we hand him needs to let him see the "end of the stream" at this content 
            // length, because otherwise he won't know when he's seen it all! 

            Console.WriteLine( "get post data start" );
            int content_len = 0;
            var ms = new MemoryStream();
            if (httpHeaders.ContainsKey( "Content-Length" ))
            {
                content_len = Convert.ToInt32( httpHeaders["Content-Length"] );
                if (content_len > MAX_POST_SIZE)
                {
                    throw new Exception(
                        String.Format( "POST Content-Length({0}) too big for this simple server",
                                       content_len ) );
                }
                var buf = new byte[BUF_SIZE];
                int to_read = content_len;
                while (to_read > 0)
                {
                    Console.WriteLine( "starting Read, to_read={0}", to_read );

                    int numread = inputStream.Read( buf, 0, Math.Min( BUF_SIZE, to_read ) );
                    Console.WriteLine( "read finished, numread={0}", numread );
                    if (numread == 0)
                    {
                        if (to_read == 0)
                        {
                            break;
                        }
                        throw new Exception( "client disconnected during post" );
                    }
                    to_read -= numread;
                    ms.Write( buf, 0, numread );
                }
                ms.Seek( 0, SeekOrigin.Begin );
            }
            Console.WriteLine( "get post data end" );
            srv.handlePOSTRequest( this, new StreamReader( ms ) );
        }

        public void writeSuccess( string content_type = "text/html" )
        {
            outputStream.WriteLine( "HTTP/1.0 200 OK" );
            outputStream.WriteLine( "Content-Type: " + content_type );
            outputStream.WriteLine( "Connection: close" );
            outputStream.WriteLine( "" );
        }

        public void writeFailure()
        {
            outputStream.WriteLine( "HTTP/1.0 404 File not found" );
            outputStream.WriteLine( "Connection: close" );
            outputStream.WriteLine( "" );
        }
    }

    public abstract class HttpServer
    {
        public delegate void OnErrorDelegate( object sender, string message );

        public delegate void OnStartDelegate( object sender );

        public delegate void OnStopDelegate( object sender );

        private readonly string error;
        private readonly object parent;
        private bool is_active = true;
        private TcpListener listener;
        protected int port;
        public HttpServer( int port, object parent )
        {
            this.port = port;
            this.parent = parent;

            IPGlobalProperties ipGlobalProperties = IPGlobalProperties.GetIPGlobalProperties();
            IPEndPoint[] tcpConnInfoArray = ipGlobalProperties.GetActiveTcpListeners();

            foreach (IPEndPoint endpoint in tcpConnInfoArray)
            {
                if (endpoint.Port == port)
                {
                    error = "Port " + port + " is unavailable";
                    is_active = false;
                    break;
                }
            }
        }

        public bool IsActive
        {
            get { return is_active; }
        }

        public event OnStopDelegate OnStop;
        public event OnStartDelegate OnStart;
        public event OnErrorDelegate OnError;

        protected virtual void OnOnError( string message )
        {
            OnErrorDelegate handler = OnError;
            if (handler != null) handler( parent, message );
        }

        public void Stop()
        {
            if (listener != null)
                listener.Stop();
            is_active = false;
            OnStop( parent );
        }

        public void listen()
        {
            try
            {
                if (error != null)
                    throw new Exception( error );
                listener = new TcpListener( port );
                listener.Start();
                OnStart( parent );
                Console.WriteLine( "HTTP Server has started..." );
                while (is_active)
                {
                    TcpClient s = listener.AcceptTcpClient();
                    var processor = new HttpProcessor( s, this );
                    var thread = new Thread( processor.process );
                    thread.Start();
                    Thread.Sleep( 1 );
                }
            }
            catch (Exception e)
            {
                if (!e.Message.Contains( "WSACancelBlockingCall" ))
                {
                    Console.WriteLine( e.Message );
                    OnOnError( e.Message );
                }
            }
            Console.WriteLine( "HTTP Server has stopped..." );
        }

        public abstract void handleGETRequest( HttpProcessor p );
        public abstract void handlePOSTRequest( HttpProcessor p, StreamReader inputData );
    }

    public class MyHttpServer : HttpServer
    {
        public MyHttpServer( int port, object parent )
            : base( port, parent )
        {
        }
        public override void handleGETRequest( HttpProcessor p )
        {
            string contextPath = p.ContextPath;
            Dictionary<String, String> properties = p.Properties;

            if (p.http_url.Equals( "/Test.png" ))
            {
                Stream fs = File.Open( "../../Test.png", FileMode.Open );

                p.writeSuccess( "image/png" );
                fs.CopyTo( p.outputStream.BaseStream );
                p.outputStream.BaseStream.Flush();
            }

            Console.WriteLine( "request: {0}", p.http_url );
            p.writeSuccess();
            p.outputStream.WriteLine( "<html><body><h1>test server</h1>" );
            p.outputStream.WriteLine( "Current Time: " + DateTime.Now );
            p.outputStream.WriteLine( "url : {0}", p.http_url );

            p.outputStream.WriteLine( "<form method=post action=/form>" );
            p.outputStream.WriteLine( "<input type=text name=foo value=foovalue>" );
            p.outputStream.WriteLine( "<input type=submit name=bar value=barvalue>" );
            p.outputStream.WriteLine( "</form>" );
        }

        public override void handlePOSTRequest( HttpProcessor p, StreamReader inputData )
        {
            Console.WriteLine( "POST request: {0}", p.http_url );
            string data = inputData.ReadToEnd();

            p.writeSuccess();
            p.outputStream.WriteLine( "<html><body><h1>test server</h1>" );
            p.outputStream.WriteLine( "<a href=/test>return</a><p>" );
            p.outputStream.WriteLine( "postbody: <pre>{0}</pre>", data );
        }
    }

    public class TestMain
    {
        public static int Main( String[] args )
        {
            HttpServer httpServer;
            if (args.GetLength( 0 ) > 0)
            {
                httpServer = new MyHttpServer( Convert.ToInt16( args[0] ), null );
            }
            else
            {
                httpServer = new MyHttpServer( 8080, null );
            }
            var thread = new Thread( httpServer.listen );
            thread.Start();
            return 0;
        }
    }
}