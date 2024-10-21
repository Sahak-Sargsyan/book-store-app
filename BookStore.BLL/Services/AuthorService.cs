using AutoMapper;
using BookStore.BLL.Interfaces;
using BookStore.DAL.Entitites;
using BookStore.DAL.Interface;
using BookStore.Dtos;

namespace BookStore.BLL.Services;

public class AuthorService : IAuthorService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public AuthorService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task AddAuthorAsync(AuthorCreateDto model)
    {
        var entity = _mapper.Map<Author>(model);
        await _unitOfWork.AuthorRepository.AddAsync(entity);
        await _unitOfWork.SaveAsync();
    }

    public async Task DeleteAuthorByIdAsync(Guid id)
    {
        _unitOfWork.AuthorRepository.DeleteById(id);
        await _unitOfWork.SaveAsync();
    }

    public async Task<IEnumerable<AuthorListDto>> GetAllAuthorsAsync()
    {
        var entities = await _unitOfWork.AuthorRepository.GetAllAsync();
        var authors = _mapper.Map<IEnumerable<AuthorListDto>>(entities);
        return authors;
    }

    public async Task<AuthorListDto> GetAuthorByIdAsync(Guid id)
    {
        var entity = await _unitOfWork.AuthorRepository.GetByIdAsync(id);
        var author = _mapper.Map<AuthorListDto>(entity);
        return author;
    }

    public async Task<IEnumerable<AuthorListDto>> GetAuthorsByIsbn13Async(string isbn13)
    {
        var entities = await _unitOfWork.AuthorRepository.GetAuthorsOfBookAsync(isbn13);
        var authors = _mapper.Map<IEnumerable<AuthorListDto>>(entities);
        return authors;
    }

    public async Task UpdateAuthorAsync(AuthorUpdateDto model)
    {
        var updateEntity = _mapper.Map<Author>(model);
        _unitOfWork.AuthorRepository.Update(updateEntity);
        await _unitOfWork.SaveAsync();
    }
}
