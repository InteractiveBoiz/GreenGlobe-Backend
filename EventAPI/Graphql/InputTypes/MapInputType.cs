using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventAPI.Graphql.InputTypes
{
    public class MapInputType : InputObjectGraphType
    {
        public MapInputType()
        {
            Name = "MapInput";
            Field<ListGraphType<FloatGraphType>>("meetUpPosition");
            Field<ListGraphType<FloatGraphType>>("areaOfInterest");
            Field<ListGraphType<PingInputType>>("pings");
        }
    }
}
