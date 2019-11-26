using System;
using System.Collections.Generic;

namespace UserAPI.Models
{
    public class User
    {
        public string Id { get; set; }
        public UserType UserType { get; set; }
        public Boolean IsVerified { get; set; }
        public String Email { get; set; }
        public String Username { get; set; }
        public String Password { get; set; }
        //public Byte ProfilePicture { get; set; }
        public List<String> FriendsList { get; set; }
        public List<String> GroupsList { get; set; }
    }

    public enum UserType
    {
        User = 0,
        NonUser = 1,
        Organisation = 2,
    }
}
