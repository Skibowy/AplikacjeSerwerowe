namespace AS_lab1_gr1.Models
{
    public class EventType
    {
        public int EventTypeId { get; set; }
        public string Name { get; set; }
        public ICollection<MatchEvent> MatchEvents { get; set; }

    }
}
