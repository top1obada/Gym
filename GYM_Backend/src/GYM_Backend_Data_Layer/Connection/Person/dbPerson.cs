using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using GYM_DTO.Object.Person;
using GYM_Backend_Data_Layer.Setting;

namespace GYM_Backend_Data_Layer.Connection.Person
{
    public static class dbPerson
    {
        public static async Task<clsInsertCompletedPersonRetrivingsDTO?> InsertCompletedPerson(clsInsertCompletedPersonDTO insertCompletedPersonDTO)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionSetting.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("SP_InsertCompletedPerson", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@FirstName", insertCompletedPersonDTO.Person.FirstName);
                    command.Parameters.AddWithValue("@MiddleName", insertCompletedPersonDTO.Person.MiddleName);
                    command.Parameters.AddWithValue("@LastName", insertCompletedPersonDTO.Person.LastName);
                    command.Parameters.AddWithValue("@BirthDate", insertCompletedPersonDTO.Person.BirthDate);
                    command.Parameters.AddWithValue("@Gender", insertCompletedPersonDTO.Person.Gender);
                    command.Parameters.AddWithValue("@Nationality", insertCompletedPersonDTO.Person.Nationality);
                    command.Parameters.AddWithValue("@NationalNumber", insertCompletedPersonDTO.Person.NationalNumber);

                    command.Parameters.AddWithValue("@PhoneNumber", insertCompletedPersonDTO.ContactInformation.PhoneNumber);
                    command.Parameters.AddWithValue("@Email", insertCompletedPersonDTO.ContactInformation.Email);

                    command.Parameters.AddWithValue("@CityID", insertCompletedPersonDTO.Address.CityID);
                    command.Parameters.AddWithValue("@TownName", insertCompletedPersonDTO.Address.TownName);
                    command.Parameters.AddWithValue("@Details", insertCompletedPersonDTO.Address.Details);

                    SqlParameter outputContactId = new SqlParameter("@ContactInformationID", SqlDbType.Int) { Direction = ParameterDirection.Output };
                    SqlParameter outputAddressId = new SqlParameter("@AddressID", SqlDbType.Int) { Direction = ParameterDirection.Output };
                    SqlParameter outputPersonId = new SqlParameter("@NewPersonID", SqlDbType.Int) { Direction = ParameterDirection.Output };

                    command.Parameters.Add(outputContactId);
                    command.Parameters.Add(outputAddressId);
                    command.Parameters.Add(outputPersonId);

                    await connection.OpenAsync();
                    await command.ExecuteNonQueryAsync();

                    var retrivings = new clsInsertCompletedPersonRetrivingsDTO
                    {
                        ContactInformationID = Convert.ToInt32(outputContactId.Value),
                        AddressID = Convert.ToInt32(outputAddressId.Value),
                        PersonID = Convert.ToInt32(outputPersonId.Value)
                    };

                    return retrivings;
                }
            }
        }
    }
}
