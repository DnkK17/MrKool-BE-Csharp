using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MrKool.Data;
using MrKool.DTO;
using MrKool.Interface;
using MrKool.Models;
using MrKool.Repository;
using MrKoolApplication.DTO;
using MrKoolApplication.Interface;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MrKool.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TechnicianController : ControllerBase
    {
        private readonly ITechnicianRepository _technicianRepository;
        private readonly IMapper _mapper;

        public TechnicianController(ITechnicianRepository technicianRepository, IMapper mapper)
        {
            _technicianRepository = technicianRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("Technicians")]
        public async Task<ActionResult<IEnumerable<TechnicianDTO>>> GetTechnicians()
        {
            var technicians = await _technicianRepository.GetAllTechniciansAsync();
            var technicianDTOs = _mapper.Map<IEnumerable<CustomerDTO>>(technicians);
            return Ok(technicianDTOs);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<TechnicianDTO>> GetTechnicianByIdAsync(int id)
        {
            var technician = await _technicianRepository.GetById(id);
            if (technician == null)
            {
                return NotFound();
            }

            var technicianDTO = _mapper.Map<TechnicianDTO>(technician);
            return Ok(technicianDTO);
        }

        [HttpGet]
        [Route("search/{keyword}")]
        public ActionResult<IEnumerable<TechnicianDTO>> SearchTechnicians(string keyword)
        {
            var technicians = _technicianRepository.GetByNameContaining(keyword);
            var technicianDTOs = _mapper.Map<IEnumerable<CustomerDTO>>(technicians);
            return Ok(technicianDTOs);
        }


        [HttpPost]
        [Route("CreateTechnician")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateTechnician([FromBody] TechnicianDTO technicianCreate)
        {
            if (technicianCreate == null) return BadRequest();

            var customer = _technicianRepository.GetTechnicians().FirstOrDefault(c => c.Email == technicianCreate.Email);
            if (customer != null)
            {
                return BadRequest("Technician with the same email already exists.");
            }

            var customerMap = _mapper.Map<Technician>(technicianCreate);
            if (!_technicianRepository.CreateTechnician(customerMap))
            {
                return StatusCode(500, "A problem happened while handling your request.");
            }

            return Ok("Successfully created the Technician.");
        }

        [HttpPut]
        [Route("UpdateTechnician/{technicianID}")]
        public IActionResult UpdateTechnician(int technicianID, [FromBody] TechnicianDTO technicianUpdate)
        {
            if (technicianUpdate == null) return BadRequest();
            if (technicianID != technicianUpdate.TechnicianID) return BadRequest();
            if (!_technicianRepository.TechnicianExist(technicianID)) return BadRequest();

            var technicianMap = _mapper.Map<Technician>(technicianUpdate);
            if (!_technicianRepository.UpdateTechnician(technicianMap))
            {
                return StatusCode(500, "A problem happened while handling your request.");
            }

            return NoContent();
        }

        [HttpDelete]
        [Route("DeleteTechnician/{id}")]
        public async Task<IActionResult> DeleteTechnicianAsync(int id)
        {
            var technician = await _technicianRepository.GetById(id);
            if (technician == null)
            {
                return NotFound();
            }

            technician.IsDeleted = false;
            return NoContent();
        }
    }
}
