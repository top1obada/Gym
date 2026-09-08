using Gym_Backend_BusinessTier.Services.Gym;
using GYM_DTO.Object.Gym;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GYM_Backend_API_Interfaces.Controllers.Gym
{
    [Route("api/[controller]")]
    [ApiController]
    public class GymController : ControllerBase
    {
        private readonly scCreateGymService _gymService;

        public GymController(scCreateGymService gymService)
        {
            _gymService = gymService;
        }

        [HttpPost("Create")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<clsCreateGymRetrivingDTO>> Create([FromBody] clsCreateGymDTO createGymDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _gymService.Save(createGymDTO);

            if (result == null)
            {
                return BadRequest("An error occurred while creating the gym or its branch.");
            }

            return Ok(result);
        }
    }
}
