using System.ComponentModel.DataAnnotations;

namespace StudentRestAPI.Models
{
    public class Student : BaseEntity
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public int Age { get; set; }
        [Required]
        public string Email { get; set; }

    }
}
