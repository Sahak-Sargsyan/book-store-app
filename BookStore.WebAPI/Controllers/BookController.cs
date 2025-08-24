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
        var books = await _service.GetAllBooksAsync();
        return Ok(books);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<BookListDto>> GetBookByIdAsync(Guid id)
    {
        var book = await _service.GetBookByIdAsync(id);
        return Ok(book);
    }

    [HttpGet("find/{isbn13}")]
    public async Task<ActionResult<BookListDto>> GetBookByIsbn13Async(string isbn13)
    {
        var book = await _service.GetBookByIsbn13Async(isbn13);
        return Ok(book);
    }

    [HttpGet("{authorId}/authors")]
    public async Task<ActionResult<IEnumerable<BookListDto>>> GetBooksByAuthorsAsync(Guid authorId)
    {
        var books = await _service.GetBooksByAuthorsAsync(authorId);
        return Ok(books);
    }

    [HttpGet("{genreId}/genres")]
    public async Task<ActionResult<IEnumerable<BookListDto>>> GetBooksByGenreAsync(Guid genreId)
    {
        var books = await _service.GetBooksByGenresAsync(genreId);
        return Ok(books);
    }

    [HttpGet("{publisherId}/publishers")]
    public async Task<ActionResult<IEnumerable<BookListDto>>> GetBooksByPublisherAsync(Guid publisherId)
    {
        var books = await _service.GetBooksByPublisherAsync(publisherId);
        return Ok(books);
    }

    [HttpPost]
    public async Task<ActionResult> AddBookAsync([FromBody] BookCreateDto book)
    {
        await _service.AddBookAsync(book);
        return Ok(book);
    }

    [HttpPut]
    public async Task<ActionResult> UpdateBookAsync([FromBody] BookUpdateDto bookToUpdate)
    {
        await _service.UpdateBookAsync(bookToUpdate);
        return Ok(bookToUpdate);
    }

    [HttpDelete("{isbn13}")]
    public async Task<ActionResult> DeleteBookByIsbn13Async(string isbn13)
    {
        await _service.DeleteBookByIsbn13Async(isbn13);
        return Ok();
    }
}
