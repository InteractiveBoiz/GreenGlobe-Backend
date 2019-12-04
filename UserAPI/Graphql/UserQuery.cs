using GraphQL.Types;
using Raven.Client.Documents.Session;
using System.Collections.Generic;
using System.Linq;
using UserAPI.Graphql.Types;
using UserAPI.Database;
using UserAPI.Models;

namespace UserAPI.Graphql
{
    public class UserQuery : ObjectGraphType
    {
        public UserQuery()
        {
            Field<UserType>(
                "user",
                arguments: new QueryArguments(
                    new QueryArgument<IdGraphType> { Name = "id", Description = "The ID of the user." }),
                resolve: context =>
                {
                    var id = context.GetArgument<string>("id");

                    using (IDocumentSession session = RavenDocumentStore.Store.OpenSession())  // Open a session for a default 'Database'
                    {
                        //EnsureDatabaseExists.DatabaseExists(RavenDocumentStore.Store, "Scores");
                        User userObj = session.Load<User>(id);

                        return userObj;
                    }
                });

            Field<ListGraphType<UserType>>(
                "users",
                resolve: context =>
                {
                    using (IDocumentSession session = RavenDocumentStore.Store.OpenSession())  // Open a session for a default 'Database'
                    {
                        List<User> users = session
                            .Query<User>()
                            .ToList();

                        return users;
                    }
                });
        }
    }
        
}
