using System.Xml.Serialization;

namespace MsgDeliveryFailReporting.XmlParsing.Models.ComplexTypes
{
    public partial class URLType
    {
        [XmlAttribute("V")]
        public string? V { get; set; }
    }
}
