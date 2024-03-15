using AdventureWorks.Models;
using Microsoft.Data.SqlClient;

namespace AdventureWorks.Services
{
    public class ProductsDAO : IProductDataService
    {
        string connectionString = @"Server=tcp:adventureworks-dxn.database.windows.net,1433;Initial Catalog=AdventureWorks;Persist Security Info=False;
        User ID=CloudSA44fc7231;Password=Corolla860!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        public int Delete(Product product)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAllProducts()
        {
            List<Product> products = new List<Product>();
            string sqlStatement = "SELECT * FROM SalesLT.Product";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sqlStatement, connection);
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        products.Add(new Product { Id = (int)reader[0], Name = (string)reader[1], 
                            Color = (string)reader[3], Price = (decimal)reader[5], PhotoURL = (string)reader[14] });
                    }
                }
                catch (Exception e)
                {
                    Console.Write("GetAllProductsError: ");
                    Console.WriteLine(e.Message);
                }
            }
            return products;
        }

        public Product GetProduct(int id)
        {
            Product product = new Product();
            string sqlStatement = "SELECT * FROM SalesLT.Product s WHERE s.ProductID = " + id;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sqlStatement, connection);
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        product.Id = (int)reader[0];
                        product.Name = (string)reader[1];
                        product.Color = (string)reader[3];
                        product.Price = (decimal)reader[5];
                        product.PhotoURL = (string)reader[14];
                    }
                    
                }
                catch (Exception e)
                {

                    Console.WriteLine(e.Message);
                }
            }
            //Console.WriteLine(product.Id);
            return product;
        }

        public int Insert(Product product)
        {
            throw new NotImplementedException();
        }

        public List<Product> SearchProducts(string searchTerm)
        {
            List<Product> products = new List<Product>();
            string sqlStatement = "SELECT * FROM SalesLT.Product s WHERE s.Name LIKE @Name";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sqlStatement, connection);
                command.Parameters.AddWithValue("@Name","%" + searchTerm + "%");
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        products.Add(new Product
                        {
                            Id = (int)reader[0],
                            Name = (string)reader[1],
                            Color = (string)reader[3],
                            Price = (decimal)reader[5],
                            PhotoURL = (string)reader[14]
                        });
                    }
                }
                catch (Exception e)
                {
                    Console.Write("SearchProductsError: ");
                    Console.WriteLine(e.Message);
                }
            }
            return products;
        }

        public int Update(Product product)
        {
            throw new NotImplementedException();
        }
    }
}
