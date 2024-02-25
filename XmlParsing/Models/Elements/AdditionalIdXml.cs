using MsgDeliveryFailReporting.XmlParsing.Models.ComplexTypes;
using System.Xml.Serialization;

namespace MsgDeliveryFailReporting.XmlParsing.Models.Elements
{
    public partial class AdditionalIdXml
    {
        [XmlElement("Id")]
        public string Id { get; set; } = string.Empty;

        [XmlElement("Type")]
        public CSType Type { get; set; } = new CSType();
    }
}
