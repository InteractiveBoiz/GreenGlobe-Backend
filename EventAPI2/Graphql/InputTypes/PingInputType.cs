using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventAPI2.Graphql.InputTypes
{
    public class PingInputType : InputObjectGraphType
    {
        public PingInputType()
        {
            Name = "PingInput";
            Field<StringGraphType>("ownerId");
            Field<ListGraphType<FloatGraphType>>("position");
            Field<StringGraphType>("text");
            Field<DateGraphType>("date");
        }
    }
}
