using Gym_Backend_BusinessTier.Services.Person;
using GYM_DTO.Object.Person;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GYM_Backend_API_Interfaces.Controllers.Person
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly scCreateCompletedPersonService _personService;

        public PersonController(scCreateCompletedPersonService personService)
        {
            _personService = personService;
        }

        [HttpPost("Create")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<clsInsertCompletedPersonRetrivingsDTO>> Create([FromBody] clsInsertCompletedPersonDTO insertCompletedPersonDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _personService.Save(insertCompletedPersonDTO);

            if (result == null)
            {
                return BadRequest("An error occurred while creating the person profile.");
            }

            return Ok(result);
        }
    }
}
