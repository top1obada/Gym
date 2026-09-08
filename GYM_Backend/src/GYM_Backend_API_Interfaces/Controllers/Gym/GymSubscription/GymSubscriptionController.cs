using System.Threading.Tasks;
using Gym_Backend_BusinessTier.Services.Gym.GymSubscription;

using GYM_DTO.Object.Gym.GymSubscription;

using Microsoft.AspNetCore.Mvc;

namespace GYM_Backend_API_Interfaces.Controllers.Gym.GymSubscription
{
    [Route("api/[controller]")]
    [ApiController]
    public class GymSubscriptionController : ControllerBase
    {
        private readonly scAddGymSubscriptionService _subscriptionService;

        public GymSubscriptionController(scAddGymSubscriptionService subscriptionService)
        {
            _subscriptionService = subscriptionService;
        }

        [HttpPost("Create")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<int>> Create([FromBody] clsInsertGymSubscriptionDTO insertDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _subscriptionService.Save(insertDTO);

            if (result == null)
            {
                return BadRequest("An error occurred while creating the gym subscription.");
            }

            return Ok(result);
        }
    }
}
