﻿using EventAPI.Graphql.InputTypes;
using EventAPI.Model;
using GraphQL.Types;


namespace EventAPI.Graphql.Types
{
    public class EventInputType : InputObjectGraphType
    {
        public EventInputType ()
        {
            Name = "EventInput";
            Field<StringGraphType>("hostId");
            Field<BooleanGraphType>("isPublicEvent");
            Field<BooleanGraphType>("isOrganized");
            Field<ListGraphType<EventActivityEnumType>>("eventActivity");
            Field<StringGraphType>("eventName");
            Field<StringGraphType>("eventDescription");
            Field<ListGraphType<StringGraphType>>("eventRequirements");
            Field<DateGraphType>("eventDate");
            Field<DateGraphType>("eventCreated");
            Field<DateGraphType>("eventEnd");
            Field<ListGraphType<StringGraphType>>("attendees");
            Field<MapInputType>("map");
            Field<StringGraphType>("chatId");
        }
    }
}
