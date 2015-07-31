/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
*
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

using System;
using System.Windows.Forms;
using System.Xml;
using ATMLCommonLibrary.controls.awb;
using ATMLModelLibrary.model.signal.basic;

namespace ATMLCommonLibrary.controls.signal
{
    public class SignalPartListView : AWBListView
    {
        private void SetColumnsWidths()
        {
            if (Columns.Count >= 4)
            {
                Columns[0].Width = (int) ( Width*.25 );
                Columns[1].Width = (int) ( Width*.25 );
                Columns[2].Width = (int) ( Width*.15 );
                Columns[3].Width = Width - ( Columns[0].Width + Columns[1].Width + Columns[2].Width );
            }
        }

        public void addSignalPart(object signalType)
        {
            if (signalType is SignalFunctionType)
            {
                var item = new ListViewItem(signalType.GetType().Name);
                item.SubItems.Add(((SignalFunctionType) signalType).name);
                item.SubItems.Add(((SignalFunctionType) signalType).type);
                item.SubItems.Add(((SignalFunctionType) signalType).In);
                item.Tag = signalType;
                item = Items.Add(item);
                if (item.Index%2 == 0)
                {
                    item.BackColor = AltColor1;
                }
                else
                {
                    item.BackColor = AltColor2;
                }
            }
            else if (signalType is XmlElement)
            {
                var item = new ListViewItem(((XmlElement) signalType).LocalName);
                item.SubItems.Add((((XmlElement) signalType).HasAttribute("name"))
                    ? ((XmlElement) signalType).GetAttribute("name")
                    : "");
                item.SubItems.Add((((XmlElement) signalType).HasAttribute("type"))
                    ? ((XmlElement) signalType).GetAttribute("type")
                    : "");
                item.SubItems.Add((((XmlElement) signalType).HasAttribute("In"))
                    ? ((XmlElement) signalType).GetAttribute("In")
                    : "");
                item.Tag = signalType;
                item = Items.Add(item);
                if (item.Index%2 == 0)
                {
                    item.BackColor = AltColor1;
                }
                else
                {
                    item.BackColor = AltColor2;
                }
            }
        }


        public void addSignalParts(SignalFunctionType[] signalTypes)
        {
            foreach (SignalFunctionType signalType in signalTypes)
            {
                addSignalPart(signalType);
            }
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            SetColumnsWidths();
        }
    }
}