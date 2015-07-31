/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
* 
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

using System;
using System.IO;
using System.Windows.Forms;
using ATML1671Allocator.allocator;
using ATMLCommonLibrary.model;
using ATMLManagerLibrary.managers;
using ATMLModelLibrary.model.common;
using WeifenLuo.WinFormsUI.Docking;

namespace ATML1671Allocator.forms
{
    public partial class RequiredAdaptersWindow : DockContent, IATMLDockableWindow
    {
        public RequiredAdaptersWindow()
        {
            InitializeComponent();
            ATMLAllocator.Instance.TestConfigurationLoaded += Instance_TestConfigurationLoaded;
            lvAdapters.Columns.Clear();
            lvAdapters.Columns.Add( "Name" );
            lvAdapters.Columns.Add( "P/N" );
            lvAdapters.Columns.Add( "Description" );
        }

        public void CloseProject()
        {
            lvAdapters.Items.Clear();
        }

        private void Instance_TestConfigurationLoaded( FileInfo fileInfo, byte[] content )
        {
            try
            {
                TestConfiguration15 testConfig = TestConfiguration15.Deserialize( new MemoryStream( content ) );
                if (testConfig != null)
                {
                    foreach (object element in testConfig.TestProgramElements)
                    {
                        var hardwareReference = element as ConfigurationResourceReference;
                        if (hardwareReference != null)
                        {
                            var itemDesc = hardwareReference.Item as ItemDescription;
                            var itemRef = hardwareReference.Item as DocumentReference;
                            if (itemRef != null)
                            {
                                AddTestAdapter( itemRef );
                            }
                            else if (itemDesc != null)
                            {
                                AddTestAdapter( itemDesc );
                            }
                        }
                    }
                }
                lvAdapters.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            }
            catch (Exception e)
            {
                LogManager.Error( e.Message );
            }
        }

        private void AddTestAdapter( ItemDescription itemDescription )
        {
            var itm = new ListViewItem( itemDescription.name );
            itm.SubItems.Add( itemDescription.Identification.ModelName );
            itm.SubItems.Add( itemDescription.Description );
            itm.Tag = itemDescription;
            lvAdapters.Items.Add( itm );
        }

        private void AddTestAdapter( DocumentReference documentReference )
        {
            var itm = new ListViewItem( documentReference.ID );
            itm.SubItems.Add( documentReference.uuid );
            itm.SubItems.Add( documentReference.DocumentType.ToString() );
            lvAdapters.Items.Add( itm );
        }

        protected override bool ProcessCmdKey( ref Message msg, Keys keyData )
        {
            if (keyData == ( Keys.Control | Keys.F4 ))
            {
                Console.Beep();
                return true;
            }
            return base.ProcessCmdKey( ref msg, keyData );
        }
    }
}