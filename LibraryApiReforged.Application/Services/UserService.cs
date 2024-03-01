using LibraryApiReforged.Application.Services.Interfaces;
using LibraryApiReforged.Domain.DTOs;
using LibraryApiReforged.Domain.Models;
using LibraryApiReforged.Infraestructure.Repositories;
using LibraryApiReforged.Infraestructure.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApiReforged.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            ArgumentNullException.ThrowIfNull(userRepository);
            _userRepository = userRepository;
        }

        public async Task<User> AddSkillToUser(int id, Guid skillId)
        {
            var user = await _userRepository.GetUserById(id);

            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }
            await _userRepository.AddSkillToUser(id, skillId);
            return user;
        }

        public async Task<User> CreateUser(UserCreateDto userDto)
        {
            var user = new User
            {
                Username = userDto.Username,
                Name = userDto.Name,
                Password = userDto.Password,
                Email = userDto.Email,
                CreatedAt = DateTime.Now,
                Goals = [],
                UserLessons = [],
                UserSkills = []
            };
            await _userRepository.CreateUser(user);
            return user;
        }

        public async Task<User> DeleteUser(int id)
        {

            var user = await _userRepository.GetUserById(id);

            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            await _userRepository.DeleteUser(user);

            return user!;
        }

        public async Task<User> GetUserById(int id)
        {
            var user = await _userRepository.GetUserById(id);
            return user!;
        }

        public async Task<IEnumerable<User>?> GetUsers()
        {
            var users = await _userRepository.GetUser();
            return users!;
        }

        public async Task<IEnumerable<User>> GetUsersWithoutTracking()
        {
            var users = await _userRepository.GetUserWithoutTracking();
            return users!;
        }

        public async Task<User> UpdateUser(int id, User user)
        {
            var updatedUser = await _userRepository.UpdateUser(id, user);
            return updatedUser;
        }
    }
}
