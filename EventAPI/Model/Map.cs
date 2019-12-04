using System.Collections.Generic;

namespace EventAPI.Model
{
    public class Map
    {
        public string Id { get; set; }
        public List<double> MeetUpPosition { get; set; }
        public List<double> AreaOfInterest { get; set; }
        public List<Ping> Pings { get; set; }
    }
}
