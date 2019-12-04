using EventAPI.Graphql.Types;
using EventAPI.Model;
using EventAPI.RavenDB;
using GraphQL.Types;
using Raven.Client.Documents.Session;
using System.Collections.Generic;
using System.Linq;

namespace EventAPI.Graphql
{
    public class EventQuery : ObjectGraphType
    {
        public EventQuery()
        {
            Field<EventType>(
                "event",
                arguments: new QueryArguments(
                    new QueryArgument<IdGraphType> { Name = "id", Description = "The ID of the event." }),
                resolve: context =>
                {
                    var id = context.GetArgument<string>("id");

                    using (IDocumentSession session = RavenDocumentStore.Store.OpenSession())  // Open a session for a default 'Database'
                    {
                        //EnsureDatabaseExists.DatabaseExists(RavenDocumentStore.Store, "Scores");
                        Event eventObj = session.Load<Event>(id);
                   
                        return eventObj;
                    }
                });
            Field<ListGraphType<EventType>>(
                "events",
                resolve: context =>
                {
                    using (IDocumentSession session = RavenDocumentStore.Store.OpenSession())  // Open a session for a default 'Database'
                    {
                        List<Event> events = session
                            .Query<Event>()
                            .ToList();

                        return events;
                    }
                });
        }
            
    }
}
