using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MrKool.DTO;
using MrKool.Interface;
using MrKool.Models;
using MrKool.Repository;
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
            var serviceSearch = _serviceRepository.GetByNameContaining(keyword);
            if (serviceSearch == null) return NotFound();
            var serviceSearchDTO = _mapper.Map<IEnumerable<ServiceDTO>>(serviceSearch);

            return Ok(serviceSearchDTO);
        }

        [HttpPost]
        [Route("CreateService")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateService([FromBody] ServiceDTO serviceCreate)
        {
            if (serviceCreate == null) return BadRequest();

            var service = _serviceRepository.GetServices().FirstOrDefault(c => c.ServiceTitle == serviceCreate.ServiceTitle);
            if (service != null)
            {
                return BadRequest("Area with the same title already exists.");
            }

            var serviceMap = _mapper.Map<Service>(serviceCreate);
            if (!_serviceRepository.CreateService(serviceMap))
            {
                return StatusCode(500, "A problem happened while handling your request.");
            }

            return Ok("Successfully created the service.");
        }

        [HttpPut]
        [Route("UpdateService/{serviceID}")]
        public IActionResult UpdateService(int serviceID, [FromBody] ServiceDTO serviceUpdate)
        {
            if (serviceUpdate == null) return BadRequest();
            if (serviceID != serviceUpdate.ServiceID) return BadRequest();
            if (!_serviceRepository.ServiceExist(serviceID)) return BadRequest();

            var serviceMap = _mapper.Map<Service>(serviceUpdate);
            if (!_serviceRepository.UpdateService(serviceMap))
            {
                return StatusCode(500, "A problem happened while handling your request.");
            }

            return NoContent();
        }

        [HttpDelete]
        [Route("DeleteService/{id}")]
        public async Task<IActionResult> DeleteServiceAsync(int id)
        {
            var service =  _serviceRepository.GetById(id);
            if (service == null)
            {
                return NotFound();
            }

            service.IsDeleted = true;
            return NoContent();
        }
    }
}
