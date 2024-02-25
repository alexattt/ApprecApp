using MsgDeliveryFailReporting.XmlParsing.Models.ComplexTypes;
using System.Xml.Serialization;

namespace MsgDeliveryFailReporting.XmlParsing.Models.Elements
{
    public partial class AddressXml
    {
        [XmlElement("Type")]
        public CSType Type { get; set; } = new CSType();

        [XmlElement("StreetAdr")]
        public string? StreetAdr { get; set; }

        [XmlElement("PostalCode")]
        public string? PostalCode { get; set; }

        [XmlElement("City")]
        public string? City { get; set; }

        [XmlElement("County")]
        public CSType? County { get; set; }

        [XmlElement("Country")]
        public CSType? Country { get; set; }

        [XmlElement("CityDistr")]
        public CSType? CityDistr { get; set; }

        [XmlElement("TeleAddress")]
        public List<URLType> TeleAddresses { get; set; } = new List<URLType>();
    }
}
