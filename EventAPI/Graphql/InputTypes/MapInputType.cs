using EventAPI.Graphql.Types;
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
            Field<GeoCoordinateInputType>("meetUpPosition");
            Field<ListGraphType<GeoCoordinateInputType>>("areaOfInterest");
            Field<GeoCoordinateInputType>("exitPosition"); 
            Field<ListGraphType<PingInputType>>("pings");
        }
    }
}
