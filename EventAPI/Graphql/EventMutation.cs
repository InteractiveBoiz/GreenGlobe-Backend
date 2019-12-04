using EventAPI.Graphql.Types;
using EventAPI.Model;
using EventAPI.RavenDB;
using GraphQL.Types;
using Microsoft.Extensions.Logging;
using Raven.Client.Documents.Session;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventAPI.Graphql
{
    public class EventMutation : ObjectGraphType
    {
        public EventMutation()
        {
            Field<EventType>(
              "createEvent",
              arguments: new QueryArguments(
                new QueryArgument<NonNullGraphType<EventInputType>> { Name = "event" }
              ),
              resolve: context =>
              {
                  var eventObj = context.GetArgument<Event>("event");
                  using (IDocumentSession session = RavenDocumentStore.Store.OpenSession())  // Open a session for a default 'Database'
                  {
                      session.Store(eventObj);
                      session.SaveChanges();

                      return eventObj;
                  }
              });
            Field<EventType>(
              "updateEvent",
              arguments: new QueryArguments(
                new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "id", Description = "The ID of the event." },
                new QueryArgument<NonNullGraphType<EventInputType>> { Name = "event" }
              ),
              resolve: context =>
              {
                  var id = context.GetArgument<string>("id");

                  Event eventObj = context.GetArgument<Event>("event");
                  using (IDocumentSession session = RavenDocumentStore.Store.OpenSession())  // Open a session for a default 'Database'
                  {
                      Event doc = session.Load<Event>(id);
                      //doc.IsOrganized = eventObj.IsOrganized;
                      if (eventObj.HostId != null)
                      {
                          doc.HostId = eventObj.HostId;
                      }

                      doc.IsPublicEvent = eventObj.IsPublicEvent;
                      doc.IsOrganized = eventObj.IsOrganized;
                      doc.EventActivity = eventObj.EventActivity;
                      doc.EventName = eventObj.EventName;
                      doc.EventDescription = eventObj.EventDescription;
                      doc.EventRequirements = eventObj.EventRequirements;
                      doc.EventDate = eventObj.EventDate;
                      doc.EventCreated = eventObj.EventCreated;
                      doc.EventEnd = eventObj.EventEnd;
                      doc.Attendees = eventObj.Attendees;
                      doc.Map = eventObj.Map;

                      session.SaveChanges();
                    return doc;
                  }
              });
            Field<BooleanGraphType>(
              "deleteEvent",
              arguments: new QueryArguments(
                new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "id", Description = "The ID of the event." }
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
