using System.Linq.Expressions;

public interface IGenericRepository<TEntity> where TEntity : class
{
    Task<List<TEntity>> GetAllAsync(params Expression<Func<TEntity, object>>[] includes);
  
}
