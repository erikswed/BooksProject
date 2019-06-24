using WorkSampleBookSearch.Models;

namespace WorkSampleBookSearch.Model
{
    /// <summary>
    /// Return different db depending on runtime environment.
    /// </summary>
    internal class DbParserResolver
    {
        public static IDbParser DB_PARSER;

        static DbParserResolver()
        {
            DB_PARSER = new GoogleCloudDatastoreParser();

            // Localhost database in local runtime environment
            DB_PARSER = new LocalHostParser();
            if (DB_PARSER == null)
            {
                // Go for Google Cloud Datastore runtime environment
                DB_PARSER = new GoogleCloudDatastoreParser();

            }
        }
    }
}