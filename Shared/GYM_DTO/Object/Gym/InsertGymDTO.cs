using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GYM_DTO.Object.Gym
{
    public class clsInsertGymDTO
    {
        [Required(ErrorMessage = "Gym name is required.")]
        public string? GymName { get; set; }

        [Required(ErrorMessage = "Created by user ID is required.")]
        public int? CreatedByUserID { get; set; }
    }
}
