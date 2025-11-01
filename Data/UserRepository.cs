using CafeShopManagement.Models;
using CafeShopManagement.Utils;
using Npgsql;
using System;

namespace CafeShopManagement.Data
{
    internal static class UserRepository
    {
        public static bool Register(string username, string password)
        {
            using (var conn = Connection.Open())
            {
                string hashedPassword = PasswordHelper.Hash(password);

                string query = @"
                    INSERT INTO users (username, password)
                    VALUES (@username, @password);
                ";

                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@password", hashedPassword);

                    try
                    {
                        return cmd.ExecuteNonQuery() > 0;
                    }
                    catch (PostgresException ex)
                    {
                        if (ex.SqlState == "23505") // Unique violation
                            throw new Exception("Username already exists!");
                        throw;
                    }
                }
            }
        }

        public static User? Login(string username, string password)
        {
            using (var conn = Connection.Open())
            {
                string query = "SELECT id, username, password, date_reg FROM users WHERE username = @username LIMIT 1;";

                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@username", username);

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string hashedPassword = reader.GetString(2);
                            if (PasswordHelper.Verify(password, hashedPassword))
                            {
                                return new User
                                {
                                    Id = reader.GetInt32(0),
                                    Username = reader.GetString(1),
                                    Password = hashedPassword,
                                    DateRegistered = reader.GetDateTime(3)
                                };
                            }
                        }
                    }
                }
            }

            return null;
        }
    }
}
