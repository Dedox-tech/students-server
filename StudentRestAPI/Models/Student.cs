using System.ComponentModel.DataAnnotations;

namespace StudentRestAPI.Models
{
    public class Student
    {
        [Required]
        public string Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int Age { get; set; }
        [Required]
        public string Email { get; set; }

    }
}
