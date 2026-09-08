using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using GYM_Backend_Data_Layer.Connection.Gym;
using GYM_DTO.Object.Gym;
using GYM_DTO.Login;
using ProjectsServices.PasswordServices;
using Gym_Backend_BusinessTier.ServicesInterfaces.Save;

namespace Gym_Backend_BusinessTier.Services.Gym
{
    public class scCreateGymService : ISaveService<clsCreateGymDTO, clsCreateGymRetrivingDTO?>
    {
        public async Task<clsCreateGymRetrivingDTO?> Save(clsCreateGymDTO createGymDTO)
        {
            var encryptionResult = clsPasswordEncrypt.HashPassword(createGymDTO.GymUser.LoginRequirements.Password);

            var loginSendData = new clsLoginSenData
            {
                HashedPassword = encryptionResult.Hash,
                Salt = encryptionResult.Salt
            };

            return await dbGym.CreateGym(createGymDTO, loginSendData);
        }
    }
}
