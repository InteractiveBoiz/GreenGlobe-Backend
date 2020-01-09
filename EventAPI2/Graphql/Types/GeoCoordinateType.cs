using EventAPI2.Model;
using GraphQL.Types;

namespace EventAPI2.Graphql.Types
{
    public class GeoCoordinateType : ObjectGraphType<GeoCoordinate>
    {
        public GeoCoordinateType()
        {
            Name = "GeoCoordinate";
            Description = "An GeoCoordinate for an Map";
            Field(x => x.Latitude, type: typeof(FloatGraphType)).Description("The latitude of the point.");
            Field(x => x.Longitude, type: typeof(FloatGraphType)).Description("The longitude of the point");
        }
    }
}
