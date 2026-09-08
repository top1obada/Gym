using Gym_Backend_BusinessTier.Services.FitnessType;
using GYM_DTO.Object.FitnessType;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GYM_Backend_API_Interfaces.Controllers.FitnessType
{
    [Route("api/[controller]")]
    [ApiController]
    public class FitnessTypeController : ControllerBase
    {
        private readonly scAddFitnessTypeService _fitnessTypeService;

        public FitnessTypeController(scAddFitnessTypeService fitnessTypeService)
        {
            _fitnessTypeService = fitnessTypeService;
        }

        [HttpPost("Create")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<int>> Create([FromBody] clsInsertFitnessTypeDTO insertFitnessTypeDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var fitnessTypeId = await _fitnessTypeService.Save(insertFitnessTypeDTO);

            if (fitnessTypeId == null)
            {
                return BadRequest("An error occurred while creating the fitness type.");
            }

            return Ok(fitnessTypeId);
        }
    }
}
