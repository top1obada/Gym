using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GYM_DTO.Object.Address;
using GYM_DTO.Object.ContactInformation;

namespace GYM_DTO.Object.Person
{
    public class clsInsertCompletedPersonDTO
    {
        [Required(ErrorMessage = "Person details are required.")]
        public clsInsertPersonDTO? Person { get; set; }

        [Required(ErrorMessage = "Contact information details are required.")]
        public clsInsertContactInformationDTO? ContactInformation { get; set; }

        [Required(ErrorMessage = "Address details are required.")]
        public clsInsertAddressDTO? Address { get; set; }
    }
}
