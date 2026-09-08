using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gym_Backend_BusinessTier.ServicesInterfaces.Find;
using GYM_Backend_Data_Layer.Connection.Login;
using Gym_Backend_DTO.Login;
using ProjectsServices.PasswordServices;

namespace Gym_Backend_BusinessTier.Services.Login
{
    public class scLoginService : 
        IFindService<clsLoginRequirementsDTO,clsSystemUserLoginRetrivingsDTO?>
    {

        public async Task<clsSystemUserLoginRetrivingsDTO?> 
            Find(clsLoginRequirementsDTO SystemUserLoginRequirementsDTO)
        {

            var Result = await dbLogin.Login(SystemUserLoginRequirementsDTO.Email,
                SystemUserLoginRequirementsDTO.PhoneNumber);

            bool RightPassword = clsPasswordEncrypt.VerifyPassword
                (SystemUserLoginRequirementsDTO.Password, Result.HashedPassword,
                Result.Salt);

            if(RightPassword)
            {
                return Result;
            }

            return null;

        }

    }
}
