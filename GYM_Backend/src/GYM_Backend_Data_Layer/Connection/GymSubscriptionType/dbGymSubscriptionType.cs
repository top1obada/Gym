using System;
using System.Data;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using GYM_DTO.Object.GymSubscriptionType;
using GYM_Backend_Data_Layer.Setting;

namespace GYM_Backend_Data_Layer.Connection.GymSubscriptionType
{
    public static class dbGymSubscriptionType
    {
        public static async Task<int?> InsertGymSubscriptionTypeWithLimits(clsInsertGymSubscriptionTypeWithLimitsDTO insertDTO)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionSetting.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("SP_InsertGymSubscriptionTypeWithLimits", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@GymSubscriptionTypeName", insertDTO.SubscriptionType.GymSubscriptionTypeName);
                    command.Parameters.AddWithValue("@MonthesCount", insertDTO.SubscriptionType.MonthesCount);
                    command.Parameters.AddWithValue("@Price", insertDTO.SubscriptionType.Price);
                    command.Parameters.AddWithValue("@AvailableFitnessTypesCount", insertDTO.SubscriptionLimits.AvailableFitnessTypesCount);
                    command.Parameters.AddWithValue("@AvailableTraineesCountByFitnessType", insertDTO.SubscriptionLimits.AvailableTraineesCountByFitnessType);
                    command.Parameters.AddWithValue("@AvailableFitnessTypesSectionsCount", insertDTO.SubscriptionLimits.AvailableFitnessTypesSectionsCount);

                    SqlParameter outputId = new SqlParameter("@GymSubscriptionTypeID", SqlDbType.Int)
                    {
                        Direction = ParameterDirection.Output
                    };
                    command.Parameters.Add(outputId);

                    await connection.OpenAsync();
                    int affectedRows = await command.ExecuteNonQueryAsync();

                    if (affectedRows < 1)
                    {
                        return null;
                    }

                    return Convert.ToInt32(outputId.Value);
                }
            }
        }
    }
}
