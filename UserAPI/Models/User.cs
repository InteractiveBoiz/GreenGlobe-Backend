using System;
using System.Collections.Generic;

namespace UserAPI.Models
{
    public class User
    {
        public string Id { get; set; }
        public UserType UserType { get; set; }
        public bool IsVerified { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        //public Byte ProfilePicture { get; set; }
        public List<string> FriendsList { get; set; }
        public List<string> GroupsList { get; set; }
    }

    public enum UserType
    {
        User = 0,
        NonUser = 1,
        Organisation = 2,
    }
}
