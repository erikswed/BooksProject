using System.Xml.Linq;

namespace WorkSampleBookSearch
{
    /// <summary>
    /// Factory that returns a db
    /// </summary>
    public class XmlDbFactory : IXmlDbFactory
    {
        // DbParserResolver Db = new DbParserResolver();
        public XDocument GetXmlDb()
        {
            return DbParserResolver.JSON_PARSER.GetDb();
        }

        public XmlDbFactory()
        {
        }
    }
}