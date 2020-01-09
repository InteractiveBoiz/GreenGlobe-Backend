using GraphQL.Types;
using GroupAPI.Graphql.InputTypes;
using GroupAPI.Graphql.Types;
using GroupAPI.Model;
using GroupAPI.RavenDB;
using Raven.Client.Documents.Session;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroupAPI.Graphql
{
    public class GroupMutation : ObjectGraphType
    {
        public GroupMutation ()
        {
            Field<GroupType>(
              "createGroup",
              arguments: new QueryArguments(
                new QueryArgument<NonNullGraphType<GroupInputType>> { Name = "group" }
              ),
              resolve: context =>
              {
                  var groupObj = context.GetArgument<Group>("group");
                  using (IDocumentSession session = RavenDocumentStore.Store.OpenSession())  // Open a session for a default 'Database'
                  {
                      session.Store(groupObj);
                      session.SaveChanges();

                      return groupObj;
                  }
              });
            Field<GroupType>(
              "updateGroup",
              arguments: new QueryArguments(
                new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "id", Description = "The ID of the group." },
                new QueryArgument<NonNullGraphType<GroupInputType>> { Name = "group" }
              ),
              resolve: context =>
              {
                  var id = context.GetArgument<string>("id");

                  Group eventObj = context.GetArgument<Group>("group");
                  using (IDocumentSession session = RavenDocumentStore.Store.OpenSession())  // Open a session for a default 'Database'
                  {
                      Group doc = session.Load<Group>(id);
                      doc.OwnerId = eventObj.OwnerId;
                      doc.Privacy = eventObj.Privacy;
                      doc.Name = eventObj.Name;
                      doc.Description = eventObj.Description;
                      doc.Members = eventObj.Members;

                      session.SaveChanges();
                      return doc;
                  }
              });
            Field<BooleanGraphType>(
              "deleteGroup",
              arguments: new QueryArguments(
                new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "id", Description = "The ID of the group." }
              ),
              resolve: context =>
              {
                  var id = context.GetArgument<string>("id");
                  using (IDocumentSession session = RavenDocumentStore.Store.OpenSession())  // Open a session for a default 'Database'
                  {
                      session.Delete(id);
                      session.SaveChanges();

                      return true;
                  }
              });
        }
    }
}
