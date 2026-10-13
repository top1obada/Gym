using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GYM_DTO.Login
{
    public class clsLoginSenData
    {

        public byte[]? HashedPassword { get; set; }

        public byte[]? Salt { get; set; }

    }

}
