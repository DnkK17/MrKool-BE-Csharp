using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MrKool.Data;
using MrKool.Interface;
using MrKool.Models;
using MrKoolApplication.DTO;
using MrKoolApplication.Interface;
using System.Diagnostics.Metrics;
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
        public RequestController(IRequestRepository requestRepository, IMapper mapper)
        {
            _requestRepository = requestRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Request>))]
        public async Task<ActionResult<IEnumerable<Request>>> GetActionResultAsync()
        {
            {
                var requests = await _requestRepository.GetAllAsync();
                var requestDTOs = _mapper.Map<IEnumerable<Request>>(requests);
                return Ok(requestDTOs);
            }
        }

        [HttpGet("{id}")]
        public ActionResult<Request> GetAreaById(int id)
        {
            var request = _requestRepository.GetById(id);
            if (request == null)
            {
                return NotFound();
            }
            return request;
        }


        [HttpPost("area/{areaID}/station/{stationID}")]
        public async Task<IActionResult> CreateRequest(
                [FromRoute] int areaID,
                [FromRoute] int stationID)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }



            var request = new Request
            {
                AreaID = areaID,
                StationID = stationID,
                Date = "a",
                Description = "a",
                RequestAddress = "a",
                Status = "a",
                CustomerID = 1,
                ManagerID = 1,
                OrderID = 1,
                TechnicianID = 1
            };

            var requestMap = _mapper.Map<Request>(request);
            _requestRepository.CreateRequest(request);
            return Ok();
        }

        [HttpPut]
        [ProducesResponseType(404)]
        public IActionResult UpdateRequest(int requestID, [FromBody] RequestDTO requestUpdate)
        {


            var requestMap = _mapper.Map<Request>(requestUpdate);

            if (!_requestRepository.UpdateRequest(requestMap))
            {
                ModelState.AddModelError("", "Something went wrong while update category");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }


     
    }
         

}
