using GraphQL.Types;

namespace UserAPI.Graphql.Types
{
    public class UserCategoryEnumType : EnumerationGraphType
    {
        public UserCategoryEnumType()
        {
            Name = "UserCategory";
            Description = "The category of this user";
            AddValue("User", "Is a user", 0);
            AddValue("NonUser", "Is not a user", 1);
            AddValue("Organisation", "Is an organisation", 2);
        }
    }
}
