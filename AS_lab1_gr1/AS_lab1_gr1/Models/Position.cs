namespace AS_lab1_gr1.Models
{
    public class Position
    {
        public int PositionId { get; set; }
        public string Name { get; set; }

        // 1 - *
        public virtual ICollection<MatchPlayer>? MatchPlayers { get; set; }

        // 1 - *
        public virtual ICollection<Player>? Player { get; set; }
    }
}
