using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace xmltest
{
    class XmlParser<T> : AbstractParser<T> where T : class, new()
    {
        public override string Extension { get; } = ".xml";
        protected override string GetRawPropertyByName(string propName)
        {
            var xmlDocument = new XmlDocument();
            xmlDocument.LoadXml(ReadDocument());
            var node = GetNodeOrNull(propName, xmlDocument.DocumentElement);
            if (node == null) throw new KeyNotFoundException();
            return node.InnerText;
        }

        private XmlNode GetNodeOrNull(string name, XmlNode xmlNode)
        {
            foreach (XmlNode node in xmlNode)
            {
                if (node.Name == name)
                {
                    return node;
                }
                else
                {
                    var xmlNode1 = GetNodeOrNull(name, node);
                    if (xmlNode1 != null) return xmlNode1;
                }
            }
            return null;
        }
    }
}
