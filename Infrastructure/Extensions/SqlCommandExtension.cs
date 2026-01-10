using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace Infrastructure.Extensions
{
    public static class SqlCommandExtension
    {
        public static async Task<DataSet> GetDataTables(DbContext dbContext, string sql, params SqlParameter[] parameters)
        {
            SqlCommand cmd = new();
            var conn = (SqlConnection)dbContext.Database.GetDbConnection();
            cmd.CommandText = sql;
            cmd.Parameters.AddRange(parameters);
            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;

            await conn.OpenAsync();

            SqlDataAdapter adapter = new(cmd);

            DataSet ds = new();
            adapter.Fill(ds);

            await conn.CloseAsync();

            return ds;
        }
    }
}
