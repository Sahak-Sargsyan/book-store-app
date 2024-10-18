namespace BookStore.Dtos;

#pragma warning disable
public record PublisherDto
{
    public string CompanyName { get; set; }
}

public record PublisherListDto
{
    public Guid Id { get; set; }

    public string CompanyName { get; set; }
}

public record PublisherCreateDto
{
    public PublisherDto Publisher { get; set; }
}

public record PublisherUpdateDto
{
    public PublisherListDto Publisher { get; set; }
}