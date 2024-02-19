using LibraryApiReforged.Domain.Models;

namespace LibraryApiReforged.Infraestructure.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>?> GetUser();
        Task<IEnumerable<User>?> GetUserWithoutTracking();

        Task<User?> GetUserById(int id);
        Task<User?> CreateUser(User User);
        Task<User?> UpdateUser(int id, User User);
        Task<User?> DeleteUser(User id);

        Task<User?> AddSkillToUser(int id, Guid idSkill);
    }
}
