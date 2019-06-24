using System.Xml.Linq;

namespace WorkSampleBookSearch.Model
{
    /// <summary>
    /// Factory that returns a db
    /// </summary>
    public class XmlDbFactory : IXmlDbFactory
    {
        public XDocument GetXmlDb()
        {
            return DbParserResolver.DB_PARSER.GetDb();
        }
    }
}