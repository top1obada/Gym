using System;
using System.ComponentModel.DataAnnotations;

namespace GYM_DTO.Object.Gym.GymSubscription
{
    public class clsBaseGymSubscriptionDTO
    {
        [Required(ErrorMessage = "Gym ID is required.")]
        public int? GymID { get; set; }

        [Required(ErrorMessage = "Gym subscription type ID is required.")]
        public int? GymSubscriptionTypeID { get; set; }

        [Required(ErrorMessage = "Start date is required.")]
        public DateTime? StartDate { get; set; }
    }
}
