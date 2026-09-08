using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GYM_DTO.Object.Person
{
    public class clsUpdatePersonDTO : clsBasePersonDTO
    {
        [Required(ErrorMessage = "Person ID Is Required")]
        public int? PersonID { get; set; }

    }
}
