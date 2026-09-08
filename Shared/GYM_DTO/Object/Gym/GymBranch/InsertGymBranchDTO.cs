using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GYM_DTO.Object.Address;

namespace GYM_DTO.Object.Gym.GymBranch
{
    public class clsInsertGymBranchDTO
    {
        public int? GymID { get; set; }

        [Required(ErrorMessage = "Gym branch name is required.")]
        public string? GymBranchName { get; set; }

        [Required(ErrorMessage = "Branch address details are required.")]
        public clsAddressDTO? Address { get; set; }
    }
}
