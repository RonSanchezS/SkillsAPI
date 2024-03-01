namespace LibraryApiReforged.Domain.Models
{
    public class Skill
    {
        public Guid SkillID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string MasteryLevel { get; set; }

        // Navigation
        public List<UserSkill> UserSkills { get; set; }
        public List<LessonSkill> LessonSkills { get; set; }
    }
}
