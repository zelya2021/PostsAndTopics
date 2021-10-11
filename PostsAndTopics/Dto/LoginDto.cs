using System.ComponentModel.DataAnnotations;

namespace PostsAndTopics.Dto
{
    public class LoginDto
    {
        [Required]
        [StringLength(20, MinimumLength = 3)]
        public string userName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string password { get; set; }
    }
}