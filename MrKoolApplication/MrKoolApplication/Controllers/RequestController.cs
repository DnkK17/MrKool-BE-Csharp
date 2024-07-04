using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MrKool.Data;
using MrKool.Interface;
using MrKool.Models;
using MrKoolApplication.DTO;
using MrKoolApplication.Interface;
using System.Diagnostics.Metrics;
using System.Net;
using System.Security.Cryptography;

namespace MrKoolApplication.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RequestController : Controller
    {
        private readonly IRequestRepository _requestRepository;
        private readonly IMapper _mapper;
        private readonly DBContext _context;
        public RequestController(IRequestRepository requestRepository, IMapper mapper, DBContext context)
        {
            _requestRepository = requestRepository;
            _mapper = mapper;
            _context = context;
        }

        [HttpGet]
        [ProducesResponseType(200)]
        public async Task<ActionResult<IEnumerable<RequestDTO>>> GetAllRequests()
        {
            var requests = await _requestRepository.GetAllAsync();
            var requestDTO = _mapper.Map<IEnumerable<RequestDTO>>(requests);
            return Ok(requestDTO);
        }


        [HttpGet("{id}")]
        public ActionResult<Request> GetRequestById(int id)
        {
            var request = _requestRepository.GetById(id);
            if (request == null)
            {
                return NotFound();
            }
            return request;
        }


        [HttpPost]
        public ActionResult<Request> CreateRequest(RequestDTO requestDto)
        {
            var area = _context.Areas.Find(requestDto.AreaID);
            var station = _context.Stations.Find(requestDto.StationID);
            var customer = _context.Customers.Find(requestDto.CustomerID);
            var services = _context.Services.Where(s => requestDto.ServiceIDs.Contains(s.ServiceID)).ToList();

            if (area == null || station == null || customer == null || services.Count != requestDto.ServiceIDs.Count)
            {
                return BadRequest("Invalid input data");
            }

            var request = _mapper.Map<Request>(requestDto);
            request.Area = area;
            request.Station = station;
            request.Customer = customer;
            request.Services = services;
            request.Status = Enum.Status.Pending; 

            _requestRepository.CreateRequest(request);
            _requestRepository.Save();

            return CreatedAtAction(nameof(GetRequestById), new { id = request.RequestID }, request);
        }

        [HttpPut("/approve/manager/{requestID}/{technicianID}")]
        public IActionResult ApproveRequestByManager(int requestID,int technicianID)
        {
            var request = _context.Requests.Find(requestID);
            if (request == null)
            {
                return NotFound();
            }
            
            request.Status = Enum.Status.Approved; 
            request.TechnicianID = technicianID; 
            _context.SaveChanges();
            return NoContent();
        }

        [HttpPut("{id}/approve/technician")]
        public IActionResult ApproveRequestByTechnician(int id)
        {
            var request = _context.Requests.Find(id);
            if (request == null)
            {
                return NotFound();
            }


            // Create a new order
            var order = new Order
            {
                Date = request.Date,
                Title = request.Description,
                Address = request.RequestAddress,
                Status = Enum.Status.Processing, 
                Customer = request.Customer,
                CustomerID = request.CustomerID, 
                OrderDetailList = new List<OrderDetail>(),
                TotalPrice = request.TotalPrice
            };

            foreach (var service in request.Services)
            {
                OrderDetail orderDetail = new OrderDetail
                {
                    Image = "", 
                    Status = true, 
                    IsDeleted = false,
                    OrderID = order.OrderID,
                    TechnicianID = request.TechnicianID,
                    ServiceID = service.ServiceID,
                };

                order.OrderDetailList.Add(orderDetail);
            }
            _context.Orders.Add(order);
            _context.SaveChanges();

            return NoContent();
        }

        [HttpPut]
        [ProducesResponseType(404)]
        public IActionResult UpdateRequest(int requestID, [FromBody] RequestDTO requestUpdate)
        {


            var requestMap = _mapper.Map<Request>(requestUpdate);

            if (!_requestRepository.UpdateRequest(requestMap))
            {
                ModelState.AddModelError("", "Something went wrong while update");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }


     
    }
         

}
