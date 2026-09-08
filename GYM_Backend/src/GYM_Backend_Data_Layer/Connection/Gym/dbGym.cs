using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Microsoft.Data.SqlClient;
using GYM_DTO.Object.Gym;
using GYM_DTO.Login;
using GYM_Backend_Data_Layer.Setting;

namespace GYM_Backend_Data_Layer.Connection.Gym
{
    public static class dbGym
    {
        public static async Task<clsCreateGymRetrivingDTO?> CreateGym(clsCreateGymDTO createGymDTO, clsLoginSenData loginSenData)
        {
            var fitnessTypesElement = new XElement("FitnessTypes",
                createGymDTO.GymFitnessTypes.Select(id => new XElement("Type", new XElement("FitnessTypeID", id)))
            );

            using (SqlConnection connection = new SqlConnection(ConnectionSetting.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("SP_CreateGym", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@PersonID", createGymDTO.GymUser.PersonID);
                    command.Parameters.AddWithValue("@UserName", createGymDTO.GymUser.LoginRequirements.UniqueValue);
                    command.Parameters.AddWithValue("@Salt", loginSenData.Salt);
                    command.Parameters.AddWithValue("@HashedPassword", loginSenData.HashedPassword);
                    command.Parameters.AddWithValue("@GymName", createGymDTO.Gym.GymName);
                    command.Parameters.AddWithValue("@CreatedByUserID", createGymDTO.Gym.CreatedByUserID);
                    command.Parameters.AddWithValue("@GymBranchName", Convert.ToInt32(createGymDTO.GymBranchDTO.GymBranchName));
                    command.Parameters.AddWithValue("@CityID", createGymDTO.GymBranchDTO.Address.CityID);
                    command.Parameters.AddWithValue("@TownName", createGymDTO.GymBranchDTO.Address.TownName);
                    command.Parameters.AddWithValue("@Details", createGymDTO.GymBranchDTO.Address.Details);
                    command.Parameters.Add(new SqlParameter("@FitnessTypesXml", SqlDbType.Xml) { Value = fitnessTypesElement.ToString() });

                    SqlParameter outputGymId = new SqlParameter("@NewGymID", SqlDbType.Int) { Direction = ParameterDirection.Output };
                    SqlParameter outputBranchId = new SqlParameter("@NewGymBranchID", SqlDbType.Int) { Direction = ParameterDirection.Output };

                    command.Parameters.Add(outputGymId);
                    command.Parameters.Add(outputBranchId);

                    await connection.OpenAsync();
                    int affectedRows = await command.ExecuteNonQueryAsync();

                    if (affectedRows < 1)
                    {
                        return null;
                    }

                    var retriving = new clsCreateGymRetrivingDTO
                    {
                        GymID = Convert.ToInt32(outputGymId.Value),
                        BranchID = Convert.ToInt32(outputBranchId.Value)
                    };

                    return retriving;
                }
            }
        }
    }
}
