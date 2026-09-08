using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GYM_DTO.Object.GymSubscriptionType
{
    public class clsBaseGymSubscriptionTypeDTO
    {

        [Required(ErrorMessage = "Subscription type name is required.")]
        public string? GymSubscriptionTypeName { get; set; }

        [Required(ErrorMessage = "Months count is required.")]
        public byte? MonthesCount { get; set; }

        [Required(ErrorMessage = "Price is required.")]
        [Range(0.0, double.MaxValue, ErrorMessage = "Price must be a positive number.")]
        public decimal? Price { get; set; }
        

    }
}
