using BookStore.DAL.Data;
using BookStore.DAL.Entitites;
using BookStore.DAL.Interface;
using Microsoft.EntityFrameworkCore;

namespace BookStore.DAL.Repository;

#pragma warning disable
public class BookRepository : BaseRepository<Book>, IBookRepository
{
    private readonly BookStoreDbContext _dbContext;
    private readonly DbSet<Book> _dbSet;

    public BookRepository(BookStoreDbContext context)
        : base(context)
    {
        _dbContext = context;
        _dbSet = _dbContext.Set<Book>();
    }
    public async Task<Book> GetBookByIsbn13Async(string isbn13)
    {
        return await _dbSet.AsNoTracking().FirstOrDefaultAsync(b => b.Isbn13 == isbn13);
    }

    public async Task<Book> GetBookByIsbn13WithDetailsAsync(string isbn13)
    {
        return await _dbSet.AsNoTracking()
            .Include(b => b.Authors)
            .Include(b => b.Genres)
            .Include(b => b.Publisher)
            .AsSplitQuery()
            .FirstOrDefaultAsync(b => b.Isbn13 == isbn13);
    }

    public async Task<IEnumerable<Book>> GetBooksByAuthorAsync(IEnumerable<Guid> authors)
    {
        var list = new List<Book>();
        foreach(var author in authors)
        {
            list.AddRange(await _dbSet.Where(b => b.Authors.Any(ba => ba.AuthorId == author)).ToListAsync());
        }

        return list;
    }

    public async Task<IEnumerable<Book>> GetBooksByGenreAsync(Guid genreId)
    {
        return await _dbSet.Where(b => b.Genres.Any(ba => ba.GenreId == genreId)).ToListAsync();
    }

    public async Task<IEnumerable<Book>> GetBooksByPublisherAsync(Guid publisherId)
    {
        return await _dbSet.Where(b => b.Publisher.Id == publisherId).ToListAsync();
    }
}
