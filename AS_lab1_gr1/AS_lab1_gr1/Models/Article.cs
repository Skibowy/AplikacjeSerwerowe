namespace AS_lab1_gr1.Models
{
    public class Article
    {
        public int ArticleId { get; set; }
        public string Title { get; set; }
        public string Lead { get; set; }
        public string Content { get; set; }
        public DateTime CreationDate { get; set; }

        // * - 1
        public virtual Category? Category { get; set; }
        public int? CategoryId { get; set; }

        // * - 1
        public virtual Author? Author { get; set; }
        public int? AuthorId { get; set; }

        // * - 1
        public virtual Match? Match { get; set; }
        public int? MatchId { get; set; }

        // 1 - *
        public virtual ICollection<Comment>? Comments { get; set; }

        // * - *
        public virtual ICollection<Tag>? Tags { get; set; }
    }
}
