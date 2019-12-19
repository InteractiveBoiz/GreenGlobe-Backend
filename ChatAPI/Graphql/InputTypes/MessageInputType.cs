using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatAPI.Graphql.InputTypes
{
    public class MessageInputType : InputObjectGraphType
    {
        public MessageInputType()
        {
            Name = "MessageInput";
            Field<StringGraphType>("owner");
            Field<StringGraphType>("text");
            Field<DateTimeGraphType>("messageDateTime");
        }
    }
}
