using Raven.Client.Documents;
using System;

namespace Database
{
    public class RavenDocumentStore
    {
        //
        private static Lazy<IDocumentStore> store = new Lazy<IDocumentStore>(CreateStore);

        public static IDocumentStore Store => store.Value;

        private static IDocumentStore CreateStore()
        {
            string ravenDBIP = ConfigurationManager.AppSettings["RavenDBEndPoint"];
            IDocumentStore store = new DocumentStore()
            {
                Urls = new[] { ravenDBIP },
                Database = "Scores"
            }.Initialize();

            return store;
        }
    }
}
