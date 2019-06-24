using System.Xml.Linq;

namespace WorkSampleBookSearch.Model
{
    public interface IXmlDbFactory
    {
        XDocument GetXmlDb();
    }
}