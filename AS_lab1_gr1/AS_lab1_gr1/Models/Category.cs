namespace AS_lab1_gr1.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }

        // 1 - *
        public virtual ICollection<Article>? Articles { get; set; }
    }
}
