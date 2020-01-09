using GraphQL.Types;
using GroupAPI.Graphql.Types;
using GroupAPI.Model;
using GroupAPI.RavenDB;
using Raven.Client.Documents.Session;
using System.Collections.Generic;
using System.Linq;

namespace GroupAPI.Graphql
{
    public class GroupQuery : ObjectGraphType
    {
        public GroupQuery ()
        {
            Field<GroupType>(
                "group",
                arguments: new QueryArguments(
                    new QueryArgument<IdGraphType> { Name = "id", Description = "The ID of the event." }),
                resolve: context =>
                {
                    var id = context.GetArgument<string>("id");

                    using (IDocumentSession session = RavenDocumentStore.Store.OpenSession())  // Open a session for a default 'Database'
                    {
                        Group groupObj = session.Load<Group>(id);

                        return groupObj;
                    }
                });
            Field<ListGraphType<GroupType>>(
                "groups",
                resolve: context =>
                {
                    using (IDocumentSession session = RavenDocumentStore.Store.OpenSession())  // Open a session for a default 'Database'
                    {
                        List<Group> groups = session
                            .Query<Group>()
                            .ToList();

                        return groups;
                    }
                });
        }
    }
}
