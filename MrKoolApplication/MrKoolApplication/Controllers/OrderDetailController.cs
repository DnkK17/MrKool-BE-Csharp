using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MrKool.DTO;
using MrKool.Models;
using MrKoolApplication.DTO;
using MrKoolApplication.Interface;

namespace MrKoolApplication.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderDetailController : ControllerBase
    {
        private readonly IOrderDetailRepository _orderDetailRepository;
        private readonly IMapper _mapper;

        public OrderDetailController(IMapper mapper, IOrderDetailRepository orderDetailRepository)
        {
            _mapper = mapper;
            _orderDetailRepository = orderDetailRepository;
        }

        [HttpGet]
        [Route("OrderDetails")]
        public async Task<ActionResult<IEnumerable<OrderDetailDTO>>> GetOrderDetails()
        {
            var ordetails = await _orderDetailRepository.GetAllOrderDetailsAsync();
            var ordetailDTOs = _mapper.Map<IEnumerable<OrderDetailDTO>>(ordetails); 
            return Ok(ordetailDTOs);
        }

        [HttpGet]
        [Route("OrderDetail/{orderID}")]

        public  ActionResult<IEnumerable<OrderDetailDTO>> GetOrderDetailByOrderID(int orderID)
        {
            var orderDetail = _orderDetailRepository.GetByOrderID(orderID);
            var orderDetailDTOs = _mapper.Map<IEnumerable<OrderDetailDTO>>(orderDetail); 
            return Ok(orderDetailDTOs);

        }
        
    }
}
