using BookStore.BLL.Interfaces;
using BookStore.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.WebAPI.Controllers;

[ApiController]
[Route("/books")]
public class BookController : Controller
{
    private readonly IBookService _service;

    public BookController(IBookService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<BookListDto>>> GetAllBooksAsync()
    {
        try
        {
            var books = await _service.GetAllBooksAsync();
            return Ok(books);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<BookListDto>> GetBookByIdAsync(Guid id)
    {
        try
        {
            var book = await _service.GetBookByIdAsync(id);
            return Ok(book);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("find/{isbn13}")]
    public async Task<ActionResult<BookListDto>> GetBookByIsbn13Async(string isbn13)
    {
        try
        {
            var book = await _service.GetBookByIsbn13Async(isbn13);
            return Ok(book);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("{authorId}/authors")]
    public async Task<ActionResult<IEnumerable<BookListDto>>> GetBooksByAuthorsAsync(Guid authorId)
    {
        try
        {
            var books = await _service.GetBooksByAuthorsAsync(authorId);
            return Ok(books);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("{genreId}/genres")]
    public async Task<ActionResult<IEnumerable<BookListDto>>> GetBooksByGenreAsync(Guid genreId)
    {
        try
        {
            var books = await _service.GetBooksByGenresAsync(genreId);
            return Ok(books);
        }
        catch(Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("{publisherId}/publishers")]
    public async Task<ActionResult<IEnumerable<BookListDto>>> GetBooksByPublisherAsync(Guid publisherId)
    {
        try
        {
            var books = await _service.GetBooksByPublisherAsync(publisherId);
            return Ok(books);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost]
    public async Task<ActionResult> AddBookAsync([FromBody] BookCreateDto book)
    {
        try
        {
            await _service.AddBookAsync(book);
            return Ok(book);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPut]
    public async Task<ActionResult> UpdateBookAsync([FromBody] BookUpdateDto bookToUpdate)
    {
        try
        {
            await _service.UpdateBookAsync(bookToUpdate);
            return Ok(bookToUpdate);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpDelete("{isbn13}")]
    public async Task<ActionResult> DeleteBookByIsbn13Async(string isbn13)
    {
        try
        {
            await _service.DeleteBookByIsbn13Async(isbn13);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
