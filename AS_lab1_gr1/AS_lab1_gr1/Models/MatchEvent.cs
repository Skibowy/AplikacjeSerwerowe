namespace AS_lab1_gr1.Models
{
    public class MatchEvent
    {
        public int MatchEventId { get; set; }
        public int Minute { get; set; }
        public Match Match { get; set; }
        public EventType EventType { get; set; }
        public MatchPlayer MatchPlayer { get; set; }
    }
}
