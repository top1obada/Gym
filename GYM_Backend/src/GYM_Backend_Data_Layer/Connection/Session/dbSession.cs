using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Gym_Backend_DTO.Login.Session;
using GYM_Backend_Data_Layer.Setting;

namespace GYM_Backend_Data_Layer.Connection.Session
{
    public static class dbSession
    {
        public static async Task<int?> InsertSystemUserSession(clsSystemUserSessionDTO systemUserSessionDTO)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionSetting.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("SP_InsertSystemUserSession", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@HashedRefreshToken", systemUserSessionDTO.HashedRefreshToken);
                    command.Parameters.AddWithValue("@DeviceName", (object?)systemUserSessionDTO.DeviceName ?? DBNull.Value);
                    command.Parameters.AddWithValue("@SystemUserID", systemUserSessionDTO.SystemUserID);

                    SqlParameter outputSessionId = new SqlParameter
                    {
                        ParameterName = "@SystemUserSessionID",
                        SqlDbType = System.Data.SqlDbType.Int,
                        Direction = System.Data.ParameterDirection.Output
                    };
                    command.Parameters.Add(outputSessionId);

                    await connection.OpenAsync();
                    await command.ExecuteNonQueryAsync();

                    if (outputSessionId.Value != DBNull.Value)
                    {
                        return Convert.ToInt32(outputSessionId.Value);
                    }

                    return null;
                }
            }
        }
    }
}
