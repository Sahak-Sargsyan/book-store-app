using BookStore.BLL.Interfaces;
using BookStore.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.WebAPI.Controllers;

public class GenreController : Controller
{
    private readonly IGenreService _service;

    public GenreController(IGenreService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<GenreListDto>>> GetAllGenresAsync()
    {
        try
        {
            var genres = await _service.GetAllGenresAsync();
            return Ok(genres);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("find/{isbn13}")]
    public async Task<ActionResult<IEnumerable<GenreListDto>>> GetGenresByIsbn13Async(string isbn13)
    {
        try
        {
            var genres = await _service.GetGenresByIsbn13Async(isbn13);
            return Ok(genres);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GenreListDto>> GetGenreByIdAsync(Guid id)
    {
        try
        {
            var genre = await _service.GetGenreByIdAsync(id);
            return Ok(genre);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost]
    public async Task<ActionResult> AddGenreAsync([FromBody] GenreCreateDto genre)
    {
        try
        {
            await _service.AddGenreAsync(genre);
            return Ok(genre);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPut]
    public async Task<ActionResult> UpdateGenreAsync([FromBody] GenreUpdateDto genreToUpdate)
    {
        try
        {
            await _service.UpdateGenreAsync(genreToUpdate);
            return Ok(genreToUpdate);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteGenreAsync(Guid id)
    {
        try
        {
            await _service.DeleteGenreByIdAsync(id);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
