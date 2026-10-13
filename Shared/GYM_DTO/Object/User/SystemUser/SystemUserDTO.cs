using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym_Backend_DTO.Object.User
{
    public enum enUserRole { eOwner = 1, eAdmin = 2 }

    public class clsSystemUserDTO
    {
        public int? SystemUserID { get; set; }

        public enUserRole? Role { get; set; }

        public DateTime? JoiningDate { get; set; }

        public bool? Active { get; set; }
    }
}
