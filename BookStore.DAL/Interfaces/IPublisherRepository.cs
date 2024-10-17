using BookStore.DAL.Entitites;

namespace BookStore.DAL.Interface;

public interface IPublisherRepository : IBaseRepository<Publisher>
{
    Task<Publisher> GetPublisherByCompanyAsync(string companyName);

    Task<Publisher> GetPublisherByCompanyWithDetails(string companyName);

    Task<Publisher> GetPublisherByIsbn13(string isbn13);
}
