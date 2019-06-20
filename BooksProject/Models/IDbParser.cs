using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BooksProject.Models
{
    public interface IDbParser
    {
        XDocument GetDb();
    }
}
