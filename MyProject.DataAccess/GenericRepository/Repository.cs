using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MyProject.DataAccess.Context;
using MyProject.DataAccess.Models.Abstratction;
using System.Linq.Expressions;

namespace MyProject.DataAccess.GenericRepository;

public class Repository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
{
    protected readonly ILogger _logger;
    protected DataBaseContext _context;

    public Repository(DataBaseContext context, ILogger logger)
    {
        _context = context;
        _logger = logger;
    }

    public async Task<TEntity> AddAsync(TEntity entity)
    {
        await _context.Set<TEntity>().AddAsync(entity);

        await _context.SaveChangesAsync();

        return entity;
    }

    public async Task AddRange(IEnumerable<TEntity> entities)
    {
        await _context.Set<TEntity>().AddRangeAsync(entities);
    }

    public async Task<bool> CheckDuplicate(Expression<Func<TEntity, bool>> predicate)
    {
        return await _context.Set<TEntity>().AnyAsync(predicate);
    }

    public async Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate)
    {
        return await _context.Set<TEntity>().CountAsync(predicate);
    }

    public async Task Delete(TEntity entity)
    {
        entity.IsDeleted = true;
        await _context.SaveChangesAsync();
    }

    public async Task DeleteRange(IEnumerable<TEntity> entities)
    {
        entities.ToList().ForEach(p => p.IsDeleted = true);

        await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<TEntity>> Find(Expression<Func<TEntity, bool>> predicate)
    {
        return await _context.Set<TEntity>().Where(predicate).ToListAsync().ConfigureAwait(false);
    }

    public async Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate)
    {
        return await _context.Set<TEntity>().FirstOrDefaultAsync(predicate);
    }

    public async Task<TEntity> Get(int id)
    {
        return await _context.Set<TEntity>().FindAsync(id).ConfigureAwait(false);
    }

    public async Task<IEnumerable<TEntity>> GetAll()
    {
        return await _context.Set<TEntity>().ToListAsync().ConfigureAwait(false);
    }

    public void RemovePermanent(TEntity entity)
    {
        _context.Set<TEntity>().Remove(entity);
    }

    public void RemovePermanentRange(IEnumerable<TEntity> entities)
    {
        _context.Set<TEntity>().RemoveRange(entities);
    }

    public async Task<TEntity> SafeGet(int id)
    {
        return await _context.Set<TEntity>().Where(p => !p.IsDeleted).FirstAsync(p => p.Id == id).ConfigureAwait(false);
    }
}
