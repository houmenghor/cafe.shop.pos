using Npgsql;
using System.Data;

namespace CafeShopManagement.Data
{
    internal static class Db
    {
        public static DataTable Table(string sql)
        {
            using var conn = Connection.Open();
            using var cmd = new NpgsqlCommand(sql, conn);
            using var da = new NpgsqlDataAdapter(cmd);
            var dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public static object? Scalar(string sql)
        {
            using var conn = Connection.Open();
            using var cmd = new NpgsqlCommand(sql, conn);
            return cmd.ExecuteScalar();
        }

        public static int Exec(string sql)
        {
            using var conn = Connection.Open();
            using var cmd = new NpgsqlCommand(sql, conn);
            return cmd.ExecuteNonQuery();
        }
    }
}
