using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MrKool.Data;
using MrKool.Models;
using MrKoolApplication.Interface;

namespace MrKoolApplication.Repository
{
    public class OrderDetailRepository : IOrderDetailRepository
    {
        private DBContext _context;
        private readonly IMapper _mapper;

        public OrderDetailRepository (DBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<OrderDetail>> GetAllOrderDetailsAsync()
        {
            return await _context.OrderDetails.ToListAsync();
        }
        public List<OrderDetail> GetByOrderID(int orderID)
        {
            return _context.OrderDetails.Where(od => od.OrderID == orderID).ToList();   
        }
        //CRUD
        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;        }
        public bool CreateOrderDetail(OrderDetail orderDetail)
        {
            _context.Add(orderDetail);
            return Save();
        }

        public bool UpdateOrderDetail(OrderDetail orderDetail)
        {
            _context.Update(orderDetail);
            return Save();
        }
        public async Task DeleteOrderDetailAsync(OrderDetail orderDetail)
        {
            _context.OrderDetails.Remove(orderDetail);
            await _context.SaveChangesAsync();
        }
    }
}
