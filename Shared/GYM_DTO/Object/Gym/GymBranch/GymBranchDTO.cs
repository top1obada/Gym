using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GYM_DTO.Object.Gym.GymBranch
{
    public class clsGymBranchDTO
    {
        public int? GymBranchID { get; set; }

        public int? GymID { get; set; }

        public string? GymBranchName { get; set; }

        public int? AddressID { get; set; }

        public DateTime? StartDate { get; set; }

        public bool? Active { get; set; }

    }
}
