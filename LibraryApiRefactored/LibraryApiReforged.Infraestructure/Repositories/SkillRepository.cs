using LibraryApiReforged.Domain.Models;
using LibraryApiReforged.Infraestructure.Context;
using LibraryApiReforged.Infraestructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LibraryApiReforged.Infraestructure.Repositories
{
    public class SkillRepository : ISkillRepository
    {
        private readonly LibraryDbContext _context;

        public SkillRepository(LibraryDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Skill>> GetSkills()
        {
            var skillsTask = await Task.FromResult(_context.Skills.ToListAsync());
            return skillsTask.Result;
        }

        public async Task<IEnumerable<Skill>?> GetSkillsWithoutTracking()
        {
            var skillsTask = await Task.FromResult(_context.Skills.AsNoTracking().ToListAsync());
            return skillsTask.Result;
        }

        public async Task<Skill> GetSkillById(Guid id)
        {
            var foundSkill = await Task.FromResult(_context.Skills.FirstOrDefaultAsync(s=>s.SkillID == id));
            if (foundSkill != null)
            {
                return foundSkill.Result;
            }
            return null;
        }

        public async Task<Skill> CreateSkill(Skill skill)
        {
            _context.Skills.Add(skill);
            _context.SaveChanges();
            return skill;
        }

        public async Task<Skill> UpdateSkill(Guid id, Skill skill)
        {

            var skillInDb = _context.Skills.FirstOrDefault(s => s.SkillID == id);

            if (skillInDb == null)
            {
                return null;
            }

            skillInDb.Name = skill.Name;
            skillInDb.Description = skill.Description;
            skillInDb.MasteryLevel = skill.MasteryLevel;

            _context.SaveChanges();

            return skillInDb;
        }

        public async Task<Skill> DeleteSkill(Skill skill)
        {
            var skillInDB = await _context.Skills.FirstOrDefaultAsync(s => s.SkillID == skill.SkillID);

            if (skillInDB != null)
            {
                _context.Skills.Remove(skillInDB);
                await _context.SaveChangesAsync();
                return skillInDB;
            }

            return null; 
        }

    }
}
