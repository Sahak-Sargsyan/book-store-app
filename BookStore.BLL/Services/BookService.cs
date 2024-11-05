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

    public async Task<IEnumerable<BookListDto>> GetBooksByAuthorsAsync(Guid authorId)
    {
        var entities = await _unitOfWork.BookRepository.GetBooksByAuthorAsync(authorId);
        var books = _mapper.Map<IEnumerable<BookListDto>>(entities);
        return books;
    }

    public async Task<IEnumerable<BookListDto>> GetBooksByGenresAsync(Guid genreId)
    {
        var entity = await _unitOfWork.BookRepository.GetBooksByGenreAsync(genreId);
        var book = _mapper.Map<IEnumerable<BookListDto>>(entity);
        return book;
    }

    public async Task<IEnumerable<BookListDto>> GetBooksByPublisherAsync(Guid publisherId)
    {
        var entities = await _unitOfWork.BookRepository.GetBooksByPublisherAsync(publisherId);
        var books = _mapper.Map<IEnumerable<BookListDto>>(entities);
        return books;
    }

    public async Task UpdateBookAsync(BookUpdateDto model)
    {
        var entity = _mapper.Map<Book>(model);
        _unitOfWork.BookRepository.Update(entity);
        await _unitOfWork.SaveAsync();
    }
}
