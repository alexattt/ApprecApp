using System.Xml.Serialization;
using System.Xml;
using MsgDeliveryFailReporting.XmlParsing.Models.Elements;

namespace MsgDeliveryFailReporting.XmlParsing
{
	public static class XmlParser
	{
		public static AppRecXml? ParseAppRecXml(string filePath)
		{
			using (XmlReader reader = XmlReader.Create(filePath))
			{
				var serializer = new XmlSerializer(typeof(AppRecXml));

				var appRec = (AppRecXml?)serializer.Deserialize(reader);

				return appRec;
			}
		}
	}
}
