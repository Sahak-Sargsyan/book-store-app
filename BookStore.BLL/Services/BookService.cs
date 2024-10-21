using AutoMapper;
using BookStore.BLL.Interfaces;
using BookStore.DAL.Entitites;
using BookStore.DAL.Interface;
using BookStore.Dtos;

namespace BookStore.BLL.Services;

public class BookService : IBookService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public BookService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task AddBookAsync(BookCreateDto model)
    {
        var entity = _mapper.Map<Book>(model);
        entity.Id = Guid.NewGuid();
        await _unitOfWork.BookRepository.AddAsync(entity);
        await _unitOfWork.SaveAsync();
    }

    public async Task DeleteBookByIsbn13Async(string isbn13)
    {
        var entity = await _unitOfWork.BookRepository.GetBookByIsbn13Async(isbn13);
        var id = entity.Id;
        _unitOfWork.BookRepository.DeleteById(id);
        await _unitOfWork.SaveAsync();
    }

    public async Task<IEnumerable<BookListDto>> GetAllBooksAsync()
    {
        var entities = await _unitOfWork.BookRepository.GetAllAsync();
        var books = _mapper.Map<IEnumerable<BookListDto>>(entities);
        return books;
    }

    public async Task<BookListDto> GetBookByIdAsync(Guid id)
    {
        var entity = await _unitOfWork.BookRepository.GetByIdAsync(id);
        var book = _mapper.Map<BookListDto>(entity);
        return book;
    }

    public async Task<BookListDto> GetBookByIsbn13Async(string isbn13)
    {
        var entity = await _unitOfWork.BookRepository.GetBookByIsbn13Async(isbn13);
        var book = _mapper.Map<BookListDto>(entity);
        return book;
    }

    public async Task<IEnumerable<BookListDto>> GetBooksByAuthorsAsync(IEnumerable<Guid> authors)
    {
        var entities = await _unitOfWork.BookRepository.GetBooksByAuthorAsync(authors);
        var books = _mapper.Map<IEnumerable<BookListDto>>(entities);
        return books;
    }

    public Task<IEnumerable<BookListDto>> GetBooksByGenresAsync(Guid genreId)
    {
        throw new NotImplementedException();
    }

    public Task UpdateBookAsync(BookUpdateDto model)
    {
        throw new NotImplementedException();
    }
}
