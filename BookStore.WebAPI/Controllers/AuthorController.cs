using BookStore.BLL.Interfaces;
using BookStore.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.WebAPI.Controllers;

[ApiController]
[Route("authors")]
public class AuthorController : Controller
{
    private readonly IAuthorService _service;

    public AuthorController(IAuthorService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<AuthorListDto>>> GetAllAuthorsAsync()
    {
        try
        {
            var authors = await _service.GetAllAuthorsAsync();
            return Ok(authors);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("find/{isbn13}")]
    public async Task<ActionResult<IEnumerable<AuthorListDto>>> GetAuthorsByIsbn13Async(string isbn13)
    {
        try
        {
            var authors = await _service.GetAuthorsByIsbn13Async(isbn13);
            return Ok(authors);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<AuthorListDto>> GetAuthorByIdAsync(Guid id)
    {
        try
        {
            var author = await _service.GetAuthorByIdAsync(id);
            return Ok(author);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost]
    public async Task<ActionResult> AddAuthorAsync([FromBody] AuthorCreateDto author)
    {
        try
        {
            await _service.AddAuthorAsync(author);
            return Ok(author);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPut]
    public async Task<ActionResult> UpdateAuthorAsync([FromBody] AuthorUpdateDto authorToUpdate)
    {
        try
        {
            await _service.UpdateAuthorAsync(authorToUpdate);
            return Ok(authorToUpdate);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteAuthorAsync(Guid id)
    {
        try
        {
            await _service.DeleteAuthorByIdAsync(id);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
