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
        [ProducesResponseType(200, Type = typeof(IEnumerable<Area>))]
        public ActionResult GetAllStations()
        {
            var areas = _mapper.Map<List<StationDTO>>(_stationRepository.GetAll());
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(areas);
        }

    }
}
