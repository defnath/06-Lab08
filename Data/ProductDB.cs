using Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class ProductDB
    {
        private string connectionString = "Data Source=LAB1504-01\\SQLEXPRESS;Initial Catalog=FacturaDB;User ID=tecsup;Password=tecsup";
        public List<Product> ListProducts()
        {
            List<Product> products = new List<Product>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand cmd = new SqlCommand("ListProducts", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Product product = new Product
                            {
                                Id = Convert.ToInt32(reader["product_id"]),
                                Name = reader["name"].ToString(),
                                Price = Convert.ToDecimal(reader["price"]),
                                Stock = Convert.ToInt32(reader["stock"]),
                                Active = Convert.ToBoolean(reader["active"])
                            };

                            products.Add(product);
                        }
                    }
                }
            }

            return products;
        }
        public List<Product> GetProducts()
        {
            ProductDB customerdb = new ProductDB();
            return customerdb.ListProducts();
        }
    }
}