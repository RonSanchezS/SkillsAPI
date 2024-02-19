using System.ComponentModel.DataAnnotations;

namespace LibraryApiReforged.Domain.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string Username { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 3)]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 6)]
        public string Password { get; set; }

        public DateTime CreatedAt { get; set; }

        // Navigation properties
        public List<Goal> Goals { get; set; }
        public List<UserSkill> UserSkills { get; set; }
        public List<UserLesson> UserLessons { get; set; }
    }
}
