using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MrKool.Data;
using MrKool.DTO;
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
        private readonly DBContext _context;
        public ModelController(IModelRepository modelRepository, IMapper mapper, DBContext context)
        {
            _modelRepository = modelRepository;
            _mapper = mapper;
            _context = context;
        }

        [HttpGet]
        [ProducesResponseType(200)]
        public async Task<ActionResult<ConditionerModelDTO>> GetAllModels()
        {
            var models =  _modelRepository.GetAll();
            var modelDTOS = _mapper.Map<IEnumerable<ConditionerModelDTO>>(models);
            return Ok(modelDTOS);
        }

        [HttpGet("{id}")]
        public ActionResult<ConditionerModelDTO> GetModelById(int id)
        {
            var model = _modelRepository.GetById(id);
            if (model == null)
            {
                return NotFound();
            }
            var modelMap = _mapper.Map<ConditionerModelDTO>(model);
            return Ok(modelMap);
        }

        [HttpGet("search/{keyword}")]
        public ActionResult<ConditionerModelDTO> SearchModels(string keyword)
        {
            var model = _modelRepository.GetByNameContaining(keyword);
            var modelMap = _mapper.Map<ConditionerModelDTO>(model);
            return modelMap;
        }



        //CRUD

        [HttpPost("/CreateModel")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateModel([FromBody] ConditionerModelDTO modelCreate)
        {
            if (modelCreate == null) return BadRequest();
          
            var modelMap = _mapper.Map<ConditionerModel>(modelCreate);
            if (!_modelRepository.CreateModel(modelMap))
                return StatusCode(500);

            return Ok("Successfully");
        }

        [HttpPut("/UpdateModel/{modelID}")]
        public IActionResult UpdateModel(int modelID, [FromBody] ConditionerModelDTO modelUpdate)
        {
            if (modelUpdate == null) return BadRequest();
            if (!_modelRepository.ModelExist(modelID)) return BadRequest();
            var modelMap = _mapper.Map<ConditionerModel>(modelUpdate);
            if (!_modelRepository.UpdateModel(modelMap))
            {
                return StatusCode(500);
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteModel(int id)
        {
            var model = _context.Models.Find(id);
            if (model == null)
            {
                return NotFound();
            }
            model.IsDeleted = true;
            model.Status = false;
            _context.SaveChanges();
            return NoContent();
        }
    }
}
