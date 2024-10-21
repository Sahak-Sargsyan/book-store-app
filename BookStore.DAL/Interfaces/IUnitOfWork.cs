namespace BookStore.DAL.Interface;

public interface IUnitOfWork
{
    IBookRepository BookRepository { get; }

    IAuthorRepository AuthorRepository { get; }

    IGenreRepository GenreRepository { get; }

    IPublisherRepository PublisherRepository { get; }

    Task SaveAsync();
}
