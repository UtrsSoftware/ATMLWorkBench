/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
* 
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace ATMLModelLibrary.model
{
    [GeneratedCode("System.Xml", "4.0.30319.18408")]
    [Serializable]
    [DesignerCategory(@"code")]
    [XmlRoot("project")]
    public class ProjectInfo
    {
        private string _projectTitle;
        private string _projectName;
        private string _uuid;
        private string _uutId;
        private string _uutName;
        private string _className;

        [XmlElement("translator")]
        public TranslationInfo TranslationInfo { set; get; }

        public ProjectInfo()
        {
        }

        public ProjectInfo(string xml)
        {
            Copy(Deserialize(xml));
        }

        public ProjectInfo(byte[] xml)
        {
            Copy(Deserialize(Encoding.UTF8.GetString(xml)));
        }

        [XmlAttribute("name")]
        public string ProjectName
        {
            get { return _projectName; }
            set { _projectName = value; }
        }

        [XmlAttribute("uut")]
        public string UutName
        {
            get { return _uutName; }
            set { _uutName = value; }
        }

        [XmlAttribute("uutid")]
        public string UutId
        {
            get { return _uutId; }
            set { _uutId = value; }
        }

        [XmlAttribute("uuid")]
        public string Uuid
        {
            get { return _uuid; }
            set { _uuid = value; }
        }

        [XmlAttribute("title")]
        public string ProjectTitle
        {
            get { return _projectTitle; }
            set { _projectTitle = value; }
        }

        [XmlAttribute("className")]
        public string ClassName
        {
            get { return _className; }
            set { _className = value; }
        }

        public void Copy(ProjectInfo projectInfo)
        {
            _projectName = projectInfo.ProjectName;
            _uuid = projectInfo.Uuid;
            _uutId = projectInfo.UutId;
            _uutName = projectInfo.UutName;
            _projectTitle = projectInfo._projectTitle;
            _className = projectInfo._className;
            TranslationInfo = projectInfo.TranslationInfo;
        }

        public virtual string Serialize()
        {
            string content;
            MemoryStream memoryStream = null;
            var serializer = new XmlSerializer(typeof (ProjectInfo));
            using (memoryStream = new MemoryStream())
            {
                serializer.Serialize(memoryStream, this);
                memoryStream.Flush();
                content = Encoding.UTF8.GetString(memoryStream.ToArray());
            }
            return content;
        }

        public static ProjectInfo Deserialize(string input)
        {
            StringReader stringReader = null;
            try
            {
                var serializer = new XmlSerializer(typeof (ProjectInfo));
                stringReader = new StringReader(input.Replace('\0', ' ' ).Trim() );
                return ((ProjectInfo) (serializer.Deserialize(XmlReader.Create(stringReader))));
            }
            finally
            {
                if ((stringReader != null))
                {
                    stringReader.Dispose();
                }
            }
        }
    }

    [GeneratedCode("System.Xml", "4.0.30319.18408")]
    [Serializable]
    [XmlRoot("translator")]
    public class TranslationInfo
    {
        [XmlAttribute("segmented")]
        public bool Segmented { set; get; }
        [XmlElement("source", Type = typeof(TranslationSourceInfo))]
        public List<TranslationSourceInfo> SourceFiles { get; set; }

        public string SourcesAsAstring
        {
            get
            {
                var sb = new StringBuilder();
                foreach (var translationSourceInfo in SourceFiles)
                {
                    sb.Append( translationSourceInfo.FileName ).Append( "," );
                }
                if( sb.ToString().EndsWith( "," ) )
                    sb.Length = sb.Length - 1;
                return sb.ToString();
            }
        }

        public string PrimaryFile
        {
            get
            {
                string primarySource = null;
                foreach (var translationSourceInfo in SourceFiles)
                {
                    if (translationSourceInfo.Primary)
                    {
                        primarySource = translationSourceInfo.FileName;
                    }
                }
                return primarySource;
            }
        }
    }

    [GeneratedCode("System.Xml", "4.0.30319.18408")]
    [Serializable]
    [XmlRoot("source")]
    public class TranslationSourceInfo
    {
        [XmlAttribute("primary")]
        public bool Primary { set; get; }
        [XmlText]
        public string FileName { get; set; }

        public TranslationSourceInfo()
        {
            
        }

        public TranslationSourceInfo( string fileName )
        {
            FileName = fileName;
        }

        public TranslationSourceInfo(string fileName, bool primary )
        {
            FileName = fileName;
            Primary = primary;
        }

        public override string ToString()
        {
            return FileName;
        }
    }

}