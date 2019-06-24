using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;
using WorkSampleBookSearch.Model;
using System.Globalization;
using Microsoft.AspNetCore.Cors;

namespace WorkSampleBookSearch
{

    [Route("api/[controller]")]
    [ApiController]
    public class BooksXmlController : ControllerBase
    {
        private readonly IXmlDbFactory _db;
        public BooksXmlController(IXmlDbFactory db)
        {
            _db = db;
        }

        /// <summary>
        /// Retrieve all items from Books.
        /// </summary>
        /// <returns>Books items List</returns>
        // GET: api/BooksXml
        [EnableCors("AllowSpecificOrigin")]
        [HttpGet]
        public IActionResult GetBookItems()
        {
            List<BookItem> BookItems = new List<BookItem>();
            XDocument doc = _db.GetXmlDb();
            List<BookItem> bookitems = doc.Descendants("book").Select(x => new BookItem()
            {
                Id = (string)x.Attribute("id"),
                Author = (string)x.Element("author"),
                Title = (string)x.Element("title"),
                Genre = (string)x.Element("genre"),
                Price = (decimal)x.Element("price"),
                Publish_date = (DateTime)x.Element("publish_date"),
                Description = (string)x.Element("description")
            }).ToList();
            return Ok(bookitems);
        }

        /// <summary>
        /// Returns a Book item matching the given id.
        /// </summary>
        /// <param name="id">Id of item to be retrieved</param>
        /// <returns>Book item</returns>
        // GET: api/BooksXml/5
        [EnableCors("AllowSpecificOrigin")]
        [HttpGet("{id}")]
        public IActionResult GetBookItems(string id)
        {
            XDocument doc = _db.GetXmlDb();
            XElement result = doc.Descendants("book").FirstOrDefault(el => el.Attribute("id") != null &&
                         el.Attribute("id").Value == id);
            List<BookItem> BookItems = new List<BookItem>();
            if (result != null)
            {
                BookItem Book = new BookItem();
                Book.Id = (string)result.Attribute("id");
                Book.Author = (string)result.Element("author");
                Book.Title = (string)result.Element("title");
                Book.Genre = (string)result.Element("genre");
                Book.Price = (decimal)result.Element("price");
                Book.Publish_date = (DateTime)result.Element("publish_date");
                Book.Description = (string)result.Element("description");
                BookItems.Add(Book);
            }
            return Ok(BookItems);
        }

        [EnableCors("AllowSpecificOrigin")]
        [HttpGet("title/{title}")]
        public IActionResult GetBookItemsByTitle(string title)
        {
            XDocument doc = _db.GetXmlDb();
            var books = doc.Root.Elements("book")
                    .Where(x => x.Element("title").Value.ToLower().Contains(title.ToLower()))
                    .Select(x => new BookItem
                    {
                        Id = x.Attribute("id").Value,
                        Author = x.Element("author").Value,
                        Title = x.Element("title").Value,
                        Genre = x.Element("genre").Value,
                        Price = decimal.Parse(x.Element("price").Value.Replace(',', '.'), NumberStyles.Any, CultureInfo.InvariantCulture),
                        Publish_date = Convert.ToDateTime(x.Element("publish_date").Value),
                        Description = x.Element("description").Value
                    }).ToList();
            return Ok(books);
        }

        [EnableCors("AllowSpecificOrigin")]
        [HttpGet("author/{author}")]
        public IActionResult GetBookItemsByAuthor(string author)
        {
            XDocument doc = _db.GetXmlDb();
            var books = doc.Root.Elements("book")
                    .Where(x => x.Element("author").Value.ToLower().Contains(author.ToLower()))
                    .Select(x => new BookItem
                    {
                        Id = x.Attribute("id").Value,
                        Author = x.Element("author").Value,
                        Title = x.Element("title").Value,
                        Genre = x.Element("genre").Value,
                        Price = decimal.Parse(x.Element("price").Value.Replace(',', '.'), NumberStyles.Any, CultureInfo.InvariantCulture),
                        Publish_date = Convert.ToDateTime(x.Element("publish_date").Value),
                        Description = x.Element("description").Value
                    }).ToList();
            return Ok(books);
        }

        [EnableCors("AllowSpecificOrigin")]
        [HttpGet("genre/{genre}")]
        public IActionResult GetBookItemsByGenre(string genre)
        {
            XDocument doc = _db.GetXmlDb();
            var books = doc.Root.Elements("book")
                    .Where(x => x.Element("genre").Value.ToLower().Contains(genre.ToLower()))
                    .Select(x => new BookItem
                    {
                        Id = x.Attribute("id").Value,
                        Author = x.Element("author").Value,
                        Title = x.Element("title").Value,
                        Genre = x.Element("genre").Value,
                        Price = decimal.Parse(x.Element("price").Value.Replace(',', '.'), NumberStyles.Any, CultureInfo.InvariantCulture),
                        Publish_date = Convert.ToDateTime(x.Element("publish_date").Value),
                        Description = x.Element("description").Value
                    }).ToList();
            return Ok(books);
        }

        [EnableCors("AllowSpecificOrigin")]
        [HttpGet("price/{price}")]
        public IActionResult GetBookItemsByPrice(string price)
        {
            XDocument doc = _db.GetXmlDb();
            var books = doc.Root.Elements("book")
                    .Where(x => x.Element("price").Value.ToLower().Contains(price.ToLower()))
                    .Select(x => new BookItem
                    {
                        Id = x.Attribute("id").Value,
                        Author = x.Element("author").Value,
                        Title = x.Element("title").Value,
                        Genre = x.Element("genre").Value,
                        Price = decimal.Parse(x.Element("price").Value.Replace(',', '.'), NumberStyles.Any, CultureInfo.InvariantCulture),
                        Publish_date = Convert.ToDateTime(x.Element("publish_date").Value),
                        Description = x.Element("description").Value
                    }).ToList();
            return Ok(books);
        }
    }
}