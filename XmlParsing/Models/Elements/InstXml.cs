using MsgDeliveryFailReporting.XmlParsing.Models.ComplexTypes;
using System.Xml.Serialization;

namespace MsgDeliveryFailReporting.XmlParsing.Models.Elements
{
    public partial class InstXml
    {
        [XmlElement("Name")]
        public string? Name { get; set; }

        [XmlElement("Id")]
        public string? Id { get; set; }

        [XmlElement("TypeId")]
        public CSType? TypeId { get; set; }

        public List<DeptXml> Depts { get; set; } = new List<DeptXml>();

        public List<AdditionalIdXml> AdditionalIds { get; set; } = new List<AdditionalIdXml>();

        public List<HCPersonXml> HCPersons { get; set; } = new List<HCPersonXml>();
    }
}
