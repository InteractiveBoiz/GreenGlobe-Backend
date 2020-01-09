using GraphQL.Types;
using GroupAPI.Model;

namespace GroupAPI.Graphql.Types
{
    public class GroupType : ObjectGraphType<Group>
    {
        public GroupType()
        {
            Name = "Group";
            Description = "A Group consisting of users";
            Field(x => x.Id).Description("The ID of the Group.");
            Field(x => x.OwnerId, type: typeof(StringGraphType)).Description("The ID of the owner of the Group.");
            Field(x => x.Privacy, type: typeof(BooleanGraphType)).Description("The Privacy of the Group (Public/Private).");
            Field(x => x.Name, type: typeof(StringGraphType)).Description("The Name of the Group.");
            Field(x => x.Description, type: typeof(StringGraphType)).Description("The Description of the Group.");
            Field(x => x.Members, type: typeof(ListGraphType<StringGraphType>)).Description("The List of Group Members.");
            Field(x => x.ChatId, type: typeof(StringGraphType)).Description("The List of Group Members.");
        }
    }
}
