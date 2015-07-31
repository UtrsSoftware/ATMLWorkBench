/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
* 
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

using System;
using System.ComponentModel;
using System.IO;
using System.Text;
using System.Windows.Forms;
using ATML1671Reader.controls;
using ATML1671Reader.reader;
using ATMLCommonLibrary.model;
using ATMLManagerLibrary.delegates;
using ATMLManagerLibrary.interfaces;
using ATMLManagerLibrary.managers;
using ATMLModelLibrary.interfaces;
using ATMLModelLibrary.model;
using ATMLModelLibrary.model.common;
using WeifenLuo.WinFormsUI.Docking;

namespace ATML1671Reader.forms
{
    public partial class TestConfigurationForm : DockContent, IATMLDockableWindow, ITestConfigurationChangeListener,
        IATMLReaderConsumer, IAtmlActionable
    {
        #region Events

        public event AtmlActionDeligate<IAtmlObject> AtmlObjectAction;
        public event TestConfigurationSaveHandler TestConfigurationSaved;

        protected virtual IAtmlObject OnAtmlObjectAction(IAtmlObject obj, AtmlActionType actiontype, EventArgs args)
        {
            AtmlActionDeligate<IAtmlObject> handler = AtmlObjectAction;
            if (handler != null)
                obj = handler(obj, actiontype, args);
            return obj;
        }

        protected virtual void OnTestConfigurationSaved(TestConfiguration15 testconfiguration)
        {
            TestConfigurationSaveHandler handler = TestConfigurationSaved;
            if (handler != null) handler(testconfiguration);
        }

        #endregion

        public TestConfigurationForm()
        {
            InitializeComponent();
            testConfigurationControl1.AddChangeListener(this);
            testConfigurationControl1.TestConfigurationSaved += testConfigurationControl1_TestConfigurationSaved;
            testConfigurationControl1.AtmlObjectAction += testConfigurationControl1_ProjectUutChanged;
            testConfigurationControl1.Parent = this;
            testConfigurationControl1.Enabled = false;
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public TestConfiguration15 TestConfiguration
        {
            get { return testConfigurationControl1.TestConfiguration; }
            set { testConfigurationControl1.TestConfiguration = value; }
        }

        public void CloseProject()
        {
            testConfigurationControl1.CloseProject();
        }

        public void RegisterATMLReader(ATMLReader reader)
        {
            reader.InputDocumentTranslated += LoadTestConfiguration;
            reader.AtmlFileOpened += LoadTestConfiguration;
            reader.AtmlDocumentOpened += LoadTestConfiguration;
            reader.ProjectOpened += reader_ProjectOpened;
        }

        public void OnTestConfigurationChange()
        {
            LogManager.SourceTrace(ATMLReader.SOURCE, "Test Configuration Changed");
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

        private IAtmlObject testConfigurationControl1_ProjectUutChanged(IAtmlObject uutDescription,
            AtmlActionType actionType, EventArgs args)
        {
            OnAtmlObjectAction(uutDescription, actionType, args);
            return uutDescription;
        }

        private void testConfigurationControl1_TestConfigurationSaved(TestConfiguration15 testConfiguration)
        {
            OnAtmlObjectAction(testConfiguration, AtmlActionType.Edit, EventArgs.Empty);
            OnTestConfigurationSaved(testConfiguration);
        }

        private void reader_ProjectOpened(string testProgramSetName)
        {
            testConfigurationControl1.Enabled = true;
        }

        public void LoadTestConfiguration(TestConfiguration15 testConfiguration)
        {
            testConfigurationControl1.TestConfiguration = testConfiguration;
        }

        public void LoadTestConfiguration(Document document)
        {
            if (document != null)
                testConfigurationControl1.TestConfiguration =
                    TestConfiguration15.Deserialize(Encoding.UTF8.GetString(document.DocumentContent));
        }

        public void LoadTestConfiguration(FileInfo fi, byte[] content)
        {
            try
            {
                if (content != null && content.Length > 0)
                {
                    string text = Encoding.UTF8.GetString(content);
                    string byteOrderMarkUtf8 = Encoding.UTF8.GetString(Encoding.UTF8.GetPreamble());
                    if (text.StartsWith(byteOrderMarkUtf8))
                        text = text.Remove(0, byteOrderMarkUtf8.Length);
                    testConfigurationControl1.TestConfiguration =
                        TestConfiguration15.Deserialize(text);
                }
            }
            catch (Exception e)
            {
                LogManager.SourceError(ATMLReader.SOURCE, e,
                                 "Failed to parse the Test Configuration File. Please make sure it is in the correct format.");
            }
        }

        private void testConfigurationControl1_Load(object sender, EventArgs e)
        {

        }
    }
}