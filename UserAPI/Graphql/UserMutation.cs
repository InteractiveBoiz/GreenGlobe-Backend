using GraphQL.Types;
using Raven.Client.Documents.Session;
using UserAPI.Database;
using UserAPI.Graphql.InputTypes;
using UserAPI.Graphql.Types;
using UserAPI.Models;

namespace UserAPI.Graphql
{
    public class UserMutation : ObjectGraphType
    {
        public UserMutation()
        {
            Field<UserType>(
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
            Field<UserType>(
                "updateUser",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<UserInputType>> { Name = "user", Description = "The user to be updated." },
                    new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "id" }
                    ),
                resolve: context =>
                {
                    var id = context.GetArgument<string>("id");

                    User userObj = context.GetArgument<User>("user");
                    using (IDocumentSession session = RavenDocumentStore.Store.OpenSession())
                    {
                        User user = session.Load<User>(id);

                        user.Email = userObj.Email;
                        user.Username = userObj.Username;
                        user.Password = userObj.Password;
                        user.IsVerified = userObj.IsVerified;
                        user.GroupsList = userObj.GroupsList;
                        user.UserCategory = userObj.UserCategory;
                        user.FriendsList = userObj.FriendsList;

                        session.SaveChanges();
                        return user;
                    }
                });
            Field<BooleanGraphType>(
                "deleteUser",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "id", Description = "The id of the user to be deleted" }
                    ),
                resolve: context =>
                {
                    var id = context.GetArgument<string>("id");
                    using (IDocumentSession session = RavenDocumentStore.Store.OpenSession())
                    {
                        session.Delete(id);
                        session.SaveChanges();

                        return true;
                    }
                });
        }
    }
}
