using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MrKool.Data;
using MrKool.DTO;
using MrKool.Interface;
using MrKool.Models;
using MrKool.Repository;
using MrKoolApplication.DTO;
using MrKoolApplication.Enum;
using MrKoolApplication.Interface;
using MrKoolApplication.Repository;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MrKool.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;
        private readonly Status _status;
        private readonly DBContext _context;
        public OrderController(IOrderRepository orderRepository, IMapper mapper, Status status)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
            _status = status;
        }

        [HttpGet]
        [Route("Orders")]
        public async Task<ActionResult<IEnumerable<OrderDTO>>> GetOrders()
        {
            var orders = await _orderRepository.GetAllOrdersAsync();
            var orderDTOs = _mapper.Map<IEnumerable<OrderDTO>>(orders);
            return Ok(orderDTOs);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<OrderDTO>> GetOrderByIdAsync(int id)
        {
            var orders = await _orderRepository.GetById(id);
            if (orders == null)
            {
                return NotFound();
            }

            var orderDTOs = _mapper.Map<OrderDTO>(orders);
            return Ok(orderDTOs);
        }

        [HttpGet]
        [Route("search/{keyword}")]
        public ActionResult<IEnumerable<OrderDTO>> SearchOrders(string keyword)
        {
            var orders = _orderRepository.GetByTitleContaining(keyword);
            var orderDTOs = _mapper.Map<IEnumerable<OrderDTO>>(orders);
            return Ok(orderDTOs);
        }


        [HttpPut("technician/complete/{orderID}")]
        public IActionResult CompletedOrderByTechnician(int orderID)
        {
            var order = _context.Orders.Find(orderID);
            if (order == null) return NotFound();
            order.Status = Status.Approved;
            _context.SaveChanges();

            var newFixHistory = new FixHistory
            {
                CustomerID = order.CustomerID,
                Title = order.Title,
                TechnicianID = order.TechnicianID,
                OrderDetailList = order.OrderDetailList,
            };
            _context.FixHistories.Add(newFixHistory);
            _context.SaveChanges();
            return NoContent();
        }


        //CRUD
        [HttpPost]
        [Route("CreateOrder")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateOrder([FromBody] OrderDTO orderCreate)
        {
            if (orderCreate == null) return BadRequest();

            var order = _orderRepository.GetOrders().FirstOrDefault(c => c.Title == orderCreate.Title);
            if (order != null)
            {
                return BadRequest("Order with the same title already exists.");
            }

            var orderMap = _mapper.Map<Order>(orderCreate);
            if (!_orderRepository.CreateOrder(orderMap))
            {
                return StatusCode(500, "A problem happened while handling your request.");
            }

            return Ok("Successfully created the order.");
        }


        [HttpPut]
        [Route("UpdateOrder/{orderID}")]
        public IActionResult UpdateOrder(int orderID, [FromBody] OrderDTO orderUpdate)
        {
            if (orderUpdate == null) return BadRequest();
            if (orderID != orderUpdate.OrderID) return BadRequest();
            if (!_orderRepository.OrderExist(orderID)) return BadRequest();

            var orderMap = _mapper.Map<Order>(orderUpdate);
            if (!_orderRepository.UpdateOrder(orderMap))
            {
                return StatusCode(500, "A problem happened while handling your request.");
            }

            return NoContent();
        }

        [HttpDelete]
        [Route("DeleteOrder/{id}")]
        public async Task<IActionResult> DeleteAreaAsync(int id)
        {
            var order = await _orderRepository.GetById(id);
            if (order == null)
            {
                return NotFound();
            }

            order.IsDeleted = false;
            return NoContent();
        }
    }
}
