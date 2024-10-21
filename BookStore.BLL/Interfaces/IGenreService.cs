using BookStore.Dtos;

namespace BookStore.BLL.Interfaces;

public interface IGenreService
{
    Task<IEnumerable<GenreListDto>> GetAllGenresAsync();

    Task<GenreListDto> GetGenreByIdAsync(Guid id);

    Task<IEnumerable<GenreListDto>> GetGenresByIsbn13Async(string isbn13);

    Task AddGenreAsync(GenreCreateDto model);

    Task DeleteGenreByIdAsync(Guid id);

    Task UpdateGenreAsync(GenreUpdateDto model);
}
