using System.Threading.Tasks;
using Gym_Backend_BusinessTier.Services.Gym.GymSubscription.GymSubscriptionPayment;
using GYM_DTO.Object.Gym.GymSubscription.GymSubscriptionPayment;

using Microsoft.AspNetCore.Mvc;

namespace GYM_Backend_API_Interfaces.Controllers.Gym.GymSubscription.GymSubscriptionPayment
{
    [Route("api/[controller]")]
    [ApiController]
    public class GymSubscriptionPaymentController : ControllerBase
    {
        private readonly scAddGymSubscriptionPaymentService _subscriptionPaymentService;

        public GymSubscriptionPaymentController(scAddGymSubscriptionPaymentService subscriptionPaymentService)
        {
            _subscriptionPaymentService = subscriptionPaymentService;
        }

        [HttpPost("Create")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<int>> Create([FromBody] clsInsertGymSubscriptionPaymentDTO insertDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _subscriptionPaymentService.Save(insertDTO);

            if (result == null)
            {
                return BadRequest("An error occurred while creating the gym subscription payment.");
            }

            return Ok(result);
        }
    }
}