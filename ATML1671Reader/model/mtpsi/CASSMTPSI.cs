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
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using ATMLModelLibrary.model.uut;
using ATMLModelLibrary.model.common;
using ATMLModelLibrary.model;

namespace ATML1671Reader.model.mtpsi
{
    [XmlRoot("CASS_MTPSI", Namespace = "urn:MyNamespace")]
    public class CASSMTPSI : CASS_MTPSI, IInputFile
    {
        public CASSMTPSI()
        {
        }

        public CASSMTPSI( String content )
        {
            MemoryStream memory = new MemoryStream(System.Text.Encoding.UTF8.GetBytes(content));
            XmlSerializer SerializerObj = new XmlSerializer(typeof(CASSMTPSI));
            CASSMTPSI tpsi = (CASSMTPSI)SerializerObj.Deserialize(memory);
        }

        public String toATML()
        {
            StringWriter tw = new StringWriter();
            TestConfiguration testConfig = new TestConfiguration();
            ManufacturerData configManager = testConfig.ConfigurationManager;
            List<CASS_MTPSICASS_MTPSI_page> pages = this.CASS_MTPSI_page;
            foreach( CASS_MTPSICASS_MTPSI_page page in pages )
            {
                CASS_MTPSICASS_MTPSI_pageUUT uut = page.UUT;
                String partNo = uut.UUT_ID.Part_Number;
                //UUTInstance item = new UUTInstance();
                UUTDescription item = new UUTDescription();
                item.Item.name = uut.UUT_ID.Part_Number;
                //Lookup UUT Information
                ItemDescriptionReference reference = new ItemDescriptionReference();
                DocumentReference docRef = new DocumentReference();
                docRef.ID = uut.UUT_ID.Part_Number;
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
                    //testEquipment.Instrumentation.Add( refEquip );
                }

                //testConfig.TestEquipment.Add(testEquipment);

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

        public void fromATML(String atmlDocument)
        {

        }

    }


}

