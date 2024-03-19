namespace AS_lab1_gr1.Models
{
    public class Team
    {
        public int TeamId { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public DateTime FoundingDate { get; set; }

        // 1 - *
        public virtual ICollection<Player>? Players { get; set; }

        // 1 - *
        public virtual ICollection<Match> HomeMatches { get; set; }
        public virtual ICollection<Match> AwayMatches { get; set; }

        // * - 1
        public virtual League? League { get; set; }
        public int? LeagueId { get; set; }
    }
}
