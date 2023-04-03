using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using KPZ_LAB_3.Repository.Models;
using KPZ_LAB_3.ViewModels;
using Microsoft.Data.SqlClient;

namespace KPZ_LAB_3.Repository
{
    public class JewelryStoreRepository : IJewelryStoreRepository
    {
        public async Task AddCustomer(CreateCustomerViewModel customer)
        {
            string strConString = "Data Source=DESKTOP-QAU2I64;Initial Catalog=jewelry_store_vasiutyk_ostap;Integrated Security=True";

            using (SqlConnection con = new SqlConnection(strConString))
            {
                con.Open();
                string query = "Insert into dbo.customer (Username, Email, Password) " +
                    "values(@Username, @Email, @Password)";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Username", customer.Username);
                cmd.Parameters.AddWithValue("@Email", customer.Email);
                cmd.Parameters.AddWithValue("@Password", customer.Password);
                await cmd.ExecuteNonQueryAsync();
            }
        }

        public async Task DeleteCustomer(int customerId)
        {
            string strConString = "Data Source=DESKTOP-QAU2I64;Initial Catalog=jewelry_store_vasiutyk_ostap;Integrated Security=True";

            using (SqlConnection con = new SqlConnection(strConString))
            {
                con.Open();
                string query = "Delete from dbo.customer where Id=@customerId";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@customerId", customerId);
                await cmd.ExecuteNonQueryAsync();
            }
        }



        public async Task<Customer> GetCustomer(int customerId)
        {
            string strConString = "Data Source=DESKTOP-QAU2I64;Initial Catalog=jewelry_store_vasiutyk_ostap;Integrated Security=True";
            Customer result = new();

            using (SqlConnection con = new SqlConnection(strConString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Select * from dbo.customer where Id=" + customerId, con);

                using (DbDataReader rdr = await cmd.ExecuteReaderAsync(CommandBehavior.SequentialAccess))
                {
                    while (rdr.Read())
                    {
                        result = new Customer()
                        {
                            Id = rdr.GetInt32(0),
                            Username = rdr.GetString(1),
                            Email = rdr.GetString(2),
                            Password = rdr.GetString(3),
                        };
                    }
                }
            }

            return result;
        }

        public async Task UpdateCustomer(UpdateCustomerViewModel customer)
        {
            string strConString = "Data Source=DESKTOP-QAU2I64;Initial Catalog=jewelry_store_vasiutyk_ostap;Integrated Security=True";

            using (SqlConnection con = new SqlConnection(strConString))
            {
                con.Open();
                string query = "Update dbo.customer SET Username=@Username, " +
                    "Email=@Email, Password=@Password where Id=@CustomerId";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@CustomerId", customer.Id);
                cmd.Parameters.AddWithValue("@Username", customer.Username);
                cmd.Parameters.AddWithValue("@Email", customer.Email);
                cmd.Parameters.AddWithValue("@Password", customer.Password);
                await cmd.ExecuteNonQueryAsync();
            }
        }



        public async Task<IEnumerable<Customer>> GetCustomers()
        {
            string strConString = "Data Source=DESKTOP-QAU2I64;Initial Catalog=jewelry_store_vasiutyk_ostap;Integrated Security=True";
            List<Customer> result = new();

            using (SqlConnection con = new SqlConnection(strConString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Select * from dbo.customer", con);

                using (DbDataReader rdr = await cmd.ExecuteReaderAsync(CommandBehavior.SequentialAccess))
                {
                    while (rdr.Read())
                    {
                        result.Add(new Customer()
                        {
                            Id = rdr.GetInt32(0),
                            Username = rdr.GetString(1),
                            Email = rdr.GetString(2),
                            Password = rdr.GetString(3),
                        });
                    }
                }
            }

            IEnumerable<Customer> res = result;
            return res;
        }
    }
}
