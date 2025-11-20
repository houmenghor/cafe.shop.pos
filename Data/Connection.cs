using Npgsql;
namespace CafeShopManagement.Data
{
    internal class Connection
    {
        private const string ConnectionString =
           "Host=localhost;Port=5432;Database=cafe_shop_management;Username=postgres;Password=Menghor100@@$$;";

        public static NpgsqlConnection Open()
        {
            var conn = new NpgsqlConnection(ConnectionString);
            conn.Open();
            return conn;
        }
    }
}
