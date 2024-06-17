using MrKool.Models;
using MrKoolApplication.DTO;

namespace MrKoolApplication.Interface
{
    public interface ICustomerRepository

    {
        Task<IEnumerable<Customer>> GetAllCustomersAsync();
        Task<Customer> GetById(int customerID);
        List<Customer> GetByNameContaining(string CustomerName);
        List<Customer> GetByAreaId(int areaID);

        List<Customer> GetCustomers();
      

        bool CustomerExist(int CustomerID);
        bool UpdateCustomer(Customer customer);


        bool CreateCustomer(Customer customer);

        Task DeleteCustomerAsync(Customer customer);

        bool Save();
    }
}
