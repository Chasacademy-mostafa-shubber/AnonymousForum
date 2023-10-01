using System.ComponentModel.DataAnnotations;

namespace AnonymousForum.Models
{
    public class ViewModels
    {
        public Topic Topic { get; set; }
        public Post Post { get; set; }
        public Comment Comment { get; set; }


        [Required]
        public string Title { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }

    }
}
