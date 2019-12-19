using Raven.Client.Documents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatAPI.RavenDB
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
                Database = "Chat"
            }.Initialize();

            return store;
        }
    }
}
