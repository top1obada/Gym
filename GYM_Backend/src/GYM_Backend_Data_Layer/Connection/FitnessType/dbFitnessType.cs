using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using GYM_DTO.Object.FitnessType;
using GYM_Backend_Data_Layer.Setting;

namespace GYM_Backend_Data_Layer.Connection.FitnessType
{
    public static class dbFitnessType
    {
        public static async Task<int?> InsertFitnessType(clsInsertFitnessTypeDTO insertFitnessTypeDTO)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionSetting.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("SP_InsertFitnessType", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@FitnessTypeName", insertFitnessTypeDTO.FitnessTypeName);

                    SqlParameter outputFitnessTypeId = new SqlParameter("@FitnessTypeID", SqlDbType.Int)
                    {
                        Direction = ParameterDirection.Output
                    };
                    command.Parameters.Add(outputFitnessTypeId);

                    await connection.OpenAsync();
                    int affectedRows = await command.ExecuteNonQueryAsync();

                    if (affectedRows < 1)
                    {
                        return null;
                    }

                    return Convert.ToInt32(outputFitnessTypeId.Value);
                }
            }
        }
    }
}
