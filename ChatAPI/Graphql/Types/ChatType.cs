using ChatAPI.Model;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatAPI.Graphql.Types
{
    public class ChatType : ObjectGraphType<Chat>
    {
        public ChatType()
        {
            Name = "Chat";
            Description = "A Chat associated with either a Group or Relation";
            Field(x => x.Id, type: typeof(StringGraphType)).Description("The ID of the Chat.");
            Field(x => x.Association, type: typeof(ChatAssociationEnumType)).Description("The Association of the Chat.");
            Field(x => x.Members, type: typeof(ListGraphType<StringGraphType>)).Description("The Members of the Chat.");
            Field(x => x.Messages, type: typeof(ListGraphType<MessageType>)).Description("The Association of the Chat.");
        }
    }
}
