using EventAPI2.Model;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventAPI2.Graphql.Types
{
    public class PingType : ObjectGraphType<Ping>
    {
        public PingType()
        {
            Name = "Ping";
            Description = "An Ping Created for an Event Map";
            Field(x => x.Id).Description("The ID of the item.");
            Field(x => x.OwnerId).Description("The ID of the owner of the item.");
            Field(x => x.Position, type: typeof(ListGraphType<FloatGraphType>)).Description("The Position of the item.");
            Field(x => x.Text).Description("The Text of the item.");
            Field(x => x.Date, type: typeof(DateGraphType)).Description("The Date of when the item was created.");
        }
    }
}
