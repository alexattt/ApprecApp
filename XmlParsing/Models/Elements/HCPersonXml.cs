﻿using MsgDeliveryFailReporting.XmlParsing.Models.ComplexTypes;
using System.Xml.Serialization;

namespace MsgDeliveryFailReporting.XmlParsing.Models.Elements
{
    public partial class HCPersonXml
    {
        [XmlElement("Name")]
        public string? Name { get; set; }

        [XmlElement("Id")]
        public string? Id { get; set; }

        [XmlElement("TypeId")]
        public CSType? TypeId { get; set; }

        public List<AdditionalIdXml> AdditionalIds { get; set; } = new List<AdditionalIdXml>();
    }
}
