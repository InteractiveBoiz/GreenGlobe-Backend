using ChatAPI.Graphql.Types;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatAPI.Graphql.InputTypes
{
    public class ChatInputType : InputObjectGraphType
    {
        public ChatInputType()
        {
            Name = "ChatInput";
            Field<ChatAssociationEnumType>("association");
            Field<ListGraphType<StringGraphType>>("members");
            Field<ListGraphType<MessageInputType>>("messages");
        }
    }
}
