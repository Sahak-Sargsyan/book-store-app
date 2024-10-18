namespace BookStore.Dtos;

#pragma warning disable
public record AuthorDto
{
    public string FirstName { get; set; }

    public string LastName { get; set; }

    public DateTime BirthDate { get; set; }
}

public record AuthorListDto
{
    public Guid Id { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public DateTime BirthDate { get; set; }
}

public record AuthorCreateDto
{
    public AuthorDto Author { get; set; }
}

public record AuthorUpdateDto
{
    public AuthorListDto Author { get; set; }
}
