using Gym_Backend_BusinessTier.Services.GymSubscriptionType;
using GYM_DTO.Object.GymSubscriptionType;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GYM_Backend_API_Interfaces.Controllers.GymSubscriptionType
{
    [Route("api/[controller]")]
    [ApiController]
    public class GymSubscriptionTypeController : ControllerBase
    {
        private readonly scAddGymSubscriptionTypeWithLimitsService _subscriptionService;

        public GymSubscriptionTypeController(scAddGymSubscriptionTypeWithLimitsService subscriptionService)
        {
            _subscriptionService = subscriptionService;
        }

        [HttpPost("CreateWithLimits")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<int>> CreateWithLimits([FromBody] clsInsertGymSubscriptionTypeWithLimitsDTO insertDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var subscriptionTypeId = await _subscriptionService.Save(insertDTO);

            if (subscriptionTypeId == null)
            {
                return BadRequest("An error occurred while creating the gym subscription type with limits.");
            }

            return Ok(subscriptionTypeId);
        }
    }
}
