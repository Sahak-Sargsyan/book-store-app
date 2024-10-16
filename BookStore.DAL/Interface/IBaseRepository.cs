using BookStore.DAL.Entitites;

namespace BookStore.DAL.Interface;

public interface IBaseRepository<TEntity>
    where TEntity : BaseEntity, new()
{
    Task AddAsync(TEntity entity);

    Task<IEnumerable<TEntity>> GetAllAsync();

    Task<TEntity> GetByIdAsync(Guid id);

    void Update(TEntity entity);

    void DeleteById(TEntity entity);
}
