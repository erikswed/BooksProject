using System.Xml.Linq;

namespace WorkSampleBookSearch
{
    public class XmlDbFactory : IXmlDbFactory
    {
        public XDocument GetXmlDb()
        {
            return XDocument.Load("books.xml");
        }
    }
}