using MsgDeliveryFailReporting.XmlParsing.Models.ComplexTypes;
using System.Xml.Serialization;

namespace MsgDeliveryFailReporting.XmlParsing.Models.Elements
{
    [Serializable, XmlRoot(ElementName = "AppRec", Namespace = "http://www.kith.no/xmlstds/apprec/2004-11-21")]
    public partial class AppRecXml
    {
        [XmlElement("MsgType")]
        public CSType MsgType { get; set; } = new CSType();

        [XmlElement("MIGversion")]
        public string MIGversion { get; set; } = "1.0 2004-11-21";

        [XmlElement("SoftwareName")]
        public string? SoftwareName { get; set; }

        [XmlElement("SoftwareVersion")]
        public string? SoftwareVersion { get; set; }

        [XmlElement("GenDate")]
        public DateTime GenDate { get; set; }

        [XmlElement("Id")]
        public string Id { get; set; } = string.Empty;

        public SenderXml Sender { get; set; } = new SenderXml();

        public ReceiverXml Receiver { get; set; } = new ReceiverXml();

        [XmlElement("Status")]
        public CSType Status { get; set; } = new CSType();

        [XmlElement("Error")]
        public List<CVType> Errors { get; set; } = new List<CVType>();

        public OriginalMsgIdXml OriginalMsgId { get; set; } = new OriginalMsgIdXml();
    }
}
