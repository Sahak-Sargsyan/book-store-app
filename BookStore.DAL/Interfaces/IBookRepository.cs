using BookStore.DAL.Entitites;
namespace BookStore.DAL.Interface;

public interface IBookRepository : IBaseRepository<Book>
{
    Task<Book> GetBookByIsbn13Async(string isbn13);

    Task<Book> GetBookByIsbn13WithDetailsAsync(string isbn13);

    Task<IEnumerable<Book>> GetBooksByPublisherAsync(Guid publisherId);

    Task<IEnumerable<Book>> GetBooksByGenreAsync(Guid genreId);

    Task<IEnumerable<Book>> GetBooksByAuthorAsync(IEnumerable<Guid> authors);
}
