using CafeShopManagement.Models;
using Npgsql;
using System;
using System.Collections.Generic;

namespace CafeShopManagement.Data
{
    internal static class ProductRepository
    {
        // ✅ Get all products from the database
        public static List<Product> GetAll()
        {
            var products = new List<Product>();

            try
            {
                using (var conn = Connection.Open())
                using (var cmd = new NpgsqlCommand(
                    "SELECT id, name, price, stock, created_at FROM products ORDER BY id ASC", conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        products.Add(new Product
                        {
                            Id = reader.GetInt32(0),
                            Name = reader.GetString(1),
                            Price = reader.GetDecimal(2),
                            Stock = reader.GetInt32(3),
                            CreatedAt = reader.GetDateTime(4)
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"⚠️ Error loading products: {ex.Message}");
            }

            return products;
        }

        // ✅ Add a new product
        public static bool Add(Product product)
        {
            try
            {
                using (var conn = Connection.Open())
                using (var cmd = new NpgsqlCommand(
                    "INSERT INTO products (name, price, stock, created_at) VALUES (@name, @price, @stock, NOW())", conn))
                {
                    cmd.Parameters.AddWithValue("@name", product.Name);
                    cmd.Parameters.AddWithValue("@price", product.Price);
                    cmd.Parameters.AddWithValue("@stock", product.Stock);

                    return cmd.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"⚠️ Error adding product: {ex.Message}");
                return false;
            }
        }

        // ✅ Update an existing product
        public static bool Update(Product product)
        {
            try
            {
                using (var conn = Connection.Open())
                using (var cmd = new NpgsqlCommand(
                    "UPDATE products SET name=@name, price=@price, stock=@stock WHERE id=@id", conn))
                {
                    cmd.Parameters.AddWithValue("@id", product.Id);
                    cmd.Parameters.AddWithValue("@name", product.Name);
                    cmd.Parameters.AddWithValue("@price", product.Price);
                    cmd.Parameters.AddWithValue("@stock", product.Stock);

                    return cmd.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"⚠️ Error updating product: {ex.Message}");
                return false;
            }
        }

        // ✅ Delete a product by ID
        public static bool Delete(int id)
        {
            try
            {
                using (var conn = Connection.Open())
                using (var cmd = new NpgsqlCommand("DELETE FROM products WHERE id=@id", conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"⚠️ Error deleting product: {ex.Message}");
                return false;
            }
        }
        public static List<Product> SearchByName(string keyword)
        {
            var products = new List<Product>();

            using (var conn = Connection.Open())
            {
                string query = "SELECT id, name, price, stock, created_at FROM products WHERE name ILIKE @keyword ORDER BY id";
                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@keyword", $"%{keyword}%");
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            products.Add(new Product
                            {
                                Id = reader.GetInt32(0),
                                Name = reader.GetString(1),
                                Price = reader.GetDecimal(2),
                                Stock = reader.GetInt32(3),
                                CreatedAt = reader.GetDateTime(4)
                            });
                        }
                    }
                }
            }

            return products;
        }

        public static Product? GetByName(string name)
        {
            using (var conn = Connection.Open())
            {
                string query = "SELECT id, name, price, stock, created_at FROM products WHERE name = @name LIMIT 1";
                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@name", name);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Product
                            {
                                Id = reader.GetInt32(0),
                                Name = reader.GetString(1),
                                Price = reader.GetDecimal(2),
                                Stock = reader.GetInt32(3),
                                CreatedAt = reader.GetDateTime(4)
                            };
                        }
                    }
                }
            }
            return null;
        }


    }
}
