using BooksProject.Models;

namespace WorkSampleBookSearch
{
    /// <summary>
    /// This class can return differen db´s depending on criteria.
    /// </summary>
    internal class DbParserResolver
    {

        public static IDbParser JSON_PARSER;

        static DbParserResolver()
        {
            bool con = true;
            if (con)
            {            
                // Default is the LocalDbParser 
                JSON_PARSER = new LocalDbParser();

            }
            else
            {
                JSON_PARSER = new RemoteDbParser();

            }

        }
    }
    
}