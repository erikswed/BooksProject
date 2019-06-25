using WorkSampleBookSearch.Models;

namespace WorkSampleBookSearch.Model
{
    /// <summary>
    /// The class will host different db backend depending on runtime environment.
    /// </summary>
    internal class DbParserResolver
    {
        public static IDbParser DB_PARSER;

        static DbParserResolver()
        {
            // Go for Localhost runtime environment
            DB_PARSER = new LocalHostParser();
            if (DB_PARSER.GetDb() == null)
            {
                // Go for Google Cloud Datastore runtime environment
                DB_PARSER = new GoogleCloudDatastoreParser();

            }
        }
    }
}