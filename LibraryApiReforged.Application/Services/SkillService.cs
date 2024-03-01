using LibraryApiReforged.Application.Services.Interfaces;
using LibraryApiReforged.Domain.DTOs;
using LibraryApiReforged.Domain.Models;
using LibraryApiReforged.Infraestructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LibraryApiReforged.Application.Services
{
    public class SkillService : ISkillService
    {
        private readonly ISkillRepository _skillRepository;

        public SkillService(ISkillRepository skillRepository)
        {
            ArgumentNullException.ThrowIfNull(skillRepository);
            _skillRepository = skillRepository;
        }

        public async Task<Skill> CreateSkill(SkillCreateDto skillDto)
        {
            var skill = new Skill
            {
                SkillID = new Guid(),
                Name = skillDto.Name,
                Description = skillDto.Description,
                MasteryLevel = skillDto.MasteryLevel,
                UserSkills = [],
                LessonSkills = [],
            };
            await _skillRepository.CreateSkill(skill);
            return skill;
        }

        public async Task<Skill> DeleteSkill(Guid id)
        {
            var skill = await _skillRepository.GetSkillById(id);

            if(skill == null)
            {
                throw new ArgumentNullException(nameof(skill));
            }

            await _skillRepository.DeleteSkill(skill);

            return skill!;
        }

        public async Task<Skill> GetSkillById(Guid id)
        {
            var skill = await _skillRepository.GetSkillById(id);
            return skill!;
        }

        public async Task<IEnumerable<Skill>> GetSkills()
        {
            var skills = await _skillRepository.GetSkills();
            return skills!;
        }

        public async Task<IEnumerable<Skill>> GetSkillsWithoutTracking()
        {
            var skills = await _skillRepository.GetSkillsWithoutTracking();
            return skills;
        }

        public async Task<Skill> UpdateSkill(Guid id, Skill skill)
        {
            var updatedSkill = await _skillRepository.UpdateSkill(id, skill);
            return updatedSkill;
        }
    }
}
