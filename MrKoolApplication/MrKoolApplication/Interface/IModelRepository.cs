
using MrKool.Models;

namespace MrKoolApplication.Interface
{
    public interface IModelRepository
    {
        ConditionerModel GetById(int stationID);
        List<ConditionerModel> GetAll();
        List<ConditionerModel> GetByNameContaining(string name);

        List<ConditionerModel> GetModels();
        bool ModelExist(int modelID);
        bool UpdateModel(ConditionerModel model);

        bool CreateModel(ConditionerModel model);

        bool DeleteModel(ConditionerModel model);
    }
}
