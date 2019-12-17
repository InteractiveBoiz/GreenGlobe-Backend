using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatAPI.Model
{
    public class Message
    {
        public string Id { get; set; }
        public string Owner { get; set; }
        public string Text { get; set; }
        public DateTime MessageDateTime { get; set; }
    }
}
