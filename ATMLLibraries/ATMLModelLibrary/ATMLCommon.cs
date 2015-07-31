using System.ComponentModel;
using System.Xml.Serialization;
using ATMLDataAccessLibrary.db.beans;

namespace ATMLModelLibrary
{

    public class ATMLCommon
    {
        public static string HardwareCommonNameSpace = "urn:IEEE-1671:2010:HardwareCommon";
        public static string InstrumentNameSpace = "urn:IEEE-1671.2:2012:InstrumentDescription";
        public static string TestEquipmentNameSpace = "urn:IEEE-1671:2010:TestEquipment";
        public static string TestStationNameSpace = "urn:IEEE-1671.6:2009.03:TestStationDescription";
        public static string TestAdapterNameSpace = "urn:IEEE-1671.5:2009.03:TestAdapterDescription";
        public static string TestDescriptionNameSpace = "urn:IEEE-1671.1:2009:TestDescription";
        public static string TestConfigurationNameSpace = "urn:IEEE-1671.4:2009.03:TestConfiguration";
        public static string UUTNameSpace = "urn:IEEE-1671.3:2009.03:UUTDescription";
        
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [XmlIgnore]
        public BASEBean.eDataState DataState;



    }
}
