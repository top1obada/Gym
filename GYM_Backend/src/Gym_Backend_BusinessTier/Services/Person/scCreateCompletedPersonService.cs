using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gym_Backend_BusinessTier.ServicesInterfaces.Save;
using GYM_Backend_Data_Layer.Connection.Person;
using GYM_DTO.Object.Person;

namespace Gym_Backend_BusinessTier.Services.Person
{
    public class scCreateCompletedPersonService : ISaveService<clsInsertCompletedPersonDTO, clsInsertCompletedPersonRetrivingsDTO?>
    {
        public async Task<clsInsertCompletedPersonRetrivingsDTO?> Save(clsInsertCompletedPersonDTO insertCompletedPersonDTO)
        {
            return await dbPerson.InsertCompletedPerson(insertCompletedPersonDTO);
        }
    }
}
