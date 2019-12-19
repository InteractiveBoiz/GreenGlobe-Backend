using ChatAPI.Graphql.Types;
using ChatAPI.Model;
using ChatAPI.RavenDB;
using GraphQL.Types;
using Raven.Client.Documents.Session;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatAPI.Graphql
{
    public class ChatQuery : ObjectGraphType
    {
        public ChatQuery ()
        {
            Field<ChatType>(
                "chat",
                arguments: new QueryArguments(
                    new QueryArgument<IdGraphType> { Name = "id", Description = "The ID of the chat." }),
                resolve: context =>
                {
                    var id = context.GetArgument<string>("id");

                    using (IDocumentSession session = RavenDocumentStore.Store.OpenSession())  // Open a session for a default 'Database'
                    {
                        //EnsureDatabaseExists.DatabaseExists(RavenDocumentStore.Store, "Scores");
                        Chat chatObj = session.Load<Chat>(id);

                        return chatObj;
                    }
                });
            Field<ListGraphType<ChatType>>(
                "chats",
                resolve: context =>
                {
                    using (IDocumentSession session = RavenDocumentStore.Store.OpenSession())  // Open a session for a default 'Database'
                    {
                        List<Chat> chats = session
                            .Query<Chat>()
                            .ToList();

                        return chats;
                    }
                });
        }
    }
}
