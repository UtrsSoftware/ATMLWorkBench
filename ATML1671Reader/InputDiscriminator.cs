/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
* 
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

using System;
using System.Xml;
using System.Xml.Serialization;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using ATML1671Reader.model;
using ATML1671Reader.model.mtpsi;

namespace ATML1671Reader
{
    /**
     * The InputDiscriminator looks at the input file and determines the file type. For example if the 
     * input file is a .tpsi file then the MTPSI reader will be implemented. Other file types will include
     * .trd, .eltd, .doc, .docx, .xsl, .xslx, .txt
     */
    public class InputDiscriminator
    {

        public IInputFile readFile(FileInfo fi)
        {
            StreamReader sr = new StreamReader(fi.OpenRead());
            String content = sr.ReadToEnd();
            IInputFile input = null;
            if( fi.Extension.ToLower().EndsWith("tpsi") )
            {
                MemoryStream memory = new MemoryStream(System.Text.Encoding.UTF8.GetBytes(content));
                XmlSerializer SerializerObj = new XmlSerializer(typeof(CASSMTPSI));
                input = (CASSMTPSI)SerializerObj.Deserialize(memory);
            }
            return input;
        }
    }
}
