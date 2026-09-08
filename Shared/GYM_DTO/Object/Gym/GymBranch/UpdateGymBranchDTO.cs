using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GYM_DTO.Object.Gym.GymBranch
{
    public class clsUpdateGymBranchDTO 
    {
        public string? GymBranchName { get; set; }

        public int? GymBranchID { get; set; }

        public bool? Active { get; set; }
    }
}
