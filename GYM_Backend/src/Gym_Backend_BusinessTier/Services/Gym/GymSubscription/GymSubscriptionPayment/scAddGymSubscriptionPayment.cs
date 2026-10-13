using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gym_Backend_BusinessTier.ServicesInterfaces.Save;
using GYM_Backend_Data_Layer.Connection.Gym.GymSubscription.GymSubscriptionPayment;
using GYM_DTO.Object.Gym.GymSubscription.GymSubscriptionPayment;

namespace Gym_Backend_BusinessTier.Services.Gym.GymSubscription.GymSubscriptionPayment
{
    public class scAddGymSubscriptionPaymentService : ISaveService<clsInsertGymSubscriptionPaymentDTO, int?>
    {
        public async Task<int?> Save(clsInsertGymSubscriptionPaymentDTO insertDTO)
        {
            return await dbGymSubscriptionPayment.InsertGymSubscriptionPayment(insertDTO);
        }
    }
}