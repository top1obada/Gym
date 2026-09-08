using System;
using System.ComponentModel.DataAnnotations;

namespace GYM_DTO.Object.GymSubscriptionType
{
    public class clsInsertGymSubscriptionTypeWithLimitsDTO
    {
        [Required(ErrorMessage = "Subscription main data is required.")]
        public clsInsertGymSubscriptionTypeDTO? SubscriptionType { get; set; }

        [Required(ErrorMessage = "Subscription limits configuration is required.")]
        public clsInsertGymSubscriptionTypeLimitsDTO? SubscriptionLimits { get; set; }
    }
}
