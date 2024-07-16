using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MrKool.Data;
using MrKool.Interface;
using MrKool.Models;
using MrKool.Repository;
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
        public async Task<IActionResult> CreateRequest([FromBody] RequestDTO requestDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var request = _mapper.Map<Request>(requestDto);

            if (requestDto.ServiceIDs != null)
            {
                request.Services = new List<Service>();
                foreach (var serviceId in requestDto.ServiceIDs)
                {
                    var service = await _context.Services.FindAsync(serviceId);
                    if (service != null)
                    {
                        request.Services.Add(service);
                    }
                }
            }

            var createdRequest = await _requestRepository.CreateRequestAsync(request);
            var createdRequestDto = _mapper.Map<RequestDTO>(createdRequest);

            return CreatedAtAction(nameof(GetRequestById), new { id = createdRequest.RequestID }, createdRequestDto);
        }

        [HttpPut("/manager/approve/{requestID}/{technicianID}")]
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

        [HttpPut("/technician/{id}/approve")]
        public IActionResult ApproveRequestByTechnician(int id)
        {
            var request = _context.Requests
                          .Include(r => r.Services)
                          .FirstOrDefault(r => r.RequestID == id);

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
                Time = DateTime.Now,
                Status = Enum.Status.Processing,
                Customer = request.Customer,
                CustomerID = request.CustomerID,
                TechnicianID = request.TechnicianID,
                OrderDetailList = new List<OrderDetail>(),
                TotalPrice = request.TotalPrice
            };
            _context.Orders.Add(order);
            _context.SaveChanges();

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
            _context.SaveChanges();

            return NoContent();
        }

        [HttpPut]
        [Route("/manager/updateRequest")]
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
