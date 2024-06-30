using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MrKool.Data;
using MrKool.DTO;
using MrKool.Interface;
using MrKool.Models;
using MrKool.Repository;
using MrKoolApplication.DTO;
using MrKoolApplication.Interface;
using System.Collections.Generic;

namespace MrKool.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StationController: Controller
    {
        private readonly IStationRepository _stationRepository;
        private readonly IMapper _mapper;
        public StationController(IStationRepository stationRepository, IMapper mapper)
        {
            _stationRepository = stationRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<StationDTO>))]
        public ActionResult GetAllStations()
        {
            var stations = _mapper.Map<List<StationDTO>>(_stationRepository.GetAll());
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(stations);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<StationDTO>> GetStationById(int id)
        {
            var stations = await _stationRepository.GetById(id);
            if (stations == null)
            {
                return NotFound();
            }
            var stationDTOs = _mapper.Map<StationDTO>(stations);
            return Ok(stationDTOs);
        }

        [HttpGet("search/{keyword}")]
        public ActionResult<IEnumerable<Station>> SearchStations(string keyword)
        {
            return _stationRepository.GetByNameContaining(keyword);
        }
        [HttpPost]
        [Route("CreateStation")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateStation([FromBody] StationDTO stationCreate)
        {
            if (stationCreate == null) return BadRequest();

            var station = _stationRepository.GetStations().FirstOrDefault(c => c.Address == stationCreate.Address);
            if (station != null)
            {
                return BadRequest("Station with the same title already exists.");
            }

            var stationMap = _mapper.Map<Station>(stationCreate);
            if (!_stationRepository.CreateStation(stationMap))
            {
                return StatusCode(500, "A problem happened while handling your request.");
            }

            return Ok("Successfully created the station.");
        }

        [HttpPut]
        [Route("UpdateStation/{stationID}")]
        public IActionResult UpdateStation(int stationID, [FromBody] StationDTO stationUpdate)
        {
            if (stationUpdate == null) return BadRequest();
            if (stationID != stationUpdate.StationID) return BadRequest();
            if (!_stationRepository.StationExist(stationID)) return BadRequest();

            var stationMap = _mapper.Map<Station>(stationUpdate);
            if (!_stationRepository.UpdateStation(stationMap))
            {
                return StatusCode(500, "A problem happened while handling your request.");
            }

            return NoContent();
        }

        [HttpDelete]
        [Route("DeleteStation/{id}")]
        public async Task<IActionResult> DeleteStationAsync(int id)
        {
            var station = await _stationRepository.GetById(id);
            if (station == null)
            {
                return NotFound();
            }

            station.IsDeleted = false;
            return NoContent();
        }
    }
}
