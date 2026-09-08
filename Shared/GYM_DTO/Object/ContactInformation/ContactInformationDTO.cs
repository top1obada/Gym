using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GYM_DTO.Object.ContactInformation
{
    public class clsContactInformationDTO
    {


        [Required(ErrorMessage = "Phone Number Is Required")]
        public string? PhoneNumber { get; set; }

        public string? Email { get; set; }

    }
}
