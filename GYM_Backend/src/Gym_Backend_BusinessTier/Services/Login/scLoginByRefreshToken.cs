using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gym_Backend_BusinessTier.ServicesInterfaces.Find;
using GYM_Backend_Data_Layer.Connection.Login;
using Gym_Backend_DTO.Login;

namespace Gym_Backend_BusinessTier.Services.Login
{
    public class scSystemUserLoginByRefreshTokenService : IFindService<string, clsSystemUserLoginRetrivingsDTO?>
    {
        public async Task<clsSystemUserLoginRetrivingsDTO?> Find(string hashedRefreshToken)
        {
            return await dbSystemLogin.SystemUserLoginByRefreshToken(hashedRefreshToken);
        }
    }
}
