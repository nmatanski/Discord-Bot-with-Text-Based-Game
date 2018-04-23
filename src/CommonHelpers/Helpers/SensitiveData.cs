using System.IO;
using System.Xml;

namespace CommonHelpers.Helpers
{
    public static class SensitiveData
    {
        public static string GetConnectionString()
        {
            var xml = File.ReadAllText(@"..\..\..\..\config.xml");
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xml);
            var node = doc.SelectSingleNode("sd/connectionString");
            return node.InnerText;
        }

        public static string GetBotToken()
        {
            var xml = File.ReadAllText(@"..\..\..\..\config.xml");
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xml);
            var node = doc.SelectSingleNode("sd/botToken");
            return node.InnerText;
        }
    }
}
