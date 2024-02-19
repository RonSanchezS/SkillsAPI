using Azure;
using LibraryApiReforged.Application.Services;
using LibraryApiReforged.Application.Services.Interfaces;
using LibraryApiReforged.Domain.DTOs;
using LibraryApiReforged.Domain.Models;
using LibraryApiReforged.Infraestructure.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LibraryApiReforged.Controllers
{

    [Route("api/[controller]s")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetAll()
        {
            var users = _userService.GetUsers();
            if(users == null)
            {
                return NoContent();
            }
            return Ok(users);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetById(int id)
        {
            if (id == 0)
            {
                throw new BadHttpRequestException("ID cannot be empty.");
            }

            var user = _userService.GetUserById(id);
            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        [HttpPost(Name = "Create User")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        public IActionResult Create([FromBody] UserCreateDto user)
        {
            var createdUser = _userService.CreateUser(user);
            return CreatedAtRoute("Create User", createdUser);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Update(int id, [FromBody] User user)
        {
            var updatedUser = _userService.UpdateUser(id, user);
            return Ok(updatedUser);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Delete(int id)
        { 

            var user = _userService.DeleteUser(id);
            var response = new { message = $"User with id {id} was deleted", user };
            return Ok(response);
        }


        [HttpPost("{userId}/AddSkill/{skillId}")]
        public IActionResult AddSkillToUser(int userId, Guid skillId)
        {
            var result = _userService.AddSkillToUser(userId, skillId);
            var response = new { message = $"User with id {userId} was added a new Skill!", skillId};
            return Ok(response);
            /*
        try
        {

            // Buscar el usuario por su Id
            var user = _context.Users.FirstOrDefault(u => u.Id == userId);

            if (user == null)
            {
                return NotFound("User not found");
            }

            // Buscar la habilidad por su SkillID
            var skill = _context.Skills.FirstOrDefault(s => s.SkillID == skillId);

            if (skill == null)
            {
                return NotFound("Skill not found");
            }

            // Verificar si el usuario ya tiene esta habilidad
            if (_context.UserSkills.Any(us => us.UserId == userId && us.SkillID == skillId))
            {
                return BadRequest("User already has this skill");
            }

            // Agregar la habilidad al usuario
            _context.UserSkills.Add(new UserSkill { UserId = userId, SkillID = skillId });

            _context.SaveChanges();

            return Ok("Skill added to user successfully");
        }
        catch (Exception ex)
        {
            return StatusCode(500, "An error occurred while adding the skill to the user");
        }
             */
            return Ok();
        }
    }

}
