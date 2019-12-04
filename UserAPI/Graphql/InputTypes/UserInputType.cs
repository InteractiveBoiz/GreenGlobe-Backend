using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;
using UserAPI.Graphql.Types;


namespace UserAPI.Graphql.InputTypes
{
    public class UserInputType : InputObjectGraphType
    {
        public UserInputType()
        {
            Name = "UserInput";
            Field<UserCategoryEnumType>("userCategory");
            Field<BooleanGraphType>("isVerified");
            Field<StringGraphType>("email");
            Field<StringGraphType>("username");
            Field<StringGraphType>("password");
            Field<ListGraphType<StringGraphType>>("friendsList");
            Field<ListGraphType<StringGraphType>>("groupsList");
        }
    }
}
