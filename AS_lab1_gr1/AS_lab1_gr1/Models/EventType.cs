namespace AS_lab1_gr1.Models
{
    public class EventType
    {
        public int EventTypeId { get; set; }
        public string Name { get; set; }

        // 1 - *
        public virtual ICollection<MatchEvent>? MatchEvents { get; set; }

    }
}
