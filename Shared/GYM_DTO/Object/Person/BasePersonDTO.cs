using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GYM_DTO.Object.Person
{
    public class clsBasePersonDTO
    {

        [Required(ErrorMessage = "First Name Is Required")]
        public string? FirstName { get; set; }

        public string? MiddleName { get; set; }

        [Required(ErrorMessage = "Last Name Is Required")]
        public string? LastName { get; set; }

        [Required(ErrorMessage = "BirthDate Is Required")]
        public DateTime? BirthDate { get; set; }

        [Required(ErrorMessage = "Gender Is Required")]
        public char? Gender { get; set; }

        [Required(ErrorMessage = "Nationality Is Required")]
        public int? Nationality { get; set; }
        public string? NationalNumber { get; set; }

    }
}
