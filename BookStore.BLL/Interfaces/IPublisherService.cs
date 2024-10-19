using BookStore.Dtos;

namespace BookStore.BLL.Interfaces;

public interface IPublisherService
{
    Task<IEnumerable<PublisherListDto>> GetAllPublishersAsync();

    Task<PublisherListDto> GetPublisherByIdAsync(Guid id);

    Task<PublisherListDto> GetPublisherByIsbn13Async(string isbn13);

    Task AddPublisherAsync(PublisherCreateDto model);

    Task DeletePublisherByIdAsync(Guid id);

    Task UpdatePublisherAsync(PublisherUpdateDto model);
}
