using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PostsAndTopics.Dto
{
    public class TopicDto
    {
        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string Theme { get; set; }
        public int UserId { get; set; }
    }
}
