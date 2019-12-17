using ChatAPI.Model;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatAPI.Graphql.Types
{
    public class MessageType : ObjectGraphType<Message>
    {
        public MessageType()
        {
            Name = "Message";
            Description = "A Message inside of a Chat";
            Field(x => x.Id, type: typeof(StringGraphType)).Description("The ID of the Message.");
            Field(x => x.Owner, type: typeof(StringGraphType)).Description("The Owner of the Message.");
            Field(x => x.Text, type: typeof(StringGraphType)).Description("The Text of the Message.");
            Field(x => x.MessageDateTime, type: typeof(DateTimeGraphType)).Description("The Datetime of the Message.");
        }
    }
}
