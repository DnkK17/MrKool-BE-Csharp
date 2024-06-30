using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MrKool.Data;
using MrKool.DTO;
using MrKool.Interface;
using MrKool.Models;
using MrKool.Repository;
using MrKoolApplication.DTO;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MrKool.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AreaController : ControllerBase
    {
        private readonly IAreaRepository _areaRepository;
        private readonly IMapper _mapper;

        public AreaController(IAreaRepository areaRepository, IMapper mapper)
        {
            _areaRepository = areaRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("Areas")]
        public async Task<ActionResult<IEnumerable<AreaDTO>>> GetAreas()
        {
            var areas = await _areaRepository.GetAllAreasAsync();
            var areaDTOs = _mapper.Map<IEnumerable<AreaDTO>>(areas);
            return Ok(areaDTOs);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<AreaDTO>> GetAreaByIdAsync(int id)
        {
            var area = await _areaRepository.GetById(id);
            if (area == null)
            {
                return NotFound();
            }

            var areaDto = _mapper.Map<AreaDTO>(area);
            return Ok(areaDto);
        }

        [HttpGet]
        [Route("search/{keyword}")]
        public ActionResult<IEnumerable<AreaDTO>> SearchAreas(string keyword)
        {
            var areas = _areaRepository.GetByNameContaining(keyword);
            var areaDtos = _mapper.Map<IEnumerable<AreaDTO>>(areas);
            return Ok(areaDtos);
        }

        [HttpPost("{areaId}/admin/addStation")]
        public IActionResult AddStationToArea(int areaId, [FromBody] StationDTO station)
        {
            var area = _areaRepository.GetById(areaId);
            if (area == null)
            {
                return NotFound("Area not found");
            }

            _areaRepository.AddStationToArea(areaId, station);
            _areaRepository.Save();

            return Ok(station);
        }

        [HttpPost]
        [Route("CreateArea")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateArea([FromBody] AreaDTO areaCreate)
        {
            if (areaCreate == null) return BadRequest();

            var area = _areaRepository.GetAreas().FirstOrDefault(c => c.Title == areaCreate.Title);
            if (area != null)
            {
                return BadRequest("Area with the same title already exists.");
            }

            var areaMap = _mapper.Map<Area>(areaCreate);
            if (!_areaRepository.CreateArea(areaMap))
            {
                return StatusCode(500, "A problem happened while handling your request.");
            }

            return Ok("Successfully created the area.");
        }

        [HttpPut]
        [Route("UpdateArea/{areaID}")]
        public IActionResult UpdateArea(int areaID, [FromBody] AreaDTO areaUpdate)
        {
            if (areaUpdate == null) return BadRequest();
            if (areaID != areaUpdate.AreaID) return BadRequest();
            if (!_areaRepository.AreaExist(areaID)) return BadRequest();

            var areaMap = _mapper.Map<Area>(areaUpdate);
            if (!_areaRepository.UpdateArea(areaMap))
            {
                return StatusCode(500, "A problem happened while handling your request.");
            }

            return NoContent();
        }

        [HttpDelete]
        [Route("DeleteArea/{id}")]
        public async Task<IActionResult> DeleteAreaAsync(int id)
        {
            var area = await _areaRepository.GetById(id);
            if (area == null)
            {
                return NotFound();
            }

            area.IsDeleted = false;
            return NoContent();
        }
    }
}
