using AutoMapper;
using BookStore.BLL.Interfaces;
using BookStore.BLL.Validation;
using BookStore.DAL.Entitites;
using BookStore.DAL.Interface;
using BookStore.Dtos;

namespace BookStore.BLL.Services;

public class GenreService : IGenreService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly IBookStoreValidation _validation;

    public GenreService(IUnitOfWork unitOfWork, IMapper mapper, IBookStoreValidation validation)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _validation = validation;
    }

    public async Task AddGenreAsync(GenreCreateDto model)
    {
        _validation.ValidateModel(model);

        var entity = _mapper.Map<Genre>(model);
        await _unitOfWork.GenreRepository.AddAsync(entity);
        await _unitOfWork.SaveAsync();
    }

    public async Task DeleteGenreByIdAsync(Guid id)
    {
        var entity = await _unitOfWork.GenreRepository.GetByIdAsync(id);
        _validation.ValidateEntityExistense(entity);

        _unitOfWork.GenreRepository.DeleteById(id);
        await _unitOfWork.SaveAsync();
    }

    public async Task<IEnumerable<GenreListDto>> GetAllGenresAsync()
    {
        var entities = await _unitOfWork.GenreRepository.GetAllAsync();
        var genres = _mapper.Map<IEnumerable<GenreListDto>>(entities);
        return genres;
    }

    public async Task<GenreListDto> GetGenreByIdAsync(Guid id)
    {
        var entity = await _unitOfWork.GenreRepository.GetByIdAsync(id);
        _validation.ValidateEntityExistense(entity);

        var genre = _mapper.Map<GenreListDto>(entity);
        return genre;
    }

    public async Task<IEnumerable<GenreListDto>> GetGenresByIsbn13Async(string isbn13)
    {
        var entities = await _unitOfWork.GenreRepository.GetGenresByIsbn13(isbn13);
        _validation.ValidateEntityExistense(entities);

        var genres = _mapper.Map<IEnumerable<GenreListDto>>(entities);
        return genres;
    }

    public async Task UpdateGenreAsync(GenreUpdateDto model)
    {
        _validation.ValidateModel(model);

        var updateEntity = _mapper.Map<Genre>(model);
        _unitOfWork.GenreRepository.Update(updateEntity);
        await _unitOfWork.SaveAsync();
    }
}
