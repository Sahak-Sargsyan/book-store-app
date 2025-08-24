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
        var authors = await _service.GetAllAuthorsAsync();
        return Ok(authors);
    }

    [HttpGet("find/{isbn13}")]
    public async Task<ActionResult<IEnumerable<AuthorListDto>>> GetAuthorsByIsbn13Async(string isbn13)
    {
        var authors = await _service.GetAuthorsByIsbn13Async(isbn13);
        return Ok(authors);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<AuthorListDto>> GetAuthorByIdAsync(Guid id)
    {
        var author = await _service.GetAuthorByIdAsync(id);
        return Ok(author);
    }

    [HttpPost]
    public async Task<ActionResult> AddAuthorAsync([FromBody] AuthorCreateDto author)
    {
        await _service.AddAuthorAsync(author);
        return Ok(author);
    }

    [HttpPut]
    public async Task<ActionResult> UpdateAuthorAsync([FromBody] AuthorUpdateDto authorToUpdate)
    {
        await _service.UpdateAuthorAsync(authorToUpdate);
        return Ok(authorToUpdate);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteAuthorAsync(Guid id)
    {
        await _service.DeleteAuthorByIdAsync(id);
        return Ok();
    }
}
