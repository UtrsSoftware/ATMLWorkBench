using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using ATMLModelLibrary.model;

namespace ATMLModelLibrary
{
    public class NameSpaceLibrary
    {
        public static XNamespace tdns = "urn:IEEE-1671.1:2009:TestDescription";
    }

    public class TestDescriptionReader
    {
        private XElement _detailedTestInformation;
        private XDocument _document;
        private XElement _failureFaultData;
        private XElement _interfaceRequirements;
        private XElement _tsfLibraries;
        private XElement _uut;

        public TestDescriptionReader(string xmlContent)
        {

            TestDescription td = TestDescription.Deserialize(xmlContent);




            _document = XDocument.Parse(xmlContent);
            XElement root = _document.Root;
            _tsfLibraries = root.Element(NameSpaceLibrary.tdns + "TsfLibraries");
            _uut = root.Element(NameSpaceLibrary.tdns + "UUT");
            _interfaceRequirements = root.Element(NameSpaceLibrary.tdns + "nterfaceRequirements");
            _detailedTestInformation = root.Element(NameSpaceLibrary.tdns + "DetailedTestInformation");
            _failureFaultData = root.Element(NameSpaceLibrary.tdns + "FailureFaultData");


            StringReader stringReader = null;
            try
            {
                stringReader = new StringReader(_detailedTestInformation.ToString());
                XmlReader reader = XmlReader.Create(stringReader);
                var nsmanager = new XmlNamespaceManager(reader.NameTable);
                nsmanager.AddNamespace("td", "urn:IEEE-1671.1:2009:TestDescription");
                var serializer = new XmlSerializer(typeof (DetailedTestInformation));
                var dti = ((DetailedTestInformation) (serializer.Deserialize(reader)));

                int x = 0;
            }
            finally
            {
                if ((stringReader != null))
                {
                    stringReader.Dispose();
                }
            }

            DetailedTestInformation dt = DetailedTestInformation.Deserialize(_detailedTestInformation.ToString());

            int i = 0;
        }
    }

    public class DetailedTestInformationz
    {
        private readonly List<XElement> _entryPoints = new List<XElement>();
        private XElement _detailedTestInformation;

        public DetailedTestInformationz(XElement detailedTestInformation)
        {
            _detailedTestInformation = detailedTestInformation;
            _entryPoints.AddRange(detailedTestInformation.Descendants(NameSpaceLibrary.tdns + "TestGroupEntryPoint"));
        }
    }
}