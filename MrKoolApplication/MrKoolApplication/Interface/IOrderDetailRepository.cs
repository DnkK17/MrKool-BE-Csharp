using MrKool.Models;
using MrKoolApplication.DTO;

namespace MrKoolApplication.Interface
{
    public interface IOrderDetailRepository
    {
        Task<IEnumerable<OrderDetail>> GetAllOrderDetailsAsync();
        List<OrderDetail> GetByOrderID(int orderID);
       
     

    

        bool CreateOrderDetail(OrderDetail orderDetail);



        bool Save();
    }
}
