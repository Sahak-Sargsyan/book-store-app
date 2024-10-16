using BookStore.DAL.Data;
using BookStore.DAL.Entitites;
using BookStore.DAL.Interface;
using Microsoft.EntityFrameworkCore;

namespace BookStore.DAL.Repository;

public class PublisherRepository : BaseRepository<Publisher>, IPublisherRepository
{
    private readonly BookStoreDbContext _dbContext;
    private readonly DbSet<Publisher> _dbSet;

    public PublisherRepository(BookStoreDbContext context)
        : base(context)
    {
        _dbContext = context;
        _dbSet = _dbContext.Set<Publisher>();
    }
    public async Task<Publisher> GetPublisherByCompanyAsync(string companyName)
    {
        return await _dbSet.AsNoTracking().FirstOrDefaultAsync(p => p.CompanyName == companyName);
    }

    public async Task<Publisher> GetPublisherByCompanyWithDetails(string companyName)
    {
        return await _dbSet.AsNoTracking().Include(p => p.Books).FirstOrDefaultAsync(p => p.CompanyName == companyName);
    }

    public async Task<Publisher> GetPublisherByIsbn13(string isbn13)
    {
        return await _dbSet.Where(p => p.Books.Any(b => b.Isbn13 == isbn13)).FirstOrDefaultAsync();
    }
}
