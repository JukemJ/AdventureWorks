using AdventureWorks.Models;
using Microsoft.Data.SqlClient;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using System.Net.Mail;

namespace AdventureWorks.Services
{
    public class CustomerDAO : ICustomerDataService
    {
        string connectionString = @"Data Source=JUKEM-PC;Initial Catalog=AdventureWorksLT2022;Integrated Security=True;Connect Timeout=30;Encrypt=False;
                                    Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";
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
                            Name = (string)reader[3] + " " + (string)reader[5],
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
                            Name = (string)reader[3] + " " +(string)reader[5],
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
