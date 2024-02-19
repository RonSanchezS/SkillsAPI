

using LibraryApiReforged.Domain.DTOs;
using LibraryApiReforged.Domain.Models;

namespace LibraryApiReforged.Application.Services.Interfaces
{
    public interface ISkillService
    {

        Task<IEnumerable<Skill>?> GetSkills();
        Task<IEnumerable<Skill>> GetSkillsWithoutTracking();

        Task<Skill> GetSkillById(Guid id);
        Task<Skill> CreateSkill(SkillCreateDto skill);
        Task<Skill> UpdateSkill(Guid id, Skill skill);
        Task<Skill> DeleteSkill(Guid id);
    }
}
