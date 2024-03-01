using LibraryApiReforged.Domain.DTOs;
using LibraryApiReforged.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApiReforged.Application.Services.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<User>?> GetUsers();
        Task<IEnumerable<User>> GetUsersWithoutTracking();

        Task<User> GetUserById(int id);
        Task<User> CreateUser(UserCreateDto user);
        Task<User> UpdateUser(int id, User user);
        Task<User> DeleteUser(int id);

        Task<User> AddSkillToUser(int id, Guid skillId);
    }
}
