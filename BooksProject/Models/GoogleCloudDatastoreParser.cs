using System;
using Google.Cloud.Storage.V1;
using System.Xml.Linq;
using System.IO;

namespace WorkSampleBookSearch.Models
{
    /// <summary>
    /// Returns a Google Cloud Datastore type of db
    /// </summary>
    public class GoogleCloudDatastoreParser : IDbParser
    {
        public XDocument GetDb()
        {
            XDocument doc;
            try
            {
                var storage = StorageClient.Create();
                var stream = new MemoryStream();
                storage.DownloadObject("angular-book-app-bucket", "books.xml", stream);
                stream.Seek(0, SeekOrigin.Begin);
                doc = XDocument.Load(stream);
                return doc;
            }
            catch
            {
                return null;
            }
        }
    }
}
