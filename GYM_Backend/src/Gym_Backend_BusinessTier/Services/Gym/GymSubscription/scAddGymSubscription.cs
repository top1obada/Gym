using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gym_Backend_BusinessTier.ServicesInterfaces.Save;
using GYM_Backend_Data_Layer.Connection.GymSubscription;
using GYM_DTO.Object.Gym.GymSubscription;

namespace Gym_Backend_BusinessTier.Services.Gym.GymSubscription
{
    public class scAddGymSubscriptionService : ISaveService<clsInsertGymSubscriptionDTO, int?>
    {
        public async Task<int?> Save(clsInsertGymSubscriptionDTO insertDTO)
        {
            return await dbGymSubscription.InsertGymSubscription(insertDTO);
        }
    }
}
