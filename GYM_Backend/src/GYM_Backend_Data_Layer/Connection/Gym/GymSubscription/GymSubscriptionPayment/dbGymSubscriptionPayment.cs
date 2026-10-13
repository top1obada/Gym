using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using GYM_Backend_Data_Layer.Setting;
using GYM_DTO.Object.Gym.GymSubscription.GymSubscriptionPayment;

namespace GYM_Backend_Data_Layer.Connection.Gym.GymSubscription.GymSubscriptionPayment
{
    public static class dbGymSubscriptionPayment
    {
        public static async Task<int?> InsertGymSubscriptionPayment(clsInsertGymSubscriptionPaymentDTO insertDTO)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionSetting.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("SP_InsertGymSubscriptionPayment", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@GymSubscriptionID", insertDTO.GymSubscriptionID);
                    command.Parameters.AddWithValue("@PaymentAmount", insertDTO.PaymentAmount);
                    command.Parameters.AddWithValue("@CurrencyID", insertDTO.CurrencyID);
                    command.Parameters.AddWithValue("@PaymentAmountInCurrentCurrency", (object?)insertDTO.PaymentAmountInCurrentCurrency ?? DBNull.Value);
                    command.Parameters.AddWithValue("@CurrencyPerDollar", (object?)insertDTO.CurrencyPerDollar ?? DBNull.Value);
                    command.Parameters.AddWithValue("@PaymentMethodID", insertDTO.PaymentMethodID);
                    command.Parameters.AddWithValue("@Details", (object?)insertDTO.Details ?? DBNull.Value);

                    SqlParameter outputId = new SqlParameter("@GymSubscriptionPaymentID", SqlDbType.Int) { Direction = ParameterDirection.Output };
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