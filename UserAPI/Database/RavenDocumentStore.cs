using Raven.Client.Documents;
using System;

namespace UserAPI.Database
{
    public class RavenDocumentStore
    {
        private static Lazy<IDocumentStore> store = new Lazy<IDocumentStore>(CreateStore);
        public static IDocumentStore Store => store.Value;

        private static IDocumentStore CreateStore()
        {
            string connString = Startup.StaticConfig["Development:RavenDBConnection"];
            IDocumentStore store = new DocumentStore()
            {
                Urls = new[] { connString },
                Database = "Users"
            }.Initialize();

            return store;
        }
    }
}
