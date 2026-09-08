using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gym_Backend_BusinessTier.ServicesInterfaces.Save;
using GYM_Backend_Data_Layer.Connection.FitnessType;
using GYM_DTO.Object.FitnessType;

namespace Gym_Backend_BusinessTier.Services.FitnessType
{
    public class scAddFitnessTypeService : ISaveService<clsInsertFitnessTypeDTO, int?>
    {
        public async Task<int?> Save(clsInsertFitnessTypeDTO insertFitnessTypeDTO)
        {
            return await dbFitnessType.InsertFitnessType(insertFitnessTypeDTO);
        }
    }
}
