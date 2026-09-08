using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GYM_DTO.Login
{
    public class clsUserLoginRetrivingsDTO
    {

        public int? PersonID { get; set; }

        public string? FirstName { get; set; }

        public char? Gender { get; set; }

        public byte[]? HashedPassword { get; set; }

        public byte[]? Salt { get;set; }

        public DateTime? JoiningDate { get; set; }

    }
}
