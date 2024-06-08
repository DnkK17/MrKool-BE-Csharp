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

        public List<ConditionerModel> GetModels()
        {
            return _context.Models.ToList();
        }


        public List<ConditionerModel> GetByNameContaining(string name)
        {
            return _context.Models.Where(a => a.Title.Contains(name)).ToList();
        }

        //CRUD
        public bool ModelExist(int modelID)
        {
            return _context.Set<ConditionerModel>().Any(a => a.ConditionerModelID== modelID);
        }
        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool CreateModel(ConditionerModel model)
        {
            _context.Add(model);
            return Save();
        }

        public bool UpdateModel(ConditionerModel model)
        {
            _context.Update(model);
            return Save();
        }

        public bool DeleteModel(ConditionerModel model)
        {
            _context.Models.Remove(model);
            return Save();
        }
    }
}
