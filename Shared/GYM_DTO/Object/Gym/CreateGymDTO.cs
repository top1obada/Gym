using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GYM_DTO.Object.Gym.GymBranch;
using GYM_DTO.Object.User.GymUser;

namespace GYM_DTO.Object.Gym
{
    public class clsCreateGymDTO
    {
        [Required(ErrorMessage = "Gym details are required.")]
        public clsInsertGymDTO? Gym { get; set; }

        [Required(ErrorMessage = "Gym branch details are required.")]
        public clsInsertGymBranchDTO? GymBranchDTO { get; set; }

        [Required(ErrorMessage = "Gym user owner details are required.")]
        public clsInsertGymUserOnGenerateGymDTO? GymUser { get; set; }

        [Required(ErrorMessage = "At least one gym fitness type must be provided.")]
        [MinLength(1, ErrorMessage = "At least one gym fitness type must be selected.")]
        public List<int>? GymFitnessTypes { get; set; }
    }
}
