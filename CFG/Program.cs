using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace CFG
{
    class Program
    {
        static void Main(string[] args)
        {
            string xmlFilePath = @"C:\Users\Gyue\Desktop\Wiki\cfg.xml";
            GenerateXMLFile(xmlFilePath);
            GetXmlInfo(xmlFilePath);
            ModifyXml(xmlFilePath);
        }

        private static void ModifyXml(string xmlFilePath)
        {
            XmlDocument myXmlDoc = new XmlDocument();
            myXmlDoc.Load(xmlFilePath);
            XmlNode rootNode = myXmlDoc.FirstChild;
            XmlNodeList firstLevelNodeList = rootNode.ChildNodes;
            foreach (XmlNode node in firstLevelNodeList)
            {
            //修改此节点的属性值
                if (node.Attributes["id"].Value.Equals("111"))
                    {
                    node.Attributes["id"].Value = "123";
                    }
                }
            //要想使对xml文件所做的修改生效，必须执行以下Save方法
            myXmlDoc.Save(xmlFilePath);
        }

        private static void GetXmlInfo(string xmlFilePath)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(xmlFilePath);

            XmlNode rootNode = xmlDoc.SelectSingleNode("Root");

            XmlNode FstNode = rootNode.ChildNodes.Item(0);
            string id = FstNode.Attributes.GetNamedItem("id").Value;
        }

        private static void GenerateXMLFile(string xmlFilePath)
        {
            XmlDocument xmlDoc = new XmlDocument();
            
            XmlElement rootElm = xmlDoc.CreateElement("Root");
            xmlDoc.AppendChild(rootElm);

            XmlElement fstElm = xmlDoc.CreateElement("Fst");
            fstElm.SetAttribute("id", "111");
            fstElm.SetAttribute("des", "dessss");
            rootElm.AppendChild(fstElm);

            xmlDoc.Save(xmlFilePath);
        }
    }
}
