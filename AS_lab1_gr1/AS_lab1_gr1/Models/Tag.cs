﻿namespace AS_lab1_gr1.Models
{
    public class Tag
    {
        public int TagId { get; set; }
        public string Name { get; set; }
        public ICollection<Article> Articles { get; set; }
    }
}
