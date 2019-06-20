using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BooksProject.Models
{
    /// <summary>
    /// Returns a remote type of db
    /// </summary>
    public class RemoteDbParser : IDbParser
    {
        public XDocument GetDb()
        {
            // remote http some host in Mexiko sitting on our db :)
            return null;
        }
    }
}
