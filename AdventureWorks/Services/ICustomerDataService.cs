using AdventureWorks.Models;

namespace AdventureWorks.Services
{
    public interface ICustomerDataService
    {
        List<Customer> GetAllCustomers();
        List<Customer> SearchCustomers(string searchTerm);
        Customer GetCustomer(int id);
        int Insert(Customer customer);
        int Update(Customer customer);
        //int Delete(int id);
    }
}
