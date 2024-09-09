namespace BookStore.DAL.Entitites;

public class Genre
{
    public string Name { get; set; }

    public Guid? ParentGenreId { get; set; }

    ICollection<BookGenre> Books { get; set; }
}
