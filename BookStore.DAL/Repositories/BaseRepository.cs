using BookStore.DAL.Data;
using BookStore.DAL.Entitites;
using BookStore.DAL.Interface;
using Microsoft.EntityFrameworkCore;

namespace BookStore.DAL.Repository;

public class BaseRepository<TEntity> : IBaseRepository<TEntity>
    where TEntity : BaseEntity, new()
{
    private readonly BookStoreDbContext _dbContext;
    private readonly DbSet<TEntity> _dbSet;

    public BaseRepository(BookStoreDbContext context)
    {
        _dbContext = context;
        _dbSet = _dbContext.Set<TEntity>();
    }

    public async Task AddAsync(TEntity entity)
    {
        await _dbSet.AddAsync(entity);
    }

    public void DeleteById(Guid id)
    {
        var entity = _dbSet.Find(id);
        if (entity != null)
        {
            _dbSet.Remove(entity);
        }
    }

    public async Task<IEnumerable<TEntity>> GetAllAsync()
    {
        return await _dbSet.AsNoTracking().ToListAsync();
    }

    public async Task<TEntity> GetByIdAsync(Guid id)
    {
        return await _dbSet.FindAsync(id);
    }

    public void Update(TEntity entity)
    {
        _dbSet.Attach(entity);
        _dbContext.Entry(entity).State = EntityState.Modified;
    }
}
