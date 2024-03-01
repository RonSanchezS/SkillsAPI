using LibraryApiReforged.Application.Services.Interfaces;
using LibraryApiReforged.Domain.DTOs;
using LibraryApiReforged.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace LibraryApiReforged.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SkillsController : ControllerBase
    {
        private readonly ISkillService _skillService;

        public SkillsController(ISkillService skillService)
        {
            ArgumentNullException.ThrowIfNull(skillService);
            _skillService = skillService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetAll()
        {
            var skills = _skillService.GetSkills();
            if(skills == null)
            {
                return NotFound();
            }
            return Ok(skills);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetSkillById(Guid id)
        {
            try
            {
                if (id == Guid.Empty)
                {
                    throw new BadHttpRequestException("ID cannot be empty.");
                }

                var skill = _skillService.GetSkillById(id);
                if (skill == null)
                {
                    return NotFound();
                }

                return Ok(skill);
            }
            catch (BadHttpRequestException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An unexpected error occurred.");
            }
        }

        [HttpPost(Name = "Create Skill")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        public IActionResult CreateSkill([FromBody] SkillCreateDto skill)
        {
            var createdSkill = _skillService.CreateSkill(skill);
            return CreatedAtRoute("Create Skill", createdSkill);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult UpdateSkill(Guid id, [FromBody] Skill updatedSkill)
        {
            var skill = _skillService.UpdateSkill(id, updatedSkill);
            return Ok(skill);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult DeleteSkill(Guid id)
        {
            var skill = _skillService.DeleteSkill(id);
            var response = new { message = $"Skill with id {id} was deleted", skill };
            return Ok(response);
        }
    }
}
