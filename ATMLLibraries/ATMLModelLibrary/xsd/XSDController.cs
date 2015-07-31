using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Xml;
using System.Xml.Schema;


namespace ATMLModelLibrary.xsd
{
    public class XSDController
    {
        private String _schemaTypeName;
        [Category("Behaviour")]
        [Description("Enter the XML Schema Type Name.")]
        public String SchemaTypeName
        {
            get { return _schemaTypeName; }
            set { _schemaTypeName = value; }
        }
        private String _targetNamespace;
        [Category("Behaviour")]
        [Description("Enter the target namespace for the Schema Type.")]
        public String TargetNamespace
        {
            get { return _targetNamespace; }
            set { _targetNamespace = value; }
        }

    }
}
