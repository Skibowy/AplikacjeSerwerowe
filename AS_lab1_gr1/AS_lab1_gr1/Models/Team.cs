﻿namespace AS_lab1_gr1.Models
{
    public class Team
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public DateTime FoundingDate { get; set; }
        public ICollection<Player> Players { get; set; }
        public ICollection<Match> Matches { get; set; }
        public League League { get; set; }
    }
}
