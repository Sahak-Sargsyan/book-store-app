using BookStore.BLL.Interfaces;
using BookStore.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.WebAPI.Controllers;

[ApiController]
[Route("genres")]
public class GenreController : Controller
{
    private readonly IGenreService _service;

    public GenreController(IGenreService service)
    {
        _service = service;
    }

    [Authorize]
    [HttpGet]
    public async Task<ActionResult<IEnumerable<GenreListDto>>> GetAllGenresAsync()
    {
        var genres = await _service.GetAllGenresAsync();
        return Ok(genres);
    }

    [HttpGet("find/{isbn13}")]
    public async Task<ActionResult<IEnumerable<GenreListDto>>> GetGenresByIsbn13Async(string isbn13)
    {
        var genres = await _service.GetGenresByIsbn13Async(isbn13);
        return Ok(genres);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GenreListDto>> GetGenreByIdAsync(Guid id)
    {
        var genre = await _service.GetGenreByIdAsync(id);
        return Ok(genre);
    }

    [HttpPost]
    public async Task<ActionResult> AddGenreAsync([FromBody] GenreCreateDto genre)
    {
        await _service.AddGenreAsync(genre);
        return Ok(genre);
    }

    [HttpPut]
    public async Task<ActionResult> UpdateGenreAsync([FromBody] GenreUpdateDto genreToUpdate)
    {
        await _service.UpdateGenreAsync(genreToUpdate);
        return Ok(genreToUpdate);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteGenreAsync(Guid id)
    {
        await _service.DeleteGenreByIdAsync(id);
        return Ok();
    }
}
