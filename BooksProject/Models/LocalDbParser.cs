using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BooksProject.Models
{
    /// <summary>
    /// Returns a Localhost type of db
    /// </summary>
    public class LocalDbParser : IDbParser
    {
        public XDocument GetDb()
        {
            return XDocument.Load("books.xml");
        }
    }
}
