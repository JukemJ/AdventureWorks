using AdventureWorks.Models;
using Microsoft.Data.SqlClient;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using System.Net.Mail;

namespace AdventureWorks.Services
{
    public class CustomerDAO : ICustomerDataService
    {
        string connectionString = @"Server=tcp:adventureworks-dxn.database.windows.net,1433;Initial Catalog=AdventureWorks;Persist Security Info=False;
        User ID=CloudSA44fc7231;Password=TestPassword!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        public int Delete(Customer customer)
        {
            throw new NotImplementedException();
        }

        public List<Customer> GetAllCustomers()
        {
            List<Customer> customers = new List<Customer>();
            string sqlStatement = "SELECT * FROM SalesLT.Customer";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sqlStatement, connection);
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        customers.Add(new Customer
                        {
                            Id = (int)reader[0],
                            Name = (string)reader[3] + (string)reader[5],
                            Company = (string)reader[7],
                            EmailAddress = (string)reader[9],
                            PhoneNumber = (string)reader[10]            
                        });
                    }
                }
                catch (Exception e)
                {
                    Console.Write("GetAllCustomersError: ");
                    Console.WriteLine(e.Message);
                }
            }
            return customers;
        }

        public Customer GetCustomer(int id)
        {
            Customer customer = new Customer();
            string sqlStatement = "SELECT * FROM SalesLT.Customer c WHERE c.CustomerID = " +id;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sqlStatement, connection);
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        customer.Id = (int)reader[0];
                        customer.Name = (string)reader[3] + " " +(string)reader[5];
                        customer.Company = (string)reader[7];
                        customer.EmailAddress = (string)reader[9];
                        customer.PhoneNumber = (string)reader[10];
                    }
                }
                catch (Exception e)
                {
                    Console.Write("GetCustomerError: ");
                    Console.WriteLine(e.Message);
                }
            }
            return customer;
        }

        public int Insert(Customer customer)
        {
            throw new NotImplementedException();
        }

        public List<Customer> SearchCustomers(string searchTerm)
        {
            List<Customer> customers = new List<Customer>();
            string sqlStatement = "SELECT * FROM SalesLT.Customer c WHERE c.FirstName LIKE @Name OR c.LastName LIKE @Name";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sqlStatement, connection);
                command.Parameters.AddWithValue("@Name", "%" + searchTerm + "%");
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        customers.Add(new Customer
                        {
                            Id = (int)reader[0],
                            Name = (string)reader[3] + (string)reader[5],
                            Company = (string)reader[7],
                            EmailAddress = (string)reader[9],
                            PhoneNumber = (string)reader[10]
                        });
                    }
                }
                catch (Exception e)
                {
                    Console.Write("SearchCustomersError: ");
                    Console.WriteLine(e.Message);
                }
            }
            return customers;
        }

        public int Update(Customer customer)
        {
            throw new NotImplementedException();
        }
    }
}
