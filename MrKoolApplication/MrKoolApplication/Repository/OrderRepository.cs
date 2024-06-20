using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MrKool.Data;
using MrKool.Interface;
using MrKool.Models;
using MrKoolApplication.DTO;
using MrKoolApplication.Interface;

namespace MrKool.Repository
{
    public class OrderRepository : IOrderRepository
    {

        private DBContext _context;

        private readonly IMapper _mapper;
        public OrderRepository(DBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<IEnumerable<Order>> GetAllOrdersAsync()
        {
            return await _context.Orders.Include(a => a.OrderDetailList).ToListAsync();
        }
        public async Task<Order> GetById(int orderID)
        {
            return await _context.Orders
                                 .Include(a => a.OrderDetailList)
                                 .FirstOrDefaultAsync(a => a.OrderID == orderID);

        }


        public List<Order> GetOrders()
        {
            return _context.Orders.ToList();
        }


        public List<Order> GetByTitleContaining(string name)
        {
            return _context.Orders
                           .Include(a => a.OrderDetailList)
                           .Where(a => a.Title.Contains(name))
                           .ToList();
        }

        public List<Order> GetByCustomerID(int customerID)
        {
            return _context.Orders
                           .Include(a => a.OrderDetailList)
                           .Where(a => a.CustomerID == customerID)
                           .ToList();
        }

        //CRUD
        public bool OrderExist(int OrderID)
        {
            return _context.Set<Order>().Any(a => a.OrderID == OrderID);
        }
        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool CreateOrder(Order order)
        {
            _context.Add(order);
            return Save();
        }

        public bool UpdateOrder(Order order)
        {
            _context.Update(order);
            return Save();
        }

        public async Task DeleteOrderAsync(Order order)
        {
            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();
        }
    }
}
