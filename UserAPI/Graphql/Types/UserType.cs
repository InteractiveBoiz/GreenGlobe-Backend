using GraphQL.Types;
using UserAPI.Models;

namespace UserAPI.Graphql.Types
{
    public class UserType : ObjectGraphType<User>
    {
        public UserType()
        {
            Name = "User";
            Description = "A User";
            Field(x => x.Id, type: typeof(StringGraphType)).Description("The ID of the User");
            Field(x => x.UserCategory, type: typeof(UserCategoryEnumType)).Description("The UserType of the User"); // IS AN ENUM, THIS IS NOT RIGHT
            Field(x => x.IsVerified, type: typeof(BooleanGraphType)).Description("The verification status of the User");
            Field(x => x.Email, type: typeof(StringGraphType)).Description("The Email of the User");
            Field(x => x.Username, type: typeof(StringGraphType)).Description("The Username of the User");
            Field(x => x.Password, type: typeof(StringGraphType)).Description("The Password of the User");
            // Field(x => x.ProfilePicture).Description("The ProfilePicture of the User");
            Field(x => x.FriendsList, type: typeof(ListGraphType<StringGraphType>)).Description("The List of Friends of the User");
            Field(x => x.GroupsList, type: typeof(ListGraphType<StringGraphType>)).Description("The List of Joined Groups of the User");

        }
    }
}
