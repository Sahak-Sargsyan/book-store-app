using BookStore.DAL.Data;
using BookStore.DAL.Entitites;
using BookStore.DAL.Interface;
using Microsoft.EntityFrameworkCore;

namespace BookStore.DAL.Repository;

public class AuthorRepository : BaseRepository<Author>, IAuthorRepository
{
    private readonly BookStoreDbContext _dbContext;
    private readonly DbSet<Author> _dbSet;

    public AuthorRepository(BookStoreDbContext context)
        : base(context)
    {
        _dbContext = context;
        _dbSet = _dbContext.Set<Author>();
    }

    public async Task<IEnumerable<Author>> GetAuthorsOfBookAsync(string isbn13)
    {
        return await _dbSet.Where(a => a.Books.Any(ab => ab.Book.Isbn13 == isbn13)).ToListAsync();
    }
}
