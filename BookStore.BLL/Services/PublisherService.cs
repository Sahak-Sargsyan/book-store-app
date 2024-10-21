using AutoMapper;
using BookStore.BLL.Interfaces;
using BookStore.DAL.Entitites;
using BookStore.DAL.Interface;
using BookStore.Dtos;

namespace BookStore.BLL.Services;

public class PublisherService : IPublisherService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public PublisherService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task AddPublisherAsync(PublisherCreateDto model)
    {
        var entity = _mapper.Map<Publisher>(model);
        await _unitOfWork.PublisherRepository.AddAsync(entity);
        await _unitOfWork.SaveAsync();
    }

    public async Task DeletePublisherByIdAsync(Guid id)
    {
        _unitOfWork.PublisherRepository.DeleteById(id);
        await _unitOfWork.SaveAsync();
    }

    public async Task<IEnumerable<PublisherListDto>> GetAllPublishersAsync()
    {
        var entities = await _unitOfWork.PublisherRepository.GetAllAsync();
        var publishers = _mapper.Map<IEnumerable<PublisherListDto>>(entities);
        return publishers;
    }

    public async Task<PublisherListDto> GetPublisherByIdAsync(Guid id)
    {
        var entity = await _unitOfWork.PublisherRepository.GetByIdAsync(id);
        var publisher = _mapper.Map<PublisherListDto>(entity);
        return publisher;
    }

    public async Task<PublisherListDto> GetPublisherByIsbn13Async(string isbn13)
    {
        var entity = await _unitOfWork.PublisherRepository.GetPublisherByIsbn13(isbn13);
        var publisher = _mapper.Map<PublisherListDto>(entity);
        return publisher;
    }

    public async Task UpdatePublisherAsync(PublisherUpdateDto model)
    {
        var updateEntity = _mapper.Map<Publisher>(model);
        _unitOfWork.PublisherRepository.Update(updateEntity);
        await _unitOfWork.SaveAsync();
    }
}
