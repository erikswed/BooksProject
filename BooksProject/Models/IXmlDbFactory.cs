using System.Xml.Linq;

namespace WorkSampleBookSearch
{
    public interface IXmlDbFactory
    {
        XDocument GetXmlDb();
    }
}