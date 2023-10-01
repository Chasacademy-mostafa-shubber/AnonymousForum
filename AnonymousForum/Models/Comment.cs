using System.ComponentModel.DataAnnotations.Schema;

namespace AnonymousForum.Models
{
    public class Comment
    {
        public int CommentID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int PostID { get; set; }

        [ForeignKey("PostID")]
        public Post Post { get; set; }
    }
}
