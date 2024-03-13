using AdventureWorks.Models;

namespace AdventureWorks.Services
{
    public interface IProductDataService
    {
        List<Product> GetAllProducts();
        List<Product> SearchProducts(string searchTerm);
        Product GetProduct(int id);
        int Insert (Product product);
        int Update (Product product); 
        int Delete (Product product);   

    }
}
