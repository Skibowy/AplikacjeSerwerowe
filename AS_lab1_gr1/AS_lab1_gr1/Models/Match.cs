namespace AS_lab1_gr1.Models
{
    public class Match
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Stadium { get; set; }
        public ICollection<Article> Articles { get; set; }
        public ICollection<MatchEvent> MatchEvents { get; set; }
        public ICollection<MatchPlayer> MatchPlayers { get; set; }
    }
}
