using EventAPI.Model;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventAPI.Graphql.Types
{
    public class MapType : ObjectGraphType<Map>
    {
        public MapType ()
        {
            Name = "Map";
            Description = "An Map Created for an Event";
            Field(x => x.Id).Description("The ID of the item.");
            Field(x => x.MeetUpPosition, type: typeof(ListGraphType<FloatGraphType>)).Description("The Meetup position of the item.");
            Field(x => x.AreaOfInterest, type: typeof(ListGraphType<FloatGraphType>)).Description("The Area of Interest position of the item.");
            Field(x => x.Pings, type: typeof(ListGraphType<PingType>)).Description("The Pings of the item.");
        }
    }
}
