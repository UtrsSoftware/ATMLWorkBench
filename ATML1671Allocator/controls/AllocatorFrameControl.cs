/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
* 
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using ATML1671Allocator.allocator;
using ATML1671Allocator.Properties;
using ATMLCommonLibrary.forms;
using ATMLCommonLibrary.model.navigator;
using ATMLCommonLibrary.utils;
using ATMLDataAccessLibrary.db.daos;
using ATMLManagerLibrary.managers;
using ATMLModelLibrary.model;
using ATMLModelLibrary.model.common;
using ATMLModelLibrary.model.signal;
using ATMLModelLibrary.model.signal.analysis;
using ATMLProject.managers;
using ATMLUtilitiesLibrary;

namespace ATML1671Allocator.controls
{
    public partial class AllocatorFrameControl : UserControl
    {
        private FileSystemWatcher _fileSystemWatcher;

        public AllocatorFrameControl()
        {
            InitializeComponent();
            edtTestDescription.InitForXML();
            edtTestDescription.SourceDocumentLoaded += edtTestDescription_SourceDocumentLoaded;
            edtTestDescription.XmlDocumentLoaded += edtTestDescription_XmlDocumentLoaded;
            btnFind.Visible = false;
            btnCollapseAll.Visible = false;
            btnExpandAll.Visible = false;
            btnWordWrap.Visible = false;
            ATMLNavigator.Instance.SelectATMLTestDescriptionDocument += _navigator_SelectATMLTestDescriptionDocument;
            ATMLAllocator.Instance.TestDescriptionLoaded += InstanceTestDescriptionLoaded;
            ProjectManager.Instance.ProjectOpened+=InstanceOnProjectOpened;
        }

        private void edtTestDescription_SourceDocumentLoaded( object sender, EventArgs e )
        {
            
        }

        private void InstanceOnProjectOpened(string testProgramSetName)
        {
            _fileSystemWatcher = new FileSystemWatcher(ATMLContext.ProjectAtmlPath);
            _fileSystemWatcher.Filter = "*.*" + ATMLContext.ATML_TEST_DESC_FILENAME_SUFFIX;
            _fileSystemWatcher.NotifyFilter = NotifyFilters.FileName | NotifyFilters.CreationTime | NotifyFilters.LastWrite;
            _fileSystemWatcher.Created += FileSystemWatcherOnCreated;
            _fileSystemWatcher.Changed += FileSystemWatcherOnChanged;
            _fileSystemWatcher.Deleted += FileSystemWatcherOnDeleted;
            _fileSystemWatcher.EnableRaisingEvents = true;
        }

        private void FileSystemWatcherOnDeleted(object sender, FileSystemEventArgs fileSystemEventArgs)
        {
            edtTestDescription.Text = "";
            lblTestDescriptionTitle.Text = Resources.Test_Description;
        }

        private void FileSystemWatcherOnChanged(object sender, FileSystemEventArgs fileSystemEventArgs)
        {
            LoadTestDescriptionDocument( new FileInfo( fileSystemEventArgs.FullPath ) );
        }

        private void FileSystemWatcherOnCreated(object sender, FileSystemEventArgs fileSystemEventArgs)
        {
            LoadTestDescriptionDocument(new FileInfo(fileSystemEventArgs.FullPath));
        }

        private void InstanceTestDescriptionLoaded( FileInfo fileInfo, byte[] content )
        {
            LoadTestDescriptionDocument( fileInfo );
        }


        private void edtTestDescription_XmlDocumentLoaded()
        {
            edtTestDescription.InitForXML();
        }


        private void _navigator_SelectATMLTestDescriptionDocument( object sender, FileInfo fileInfo )
        {
            LoadTestDescriptionDocument( fileInfo );
        }

        private void LoadTestDescriptionDocument( FileInfo fileInfo )
        {
            edtTestDescription.Text = File.ReadAllText( fileInfo.FullName );
            ATMLAllocator.Instance.LoadXML( edtTestDescription.Text );
            lblTestDescriptionTitle.Text = string.Format( "{0} [{1}]", Resources.Test_Description, fileInfo.Name );
            btnAnalyze.Visible = true;
            btnFind.Visible = true;
            btnCollapseAll.Visible = true;
            btnExpandAll.Visible = true;
            btnWordWrap.Visible = true;
        }

        private string openTestDescription()
        {
            String content = null;
            var ofp = new OpenFileDialog();
            if (DialogResult.OK == ofp.ShowDialog())
            {
                //lblInputDocument.Text = ofp.FileName;
                var sr = new StreamReader( ofp.OpenFile() );
                content = sr.ReadToEnd();
            }
            return content;
        }

        public void CloseProject()
        {
            edtTestDescription.Text = "";
            lblTestDescriptionTitle.Text = Resources.Test_Description;
            btnAnalyze.Visible = false;
            btnFind.Visible = false;
            btnCollapseAll.Visible = false;
            btnExpandAll.Visible = false;
            btnWordWrap.Visible = false;
            _fileSystemWatcher = null;
        }

        private void btnOpenTestDescription_Click( object sender, EventArgs e )
        {
            String content = openTestDescription();
            edtTestDescription.Text = content;

            /*

            XmlReader reader =  XmlReader.Create(new StringReader(content));
            XmlSerializer serializerObj = new XmlSerializer(typeof(TestDescription));
            TestDescription testDescription = (TestDescription)serializerObj.Deserialize(reader);
            lvRequiredSignals.Items.Clear();

            foreach( SignalRequirementsSignalRequirement sigReq in testDescription.SignalRequirements )
            {
                ListViewItem itm = new ListViewItem(sigReq.TsfClassAttribute.ToString() );
                lvRequiredSignals.Items.Add(itm);
            }

            DetailedTestInformation detail = testDescription.DetailedTestInformation;
            foreach( ActionType action in detail.Actions )
            {
                ActionTypeBehavior behavior = action.Behavior;
                if( behavior.Item.GetType() == typeof(IeeeStd1641) )
                {
                    IeeeStd1641 sig = (IeeeStd1641)behavior.Item;
                    if( sig.Any != null )
                    {
                        XmlDocument signal = new XmlDocument();
                        signal.LoadXml(sig.Any.InnerXml);
                        if( signal.Name == "Signal" )
                        {
                            ListViewItem itm = new ListViewItem(signal.InnerXml);
                            lvRequiredSignals.Items.Add(itm);
                        }
                    }
                    foreach( IeeeStd1641GlobalSignalOperation go in sig.GlobalSignalOperations )
                    {
                        if( go.Item.GetType() == typeof(IeeeStd1641GlobalSignalOperationDefine) )
                        {
                            IeeeStd1641GlobalSignalOperationDefine define = (IeeeStd1641GlobalSignalOperationDefine)go.Item;
                            ListViewItem itm = new ListViewItem(define.signalName);
                            lvRequiredSignals.Items.Add(itm);
                        }
                    }
                }

            }
             * 
             * 
             * 				<tsf:AC_SIGNAL name="VIN1" ac_ampl="4.0mV" freq="1.0kHz"/>
                            <std:TwoWire name="Conn10" hi="J1-1" lo="J1-2" In="VIN1"/>
                            <!--Measure Amplitude of AC_SIGNAL at J1-3, J1-4-->
                            <std:TwoWire name="Conn17" hi="J1-3" lo="J1-4"/>
                            <tsf:DC_SIGNAL name="V_O3" ac_ampl="range 0mV to 100mV errlmt +- 0.1mV" freq="1000Hz"/>
                            <std:Measure name="Meas4" As="V_O3" attribute="ac_ampl" In="Conn17"/>

             */
        }

        private void addSignal( String name, String attributes )
        {
            var itm = new ListViewItem( name );
            itm.SubItems.Add( attributes );
        }


        private void lvTestEquipment_ItemChecked( object sender, ItemCheckedEventArgs e )
        {
        }

        private void btnOpenTestConfiguration_Click( object sender, EventArgs e )
        {
            String content = openTestDescription();
        }

        private void menu_VisibleChanged( object sender, EventArgs e )
        {
        }

        private void menu_Enter( object sender, EventArgs e )
        {
        }

        private void btnOpenTestDescription_Click_1( object sender, EventArgs e )
        {
        }

        private void btnFind_Click( object sender, EventArgs e )
        {
            edtTestDescription.Find();
        }

        private void btnCollapseAll_Click( object sender, EventArgs e )
        {
            edtTestDescription.CollapseAll();
        }

        private void btnExpandAll_Click( object sender, EventArgs e )
        {
            edtTestDescription.ExpandAll();
        }

        private void btnWordWrap_Click( object sender, EventArgs e )
        {
            edtTestDescription.ToggleWordWrap();
            btnWordWrap.Checked = edtTestDescription.IsWordWrap;
            if (btnWordWrap.Checked)
                btnWordWrap.BackColor = Color.AliceBlue;
            else
                btnWordWrap.BackColor = Color.Transparent;
        }

        private void btnAnalyze_Click( object sender, EventArgs e )
        {
            HourGlass.Start();
            try{ATMLAllocator.Instance.AnalyzeRequiredSignals(edtTestDescription.Text);}
                finally{HourGlass.Stop();}
            
        }
    }
}