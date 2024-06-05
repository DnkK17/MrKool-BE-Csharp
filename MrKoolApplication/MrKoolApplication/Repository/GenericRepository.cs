using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

public interface GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
{

    Task<List<TEntity>> GetAllAsync(params Expression<Func<TEntity, object>>[] includes);
    Task<List<TEntity?>> GetAllAsyncByID(int id, params Expression<Func<TEntity, object>>[] includes);

    Task AddAsync(TEntity entity);

    void UpdateAsync(TEntity entity);

    void SoftRemove(TEntity entity);
    
}
