using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatAPI.Graphql.Types
{
    public class ChatAssociationEnumType : EnumerationGraphType
    {
        public ChatAssociationEnumType()
        {
            Name = "ChatAssociationEnumType";
            Description = "The Association between a Chat and a Group or Relation";
            AddValue("Group_Chat", "Group Chat", 0);
            AddValue("Person_Chat", "Person Chat", 1);
        }
    }
}
