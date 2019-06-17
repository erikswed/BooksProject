using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;
using WorkSampleBookSearch.Model;

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
        // GET: api/Book
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
        // GET: api/Book/5
        [HttpGet("{id}")]
        public IActionResult GetBookItem(long id)
        {
            XDocument doc = _db.GetXmlDb();
            XElement element = doc.Element("catalog").
                Elements("id").SingleOrDefault(x => x.Value == id.ToString());

            XElement parent = element.Parent;

            //BookItem bookitem = new BookItem
            //{
            //    Id = element.Element("id").Value,
            //    Author = element.Element("author").Value,
            //    Title = element.Element("title").Value,
            //    Genre = element.Element("genre").Value,
            //    Price = element.Element("price").Value,
            //    Publish_date = element.Element("publish_date").Value,
            //    Description = element.Element("description").Value
            //};
            return null; // Ok(bookitem);
        }

        /// <summary>
        /// Insert a Book item.
        /// </summary>
        /// <returns>Inserts new Book item in books.xml and saves the file</returns>
        //POST: api/Book
        [HttpPost]
        public void PostBookItem(BookItem BookItem)
        {
            int maxId;
            XDocument doc = _db.GetXmlDb();
            bool elementExist = doc.Descendants("catalog").Any();
            if (elementExist)
            {
                maxId = doc.Descendants("catalog").Max(x => (int)x.Element("id"));
            }
            else
            {
                maxId = 0;
            }
            /// Id 
            /// Author
            /// Title
            /// Genre
            /// Price
            /// Price
            /// Publish_date
            /// Description
            XElement root = new XElement("catalog");
            root.Add(new XElement("id", maxId + 1));
            root.Add(new XElement("author", BookItem.Author));
            root.Add(new XElement("title", BookItem.Title));
            root.Add(new XElement("genre", BookItem.Genre));
            root.Add(new XElement("price", BookItem.Price));
            root.Add(new XElement("publish_date", BookItem.Publish_date));
            root.Add(new XElement("description", BookItem.Description));
            doc.Element("catalog").Add(root);
            doc.Save("books.xml");
        }

        /// <summary>
        /// Updates a Book item matching the given id.
        /// </summary>
        /// <param name="id">Id of item to be retrieved</param>
        /// <param name="BookItem">Retrieved Book item</param>
        /// <returns>Updates Book item in books.xml and saves the file</returns>
        //PUT: api/Book/5
        [HttpPut("{id}")]
        public void PostBookItem(long id, BookItem BookItem)
        {
            XDocument doc = _db.GetXmlDb();

            var items = from item in doc.Descendants("catalog")
                        where item.Element("id").Value == id.ToString()
                        select item;

            foreach (XElement itemElement in items)
            {
                /// Id 
                /// Author
                /// Title
                /// Genre
                /// Price
                /// Publish_date
                /// Description
                itemElement.SetElementValue("author",BookItem.Author);
                itemElement.SetElementValue("title", BookItem.Title);
                itemElement.SetElementValue("genre", BookItem.Genre);
                itemElement.SetElementValue("price", BookItem.Price);
                itemElement.SetElementValue("publish_date", BookItem.Publish_date);
                itemElement.SetElementValue("description", BookItem.Description);

            }

            doc.Save("books.xml");
        }

        /// <summary>
        /// Delete a Book item matching the given id.
        /// </summary>
        /// <param name="id">Id of item to be retrieved</param>
        /// <returns>Deletes item from books.xml and saves the file</returns>
        // DELETE: api/Book/5
        [HttpDelete("{id}")]
        public void DeleteBookItem(long id)
        {

            XDocument doc = _db.GetXmlDb();
            var elementToDelete = from item in doc.Descendants("catalog")
                                  where item.Element("id").Value == id.ToString()
                                  select item;

            elementToDelete.Remove();

            doc.Save("books.xml");
        }
    }
}