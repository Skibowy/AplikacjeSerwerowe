namespace AS_lab1_gr1.Models
{
    public class Player
    {
        public int PlayerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Country { get; set; }
        public DateTime BirthDate { get; set; }

        // 1 - *
        public virtual ICollection<MatchPlayer>? MatchPlayers { get; set; }

        // 1 - *
        public virtual ICollection<Position>? Positions { get; set; }

        // * - 1
        public virtual Team? Team { get; set; }
        public int? TeamId { get; set; }

    }
}
