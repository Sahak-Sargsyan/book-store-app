namespace BookStore.Dtos;

#pragma warning disable
public record GenreDto
{
    public string Name { get; set; }
}

public record GenreListDto
{
    public Guid Id { get; set; }

    public string Name { get; set; }
}

public record GenreCreateDto
{
    public GenreDto Genre { get; set; }
}

public record GenreUpdateDto
{
    public GenreListDto Genre { get; set; }
}