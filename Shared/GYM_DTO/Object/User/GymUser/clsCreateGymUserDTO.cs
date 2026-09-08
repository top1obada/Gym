using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GYM_DTO.Object.Address;
using GYM_DTO.Object.ContactInformation;
using GYM_DTO.Object.Person;

namespace GYM_DTO.Object.User.GymUser
{
    public class clsCreateGymUserDTO
    {

        public clsInsertCompletedPersonDTO? CompletedPerson {  get; set; }

        public clsInsertGymUserOnGenerateGymDTO? GymUser { get; set; }

    }
}
