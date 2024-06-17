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
    public class CustomerRepository : ICustomerRepository
    {

        private DBContext _context;

        private readonly IMapper _mapper;
        public CustomerRepository(DBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<IEnumerable<Customer>> GetAllCustomersAsync()
        {
            return await _context.Customers.ToListAsync();
        }
        public async Task<Customer> GetById(int customerID)
        {
            return await _context.Customers
                                 .FirstOrDefaultAsync(a => a.CustomerID == customerID);
        }


        public List<Customer> GetCustomers()
        {
            return _context.Customers.ToList();
        }


        public List<Customer> GetByNameContaining(string CustomerName)
        {
            return _context.Customers
                           .Where(a => a.CustomerName.Contains(CustomerName))
                           .ToList();
        }

        public List<Customer> GetByAreaId(int areaID)
        {
            return _context.Customers
                           .Where(a => a.AreaID == areaID)
                           .ToList();
        }
     

        //CRUD
        public bool CustomerExist(int CustomerID)
        {
            return _context.Set<Customer>().Any(a => a.CustomerID == CustomerID);
        }
        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool CreateCustomer(Customer customer)
        {
            _context.Add(customer);
            return Save();
        }

        public bool UpdateCustomer(Customer customer)
        {
            _context.Update(customer);
            return Save();
        }

        public async Task DeleteCustomerAsync(Customer customer)
        {
            _context.Customers.Remove(customer);
            await _context.SaveChangesAsync();
        }
    }
}
