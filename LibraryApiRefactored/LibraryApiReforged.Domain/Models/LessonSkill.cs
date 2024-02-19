namespace LibraryApiReforged.Domain.Models
{
    public class LessonSkill
    {

        public Guid LessonID { get; set; }
        public Lesson Lesson { get; set; }

        public Guid SkillID { get; set; }
        public Skill Skill { get; set; }
    }
}
