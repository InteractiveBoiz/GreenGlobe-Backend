using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroupAPI.Graphql.InputTypes
{
    public class GroupInputType : InputObjectGraphType
    {
        public GroupInputType()
        {
            Name = "GroupInput";
            Field<StringGraphType>("ownerId");
            Field<BooleanGraphType>("privacy");
            Field<StringGraphType>("name");
            Field<StringGraphType>("description");
            Field<ListGraphType<StringGraphType>>("members");
        }
    }
}
