namespace LibraryApiReforged.Domain.Models
{
    public class Lesson
    {
        public Guid LessonID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Content { get; set; }
        public string DifficultyLevel { get; set; }
        public string DurationEstimate { get; set; }

        // Navigation properties
        public List<UserLesson> UserLessons { get; set; }
        public List<LessonSkill> LessonSkills { get; set; }
    }


}
