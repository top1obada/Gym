using System;
using System.Data;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using GYM_Backend_Data_Layer.Setting;
using GYM_DTO.Object.Gym.GymSubscription;

namespace GYM_Backend_Data_Layer.Connection.GymSubscription
{
    public static class dbGymSubscription
    {
        public static async Task<int?> InsertGymSubscription(clsInsertGymSubscriptionDTO insertDTO)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionSetting.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("SP_InsertGymSubscription", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@GymID", insertDTO.GymID);
                    command.Parameters.AddWithValue("@GymSubscriptionTypeID", insertDTO.GymSubscriptionTypeID);
                    command.Parameters.AddWithValue("@StartDate", insertDTO.StartDate);

                    SqlParameter outputId = new SqlParameter("@GymSubscriptionID", SqlDbType.Int) { Direction = ParameterDirection.Output };
                    command.Parameters.Add(outputId);

                    await connection.OpenAsync();
                    int affectedRows = await command.ExecuteNonQueryAsync();

                    if (affectedRows < 1) return null;

                    return Convert.ToInt32(outputId.Value);
                }
            }
        }
    }
}
