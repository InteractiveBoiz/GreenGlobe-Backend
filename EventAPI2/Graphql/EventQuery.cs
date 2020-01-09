using EventAPI2.Graphql.Types;
using EventAPI2.Model;
using EventAPI2.RavenDB;
using GraphQL.Types;
using Raven.Client.Documents.Session;
using System.Collections.Generic;
using System.Linq;

namespace EventAPI2.Graphql
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
            Field<ListGraphType<EventType>>(
                "attendingEvents",
                arguments: new QueryArguments(
                    new QueryArgument<IdGraphType> { Name = "userId", Description = "The ID of the event." }
                ),
                resolve: context =>
                {
                    var userId = context.GetArgument<string>("userId");

                    using (IDocumentSession session = RavenDocumentStore.Store.OpenSession())  // Open a session for a default 'Database'
                    {
                        List<Event> docs = session.Query<Event>()
                                              .Where(x => x.Attendees.Contains(userId))
                                              .ToList();

                        return docs;
                    }
                });
            Field<ListGraphType<EventType>>(
                "hostingEvents",
                arguments: new QueryArguments(
                    new QueryArgument<IdGraphType> { Name = "userId", Description = "The ID of the event." }
                ),
                resolve: context =>
                {
                    var userId = context.GetArgument<string>("userId");

                    using (IDocumentSession session = RavenDocumentStore.Store.OpenSession())  // Open a session for a default 'Database'
                    {
                        List<Event> docs = session.Query<Event>()
                                              .Where(x => x.HostId.Equals(userId))
                                              .ToList();

                        return docs;
                    }
                });
        }
            
    }
}
