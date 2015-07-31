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
using System.Xml;
using ATMLDataAccessLibrary.db.beans;
using ATMLDataAccessLibrary.db.daos;
using ATMLUtilitiesLibrary;

namespace ATMLManagerLibrary.managers
{
    /**
     * The MessageManager provides access to all text messages stored in the help_message database table.
     * The MessageManager is created as a Singleton where only one instance is available for the entire application.
     * For performance reasons, all the messages are loaded into the CacheManager.
     * @author Paul Garrison
     * @date January 2014
     */
    public class MessageManager
    {

#region Message Keys

        public static String GENERIC_DELETE_PROMPT = "Generic.delete.prompt";
        public static String GENERIC_TITLE_VERIFICATION = "Generic.title.verification";
        public static String CAPABILITY_PORT_DELETE = "Capability.port.delete";
        public static String CACHEMANAGER_NOCACHEERROR = "CacheManager.noCacheError";
        public static String COMPONENT_ID = "Component.id";
        public static String CONNECTOR_ID = "Connector.id";
        public static String CONNECTOR_LOCATION = "Connector.location";
        public static String CONNECTOR_MATINGCONNECTORTYPE = "Connector.matingConnectorType";
        public static String CONNECTOR_PINCONFIGURATION = "Connector.pinConfiguration";
        public static String CONNECTOR_PINTYPE = "Connector.pinType";
#endregion


        private static volatile MessageManager instance;
        private MessageManager()
        {
            if( instance == null )
                instance = new MessageManager();
        }

        /**
         * Returns an instance of the MessageManager.
         */
        [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.Synchronized)]
        public static MessageManager getInstance()
        {
            if( instance == null )
                instance = new MessageManager();
            return instance;
        }

        /**
         * Returns the message store using the provided message key. If the key is not found then a message stating that fact will be returned.
         * @param messageKey - The key that the message was store with.
         * @return The message found
         */
        public static String getMessage(String messageKey)
        {
            String message = String.Format( "Message for message key \"{0}\" was not found!", messageKey );
            Cache messageCache = CacheManager.getCache("help_message");
            HelpMessageBean bean = (HelpMessageBean)messageCache.getItem(messageKey);
            if( bean != null )
                message = bean.message;
            return message;
        }


        public static int saveMessage(String messageKey, String newMessage)
        {
            int saveCode = 0;
            String message = String.Format("Message for message key \"{0}\" was not found!", messageKey);
            Cache messageCache = CacheManager.getCache("help_message");
            HelpMessageBean bean = (HelpMessageBean)messageCache.getItem(messageKey);
            if (bean != null)
            {
                if (bean.message == null || !bean.message.Equals(newMessage))
                {
                    bean.DataState = BASEBean.eDataState.DS_EDIT;
                    bean.message = message = newMessage;
                    bean.save();
                    saveCode = 1;
                }
            }
            else
            {
                bean = new HelpMessageBean();
                bean.DataState = BASEBean.eDataState.DS_ADD;
                bean.messageKey = messageKey;
                bean.message = newMessage;
                bean.IncludeKeyOnInsert = true;
                bean.save();
                messageCache.addCacheItem(messageKey, bean);
                saveCode = 2;
            }
            return saveCode;
        }


        public static void ExportMessages()
        {
            HelpDAO dao = new HelpDAO();
            List<HelpMessageBean> messages = dao.getHelpMessages();
            XmlDocument document = new XmlDocument();
            XmlElement root = document.CreateElement("messages");
            document.AppendChild(root);
            foreach (HelpMessageBean messageBean in messages)
            {
                XmlElement message = document.CreateElement("message");
                message.SetAttribute( "key", messageBean.messageKey );
                XmlText txt = document.CreateTextNode( messageBean.message );
                message.AppendChild( txt );
                root.AppendChild( message );
            }

            StringWriter sw = new StringWriter();
            XmlWriter writer = new UTRSXmlWriter( sw );
            document.WriteContentTo( writer );
            if( FileManager.WriteFile( Encoding.UTF8.GetBytes( sw.ToString() ), "help-messages.xml" ) )
                LogManager.Info( "Help Messages have been successfully exported." );
        }


        public static void ImportMessages()
        {
            bool successful = false;
            int count = 0;
            int messagesUpdated = 0;
            int messagesAdded = 0;
            var document = new XmlDocument();
            string data;
            if (FileManager.OpenXmlFile( out data ))
            {
                document.LoadXml( data );
                var root = document.DocumentElement;
                if (root != null)
                {
                    var messages = root.SelectNodes( "//message" );
                    if (messages != null)
                    {
                        foreach (XmlNode xmlNode in messages)
                        {
                            var element = xmlNode as XmlElement;
                            if (element != null)
                            {
                                string key = element.GetAttribute( "key" );
                                string message = element.InnerText;
                                int code = saveMessage( key, message );
                                if (code == 1) messagesUpdated++;
                                if (code == 2) messagesAdded++;
                                count++;
                                successful = true;
                            }
                        }
                    }
                }
            }
            if (successful)
            {
                LogManager.Info( "Successfully imported help messages. Updated:{0} Added:{1} Total Messages:{2}", messagesUpdated, messagesAdded, count );
            }

        }

    }

}
