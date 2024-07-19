using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MrKool.DTO;
using MrKool.Interface;
using MrKool.Models;
using MrKoolApplication.DTO;
using MrKoolApplication.Interface;
using MrKoolApplication.Repository;

namespace MrKoolApplication.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FixHistoryController : ControllerBase
    {
        private readonly IFixHistoryRepository _fixRepository;
        private readonly IMapper _mapper;

        public FixHistoryController(IFixHistoryRepository fixRepository, IMapper mapper)
        {
            _fixRepository = fixRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("FixHistories")]
        public async Task<ActionResult<IEnumerable<FixHistoryDTO>>> GetFixhistories()
        {
            var fixHistories = await _fixRepository.GetAllFixHistorysAsync();
            var fixHistorieDTOs = _mapper.Map<IEnumerable<FixHistoryDTO>>(fixHistories);
            return Ok(fixHistorieDTOs);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<FixHistoryDTO>> GetFixhistoryByIdAsync(int id)
        {
            var fixHistory = await _fixRepository.GetById(id);
            if (fixHistory == null)
            {
                return NotFound();
            }

            var FixHistoryDTO = _mapper.Map<FixHistoryDTO>(fixHistory);
            return Ok(FixHistoryDTO);
        }

        [HttpGet("/FixHistory/{cusID}/List")]
        public IActionResult GetByCustomerID(int cusID)
        {
            var fixHistories = _fixRepository.GetByCustomerID(cusID);
            if (fixHistories == null || !fixHistories.Any())
            {
                return NotFound("No fix history found for the given customer ID");
            }

            var fixHistoryDtos = _mapper.Map<List<FixHistoryDTO>>(fixHistories);
            return Ok(fixHistoryDtos);
        }
        //CRUD

        [HttpPost]
        [Route("CreateFixHistory")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateArea([FromBody] FixHistoryDTO fixHistoryCreate)
        {
            if (fixHistoryCreate == null) return BadRequest();

            var fixHistory = _fixRepository.GetFixHistories().FirstOrDefault();
            if (fixHistory != null)
            {
                return BadRequest("Area with the same title already exists.");
            }

            var fixHistoryMap = _mapper.Map<FixHistory>(fixHistoryCreate);
            if (!_fixRepository.CreateFixHistory(fixHistoryMap))
            {
                return StatusCode(500, "A problem happened while handling your request.");
            }

            return Ok("Successfully created the fix history.");
        }

        [HttpPut]
        [Route("UpdateFixHistory/{fixHistoryID}")]
        public IActionResult UpdateFixHistory(int fixHistoryID, [FromBody] FixHistoryDTO fixHistoryUpdate)
        {
            if (fixHistoryUpdate == null) return BadRequest();
            if (fixHistoryID != fixHistoryUpdate.FixHistoryID) return BadRequest();
            if (!_fixRepository.FixHistoryExist(fixHistoryID)) return BadRequest();

            var fixHistoryMap = _mapper.Map<FixHistory>(fixHistoryUpdate);
            if (!_fixRepository.UpdateFixHistory(fixHistoryMap))
            {
                return StatusCode(500, "A problem happened while handling your request.");
            }

            return NoContent();
        }

        [HttpDelete]
        [Route("DeleteFixHistory/{id}")]
        public async Task<IActionResult> DeleteAreaAsync(int id)
        {
            var fixHistory = await _fixRepository.GetById(id);
            if (fixHistory == null)
            {
                return NotFound();
            }

            fixHistory.IsDeleted = false;
            return NoContent();
        }
    }
}
