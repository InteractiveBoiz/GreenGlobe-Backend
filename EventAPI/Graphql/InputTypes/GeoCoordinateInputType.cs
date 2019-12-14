using GraphQL.Types;

namespace EventAPI.Graphql.InputTypes
{
    public class GeoCoordinateInputType : InputObjectGraphType
    {
        public GeoCoordinateInputType()
        {
            Name = "GeoCoordinateInput";
            Field<FloatGraphType>("latitude");
            Field<FloatGraphType>("longitude");
        }
    }
}
