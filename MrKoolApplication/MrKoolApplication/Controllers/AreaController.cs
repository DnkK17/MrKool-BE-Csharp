using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MrKool.Data;
using MrKool.DTO;
using MrKool.Interface;
using MrKool.Models;
using MrKool.Repository;
using MrKoolApplication.DTO;
using System.Collections.Generic;

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
        [ProducesResponseType(200, Type = typeof(IEnumerable<Area>))]
        public async Task<ActionResult<IEnumerable<Area>>> GetActionResultAsync()
        {
            {
                var areas = await _areaRepository.GetAllAsync() ;
                var areaDTOs = _mapper.Map<IEnumerable<Area>>(areas);
                return Ok(areaDTOs);
            }
        }

        [HttpGet("{id}")]
        public ActionResult<Area> GetAreaById(int id)
        {
            var area = _areaRepository.GetById(id);
            if (area == null)
            {
                return NotFound();
            }
            return area;
        }

        [HttpGet("search/{keyword}")]
        public ActionResult<IEnumerable<Area>> SearchAreas(string keyword)
        {
            return _areaRepository.GetByNameContaining(keyword);
        }


        //CRUD

        [HttpPost("/CreateArea")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateArea([FromBody] Area areaCreate)
        {
            if (areaCreate == null) return BadRequest();
            var area = _areaRepository.GetAreas().Where(c => c.Title == areaCreate.Title);
            if (area != null)
            {
                return BadRequest();
            }
            var areaMap = _mapper.Map<Area>(areaCreate);
            if (!_areaRepository.CreateArea(areaMap))
                return StatusCode(500);

            return Ok("Successfully");
        }

        [HttpPut("/UpdateArea/{areaID}")]
        public IActionResult UpdateArea(int areaID, [FromBody] Area areaUpdate)
        {
            if(areaUpdate == null) return BadRequest();
            if(areaID != areaUpdate.AreaID) return BadRequest();
            if(!_areaRepository.AreaExist(areaID)) return BadRequest();
            var areaMap = _mapper.Map<Area>(areaUpdate);
            if(!_areaRepository.UpdateArea(areaMap))
            {
                return StatusCode(500);
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteArea(int id)
        {
            var area = _areaRepository.GetById(id);
            if (area == null)
            {
                return NotFound();
            }
            _areaRepository.DeleteArea(area);

            return NoContent();
        }
    }
}
