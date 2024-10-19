using BookStore.Dtos;

namespace BookStore.BLL.Interfaces;

public interface IBookService
{
    Task<IEnumerable<BookListDto>> GetAllBooksAsync();

    Task<BookListDto> GetBookByIdAsync(Guid id);

    Task<BookListDto> GetBookByIsbn13Async(string isbn13);

    Task<IEnumerable<BookListDto>> GetBooksByAuthorsAsync(IEnumerable<Guid> authors);

    Task<IEnumerable<BookListDto>> GetBooksByGenresAsync(IEnumerable<Guid> genres);

    Task AddBookAsync(BookCreateDto model);

    Task DeleteBookByIsbn13Async(string isbn13);

    Task UpdateBookAsync(BookUpdateDto model);
}
