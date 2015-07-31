/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
* 
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using ATMLCommonLibrary.controls.lists;
using ATMLCommonLibrary.model;
using ATMLManagerLibrary.delegates;
using ATMLManagerLibrary.interfaces;
using ATMLManagerLibrary.managers;
using ATMLModelLibrary.interfaces;
using WeifenLuo.WinFormsUI.Docking;

namespace ATMLCommonLibrary.forms
{
    public partial class ATMLLibraryForm : DockContent, IATMLDockableWindow, IAtmlActionable
    {
        private readonly ATMLLibraryListControl _listControl;
        private object _selectedObject;

        public ATMLLibraryForm(Type classType)
        {
            InitializeComponent();
            HideOnClose = true;
            try
            {
                object control = Activator.CreateInstance(classType);
                _listControl = control as ATMLLibraryListControl;
                if (_listControl != null)
                {
                    Controls.Add(_listControl);
                    _listControl.Location = new Point(0, toolStrip.Bottom);
                    _listControl.Width = ClientSize.Width;
                    _listControl.Height = ClientSize.Height - toolStrip.Height;
                    _listControl.Anchor = AnchorStyles.Bottom | AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
                    var actionable = _listControl as IAtmlActionable;
                    if (actionable != null)
                        actionable.AtmlObjectAction += OnAtmlObjectAction;

                    Text = _listControl.ListName + @"s";
                    _listControl.InitializeForm += delegate(Form form)
                    {
                        var atmlForm = form as ATMLForm;
                        if (atmlForm != null) atmlForm.CloseOnSave = false;
                    };
                }
                var mnuContextMenu = new ContextMenu();
                TabPageContextMenu = mnuContextMenu;
                var mnuItemNew = new MenuItem();
                mnuItemNew.Text = @"Close";
                mnuItemNew.Click += mnuItemNew_Click;
                mnuContextMenu.MenuItems.Add(mnuItemNew);
                mnuItemNew.Tag = this;
            }
            catch (Exception e )
            {
                LogManager.Error( e, "Error creating instance for class type: {0}", classType );
            }

        }


        public override sealed string Text
        {
            get { return base.Text; }
            set { base.Text = value; }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public object SelectedObject
        {
            get { return _selectedObject; }
        }

        public event AtmlActionDeligate<IAtmlObject> AtmlObjectAction;

        public void CloseProject()
        {
        }

        protected virtual IAtmlObject OnAtmlObjectAction(IAtmlObject obj, AtmlActionType actiontype, EventArgs args)
        {
            IAtmlObject results = null;
            AtmlActionDeligate<IAtmlObject> handler = AtmlObjectAction;
            if (handler != null)
            {
                results = handler( obj, actiontype, args );
            }
            return results;
        }

        private void mnuItemNew_Click(object sender, EventArgs e)
        {
            var mnuItem = sender as MenuItem;
            if (mnuItem != null)
            {
                var form = mnuItem.Tag as DockContent;
                if (form != null)
                    form.Hide();
            }
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            _listControl.ApplyFilter(edtFilter.Text);
        }

        private void edtFilter_KeyPress(object sender, KeyPressEventArgs e)
        {
        }

        private void edtFilter_KeyDown(object sender, KeyEventArgs e)
        {
        }

        private void edtFilter_KeyUp(object sender, KeyEventArgs e)
        {
            _listControl.ApplyFilter(edtFilter.Text);
        }

        private void ATMLLibraryForm_Load(object sender, EventArgs e)
        {
            btnCancel.Visible = Modal;
            btnSelect.Visible = Modal;
            if (Modal)
                _listControl.Height = ClientSize.Height - (toolStrip.Height + 35);
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            _selectedObject = _listControl.SelectedObject;
        }

        private void ATMLLibraryForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Modal && DialogResult == DialogResult.OK)
            {
                if (!_listControl.HasSelected)
                {
                    MessageBox.Show(
                        @"Please select a UUT. If the UUT description you need does not exist, please create one first.");
                    e.Cancel = true;
                }
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            _listControl.RefreshList();
        }
    }
}