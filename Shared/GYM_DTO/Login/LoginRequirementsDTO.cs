using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GYM_DTO.Login
{
    public class clsLoginRequirementsDTO
    {

        [Required(ErrorMessage = "Unique Value Is Required")]
        public string? UniqueValue { get; set; }


        [Required(ErrorMessage = "Password Is Required")]
        public string? Password { get; set; }

    }
}
