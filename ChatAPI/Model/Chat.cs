using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatAPI.Model
{
    public class Chat
    {
        public string Id { get; set; }
        public Association Association { get; set; }
        public List<string> Members { get; set; }
        public List<Message> Messages { get; set; }
    }

    public enum Association
    {
        Group_Chat = 0,
        Person_Chat = 1,
    }
}
