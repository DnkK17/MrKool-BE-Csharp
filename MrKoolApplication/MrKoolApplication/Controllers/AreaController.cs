using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MrKool.Data;
using MrKool.DTO;
using MrKool.Interface;
using MrKool.Models;
using MrKool.Repository;
using System.Collections.Generic;

namespace MrKool.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AreaController : Controller
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
        public ActionResult GetAllAreas()
        {
            var areas = _mapper.Map<List<AreaDTO>>( _areaRepository.GetAll());
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(areas);
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


    }
}
