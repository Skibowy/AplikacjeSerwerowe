namespace AS_lab1_gr1.Models
{
    public class Author
    {
        public int AuthorId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        // 1 - *
        public virtual ICollection<Article>? Articles { get; set; }
    }
}
