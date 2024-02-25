using MsgDeliveryFailReporting.XmlParsing.Models.ComplexTypes;
using System.Xml.Serialization;

namespace MsgDeliveryFailReporting.XmlParsing.Models.Elements
{
    public partial class OriginalMsgIdXml
    {
        [XmlElement("MsgType")]
        public CSType MsgType { get; set; } = new CSType();

        [XmlElement("IssueDate")]
        public DateTime IssueDate { get; set; } = DateTime.MinValue;

        [XmlElement("Id")]
        public string Id { get; set; } = string.Empty;
    }
}
