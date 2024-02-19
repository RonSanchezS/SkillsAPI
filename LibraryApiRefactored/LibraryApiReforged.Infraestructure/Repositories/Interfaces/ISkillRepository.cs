using LibraryApiReforged.Domain.Models;

namespace LibraryApiReforged.Infraestructure.Repositories.Interfaces
{
    public interface ISkillRepository
    {
        Task<IEnumerable<Skill>?> GetSkills();
        Task<IEnumerable<Skill>?> GetSkillsWithoutTracking();

        Task<Skill?> GetSkillById(Guid id);
        Task<Skill?> CreateSkill(Skill skill);
        Task<Skill?> UpdateSkill(Guid id, Skill skill);
        Task<Skill?> DeleteSkill(Skill id);
    }
}
