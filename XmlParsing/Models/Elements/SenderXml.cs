using MsgDeliveryFailReporting.XmlParsing.Models.ComplexTypes;
using System.Xml.Serialization;

namespace MsgDeliveryFailReporting.XmlParsing.Models.Elements
{
    public partial class SenderXml
    {
        [XmlElement("Role")]
        public CSType? Role { get; set; }

        public HCPXml HCP { get; set; } = new HCPXml();
    }
}
