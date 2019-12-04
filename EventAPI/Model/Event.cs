using System;

namespace EventAPI.Model
{
    public class Event
    {
        public string Id { get; set; }
        public string HostId { get; set; }

        public bool IsPublicEvent { get; set; }
        public bool IsOrganized { get; set; }
        public EventActivity[] EventActivity { get; set; }
        public string EventName { get; set; }
        public string EventDescription { get; set; }
        public string[] EventRequirements { get; set; }
        public DateTime EventDate { get; set; }
        public DateTime EventCreated { get; set; }
        public DateTime EventEnd { get; set; }
        public string[] Attendees { get; set; }
        //public byte[] images { get; set; }
        //public Map map { get; set; }
    }
    public enum EventActivity
    {
        Cleanup_Small_Items = 0,
        Cleanup_Large_Items = 1,
        Ocean_Lake_River_Cleanup = 2,
        Tree_Planting = 3,
        Flower_Planting = 4,
        Environmental_Landscaping = 5,
        Help_Animals = 6,
        Seminar = 7,
    }
}
