using MsgDeliveryFailReporting.XmlParsing.Models.ComplexTypes;
using System.Xml.Serialization;

namespace MsgDeliveryFailReporting.XmlParsing.Models.Elements
{
    public partial class HCPXml
    {
        public InstXml? Inst { get; set; }

        public HCProfXml? HCProf { get; set; }

        [XmlElement("MedSpeciality")]
        public CVType? MedSpeciality { get; set; }

        public AddressXml? Address { get; set; }
    }
}
