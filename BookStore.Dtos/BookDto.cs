namespace BookStore.Dtos;

#pragma warning disable
public record BookDto
{
    public string Isbn13 { get; set; }

    public string Title { get; set; }

    public string? Description { get; set; }

    public DateTime ReleaseDate { get; set; }

    public string Language { get; set; }
}

public record BookListDto
{
    public Guid Id { get; set; }

    public string Isbn13 { get; set; }

    public string Title { get; set; }

    public string? Description { get; set; }

    public DateTime ReleaseDate { get; set; }

    public string Language { get; set; }
}

public record BookCreateDto
{
    public BookDto Book { get; set; }

    public Guid Publisher { get; set; }

    public IEnumerable<Guid> Authors { get; set; }

    public IEnumerable<Guid> Genres { get; set; }
}

public record BookUpdateDto
{
    public BookListDto Book { get; set; }

    public Guid Publisher { get; set; }

    public IEnumerable<Guid> Authors { get; set; }

    public IEnumerable<Guid> Genres { get; set; }
}