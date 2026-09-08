using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gym_Backend_BusinessTier.ServicesInterfaces.Save;
using GYM_Backend_Data_Layer.Connection.GymSubscriptionType;
using GYM_DTO.Object.GymSubscriptionType;

namespace Gym_Backend_BusinessTier.Services.GymSubscriptionType
{
    public class scAddGymSubscriptionTypeWithLimitsService : ISaveService<clsInsertGymSubscriptionTypeWithLimitsDTO, int?>
    {
        public async Task<int?> Save(clsInsertGymSubscriptionTypeWithLimitsDTO insertDTO)
        {
            return await dbGymSubscriptionType.InsertGymSubscriptionTypeWithLimits(insertDTO);
        }
    }
}
