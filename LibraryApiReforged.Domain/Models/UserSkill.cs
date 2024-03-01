namespace LibraryApiReforged.Domain.Models
{
    public class UserSkill
    {

        public int UserId { get; set; }
        public User User { get; set; }

        public Guid SkillID { get; set; }
        public Skill Skill { get; set; }
    }

}