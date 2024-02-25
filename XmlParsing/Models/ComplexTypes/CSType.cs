using System.Xml.Serialization;

namespace MsgDeliveryFailReporting.XmlParsing.Models.ComplexTypes
{
    public partial class CSType
    {
        [XmlAttribute("V")]
        public string? V { get; set; }

        [XmlAttribute("DN")]
        public string? DN { get; set; }
    }
}
