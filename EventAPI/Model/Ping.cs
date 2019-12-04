using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventAPI.Model
{
    public class Ping
    {
        public string Id { get; set; }
        public string OwnerId { get; set; }
        public List<double> Position { get; set; }
        public string Text { get; set; }
        public DateTime Date { get; set; }
    }
}
