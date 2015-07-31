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
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using ATMLCommonLibrary.controls.awb;
using ATMLCommonLibrary.managers;
using ATMLCommonLibrary.model;
using ATMLCommonLibrary.model.navigator;
using ATMLDataAccessLibrary.db.daos;
using ATMLManagerLibrary.managers;
using ATMLModelLibrary.model;
using ATMLModelLibrary.model.common;
using ATMLProject.managers;
using ATMLUtilitiesLibrary;
using WeifenLuo.WinFormsUI.Docking;

namespace ATML1671Allocator.forms
{
    public partial class ATMLAllocatorToolWindow : DockContent, IATMLDockableWindow
    {
        private AvailableTestStationsWindow availableTestStations = null;
        //private AvailableTestAdaptersWindow availableTestAdapters = null;
        private AvailableInstrumentsWindow availableInstruments = null;
        private RequiredSignalsWindow requiredSignals = null;
        private RequiredInstrumentsWindow requiredInstruments = null;
        private RequiredAdaptersWindow requiredAdapters = null;

        public ATMLAllocatorToolWindow(DockPanel dockPanel)
        {
            InitializeComponent();
            this.DockPanel = dockPanel;
        }

        public void InitWindows( DockPane navigatorPane, DockPane outputPane )
        {
            availableTestStations = new AvailableTestStationsWindow();
            availableTestStations.Show(DockPanel, DockState.DockRight);
            availableTestStations.Hide();

            //availableTestAdapters = new AvailableTestAdaptersWindow();
            //availableTestAdapters.Show(navigatorPane, DockAlignment.Bottom, .60);
            //availableTestAdapters.Hide();

            availableInstruments = new AvailableInstrumentsWindow();
            availableInstruments.Show(navigatorPane, DockAlignment.Bottom, .50);
            availableInstruments.Hide();

            requiredSignals = new RequiredSignalsWindow();
            requiredSignals.Show(outputPane, DockAlignment.Right, .50 );
            requiredSignals.Hide();
            requiredSignals.SignalRequirementSelected += new ATMLManagerLibrary.delegates.ItemSelectionDeligate<ATMLModelLibrary.model.SignalRequirementsSignalRequirement>(requiredSignals_SignalRequirementSelected);

            requiredInstruments = new RequiredInstrumentsWindow();
            requiredInstruments.Show( requiredSignals.Pane, DockAlignment.Bottom, 0 );
            requiredInstruments.DockTo(requiredSignals.Pane, DockStyle.Fill, 0 );
            requiredInstruments.Hide();

            requiredAdapters = new RequiredAdaptersWindow();
            requiredAdapters.Show(requiredSignals.Pane, DockAlignment.Bottom, 0);
            requiredAdapters.DockTo(requiredSignals.Pane, DockStyle.Fill, 0);
            requiredAdapters.Hide();
        
        }

        void requiredSignals_SignalRequirementSelected(SignalRequirementsSignalRequirement signalRequirement, EventArgs args)
        {
            availableInstruments.ProcessSignal( signalRequirement );
            availableTestStations.ProcessSignal(signalRequirement);
        }

        public void CloseProject()
        {
            allocatorFrameControl.CloseProject();
            availableInstruments.CloseProject();
            //availableTestAdapters.CloseProject();
            availableTestStations.CloseProject();
            requiredAdapters.CloseProject();
            requiredInstruments.CloseProject();
            requiredSignals.CloseProject();
        }

        private void ATMLAllocatorToolWindow_Activated(object sender, System.EventArgs e)
        {
            if (availableTestStations.DockState != DockState.Float)
                availableTestStations.Show();
            //if (availableTestStations.DockState != DockState.Float)
            //    availableTestAdapters.Show();
            if (availableInstruments.DockState != DockState.Float)
                availableInstruments.Show();
            if (requiredSignals.DockState != DockState.Float)
                requiredSignals.Show();
            if (requiredInstruments.DockState != DockState.Float)
                requiredInstruments.Show();
            if (requiredAdapters.DockState != DockState.Float)
                requiredAdapters.Show();
        }

        private void ATMLAllocatorToolWindow_Deactivate(object sender, System.EventArgs e)
        {
            if (availableTestStations.DockState != DockState.Float)
                availableTestStations.Hide();
            //if (availableTestStations.DockState != DockState.Float)
            //    availableTestAdapters.Hide();
            if (availableInstruments.DockState != DockState.Float)
                availableInstruments.Hide();
            if (requiredSignals.DockState != DockState.Float)
                requiredSignals.Hide();
            if (requiredInstruments.DockState != DockState.Float)
                requiredInstruments.Hide();
            if (requiredAdapters.DockState != DockState.Float)
                requiredAdapters.Hide();

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

        private void allocatorFrameControl_Load(object sender, EventArgs e)
        {

        }
    }
}
