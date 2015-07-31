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
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ATML1671Allocator.allocator;
using ATMLCommonLibrary.model;
using ATMLDataAccessLibrary.db.daos;
using ATMLManagerLibrary.delegates;
using ATMLManagerLibrary.managers;
using ATMLModelLibrary.model;
using ATMLModelLibrary.model.common;
using WeifenLuo.WinFormsUI.Docking;

namespace ATML1671Allocator.forms
{
    public partial class RequiredSignalsWindow : DockContent, IATMLDockableWindow
    {
        public event ItemSelectionDeligate<SignalRequirementsSignalRequirement> SignalRequirementSelected;
        public event ItemSelectionDeligate<SignalRequirementsSignalRequirement> LocalSignalSelected;

        protected virtual void OnSignalRequirementSelected( SignalRequirementsSignalRequirement obj )
        {
            ItemSelectionDeligate<SignalRequirementsSignalRequirement> handler = SignalRequirementSelected;
            if (handler != null) handler( obj, EventArgs.Empty );
        }

        public RequiredSignalsWindow()
        {
            InitializeComponent();
            lvSignals.FullRowSelect = true;
            lvSignals.HideSelection = false;
            lvSignals.Columns.Add("Id");
            lvSignals.Columns.Add("Type");
            lvSignals.Columns.Add("Attributes");
            lvSignals.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);

            ATMLAllocator.Instance.TestDescriptionChanged+=OnTestDescriptionChanged;
        }


        private void OnTestDescriptionChanged( TestDescription testDescription )
        {
            lvSignals.Items.Clear();
            lvSignals.ShowGroups = true;
            Dictionary<string, ListViewGroup> groups = new Dictionary<string, ListViewGroup>();
            if (testDescription != null)
            {
                foreach (SignalRequirementsSignalRequirement signalRequirement in testDescription.SignalRequirements)
                {
                    if (signalRequirement.TsfClass != null && !"SHORT".Equals(signalRequirement.TsfClass.tsfClassName ))
                    {
                        ListViewGroup grp;
                        if (groups.ContainsKey( signalRequirement.TsfClass.tsfClassName ))
                        {
                            grp = groups[signalRequirement.TsfClass.tsfClassName];
                        }
                        else
                        {
                            grp = new ListViewGroup( signalRequirement.TsfClass.tsfClassName );
                            groups.Add( signalRequirement.TsfClass.tsfClassName, grp );
                            lvSignals.Groups.Add( grp );
                        }

                        ListViewItem lvi = new ListViewItem(signalRequirement.TsfClass.tsfLibraryID);
                        lvi.SubItems.Add( signalRequirement.TsfClass.tsfClassName );
                        StringBuilder sb = new StringBuilder();
                        foreach (SignalRequirementsSignalRequirementTsfClassAttribute attribute in signalRequirement.TsfClassAttribute)
                        {
                            sb.Append( string.Format( "{0}={1}, ", attribute.Name.Value, attribute.Value ) );
                        }
                        if (sb.ToString().EndsWith( ", " ))
                            sb.Length = sb.Length - 2;
                        lvi.SubItems.Add(sb.ToString());
                        lvi.Tag = signalRequirement;
                        lvi.Group = grp;
                        lvSignals.Items.Add( lvi );
                    }
                }

                foreach (ActionType actionType in testDescription.DetailedTestInformation.Actions)
                {
                    foreach (ActionTypeLocalSignal localSignal in actionType.LocalSignals)
                    {

                    }
                }

                lvSignals.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);

            }
        }

        public void CloseProject()
        {
            lvSignals.Items.Clear();
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

        private void lvSignals_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvSignals.SelectedItems.Count > 0)
            {
                ListViewItem lvi = lvSignals.SelectedItems[0];
                SignalRequirementsSignalRequirement signalRequirement = lvi.Tag as SignalRequirementsSignalRequirement;
                if (signalRequirement != null)
                {
                    OnSignalRequirementSelected( signalRequirement );
                }
            }
        }

    }
}
