using System.Collections.Generic;

namespace EventAPI.Model
{
    public class Map
    {
        public string Id { get; set; }
        public GeoCoordinate MeetUpPosition { get; set; }
        public List<GeoCoordinate> AreaOfInterest { get; set; }
        public GeoCoordinate ExitPosition { get; set; }
        public List<Ping> Pings { get; set; }
    }
}
