using System.ComponentModel.DataAnnotations.Schema;

namespace AnonymousForum.Models
{
    public class Post
    {
        public int PostID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int TopicID { get; set; }

        [ForeignKey("TopicID")]
        public Topic Topic { get; set; }
    }
}
