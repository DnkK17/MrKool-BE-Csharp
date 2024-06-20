using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MrKool.Interface;
using MrKool.Models;
using MrKoolApplication.DTO;
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
        [ProducesResponseType(200, Type = typeof(IEnumerable<ServiceDTO>))]
        public async Task<ActionResult<IEnumerable<ServiceDTO>>> GetActionResultAsync()
        {
            {
                var services = await _serviceRepository.GetAllAsync();
                var serviceDTOs = _mapper.Map<IEnumerable<ServiceDTO>>(services);
                return Ok(serviceDTOs);
            }
        }

        [HttpGet("/Service/{id}")]
        public ActionResult<ServiceDTO> GetServiceById(int id)
        {
            var service = _serviceRepository.GetById(id);
            if (service == null)
            {
                return NotFound();
            }
            var serviceDTO = _mapper.Map<ServiceDTO>(service);
            return serviceDTO;
        }

        [HttpGet("search/{keyword}")]
        public ActionResult<IEnumerable<ServiceDTO>> SearchServices(string keyword)
        {
            var serviceSearch = _serviceRepository.GetByModel(keyword);
            if (serviceSearch == null) return NotFound();
            var serviceSearchDTO = new List<ServiceDTO> { _mapper.Map<ServiceDTO>(serviceSearch) };

            return Ok(serviceSearchDTO);
        }


    }
}
