using BookStore.DAL.Entitites;

namespace BookStore.DAL.Interface;

public interface IAuthorRepository : IBaseRepository<Author>
{
    Task<IEnumerable<Author>> GetAuthorsOfBookAsync(string isbn13);
}
