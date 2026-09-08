using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GYM_DTO.Object.Gym
{
    public class clsGymDTO
    {

        public int? GymID { get; set; }

        public int? CreatedByUserID { get; set; }

        public string? GymName { get; set; }

        public DateTime? CreatedDate { get; set; }

        public bool? Active { get; set; }

    }
}
