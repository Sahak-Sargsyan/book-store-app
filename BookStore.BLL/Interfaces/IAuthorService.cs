using BookStore.Dtos;

namespace BookStore.BLL.Interfaces;

public interface IAuthorService
{
    Task<IEnumerable<AuthorListDto>> GetAllAuthorsAsync();

    Task<AuthorListDto> GetAuthorByIdAsync(Guid id);

    Task<IEnumerable<AuthorListDto>> GetAuthorsByIsbn13Async(string isbn13);

    Task AddAuthorAsync(AuthorCreateDto model);

    Task UpdateAuthorAsync(AuthorUpdateDto model);

    Task DeleteAuthorByIdAsync(Guid id);
}
