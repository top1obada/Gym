using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GYM_DTO.Object.Gym
{
    public class UpdateGymDTO
    {
        public int? GymID { get; set; }

        public string? GymName { get; set; }
        public bool? Active { get; set; }

    }
}
