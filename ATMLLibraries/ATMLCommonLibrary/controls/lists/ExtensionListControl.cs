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
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml.Serialization;
using ATMLModelLibrary.model.common;
using ATMLModelLibrary.model.equipment;

namespace ATMLCommonLibrary.controls
{
    public partial class ExtensionListControl : UserControl
    {
        private Extension extension = null;
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Extension Extension
        {
            get { return extension; }
            set { extension = value; }
        }

        public ExtensionListControl()
        {
            InitializeComponent();
        }

        public void DataToControls()
        {
            lvExtensions.Items.Clear();
            //foreach( XmlElement element in extension.Any )
            //{
             //   ListViewItem item = new ListViewItem(element.Name);
              //  item.SubItems.Add(element.Value); //TODO: Note need a way to represent a generic complex element
               // item.Tag = element;
                //lvExtensions.Items.Add(item);
            //}
        }
    }
}
