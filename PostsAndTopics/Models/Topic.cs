using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PostsAndTopics.Models
{
    public class Topic
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public string Theme { get; set; }
        public int UserId { get; set; }
        public List<Post> Posts { get; set; } = new List<Post>();

    }
}
