using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MrKool.Interface;
using MrKool.Models;
using MrKool.Repository;
using MrKoolApplication.DTO;
using MrKoolApplication.Interface;

namespace MrKoolApplication.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ModelController : Controller
    {
        private readonly IModelRepository _modelRepository;
        private readonly IMapper _mapper;
        public ModelController(IModelRepository modelRepository, IMapper mapper)
        {
            _modelRepository = modelRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<ConditionerModel>))]
        public ActionResult GetAllModels()
        {
            var models = _mapper.Map<List<ConditionerModelDTO>>(_modelRepository.GetAll());
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(models);
        }

        [HttpGet("{id}")]
        public ActionResult<ConditionerModel> GetModelById(int id)
        {
            var model = _modelRepository.GetById(id);
            if (model == null)
            {
                return NotFound();
            }
            return model;
        }

        [HttpGet("search/{keyword}")]
        public ActionResult<IEnumerable<ConditionerModel>> SearchModels(string keyword)
        {
            return _modelRepository.GetByNameContaining(keyword);
        }


    }
}
