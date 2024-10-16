namespace BookStore.DAL.Entitites;

public class Book : BaseEntity
{
    public string Isbn { get; set; }

    public string Title { get; set; }

    public string? Description { get; set; }
    
    public DateTime ReleaseDate { get; set; }

    public string Language { get; set; }

    public Guid PublisherId { get; set; }

    public Publisher Publisher { get; set; }

    public ICollection<BookGenre> Genres { get; set; }

    public ICollection<BookAuthor> Authors { get; set; }
}

