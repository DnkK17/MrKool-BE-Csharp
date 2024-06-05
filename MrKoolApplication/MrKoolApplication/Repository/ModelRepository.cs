using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MrKool.Data;
using MrKool.Models;
using MrKoolApplication.Interface;
using System.Linq.Expressions;

namespace MrKoolApplication.Repository
{
    public class ModelRepository : IModelRepository
    {

        private DBContext _context;

        private readonly IMapper _mapper;
        public ModelRepository(DBContext context)
        {
            _context = context;
        }
        public ConditionerModel GetById(int conditionerModelID)
        {
            return _context.Set<ConditionerModel>().SingleOrDefault(a => a.ConditionerModelID == conditionerModelID);
        }

        public List<ConditionerModel> GetAll()
        {
            return _context.Models.ToList();
        }


        public List<ConditionerModel> GetByNameContaining(string name)
        {
            return _context.Models.Where(a => a.Title.Contains(name)).ToList();
        }

     
    }
}
