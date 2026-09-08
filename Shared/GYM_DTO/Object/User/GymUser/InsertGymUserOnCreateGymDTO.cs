using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GYM_DTO.Login;

namespace GYM_DTO.Object.User.GymUser
{
    public class clsInsertGymUserOnGenerateGymDTO 
    {

        [Required(ErrorMessage = "Person ID Is Required")]
        public int? PersonID { get; set; }

        [Required(ErrorMessage = "Login Requirements Is Required")]
        public clsLoginRequirementsDTO? LoginRequirements { get; set; }

    }
}
