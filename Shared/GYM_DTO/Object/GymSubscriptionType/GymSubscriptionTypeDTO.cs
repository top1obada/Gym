using System;
using System.ComponentModel.DataAnnotations;

namespace GYM_DTO.Object.GymSubscriptionType
{
    public class clsGymSubscriptionTypeDTO : clsBaseGymSubscriptionTypeDTO
    {      

        [Required(ErrorMessage = "Gym Subscription Type ID Is Required")]
        public int? GymSubscriptionTypeID { get; set; }

        [Required(ErrorMessage = "Active Is Required")]
        public bool? Active { get; set; }
    }
}
