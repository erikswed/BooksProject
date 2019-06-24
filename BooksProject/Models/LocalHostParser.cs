using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace WorkSampleBookSearch.Models
{
    /// <summary>
    /// Returns a Localhost type of db
    /// </summary>
    public class LocalHostParser : IDbParser
    {
        public XDocument GetDb()
        {
            try
            {
                return XDocument.Load("books.xml");
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
