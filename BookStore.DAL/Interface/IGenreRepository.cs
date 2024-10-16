using BookStore.DAL.Entitites;

namespace BookStore.DAL.Interface;

public interface IGenreRepository : IBaseRepository<Genre>
{
    Task<Genre> GetGenreByNameAsync(string name);

    Task<Genre> GetGenreByNameWithDetailsAsync(string name);

    Task<IEnumerable<Genre>> GetGenresByIsbn13(string isbn13);
}
