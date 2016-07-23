using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            string path = @"C:\Users\Simon\Desktop\aklng temp\";
            string file = @"AKLNG Integrated (+ERL+PL+Marine+Plant+GTP) - Rev-7h 160714 sw small3.plnx";

            XmlDocument x = GetXmlDoc(path + file);

            x.Save(path + Path.GetFileNameWithoutExtension(file) + " f" + Path.GetExtension(file) + ".xml");
        }


        // Xml functions

        public static XmlDocument CreateXmlDoc()
        {
            XmlDocument doc = new XmlDocument();
            XmlDeclaration dec = doc.CreateXmlDeclaration("1.0", null, null);
            doc.AppendChild(dec);
            return doc;
        }

        public static XmlDocument GetXmlDoc(string file)
        {
            XmlDocument doc = new XmlDocument();
            XmlTextReader reader = new XmlTextReader(file);
            doc.Load(reader);
            reader.Close();
            return doc;
        }

        public static XmlNode GetTopNode(string file)
        {
            XmlDocument doc = new XmlDocument();
            doc.PreserveWhitespace = false;
            XmlTextReader reader = new XmlTextReader(file);
            doc.Load(reader);
            reader.Close();
            return doc.LastChild;
        }

        public static List<XmlElement> GetChildElements(XmlNode n, string name)
        {
            List<XmlElement> ns = new List<XmlElement>();
            foreach (XmlNode c in n.ChildNodes)
                if (c.Name == name)
                {
                    XmlElement e = (XmlElement) c;
                    ns.Add(e);
                }
            return ns;
        }

        public static List<XmlNode> GetChildNodes(XmlNode n, string name)
        {
            List<XmlNode> ns = new List<XmlNode>();
            foreach (XmlNode c in n.ChildNodes)
                if (c.Name == name)
                    ns.Add(c);
            return ns;
        }

        public static XmlElement GetChildElement(XmlNode n, string name)
        {
            return n.ChildNodes.Cast<XmlElement>().FirstOrDefault(child => child.Name == name);
        }

        public static XmlNode GetChildNode(XmlNode n, string name)
        {
            return n.ChildNodes.Cast<XmlNode>().FirstOrDefault(child => child.Name == name);
        }
    }
}
