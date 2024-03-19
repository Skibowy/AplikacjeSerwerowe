namespace AS_lab1_gr1.Models
{
    public class Comment
    {
        public int CommentId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }

        // * - 1
        public virtual Article? Article { get; set; }
        public int? ArticleId { get; set; }
    }
}
