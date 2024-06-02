using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MrKool.Interface;
using MrKool.Models;
using MrKoolApplication.Interface;

namespace MrKoolApplication.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ServiceController : Controller
    {
        private readonly IServiceRepository _serviceRepository;
        private readonly IMapper _mapper;
        public ServiceController(IServiceRepository serviceRepository, IMapper mapper)
        {
            _serviceRepository = serviceRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Area>))]
        public async Task<ActionResult<IEnumerable<Service>>> GetActionResultAsync()
        {
            {
                var services = await _serviceRepository.GetAllAsync();
                var serviceDTOs = _mapper.Map<IEnumerable<Service>>(services);
                return Ok(serviceDTOs);
            }
        }

        [HttpGet("{id}")]
        public ActionResult<Service> GetAreaById(int id)
        {
            var service = _serviceRepository.GetById(id);
            if (service == null)
            {
                return NotFound();
            }
            return service;
        }

        [HttpGet("search/{keyword}")]
        public ActionResult<IEnumerable<Service>> SearchAreas(string keyword)
        {
            return _serviceRepository.GetByModel(keyword);
        }


    }
}
