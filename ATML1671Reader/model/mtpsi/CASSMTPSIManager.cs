/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
* 
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

using System;
using System.Xml;
using System.Xml.Serialization;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using ATML1671Reader.forms;
using ATMLModelLibrary.model;
using ATMLCommonLibrary.model.mtpsi;
using ATMLModelLibrary.model.common;
using ATMLModelLibrary.model.uut;

namespace ATML1671Reader.model.mtpsi
{
    public class CASSMTPSIManager
    {

        public static String toATML(CASS_MTPSI tpsi)
        {
            StringWriter tw = new StringWriter();
            TestConfiguration testConfig = new TestConfiguration();

            ManufacturerData configManager = testConfig.ConfigurationManager;
            List<CASS_MTPSICASS_MTPSI_page> pages = tpsi.CASS_MTPSI_page;
            foreach( CASS_MTPSICASS_MTPSI_page page in pages )
            {
                CASS_MTPSICASS_MTPSI_pageUUT uut = page.UUT;
                String partNo = uut.UUT_ID.Part_Number;
                //UUTInstance instance = new UUTInstance();
                UUTDescription item = new UUTDescription();
                //item.Item.name = uut.UUT_ID.Part_Number;

                //Lookup UUT Information
                ItemDescriptionReference reference = new ItemDescriptionReference();
                DocumentReference docRef = new DocumentReference();
                //docRef.ID = uut.UUT_ID.Part_Number;
                docRef.uuid = "{SOMEUUIDHERE}";

                reference.Item = docRef;// item.Item;
                //testConfig.TestedUUTs.Add(reference);

                TestConfigurationTestEquipmentItem testEquipment = new TestConfigurationTestEquipmentItem();

                foreach( CASS_MTPSICASS_MTPSI_pageATE_assets asset in page.ATE_assets )
                {
                    ItemDescriptionReference refEquip = new ItemDescriptionReference();
                    ItemDescription instrument = new ItemDescription();
                    instrument.name = asset.Asset_Identifier;
                    refEquip.Item = instrument;
                    //testEquipment.Instrumentation.Add(refEquip);
                }

               // testConfig.TestEquipment.Add(testEquipment);

                try
                {
                    XmlSerializer serializerObj = new XmlSerializer(typeof(TestConfiguration));
                    serializerObj.Serialize(tw, testConfig);
                }
                catch( Exception e )
                {
                    Exception ie = e.InnerException;
                    while( ie != null )
                    {
                        Trace.WriteLine(ie.Message);
                        ie = ie.InnerException;
                    }
                }
                break;
            }
            return tw.ToString();
        }

        public static TestConfiguration fromATML(String atmlDocument)
        {
            XmlReader reader =  XmlReader.Create(new StringReader(atmlDocument));
            XmlSerializer serializerObj = new XmlSerializer(typeof(TestConfiguration));
            TestConfiguration testConfiguration = (TestConfiguration)serializerObj.Deserialize(reader);
            return testConfiguration;
        }



    }
}
