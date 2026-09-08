using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gym_Backend_BusinessTier.ServicesInterfaces.Save;
using GYM_Backend_Data_Layer.Connection.Session;
using Gym_Backend_DTO.Login.Session;

namespace Gym_Backend_BusinessTier.Services.Login.Session
{
    public class scSessionService : ISaveService<clsSystemUserSessionDTO, int?>
    {
        public async Task<int?> Save(clsSystemUserSessionDTO systemUserSessionDTO)
        {
            return await dbSession.InsertSystemUserSession(systemUserSessionDTO);
        }
    }
}
