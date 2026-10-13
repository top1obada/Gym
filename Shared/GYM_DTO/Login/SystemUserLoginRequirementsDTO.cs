using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym_Backend_DTO.Login
{
    public class clsSystemUserLoginRequirementsDTO
    {

        public string? Email { get; set; }

        public string? PhoneNumber { get; set; }

        [Required(ErrorMessage = "Password Is Required")]
        public string? Password { get; set; }

    }
}
