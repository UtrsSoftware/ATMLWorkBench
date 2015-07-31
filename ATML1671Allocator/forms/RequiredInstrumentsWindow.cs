/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
* 
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ATML1671Allocator.allocator;
using ATMLCommonLibrary.model;
using ATMLManagerLibrary.managers;
using ATMLModelLibrary.model.common;
using WeifenLuo.WinFormsUI.Docking;

namespace ATML1671Allocator.forms
{
    public partial class RequiredInstrumentsWindow : DockContent, IATMLDockableWindow
    {
        public RequiredInstrumentsWindow()
        {
            InitializeComponent();
            lvInstruments.Columns.Clear();
            lvInstruments.Columns.Add("Name");
            lvInstruments.Columns.Add("P/N");
            lvInstruments.Columns.Add("Description");
            ATMLAllocator.Instance.TestConfigurationLoaded+=InstanceOnTestConfigurationLoaded;
        }

        private void InstanceOnTestConfigurationLoaded( FileInfo fileInfo, byte[] content )
        {
            try
            {
                TestConfiguration15 testConfig = TestConfiguration15.Deserialize(new MemoryStream(content));
                if (testConfig != null)
                {
                    foreach (TestConfigurationTestEquipmentItem item in testConfig.TestEquipment)
                    {
                        foreach (ItemDescriptionReference itemRef in item.Instrumentation)
                        {
                            var itemDescription = itemRef.Item as ItemDescription;
                            var documentReference = itemRef.Item as DocumentReference;
                            if (itemDescription != null)
                                AddInstrument( itemDescription );
                            else if( documentReference!=null )
                                AddInstrument(documentReference);
                        }
                    }
                }
                lvInstruments.AutoResizeColumns( ColumnHeaderAutoResizeStyle.ColumnContent );
            }
            catch (Exception e)
            {
                LogManager.Error(e.Message);
            }
        }

        private void AddInstrument(ItemDescription itemDescription)
        {
            var itm = new ListViewItem(itemDescription.name);
            itm.SubItems.Add(itemDescription.Identification.ModelName);
            itm.SubItems.Add(itemDescription.Description);
            itm.Tag = itemDescription;
            lvInstruments.Items.Add(itm);
        }

        private void AddInstrument(DocumentReference documentReference)
        {
            var itm = new ListViewItem(documentReference.ID);
            itm.SubItems.Add(documentReference.uuid);
            itm.SubItems.Add(documentReference.DocumentType.ToString());
            lvInstruments.Items.Add(itm);
        }

        public void CloseProject()
        {
            lvInstruments.Items.Clear();   
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Control | Keys.F4))
            {
                Console.Beep();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

    }
}
