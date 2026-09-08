using System;
using System.ComponentModel.DataAnnotations;

namespace GYM_DTO.Object.Gym.GymSubscription
{
    public class clsGymSubscriptionDTO : clsBaseGymSubscriptionDTO
    {
        [Required(ErrorMessage = "Gym subscription ID is required.")]
        public int? GymSubscriptionID { get; set; }

        public DateTime? ExpirationDate { get; set; }

        public DateTime? RevokedDate { get; set; }

        [Required(ErrorMessage = "Active status is required.")]
        public bool? Active { get; set; }
    }
}
