namespace AS_lab1_gr1.Models
{
    public class MatchEvent
    {
        public int MatchEventId { get; set; }
        public int Minute { get; set; }

        // * - 1
        public virtual Match? Match { get; set; }
        public int? MatchId { get; set; }

        // * - 1
        public virtual EventType? EventType { get; set; }
        public int? EventTypeId { get; set; }

        // * - 1
        public virtual MatchPlayer? MatchPlayer { get; set; }
        public int? MatchPlayerId { get; set; }
    }
}
