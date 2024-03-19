namespace AS_lab1_gr1.Models
{
    public class League
    {
        public int LeagueId { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public int Level { get; set; }

        // 1 - *
        public virtual ICollection<Team>? Teams { get; set; }
    }
}
