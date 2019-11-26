using Raven.Client.Documents;
using System;

namespace EventAPI.RavenDB
{
    public class RavenDocumentStore
    {
        private static Lazy<IDocumentStore> store = new Lazy<IDocumentStore>(CreateStore);
        public static IDocumentStore Store => store.Value;

        private static IDocumentStore CreateStore()
        {
            string connString = Startup.StaticConfig["Production:RavenDBConnection"];
            IDocumentStore store = new DocumentStore()
            {
                Urls = new[] { connString },
                Database = "Event"
            }.Initialize();

            return store;
        }
    }
}
