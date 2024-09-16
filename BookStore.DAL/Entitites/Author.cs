namespace BookStore.DAL.Entitites;

public class Author : BaseEntity
{
    public string FirstName { get; set; }

    public string LastName { get; set; }

    public DateTime BirthDate { get; set; }

    public ICollection<BookAuthor> Books { get; set; }
}
