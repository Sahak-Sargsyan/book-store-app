using BookStore.DAL.Interface;
using BookStore.DAL.Repository;

namespace BookStore.DAL.Data;

public class UnitOfWork : IUnitOfWork, IDisposable
{
    private readonly BookStoreDbContext _dbContext;

    private bool _disposed;

    public UnitOfWork(BookStoreDbContext context)
    {
        _dbContext = context;
        BookRepository = new BookRepository(_dbContext);
        AuthorRepository = new AuthorRepository(_dbContext);
        GenreRepository = new GenreRepository(_dbContext);
        PublisherRepository = new PublisherRepository(_dbContext);
    }

    public IBookRepository BookRepository { get; set; }

    public IAuthorRepository AuthorRepository { get; set; }

    public IGenreRepository GenreRepository { get; set; }

    public IPublisherRepository PublisherRepository { get; set; }

    public Task SaveAsync()
    {
        _dbContext.SaveChanges();
        return Task.CompletedTask;
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (!_disposed && disposing)
        {
            _dbContext?.Dispose();
        }

        _disposed = true;
    }
}
