using System.Xml.Serialization;

namespace MsgDeliveryFailReporting.XmlParsing.Models.ComplexTypes
{
    public partial class CVType
    {
        [XmlAttribute("V")]
        public string? V { get; set; }

        [XmlAttribute("S")]
        public string? S { get; set; }

        [XmlAttribute("DN")]
        public string? DN { get; set; }

        [XmlAttribute("OT")]
        public string? OT { get; set; }
    }
}
