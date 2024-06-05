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
        [ProducesResponseType(200, Type = typeof(IEnumerable<Station>))]
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
        public ActionResult<Station> GetAreaById(int id)
        {
            var stations = _stationRepository.GetById(id);
            if (stations == null)
            {
                return NotFound();
            }
            return stations;
        }

        [HttpGet("search/{keyword}")]
        public ActionResult<IEnumerable<Station>> SearchStations(string keyword)
        {
            return _stationRepository.GetByNameContaining(keyword);
        }

    }
}
