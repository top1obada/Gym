using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

using Gym_Backend_DTO.Login;
using GYM_Backend_Data_Layer.Setting;
using System.Text.Json;
using Gym_Backend_DTO.Object.User;

namespace GYM_Backend_Data_Layer.Connection.Login
{
    public static class dbLogin
    {
        public static async Task<clsSystemUserLoginRetrivingsDTO?> Login(string? Email, string? PhoneNumber)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionSetting.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("SP_SystemUsersLogin", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Email", (object?)Email ?? DBNull.Value);
                    command.Parameters.AddWithValue("@PhoneNumber", (object?)PhoneNumber ?? DBNull.Value);

                    await connection.OpenAsync();

                    using (SqlDataReader result = await command.ExecuteReaderAsync())
                    {
                        if (result != null && await result.ReadAsync())
                        {
                            var retrivings = new clsSystemUserLoginRetrivingsDTO();

                            retrivings.PersonID = Convert.ToInt32(result["PersonID"]);
                            retrivings.FirstName = result["FirstName"].ToString();
                            retrivings.Gender = Convert.ToChar(result["Gender"]);
                            retrivings.HashedPassword = (byte[])result["HashedPassword"];
                            retrivings.Salt = (byte[])result["Salt"];
                            retrivings.JoiningDate = Convert.ToDateTime(result["JoiningDate"]);
                            retrivings.Role = (enUserRole)Convert.ToInt32(result["Role"]);

                            return retrivings;
                        }
                    }

                    return null;
                }
            }
        }

        public static async Task<clsSystemUserLoginRetrivingsDTO?> LoginByRefreshToken(string hashedRefreshToken)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionSetting.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("SP_LoginSystemUsersLoginByRefreshToken", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@HashedRefreshToken", hashedRefreshToken);

                    await connection.OpenAsync();

                    using (SqlDataReader result = await command.ExecuteReaderAsync())
                    {
                        if (result != null && await result.ReadAsync())
                        {
                            var retrivings = new clsSystemUserLoginRetrivingsDTO();

                            retrivings.PersonID = Convert.ToInt32(result["PersonID"]);
                            retrivings.FirstName = result["FirstName"].ToString();
                            retrivings.Gender = Convert.ToChar(result["Gender"]);
                            retrivings.JoiningDate = Convert.ToDateTime(result["JoiningDate"]);
                            retrivings.Role = (enUserRole)Convert.ToInt32(result["Role"]);

                            retrivings.HashedPassword = null;
                            retrivings.Salt = null;

                            return retrivings;
                        }
                    }

                    return null;
                }
            }
        }
    }
}
