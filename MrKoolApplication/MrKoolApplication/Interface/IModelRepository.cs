
using MrKool.Models;

namespace MrKoolApplication.Interface
{
    public interface IModelRepository
    {
        ConditionerModel GetById(int stationID);
        List<ConditionerModel> GetAll();
        List<ConditionerModel> GetByNameContaining(string name);
    }
}
