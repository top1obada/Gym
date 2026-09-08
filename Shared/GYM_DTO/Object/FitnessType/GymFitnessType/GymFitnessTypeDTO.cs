using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GYM_DTO.Object.FitnessType.GymFitnessType
{
    public class clsGymFitnessTypeDTO
    {

        public int? FitnessTypeID { get; set; }

        public int? GymID { get; set; }

        public int? CreatedByUserID { get; set; }

        public DateTime? CreatingDate { get; set; }

        public bool? Active { get; set; }

    }
}
