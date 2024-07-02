using System.Linq.Expressions;

namespace MyProject.DataAccess.GenericRepository;

public interface IRepository<TEntity> where TEntity : class
{
    Task<TEntity> Get(int id);
    Task<TEntity> SafeGet(int id);
    Task<IEnumerable<TEntity>> GetAll();
    Task<IEnumerable<TEntity>> Find(Expression<Func<TEntity, bool>> predicate);
    Task<TEntity> AddAsync(TEntity entity);
    Task AddRange(IEnumerable<TEntity> entities);
    void RemovePermanent(TEntity entity);
    Task Delete(TEntity entity);
    Task DeleteRange(IEnumerable<TEntity> entities);
    void RemovePermanentRange(IEnumerable<TEntity> entities);
    Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate);
    Task<bool> CheckDuplicate(Expression<Func<TEntity, bool>> predicate);
    Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate);
}
