using LibraryApiReforged.Domain.Models;
using LibraryApiReforged.Infraestructure.Context;
using LibraryApiReforged.Infraestructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LibraryApiReforged.Infraestructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly LibraryDbContext _context;

        public UserRepository(LibraryDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<User>?> GetUser()
        {
            var users = await Task.FromResult(
                _context.Users.AsNoTracking()
                     .Select(u => new User
                     {
                         Id = u.Id,
                         Username = u.Username,
                         Name = u.Name,
                         Email = u.Email,
                         Password = u.Password,
                         CreatedAt = u.CreatedAt
                     })
                     .ToListAsync());
            return users.Result;
        }

        public async Task<IEnumerable<User>?> GetUserWithoutTracking()
        {
            var users = await Task.FromResult(
                _context.Users.AsNoTracking()
                     .Select(u => new User
                     {
                         Id = u.Id,
                         Username = u.Username,
                         Name = u.Name,
                         Email = u.Email,
                         Password = u.Password,
                         CreatedAt = u.CreatedAt
                     })
                     .ToListAsync());
            return users.Result;
        }

        public async Task<User?> GetUserById(int id)
        {
            var foundUser = await Task.FromResult(_context.Users.Include(u => u.UserSkills).ThenInclude(us => us.Skill).FirstOrDefaultAsync(s => s.Id == id));
            if (foundUser != null)
            {
                return foundUser.Result;
            }
            return null;
        }

        public async Task<User> CreateUser(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
            return user;
        }

        public async Task<User?> DeleteUser(User id)
        {

            var userInDB= await _context.Users.FirstOrDefaultAsync(s => s.Id == id.Id);

            if (userInDB != null)
            {
                _context.Users.Remove(userInDB);
                await _context.SaveChangesAsync();
                return userInDB;
            }

            return null;

        }

        public async Task<User?> UpdateUser(int id, User User)
        {
            var userInDB = _context.Users.FirstOrDefault(u => u.Id == id);

            if (userInDB == null)
            {
                return null;
            }

            userInDB.UserLessons = User.UserLessons;
            userInDB.Username = User.Username;
            userInDB.UserSkills = User.UserSkills;
            userInDB.Goals = User.Goals;
            userInDB.Email = User.Email;
            userInDB.Password = User.Password;


            _context.SaveChanges();

            return userInDB;
        }

        public async Task<User> AddSkillToUser(int userId, Guid skillId)
        {
            // Buscar el usuario por su Id
            var user = _context.Users.FirstOrDefault(u => u.Id == userId);

            // Buscar la habilidad por su SkillID
            var skill = _context.Skills.FirstOrDefault(s => s.SkillID == skillId);

            // Agregar la habilidad al usuario
            _context.UserSkills.Add(new UserSkill { UserId = userId, SkillID = skillId });

            _context.SaveChanges();

            return user;
        }
    }
}
