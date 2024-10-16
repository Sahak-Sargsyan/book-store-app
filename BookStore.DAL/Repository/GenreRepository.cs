using BookStore.DAL.Data;
using BookStore.DAL.Entitites;
using BookStore.DAL.Interface;
using Microsoft.EntityFrameworkCore;

namespace BookStore.DAL.Repository;

public class GenreRepository : BaseRepository<Genre>, IGenreRepository
{
    private readonly BookStoreDbContext _dbContext;
    private readonly DbSet<Genre> _dbSet;

    public GenreRepository(BookStoreDbContext context)
        : base(context)
    {
        _dbContext = context;
        _dbSet = _dbContext.Set<Genre>();
    }

    public async Task<Genre> GetGenreByNameAsync(string name)
    {
        return await _dbSet.AsNoTracking().FirstOrDefaultAsync(g => g.Name == name);
    }

    public async Task<Genre> GetGenreByNameWithDetailsAsync(string name)
    {
        return await _dbSet.AsNoTracking().Include(g => g.Books).FirstOrDefaultAsync(g => g.Name == name);
    }

    public async Task<IEnumerable<Genre>> GetGenresByIsbn13(string isbn13)
    {
        return await _dbSet.Where(g => g.Books.Any(b => b.Book.Isbn13 == isbn13)).ToListAsync();
    }
}
