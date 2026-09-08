using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gym_Backend_DTO.Object.User;
using GYM_DTO.Login;

namespace Gym_Backend_DTO.Login
{

    

    public class clsSystemUserLoginRetrivingsDTO : clsUserLoginRetrivingsDTO
    {

          public enUserRole? Role { get; set; }    

    }
}
