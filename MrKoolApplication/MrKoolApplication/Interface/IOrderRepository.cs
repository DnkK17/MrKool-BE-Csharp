using MrKool.Models;
using MrKoolApplication.DTO;

namespace MrKoolApplication.Interface
{
    public interface IOrderRepository
    {
        Task<IEnumerable<Order>> GetAllOrdersAsync();
        Task<Order> GetById(int OrderID);
        List<Order> GetByTitleContaining(string name);
        List<Order> GetByCustomerID(int customerID);

        List<Order> GetOrders();
        bool OrderExist(int OrderID);
        bool UpdateOrder(Order order);


        bool CreateOrder(Order order);

        Task DeleteOrderAsync(Order order);

        bool Save();
    }
}
