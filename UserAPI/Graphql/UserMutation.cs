using GraphQL.Types;
using Raven.Client.Documents.Session;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserAPI.Database;
using UserAPI.Graphql.InputTypes;
using UserAPI.Models;

namespace UserAPI.Graphql
{
    public class UserMutation : ObjectGraphType
    {
        public UserMutation()
        {
            Field<Types.UserType>(
                "createUser",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<UserInputType>> { Name = "user", Description = "The user to be created." }),
                resolve: context =>
                {
                    var userObj = context.GetArgument<User>("user");
                    using (IDocumentSession session = RavenDocumentStore.Store.OpenSession())  // Open a session for a default 'Database'
                    {
                        session.Store(userObj); 
                        session.SaveChanges();

                        return userObj;
                    }
                });
        }
    }
}
