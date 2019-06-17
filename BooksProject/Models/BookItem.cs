using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WorkSampleBookSearch.Model
{
    public class BookItem
    {
        public string Id { get; set; }
        public string Author { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
        public decimal Price { get; set; }
        public DateTime Publish_date { get; set; }
        public string Description { get; set; }
    }
}