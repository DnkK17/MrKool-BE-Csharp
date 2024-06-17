using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MrKool.Interface;
using MrKool.Models;
using MrKoolApplication.Interface;

namespace MrKoolApplication.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ManagerController : ControllerBase
    {
        private readonly IManagerRepository _managerRepository;
        private readonly IMapper _mapper;
        public ManagerController(IManagerRepository managerRepository, IMapper mapper)
        {
            _managerRepository = managerRepository;
            _mapper = mapper;
        }


        [HttpGet("{id}")]
        public ActionResult<Manager> GetManagerById(int id)
        {
            var manager = _managerRepository.GetById(id);
            if (manager == null)
            {
                return NotFound();
            }
            return manager;
        }

   


        //CRUD

        [HttpPost("/CreateManager")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateManager([FromBody] Manager managerCreate)
        {
            if (managerCreate == null) return BadRequest();
            var manager = _managerRepository.GetManagers().Where(c => c.Email == managerCreate.Email);
            if (manager != null)
            {
                return BadRequest();
            }
            var managerMap = _mapper.Map<Manager>(managerCreate);
            if (!_managerRepository.CreateManager(managerMap))
                return StatusCode(500);

            return Ok("Successfully");
        }

        [HttpPut("/UpdateManager/{managerID}")]
        public IActionResult UpdateManager(int managerID, [FromBody] Manager managerUpdate)
        {
            if (managerUpdate == null) return BadRequest();
            if (managerID != managerUpdate.ManagerID) return BadRequest();
            if (!_managerRepository.ManagerExist(managerID)) return BadRequest();
            var managerMap = _mapper.Map<Manager>(managerUpdate);
            if (!_managerRepository.UpdateManager(managerMap))
            {
                return StatusCode(500);
            }
            return NoContent();
        }

        [HttpDelete("/DeleteManager/{id}")]
        public IActionResult DeleteManager(int id)
        {
            var manager = _managerRepository.GetById(id);
            if (manager == null)
            {
                return NotFound();
            }
            _managerRepository.DeleteManager(manager);

            return NoContent();
        }
    }
}
