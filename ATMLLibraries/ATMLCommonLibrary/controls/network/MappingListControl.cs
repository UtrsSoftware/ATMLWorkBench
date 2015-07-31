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
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using ATMLCommonLibrary.controls.lists;
using ATMLCommonLibrary.utils;
using ATMLModelLibrary.model.equipment;
using ATMLUtilitiesLibrary;
using Resources = ATMLCommonLibrary.Properties.Resources;

namespace ATMLCommonLibrary.controls.network
{
    public partial class MappingListControl : ATMLListControl
    {
        const String SEPARATOR = " → ";
        private List<Mapping> _mappings = new List<Mapping>();

        public MappingListControl()
        {
            InitializeComponent();
            InitListView();
        }

        private void InitListView()
        {
            SetAddButtonTooltip("Press to add a new Mapping");
            SetEditButtonTooltip("Press to edit the selected Mapping");
            SetDeleteButtonTooltip("Press to delete the selected Mapping");
        }

        [Browsable( false ), DesignerSerializationVisibility( DesignerSerializationVisibility.Hidden )]
        public List<Mapping> Mappings
        {
            get
            {
                ControlsToData();
                return _mappings;
            }
            set
            {
                _mappings = value;
                DataToControls();
            }
        }

        private HardwareItemDescription _hardwareItemDescription;
        public HardwareItemDescription HardwareItemDescription
        {
            get { return _hardwareItemDescription; }
            set { _hardwareItemDescription = value; }
        }

        protected void ControlsToData()
        {
            if (Items.Count == 0)
                _mappings = null;
            else
            {
                if (_mappings == null)
                    _mappings = new List<Mapping>();
                _mappings.Clear();
                foreach (ListViewItem lvi in Items)
                {
                    var mapping = lvi.Tag as Mapping;
                    if (mapping != null)
                    {
                        _mappings.Add( mapping );
                    }
                }
            }
        }

        private void DataToControls()
        {
            if (_mappings != null)
            {
                lvList.Items.Clear();
                foreach (Mapping mapping in _mappings)
                {
                    AddMappingItem( mapping );
                }
            }
        }

        private void AddMappingItem( Mapping mapping )
        {
            if (mapping == null)
                return;

            var mappingName = CreateMappingName( mapping );
            var item = new ListViewItem( mapping.ToString() );
            item.Tag = mapping;
            lvList.Items.Add( item );
        }

        private string CreateMappingName( Mapping mapping )
        {
            String mappingName = "Mapping ";
            List<Network> map = mapping.Map.ToList();
            if (map.Count > 0)
            {
                var sb = new StringBuilder();
                List<NetworkNode> nodes = map[0].Node.ToList();
                foreach (NetworkNode node in nodes)
                {
                    sb.Append( GetMappingName( node ) );
                    sb.Append( SEPARATOR );
                }
                if (sb.ToString().EndsWith( SEPARATOR ))
                    sb.Length = sb.Length - SEPARATOR.Length;
                mappingName = sb.ToString();
            }
            return mappingName;
        }

        private String GetMappingName( NetworkNode node )
        {
            String mappingName = "";
            XmlDocument doc = XmlUtils.XPath2XmlDocument( node.Path.Value );
            Dictionary<String, Dictionary<String, String>> elements = XmlUtils.ExtractElementsWithAttributes( doc );
            foreach (String key in elements.Keys)
            {
                mappingName += ( key + ":" );
                Dictionary<String, String> attributes = elements[key];
                foreach (String k in attributes.Keys)
                {
                    mappingName += ( attributes[k] + " " );
                }
            }

            return mappingName.Trim();
        }

        private void lvList_Resize( object sender, EventArgs e )
        {
            if (lvList.Columns.Count >= 1)
            {
                lvList.Columns[0].Width = lvList.Width;
            }
        }

        protected override void btnAdd_Click( object sender, EventArgs e )
        {
            var form = new MappingForm(HardwareItemDescription);
            form.Text = @"Add New Map";
            if (DialogResult.OK == form.ShowDialog())
            {
                Mapping mapping = form.Mapping;
                AddMappingItem( mapping );
            }
        }

        protected override void btnDelete_Click( object sender, EventArgs e )
        {
            if (HasSelected)
            {
                if (DialogResult.Yes ==
                    MessageBox.Show( @"Delete the selected Mapping?", 
                                     Resources.V_E_R_I_F_Y, 
                                     MessageBoxButtons.YesNo,
                                     MessageBoxIcon.Question ))
                {
                    RemoveSelectedItem();
                }
            }
        }

        protected override void btnEdit_Click( object sender, EventArgs e )
        {
            if (HasSelected)
            {
                Mapping mapping = SelectedObject as Mapping;
                if (mapping != null)
                {
                    var form = new MappingForm(HardwareItemDescription);
                    form.Text = @"Edit Map";
                    form.Mapping = mapping;
                    if (DialogResult.OK == form.ShowDialog())
                    {
                        mapping = form.Mapping;
                        SelectedListViewItem.SubItems[0].Text = mapping.ToString();
                    }
                }
            }
        }
    }
}