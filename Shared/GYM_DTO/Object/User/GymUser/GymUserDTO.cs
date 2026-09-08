using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GYM_DTO.Object.User.GymUser
{
    public enum enGymUserRole { eOwner = 1 }

    public class clsGymUserDTO
    {
        public int? GymUserID { get; set; }
        
        public int? GymID { get; set; }

        public string? UserName { get; set; }
        public int? CreatedByUserID { get; set; }
        public DateTime? JoiningDate { get; set; }

        public enGymUserRole? BaseRole { get; set; }
        public bool? Active { get; set; }
    }
}
