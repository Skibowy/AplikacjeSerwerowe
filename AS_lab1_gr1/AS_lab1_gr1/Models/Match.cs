namespace AS_lab1_gr1.Models
{
    public class Match
    {
        public int MatchId { get; set; }
        public DateTime Date { get; set; }
        public string Stadium { get; set; }

        // 1 - *
        public virtual ICollection<Article>? Articles { get; set; }

        // 1 - *
        public virtual ICollection<MatchEvent>? MatchEvents { get; set; }

        // 1 - *
        public virtual ICollection<MatchPlayer>? MatchPlayers { get; set; }

        // * - 1
        public virtual Team HomeTeam { get; set; }
        public int HomeTeamId { get; set; }
        public virtual Team AwayTeam { get; set; }
        public int AwayTeamId { get; set; }
    }
}
