using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace CommonHelpers.Helpers
{
    public static class SensitiveData
    {
        public static string GetConnectionString()
        {
            return (string)XDocument.Load(@"..\..\config.xml").Root.Element("connectionString");
        }

        public static string GetBotToken()
        {
            return (string)XDocument.Load(@"..\..\config.xml").Root.Element("botToken");
        }
    }
}
