namespace LibraryApiReforged.Domain.Models
{
    public class UserLesson
    {

        public int UserId { get; set; }
        public User User { get; set; }

        public Guid LessonID { get; set; }
        public Lesson Lesson { get; set; }
    }
}
