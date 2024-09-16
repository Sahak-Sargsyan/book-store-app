namespace BookStore.DAL.Entitites;

public class Genre : BaseEntity
{
    public string Name { get; set; }

    public ICollection<BookGenre> Books { get; set; }
}
