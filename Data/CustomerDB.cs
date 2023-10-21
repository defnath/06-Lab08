using Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Data
{
    public class CustomerDB
    {
        private string connectionString = "Data Source=LAB1504-09\\SQLEXPRESS;Initial Catalog=FacturaDB;User ID=tecsup;Password=tecsup";
        public List<Customer> ListCustomers()
        {
            List<Customer> customers = new List<Customer>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand cmd = new SqlCommand("ListCustomers", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Customer customer = new Customer()
                            {
                                Id = Convert.ToInt32(reader["customer_id"]),
                                Name = reader["name"].ToString(),
                                Address = reader["address"].ToString(),
                                Phone = reader["phone"].ToString(),
                            };

                            customers.Add(customer);
                        }
                    }
                }
            }

            return customers;
        }
        public List<Customer> GetCustomer()
        {
            CustomerDB customerDataAccess = new CustomerDB();
            return customerDataAccess.ListCustomers();
        }
        
        
        
        public List<Customer> InsertCustomer()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand cmd = new SqlCommand("InsertCustomer", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Aquí debes definir los parámetros del procedimiento almacenado
                    cmd.Parameters.AddWithValue("@name", Customer.Name);
                    cmd.Parameters.AddWithValue("@address", Customer.Address);
                    cmd.Parameters.AddWithValue("@phone", Customer.Phone);

                    try
                    {
                        int rowsAffected = cmd.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                    catch (SqlException ex)
                    {
                        return false;
                    }
                }
            }
        }

    }
}