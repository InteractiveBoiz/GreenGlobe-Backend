using EventAPI.Model;
using GraphQL.Types;

namespace EventAPI.Graphql.Types
{
    public class EventType : ObjectGraphType<Event>
    {
        public EventType()
        {
            Name = "Event";
            Description = "An Event Created By a User";
            Field(x => x.Id).Description("The ID of the item.");
            Field(x => x.HostId).Description("The HostID of the item.");
            Field(x => x.IsPublicEvent).Description("If item is public or private.");
            Field(x => x.IsOrganized).Description("Wether the event is organized or unorganized.");
            Field(x => x.EventName).Description("The Eventname of the item.");
            Field(x => x.EventActivity, type: typeof(ListGraphType<EventActivityEnumType>)).Description("The ID of the item.");
            Field(x => x.EventDescription).Description("The EventDescription of the item.");
            Field(x => x.EventRequirements, type: typeof(ListGraphType<StringGraphType>)).Description("The requirements for joining event.");
            Field(x => x.EventDate, type: typeof(DateGraphType)).Description("The Start Date of the item.");
            Field(x => x.EventCreated, type: typeof(DateGraphType)).Description("The Date of when the Event was created.");
            Field(x => x.EventEnd, type: typeof(DateGraphType)).Description("The Date of when the Event ends.");
            Field(x => x.Attendees, type: typeof(ListGraphType<StringGraphType>)).Description("The IDs of the attendees to the event.");
        }
    }
}
