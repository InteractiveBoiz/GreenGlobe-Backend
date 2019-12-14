using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroupAPI.Model
{
    public class Group
    {
        public string Id { get; set; }
        public string OwnerId { get; set; }
        public bool Privacy { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<string> Members { get; set; }
    }
}
